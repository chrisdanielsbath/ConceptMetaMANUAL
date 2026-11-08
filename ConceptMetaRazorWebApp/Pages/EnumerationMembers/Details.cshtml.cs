/****************************
 * Details.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.EnumerationMembers
{
    /// <summary>
    /// Details Model class for the <see cref="RazorModels.EnumerationMember" /> entity
    /// </summary>
    [Authorize]
    public partial class DetailsModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the DetailsModel class for the EnumerationMember entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public DetailsModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties
        public RazorModels.EnumerationMember EnumerationMember { get; set; }
        private RazorModels.Enumeration Enumeration { get; set; }

        /// <summary>
        /// The EnumerationId which partially defines the context for the EnumerationMember that is to be viewed
        /// </summary>
        public int? EnumerationId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Enumeration?.EnumerationId;
                if (result != null)
                {
                    return result;
                }
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
        private void BuildBreadcrumb()
        {
            Enumeration = EnumerationMember?.Enumeration;

            Breadcrumb_ConceptModel_ConceptModelId = Enumeration?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Enumeration?.ConceptModel?.ValueString;

            Breadcrumb_Enumeration_EnumerationId = Enumeration?.EnumerationId;
            Breadcrumb_Enumeration_ValueString = Enumeration?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int? enumerationMemberId)
        {
            if (enumerationMemberId == null)
            {
               return NotFound();
            }

            EnumerationMember = await _context.EnumerationMembers
                .Include(enumerationMember => enumerationMember.Enumeration)
                .Include(enumerationMember => enumerationMember.Enumeration.ConceptModel)
                .Include(enumerationMember => enumerationMember.Enumeration.DataType)
                .Include(enumerationMember => enumerationMember.Enumeration.DataType.ConceptModel)
                .AsNoTracking()
                .FirstOrDefaultAsync(enumerationMember => 
                        (enumerationMember.EnumerationMemberId == enumerationMemberId));

            if (EnumerationMember == null)
            {
                return NotFound();
            }

            BuildBreadcrumb();
            return Page();
        }

        #endregion
    }
}
