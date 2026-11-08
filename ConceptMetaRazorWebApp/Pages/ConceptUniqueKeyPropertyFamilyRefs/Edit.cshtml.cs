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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptUniqueKeyPropertyFamilyRefs
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.ConceptUniqueKeyPropertyFamilyRef" /> entity
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
        /// creates a new instance of the EditModel class for the ConceptUniqueKeyPropertyFamilyRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EditModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.ConceptUniqueKeyPropertyFamilyRef ConceptUniqueKeyPropertyFamilyRef { get; set; }
        private RazorModels.ConceptUniqueKey ConceptUniqueKey { get; set; }
        public SelectList ConceptUniqueKeySL { get; private set; }
        public SelectList ConceptPropertyFamilySL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the ConceptUniqueKeyPropertyFamilyRef that is to be edited
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptUniqueKey?.Concept?.ConceptModelId;
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        /// The ConceptId which partially defines the context for the ConceptUniqueKeyPropertyFamilyRef that is to be edited
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptUniqueKey?.ConceptId;
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        /// The ConceptUniqueKeyId which partially defines the context for the ConceptUniqueKeyPropertyFamilyRef that is to be edited
        /// </summary>
        public int? ConceptUniqueKeyId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptUniqueKeyPropertyFamilyRef?.ConceptUniqueKeyId;
                if (result != null)
                {
                    return result;
                }
                result = result = ConceptUniqueKey?.ConceptUniqueKeyId;
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
        private async Task BuildBreadcrumbAsync()
        {
            if (ConceptUniqueKeyPropertyFamilyRef?.ConceptUniqueKey != null)
            {
                ConceptUniqueKey = ConceptUniqueKeyPropertyFamilyRef?.ConceptUniqueKey;
            }
            else
            {
                ConceptUniqueKey = await _context.ConceptUniqueKeys
                        .Where(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId == ConceptUniqueKeyId)
                        .Include(conceptUniqueKey => conceptUniqueKey.Concept)
                        .Include(conceptUniqueKey => conceptUniqueKey.Concept.ConceptModel)
                        .Include(conceptUniqueKey => conceptUniqueKey.Concept.DataType)
                        .Include(conceptUniqueKey => conceptUniqueKey.Concept.DataType.ConceptModel)
                        .FirstOrDefaultAsync();
            }

            Breadcrumb_ConceptModel_ConceptModelId = ConceptUniqueKey?.Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptUniqueKey?.Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = ConceptUniqueKey?.Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = ConceptUniqueKey?.Concept?.ValueString;

            Breadcrumb_ConceptUniqueKey_ConceptUniqueKeyId = ConceptUniqueKey?.ConceptUniqueKeyId;
            Breadcrumb_ConceptUniqueKey_ValueString = ConceptUniqueKey?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int conceptUniqueKeyPropertyFamilyRefId)
        {
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

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.ConceptUniqueKeyPropertyFamilyRefs.Update(ConceptUniqueKeyPropertyFamilyRef);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index", new { conceptUniqueKeyId = ConceptUniqueKeyId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        private async Task BuildDropdownsAsync()
        {
            // create basic queries
            IQueryable<RazorModels.ConceptUniqueKey> conceptUniqueKeyQuery = _context.ConceptUniqueKeys
                    .AsQueryable<RazorModels.ConceptUniqueKey>();

            IQueryable<RazorModels.ConceptPropertyFamily> conceptPropertyFamilyQuery = _context.ConceptPropertyFamilies
                    .AsQueryable<RazorModels.ConceptPropertyFamily>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptUniqueKeyQuery = conceptUniqueKeyQuery.Where(conceptUniqueKey => conceptUniqueKey.Concept.ConceptModelId == ConceptModelId);
                conceptPropertyFamilyQuery = conceptPropertyFamilyQuery.Where(conceptPropertyFamily => conceptPropertyFamily.Concept.ConceptModelId == ConceptModelId);
            }
            // adjust queries to reflect ConceptId
            if (!string.IsNullOrWhiteSpace(ConceptId.ToString()))
            {
                conceptUniqueKeyQuery = conceptUniqueKeyQuery.Where(conceptUniqueKey => conceptUniqueKey.ConceptId == ConceptId);
                conceptPropertyFamilyQuery = conceptPropertyFamilyQuery.Where(conceptPropertyFamily => conceptPropertyFamily.ConceptId == ConceptId);
            }
            // adjust queries to reflect ConceptUniqueKeyId
            if (!string.IsNullOrWhiteSpace(ConceptUniqueKeyId.ToString()))
            {
                conceptUniqueKeyQuery = conceptUniqueKeyQuery.Where(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId == ConceptUniqueKeyId);
            }

            // setup ConceptUniqueKeySL
            ConceptUniqueKeySL = new SelectList(
                await conceptUniqueKeyQuery.ToListAsync<RazorModels.ConceptUniqueKey>(),
                "PkString",
                "ValueString",
                ConceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyKeyString);

            // setup ConceptPropertyFamilySL
            ConceptPropertyFamilySL = new SelectList(
                await conceptPropertyFamilyQuery.ToListAsync<RazorModels.ConceptPropertyFamily>(),
                "PkString",
                "ValueString",
                ConceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyKeyString);
        }

        #endregion
    }
}
