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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptUniqueKeyPropertyFamilyRefs
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.ConceptUniqueKeyPropertyFamilyRef" /> entity
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
        /// creates a new instance of the IndexModel class for the ConceptUniqueKeyPropertyFamilyRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.ConceptUniqueKeyPropertyFamilyRef> ConceptUniqueKeyPropertyFamilyRefs { get; set; }
        private RazorModels.ConceptUniqueKey ConceptUniqueKey { get; set; }

        /// <summary>
        /// The ConceptUniqueKeyId which partially defines the context for the ConceptUniqueKeyPropertyFamilyRefs that are to be listed
        /// </summary>
        public int? ConceptUniqueKeyId
        {
            get
            {
                int? result;
                // inspect query string
                string paramValue = Request.Query["conceptUniqueKeyId"];
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
        public int? Breadcrumb_ConceptUniqueKey_ConceptUniqueKeyId { get; private set; }
        public string Breadcrumb_ConceptUniqueKey_ValueString { get; private set; }

        #endregion

        #region Instance Methods
        private async Task BuildBreadcrumbAsync()
        {
            ConceptUniqueKey = await _context.ConceptUniqueKeys
                    .Where(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId == ConceptUniqueKeyId)
                    .Include(conceptUniqueKey => conceptUniqueKey.Concept)
                    .Include(conceptUniqueKey => conceptUniqueKey.Concept.ConceptModel)
                    .Include(conceptUniqueKey => conceptUniqueKey.Concept.DataType)
                    .Include(conceptUniqueKey => conceptUniqueKey.Concept.DataType.ConceptModel)
                    .FirstOrDefaultAsync();

            Breadcrumb_ConceptModel_ConceptModelId = ConceptUniqueKey?.Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptUniqueKey?.Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = ConceptUniqueKey?.Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = ConceptUniqueKey?.Concept?.ValueString;

            Breadcrumb_ConceptUniqueKey_ConceptUniqueKeyId = ConceptUniqueKey?.ConceptUniqueKeyId;
            Breadcrumb_ConceptUniqueKey_ValueString = ConceptUniqueKey?.ValueString;
        }
        public async Task OnGetAsync()
        {
            await BuildBreadcrumbAsync();

            IQueryable<RazorModels.ConceptUniqueKeyPropertyFamilyRef> conceptUniqueKeyPropertyFamilyRefQuery = _context.ConceptUniqueKeyPropertyFamilyRefs.AsQueryable<RazorModels.ConceptUniqueKeyPropertyFamilyRef>();

            if (!string.IsNullOrWhiteSpace(ConceptUniqueKeyId.ToString()))
            {
                conceptUniqueKeyPropertyFamilyRefQuery = conceptUniqueKeyPropertyFamilyRefQuery.Where(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == ConceptUniqueKeyId);
            }

            ConceptUniqueKeyPropertyFamilyRefs = await conceptUniqueKeyPropertyFamilyRefQuery
                .Include(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey)
                .Include(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
