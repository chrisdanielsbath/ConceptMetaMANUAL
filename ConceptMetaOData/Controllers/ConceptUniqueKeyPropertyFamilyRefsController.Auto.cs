/****************************
 * ConceptUniqueKeyPropertyFamilyRefsController.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ConceptMeta.ConceptMetaDb.OData.Controllers
{
    /// <summary>
    /// OData Controller class for the <see cref="ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public partial class ConceptUniqueKeyPropertyFamilyRefsController
        : ControllerBase
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private ConceptMetaDbContext dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the ConceptUniqueKeyPropertyFamilyRefController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptUniqueKeyPropertyFamilyRefsController(ConceptMetaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// gets the complete collection of ConceptUniqueKeyPropertyFamilyRefs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(dbContext.ConceptUniqueKeyPropertyFamilyRefs);
        }

        #endregion
    }
}
