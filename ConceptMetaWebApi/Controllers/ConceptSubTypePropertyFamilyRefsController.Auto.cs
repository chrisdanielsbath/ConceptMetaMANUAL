/****************************
 * ConceptSubTypePropertyFamilyRefsController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    [Route("api/ConceptSubTypePropertyFamilyRefs")]
    [ApiController]
    public partial class ConceptSubTypePropertyFamilyRefsController
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
        /// creates a new instance of the ConceptSubTypePropertyFamilyRefsController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptSubTypePropertyFamilyRefsController(ConceptMetaDbContext dbContext)
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
        private IConceptSubTypePropertyFamilyRefRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptSubTypePropertyFamilyRefs;
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
                            cfg.CreateMap<DbEntities.ConceptSubTypePropertyFamilyRef, ConceptSubTypePropertyFamilyRefDto>();
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
                            cfg.CreateMap<ConceptSubTypePropertyFamilyRefDto, DbEntities.ConceptSubTypePropertyFamilyRef>();
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
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        private ConceptSubTypePropertyFamilyRefDto MapToDto(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return ToDtoMapper.Map<ConceptSubTypePropertyFamilyRefDto>(conceptSubTypePropertyFamilyRef);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefs"></param>
        /// <returns></returns>
        private IEnumerable<ConceptSubTypePropertyFamilyRefDto> MapToDto(IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> conceptSubTypePropertyFamilyRefs)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptSubTypePropertyFamilyRefDto>>(conceptSubTypePropertyFamilyRefs);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptSubTypePropertyFamilyRef MapFromDto(ConceptSubTypePropertyFamilyRefDto conceptSubTypePropertyFamilyRefDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptSubTypePropertyFamilyRef>(conceptSubTypePropertyFamilyRefDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> MapFromDto(IEnumerable<ConceptSubTypePropertyFamilyRefDto> conceptSubTypePropertyFamilyRefDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef>>(conceptSubTypePropertyFamilyRefDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptSubTypePropertyFamilyRefDto> BuildResponse(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return new ResponseWrapper<ConceptSubTypePropertyFamilyRefDto>(MapToDto(conceptSubTypePropertyFamilyRef));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefs"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptSubTypePropertyFamilyRefDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> conceptSubTypePropertyFamilyRefs,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptSubTypePropertyFamilyRefDto>>(
                    MapToDto(conceptSubTypePropertyFamilyRefs),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        [HttpGet("{conceptSubTypePropertyFamilyRefId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptSubTypePropertyFamilyRef>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptSubTypePropertyFamilyRefIdAsync(int conceptSubTypePropertyFamilyRefId)
        {
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = await (Repo.GetRichEntityByConceptSubTypePropertyFamilyRefIdAsync(conceptSubTypePropertyFamilyRefId));
            if (conceptSubTypePropertyFamilyRef == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptSubTypePropertyFamilyRef)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptSubTypePropertyFamilyRef items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> conceptSubTypePropertyFamilyRefs = await (Repo.FindAsync(
                    conceptSubTypePropertyFamilyRef => true,
                    conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptSubTypePropertyFamilyRefs == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptSubTypePropertyFamilyRefs, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptSubTypePropertyFamilyRef
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptSubTypePropertyFamilyRef>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptSubTypePropertyFamilyRefAsync(ConceptSubTypePropertyFamilyRefDto conceptSubTypePropertyFamilyRefDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = MapFromDto(conceptSubTypePropertyFamilyRefDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptSubTypePropertyFamilyRef);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId.ToString()),
                    BuildResponse(conceptSubTypePropertyFamilyRef)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <param name="conceptSubTypePropertyFamilyRefDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptSubTypePropertyFamilyRefId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptSubTypePropertyFamilyRef>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptSubTypePropertyFamilyRefAsync(
            int conceptSubTypePropertyFamilyRefId,
            ConceptSubTypePropertyFamilyRefDto conceptSubTypePropertyFamilyRefDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = await (Repo.GetByConceptSubTypePropertyFamilyRefIdAsync(conceptSubTypePropertyFamilyRefId));
                if (conceptSubTypePropertyFamilyRef == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptSubTypePropertyFamilyRef = MapFromDto(conceptSubTypePropertyFamilyRefDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptSubTypePropertyFamilyRef);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptSubTypePropertyFamilyRef)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptSubTypePropertyFamilyRefId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptSubTypePropertyFamilyRefAsync(int conceptSubTypePropertyFamilyRefId)
        {
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = await (Repo.GetByConceptSubTypePropertyFamilyRefIdAsync(conceptSubTypePropertyFamilyRefId));
            if (conceptSubTypePropertyFamilyRef == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptSubTypePropertyFamilyRef);
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
