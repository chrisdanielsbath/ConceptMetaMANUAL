/****************************
 * Delete.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptModels
{
    /// <summary>
    /// Delete Model class for the <see cref="RazorModels.ConceptModel" /> entity
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
        /// creates a new instance of the DeleteModel class for the ConceptModel entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DeleteModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.ConceptModel ConceptModel { get; set; }

        #endregion

        #region Instance Methods
        public async Task<IActionResult> OnGetAsync(int? conceptModelId)
        {
            if (conceptModelId == null)
            {
               return NotFound();
            }

            ConceptModel = await _context.ConceptModels
                .AsNoTracking()
                .FirstOrDefaultAsync(conceptModel => 
                        (conceptModel.ConceptModelId == conceptModelId));

            if (ConceptModel == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? conceptModelId)
        {
            if (conceptModelId == null)
            {
               return NotFound();
            }

            ConceptModel = await _context.ConceptModels.FindAsync(conceptModelId);

            if (ConceptModel != null)
            {
                _context.ConceptModels.Remove(ConceptModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new {  });
        }

        #endregion
    }
}
