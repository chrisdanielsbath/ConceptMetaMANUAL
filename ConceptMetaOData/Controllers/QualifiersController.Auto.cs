/****************************
 * QualifiersController.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ConceptMeta.ConceptMetaDb.OData.Controllers
{
    /// <summary>
    /// OData Controller class for the <see cref="Qualifier" /> entity
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public partial class QualifiersController
        : ControllerBase
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private ConceptMetaDbContext dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the QualifierController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public QualifiersController(ConceptMetaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// gets the complete collection of Qualifiers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(dbContext.Qualifiers);
        }

        #endregion
    }
}
