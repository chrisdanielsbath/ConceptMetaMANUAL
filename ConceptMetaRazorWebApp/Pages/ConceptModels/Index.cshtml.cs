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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptModels
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.ConceptModel" /> entity
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
        /// creates a new instance of the IndexModel class for the ConceptModel entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.ConceptModel> ConceptModels { get; set; }

        #endregion

        #region Instance Methods
        public async Task OnGetAsync()
        {
            IQueryable<RazorModels.ConceptModel> conceptModelQuery = _context.ConceptModels.AsQueryable<RazorModels.ConceptModel>();

            ConceptModels = await conceptModelQuery
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
