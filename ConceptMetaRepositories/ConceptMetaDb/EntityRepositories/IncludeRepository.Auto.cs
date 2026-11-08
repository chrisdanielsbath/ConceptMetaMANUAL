/****************************
 * IncludeRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.Include" /> entity
    /// </summary>
    public partial class IncludeRepository
        : ConceptMetaDbRepository<DbEntities.Include>,
        IIncludeRepository
    {

        #region Constructors
        public IncludeRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified include
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.Include include)
        {
            return new object[] { include.IncludeId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the include with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Include, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.IncludeId == (int)keyValues[0]) && (e.IncludeId != default && e.IncludeId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified include
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Include, bool>> GetPrimaryKeyPredicate(DbEntities.Include include)
        {
            return (e => 
                (e.IncludeId == include.IncludeId) && (e.IncludeId != default && e.IncludeId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified include
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Include, bool>> GetLogicalKeyPredicate(DbEntities.Include include)
        {
            return (e => 
                (e.ConceptId == include.ConceptId) && 
                (e.ItemValue == include.ItemValue));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified include
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.Include include)
        {
            return new object[] { include.ModelName, include.ConceptName, include.ItemValue };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the include with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Include, bool>> GetBusinessKeyPredicate(params object[] keyValues)
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
            DbEntities.Include from,
            DbEntities.Include to)
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
        /// <param name="include"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.Include include)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="include"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.Include include,
            out DbEntities.Include sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.Include e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.IncludeId == default || e.IncludeId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int includeId = GetIncludeIdByConceptIdItemValue(
                    e.ConceptId,
                    e.ItemValue);

                // test whether the item has been found within the database
                if (includeId != default && includeId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.IncludeId = includeId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.Include e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.IncludeId == default || e.IncludeId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int includeId = await GetIncludeIdByConceptIdItemValueAsync(
                    e.ConceptId,
                    e.ItemValue);

                // test whether the item has been found within the database
                if (includeId != default && includeId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.IncludeId = includeId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.Include> items)
        {
            foreach (DbEntities.Include item in items)
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
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.Include> items)
        {
            foreach (DbEntities.Include item in items)
            {
                // populate foreign key fields within child objects (if any)
            }
        }

        /// <summary>
        /// Gets a function that maps a include to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Include, string> GetLogicalKeyFunction()
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
        public override Func<DbEntities.Include, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.IncludeId == default || e.IncludeId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.Include fromEntity,
            IEnumerable<DbEntities.Include> toObjects)
        {
            foreach (DbEntities.Include obj in toObjects)
            {
                // populate the primary key within the object
                obj.IncludeId = fromEntity.IncludeId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public int GetIncludeIdByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (Find(
                    include =>
                        (include.Concept.ConceptModel.ModelName == modelName)
                        && (include.Concept.ConceptName == conceptName)
                        && (include.ItemValue == itemValue)))
                .Select(include => include.IncludeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<int> GetIncludeIdByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (await FindAsync(
                    include =>
                        (include.Concept.ConceptModel.ModelName == modelName)
                        && (include.Concept.ConceptName == conceptName)
                        && (include.ItemValue == itemValue)))
                .Select(include => include.IncludeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public int GetIncludeIdByConceptIdItemValue(
            int conceptId,
            string itemValue)
        {
            return (Find(
                    include =>
                        (include.ConceptId == conceptId)
                        && (include.ItemValue == itemValue)))
                .Select(include => include.IncludeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<int> GetIncludeIdByConceptIdItemValueAsync(
            int conceptId,
            string itemValue)
        {
            return (await FindAsync(
                    include =>
                        (include.ConceptId == conceptId)
                        && (include.ItemValue == itemValue)))
                .Select(include => include.IncludeId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        public DbEntities.Include GetByIncludeId(int? includeId)
        {
            return (Find (
                    include =>
                        (include.IncludeId == includeId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Include> GetByIncludeIdAsync(int? includeId)
        {
            return (await FindAsync (
                    include =>
                        (include.IncludeId == includeId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        public DbEntities.Include GetRichEntityByIncludeId(int? includeId)
        {
            return (Find(
                    include =>
                        (include.IncludeId == includeId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Include> GetRichEntityByIncludeIdAsync(int? includeId)
        {
            return (await FindAsync(
                    include =>
                        (include.IncludeId == includeId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Include GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (Find (
                    include =>
                        (include.Concept.ConceptModel.ModelName == modelName)
                        && (include.Concept.ConceptName == conceptName)
                        && (include.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Include> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (await FindAsync (
                    include =>
                        (include.Concept.ConceptModel.ModelName == modelName)
                        && (include.Concept.ConceptName == conceptName)
                        && (include.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Include GetRichEntityByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (Find(
                    include =>
                        (include.Concept.ConceptModel.ModelName == modelName)
                        && (include.Concept.ConceptName == conceptName)
                        && (include.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Include> GetRichEntityByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            return (await FindAsync(
                    include =>
                        (include.Concept.ConceptModel.ModelName == modelName)
                        && (include.Concept.ConceptName == conceptName)
                        && (include.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Include GetByConceptIdItemValue(
            int? conceptId,
            string itemValue)
        {
            return (Find (
                    include =>
                        (include.ConceptId == conceptId)
                        && (include.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Include> GetByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue)
        {
            return (await FindAsync (
                    include =>
                        (include.ConceptId == conceptId)
                        && (include.ItemValue == itemValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public DbEntities.Include GetRichEntityByConceptIdItemValue(
            int? conceptId,
            string itemValue)
        {
            return (Find(
                    include =>
                        (include.ConceptId == conceptId)
                        && (include.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.Include> GetRichEntityByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue)
        {
            return (await FindAsync(
                    include =>
                        (include.ConceptId == conceptId)
                        && (include.ItemValue == itemValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
