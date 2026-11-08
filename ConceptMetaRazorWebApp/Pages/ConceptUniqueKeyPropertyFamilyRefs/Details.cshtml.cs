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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptUniqueKeyPropertyFamilyRefs
{
    /// <summary>
    /// Details Model class for the <see cref="RazorModels.ConceptUniqueKeyPropertyFamilyRef" /> entity
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
        /// creates a new instance of the DetailsModel class for the ConceptUniqueKeyPropertyFamilyRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DetailsModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public RazorModels.ConceptUniqueKeyPropertyFamilyRef ConceptUniqueKeyPropertyFamilyRef { get; set; }
        private RazorModels.ConceptUniqueKey ConceptUniqueKey { get; set; }

        /// <summary>
        /// The ConceptUniqueKeyId which partially defines the context for the ConceptUniqueKeyPropertyFamilyRef that is to be viewed
        /// </summary>
        public int? ConceptUniqueKeyId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptUniqueKey?.ConceptUniqueKeyId;
                if (result != null)
                {
                    return result;
                }
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
        private void BuildBreadcrumb()
        {
            ConceptUniqueKey = ConceptUniqueKeyPropertyFamilyRef?.ConceptUniqueKey;

            Breadcrumb_ConceptModel_ConceptModelId = ConceptUniqueKey?.Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptUniqueKey?.Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = ConceptUniqueKey?.Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = ConceptUniqueKey?.Concept?.ValueString;

            Breadcrumb_ConceptUniqueKey_ConceptUniqueKeyId = ConceptUniqueKey?.ConceptUniqueKeyId;
            Breadcrumb_ConceptUniqueKey_ValueString = ConceptUniqueKey?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? conceptUniqueKeyPropertyFamilyRefId)
        {
            if (conceptUniqueKeyPropertyFamilyRefId == null)
            {
               return NotFound();
            }

            ConceptUniqueKeyPropertyFamilyRef = await _context.ConceptUniqueKeyPropertyFamilyRefs
                .Include(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey)
                .Include(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily)
                .AsNoTracking()
                .FirstOrDefaultAsync(conceptUniqueKeyPropertyFamilyRef => 
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId == conceptUniqueKeyPropertyFamilyRefId));

            if (ConceptUniqueKeyPropertyFamilyRef == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }

        #endregion
    }
}
