/****************************
 * Edit.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptPropertyFamilies
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.ConceptPropertyFamily" /> entity
    /// </summary>
    [Authorize]
    public partial class EditModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the EditModel class for the ConceptPropertyFamily entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EditModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.ConceptPropertyFamily ConceptPropertyFamily { get; set; }
        private RazorModels.Concept Concept { get; set; }
        public SelectList ConceptSL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the ConceptPropertyFamily that is to be edited
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
                return null;
            }
        }

        /// <summary>
        /// The ConceptId which partially defines the context for the ConceptPropertyFamily that is to be edited
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptPropertyFamily?.ConceptId;
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
        private async Task BuildBreadcrumbAsync()
        {
            if (ConceptPropertyFamily?.Concept != null)
            {
                Concept = ConceptPropertyFamily?.Concept;
            }
            else
            {
                Concept = await _context.Concepts
                        .Where(concept => concept.ConceptId == ConceptId)
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
                        .FirstOrDefaultAsync();
            }

            Breadcrumb_ConceptModel_ConceptModelId = Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = Concept?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int conceptPropertyFamilyId)
        {
            ConceptPropertyFamily = await _context.ConceptPropertyFamilies
                .Include(conceptPropertyFamily => conceptPropertyFamily.Concept)
                .Include(conceptPropertyFamily => conceptPropertyFamily.Concept.ConceptModel)
                .Include(conceptPropertyFamily => conceptPropertyFamily.Concept.DataType)
                .Include(conceptPropertyFamily => conceptPropertyFamily.Concept.DataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(conceptPropertyFamily => 
                        (conceptPropertyFamily.ConceptPropertyFamilyId == conceptPropertyFamilyId));

            if (ConceptPropertyFamily == null)
            {
                return NotFound();
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.ConceptPropertyFamilies.Update(ConceptPropertyFamily);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index", new { conceptId = ConceptId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        private async Task BuildDropdownsAsync()
        {
            // create basic queries
            IQueryable<RazorModels.Concept> conceptQuery = _context.Concepts
                    .AsQueryable<RazorModels.Concept>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptQuery = conceptQuery.Where(concept => concept.ConceptModelId == ConceptModelId);
            }
            // adjust queries to reflect ConceptId
            if (!string.IsNullOrWhiteSpace(ConceptId.ToString()))
            {
                conceptQuery = conceptQuery.Where(concept => concept.ConceptId == ConceptId);
            }

            // setup ConceptSL
            ConceptSL = new SelectList(
                await conceptQuery.ToListAsync<RazorModels.Concept>(),
                "PkString",
                "ValueString",
                ConceptPropertyFamily.ConceptKeyString);
        }

        #endregion
    }
}
