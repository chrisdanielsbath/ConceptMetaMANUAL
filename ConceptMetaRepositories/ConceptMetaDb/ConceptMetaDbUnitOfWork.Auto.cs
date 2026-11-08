/****************************
 * ConceptMetaDbUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.ConceptMetaDb.EntityRepositories;
using ConceptMeta.ConceptMetaDb.AggregateRepositories;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Unit Of Work for the ConceptMeta model
    /// </summary>
    public partial class ConceptMetaDbUnitOfWork
        : ConceptMetaDbUnitOfWorkBase,
        IConceptMetaDbUnitOfWork
    {

        #region Constructors
        public ConceptMetaDbUnitOfWork(ConceptMetaDbContext dbContext)
            : base (dbContext)
        {
            Concepts = new ConceptRepository(this);
            ConceptModels = new ConceptModelRepository(this);
            ConceptPropertyFamilies = new ConceptPropertyFamilyRepository(this);
            ConceptRefs = new ConceptRefRepository(this);
            ConceptSubTypes = new ConceptSubTypeRepository(this);
            ConceptSubTypePropertyFamilyRefs = new ConceptSubTypePropertyFamilyRefRepository(this);
            ConceptUniqueKeys = new ConceptUniqueKeyRepository(this);
            ConceptUniqueKeyPropertyFamilyRefs = new ConceptUniqueKeyPropertyFamilyRefRepository(this);
            DataTypes = new DataTypeRepository(this);
            Enumerations = new EnumerationRepository(this);
            EnumerationMembers = new EnumerationMemberRepository(this);
            Includes = new IncludeRepository(this);
            Qualifiers = new QualifierRepository(this);
            ConceptModelAggregates = new ConceptModelAggregateRepository(ConceptModels);
        }

        #endregion

        #region Instance Properties
        public IConceptRepository Concepts { get; private set; }
        public IConceptModelRepository ConceptModels { get; private set; }
        public IConceptPropertyFamilyRepository ConceptPropertyFamilies { get; private set; }
        public IConceptRefRepository ConceptRefs { get; private set; }
        public IConceptSubTypeRepository ConceptSubTypes { get; private set; }
        public IConceptSubTypePropertyFamilyRefRepository ConceptSubTypePropertyFamilyRefs { get; private set; }
        public IConceptUniqueKeyRepository ConceptUniqueKeys { get; private set; }
        public IConceptUniqueKeyPropertyFamilyRefRepository ConceptUniqueKeyPropertyFamilyRefs { get; private set; }
        public IDataTypeRepository DataTypes { get; private set; }
        public IEnumerationRepository Enumerations { get; private set; }
        public IEnumerationMemberRepository EnumerationMembers { get; private set; }
        public IIncludeRepository Includes { get; private set; }
        public IQualifierRepository Qualifiers { get; private set; }
        public IConceptModelAggregateRepository ConceptModelAggregates { get; private set; }

        #endregion
    }
}
