/****************************
 * ConceptSubTypePropertyFamilyRefSearchController.Auto.cs
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
    /// API Controller class for the <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> entity, to support Autocomplete controls
    /// </summary>
    [Produces("application/json")]
    [Route("api/ConceptSubTypePropertyFamilyRefSearch")]
    [Authorize]
    public partial class ConceptSubTypePropertyFamilyRefSearchController
        : Controller
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the ConceptSubTypePropertyFamilyRefSearchController class
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        public ConceptSubTypePropertyFamilyRefSearchController(ConceptMetaDbModelsContext context)
        {
            _context = context;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The ConceptModelId which partially defines the context for the ConceptSubTypePropertyFamilyRefs that are to be listed
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
        /// The ConceptId which partially defines the context for the ConceptSubTypePropertyFamilyRefs that are to be listed
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

        /// <summary>
        /// The ConceptSubTypeId which partially defines the context for the ConceptSubTypePropertyFamilyRefs that are to be listed
        /// </summary>
        public int? ConceptSubTypeId
        {
            get
            {
                int? result;
                // inspect query string
                string paramValue = Request.Query["conceptSubTypeId"];
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
            IQueryable<RazorModels.ConceptSubTypePropertyFamilyRef> conceptSubTypePropertyFamilyRefQuery = _context.ConceptSubTypePropertyFamilyRefs
                    .AsQueryable<RazorModels.ConceptSubTypePropertyFamilyRef>();

            // adjust query to reflect ConceptModelId
            if (!string.IsNullOrWhiteSpace(ConceptModelId.ToString()))
            {
                conceptSubTypePropertyFamilyRefQuery = conceptSubTypePropertyFamilyRefQuery.Where(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModelId == ConceptModelId);
            }

            // adjust query to reflect ConceptId
            if (!string.IsNullOrWhiteSpace(ConceptId.ToString()))
            {
                conceptSubTypePropertyFamilyRefQuery = conceptSubTypePropertyFamilyRefQuery.Where(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubType.ConceptId == ConceptId);
            }

            // adjust query to reflect ConceptSubTypeId
            if (!string.IsNullOrWhiteSpace(ConceptSubTypeId.ToString()))
            {
                conceptSubTypePropertyFamilyRefQuery = conceptSubTypePropertyFamilyRefQuery.Where(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypeId == ConceptSubTypeId);
            }

            return await conceptSubTypePropertyFamilyRefQuery
                .Where(x => (x.PropertyFamilyName).ToLower().StartsWith(lCaseText))
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
