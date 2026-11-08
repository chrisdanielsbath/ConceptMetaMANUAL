/****************************
 * ConceptUniqueKeyPropertyFamilyRefsController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    [Route("api/ConceptUniqueKeyPropertyFamilyRefs")]
    [ApiController]
    public partial class ConceptUniqueKeyPropertyFamilyRefsController
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
        /// creates a new instance of the ConceptUniqueKeyPropertyFamilyRefsController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptUniqueKeyPropertyFamilyRefsController(ConceptMetaDbContext dbContext)
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
        private IConceptUniqueKeyPropertyFamilyRefRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptUniqueKeyPropertyFamilyRefs;
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
                            cfg.CreateMap<DbEntities.ConceptUniqueKeyPropertyFamilyRef, ConceptUniqueKeyPropertyFamilyRefDto>();
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
                            cfg.CreateMap<ConceptUniqueKeyPropertyFamilyRefDto, DbEntities.ConceptUniqueKeyPropertyFamilyRef>();
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
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        private ConceptUniqueKeyPropertyFamilyRefDto MapToDto(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return ToDtoMapper.Map<ConceptUniqueKeyPropertyFamilyRefDto>(conceptUniqueKeyPropertyFamilyRef);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefs"></param>
        /// <returns></returns>
        private IEnumerable<ConceptUniqueKeyPropertyFamilyRefDto> MapToDto(IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> conceptUniqueKeyPropertyFamilyRefs)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptUniqueKeyPropertyFamilyRefDto>>(conceptUniqueKeyPropertyFamilyRefs);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptUniqueKeyPropertyFamilyRef MapFromDto(ConceptUniqueKeyPropertyFamilyRefDto conceptUniqueKeyPropertyFamilyRefDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptUniqueKeyPropertyFamilyRef>(conceptUniqueKeyPropertyFamilyRefDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> MapFromDto(IEnumerable<ConceptUniqueKeyPropertyFamilyRefDto> conceptUniqueKeyPropertyFamilyRefDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef>>(conceptUniqueKeyPropertyFamilyRefDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptUniqueKeyPropertyFamilyRefDto> BuildResponse(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return new ResponseWrapper<ConceptUniqueKeyPropertyFamilyRefDto>(MapToDto(conceptUniqueKeyPropertyFamilyRef));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefs"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptUniqueKeyPropertyFamilyRefDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> conceptUniqueKeyPropertyFamilyRefs,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptUniqueKeyPropertyFamilyRefDto>>(
                    MapToDto(conceptUniqueKeyPropertyFamilyRefs),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        [HttpGet("{conceptUniqueKeyPropertyFamilyRefId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptUniqueKeyPropertyFamilyRef>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptUniqueKeyPropertyFamilyRefIdAsync(int conceptUniqueKeyPropertyFamilyRefId)
        {
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef = await (Repo.GetRichEntityByConceptUniqueKeyPropertyFamilyRefIdAsync(conceptUniqueKeyPropertyFamilyRefId));
            if (conceptUniqueKeyPropertyFamilyRef == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptUniqueKeyPropertyFamilyRef)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptUniqueKeyPropertyFamilyRef items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> conceptUniqueKeyPropertyFamilyRefs = await (Repo.FindAsync(
                    conceptUniqueKeyPropertyFamilyRef => true,
                    conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptUniqueKeyPropertyFamilyRefs == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptUniqueKeyPropertyFamilyRefs, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptUniqueKeyPropertyFamilyRef
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptUniqueKeyPropertyFamilyRef>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptUniqueKeyPropertyFamilyRefAsync(ConceptUniqueKeyPropertyFamilyRefDto conceptUniqueKeyPropertyFamilyRefDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef = MapFromDto(conceptUniqueKeyPropertyFamilyRefDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptUniqueKeyPropertyFamilyRef);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId.ToString()),
                    BuildResponse(conceptUniqueKeyPropertyFamilyRef)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <param name="conceptUniqueKeyPropertyFamilyRefDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptUniqueKeyPropertyFamilyRefId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptUniqueKeyPropertyFamilyRef>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptUniqueKeyPropertyFamilyRefAsync(
            int conceptUniqueKeyPropertyFamilyRefId,
            ConceptUniqueKeyPropertyFamilyRefDto conceptUniqueKeyPropertyFamilyRefDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef = await (Repo.GetByConceptUniqueKeyPropertyFamilyRefIdAsync(conceptUniqueKeyPropertyFamilyRefId));
                if (conceptUniqueKeyPropertyFamilyRef == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptUniqueKeyPropertyFamilyRef = MapFromDto(conceptUniqueKeyPropertyFamilyRefDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptUniqueKeyPropertyFamilyRef);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptUniqueKeyPropertyFamilyRef)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptUniqueKeyPropertyFamilyRefId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptUniqueKeyPropertyFamilyRefAsync(int conceptUniqueKeyPropertyFamilyRefId)
        {
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef = await (Repo.GetByConceptUniqueKeyPropertyFamilyRefIdAsync(conceptUniqueKeyPropertyFamilyRefId));
            if (conceptUniqueKeyPropertyFamilyRef == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptUniqueKeyPropertyFamilyRef);
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
