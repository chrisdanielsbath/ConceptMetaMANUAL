/****************************
 * ConceptModelsController.Auto.cs
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
    /// WebApi Controller class for the <see cref="ConceptModel" /> entity
    /// </summary>
    [Route("api/ConceptModels")]
    [ApiController]
    public partial class ConceptModelsController
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
        /// creates a new instance of the ConceptModelsController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public ConceptModelsController(ConceptMetaDbContext dbContext)
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
        private IConceptModelRepository Repo
        {
            get
            {
                return UnitOfWork.ConceptModels;
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
                            cfg.CreateMap<DbEntities.ConceptModel, ConceptModelDto>();
                            cfg.CreateMap<DbEntities.DataType, DataTypeLiteDto>();
                            cfg.CreateMap<DbEntities.Enumeration, EnumerationLiteDto>();
                            cfg.CreateMap<DbEntities.EnumerationMember, EnumerationMemberLiteDto>();
                            cfg.CreateMap<DbEntities.Concept, ConceptLiteDto>();
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
                            cfg.CreateMap<ConceptModelDto, DbEntities.ConceptModel>();
                            cfg.CreateMap<DataTypeLiteDto, DbEntities.DataType>();
                            cfg.CreateMap<EnumerationLiteDto, DbEntities.Enumeration>();
                            cfg.CreateMap<EnumerationMemberLiteDto, DbEntities.EnumerationMember>();
                            cfg.CreateMap<ConceptLiteDto, DbEntities.Concept>();
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
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        private ConceptModelDto MapToDto(DbEntities.ConceptModel conceptModel)
        {
            return ToDtoMapper.Map<ConceptModelDto>(conceptModel);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="conceptModels"></param>
        /// <returns></returns>
        private IEnumerable<ConceptModelDto> MapToDto(IEnumerable<DbEntities.ConceptModel> conceptModels)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptModelDto>>(conceptModels);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptModelDto"></param>
        /// <returns></returns>
        private DbEntities.ConceptModel MapFromDto(ConceptModelDto conceptModelDto)
        {
            return FromDtoMapper.Map<DbEntities.ConceptModel>(conceptModelDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="conceptModelDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.ConceptModel> MapFromDto(IEnumerable<ConceptModelDto> conceptModelDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.ConceptModel>>(conceptModelDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptModelDto> BuildResponse(DbEntities.ConceptModel conceptModel)
        {
            return new ResponseWrapper<ConceptModelDto>(MapToDto(conceptModel));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptModels"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<ConceptModelDto>> BuildResponse(
            IEnumerable<DbEntities.ConceptModel> conceptModels,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<ConceptModelDto>>(
                    MapToDto(conceptModels),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        [HttpGet("{conceptModelId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByConceptModelIdAsync(int conceptModelId)
        {
            DbEntities.ConceptModel conceptModel = await (Repo.GetRichEntityByConceptModelIdAsync(conceptModelId));
            if (conceptModel == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptModel)); // 200
            }
        }

        /// <summary>
        /// Gets all ConceptModel items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.ConceptModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.ConceptModel> conceptModels = await (Repo.FindAsync(
                    conceptModel => true,
                    conceptModel => conceptModel.ConceptModelId,
                    filter.PageNumber,
                    filter.PageSize));
            if (conceptModels == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptModels, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new ConceptModel
        /// </summary>
        /// <param name="conceptModelDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptModelAsync(ConceptModelDto conceptModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptModel conceptModel = MapFromDto(conceptModelDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(conceptModel);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptModel.ConceptModelId.ToString()),
                    BuildResponse(conceptModel)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptModelDto"></param>
        /// <returns></returns>
        [HttpPut("{conceptModelId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.ConceptModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptModelAsync(
            int conceptModelId,
            ConceptModelDto conceptModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.ConceptModel conceptModel = await (Repo.GetByConceptModelIdAsync(conceptModelId));
                if (conceptModel == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    conceptModel = MapFromDto(conceptModelDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(conceptModel);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(conceptModel)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        [HttpDelete("{conceptModelId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptModelAsync(int conceptModelId)
        {
            DbEntities.ConceptModel conceptModel = await (Repo.GetByConceptModelIdAsync(conceptModelId));
            if (conceptModel == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(conceptModel);
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
