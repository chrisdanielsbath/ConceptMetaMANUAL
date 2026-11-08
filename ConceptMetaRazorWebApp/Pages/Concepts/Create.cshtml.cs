/****************************
 * Create.cshtml.cs
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
    /// Create Model class for the <see cref="RazorModels.Concept" /> entity
    /// </summary>
    [Authorize]
    public partial class CreateModel
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
        /// creates a new instance of the CreateModel class for the Concept entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public CreateModel(ConceptMetaDbModelsContext context)
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
        public SelectList EnumerationSL { get; private set; }
        public SelectList BasedOnConceptSL { get; private set; }
        public SelectList ReferencedConceptSL { get; private set; }
        public SelectList ReferencedUniqueKeySL { get; private set; }
        public SelectList SpecialisedConceptSL { get; private set; }
        public SelectList SpecialisedSubTypeSL { get; private set; }
        public SelectList ConceptTypeSL { get; private set; }
        public SelectList IsCollectionItemSL { get; private set; }
        public SelectList IsCreatableSL { get; private set; }
        public SelectList IsUpdatableSL { get; private set; }
        public SelectList IsDeletableSL { get; private set; }

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
        private async Task BuildDropdownsAsync(bool isPostback)
        {
            // create basic queries
            IQueryable<RazorModels.ConceptModel> conceptModelQuery = _context.ConceptModels
                    .AsQueryable<RazorModels.ConceptModel>();

            IQueryable<RazorModels.DataType> dataTypeQuery = _context.DataTypes
                    .AsQueryable<RazorModels.DataType>();

            IQueryable<RazorModels.Enumeration> enumerationQuery = _context.Enumerations
                    .AsQueryable<RazorModels.Enumeration>();

            IQueryable<RazorModels.Concept> basedOnConceptQuery = _context.Concepts
                    .AsQueryable<RazorModels.Concept>();

            IQueryable<RazorModels.Concept> referencedConceptQuery = _context.Concepts
                    .AsQueryable<RazorModels.Concept>();

            IQueryable<RazorModels.ConceptUniqueKey> referencedUniqueKeyQuery = _context.ConceptUniqueKeys
                    .AsQueryable<RazorModels.ConceptUniqueKey>();

            IQueryable<RazorModels.Concept> specialisedConceptQuery = _context.Concepts
                    .AsQueryable<RazorModels.Concept>();

            IQueryable<RazorModels.ConceptSubType> specialisedSubTypeQuery = _context.ConceptSubTypes
                    .AsQueryable<RazorModels.ConceptSubType>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptModelQuery = conceptModelQuery.Where(conceptModel => conceptModel.ConceptModelId == ConceptModelId);
                dataTypeQuery = dataTypeQuery.Where(dataType => dataType.ConceptModelId == ConceptModelId);
                enumerationQuery = enumerationQuery.Where(enumeration => enumeration.ConceptModelId == ConceptModelId);
                basedOnConceptQuery = basedOnConceptQuery.Where(concept => concept.ConceptModelId == ConceptModelId);
                referencedConceptQuery = referencedConceptQuery.Where(concept => concept.ConceptModelId == ConceptModelId);
                referencedUniqueKeyQuery = referencedUniqueKeyQuery.Where(conceptUniqueKey => conceptUniqueKey.Concept.ConceptModelId == ConceptModelId);
                specialisedConceptQuery = specialisedConceptQuery.Where(concept => concept.ConceptModelId == ConceptModelId);
                specialisedSubTypeQuery = specialisedSubTypeQuery.Where(conceptSubType => conceptSubType.Concept.ConceptModelId == ConceptModelId);
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

            // setup EnumerationSL
            if (isPostback)
            {
                EnumerationSL = new SelectList(
                    await enumerationQuery.ToListAsync<RazorModels.Enumeration>(),
                    "PkString",
                    "ValueString",
                    Concept.EnumerationKeyString);
            }
            else
            {
                EnumerationSL = new SelectList(
                    await enumerationQuery.ToListAsync<RazorModels.Enumeration>(),
                    "PkString",
                    "ValueString");
            }

            // setup BasedOnConceptSL
            if (isPostback)
            {
                BasedOnConceptSL = new SelectList(
                    await basedOnConceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString",
                    Concept.BasedOnConceptKeyString);
            }
            else
            {
                BasedOnConceptSL = new SelectList(
                    await basedOnConceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString");
            }

            // setup ReferencedConceptSL
            if (isPostback)
            {
                ReferencedConceptSL = new SelectList(
                    await referencedConceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString",
                    Concept.ReferencedConceptKeyString);
            }
            else
            {
                ReferencedConceptSL = new SelectList(
                    await referencedConceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString");
            }

            // setup ReferencedUniqueKeySL
            if (isPostback)
            {
                ReferencedUniqueKeySL = new SelectList(
                    await referencedUniqueKeyQuery.ToListAsync<RazorModels.ConceptUniqueKey>(),
                    "PkString",
                    "ValueString",
                    Concept.ReferencedUniqueKeyKeyString);
            }
            else
            {
                ReferencedUniqueKeySL = new SelectList(
                    await referencedUniqueKeyQuery.ToListAsync<RazorModels.ConceptUniqueKey>(),
                    "PkString",
                    "ValueString");
            }

            // setup SpecialisedConceptSL
            if (isPostback)
            {
                SpecialisedConceptSL = new SelectList(
                    await specialisedConceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString",
                    Concept.SpecialisedConceptKeyString);
            }
            else
            {
                SpecialisedConceptSL = new SelectList(
                    await specialisedConceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString");
            }

            // setup SpecialisedSubTypeSL
            if (isPostback)
            {
                SpecialisedSubTypeSL = new SelectList(
                    await specialisedSubTypeQuery.ToListAsync<RazorModels.ConceptSubType>(),
                    "PkString",
                    "ValueString",
                    Concept.SpecialisedSubTypeKeyString);
            }
            else
            {
                SpecialisedSubTypeSL = new SelectList(
                    await specialisedSubTypeQuery.ToListAsync<RazorModels.ConceptSubType>(),
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

            // setup IsCollectionItemSL
            if (isPostback)
            {
                IsCollectionItemSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    Concept.IsCollectionItem);
            }
            else
            {
                IsCollectionItemSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }

            // setup IsCreatableSL
            if (isPostback)
            {
                IsCreatableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    Concept.IsCreatable);
            }
            else
            {
                IsCreatableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
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

            // setup IsDeletableSL
            if (isPostback)
            {
                IsDeletableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    Concept.IsDeletable);
            }
            else
            {
                IsDeletableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }
        }

        #endregion
    }
}
