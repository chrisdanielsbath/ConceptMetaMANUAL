/****************************
 * Delete.cshtml.cs
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
    /// Delete Model class for the <see cref="RazorModels.Concept" /> entity
    /// </summary>
    [Authorize]
    public partial class DeleteModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the DeleteModel class for the Concept entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DeleteModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.Concept Concept { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Concept that is to be deleted
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
        public int? Breadcrumb_ConceptModel_ConceptModelId { get; private set; }
        public string Breadcrumb_ConceptModel_ValueString { get; private set; }

        #endregion

        #region Instance Methods
        private void BuildBreadcrumb()
        {
            ConceptModel = Concept?.ConceptModel;

            Breadcrumb_ConceptModel_ConceptModelId = ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptModel?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? conceptId)
        {
            if (conceptId == null)
            {
               return NotFound();
            }

            Concept = await _context.Concepts
                .Include(concept => concept.ConceptModel)
                .Include(concept => concept.DataType)
                .Include(concept => concept.DataType.ConceptModel)
                .Include(concept => concept.Enumeration)
                .Include(concept => concept.Enumeration.ConceptModel)
                .Include(concept => concept.Enumeration.DataType)
                .Include(concept => concept.Enumeration.DataType.ConceptModel)
                .Include(concept => concept.BasedOnConcept)
                .Include(concept => concept.BasedOnConcept.ConceptModel)
                .Include(concept => concept.BasedOnConcept.DataType)
                .Include(concept => concept.BasedOnConcept.DataType.ConceptModel)
                .Include(concept => concept.ReferencedConcept)
                .Include(concept => concept.ReferencedConcept.ConceptModel)
                .Include(concept => concept.ReferencedConcept.DataType)
                .Include(concept => concept.ReferencedConcept.DataType.ConceptModel)
                .Include(concept => concept.ReferencedUniqueKey)
                .Include(concept => concept.SpecialisedConcept)
                .Include(concept => concept.SpecialisedConcept.ConceptModel)
                .Include(concept => concept.SpecialisedConcept.DataType)
                .Include(concept => concept.SpecialisedConcept.DataType.ConceptModel)
                .Include(concept => concept.SpecialisedSubType)
                .AsNoTracking()
                .FirstOrDefaultAsync(concept => 
                        (concept.ConceptId == conceptId));

            if (Concept == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? conceptId)
        {
            if (conceptId == null)
            {
               return NotFound();
            }

            Concept = await _context.Concepts.FindAsync(conceptId);

            if (Concept != null)
            {
                _context.Concepts.Remove(Concept);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { conceptModelId = ConceptModelId });
        }

        #endregion
    }
}
