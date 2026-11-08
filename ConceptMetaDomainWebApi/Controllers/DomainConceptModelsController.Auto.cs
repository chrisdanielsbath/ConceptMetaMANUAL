/****************************
 * DomainConceptModelsController.Auto.cs
 ****************************/
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels = ConceptMeta.Domain;
using ConceptMeta.DomainDtos;
using ConceptMeta.Services;
using ConceptMeta.ConceptMetaDb.DomainRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.DomainWebApi.Controllers
{
    /// <summary>
    /// WebApi Controller class for the <see cref="DomainModels.ConceptModel" /> aggregate
    /// </summary>
    [Route("api/DomainConceptModels")]
    [ApiController]
    public partial class DomainConceptModelsController
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
        /// creates a new instance of the DomainConceptModelsController class
        /// </summary>
        /// <param name="domainUnitOfWork">the unit of work from which aggregates will be retrieved</param>
        public DomainConceptModelsController(IConceptMetaDbDomainUnitOfWork domainUnitOfWork)
        {
            UnitOfWork = domainUnitOfWork;
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
        private IConceptMetaDbDomainUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// the repository through which to access data
        /// </summary>
        private IConceptModelDomainRepository Repo
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
                            cfg.CreateMap<DomainModels.ConceptModel, ConceptModelDto>();
                            cfg.CreateMap<DomainModels.DataType, DataTypeDto>();
                            cfg.CreateMap<DomainModels.Enumeration, EnumerationDto>();
                            cfg.CreateMap<DomainModels.EnumerationMember, EnumerationMemberDto>();
                            cfg.CreateMap<DomainModels.Concept, ConceptDto>();
                            cfg.CreateMap<DomainModels.Include, IncludeDto>();
                            cfg.CreateMap<DomainModels.Qualifier, QualifierDto>();
                            cfg.CreateMap<DomainModels.ConceptPropertyFamily, ConceptPropertyFamilyDto>();
                            cfg.CreateMap<DomainModels.ConceptUniqueKey, ConceptUniqueKeyDto>();
                            cfg.CreateMap<DomainModels.ConceptUniqueKeyPropertyFamilyRef, ConceptUniqueKeyPropertyFamilyRefDto>();
                            cfg.CreateMap<DomainModels.ConceptSubType, ConceptSubTypeDto>();
                            cfg.CreateMap<DomainModels.ConceptSubTypePropertyFamilyRef, ConceptSubTypePropertyFamilyRefDto>();
                            cfg.CreateMap<DomainModels.ConceptRef, ConceptRefDto>();
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
                            cfg.CreateMap<ConceptModelDto, DomainModels.ConceptModel>();
                            cfg.CreateMap<DataTypeDto, DomainModels.DataType>();
                            cfg.CreateMap<EnumerationDto, DomainModels.Enumeration>();
                            cfg.CreateMap<EnumerationMemberDto, DomainModels.EnumerationMember>();
                            cfg.CreateMap<ConceptDto, DomainModels.Concept>();
                            cfg.CreateMap<IncludeDto, DomainModels.Include>();
                            cfg.CreateMap<QualifierDto, DomainModels.Qualifier>();
                            cfg.CreateMap<ConceptPropertyFamilyDto, DomainModels.ConceptPropertyFamily>();
                            cfg.CreateMap<ConceptUniqueKeyDto, DomainModels.ConceptUniqueKey>();
                            cfg.CreateMap<ConceptUniqueKeyPropertyFamilyRefDto, DomainModels.ConceptUniqueKeyPropertyFamilyRef>();
                            cfg.CreateMap<ConceptSubTypeDto, DomainModels.ConceptSubType>();
                            cfg.CreateMap<ConceptSubTypePropertyFamilyRefDto, DomainModels.ConceptSubTypePropertyFamilyRef>();
                            cfg.CreateMap<ConceptRefDto, DomainModels.ConceptRef>();
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
        /// Maps from Domain Objects to Dtos
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        private ConceptModelDto MapToDto(DomainModels.ConceptModel conceptModel)
        {
            return ToDtoMapper.Map<ConceptModelDto>(conceptModel);
        }

        /// <summary>
        /// Maps from Domain Objects to Dtos
        /// </summary>
        /// <param name="conceptModels"></param>
        /// <returns></returns>
        private IEnumerable<ConceptModelDto> MapToDto(IEnumerable<DomainModels.ConceptModel> conceptModels)
        {
            return ToDtoMapper.Map<IEnumerable<ConceptModelDto>>(conceptModels);
        }

        /// <summary>
        /// Maps from Dtos to Domain Objects
        /// </summary>
        /// <param name="conceptModelDto"></param>
        /// <returns></returns>
        private DomainModels.ConceptModel MapFromDto(ConceptModelDto conceptModelDto)
        {
            return FromDtoMapper.Map<DomainModels.ConceptModel>(conceptModelDto);
        }

        /// <summary>
        /// Maps from Dtos to Domain Objects
        /// </summary>
        /// <param name="conceptModelDtos"></param>
        /// <returns></returns>
        private IEnumerable<DomainModels.ConceptModel> MapFromDto(IEnumerable<ConceptModelDto> conceptModelDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DomainModels.ConceptModel>>(conceptModelDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        private ResponseWrapper<ConceptModelDto> BuildResponse(DomainModels.ConceptModel conceptModel)
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
            IEnumerable<DomainModels.ConceptModel> conceptModels,
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
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        [HttpGet("{modelName}")]
        [ProducesResponseType(typeof(ResponseWrapper<DomainModels.ConceptModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByModelNameAsync(string modelName)
        {
            DomainModels.ConceptModel conceptModel = await (Repo.GetByModelNameAsync(modelName));
            if (conceptModel == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(conceptModel)); // 200
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
        [ProducesResponseType(typeof(ResponseWrapper<DomainModels.ConceptModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConceptModelAsync(ConceptModelDto conceptModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DomainModels.ConceptModel conceptModel = MapFromDto(conceptModelDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    await Repo.AddAsync(conceptModel);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + conceptModel.ModelName.ToString()),
                    BuildResponse(conceptModel)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptModelDto"></param>
        /// <returns></returns>
        [HttpPut("{modelName}")]
        [ProducesResponseType(typeof(ResponseWrapper<DomainModels.ConceptModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateConceptModelAsync(
            string modelName,
            ConceptModelDto conceptModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DomainModels.ConceptModel conceptModel = await (Repo.GetByModelNameAsync(modelName));
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
        /// Removes the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        [HttpDelete("{modelName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConceptModelAsync(string modelName)
        {
            DomainModels.ConceptModel conceptModel = await (Repo.GetByModelNameAsync(modelName));
            if (conceptModel == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    await Repo.RemoveAsync(conceptModel);
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
