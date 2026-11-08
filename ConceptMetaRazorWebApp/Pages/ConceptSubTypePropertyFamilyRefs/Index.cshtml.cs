/****************************
 * Index.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptSubTypePropertyFamilyRefs
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    [Authorize]
    public partial class IndexModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the IndexModel class for the ConceptSubTypePropertyFamilyRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.ConceptSubTypePropertyFamilyRef> ConceptSubTypePropertyFamilyRefs { get; set; }
        private RazorModels.ConceptSubType ConceptSubType { get; set; }

        /// <summary>
        /// The ConceptSubTypeId which partially defines the context for the ConceptSubTypePropertyFamilyRefs that are to be listed
        /// </summary>
        public int? ConceptSubTypeId
        {
            get
            {
                int? result;
                // inspect query string
                string paramValue = Request.Query["conceptSubTypeId"];
                result = (string.IsNullOrWhiteSpace(paramValue) ? null : int.Parse(paramValue));
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }
        public int? Breadcrumb_ConceptModel_ConceptModelId { get; private set; }
        public string Breadcrumb_ConceptModel_ValueString { get; private set; }
        public int? Breadcrumb_Concept_ConceptId { get; private set; }
        public string Breadcrumb_Concept_ValueString { get; private set; }
        public int? Breadcrumb_ConceptSubType_ConceptSubTypeId { get; private set; }
        public string Breadcrumb_ConceptSubType_ValueString { get; private set; }

        #endregion

        #region Instance Methods
        private async Task BuildBreadcrumbAsync()
        {
            ConceptSubType = await _context.ConceptSubTypes
                    .Where(conceptSubType => conceptSubType.ConceptSubTypeId == ConceptSubTypeId)
                    .Include(conceptSubType => conceptSubType.Concept)
                    .Include(conceptSubType => conceptSubType.Concept.ConceptModel)
                    .Include(conceptSubType => conceptSubType.Concept.DataType)
                    .Include(conceptSubType => conceptSubType.Concept.DataType.ConceptModel)
                    .FirstOrDefaultAsync();

            Breadcrumb_ConceptModel_ConceptModelId = ConceptSubType?.Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptSubType?.Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = ConceptSubType?.Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = ConceptSubType?.Concept?.ValueString;

            Breadcrumb_ConceptSubType_ConceptSubTypeId = ConceptSubType?.ConceptSubTypeId;
            Breadcrumb_ConceptSubType_ValueString = ConceptSubType?.ValueString;
        }
        public async Task OnGetAsync()
        {
            await BuildBreadcrumbAsync();

            IQueryable<RazorModels.ConceptSubTypePropertyFamilyRef> conceptSubTypePropertyFamilyRefQuery = _context.ConceptSubTypePropertyFamilyRefs.AsQueryable<RazorModels.ConceptSubTypePropertyFamilyRef>();

            if (!string.IsNullOrWhiteSpace(ConceptSubTypeId.ToString()))
            {
                conceptSubTypePropertyFamilyRefQuery = conceptSubTypePropertyFamilyRefQuery.Where(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypeId == ConceptSubTypeId);
            }

            ConceptSubTypePropertyFamilyRefs = await conceptSubTypePropertyFamilyRefQuery
                .Include(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubType)
                .Include(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptPropertyFamily)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
