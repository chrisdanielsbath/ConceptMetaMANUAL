/****************************
 * Details.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptSubTypePropertyFamilyRefs
{
    /// <summary>
    /// Details Model class for the <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    [Authorize]
    public partial class DetailsModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the DetailsModel class for the ConceptSubTypePropertyFamilyRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DetailsModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public RazorModels.ConceptSubTypePropertyFamilyRef ConceptSubTypePropertyFamilyRef { get; set; }
        private RazorModels.ConceptSubType ConceptSubType { get; set; }

        /// <summary>
        /// The ConceptSubTypeId which partially defines the context for the ConceptSubTypePropertyFamilyRef that is to be viewed
        /// </summary>
        public int? ConceptSubTypeId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptSubType?.ConceptSubTypeId;
                if (result != null)
                {
                    return result;
                }
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
        private void BuildBreadcrumb()
        {
            ConceptSubType = ConceptSubTypePropertyFamilyRef?.ConceptSubType;

            Breadcrumb_ConceptModel_ConceptModelId = ConceptSubType?.Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptSubType?.Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = ConceptSubType?.Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = ConceptSubType?.Concept?.ValueString;

            Breadcrumb_ConceptSubType_ConceptSubTypeId = ConceptSubType?.ConceptSubTypeId;
            Breadcrumb_ConceptSubType_ValueString = ConceptSubType?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? conceptSubTypePropertyFamilyRefId)
        {
            if (conceptSubTypePropertyFamilyRefId == null)
            {
               return NotFound();
            }

            ConceptSubTypePropertyFamilyRef = await _context.ConceptSubTypePropertyFamilyRefs
                .Include(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubType)
                .Include(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptPropertyFamily)
                .AsNoTracking()
                .FirstOrDefaultAsync(conceptSubTypePropertyFamilyRef => 
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId == conceptSubTypePropertyFamilyRefId));

            if (ConceptSubTypePropertyFamilyRef == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }

        #endregion
    }
}
