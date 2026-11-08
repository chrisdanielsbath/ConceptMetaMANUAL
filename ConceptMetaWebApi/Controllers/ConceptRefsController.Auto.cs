/****************************
 * ConceptRefsController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptRef" /> entity
    /// </summary>
    [Route("api/ConceptRefs")]
    [ApiController]
    public partial class ConceptRefsController
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
        /// creates a new instance of the ConceptRefsController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptRefsController(ConceptMetaDbContext dbContext)
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
        private IConceptRefRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptRefs;
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
                            cfg.CreateMap<DbEntities.ConceptRef, ConceptRefDto>();
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
                            cfg.CreateMap<ConceptRefDto, DbEntities.ConceptRef>();
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
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        private ConceptRefDto MapToDto(DbEntities.ConceptRef conceptRef)
        {
            return ToDtoMapper.Map<ConceptRefDto>(conceptRef);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptRefs"></param>
        /// <returns></returns>
        private IEnumerable<ConceptRefDto> MapToDto(IEnumerable<DbEntities.ConceptRef> conceptRefs)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptRefDto>>(conceptRefs);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptRefDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptRef MapFromDto(ConceptRefDto conceptRefDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptRef>(conceptRefDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptRefDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptRef> MapFromDto(IEnumerable<ConceptRefDto> conceptRefDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptRef>>(conceptRefDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptRefDto> BuildResponse(DbEntities.ConceptRef conceptRef)
        {
            return new ResponseWrapper<ConceptRefDto>(MapToDto(conceptRef));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptRefs"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptRefDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptRef> conceptRefs,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptRefDto>>(
                    MapToDto(conceptRefs),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        [HttpGet("{conceptRefId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptRef>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptRefIdAsync(int conceptRefId)
        {
            DbEntities.ConceptRef conceptRef = await (Repo.GetRichEntityByConceptRefIdAsync(conceptRefId));
            if (conceptRef == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptRef)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptRef items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptRef>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptRef> conceptRefs = await (Repo.FindAsync(
                    conceptRef => true,
                    conceptRef => conceptRef.ConceptRefId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptRefs == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptRefs, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptRef
        /// </summary>
        /// <param name="conceptRefDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptRef>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptRefAsync(ConceptRefDto conceptRefDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptRef conceptRef = MapFromDto(conceptRefDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptRef);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptRef.ConceptRefId.ToString()),
                    BuildResponse(conceptRef)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <param name="conceptRefDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptRefId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptRef>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptRefAsync(
            int conceptRefId,
            ConceptRefDto conceptRefDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptRef conceptRef = await (Repo.GetByConceptRefIdAsync(conceptRefId));
                if (conceptRef == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptRef = MapFromDto(conceptRefDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptRef);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptRef)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptRefId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptRefAsync(int conceptRefId)
        {
            DbEntities.ConceptRef conceptRef = await (Repo.GetByConceptRefIdAsync(conceptRefId));
            if (conceptRef == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptRef);
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
