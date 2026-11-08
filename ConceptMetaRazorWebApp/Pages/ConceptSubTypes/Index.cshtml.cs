/****************************
 * Index.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptSubTypes
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.ConceptSubType" /> entity
    /// </summary>
    [Authorize]
    public partial class IndexModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the IndexModel class for the ConceptSubType entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.ConceptSubType> ConceptSubTypes { get; set; }
        private RazorModels.Concept Concept { get; set; }

        /// <summary>
        /// The ConceptId which partially defines the context for the ConceptSubTypes that are to be listed
        /// </summary>
        public int? ConceptId
        {
            get
            {
                int? result;
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

            Breadcrumb_ConceptModel_ConceptModelId = Concept?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Concept?.ConceptModel?.ValueString;

            Breadcrumb_Concept_ConceptId = Concept?.ConceptId;
            Breadcrumb_Concept_ValueString = Concept?.ValueString;
        }
        public async Task OnGetAsync()
        {
            await BuildBreadcrumbAsync();

            IQueryable<RazorModels.ConceptSubType> conceptSubTypeQuery = _context.ConceptSubTypes.AsQueryable<RazorModels.ConceptSubType>();

            if (!string.IsNullOrWhiteSpace(ConceptId.ToString()))
            {
                conceptSubTypeQuery = conceptSubTypeQuery.Where(conceptSubType => conceptSubType.ConceptId == ConceptId);
            }

            ConceptSubTypes = await conceptSubTypeQuery
                .Include(conceptSubType => conceptSubType.Concept)
                .Include(conceptSubType => conceptSubType.Concept.ConceptModel)
                .Include(conceptSubType => conceptSubType.Concept.DataType)
                .Include(conceptSubType => conceptSubType.Concept.DataType.ConceptModel)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
