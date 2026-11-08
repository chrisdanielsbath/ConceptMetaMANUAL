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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Enumerations
{
    /// <summary>
    /// Details Model class for the <see cref="RazorModels.Enumeration" /> entity
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
        /// creates a new instance of the DetailsModel class for the Enumeration entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DetailsModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public RazorModels.Enumeration Enumeration { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Enumeration that is to be viewed
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptModel?.ConceptModelId;
                if (result != null)
                {
                    return result;
                }
                // inspect query string
                string paramValue = Request.Query["conceptModelId"];
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

        #endregion

        #region Instance Methods
        private void BuildBreadcrumb()
        {
            ConceptModel = Enumeration?.ConceptModel;

            Breadcrumb_ConceptModel_ConceptModelId = ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptModel?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? enumerationId)
        {
            if (enumerationId == null)
            {
               return NotFound();
            }

            Enumeration = await _context.Enumerations
                .Include(enumeration => enumeration.ConceptModel)
                .Include(enumeration => enumeration.DataType)
                .Include(enumeration => enumeration.DataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(enumeration => 
                        (enumeration.EnumerationId == enumerationId));

            if (Enumeration == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }

        #endregion
    }
}
