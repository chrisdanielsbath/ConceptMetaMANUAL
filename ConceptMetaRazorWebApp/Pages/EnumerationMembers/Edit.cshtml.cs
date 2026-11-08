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
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.EnumerationMembers
{
    /// <summary>
    /// Edit Model class for the <see cref="RazorModels.EnumerationMember" /> entity
    /// </summary>
    [Authorize]
    public partial class EditModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the EditModel class for the EnumerationMember entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EditModel(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public RazorModels.EnumerationMember EnumerationMember { get; set; }
        private RazorModels.Enumeration Enumeration { get; set; }
        public SelectList EnumerationSL { get; private set; }

        /// <summary>
        /// The ConceptModelId which partially defines the context for the EnumerationMember that is to be edited
        /// </summary>
        public int? ConceptModelId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Enumeration?.ConceptModelId;
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        /// The DataTypeId which partially defines the context for the EnumerationMember that is to be edited
        /// </summary>
        public int? DataTypeId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = Enumeration?.DataTypeId;
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        /// The EnumerationId which partially defines the context for the EnumerationMember that is to be edited
        /// </summary>
        public int? EnumerationId
        {
            get
            {
                int? result;
                // inspect known properties first
                result = EnumerationMember?.EnumerationId;
                if (result != null)
                {
                    return result;
                }
                result = result = Enumeration?.EnumerationId;
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
        private async Task BuildBreadcrumbAsync()
        {
            if (EnumerationMember?.Enumeration != null)
            {
                Enumeration = EnumerationMember?.Enumeration;
            }
            else
            {
                Enumeration = await _context.Enumerations
                        .Where(enumeration => enumeration.EnumerationId == EnumerationId)
                        .Include(enumeration => enumeration.ConceptModel)
                        .Include(enumeration => enumeration.DataType)
                        .Include(enumeration => enumeration.DataType.ConceptModel)
                        .FirstOrDefaultAsync();
            }

            Breadcrumb_ConceptModel_ConceptModelId = Enumeration?.ConceptModel?.ConceptModelId;
            Breadcrumb_ConceptModel_ValueString = Enumeration?.ConceptModel?.ValueString;

            Breadcrumb_Enumeration_EnumerationId = Enumeration?.EnumerationId;
            Breadcrumb_Enumeration_ValueString = Enumeration?.ValueString;
        }
        public async Task<IActionResult> OnGetAsync(int enumerationMemberId)
        {
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

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.EnumerationMembers.Update(EnumerationMember);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index", new { enumerationId = EnumerationId });
            }

            await BuildBreadcrumbAsync();
            await BuildDropdownsAsync();

            return Page();
        }
        private async Task BuildDropdownsAsync()
        {
            // create basic queries
            IQueryable<RazorModels.Enumeration> enumerationQuery = _context.Enumerations
                    .AsQueryable<RazorModels.Enumeration>();

            // adjust queries to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                enumerationQuery = enumerationQuery.Where(enumeration => enumeration.ConceptModelId == ConceptModelId);
            }
            // adjust queries to reflect DataTypeId
            if (!string.IsNullOrWhiteSpace(DataTypeId.ToString()))
            {
                enumerationQuery = enumerationQuery.Where(enumeration => enumeration.DataTypeId == DataTypeId);
            }
            // adjust queries to reflect EnumerationId
            if (!string.IsNullOrWhiteSpace(EnumerationId.ToString()))
            {
                enumerationQuery = enumerationQuery.Where(enumeration => enumeration.EnumerationId == EnumerationId);
            }

            // setup EnumerationSL
            EnumerationSL = new SelectList(
                await enumerationQuery.ToListAsync<RazorModels.Enumeration>(),
                "PkString",
                "ValueString",
                EnumerationMember.EnumerationKeyString);
        }

        #endregion
    }
}
