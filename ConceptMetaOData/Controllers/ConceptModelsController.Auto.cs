/****************************
 * ConceptModelsController.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ConceptMeta.ConceptMetaDb.OData.Controllers
{
    /// <summary>
    /// OData Controller class for the <see cref="ConceptModel" /> entity
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public partial class ConceptModelsController
        : ControllerBase
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private ConceptMetaDbContext dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the ConceptModelController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptModelsController(ConceptMetaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// gets the complete collection of ConceptModels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(dbContext.ConceptModels);
        }

        #endregion
    }
}
