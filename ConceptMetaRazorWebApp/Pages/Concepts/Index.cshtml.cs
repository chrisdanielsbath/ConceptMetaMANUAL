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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Concepts
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.Concept" /> entity
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
        /// creates a new instance of the IndexModel class for the Concept entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.Concept> Concepts { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Concepts that are to be listed
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
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
            ConceptModel = await _context.ConceptModels
                    .Where(conceptModel => conceptModel.ConceptModelId == ConceptModelId)
                    .FirstOrDefaultAsync();

            Breadcrumb_ConceptModel_ConceptModelId = ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = ConceptModel?.ValueString;
        }
        public async Task OnGetAsync()
        {
            await BuildBreadcrumbAsync();

            IQueryable<RazorModels.Concept> conceptQuery = _context.Concepts.AsQueryable<RazorModels.Concept>();

            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptQuery = conceptQuery.Where(concept => concept.ConceptModelId == ConceptModelId);
            }

            Concepts = await conceptQuery
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
                .ToListAsync();
        }

        #endregion
    }
}
