/****************************
 * ConceptSubTypesController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptSubType" /> entity
    /// </summary>
    [Route("api/ConceptSubTypes")]
    [ApiController]
    public partial class ConceptSubTypesController
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
        /// creates a new instance of the ConceptSubTypesController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptSubTypesController(ConceptMetaDbContext dbContext)
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
        private IConceptSubTypeRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptSubTypes;
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
                            cfg.CreateMap<DbEntities.ConceptSubType, ConceptSubTypeDto>();
                            cfg.CreateMap<DbEntities.ConceptSubTypePropertyFamilyRef, ConceptSubTypePropertyFamilyRefLiteDto>();
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
                            cfg.CreateMap<ConceptSubTypeDto, DbEntities.ConceptSubType>();
                            cfg.CreateMap<ConceptSubTypePropertyFamilyRefLiteDto, DbEntities.ConceptSubTypePropertyFamilyRef>();
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
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        private ConceptSubTypeDto MapToDto(DbEntities.ConceptSubType conceptSubType)
        {
            return ToDtoMapper.Map<ConceptSubTypeDto>(conceptSubType);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptSubTypes"></param>
        /// <returns></returns>
        private IEnumerable<ConceptSubTypeDto> MapToDto(IEnumerable<DbEntities.ConceptSubType> conceptSubTypes)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptSubTypeDto>>(conceptSubTypes);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptSubTypeDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptSubType MapFromDto(ConceptSubTypeDto conceptSubTypeDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptSubType>(conceptSubTypeDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptSubTypeDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptSubType> MapFromDto(IEnumerable<ConceptSubTypeDto> conceptSubTypeDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptSubType>>(conceptSubTypeDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptSubTypeDto> BuildResponse(DbEntities.ConceptSubType conceptSubType)
        {
            return new ResponseWrapper<ConceptSubTypeDto>(MapToDto(conceptSubType));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptSubTypes"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptSubTypeDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptSubType> conceptSubTypes,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptSubTypeDto>>(
                    MapToDto(conceptSubTypes),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        [HttpGet("{conceptSubTypeId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptSubType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptSubTypeIdAsync(int conceptSubTypeId)
        {
            DbEntities.ConceptSubType conceptSubType = await (Repo.GetRichEntityByConceptSubTypeIdAsync(conceptSubTypeId));
            if (conceptSubType == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptSubType)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptSubType items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptSubType>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptSubType> conceptSubTypes = await (Repo.FindAsync(
                    conceptSubType => true,
                    conceptSubType => conceptSubType.ConceptSubTypeId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptSubTypes == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptSubTypes, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptSubType
        /// </summary>
        /// <param name="conceptSubTypeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptSubType>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptSubTypeAsync(ConceptSubTypeDto conceptSubTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptSubType conceptSubType = MapFromDto(conceptSubTypeDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptSubType);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptSubType.ConceptSubTypeId.ToString()),
                    BuildResponse(conceptSubType)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptSubTypeDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptSubTypeId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptSubType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptSubTypeAsync(
            int conceptSubTypeId,
            ConceptSubTypeDto conceptSubTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptSubType conceptSubType = await (Repo.GetByConceptSubTypeIdAsync(conceptSubTypeId));
                if (conceptSubType == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptSubType = MapFromDto(conceptSubTypeDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptSubType);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptSubType)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptSubTypeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptSubTypeAsync(int conceptSubTypeId)
        {
            DbEntities.ConceptSubType conceptSubType = await (Repo.GetByConceptSubTypeIdAsync(conceptSubTypeId));
            if (conceptSubType == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptSubType);
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
