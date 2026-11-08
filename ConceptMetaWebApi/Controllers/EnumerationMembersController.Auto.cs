/****************************
 * EnumerationMembersController.Auto.cs
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
    /// WebApi Controller class for the <see cref="EnumerationMember" /> entity
    /// </summary>
    [Route("api/EnumerationMembers")]
    [ApiController]
    public partial class EnumerationMembersController
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
        /// creates a new instance of the EnumerationMembersController class
        /// </summary>
        /// <param name="dbContext">the database context from which entities will be retrieved</param>
        public EnumerationMembersController(ConceptMetaDbContext dbContext)
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
        private IEnumerationMemberRepository Repo
        {
            get
            {
                return UnitOfWork.EnumerationMembers;
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
                            cfg.CreateMap<DbEntities.EnumerationMember, EnumerationMemberDto>();
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
                            cfg.CreateMap<EnumerationMemberDto, DbEntities.EnumerationMember>();
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
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        private EnumerationMemberDto MapToDto(DbEntities.EnumerationMember enumerationMember)
        {
            return ToDtoMapper.Map<EnumerationMemberDto>(enumerationMember);
        }

        /// <summary>
        /// Maps from Entities to Dtos
        /// </summary>
        /// <param name="enumerationMembers"></param>
        /// <returns></returns>
        private IEnumerable<EnumerationMemberDto> MapToDto(IEnumerable<DbEntities.EnumerationMember> enumerationMembers)
        {
            return ToDtoMapper.Map<IEnumerable<EnumerationMemberDto>>(enumerationMembers);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="enumerationMemberDto"></param>
        /// <returns></returns>
        private DbEntities.EnumerationMember MapFromDto(EnumerationMemberDto enumerationMemberDto)
        {
            return FromDtoMapper.Map<DbEntities.EnumerationMember>(enumerationMemberDto);
        }

        /// <summary>
        /// Maps from Dtos to Entities
        /// </summary>
        /// <param name="enumerationMemberDtos"></param>
        /// <returns></returns>
        private IEnumerable<DbEntities.EnumerationMember> MapFromDto(IEnumerable<EnumerationMemberDto> enumerationMemberDtos)
        {
            return FromDtoMapper.Map<IEnumerable<DbEntities.EnumerationMember>>(enumerationMemberDtos);
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        private ResponseWrapper<EnumerationMemberDto> BuildResponse(DbEntities.EnumerationMember enumerationMember)
        {
            return new ResponseWrapper<EnumerationMemberDto>(MapToDto(enumerationMember));
        }

        /// <summary>
        /// Builds the response
        /// </summary>
        /// <param name="enumerationMembers"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private ResponseWrapper<IEnumerable<EnumerationMemberDto>> BuildResponse(
            IEnumerable<DbEntities.EnumerationMember> enumerationMembers,
            int pageNumber,
            int pageSize)
        {
            return new PagedResponseWrapper<IEnumerable<EnumerationMemberDto>>(
                    MapToDto(enumerationMembers),
                    pageNumber,
                    pageSize);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        [HttpGet("{enumerationMemberId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.EnumerationMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByEnumerationMemberIdAsync(int enumerationMemberId)
        {
            DbEntities.EnumerationMember enumerationMember = await (Repo.GetRichEntityByEnumerationMemberIdAsync(enumerationMemberId));
            if (enumerationMember == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(enumerationMember)); // 200
            }
        }

        /// <summary>
        /// Gets all EnumerationMember items
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<DbEntities.EnumerationMember>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            IEnumerable<DbEntities.EnumerationMember> enumerationMembers = await (Repo.FindAsync(
                    enumerationMember => true,
                    enumerationMember => enumerationMember.EnumerationMemberId,
                    filter.PageNumber,
                    filter.PageSize));
            if (enumerationMembers == null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(BuildResponse(enumerationMembers, filter.PageNumber, filter.PageSize)); // 200
            }
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds a new EnumerationMember
        /// </summary>
        /// <param name="enumerationMemberDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.EnumerationMember>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEnumerationMemberAsync(EnumerationMemberDto enumerationMemberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.EnumerationMember enumerationMember = MapFromDto(enumerationMemberDto);
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Add(enumerationMember);
                    await UnitOfWork.CompleteAsync();
                }
                catch
                {
                    await UnitOfWork.RollbackAsync();
                    throw;
                }
                return Created(
                    new Uri(Request.Host + Request.Path + "/" + enumerationMember.EnumerationMemberId.ToString()),
                    BuildResponse(enumerationMember)); // 201
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <param name="enumerationMemberDto"></param>
        /// <returns></returns>
        [HttpPut("{enumerationMemberId}")]
        [ProducesResponseType(typeof(ResponseWrapper<DbEntities.EnumerationMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEnumerationMemberAsync(
            int enumerationMemberId,
            EnumerationMemberDto enumerationMemberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // 400
            }
            else
            {
                DbEntities.EnumerationMember enumerationMember = await (Repo.GetByEnumerationMemberIdAsync(enumerationMemberId));
                if (enumerationMember == null)
                {
                    return NotFound(); // 404
                }
                else
                {
                    enumerationMember = MapFromDto(enumerationMemberDto);
                    await UnitOfWork.BeginTransactionAsync();
                    try
                    {
                        await Repo.UpdateAsync(enumerationMember);
                        await UnitOfWork.CompleteAsync();
                    }
                    catch
                    {
                        await UnitOfWork.RollbackAsync();
                        throw;
                    }
                    return Ok(BuildResponse(enumerationMember)); // 200
                }
            }
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        [HttpDelete("{enumerationMemberId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEnumerationMemberAsync(int enumerationMemberId)
        {
            DbEntities.EnumerationMember enumerationMember = await (Repo.GetByEnumerationMemberIdAsync(enumerationMemberId));
            if (enumerationMember == null)
            {
                return NotFound(); // 404
            }
            else
            {
                await UnitOfWork.BeginTransactionAsync();
                try
                {
                    Repo.Remove(enumerationMember);
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
