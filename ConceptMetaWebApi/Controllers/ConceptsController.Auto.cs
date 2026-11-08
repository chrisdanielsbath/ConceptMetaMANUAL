/****************************
 * ConceptsController.Auto.cs
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
    /// WebApi Controller class for the <see cref="Concept" /> entity
    /// </summary>
    [Route("api/Concepts")]
    [ApiController]
    public partial class ConceptsController
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
        /// creates a new instance of the ConceptsController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptsController(ConceptMetaDbContext dbContext)
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
        private IConceptRepository Repo
        {
            get
            {
                return UnitOfWork.Concepts;
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
                            cfg.CreateMap<DbEntities.Concept, ConceptDto>();
                            cfg.CreateMap<DbEntities.Include, IncludeLiteDto>();
                            cfg.CreateMap<DbEntities.Qualifier, QualifierLiteDto>();
                            cfg.CreateMap<DbEntities.ConceptPropertyFamily, ConceptPropertyFamilyLiteDto>();
                            cfg.CreateMap<DbEntities.ConceptUniqueKey, ConceptUniqueKeyLiteDto>();
                            cfg.CreateMap<DbEntities.ConceptUniqueKeyPropertyFamilyRef, ConceptUniqueKeyPropertyFamilyRefLiteDto>();
                            cfg.CreateMap<DbEntities.ConceptSubType, ConceptSubTypeLiteDto>();
                            cfg.CreateMap<DbEntities.ConceptSubTypePropertyFamilyRef, ConceptSubTypePropertyFamilyRefLiteDto>();
                            cfg.CreateMap<DbEntities.ConceptRef, ConceptRefLiteDto>();
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
                            cfg.CreateMap<ConceptDto, DbEntities.Concept>();
                            cfg.CreateMap<IncludeLiteDto, DbEntities.Include>();
                            cfg.CreateMap<QualifierLiteDto, DbEntities.Qualifier>();
                            cfg.CreateMap<ConceptPropertyFamilyLiteDto, DbEntities.ConceptPropertyFamily>();
                            cfg.CreateMap<ConceptUniqueKeyLiteDto, DbEntities.ConceptUniqueKey>();
                            cfg.CreateMap<ConceptUniqueKeyPropertyFamilyRefLiteDto, DbEntities.ConceptUniqueKeyPropertyFamilyRef>();
                            cfg.CreateMap<ConceptSubTypeLiteDto, DbEntities.ConceptSubType>();
                            cfg.CreateMap<ConceptSubTypePropertyFamilyRefLiteDto, DbEntities.ConceptSubTypePropertyFamilyRef>();
                            cfg.CreateMap<ConceptRefLiteDto, DbEntities.ConceptRef>();
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
        /// <param name="concept"></param>
        /// <returns></returns>
        private ConceptDto MapToDto(DbEntities.Concept concept)
        {
            return ToDtoMapper.Map<ConceptDto>(concept);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="concepts"></param>
        /// <returns></returns>
        private IEnumerable<ConceptDto> MapToDto(IEnumerable<DbEntities.Concept> concepts)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptDto>>(concepts);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptDto"></param>
        /// <returns></returns>
        private DbEntities.Concept MapFromDto(ConceptDto conceptDto)
        {
            return FromDtoMapper.Map<DbEntities.Concept>(conceptDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.Concept> MapFromDto(IEnumerable<ConceptDto> conceptDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.Concept>>(conceptDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptDto> BuildResponse(DbEntities.Concept concept)
        {
            return new ResponseWrapper<ConceptDto>(MapToDto(concept));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="concepts"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptDto>> BuildResponse(
            IEnumerable<DbEntities.Concept> concepts,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptDto>>(
                    MapToDto(concepts),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        [HttpGet("{conceptId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Concept>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptIdAsync(int conceptId)
        {
            DbEntities.Concept concept = await (Repo.GetRichEntityByConceptIdAsync(conceptId));
            if (concept == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(concept)); // 200
            }
        }

        /// <summary>
        /// Gets all Concept items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.Concept>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.Concept> concepts = await (Repo.FindAsync(
                    concept => true,
                    concept => concept.ConceptId,
                    filter.PageNumber,
                    filter.PageSize));
            if (concepts == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(concepts, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new Concept
        /// </summary>
        /// <param name="conceptDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Concept>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptAsync(ConceptDto conceptDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Concept concept = MapFromDto(conceptDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(concept);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + concept.ConceptId.ToString()),
                    BuildResponse(concept)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="conceptDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Concept>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptAsync(
            int conceptId,
            ConceptDto conceptDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Concept concept = await (Repo.GetByConceptIdAsync(conceptId));
                if (concept == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    concept = MapFromDto(conceptDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(concept);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(concept)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptAsync(int conceptId)
        {
            DbEntities.Concept concept = await (Repo.GetByConceptIdAsync(conceptId));
            if (concept == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(concept);
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
