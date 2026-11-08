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
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.DataTypes
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.DataType" /> entity
    /// </summary>
    [Authorize]
    public partial class EditModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        // the enum context from which enumerations will be retrieved
        private readonly EnumContext _enumContext;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the EditModel class for the DataType entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EditModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
            _enumContext = new EnumContext();
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.DataType DataType { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }
        public SelectList ConceptModelSL { get; private set; }
        public SelectList BasicDataTypeSL { get; private set; }
        public SelectList HasLengthSL { get; private set; }
        public SelectList HasTotalDigitsSL { get; private set; }
        public SelectList HasDecimalPlacesSL { get; private set; }
        public SelectList HasIdentitySL { get; private set; }
        public SelectList HasDatePrecisionSL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the DataType that is to be edited
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = DataType?.ConceptModelId;
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
            if (DataType?.ConceptModel != null)
            {
                ConceptModel = DataType?.ConceptModel;
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
        public async Task<IActionResult> OnGetAsync(int dataTypeId)
        {
            DataType = await _context.DataTypes
                .Include(dataType => dataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(dataType => 
                        (dataType.DataTypeId == dataTypeId));

            if (DataType == null)
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
                _context.DataTypes.Update(DataType);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index", new { conceptModelId = ConceptModelId });
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

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptModelQuery = conceptModelQuery.Where(conceptModel => conceptModel.ConceptModelId == ConceptModelId);
            }

            // setup ConceptModelSL
            ConceptModelSL = new SelectList(
                await conceptModelQuery.ToListAsync<RazorModels.ConceptModel>(),
                "PkString",
                "ValueString",
                DataType.ConceptModelKeyString);

            // setup BasicDataTypeSL
            BasicDataTypeSL = new SelectList(
                _enumContext.BasicDataTypeSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                DataType.BasicDataType);

            // setup HasLengthSL
            HasLengthSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                DataType.HasLength);

            // setup HasTotalDigitsSL
            HasTotalDigitsSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                DataType.HasTotalDigits);

            // setup HasDecimalPlacesSL
            HasDecimalPlacesSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                DataType.HasDecimalPlaces);

            // setup HasIdentitySL
            HasIdentitySL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                DataType.HasIdentity);

            // setup HasDatePrecisionSL
            HasDatePrecisionSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                DataType.HasDatePrecision);
        }

        #endregion
    }
}
