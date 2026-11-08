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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Qualifiers
{
    /// <summary>
    /// Details Model class for the <see cref="RazorModels.Qualifier" /> entity
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
        /// creates a new instance of the DetailsModel class for the Qualifier entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DetailsModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public RazorModels.Qualifier Qualifier { get; set; }
        private RazorModels.Concept Concept { get; set; }

        /// <summary>
        /// The ConceptId which partially defines the context for the Qualifier that is to be viewed
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Concept?.ConceptId;
                if (result != null)
                {
                    return result;
                }
                // inspect query string
                string paramValue = Request.Query["conceptId"];
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

        #endregion

        #region Instance Methods
        private void BuildBreadcrumb()
        {
            Concept = Qualifier?.Concept;

            Breadcrumb_ConceptModel_ConceptModelId = Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = Concept?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? qualifierId)
        {
            if (qualifierId == null)
            {
               return NotFound();
            }

            Qualifier = await _context.Qualifiers
                .Include(qualifier => qualifier.Concept)
                .Include(qualifier => qualifier.Concept.ConceptModel)
                .Include(qualifier => qualifier.Concept.DataType)
                .Include(qualifier => qualifier.Concept.DataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(qualifier => 
                        (qualifier.QualifierId == qualifierId));

            if (Qualifier == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }

        #endregion
    }
}
