/****************************
 * QualifiersController.Auto.cs
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
    /// WebApi Controller class for the <see cref="Qualifier" /> entity
    /// </summary>
    [Route("api/Qualifiers")]
    [ApiController]
    public partial class QualifiersController
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
        /// creates a new instance of the QualifiersController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public QualifiersController(ConceptMetaDbContext dbContext)
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
        private IQualifierRepository Repo
        {
            get
            {
                return UnitOfWork.Qualifiers;
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
                            cfg.CreateMap<DbEntities.Qualifier, QualifierDto>();
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
                            cfg.CreateMap<QualifierDto, DbEntities.Qualifier>();
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
        /// <param name="qualifier"></param>
        /// <returns></returns>
        private QualifierDto MapToDto(DbEntities.Qualifier qualifier)
        {
            return ToDtoMapper.Map<QualifierDto>(qualifier);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="qualifiers"></param>
        /// <returns></returns>
        private IEnumerable<QualifierDto> MapToDto(IEnumerable<DbEntities.Qualifier> qualifiers)
        {
            return ToDtoMapper.Map<IEnumerable<QualifierDto>>(qualifiers);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="qualifierDto"></param>
        /// <returns></returns>
        private DbEntities.Qualifier MapFromDto(QualifierDto qualifierDto)
        {
            return FromDtoMapper.Map<DbEntities.Qualifier>(qualifierDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="qualifierDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.Qualifier> MapFromDto(IEnumerable<QualifierDto> qualifierDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.Qualifier>>(qualifierDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        private ResponseWrapper<QualifierDto> BuildResponse(DbEntities.Qualifier qualifier)
        {
            return new ResponseWrapper<QualifierDto>(MapToDto(qualifier));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="qualifiers"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<QualifierDto>> BuildResponse(
            IEnumerable<DbEntities.Qualifier> qualifiers,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<QualifierDto>>(
                    MapToDto(qualifiers),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        [HttpGet("{qualifierId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Qualifier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByQualifierIdAsync(int qualifierId)
        {
            DbEntities.Qualifier qualifier = await (Repo.GetRichEntityByQualifierIdAsync(qualifierId));
            if (qualifier == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(qualifier)); // 200
            }
        }

        /// <summary>
        /// Gets all Qualifier items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.Qualifier>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.Qualifier> qualifiers = await (Repo.FindAsync(
                    qualifier => true,
                    qualifier => qualifier.QualifierId,
                    filter.PageNumber,
                    filter.PageSize));
            if (qualifiers == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(qualifiers, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new Qualifier
        /// </summary>
        /// <param name="qualifierDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Qualifier>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateQualifierAsync(QualifierDto qualifierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Qualifier qualifier = MapFromDto(qualifierDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(qualifier);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + qualifier.QualifierId.ToString()),
                    BuildResponse(qualifier)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <param name="qualifierDto"></param>
        /// <returns></returns>
        [HttpPut("{qualifierId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.Qualifier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateQualifierAsync(
            int qualifierId,
            QualifierDto qualifierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.Qualifier qualifier = await (Repo.GetByQualifierIdAsync(qualifierId));
                if (qualifier == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    qualifier = MapFromDto(qualifierDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(qualifier);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(qualifier)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        [HttpDelete("{qualifierId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteQualifierAsync(int qualifierId)
        {
            DbEntities.Qualifier qualifier = await (Repo.GetByQualifierIdAsync(qualifierId));
            if (qualifier == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(qualifier);
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
