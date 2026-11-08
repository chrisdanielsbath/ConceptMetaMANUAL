/****************************
 * ConceptRefRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.ConceptRef" /> entity
    /// </summary>
    public partial class ConceptRefRepository
        : ConceptMetaDbRepository<DbEntities.ConceptRef>,
        IConceptRefRepository
    {

        #region Constructors
        public ConceptRefRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptRef
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptRef conceptRef)
        {
            return new object[] { conceptRef.ConceptRefId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptRef with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptRef, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptRefId == (int)keyValues[0]) && (e.ConceptRefId != default && e.ConceptRefId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptRef
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptRef, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptRef conceptRef)
        {
            return (e => 
                (e.ConceptRefId == conceptRef.ConceptRefId) && (e.ConceptRefId != default && e.ConceptRefId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptRef
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptRef, bool>> GetLogicalKeyPredicate(DbEntities.ConceptRef conceptRef)
        {
            return (e => 
                (e.ConceptId == conceptRef.ConceptId) && 
                (e.PropertyName == conceptRef.PropertyName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptRef
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptRef conceptRef)
        {
            return new object[] { conceptRef.ModelName, conceptRef.ConceptName, conceptRef.PropertyName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptRef with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptRef, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.PropertyName == (string)keyValues[2]) && (e.PropertyName != default && e.PropertyName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptRef from,
            DbEntities.ConceptRef to)
        {
            to.ConceptId = from.ConceptId;
            to.PropertyName = from.PropertyName;
            to.PropertyDescription = from.PropertyDescription;
            to.ReferencedConceptId = from.ReferencedConceptId;
            to.ConceptRefType = from.ConceptRefType;
            to.ConceptPropertyFamilyId = from.ConceptPropertyFamilyId;
            to.IsPropagating = from.IsPropagating;
            to.DbColumnName = from.DbColumnName;
            to.IsIdentity = from.IsIdentity;
            to.IsCoreField = from.IsCoreField;
            to.FieldFamilyName = from.FieldFamilyName;
            to.IsUpdatable = from.IsUpdatable;
            to.FieldLabel = from.FieldLabel;
            to.IsScalarFieldToSerialiseInPersistenceModel = from.IsScalarFieldToSerialiseInPersistenceModel;
            to.IsScalarFieldToSerialiseInDomainModel = from.IsScalarFieldToSerialiseInDomainModel;
            to.IsSeqNoField = from.IsSeqNoField;
            to.IsDiscriminatorField = from.IsDiscriminatorField;
            to.IsXmlAttribute = from.IsXmlAttribute;
            to.IsReferenceToChildEntity = from.IsReferenceToChildEntity;
            to.ParentQualifier = from.ParentQualifier;
            to.ChildQualifier = from.ChildQualifier;
            to.MinChildOccurrences = from.MinChildOccurrences;
            to.MaxChildOccurrences = from.MaxChildOccurrences;
            to.ChildVerbPhrase = from.ChildVerbPhrase;
            to.ParentVerbPhrase = from.ParentVerbPhrase;
            to.ChildPropertySeq = from.ChildPropertySeq;
            to.ChildCollectionName = from.ChildCollectionName;
            to.ChildItemName = from.ChildItemName;
            to.ChildPropertyDescription = from.ChildPropertyDescription;
            to.SelectorType = from.SelectorType;
            to.RelationshipType = from.RelationshipType;
            to.OutputExplicitXmlCollection = from.OutputExplicitXmlCollection;
            to.IsSerialisedUsingScalarFieldInDomainModel = from.IsSerialisedUsingScalarFieldInDomainModel;
            to.ScalarFieldNameInDomainModel = from.ScalarFieldNameInDomainModel;
            to.ExampleValueAsString = from.ExampleValueAsString;
            to.RelationshipName = from.RelationshipName;
            to.DbForeignKeyName = from.DbForeignKeyName;
            to.ParentIndexName = from.ParentIndexName;
            to.ForeignKeySurrogateKeyFieldName = from.ForeignKeySurrogateKeyFieldName;
            to.ChildPropertyName = from.ChildPropertyName;
            to.IsNullable = from.IsNullable;
            to.PropertySeq = from.PropertySeq;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
            RichEntityIncludes.Add("Concept");
            RichEntityIncludes.Add("Concept.ConceptModel");
            RichEntityIncludes.Add("Concept.DataType");
            RichEntityIncludes.Add("Concept.DataType.ConceptModel");
            RichEntityIncludes.Add("ReferencedConcept");
            RichEntityIncludes.Add("ReferencedConcept.ConceptModel");
            RichEntityIncludes.Add("ReferencedConcept.DataType");
            RichEntityIncludes.Add("ReferencedConcept.DataType.ConceptModel");
            RichEntityIncludes.Add("PropertyFamily");
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptRef conceptRef)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptRef conceptRef,
            out DbEntities.ConceptRef sterilisedEntity)
        {
            sterilisedEntity = null;
        }

        #endregion

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptRef e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptRefId == default || e.ConceptRefId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptRefId = GetConceptRefIdByConceptIdPropertyName(
                    e.ConceptId,
                    e.PropertyName);

                // test whether the item has been found within the database
                if (conceptRefId != default && conceptRefId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptRefId = conceptRefId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptRef e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptRefId == default || e.ConceptRefId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptRefId = await GetConceptRefIdByConceptIdPropertyNameAsync(
                    e.ConceptId,
                    e.PropertyName);

                // test whether the item has been found within the database
                if (conceptRefId != default && conceptRefId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptRefId = conceptRefId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptRef> items)
        {
            foreach (DbEntities.ConceptRef item in items)
            {
                // populate foreign key fields
                if (item.Concept != null)
                {
                    if (item.Concept.ConceptId != default && item.Concept.ConceptId != default(int))
                    {
                        item.ConceptId = item.Concept.ConceptId;
                    }
                }
                if (item.ReferencedConcept != null)
                {
                    if (item.ReferencedConcept.ConceptId != default && item.ReferencedConcept.ConceptId != default(int))
                    {
                        item.ReferencedConceptId = item.ReferencedConcept.ConceptId;
                    }
                }
                if (item.PropertyFamily != null)
                {
                    if (item.PropertyFamily.ConceptPropertyFamilyId != default && item.PropertyFamily.ConceptPropertyFamilyId != default(int))
                    {
                        item.ConceptPropertyFamilyId = item.PropertyFamily.ConceptPropertyFamilyId;
                    }
                }
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptRef> items)
        {
            foreach (DbEntities.ConceptRef item in items)
            {
                // populate foreign key fields within child objects (if any)
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptRef to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptRef, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.PropertyName != null ? e.PropertyName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptRef, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptRefId == default || e.ConceptRefId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptRef fromEntity,
            IEnumerable<DbEntities.ConceptRef> toObjects)
        {
            foreach (DbEntities.ConceptRef obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptRefId = fromEntity.ConceptRefId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public int GetConceptRefIdByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName)
        {
            return (Find(
                    conceptRef =>
                        (conceptRef.Concept.ConceptModel.ModelName == modelName)
                        && (conceptRef.Concept.ConceptName == conceptName)
                        && (conceptRef.PropertyName == propertyName)))
                .Select(conceptRef => conceptRef.ConceptRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptRefIdByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName)
        {
            return (await FindAsync(
                    conceptRef =>
                        (conceptRef.Concept.ConceptModel.ModelName == modelName)
                        && (conceptRef.Concept.ConceptName == conceptName)
                        && (conceptRef.PropertyName == propertyName)))
                .Select(conceptRef => conceptRef.ConceptRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public int GetConceptRefIdByConceptIdPropertyName(
            int conceptId,
            string propertyName)
        {
            return (Find(
                    conceptRef =>
                        (conceptRef.ConceptId == conceptId)
                        && (conceptRef.PropertyName == propertyName)))
                .Select(conceptRef => conceptRef.ConceptRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptRefIdByConceptIdPropertyNameAsync(
            int conceptId,
            string propertyName)
        {
            return (await FindAsync(
                    conceptRef =>
                        (conceptRef.ConceptId == conceptId)
                        && (conceptRef.PropertyName == propertyName)))
                .Select(conceptRef => conceptRef.ConceptRefId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        public DbEntities.ConceptRef GetByConceptRefId(int? conceptRefId)
        {
            return (Find (
                    conceptRef =>
                        (conceptRef.ConceptRefId == conceptRefId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptRef> GetByConceptRefIdAsync(int? conceptRefId)
        {
            return (await FindAsync (
                    conceptRef =>
                        (conceptRef.ConceptRefId == conceptRefId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        public DbEntities.ConceptRef GetRichEntityByConceptRefId(int? conceptRefId)
        {
            return (Find(
                    conceptRef =>
                        (conceptRef.ConceptRefId == conceptRefId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptRef> GetRichEntityByConceptRefIdAsync(int? conceptRefId)
        {
            return (await FindAsync(
                    conceptRef =>
                        (conceptRef.ConceptRefId == conceptRefId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptRef GetByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName)
        {
            return (Find (
                    conceptRef =>
                        (conceptRef.Concept.ConceptModel.ModelName == modelName)
                        && (conceptRef.Concept.ConceptName == conceptName)
                        && (conceptRef.PropertyName == propertyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptRef> GetByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName)
        {
            return (await FindAsync (
                    conceptRef =>
                        (conceptRef.Concept.ConceptModel.ModelName == modelName)
                        && (conceptRef.Concept.ConceptName == conceptName)
                        && (conceptRef.PropertyName == propertyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptRef GetRichEntityByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName)
        {
            return (Find(
                    conceptRef =>
                        (conceptRef.Concept.ConceptModel.ModelName == modelName)
                        && (conceptRef.Concept.ConceptName == conceptName)
                        && (conceptRef.PropertyName == propertyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptRef> GetRichEntityByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName)
        {
            return (await FindAsync(
                    conceptRef =>
                        (conceptRef.Concept.ConceptModel.ModelName == modelName)
                        && (conceptRef.Concept.ConceptName == conceptName)
                        && (conceptRef.PropertyName == propertyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptRef GetByConceptIdPropertyName(
            int? conceptId,
            string propertyName)
        {
            return (Find (
                    conceptRef =>
                        (conceptRef.ConceptId == conceptId)
                        && (conceptRef.PropertyName == propertyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptRef> GetByConceptIdPropertyNameAsync(
            int? conceptId,
            string propertyName)
        {
            return (await FindAsync (
                    conceptRef =>
                        (conceptRef.ConceptId == conceptId)
                        && (conceptRef.PropertyName == propertyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptRef GetRichEntityByConceptIdPropertyName(
            int? conceptId,
            string propertyName)
        {
            return (Find(
                    conceptRef =>
                        (conceptRef.ConceptId == conceptId)
                        && (conceptRef.PropertyName == propertyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptRef> GetRichEntityByConceptIdPropertyNameAsync(
            int? conceptId,
            string propertyName)
        {
            return (await FindAsync(
                    conceptRef =>
                        (conceptRef.ConceptId == conceptId)
                        && (conceptRef.PropertyName == propertyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
