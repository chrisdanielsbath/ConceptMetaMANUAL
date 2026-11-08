/****************************
 * CreateStep1.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Concepts
{
    /// <summary>
    /// CreateStep1 Model class for the <see cref="RazorModels.Concept" /> entity
    /// </summary>
    [Authorize]
    public partial class CreateStep1Model
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the CreateStep1Model class for the Concept entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public CreateStep1Model(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.Concept Concept { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Concept that is to be created
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Concept?.ConceptModelId;
                if (result != null)
                {
                    return result;
                }
                result = result = ConceptModel?.ConceptModelId;
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

        /// <summary>
        /// A string that identifies the ConceptModel within which the Concept is to be created
        /// </summary>
        public string ConceptModelKeyString
        {
            get
            {
                return ConceptModel?.PkString;
            }
        }
        public int? Breadcrumb_ConceptModel_ConceptModelId { get; private set; }
        public string Breadcrumb_ConceptModel_ValueString { get; private set; }

        #endregion

        #region Instance Methods
        private async Task BuildBreadcrumbAsync()
        {
            if (Concept?.ConceptModel != null)
            {
                ConceptModel = Concept?.ConceptModel;
            }
            else
            {
                ConceptModel = await _context.ConceptModels
                        .Where(conceptModel => conceptModel.ConceptModelId == ConceptModelId)
                        .FirstOrDefaultAsync();
            }

            Breadcrumb_ConceptModel_ConceptModelId = ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptModel?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await BuildBreadcrumbAsync();
            return Page();
        }

        #endregion
    }
}
