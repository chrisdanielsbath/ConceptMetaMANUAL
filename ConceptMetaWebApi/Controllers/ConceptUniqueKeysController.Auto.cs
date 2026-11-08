/****************************
 * ConceptUniqueKeysController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptUniqueKey" /> entity
    /// </summary>
    [Route("api/ConceptUniqueKeys")]
    [ApiController]
    public partial class ConceptUniqueKeysController
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
        /// creates a new instance of the ConceptUniqueKeysController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptUniqueKeysController(ConceptMetaDbContext dbContext)
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
        private IConceptUniqueKeyRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptUniqueKeys;
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
                            cfg.CreateMap<DbEntities.ConceptUniqueKey, ConceptUniqueKeyDto>();
                            cfg.CreateMap<DbEntities.ConceptUniqueKeyPropertyFamilyRef, ConceptUniqueKeyPropertyFamilyRefLiteDto>();
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
                            cfg.CreateMap<ConceptUniqueKeyDto, DbEntities.ConceptUniqueKey>();
                            cfg.CreateMap<ConceptUniqueKeyPropertyFamilyRefLiteDto, DbEntities.ConceptUniqueKeyPropertyFamilyRef>();
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
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        private ConceptUniqueKeyDto MapToDto(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return ToDtoMapper.Map<ConceptUniqueKeyDto>(conceptUniqueKey);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptUniqueKeys"></param>
        /// <returns></returns>
        private IEnumerable<ConceptUniqueKeyDto> MapToDto(IEnumerable<DbEntities.ConceptUniqueKey> conceptUniqueKeys)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptUniqueKeyDto>>(conceptUniqueKeys);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptUniqueKeyDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptUniqueKey MapFromDto(ConceptUniqueKeyDto conceptUniqueKeyDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptUniqueKey>(conceptUniqueKeyDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptUniqueKeyDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptUniqueKey> MapFromDto(IEnumerable<ConceptUniqueKeyDto> conceptUniqueKeyDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptUniqueKey>>(conceptUniqueKeyDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptUniqueKeyDto> BuildResponse(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return new ResponseWrapper<ConceptUniqueKeyDto>(MapToDto(conceptUniqueKey));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptUniqueKeys"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptUniqueKeyDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptUniqueKey> conceptUniqueKeys,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptUniqueKeyDto>>(
                    MapToDto(conceptUniqueKeys),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        [HttpGet("{conceptUniqueKeyId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptUniqueKey>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptUniqueKeyIdAsync(int conceptUniqueKeyId)
        {
            DbEntities.ConceptUniqueKey conceptUniqueKey = await (Repo.GetRichEntityByConceptUniqueKeyIdAsync(conceptUniqueKeyId));
            if (conceptUniqueKey == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptUniqueKey)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptUniqueKey items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptUniqueKey>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptUniqueKey> conceptUniqueKeys = await (Repo.FindAsync(
                    conceptUniqueKey => true,
                    conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptUniqueKeys == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptUniqueKeys, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptUniqueKey
        /// </summary>
        /// <param name="conceptUniqueKeyDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptUniqueKey>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptUniqueKeyAsync(ConceptUniqueKeyDto conceptUniqueKeyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptUniqueKey conceptUniqueKey = MapFromDto(conceptUniqueKeyDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptUniqueKey);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptUniqueKey.ConceptUniqueKeyId.ToString()),
                    BuildResponse(conceptUniqueKey)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptUniqueKeyDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptUniqueKeyId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptUniqueKey>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptUniqueKeyAsync(
            int conceptUniqueKeyId,
            ConceptUniqueKeyDto conceptUniqueKeyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptUniqueKey conceptUniqueKey = await (Repo.GetByConceptUniqueKeyIdAsync(conceptUniqueKeyId));
                if (conceptUniqueKey == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptUniqueKey = MapFromDto(conceptUniqueKeyDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptUniqueKey);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptUniqueKey)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptUniqueKeyId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptUniqueKeyAsync(int conceptUniqueKeyId)
        {
            DbEntities.ConceptUniqueKey conceptUniqueKey = await (Repo.GetByConceptUniqueKeyIdAsync(conceptUniqueKeyId));
            if (conceptUniqueKey == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptUniqueKey);
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
