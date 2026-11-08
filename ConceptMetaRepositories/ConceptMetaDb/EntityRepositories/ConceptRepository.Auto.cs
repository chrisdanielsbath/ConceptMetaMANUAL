/****************************
 * ConceptRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.EntityRepositories
{
    /// <summary>
    /// Repository class for the <see cref="DbEntities.Concept" /> entity
    /// </summary>
    public partial class ConceptRepository
        : ConceptMetaDbRepository<DbEntities.Concept>,
        IConceptRepository
    {

        #region Instance Properties
        protected IIncludeRepository IncludeRepository => DbUnitOfWork.Includes;
        protected IQualifierRepository QualifierRepository => DbUnitOfWork.Qualifiers;
        protected IConceptPropertyFamilyRepository ConceptPropertyFamilyRepository => DbUnitOfWork.ConceptPropertyFamilies;
        protected IConceptUniqueKeyRepository ConceptUniqueKeyRepository => DbUnitOfWork.ConceptUniqueKeys;
        protected IConceptUniqueKeyPropertyFamilyRefRepository ConceptUniqueKeyPropertyFamilyRefRepository => DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs;
        protected IConceptSubTypeRepository ConceptSubTypeRepository => DbUnitOfWork.ConceptSubTypes;
        protected IConceptSubTypePropertyFamilyRefRepository ConceptSubTypePropertyFamilyRefRepository => DbUnitOfWork.ConceptSubTypePropertyFamilyRefs;
        protected IConceptRefRepository ConceptRefRepository => DbUnitOfWork.ConceptRefs;

        #endregion

        #region Constructors
        public ConceptRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified concept
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.Concept concept)
        {
            return new object[] { concept.ConceptId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the concept with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Concept, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptId == (int)keyValues[0]) && (e.ConceptId != default && e.ConceptId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified concept
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Concept, bool>> GetPrimaryKeyPredicate(DbEntities.Concept concept)
        {
            return (e => 
                (e.ConceptId == concept.ConceptId) && (e.ConceptId != default && e.ConceptId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified concept
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Concept, bool>> GetLogicalKeyPredicate(DbEntities.Concept concept)
        {
            return (e => 
                (e.ConceptModelId == concept.ConceptModelId) && 
                (e.ConceptName == concept.ConceptName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified concept
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.Concept concept)
        {
            return new object[] { concept.ModelName, concept.ConceptName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the concept with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Concept, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.Concept from,
            DbEntities.Concept to)
        {
            to.ConceptModelId = from.ConceptModelId;
            to.ConceptName = from.ConceptName;
            to.ConceptDescription = from.ConceptDescription;
            to.ConceptType = from.ConceptType;
            to.DataTypeId = from.DataTypeId;
            to.EnumerationId = from.EnumerationId;
            to.BasedOnConceptId = from.BasedOnConceptId;
            to.ExampleValueAsString = from.ExampleValueAsString;
            to.MinLength = from.MinLength;
            to.MaxLength = from.MaxLength;
            to.MinValue = from.MinValue;
            to.MaxValue = from.MaxValue;
            to.TotalDigits = from.TotalDigits;
            to.DecimalPlaces = from.DecimalPlaces;
            to.DatePrecision = from.DatePrecision;
            to.DbSchemaName = from.DbSchemaName;
            to.DbTableName = from.DbTableName;
            to.IsCollectionItem = from.IsCollectionItem;
            to.ToStringExpression = from.ToStringExpression;
            to.IsCreatable = from.IsCreatable;
            to.IsUpdatable = from.IsUpdatable;
            to.IsDeletable = from.IsDeletable;
            to.SurrogateKeyFieldName = from.SurrogateKeyFieldName;
            to.PrimaryKeyName = from.PrimaryKeyName;
            to.AlternateKeyName = from.AlternateKeyName;
            to.ReferencedConceptId = from.ReferencedConceptId;
            to.ReferencedConceptUniqueKeyId = from.ReferencedConceptUniqueKeyId;
            to.SpecialisedConceptId = from.SpecialisedConceptId;
            to.SpecialisedConceptSubTypeId = from.SpecialisedConceptSubTypeId;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
            RichEntityIncludes.Add("ConceptModel");
            RichEntityIncludes.Add("DataType");
            RichEntityIncludes.Add("DataType.ConceptModel");
            RichEntityIncludes.Add("Enumeration");
            RichEntityIncludes.Add("Enumeration.ConceptModel");
            RichEntityIncludes.Add("Enumeration.DataType");
            RichEntityIncludes.Add("Enumeration.DataType.ConceptModel");
            RichEntityIncludes.Add("BasedOnConcept");
            RichEntityIncludes.Add("BasedOnConcept.ConceptModel");
            RichEntityIncludes.Add("BasedOnConcept.DataType");
            RichEntityIncludes.Add("BasedOnConcept.DataType.ConceptModel");
            RichEntityIncludes.Add("ReferencedConcept");
            RichEntityIncludes.Add("ReferencedConcept.ConceptModel");
            RichEntityIncludes.Add("ReferencedConcept.DataType");
            RichEntityIncludes.Add("ReferencedConcept.DataType.ConceptModel");
            RichEntityIncludes.Add("ReferencedUniqueKey");
            RichEntityIncludes.Add("SpecialisedConcept");
            RichEntityIncludes.Add("SpecialisedConcept.ConceptModel");
            RichEntityIncludes.Add("SpecialisedConcept.DataType");
            RichEntityIncludes.Add("SpecialisedConcept.DataType.ConceptModel");
            RichEntityIncludes.Add("SpecialisedSubType");
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.Concept concept)
        {
            return
                (concept.ReferencedUniqueKey != null)
                || (concept.ReferencedConceptUniqueKeyId != default && concept.ReferencedConceptUniqueKeyId != null)
                || (concept.SpecialisedSubType != null)
                || (concept.SpecialisedConceptSubTypeId != default && concept.SpecialisedConceptSubTypeId != null);
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="concept"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.Concept concept,
            out DbEntities.Concept sterilisedEntity)
        {
             if (!EntityHasReferencesToChildObjects(concept))
            {
                sterilisedEntity = null;
            }
            else
            {
                sterilisedEntity = new DbEntities.Concept();;
                CopyPrimaryKeyValuesFromEntityToObjects(concept, new List<DbEntities.Concept> { sterilisedEntity });
                CopyNonPkFields(concept, sterilisedEntity);

                // now sterilise it
                sterilisedEntity.ReferencedUniqueKey = null;
                sterilisedEntity.ReferencedConceptUniqueKeyId = default;
                sterilisedEntity.SpecialisedSubType = null;
                sterilisedEntity.SpecialisedConceptSubTypeId = default;
            }
        }

        #endregion

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.Concept e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptId == default || e.ConceptId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptId = GetConceptIdByConceptModelIdConceptName(
                    e.ConceptModelId,
                    e.ConceptName);

                // test whether the item has been found within the database
                if (conceptId != default && conceptId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptId = conceptId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.Concept e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptId == default || e.ConceptId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptId = await GetConceptIdByConceptModelIdConceptNameAsync(
                    e.ConceptModelId,
                    e.ConceptName);

                // test whether the item has been found within the database
                if (conceptId != default && conceptId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptId = conceptId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.Concept> items)
        {
            foreach (DbEntities.Concept item in items)
            {
                // populate foreign key fields
                if (item.ConceptModel != null)
                {
                    if (item.ConceptModel.ConceptModelId != default && item.ConceptModel.ConceptModelId != default(int))
                    {
                        item.ConceptModelId = item.ConceptModel.ConceptModelId;
                    }
                }
                if (item.DataType != null)
                {
                    if (item.DataType.DataTypeId != default && item.DataType.DataTypeId != default(int))
                    {
                        item.DataTypeId = item.DataType.DataTypeId;
                    }
                }
                if (item.Enumeration != null)
                {
                    if (item.Enumeration.EnumerationId != default && item.Enumeration.EnumerationId != default(int))
                    {
                        item.EnumerationId = item.Enumeration.EnumerationId;
                    }
                }
                if (item.BasedOnConcept != null)
                {
                    if (item.BasedOnConcept.ConceptId != default && item.BasedOnConcept.ConceptId != default(int))
                    {
                        item.BasedOnConceptId = item.BasedOnConcept.ConceptId;
                    }
                }
                if (item.ReferencedConcept != null)
                {
                    if (item.ReferencedConcept.ConceptId != default && item.ReferencedConcept.ConceptId != default(int))
                    {
                        item.ReferencedConceptId = item.ReferencedConcept.ConceptId;
                    }
                }
                if (item.ReferencedUniqueKey != null)
                {
                    if (item.ReferencedUniqueKey.ConceptUniqueKeyId != default && item.ReferencedUniqueKey.ConceptUniqueKeyId != default(int))
                    {
                        item.ReferencedConceptUniqueKeyId = item.ReferencedUniqueKey.ConceptUniqueKeyId;
                    }
                }
                if (item.SpecialisedConcept != null)
                {
                    if (item.SpecialisedConcept.ConceptId != default && item.SpecialisedConcept.ConceptId != default(int))
                    {
                        item.SpecialisedConceptId = item.SpecialisedConcept.ConceptId;
                    }
                }
                if (item.SpecialisedSubType != null)
                {
                    if (item.SpecialisedSubType.ConceptSubTypeId != default && item.SpecialisedSubType.ConceptSubTypeId != default(int))
                    {
                        item.SpecialisedConceptSubTypeId = item.SpecialisedSubType.ConceptSubTypeId;
                    }
                }
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.Concept> items)
        {
            foreach (DbEntities.Concept item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.Includes != null)
                {
                    foreach (DbEntities.Include childItem in item.Includes)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.Qualifiers != null)
                {
                    foreach (DbEntities.Qualifier childItem in item.Qualifiers)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.PropertyFamilies != null)
                {
                    foreach (DbEntities.ConceptPropertyFamily childItem in item.PropertyFamilies)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.UniqueKeys != null)
                {
                    foreach (DbEntities.ConceptUniqueKey childItem in item.UniqueKeys)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.SubTypes != null)
                {
                    foreach (DbEntities.ConceptSubType childItem in item.SubTypes)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.Properties != null)
                {
                    foreach (DbEntities.ConceptRef childItem in item.Properties)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.DerivedConcepts != null)
                {
                    foreach (DbEntities.Concept childItem in item.DerivedConcepts)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.BasedOnConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.ReferencedByProperties != null)
                {
                    foreach (DbEntities.ConceptRef childItem in item.ReferencedByProperties)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ReferencedConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.ReferencedByConcepts != null)
                {
                    foreach (DbEntities.Concept childItem in item.ReferencedByConcepts)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.ReferencedConceptId = item.ConceptId;
                        }
                    }
                }
                if (item.SpecialisedByConcepts != null)
                {
                    foreach (DbEntities.Concept childItem in item.SpecialisedByConcepts)
                    {
                        if (item.ConceptId != default && item.ConceptId != default(int))
                        {
                            childItem.SpecialisedConceptId = item.ConceptId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a concept to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Concept, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptModelId.ToString() + "|"
                + (e.ConceptName != null ? e.ConceptName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Concept, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptId == default || e.ConceptId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.Concept fromEntity,
            IEnumerable<DbEntities.Concept> toObjects)
        {
            foreach (DbEntities.Concept obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptId = fromEntity.ConceptId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public int GetConceptIdByModelNameConceptName(
            string modelName,
            string conceptName)
        {
            return (Find(
                    concept =>
                        (concept.ConceptModel.ModelName == modelName)
                        && (concept.ConceptName == conceptName)))
                .Select(concept => concept.ConceptId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptIdByModelNameConceptNameAsync(
            string modelName,
            string conceptName)
        {
            return (await FindAsync(
                    concept =>
                        (concept.ConceptModel.ModelName == modelName)
                        && (concept.ConceptName == conceptName)))
                .Select(concept => concept.ConceptId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public int GetConceptIdByConceptModelIdConceptName(
            int conceptModelId,
            string conceptName)
        {
            return (Find(
                    concept =>
                        (concept.ConceptModelId == conceptModelId)
                        && (concept.ConceptName == conceptName)))
                .Select(concept => concept.ConceptId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptIdByConceptModelIdConceptNameAsync(
            int conceptModelId,
            string conceptName)
        {
            return (await FindAsync(
                    concept =>
                        (concept.ConceptModelId == conceptModelId)
                        && (concept.ConceptName == conceptName)))
                .Select(concept => concept.ConceptId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public int GetConceptIdByConceptId(int conceptId)
        {
            return (Find(
                    concept =>
                        (concept.ConceptId == conceptId)))
                .Select(concept => concept.ConceptId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task<int> GetConceptIdByConceptIdAsync(int conceptId)
        {
            return (await FindAsync(
                    concept =>
                        (concept.ConceptId == conceptId)))
                .Select(concept => concept.ConceptId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public DbEntities.Concept GetByConceptId(int? conceptId)
        {
            return (Find (
                    concept =>
                        (concept.ConceptId == conceptId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Concept> GetByConceptIdAsync(int? conceptId)
        {
            return (await FindAsync (
                    concept =>
                        (concept.ConceptId == conceptId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public DbEntities.Concept GetRichEntityByConceptId(int? conceptId)
        {
            return (Find(
                    concept =>
                        (concept.ConceptId == conceptId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Concept> GetRichEntityByConceptIdAsync(int? conceptId)
        {
            return (await FindAsync(
                    concept =>
                        (concept.ConceptId == conceptId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public DbEntities.Concept GetByModelNameConceptName(
            string modelName,
            string conceptName)
        {
            return (Find (
                    concept =>
                        (concept.ConceptModel.ModelName == modelName)
                        && (concept.ConceptName == conceptName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Concept> GetByModelNameConceptNameAsync(
            string modelName,
            string conceptName)
        {
            return (await FindAsync (
                    concept =>
                        (concept.ConceptModel.ModelName == modelName)
                        && (concept.ConceptName == conceptName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public DbEntities.Concept GetRichEntityByModelNameConceptName(
            string modelName,
            string conceptName)
        {
            return (Find(
                    concept =>
                        (concept.ConceptModel.ModelName == modelName)
                        && (concept.ConceptName == conceptName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Concept> GetRichEntityByModelNameConceptNameAsync(
            string modelName,
            string conceptName)
        {
            return (await FindAsync(
                    concept =>
                        (concept.ConceptModel.ModelName == modelName)
                        && (concept.ConceptName == conceptName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public DbEntities.Concept GetByConceptModelIdConceptName(
            int? conceptModelId,
            string conceptName)
        {
            return (Find (
                    concept =>
                        (concept.ConceptModelId == conceptModelId)
                        && (concept.ConceptName == conceptName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Concept> GetByConceptModelIdConceptNameAsync(
            int? conceptModelId,
            string conceptName)
        {
            return (await FindAsync (
                    concept =>
                        (concept.ConceptModelId == conceptModelId)
                        && (concept.ConceptName == conceptName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public DbEntities.Concept GetRichEntityByConceptModelIdConceptName(
            int? conceptModelId,
            string conceptName)
        {
            return (Find(
                    concept =>
                        (concept.ConceptModelId == conceptModelId)
                        && (concept.ConceptName == conceptName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Concept> GetRichEntityByConceptModelIdConceptNameAsync(
            int? conceptModelId,
            string conceptName)
        {
            return (await FindAsync(
                    concept =>
                        (concept.ConceptModelId == conceptModelId)
                        && (concept.ConceptName == conceptName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
