/****************************
 * ViewJson.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using DomainModels = ConceptMeta.Domain;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.ConceptModels
{
    /// <summary>
    /// ViewJson Model class for the <see cref="ConceptModel" /> domain object
    /// </summary>
    [Authorize]
    public partial class ViewJsonModel
        : PageModel
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private readonly ConceptMetaDbModelsContext _context;

        // the unit of work from which domain objects will be retrieved
        private readonly IConceptMetaDbDomainUnitOfWork _domainUnitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the ViewJsonModel class for the ConceptModel entity
        /// </summary>
        /// <param name="context">the database context from which entities will be retrieved</param>
        /// <param name="domainUnitOfWork">the unit of work from which domain objects will be retrieved</param>
        public ViewJsonModel(
            ConceptMetaDbModelsContext context,
            IConceptMetaDbDomainUnitOfWork domainUnitOfWork)
        {
            _context = context;
            _domainUnitOfWork = domainUnitOfWork;
        }

        #endregion

        #region Instance Properties

        [BindProperty]
        public DomainModels.ConceptModel ConceptModel { get; set; }
        public int? ConceptModelId { get; private set; }

        [BindProperty]
        public string ConceptModelJson
        {
            get
            {
                string json = JsonConvert.SerializeObject(ConceptModel);
                using (var stringReader = new StringReader(json))
                {
                    using (var stringWriter = new StringWriter())
                    {
                        var jsonReader = new JsonTextReader(stringReader);
                        var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                        jsonWriter.WriteToken(jsonReader);
                        return stringWriter.ToString();
                    }
                }
            }
        }

        #endregion

        #region Instance Methods
        public async Task<IActionResult> OnGetAsync(int conceptModelId)
        {
            ConceptModelId = conceptModelId;

            string modelName = (await _context.ConceptModels
                .AsNoTracking()
                .FirstOrDefaultAsync(conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId)))
                .ModelName;

            ConceptModel = await _domainUnitOfWork.ConceptModels
                .GetByModelNameAsync(modelName);

            if (ConceptModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        #endregion
    }
}
