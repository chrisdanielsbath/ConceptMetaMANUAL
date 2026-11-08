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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptSubTypes
{
    /// <summary>
    /// Delete Model class for the <see cref="RazorModels.ConceptSubType" /> entity
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
        /// creates a new instance of the DeleteModel class for the ConceptSubType entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DeleteModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.ConceptSubType ConceptSubType { get; set; }
        private RazorModels.Concept Concept { get; set; }

        /// <summary>
        /// The ConceptId which partially defines the context for the ConceptSubType that is to be deleted
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptSubType?.ConceptId;
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
            Concept = ConceptSubType?.Concept;

            Breadcrumb_ConceptModel_ConceptModelId = Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = Concept?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? conceptSubTypeId)
        {
            if (conceptSubTypeId == null)
            {
               return NotFound();
            }

            ConceptSubType = await _context.ConceptSubTypes
                .Include(conceptSubType => conceptSubType.Concept)
                .Include(conceptSubType => conceptSubType.Concept.ConceptModel)
                .Include(conceptSubType => conceptSubType.Concept.DataType)
                .Include(conceptSubType => conceptSubType.Concept.DataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(conceptSubType => 
                        (conceptSubType.ConceptSubTypeId == conceptSubTypeId));

            if (ConceptSubType == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? conceptSubTypeId)
        {
            if (conceptSubTypeId == null)
            {
               return NotFound();
            }

            ConceptSubType = await _context.ConceptSubTypes.FindAsync(conceptSubTypeId);

            if (ConceptSubType != null)
            {
                _context.ConceptSubTypes.Remove(ConceptSubType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { conceptId = ConceptId });
        }

        #endregion
    }
}
