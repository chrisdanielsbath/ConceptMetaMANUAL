/****************************
 * ConceptMetaDbDomainUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common.Domain;
using ConceptMeta.ConceptMetaDb.DomainRepositories;
using ConceptMeta.ConceptMetaDb.DomainRepositoryInterfaces;
using BlueprintModels = ConceptMeta.Blueprint;
using DomainModels = ConceptMeta.Domain;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Domain Unit Of Work for the ConceptMeta model
    /// </summary>
    public partial class ConceptMetaDbDomainUnitOfWork
        : DomainUnitOfWork<IConceptMetaDbBlueprintUnitOfWork>,
        IConceptMetaDbDomainUnitOfWork<IConceptMetaDbBlueprintUnitOfWork>
    {

        #region Constructors
        public ConceptMetaDbDomainUnitOfWork(IConceptMetaDbBlueprintUnitOfWork blueprintUnitOfWork)
            : base (blueprintUnitOfWork)
        {
            ConceptModels = new ConceptModelDomainRepository(this, blueprintUnitOfWork.ConceptModelAggregates);
        }

        #endregion

        #region Instance Properties
        public IConceptModelDomainRepository ConceptModels { get; private set; }

        #endregion

        #region Static Variables

        // The mapper to be used when converting to blueprint objects
        private static IMapper toBlueprintMapper;

        // The mapper to be used when converting from blueprint objects
        private static IMapper fromBlueprintMapper;

        #endregion

        #region Static Properties

        /// <summary>
        /// The LoggerFactory to be used within mappers
        /// </summary>
        public static ILoggerFactory LoggerFactory { get; set; } = new LoggerFactory();

        #endregion

        #region Instance Properties that must be implemented separately within each concrete class

        /// <summary>
        /// The mapper to be used when converting to blueprint objects
        /// </summary>
        public override IMapper ToBlueprintMapper
        {
            get
            {
                if (toBlueprintMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<DomainModels.Concept, BlueprintModels.Concept>();
                            cfg.CreateMap<DomainModels.ConceptModel, BlueprintModels.ConceptModel>();
                            cfg.CreateMap<DomainModels.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>();
                            cfg.CreateMap<DomainModels.ConceptRef, BlueprintModels.ConceptRef>();
                            cfg.CreateMap<DomainModels.ConceptSubType, BlueprintModels.ConceptSubType>();
                            cfg.CreateMap<DomainModels.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>();
                            cfg.CreateMap<DomainModels.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>();
                            cfg.CreateMap<DomainModels.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>();
                            cfg.CreateMap<DomainModels.DataType, BlueprintModels.DataType>();
                            cfg.CreateMap<DomainModels.Enumeration, BlueprintModels.Enumeration>();
                            cfg.CreateMap<DomainModels.EnumerationMember, BlueprintModels.EnumerationMember>();
                            cfg.CreateMap<DomainModels.Include, BlueprintModels.Include>();
                            cfg.CreateMap<DomainModels.Qualifier, BlueprintModels.Qualifier>();
                        },
                        LoggerFactory);
                    toBlueprintMapper = config.CreateMapper();
                }
                return (toBlueprintMapper);
            }
        }

        /// <summary>
        /// The mapper to be used when converting from blueprint objects
        /// </summary>
        public override IMapper FromBlueprintMapper
        {
            get
            {
                if (fromBlueprintMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<BlueprintModels.Concept, DomainModels.Concept>();
                            cfg.CreateMap<BlueprintModels.ConceptModel, DomainModels.ConceptModel>();
                            cfg.CreateMap<BlueprintModels.ConceptPropertyFamily, DomainModels.ConceptPropertyFamily>();
                            cfg.CreateMap<BlueprintModels.ConceptRef, DomainModels.ConceptRef>();
                            cfg.CreateMap<BlueprintModels.ConceptSubType, DomainModels.ConceptSubType>();
                            cfg.CreateMap<BlueprintModels.ConceptSubTypePropertyFamilyRef, DomainModels.ConceptSubTypePropertyFamilyRef>();
                            cfg.CreateMap<BlueprintModels.ConceptUniqueKey, DomainModels.ConceptUniqueKey>();
                            cfg.CreateMap<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef, DomainModels.ConceptUniqueKeyPropertyFamilyRef>();
                            cfg.CreateMap<BlueprintModels.DataType, DomainModels.DataType>();
                            cfg.CreateMap<BlueprintModels.Enumeration, DomainModels.Enumeration>();
                            cfg.CreateMap<BlueprintModels.EnumerationMember, DomainModels.EnumerationMember>();
                            cfg.CreateMap<BlueprintModels.Include, DomainModels.Include>();
                            cfg.CreateMap<BlueprintModels.Qualifier, DomainModels.Qualifier>();
                        },
                        LoggerFactory);
                    fromBlueprintMapper = config.CreateMapper();
                }
                return (fromBlueprintMapper);
                
            }
        }

        #endregion
    }
}
