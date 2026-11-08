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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Includes
{
    /// <summary>
    /// Delete Model class for the <see cref="RazorModels.Include" /> entity
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
        /// creates a new instance of the DeleteModel class for the Include entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DeleteModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.Include Include { get; set; }
        private RazorModels.Concept Concept { get; set; }

        /// <summary>
        /// The ConceptId which partially defines the context for the Include that is to be deleted
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Include?.ConceptId;
                if (result != null)
                {
                    return result;
                }
                result = result = Concept?.ConceptId;
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
            Concept = Include?.Concept;

            Breadcrumb_ConceptModel_ConceptModelId = Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = Concept?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? includeId)
        {
            if (includeId == null)
            {
               return NotFound();
            }

            Include = await _context.Includes
                .Include(include => include.Concept)
                .Include(include => include.Concept.ConceptModel)
                .Include(include => include.Concept.DataType)
                .Include(include => include.Concept.DataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(include => 
                        (include.IncludeId == includeId));

            if (Include == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? includeId)
        {
            if (includeId == null)
            {
               return NotFound();
            }

            Include = await _context.Includes.FindAsync(includeId);

            if (Include != null)
            {
                _context.Includes.Remove(Include);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { conceptId = ConceptId });
        }

        #endregion
    }
}
