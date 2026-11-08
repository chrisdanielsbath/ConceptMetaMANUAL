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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Enumerations
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.Enumeration" /> entity
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
        /// creates a new instance of the IndexModel class for the Enumeration entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.Enumeration> Enumerations { get; set; }
        private RazorModels.ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the Enumerations that are to be listed
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

            IQueryable<RazorModels.Enumeration> enumerationQuery = _context.Enumerations.AsQueryable<RazorModels.Enumeration>();

            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                enumerationQuery = enumerationQuery.Where(enumeration => enumeration.ConceptModelId == ConceptModelId);
            }

            Enumerations = await enumerationQuery
                .Include(enumeration => enumeration.ConceptModel)
                .Include(enumeration => enumeration.DataType)
                .Include(enumeration => enumeration.DataType.ConceptModel)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
