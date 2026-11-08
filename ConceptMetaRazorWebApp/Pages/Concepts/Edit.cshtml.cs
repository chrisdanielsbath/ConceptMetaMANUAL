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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Concepts
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.Concept" /> entity
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
        /// creates a new instance of the EditModel class for the Concept entity
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
        /// The ConceptModelId which partially defines the context for the Concept that is to be edited
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
        public async Task<IActionResult> OnGetAsync(int conceptId)
        {
            Concept = await _context.Concepts
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
                .AsNoTracking()
                .FirstOrDefaultAsync(concept => 
                        (concept.ConceptId == conceptId));

            if (Concept == null)
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
                _context.Concepts.Update(Concept);
                await _context.SaveChangesAsync();
                return RedirectToPage("Details", new { conceptId = Concept.ConceptId });
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
            ConceptModelSL = new SelectList(
                await conceptModelQuery.ToListAsync<RazorModels.ConceptModel>(),
                "PkString",
                "ValueString",
                Concept.ConceptModelKeyString);

            // setup DataTypeSL
            DataTypeSL = new SelectList(
                await dataTypeQuery.ToListAsync<RazorModels.DataType>(),
                "PkString",
                "ValueString",
                Concept.DataTypeKeyString);

            // setup EnumerationSL
            EnumerationSL = new SelectList(
                await enumerationQuery.ToListAsync<RazorModels.Enumeration>(),
                "PkString",
                "ValueString",
                Concept.EnumerationKeyString);

            // setup BasedOnConceptSL
            BasedOnConceptSL = new SelectList(
                await basedOnConceptQuery.ToListAsync<RazorModels.Concept>(),
                "PkString",
                "ValueString",
                Concept.BasedOnConceptKeyString);

            // setup ReferencedConceptSL
            ReferencedConceptSL = new SelectList(
                await referencedConceptQuery.ToListAsync<RazorModels.Concept>(),
                "PkString",
                "ValueString",
                Concept.ReferencedConceptKeyString);

            // setup ReferencedUniqueKeySL
            ReferencedUniqueKeySL = new SelectList(
                await referencedUniqueKeyQuery.ToListAsync<RazorModels.ConceptUniqueKey>(),
                "PkString",
                "ValueString",
                Concept.ReferencedUniqueKeyKeyString);

            // setup SpecialisedConceptSL
            SpecialisedConceptSL = new SelectList(
                await specialisedConceptQuery.ToListAsync<RazorModels.Concept>(),
                "PkString",
                "ValueString",
                Concept.SpecialisedConceptKeyString);

            // setup SpecialisedSubTypeSL
            SpecialisedSubTypeSL = new SelectList(
                await specialisedSubTypeQuery.ToListAsync<RazorModels.ConceptSubType>(),
                "PkString",
                "ValueString",
                Concept.SpecialisedSubTypeKeyString);

            // setup ConceptTypeSL
            ConceptTypeSL = new SelectList(
                _enumContext.ConceptTypeSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                Concept.ConceptType);

            // setup IsCollectionItemSL
            IsCollectionItemSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                Concept.IsCollectionItem);

            // setup IsCreatableSL
            IsCreatableSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                Concept.IsCreatable);

            // setup IsUpdatableSL
            IsUpdatableSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                Concept.IsUpdatable);

            // setup IsDeletableSL
            IsDeletableSL = new SelectList(
                _enumContext.BoolSet.GetNewDropdownOptions(),
                "PkString",
                "ValueString",
                Concept.IsDeletable);
        }

        #endregion
    }
}
