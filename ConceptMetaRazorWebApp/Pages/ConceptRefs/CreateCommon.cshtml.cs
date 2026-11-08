/****************************
 * CreateCommon.cshtml.cs
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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptRefs
{
    /// <summary>
    /// CreateCommon Model class for the <see cref="RazorModels.ConceptRef" /> entity
    /// </summary>
    [Authorize]
    public partial class CreateCommonModel
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
        /// creates a new instance of the CreateCommonModel class for the ConceptRef entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public CreateCommonModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
            _enumContext = new EnumContext();
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.ConceptRef ConceptRef { get; set; }
        private RazorModels.Concept Concept { get; set; }
        public SelectList ConceptSL { get; private set; }
        public SelectList PropertyFamilySL { get; private set; }
        public SelectList ConceptRefTypeSL { get; private set; }
        public SelectList IsPropagatingSL { get; private set; }
        public SelectList IsUpdatableSL { get; private set; }
        public SelectList IsNullableSL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the ConceptRef that is to be created
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
        /// The ConceptId which partially defines the context for the ConceptRef that is to be created
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = ConceptRef?.ConceptId;
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

        /// <summary>
        /// A string that identifies the Concept within which the ConceptRef is to be created
        /// </summary>
        public string ConceptKeyString
        {
            get
            {
                return Concept?.PkString;
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
            if (ConceptRef?.Concept != null)
            {
                Concept = ConceptRef?.Concept;
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
        public async Task<IActionResult> OnGetAsync()
        {
            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync(false);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await PopulatePropertiesForSearchablesAsync();

            if (ModelState.IsValid)
            {
                _context.ConceptRefs.Add(ConceptRef);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index", new { conceptId = ConceptId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync(true);

            return Page();
        }
        private async Task BuildDropdownsAsync(bool isPostback)
        {
            // create basic queries
            IQueryable<RazorModels.Concept> conceptQuery = _context.Concepts
                    .AsQueryable<RazorModels.Concept>();

            IQueryable<RazorModels.ConceptPropertyFamily> propertyFamilyQuery = _context.ConceptPropertyFamilies
                    .AsQueryable<RazorModels.ConceptPropertyFamily>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptQuery = conceptQuery.Where(concept => concept.ConceptModelId == ConceptModelId);
                propertyFamilyQuery = propertyFamilyQuery.Where(conceptPropertyFamily => conceptPropertyFamily.Concept.ConceptModelId == ConceptModelId);
            }
            // adjust queries to reflect ConceptId
            if (!string.IsNullOrWhiteSpace(ConceptId.ToString()))
            {
                conceptQuery = conceptQuery.Where(concept => concept.ConceptId == ConceptId);
                propertyFamilyQuery = propertyFamilyQuery.Where(conceptPropertyFamily => conceptPropertyFamily.ConceptId == ConceptId);
            }

            // setup ConceptSL
            if (isPostback)
            {
                ConceptSL = new SelectList(
                    await conceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString",
                    ConceptRef.ConceptKeyString);
            }
            else
            {
                ConceptSL = new SelectList(
                    await conceptQuery.ToListAsync<RazorModels.Concept>(),
                    "PkString",
                    "ValueString",
                    ConceptKeyString); // ensure any Concept specified in the querystring is preselected
            }

            // setup PropertyFamilySL
            if (isPostback)
            {
                PropertyFamilySL = new SelectList(
                    await propertyFamilyQuery.ToListAsync<RazorModels.ConceptPropertyFamily>(),
                    "PkString",
                    "ValueString",
                    ConceptRef.PropertyFamilyKeyString);
            }
            else
            {
                PropertyFamilySL = new SelectList(
                    await propertyFamilyQuery.ToListAsync<RazorModels.ConceptPropertyFamily>(),
                    "PkString",
                    "ValueString");
            }

            // setup ConceptRefTypeSL
            if (isPostback)
            {
                ConceptRefTypeSL = new SelectList(
                    _enumContext.ConceptRefTypeSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    ConceptRef.ConceptRefType);
            }
            else
            {
                ConceptRefTypeSL = new SelectList(
                    _enumContext.ConceptRefTypeSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }

            // setup IsPropagatingSL
            if (isPostback)
            {
                IsPropagatingSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    ConceptRef.IsPropagating);
            }
            else
            {
                IsPropagatingSL = new SelectList(
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
                    ConceptRef.IsUpdatable);
            }
            else
            {
                IsUpdatableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }

            // setup IsNullableSL
            if (isPostback)
            {
                IsNullableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString",
                    ConceptRef.IsNullable);
            }
            else
            {
                IsNullableSL = new SelectList(
                    _enumContext.BoolSet.GetNewDropdownOptions(),
                    "PkString",
                    "ValueString");
            }
        }
        private async Task PopulatePropertiesForSearchablesAsync()
        {
            ConceptRef.ReferencedConcept = await _context.Concepts.FindAsync(ConceptRef.ReferencedConceptId);
        }

        #endregion
    }
}
