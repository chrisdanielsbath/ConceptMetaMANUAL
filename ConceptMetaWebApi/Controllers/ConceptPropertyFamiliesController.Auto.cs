/****************************
 * ConceptPropertyFamiliesController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptPropertyFamily" /> entity
    /// </summary>
    [Route("api/ConceptPropertyFamilies")]
    [ApiController]
    public partial class ConceptPropertyFamiliesController
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
        /// creates a new instance of the ConceptPropertyFamiliesController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptPropertyFamiliesController(ConceptMetaDbContext dbContext)
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
        private IConceptPropertyFamilyRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptPropertyFamilies;
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
                            cfg.CreateMap<DbEntities.ConceptPropertyFamily, ConceptPropertyFamilyDto>();
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
                            cfg.CreateMap<ConceptPropertyFamilyDto, DbEntities.ConceptPropertyFamily>();
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
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        private ConceptPropertyFamilyDto MapToDto(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return ToDtoMapper.Map<ConceptPropertyFamilyDto>(conceptPropertyFamily);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptPropertyFamilies"></param>
        /// <returns></returns>
        private IEnumerable<ConceptPropertyFamilyDto> MapToDto(IEnumerable<DbEntities.ConceptPropertyFamily> conceptPropertyFamilies)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptPropertyFamilyDto>>(conceptPropertyFamilies);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptPropertyFamilyDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptPropertyFamily MapFromDto(ConceptPropertyFamilyDto conceptPropertyFamilyDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptPropertyFamily>(conceptPropertyFamilyDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptPropertyFamilyDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptPropertyFamily> MapFromDto(IEnumerable<ConceptPropertyFamilyDto> conceptPropertyFamilyDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptPropertyFamily>>(conceptPropertyFamilyDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptPropertyFamilyDto> BuildResponse(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return new ResponseWrapper<ConceptPropertyFamilyDto>(MapToDto(conceptPropertyFamily));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptPropertyFamilies"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptPropertyFamilyDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptPropertyFamily> conceptPropertyFamilies,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptPropertyFamilyDto>>(
                    MapToDto(conceptPropertyFamilies),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        [HttpGet("{conceptPropertyFamilyId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptPropertyFamily>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptPropertyFamilyIdAsync(int conceptPropertyFamilyId)
        {
            DbEntities.ConceptPropertyFamily conceptPropertyFamily = await (Repo.GetRichEntityByConceptPropertyFamilyIdAsync(conceptPropertyFamilyId));
            if (conceptPropertyFamily == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptPropertyFamily)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptPropertyFamily items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptPropertyFamily>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptPropertyFamily> conceptPropertyFamilies = await (Repo.FindAsync(
                    conceptPropertyFamily => true,
                    conceptPropertyFamily => conceptPropertyFamily.ConceptPropertyFamilyId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptPropertyFamilies == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptPropertyFamilies, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptPropertyFamily
        /// </summary>
        /// <param name="conceptPropertyFamilyDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptPropertyFamily>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptPropertyFamilyAsync(ConceptPropertyFamilyDto conceptPropertyFamilyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptPropertyFamily conceptPropertyFamily = MapFromDto(conceptPropertyFamilyDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptPropertyFamily);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptPropertyFamily.ConceptPropertyFamilyId.ToString()),
                    BuildResponse(conceptPropertyFamily)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <param name="conceptPropertyFamilyDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptPropertyFamilyId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptPropertyFamily>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptPropertyFamilyAsync(
            int conceptPropertyFamilyId,
            ConceptPropertyFamilyDto conceptPropertyFamilyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptPropertyFamily conceptPropertyFamily = await (Repo.GetByConceptPropertyFamilyIdAsync(conceptPropertyFamilyId));
                if (conceptPropertyFamily == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptPropertyFamily = MapFromDto(conceptPropertyFamilyDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptPropertyFamily);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptPropertyFamily)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptPropertyFamilyId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptPropertyFamilyAsync(int conceptPropertyFamilyId)
        {
            DbEntities.ConceptPropertyFamily conceptPropertyFamily = await (Repo.GetByConceptPropertyFamilyIdAsync(conceptPropertyFamilyId));
            if (conceptPropertyFamily == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptPropertyFamily);
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
