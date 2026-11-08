/****************************
 * EnumerationMemberSearchController.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ApiControllers
{
    /// <summary>
    /// API Controller class for the <see cref="RazorModels.EnumerationMember" /> entity, to support Autocomplete controls
    /// </summary>
    [Produces("application/json")]
    [Route("api/EnumerationMemberSearch")]
    [Authorize]
    public partial class EnumerationMemberSearchController
        : Controller
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the EnumerationMemberSearchController class
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public EnumerationMemberSearchController(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The ConceptModelId which partially defines the context for the EnumerationMembers that are to be listed
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

        /// <summary>
        /// The DataTypeId which partially defines the context for the EnumerationMembers that are to be listed
        /// </summary>
        public int? DataTypeId
        {
            get
            {
                int? result;
                // inspect query string
                string paramValue = Request.Query["dataTypeId"];
                result = (string.IsNullOrWhiteSpace(paramValue) ? null : int.Parse(paramValue));
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

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

        #endregion

        #region Instance Methods

        [Route("{text}")]
        public async Task<JsonResult> GetFilteredResults(string text)
        {
            List<RazorModels.DropdownOption> result;

            text = text.ToLower().Trim();

            do
            {
                result = await GetSuggestions(text);
                text = text.Substring(0, text.Length - 1);
            }
            while (result.Count == 0 && text.Length > 0);

            return Json(result);
        }
        public async Task<List<RazorModels.DropdownOption>> GetSuggestions(string lCaseText)
        {
            // create basic query
            IQueryable<RazorModels.EnumerationMember> enumerationMemberQuery = _context.EnumerationMembers
                    .AsQueryable<RazorModels.EnumerationMember>();

            // adjust query to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                enumerationMemberQuery = enumerationMemberQuery.Where(enumerationMember => enumerationMember.Enumeration.ConceptModelId == ConceptModelId);
            }

            // adjust query to reflect DataTypeId
            if (!string.IsNullOrWhiteSpace(DataTypeId.ToString()))
            {
                enumerationMemberQuery = enumerationMemberQuery.Where(enumerationMember => enumerationMember.Enumeration.DataTypeId == DataTypeId);
            }

            // adjust query to reflect EnumerationId
            if (!string.IsNullOrWhiteSpace(EnumerationId.ToString()))
            {
                enumerationMemberQuery = enumerationMemberQuery.Where(enumerationMember => enumerationMember.EnumerationId == EnumerationId);
            }

            return await enumerationMemberQuery
                .Where(x => (x.EnumeratedValue).ToLower().StartsWith(lCaseText))
                .Select(x => new RazorModels.DropdownOption
                {
                    PkString = x.PkString,
                    ValueString = x.ValueString
                })
                .Take(10)
                .ToListAsync();
        }

        #endregion
    }
}
