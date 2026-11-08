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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptSubTypePropertyFamilyRefs
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> entity
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
        /// creates a new instance of the EditModel class for the ConceptSubTypePropertyFamilyRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EditModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.ConceptSubTypePropertyFamilyRef ConceptSubTypePropertyFamilyRef { get; set; }
        private RazorModels.ConceptSubType ConceptSubType { get; set; }
        public SelectList ConceptSubTypeSL { get; private set; }
        public SelectList ConceptPropertyFamilySL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the ConceptSubTypePropertyFamilyRef that is to be edited
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptSubType?.Concept?.ConceptModelId;
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        /// The ConceptId which partially defines the context for the ConceptSubTypePropertyFamilyRef that is to be edited
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
                return null;
            }
        }

        /// <summary>
        /// The ConceptSubTypeId which partially defines the context for the ConceptSubTypePropertyFamilyRef that is to be edited
        /// </summary>
        public int? ConceptSubTypeId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptSubTypePropertyFamilyRef?.ConceptSubTypeId;
                if (result != null)
                {
                    return result;
                }
                result = result = ConceptSubType?.ConceptSubTypeId;
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
        private async Task BuildBreadcrumbAsync()
        {
            if (ConceptSubTypePropertyFamilyRef?.ConceptSubType != null)
            {
                ConceptSubType = ConceptSubTypePropertyFamilyRef?.ConceptSubType;
            }
            else
            {
                ConceptSubType = await _context.ConceptSubTypes
                        .Where(conceptSubType => conceptSubType.ConceptSubTypeId == ConceptSubTypeId)
                        .Include(conceptSubType => conceptSubType.Concept)
                        .Include(conceptSubType => conceptSubType.Concept.ConceptModel)
                        .Include(conceptSubType => conceptSubType.Concept.DataType)
                        .Include(conceptSubType => conceptSubType.Concept.DataType.ConceptModel)
                        .FirstOrDefaultAsync();
            }

            Breadcrumb_ConceptModel_ConceptModelId = ConceptSubType?.Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptSubType?.Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = ConceptSubType?.Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = ConceptSubType?.Concept?.ValueString;

            Breadcrumb_ConceptSubType_ConceptSubTypeId = ConceptSubType?.ConceptSubTypeId;
            Breadcrumb_ConceptSubType_ValueString = ConceptSubType?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int conceptSubTypePropertyFamilyRefId)
        {
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

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.ConceptSubTypePropertyFamilyRefs.Update(ConceptSubTypePropertyFamilyRef);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index", new { conceptSubTypeId = ConceptSubTypeId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        private async Task BuildDropdownsAsync()
        {
            // create basic queries
            IQueryable<RazorModels.ConceptSubType> conceptSubTypeQuery = _context.ConceptSubTypes
                    .AsQueryable<RazorModels.ConceptSubType>();

            IQueryable<RazorModels.ConceptPropertyFamily> conceptPropertyFamilyQuery = _context.ConceptPropertyFamilies
                    .AsQueryable<RazorModels.ConceptPropertyFamily>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptSubTypeQuery = conceptSubTypeQuery.Where(conceptSubType => conceptSubType.Concept.ConceptModelId == ConceptModelId);
                conceptPropertyFamilyQuery = conceptPropertyFamilyQuery.Where(conceptPropertyFamily => conceptPropertyFamily.Concept.ConceptModelId == ConceptModelId);
            }
            // adjust queries to reflect ConceptId
            if (!string.IsNullOrWhiteSpace(ConceptId.ToString()))
            {
                conceptSubTypeQuery = conceptSubTypeQuery.Where(conceptSubType => conceptSubType.ConceptId == ConceptId);
                conceptPropertyFamilyQuery = conceptPropertyFamilyQuery.Where(conceptPropertyFamily => conceptPropertyFamily.ConceptId == ConceptId);
            }
            // adjust queries to reflect ConceptSubTypeId
            if (!string.IsNullOrWhiteSpace(ConceptSubTypeId.ToString()))
            {
                conceptSubTypeQuery = conceptSubTypeQuery.Where(conceptSubType => conceptSubType.ConceptSubTypeId == ConceptSubTypeId);
            }

            // setup ConceptSubTypeSL
            ConceptSubTypeSL = new SelectList(
                await conceptSubTypeQuery.ToListAsync<RazorModels.ConceptSubType>(),
                "PkString",
                "ValueString",
                ConceptSubTypePropertyFamilyRef.ConceptSubTypeKeyString);

            // setup ConceptPropertyFamilySL
            ConceptPropertyFamilySL = new SelectList(
                await conceptPropertyFamilyQuery.ToListAsync<RazorModels.ConceptPropertyFamily>(),
                "PkString",
                "ValueString",
                ConceptSubTypePropertyFamilyRef.ConceptPropertyFamilyKeyString);
        }

        #endregion
    }
}
