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

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.EnumerationMembers
{
    /// <summary>
    /// Index Model class for the <see cref="RazorModels.EnumerationMember" /> entity
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
        /// creates a new instance of the IndexModel class for the EnumerationMember entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public IndexModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public IList<RazorModels.EnumerationMember> EnumerationMembers { get; set; }
        private RazorModels.Enumeration Enumeration { get; set; }

        /// <summary>
        /// The EnumerationId which partially defines the context for the EnumerationMembers that are to be listed
        /// </summary>
        public int? EnumerationId
        {
            get
            {
                int? result;
                // inspect query string
                string paramValue = Request.Query["enumerationId"];
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
        public int? Breadcrumb_Enumeration_EnumerationId { get; private set; }
        public string Breadcrumb_Enumeration_ValueString { get; private set; }

        #endregion

        #region Instance Methods
        private async Task BuildBreadcrumbAsync()
        {
            Enumeration = await _context.Enumerations
                    .Where(enumeration => enumeration.EnumerationId == EnumerationId)
                    .Include(enumeration => enumeration.ConceptModel)
                    .Include(enumeration => enumeration.DataType)
                    .Include(enumeration => enumeration.DataType.ConceptModel)
                    .FirstOrDefaultAsync();

            Breadcrumb_ConceptModel_ConceptModelId = Enumeration?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Enumeration?.ConceptModel?.ValueString;

            Breadcrumb_Enumeration_EnumerationId = Enumeration?.EnumerationId;
            Breadcrumb_Enumeration_ValueString = Enumeration?.ValueString;
        }
        public async Task OnGetAsync()
        {
            await BuildBreadcrumbAsync();

            IQueryable<RazorModels.EnumerationMember> enumerationMemberQuery = _context.EnumerationMembers.AsQueryable<RazorModels.EnumerationMember>();

            if (!string.IsNullOrWhiteSpace(EnumerationId.ToString()))
            {
                enumerationMemberQuery = enumerationMemberQuery.Where(enumerationMember => enumerationMember.EnumerationId == EnumerationId);
            }

            EnumerationMembers = await enumerationMemberQuery
                .Include(enumerationMember => enumerationMember.Enumeration)
                .Include(enumerationMember => enumerationMember.Enumeration.ConceptModel)
                .Include(enumerationMember => enumerationMember.Enumeration.DataType)
                .Include(enumerationMember => enumerationMember.Enumeration.DataType.ConceptModel)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
