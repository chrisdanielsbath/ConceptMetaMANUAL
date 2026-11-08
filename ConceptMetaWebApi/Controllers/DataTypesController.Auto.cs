/****************************
 * DataTypesController.Auto.cs
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
    /// WebApi Controller class for the <see cref="DataType" /> entity
    /// </summary>
    [Route("api/DataTypes")]
    [ApiController]
    public partial class DataTypesController
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
        /// creates a new instance of the DataTypesController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public DataTypesController(ConceptMetaDbContext dbContext)
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
        private IDataTypeRepository Repo
        {
            get
            {
                return UnitOfWork.DataTypes;
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
                            cfg.CreateMap<DbEntities.DataType, DataTypeDto>();
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
                            cfg.CreateMap<DataTypeDto, DbEntities.DataType>();
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
        /// <param name="dataType"></param>
        /// <returns></returns>
        private DataTypeDto MapToDto(DbEntities.DataType dataType)
        {
            return ToDtoMapper.Map<DataTypeDto>(dataType);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="dataTypes"></param>
        /// <returns></returns>
        private IEnumerable<DataTypeDto> MapToDto(IEnumerable<DbEntities.DataType> dataTypes)
        {
            return ToDtoMapper.Map<IEnumerable<DataTypeDto>>(dataTypes);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="dataTypeDto"></param>
        /// <returns></returns>
        private DbEntities.DataType MapFromDto(DataTypeDto dataTypeDto)
        {
            return FromDtoMapper.Map<DbEntities.DataType>(dataTypeDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="dataTypeDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.DataType> MapFromDto(IEnumerable<DataTypeDto> dataTypeDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.DataType>>(dataTypeDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private ResponseWrapper<DataTypeDto> BuildResponse(DbEntities.DataType dataType)
        {
            return new ResponseWrapper<DataTypeDto>(MapToDto(dataType));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="dataTypes"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<DataTypeDto>> BuildResponse(
            IEnumerable<DbEntities.DataType> dataTypes,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<DataTypeDto>>(
                    MapToDto(dataTypes),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        [HttpGet("{dataTypeId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.DataType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByDataTypeIdAsync(int dataTypeId)
        {
            DbEntities.DataType dataType = await (Repo.GetRichEntityByDataTypeIdAsync(dataTypeId));
            if (dataType == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(dataType)); // 200
            }
        }

        /// <summary>
        /// Gets all DataType items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.DataType>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.DataType> dataTypes = await (Repo.FindAsync(
                    dataType => true,
                    dataType => dataType.DataTypeId,
                    filter.PageNumber,
                    filter.PageSize));
            if (dataTypes == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(dataTypes, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new DataType
        /// </summary>
        /// <param name="dataTypeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.DataType>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateDataTypeAsync(DataTypeDto dataTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.DataType dataType = MapFromDto(dataTypeDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(dataType);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + dataType.DataTypeId.ToString()),
                    BuildResponse(dataType)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <param name="dataTypeDto"></param>
        /// <returns></returns>
        [HttpPut("{dataTypeId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.DataType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDataTypeAsync(
            int dataTypeId,
            DataTypeDto dataTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.DataType dataType = await (Repo.GetByDataTypeIdAsync(dataTypeId));
                if (dataType == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    dataType = MapFromDto(dataTypeDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(dataType);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(dataType)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        [HttpDelete("{dataTypeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDataTypeAsync(int dataTypeId)
        {
            DbEntities.DataType dataType = await (Repo.GetByDataTypeIdAsync(dataTypeId));
            if (dataType == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(dataType);
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
