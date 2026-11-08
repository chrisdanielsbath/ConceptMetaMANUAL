/****************************
 * EnumerationMembersController.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ConceptMeta.ConceptMetaDb.OData.Controllers
{
    /// <summary>
    /// OData Controller class for the <see cref="EnumerationMember" /> entity
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public partial class EnumerationMembersController
        : ControllerBase
    {

        #region Instance Variables

        // the database context from which entities will be retrieved
        private ConceptMetaDbContext dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the EnumerationMemberController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public EnumerationMembersController(ConceptMetaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// gets the complete collection of EnumerationMembers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(dbContext.EnumerationMembers);
        }

        #endregion
    }
}
