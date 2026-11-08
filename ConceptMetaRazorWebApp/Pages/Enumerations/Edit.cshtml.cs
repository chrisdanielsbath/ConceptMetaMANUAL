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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Enumerations
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.Enumeration" /> entity
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
        /// creates a new instance of the EditModel class for the Enumeration entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EditModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.Enumeration Enumeration { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }
        public SelectList ConceptModelSL { get; private set; }
        public SelectList DataTypeSL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Enumeration that is to be edited
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Enumeration?.ConceptModelId;
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
        private async Task BuildBreadcrumbAsync()
        {
            if (Enumeration?.ConceptModel != null)
            {
                ConceptModel = Enumeration?.ConceptModel;
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
        public async Task<IActionResult> OnGetAsync(int enumerationId)
        {
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

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Enumerations.Update(Enumeration);
                await _context.SaveChangesAsync();
                return RedirectToPage("Details", new { enumerationId = Enumeration.EnumerationId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        private async Task BuildDropdownsAsync()
        {
            // create basic queries
            IQueryable<RazorModels.ConceptModel> conceptModelQuery = _context.ConceptModels
                    .AsQueryable<RazorModels.ConceptModel>();

            IQueryable<RazorModels.DataType> dataTypeQuery = _context.DataTypes
                    .AsQueryable<RazorModels.DataType>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptModelQuery = conceptModelQuery.Where(conceptModel => conceptModel.ConceptModelId == ConceptModelId);
                dataTypeQuery = dataTypeQuery.Where(dataType => dataType.ConceptModelId == ConceptModelId);
            }

            // setup ConceptModelSL
            ConceptModelSL = new SelectList(
                await conceptModelQuery.ToListAsync<RazorModels.ConceptModel>(),
                "PkString",
                "ValueString",
                Enumeration.ConceptModelKeyString);

            // setup DataTypeSL
            DataTypeSL = new SelectList(
                await dataTypeQuery.ToListAsync<RazorModels.DataType>(),
                "PkString",
                "ValueString",
                Enumeration.DataTypeKeyString);
        }

        #endregion
    }
}
