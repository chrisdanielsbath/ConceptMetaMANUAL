/****************************
 * ConceptMetaDbBlueprintUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common.Blueprint;
using ConceptMeta.ConceptMetaDb.BlueprintRepositories;
using ConceptMeta.ConceptMetaDb.BlueprintAggregateRepositories;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using BlueprintModels = ConceptMeta.Blueprint;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Blueprint Unit Of Work for the ConceptMeta model
    /// </summary>
    public partial class ConceptMetaDbBlueprintUnitOfWork
        : BlueprintUnitOfWork<IConceptMetaDbUnitOfWork>,
        IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork>
    {

        #region Constructors
        public ConceptMetaDbBlueprintUnitOfWork(IConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
            Concepts = new ConceptBlueprintRepository(this, dbUnitOfWork.Concepts);
            ConceptModels = new ConceptModelBlueprintRepository(this, dbUnitOfWork.ConceptModels);
            ConceptPropertyFamilies = new ConceptPropertyFamilyBlueprintRepository(this, dbUnitOfWork.ConceptPropertyFamilies);
            ConceptRefs = new ConceptRefBlueprintRepository(this, dbUnitOfWork.ConceptRefs);
            ConceptSubTypes = new ConceptSubTypeBlueprintRepository(this, dbUnitOfWork.ConceptSubTypes);
            ConceptSubTypePropertyFamilyRefs = new ConceptSubTypePropertyFamilyRefBlueprintRepository(this, dbUnitOfWork.ConceptSubTypePropertyFamilyRefs);
            ConceptUniqueKeys = new ConceptUniqueKeyBlueprintRepository(this, dbUnitOfWork.ConceptUniqueKeys);
            ConceptUniqueKeyPropertyFamilyRefs = new ConceptUniqueKeyPropertyFamilyRefBlueprintRepository(this, dbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs);
            DataTypes = new DataTypeBlueprintRepository(this, dbUnitOfWork.DataTypes);
            Enumerations = new EnumerationBlueprintRepository(this, dbUnitOfWork.Enumerations);
            EnumerationMembers = new EnumerationMemberBlueprintRepository(this, dbUnitOfWork.EnumerationMembers);
            Includes = new IncludeBlueprintRepository(this, dbUnitOfWork.Includes);
            Qualifiers = new QualifierBlueprintRepository(this, dbUnitOfWork.Qualifiers);
            ConceptModelAggregates = new ConceptModelBlueprintAggregateRepository(ConceptModels);
        }

        #endregion

        #region Instance Properties
        public IConceptBlueprintRepository Concepts { get; private set; }
        public IConceptModelBlueprintRepository ConceptModels { get; private set; }
        public IConceptPropertyFamilyBlueprintRepository ConceptPropertyFamilies { get; private set; }
        public IConceptRefBlueprintRepository ConceptRefs { get; private set; }
        public IConceptSubTypeBlueprintRepository ConceptSubTypes { get; private set; }
        public IConceptSubTypePropertyFamilyRefBlueprintRepository ConceptSubTypePropertyFamilyRefs { get; private set; }
        public IConceptUniqueKeyBlueprintRepository ConceptUniqueKeys { get; private set; }
        public IConceptUniqueKeyPropertyFamilyRefBlueprintRepository ConceptUniqueKeyPropertyFamilyRefs { get; private set; }
        public IDataTypeBlueprintRepository DataTypes { get; private set; }
        public IEnumerationBlueprintRepository Enumerations { get; private set; }
        public IEnumerationMemberBlueprintRepository EnumerationMembers { get; private set; }
        public IIncludeBlueprintRepository Includes { get; private set; }
        public IQualifierBlueprintRepository Qualifiers { get; private set; }
        public IConceptModelBlueprintAggregateRepository ConceptModelAggregates { get; private set; }

        #endregion

        #region Static Variables

        // The mapper to be used when converting to Entities
        public static IMapper toEntityMapper;

        // The mapper to be used when converting from Entities
        public static IMapper fromEntityMapper;

        // The mapper to be used when converting to Entity/Blueprint pairs
        public static IMapper toEntityBlueprintPairMapper;

        // The mapper to be used when converting from Entity/Blueprint pairs
        public static IMapper fromEntityBlueprintPairMapper;

        #endregion

        #region Static Properties

        /// <summary>
        /// The LoggerFactory to be used within mappers
        /// </summary>
        public static ILoggerFactory LoggerFactory { get; set; } = new LoggerFactory();

        #endregion

        #region Instance Properties that must be implemented separately within each concrete class

        /// <summary>
        /// The mapper to be used when converting to Entities
        /// </summary>
        public override IMapper ToEntityMapper
        {
            get
            {
                if (toEntityMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<BlueprintModels.Concept, DbEntities.Concept>();
                            cfg.CreateMap<BlueprintModels.ConceptModel, DbEntities.ConceptModel>();
                            cfg.CreateMap<BlueprintModels.ConceptPropertyFamily, DbEntities.ConceptPropertyFamily>();
                            cfg.CreateMap<BlueprintModels.ConceptRef, DbEntities.ConceptRef>();
                            cfg.CreateMap<BlueprintModels.ConceptSubType, DbEntities.ConceptSubType>();
                            cfg.CreateMap<BlueprintModels.ConceptSubTypePropertyFamilyRef, DbEntities.ConceptSubTypePropertyFamilyRef>();
                            cfg.CreateMap<BlueprintModels.ConceptUniqueKey, DbEntities.ConceptUniqueKey>();
                            cfg.CreateMap<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef, DbEntities.ConceptUniqueKeyPropertyFamilyRef>();
                            cfg.CreateMap<BlueprintModels.DataType, DbEntities.DataType>();
                            cfg.CreateMap<BlueprintModels.Enumeration, DbEntities.Enumeration>();
                            cfg.CreateMap<BlueprintModels.EnumerationMember, DbEntities.EnumerationMember>();
                            cfg.CreateMap<BlueprintModels.Include, DbEntities.Include>();
                            cfg.CreateMap<BlueprintModels.Qualifier, DbEntities.Qualifier>();
                        },
                        LoggerFactory);
                    toEntityMapper = config.CreateMapper();
                }
                return (toEntityMapper);
            }
        }

        /// <summary>
        /// The mapper to be used when converting from Entities
        /// </summary>
        public override IMapper FromEntityMapper
        {
            get
            {
                if (fromEntityMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<DbEntities.Concept, BlueprintModels.Concept>();
                            cfg.CreateMap<DbEntities.ConceptModel, BlueprintModels.ConceptModel>();
                            cfg.CreateMap<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>();
                            cfg.CreateMap<DbEntities.ConceptRef, BlueprintModels.ConceptRef>();
                            cfg.CreateMap<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>();
                            cfg.CreateMap<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>();
                            cfg.CreateMap<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>();
                            cfg.CreateMap<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>();
                            cfg.CreateMap<DbEntities.DataType, BlueprintModels.DataType>();
                            cfg.CreateMap<DbEntities.Enumeration, BlueprintModels.Enumeration>();
                            cfg.CreateMap<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>();
                            cfg.CreateMap<DbEntities.Include, BlueprintModels.Include>();
                            cfg.CreateMap<DbEntities.Qualifier, BlueprintModels.Qualifier>();
                        },
                        LoggerFactory);
                    fromEntityMapper = config.CreateMapper();
                }
                return (fromEntityMapper);
            }
        }

        /// <summary>
        /// The mapper to be used when converting to Entity/Blueprint pairs
        /// </summary>
        public override IMapper ToEntityBlueprintPairMapper
        {
            get
            {
                if (toEntityBlueprintPairMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<BlueprintModels.Concept, KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>(ToEntityMapper.Map<DbEntities.Concept>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptModel, KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>(ToEntityMapper.Map<DbEntities.ConceptModel>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptPropertyFamily, KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>(ToEntityMapper.Map<DbEntities.ConceptPropertyFamily>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptRef, KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>(ToEntityMapper.Map<DbEntities.ConceptRef>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptSubType, KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>(ToEntityMapper.Map<DbEntities.ConceptSubType>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptSubTypePropertyFamilyRef, KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>(ToEntityMapper.Map<DbEntities.ConceptSubTypePropertyFamilyRef>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptUniqueKey, KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>(ToEntityMapper.Map<DbEntities.ConceptUniqueKey>(x), x));

                            cfg.CreateMap<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef, KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>(ToEntityMapper.Map<DbEntities.ConceptUniqueKeyPropertyFamilyRef>(x), x));

                            cfg.CreateMap<BlueprintModels.DataType, KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>(ToEntityMapper.Map<DbEntities.DataType>(x), x));

                            cfg.CreateMap<BlueprintModels.Enumeration, KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>(ToEntityMapper.Map<DbEntities.Enumeration>(x), x));

                            cfg.CreateMap<BlueprintModels.EnumerationMember, KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>(ToEntityMapper.Map<DbEntities.EnumerationMember>(x), x));

                            cfg.CreateMap<BlueprintModels.Include, KeyValuePair<DbEntities.Include, BlueprintModels.Include>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.Include, BlueprintModels.Include>(ToEntityMapper.Map<DbEntities.Include>(x), x));

                            cfg.CreateMap<BlueprintModels.Qualifier, KeyValuePair<DbEntities.Qualifier, BlueprintModels.Qualifier>>()
                                .ConstructUsing(x =>
                                    new KeyValuePair<DbEntities.Qualifier, BlueprintModels.Qualifier>(ToEntityMapper.Map<DbEntities.Qualifier>(x), x));

                        },
                        LoggerFactory);
                    toEntityBlueprintPairMapper = config.CreateMapper();
                }
                return (toEntityBlueprintPairMapper);
            }
        }

        /// <summary>
        /// The mapper to be used when converting from Entity/Blueprint pairs
        /// </summary>
        public override IMapper FromEntityBlueprintPairMapper
        {
            get
            {
                if (fromEntityBlueprintPairMapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>, BlueprintModels.Concept>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>, BlueprintModels.ConceptModel>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>, BlueprintModels.ConceptPropertyFamily>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>, BlueprintModels.ConceptRef>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>, BlueprintModels.ConceptSubType>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>, BlueprintModels.ConceptSubTypePropertyFamilyRef>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>, BlueprintModels.ConceptUniqueKey>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>, BlueprintModels.DataType>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>, BlueprintModels.Enumeration>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>, BlueprintModels.EnumerationMember>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.Include, BlueprintModels.Include>, BlueprintModels.Include>()
                                .ConstructUsing(x =>
                                    x.Value);

                            cfg.CreateMap<KeyValuePair<DbEntities.Qualifier, BlueprintModels.Qualifier>, BlueprintModels.Qualifier>()
                                .ConstructUsing(x =>
                                    x.Value);

                        },
                        LoggerFactory);
                    fromEntityBlueprintPairMapper = config.CreateMapper();
                }
                return (fromEntityBlueprintPairMapper);
            }
        }

        #endregion
    }
}
