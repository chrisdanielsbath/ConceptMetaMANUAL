/****************************
 * IncludesController.Auto.cs
 ****************************/
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.ConceptMetaDb.EntityDtos;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;
using ConceptMeta.Services;

namespace ConceptMeta.ConceptMetaDb.WebApi.Controllers
{
    /// <summary>
    /// WebApi Controller class for the <see cref="Include" /> entity
    /// </summary>
    [Route("api/Includes")]
    [ApiController]
    public partial class IncludesController
        : ControllerBase
    {

        #region Instance Variables

        // the mapper to be used when converting to Dtos
        private IMapper toDtoMapper;

        // the mapper to be used when converting from Dtos
        private IMapper fromDtoMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// creates a new instance of the IncludesController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public IncludesController(ConceptMetaDbContext dbContext)
        {
            UnitOfWork = new ConceptMetaDbUnitOfWork(dbContext);
        }

        #endregion

        #region Static properties

        /// <summary>
        /// The LoggerFactory to be used within mappers
        /// </summary>
        public static ILoggerFactory LoggerFactory { get; set; } = new LoggerFactory();

        #endregion

        #region Instance properties

        /// <summary>
        /// the unit of work
        /// </summary>
        private IConceptMetaDbUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// the repository through which to access data
        /// </summary>
        private IIncludeRepository Repo
        {
            get
            {
                return UnitOfWork.Includes;
            }
        }

        /// <summary>
        /// the mapper to be used when converting to Dtos
        /// </summary>
        private IMapper ToDtoMapper
        {
            get
            {
                if (toDtoMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<DbEntities.Include, IncludeDto>();
                        },
                        LoggerFactory);
                    toDtoMapper = config.CreateMapper();    
                }
                return (toDtoMapper);
            }
        }

        /// <summary>
        /// the mapper to be used when converting from Dtos
        /// </summary>
        private IMapper FromDtoMapper
        {
            get
            {
                if (fromDtoMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<IncludeDto, DbEntities.Include>();
                        },
                        LoggerFactory);
                    fromDtoMapper = config.CreateMapper();
                }
                return (fromDtoMapper);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        private IncludeDto MapToDto(DbEntities.Include include)
        {
            return ToDtoMapper.Map<IncludeDto>(include);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        private IEnumerable<IncludeDto> MapToDto(IEnumerable<DbEntities.Include> includes)
        {
            return ToDtoMapper.Map<IEnumerable<IncludeDto>>(includes);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="includeDto"></param>
        /// <returns></returns>
        private DbEntities.Include MapFromDto(IncludeDto includeDto)
        {
            return FromDtoMapper.Map<DbEntities.Include>(includeDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="includeDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.Include> MapFromDto(IEnumerable<IncludeDto> includeDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.Include>>(includeDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        private ResponseWrapper<IncludeDto> BuildResponse(DbEntities.Include include)
        {
            return new ResponseWrapper<IncludeDto>(MapToDto(include));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="includes"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<IncludeDto>> BuildResponse(
            IEnumerable<DbEntities.Include> includes,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<IncludeDto>>(
                    MapToDto(includes),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        [HttpGet("{includeId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Include>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIncludeIdAsync(int includeId)
        {
            DbEntities.Include include = await (Repo.GetRichEntityByIncludeIdAsync(includeId));
            if (include == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(include)); // 200
            }
        }

        /// <summary>
        /// Gets all Include items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.Include>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.Include> includes = await (Repo.FindAsync(
                    include => true,
                    include => include.IncludeId,
                    filter.PageNumber,
                    filter.PageSize));
            if (includes == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(includes, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new Include
        /// </summary>
        /// <param name="includeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Include>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIncludeAsync(IncludeDto includeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Include include = MapFromDto(includeDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(include);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + include.IncludeId.ToString()),
                    BuildResponse(include)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <param name="includeDto"></param>
        /// <returns></returns>
        [HttpPut("{includeId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Include>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIncludeAsync(
            int includeId,
            IncludeDto includeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Include include = await (Repo.GetByIncludeIdAsync(includeId));
                if (include == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    include = MapFromDto(includeDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(include);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(include)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        [HttpDelete("{includeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIncludeAsync(int includeId)
        {
            DbEntities.Include include = await (Repo.GetByIncludeIdAsync(includeId));
            if (include == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(include);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return NoContent(); // 204
            }
        }

        #endregion
    }
}
