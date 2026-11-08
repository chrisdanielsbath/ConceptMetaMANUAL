/****************************
 * QualifierRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.Qualifier" /> entity
    /// </summary>
    public partial class QualifierRepository
        : ConceptMetaDbRepository<DbEntities.Qualifier>,
        IQualifierRepository
    {

        #region Constructors
        public QualifierRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified qualifier
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.Qualifier qualifier)
        {
            return new object[] { qualifier.QualifierId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the qualifier with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Qualifier, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.QualifierId == (int)keyValues[0]) && (e.QualifierId != default && e.QualifierId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified qualifier
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Qualifier, bool>> GetPrimaryKeyPredicate(DbEntities.Qualifier qualifier)
        {
            return (e => 
                (e.QualifierId == qualifier.QualifierId) && (e.QualifierId != default && e.QualifierId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified qualifier
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Qualifier, bool>> GetLogicalKeyPredicate(DbEntities.Qualifier qualifier)
        {
            return (e => 
                (e.ConceptId == qualifier.ConceptId) && 
                (e.ItemValue == qualifier.ItemValue));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified qualifier
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.Qualifier qualifier)
        {
            return new object[] { qualifier.ModelName, qualifier.ConceptName, qualifier.ItemValue };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the qualifier with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Qualifier, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.ItemValue == (string)keyValues[2]) && (e.ItemValue != default && e.ItemValue != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.Qualifier from,
            DbEntities.Qualifier to)
        {
            to.ConceptId = from.ConceptId;
            to.ItemValue = from.ItemValue;
            to.SeqNo = from.SeqNo;
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
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.Qualifier qualifier)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="qualifier"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.Qualifier qualifier,
            out DbEntities.Qualifier sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.Qualifier e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.QualifierId == default || e.QualifierId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int qualifierId = GetQualifierIdByConceptIdItemValue(
                    e.ConceptId,
                    e.ItemValue);

                // test whether the item has been found within the database
                if (qualifierId != default && qualifierId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.QualifierId = qualifierId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.Qualifier e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.QualifierId == default || e.QualifierId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int qualifierId = await GetQualifierIdByConceptIdItemValueAsync(
                    e.ConceptId,
                    e.ItemValue);

                // test whether the item has been found within the database
                if (qualifierId != default && qualifierId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.QualifierId = qualifierId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.Qualifier> items)
        {
            foreach (DbEntities.Qualifier item in items)
            {
                // populate foreign key fields
                if (item.Concept != null)
                {
                    if (item.Concept.ConceptId != default && item.Concept.ConceptId != default(int))
                    {
                        item.ConceptId = item.Concept.ConceptId;
                    }
                }
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.Qualifier> items)
        {
            foreach (DbEntities.Qualifier item in items)
            {
                // populate foreign key fields within child objects (if any)
            }
        }

        /// <summary>
        /// Gets a function that maps a qualifier to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Qualifier, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.ItemValue != null ? e.ItemValue.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Qualifier, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.QualifierId == default || e.QualifierId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.Qualifier fromEntity,
            IEnumerable<DbEntities.Qualifier> toObjects)
        {
            foreach (DbEntities.Qualifier obj in toObjects)
            {
                // populate the primary key within the object
                obj.QualifierId = fromEntity.QualifierId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public int GetQualifierIdByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (Find(
                    qualifier =>
                        (qualifier.Concept.ConceptModel.ModelName == modelName)
                        && (qualifier.Concept.ConceptName == conceptName)
                        && (qualifier.ItemValue == itemValue)))
                .Select(qualifier => qualifier.QualifierId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<int> GetQualifierIdByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (await FindAsync(
                    qualifier =>
                        (qualifier.Concept.ConceptModel.ModelName == modelName)
                        && (qualifier.Concept.ConceptName == conceptName)
                        && (qualifier.ItemValue == itemValue)))
                .Select(qualifier => qualifier.QualifierId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public int GetQualifierIdByConceptIdItemValue(
            int conceptId,
            string itemValue)
        {
            return (Find(
                    qualifier =>
                        (qualifier.ConceptId == conceptId)
                        && (qualifier.ItemValue == itemValue)))
                .Select(qualifier => qualifier.QualifierId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<int> GetQualifierIdByConceptIdItemValueAsync(
            int conceptId,
            string itemValue)
        {
            return (await FindAsync(
                    qualifier =>
                        (qualifier.ConceptId == conceptId)
                        && (qualifier.ItemValue == itemValue)))
                .Select(qualifier => qualifier.QualifierId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        public DbEntities.Qualifier GetByQualifierId(int? qualifierId)
        {
            return (Find (
                    qualifier =>
                        (qualifier.QualifierId == qualifierId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Qualifier> GetByQualifierIdAsync(int? qualifierId)
        {
            return (await FindAsync (
                    qualifier =>
                        (qualifier.QualifierId == qualifierId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        public DbEntities.Qualifier GetRichEntityByQualifierId(int? qualifierId)
        {
            return (Find(
                    qualifier =>
                        (qualifier.QualifierId == qualifierId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Qualifier> GetRichEntityByQualifierIdAsync(int? qualifierId)
        {
            return (await FindAsync(
                    qualifier =>
                        (qualifier.QualifierId == qualifierId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Qualifier GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (Find (
                    qualifier =>
                        (qualifier.Concept.ConceptModel.ModelName == modelName)
                        && (qualifier.Concept.ConceptName == conceptName)
                        && (qualifier.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Qualifier> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (await FindAsync (
                    qualifier =>
                        (qualifier.Concept.ConceptModel.ModelName == modelName)
                        && (qualifier.Concept.ConceptName == conceptName)
                        && (qualifier.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Qualifier GetRichEntityByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (Find(
                    qualifier =>
                        (qualifier.Concept.ConceptModel.ModelName == modelName)
                        && (qualifier.Concept.ConceptName == conceptName)
                        && (qualifier.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Qualifier> GetRichEntityByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (await FindAsync(
                    qualifier =>
                        (qualifier.Concept.ConceptModel.ModelName == modelName)
                        && (qualifier.Concept.ConceptName == conceptName)
                        && (qualifier.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Qualifier GetByConceptIdItemValue(
            int? conceptId,
            string itemValue)
        {
            return (Find (
                    qualifier =>
                        (qualifier.ConceptId == conceptId)
                        && (qualifier.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Qualifier> GetByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue)
        {
            return (await FindAsync (
                    qualifier =>
                        (qualifier.ConceptId == conceptId)
                        && (qualifier.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Qualifier GetRichEntityByConceptIdItemValue(
            int? conceptId,
            string itemValue)
        {
            return (Find(
                    qualifier =>
                        (qualifier.ConceptId == conceptId)
                        && (qualifier.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Qualifier> GetRichEntityByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue)
        {
            return (await FindAsync(
                    qualifier =>
                        (qualifier.ConceptId == conceptId)
                        && (qualifier.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
