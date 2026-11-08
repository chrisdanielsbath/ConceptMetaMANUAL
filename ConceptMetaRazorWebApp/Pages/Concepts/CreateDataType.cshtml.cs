/****************************
 * CreateDataType.cshtml.cs
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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Concepts
{
    /// <summary>
    /// CreateDataType Model class for the <see cref="RazorModels.Concept" /> entity
    /// </summary>
    [Authorize]
    public partial class CreateDataTypeModel
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
        /// creates a new instance of the CreateDataTypeModel class for the Concept entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public CreateDataTypeModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
            _enumContext = new EnumContext();
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.Concept Concept { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }
        public SelectList ConceptModelSL { get; private set; }
        public SelectList DataTypeSL { get; private set; }
        public SelectList ConceptTypeSL { get; private set; }
        public SelectList IsUpdatableSL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Concept that is to be created
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

        /// <summary>
        /// A string that identifies the ConceptModel within which the Concept is to be created
        /// </summary>
        public string ConceptModelKeyString
        {
            get
            {
                return ConceptModel?.PkString;
            }
        }
        public int? Breadcrumb_ConceptModel_ConceptModelId { get; private set; }
        public string Breadcrumb_ConceptModel_ValueString { get; private set; }

        #endregion

        #region Instance Methods
        private async Task BuildBreadcrumbAsync()
        {
            if (Concept?.ConceptModel != null)
            {
                ConceptModel = Concept?.ConceptModel;
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
        public async Task<IActionResult> OnGetAsync()
        {
            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync(false);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Concepts.Add(Concept);
                await _context.SaveChangesAsync();
                return RedirectToPage("Details", new { conceptId = Concept.ConceptId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync(true);

            return Page();
        }
        private async Task BuildDropdownsAsync(bool isPostback)
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
            if (isPostback)
            {
                ConceptModelSL = new SelectList(
                    await conceptModelQuery.ToListAsync<RazorModels.ConceptModel>(),
                    "PkString",
                    "ValueString",
                    Concept.ConceptModelKeyString);
            }
            else
            {
                ConceptModelSL = new SelectList(
                    await conceptModelQuery.ToListAsync<RazorModels.ConceptModel>(),
                    "PkString",
                    "ValueString",
                    ConceptModelKeyString); // ensure any ConceptModel specified in the querystring is preselected
            }

            // setup DataTypeSL
            if (isPostback)
            {
                DataTypeSL = new SelectList(
                    await dataTypeQuery.ToListAsync<RazorModels.DataType>(),
                    "PkString",
                    "ValueString",
                    Concept.DataTypeKeyString);
            }
            else
            {
                DataTypeSL = new SelectList(
                    await dataTypeQuery.ToListAsync<RazorModels.DataType>(),
                    "PkString",
                    "ValueString");
            }

            // setup ConceptTypeSL
            if (isPostback)
            {
                ConceptTypeSL = new SelectList(
                    _enumContext.ConceptTypeSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    Concept.ConceptType);
            }
            else
            {
                ConceptTypeSL = new SelectList(
                    _enumContext.ConceptTypeSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }

            // setup IsUpdatableSL
            if (isPostback)
            {
                IsUpdatableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    Concept.IsUpdatable);
            }
            else
            {
                IsUpdatableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }
        }

        #endregion
    }
}
