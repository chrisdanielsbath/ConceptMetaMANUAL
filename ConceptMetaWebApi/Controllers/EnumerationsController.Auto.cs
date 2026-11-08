/****************************
 * EnumerationsController.Auto.cs
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
    /// WebApi Controller class for the <see cref="Enumeration" /> entity
    /// </summary>
    [Route("api/Enumerations")]
    [ApiController]
    public partial class EnumerationsController
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
        /// creates a new instance of the EnumerationsController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public EnumerationsController(ConceptMetaDbContext dbContext)
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
        private IEnumerationRepository Repo
        {
            get
            {
                return UnitOfWork.Enumerations;
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
                            cfg.CreateMap<DbEntities.Enumeration, EnumerationDto>();
                            cfg.CreateMap<DbEntities.EnumerationMember, EnumerationMemberLiteDto>();
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
                            cfg.CreateMap<EnumerationDto, DbEntities.Enumeration>();
                            cfg.CreateMap<EnumerationMemberLiteDto, DbEntities.EnumerationMember>();
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
        /// <param name="enumeration"></param>
        /// <returns></returns>
        private EnumerationDto MapToDto(DbEntities.Enumeration enumeration)
        {
            return ToDtoMapper.Map<EnumerationDto>(enumeration);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="enumerations"></param>
        /// <returns></returns>
        private IEnumerable<EnumerationDto> MapToDto(IEnumerable<DbEntities.Enumeration> enumerations)
        {
            return ToDtoMapper.Map<IEnumerable<EnumerationDto>>(enumerations);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="enumerationDto"></param>
        /// <returns></returns>
        private DbEntities.Enumeration MapFromDto(EnumerationDto enumerationDto)
        {
            return FromDtoMapper.Map<DbEntities.Enumeration>(enumerationDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="enumerationDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.Enumeration> MapFromDto(IEnumerable<EnumerationDto> enumerationDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.Enumeration>>(enumerationDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        private ResponseWrapper<EnumerationDto> BuildResponse(DbEntities.Enumeration enumeration)
        {
            return new ResponseWrapper<EnumerationDto>(MapToDto(enumeration));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="enumerations"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<EnumerationDto>> BuildResponse(
            IEnumerable<DbEntities.Enumeration> enumerations,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<EnumerationDto>>(
                    MapToDto(enumerations),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        [HttpGet("{enumerationId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Enumeration>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByEnumerationIdAsync(int enumerationId)
        {
            DbEntities.Enumeration enumeration = await (Repo.GetRichEntityByEnumerationIdAsync(enumerationId));
            if (enumeration == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(enumeration)); // 200
            }
        }

        /// <summary>
        /// Gets all Enumeration items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.Enumeration>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.Enumeration> enumerations = await (Repo.FindAsync(
                    enumeration => true,
                    enumeration => enumeration.EnumerationId,
                    filter.PageNumber,
                    filter.PageSize));
            if (enumerations == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(enumerations, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new Enumeration
        /// </summary>
        /// <param name="enumerationDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Enumeration>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEnumerationAsync(EnumerationDto enumerationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Enumeration enumeration = MapFromDto(enumerationDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(enumeration);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + enumeration.EnumerationId.ToString()),
                    BuildResponse(enumeration)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumerationDto"></param>
        /// <returns></returns>
        [HttpPut("{enumerationId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Enumeration>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEnumerationAsync(
            int enumerationId,
            EnumerationDto enumerationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Enumeration enumeration = await (Repo.GetByEnumerationIdAsync(enumerationId));
                if (enumeration == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    enumeration = MapFromDto(enumerationDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(enumeration);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(enumeration)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        [HttpDelete("{enumerationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEnumerationAsync(int enumerationId)
        {
            DbEntities.Enumeration enumeration = await (Repo.GetByEnumerationIdAsync(enumerationId));
            if (enumeration == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(enumeration);
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
