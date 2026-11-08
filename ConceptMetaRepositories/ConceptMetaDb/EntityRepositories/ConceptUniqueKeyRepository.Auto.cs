/****************************
 * ConceptUniqueKeyRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.ConceptUniqueKey" /> entity
    /// </summary>
    public partial class ConceptUniqueKeyRepository
        : ConceptMetaDbRepository<DbEntities.ConceptUniqueKey>,
        IConceptUniqueKeyRepository
    {

        #region Instance Properties
        protected IConceptUniqueKeyPropertyFamilyRefRepository ConceptUniqueKeyPropertyFamilyRefRepository => DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs;

        #endregion

        #region Constructors
        public ConceptUniqueKeyRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptUniqueKey
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return new object[] { conceptUniqueKey.ConceptUniqueKeyId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptUniqueKey with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKey, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptUniqueKeyId == (int)keyValues[0]) && (e.ConceptUniqueKeyId != default && e.ConceptUniqueKeyId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptUniqueKey
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKey, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return (e => 
                (e.ConceptUniqueKeyId == conceptUniqueKey.ConceptUniqueKeyId) && (e.ConceptUniqueKeyId != default && e.ConceptUniqueKeyId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptUniqueKey
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKey, bool>> GetLogicalKeyPredicate(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return (e => 
                (e.ConceptId == conceptUniqueKey.ConceptId) && 
                (e.UniqueKeyName == conceptUniqueKey.UniqueKeyName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptUniqueKey
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return new object[] { conceptUniqueKey.ModelName, conceptUniqueKey.ConceptName, conceptUniqueKey.UniqueKeyName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptUniqueKey with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKey, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.UniqueKeyName == (string)keyValues[2]) && (e.UniqueKeyName != default && e.UniqueKeyName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptUniqueKey from,
            DbEntities.ConceptUniqueKey to)
        {
            to.ConceptId = from.ConceptId;
            to.UniqueKeyName = from.UniqueKeyName;
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
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptUniqueKey conceptUniqueKey,
            out DbEntities.ConceptUniqueKey sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptUniqueKey e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptUniqueKeyId == default || e.ConceptUniqueKeyId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptUniqueKeyId = GetConceptUniqueKeyIdByConceptIdUniqueKeyName(
                    e.ConceptId,
                    e.UniqueKeyName);

                // test whether the item has been found within the database
                if (conceptUniqueKeyId != default && conceptUniqueKeyId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptUniqueKeyId = conceptUniqueKeyId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptUniqueKey e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptUniqueKeyId == default || e.ConceptUniqueKeyId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptUniqueKeyId = await GetConceptUniqueKeyIdByConceptIdUniqueKeyNameAsync(
                    e.ConceptId,
                    e.UniqueKeyName);

                // test whether the item has been found within the database
                if (conceptUniqueKeyId != default && conceptUniqueKeyId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptUniqueKeyId = conceptUniqueKeyId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptUniqueKey> items)
        {
            foreach (DbEntities.ConceptUniqueKey item in items)
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
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptUniqueKey> items)
        {
            foreach (DbEntities.ConceptUniqueKey item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.UniqueKeyRefs != null)
                {
                    foreach (DbEntities.Concept childItem in item.UniqueKeyRefs)
                    {
                        if (item.ConceptUniqueKeyId != default && item.ConceptUniqueKeyId != default(int))
                        {
                            childItem.ReferencedConceptUniqueKeyId = item.ConceptUniqueKeyId;
                        }
                    }
                }
                if (item.PropertyFamilyRefs != null)
                {
                    foreach (DbEntities.ConceptUniqueKeyPropertyFamilyRef childItem in item.PropertyFamilyRefs)
                    {
                        if (item.ConceptUniqueKeyId != default && item.ConceptUniqueKeyId != default(int))
                        {
                            childItem.ConceptUniqueKeyId = item.ConceptUniqueKeyId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptUniqueKey to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptUniqueKey, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.UniqueKeyName != null ? e.UniqueKeyName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptUniqueKey, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptUniqueKeyId == default || e.ConceptUniqueKeyId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptUniqueKey fromEntity,
            IEnumerable<DbEntities.ConceptUniqueKey> toObjects)
        {
            foreach (DbEntities.ConceptUniqueKey obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptUniqueKeyId = fromEntity.ConceptUniqueKeyId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public int GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            return (Find(
                    conceptUniqueKey =>
                        (conceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .Select(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            return (await FindAsync(
                    conceptUniqueKey =>
                        (conceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .Select(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public int GetConceptUniqueKeyIdByConceptIdUniqueKeyName(
            int conceptId,
            string uniqueKeyName)
        {
            return (Find(
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptId == conceptId)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .Select(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptUniqueKeyIdByConceptIdUniqueKeyNameAsync(
            int conceptId,
            string uniqueKeyName)
        {
            return (await FindAsync(
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptId == conceptId)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .Select(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKey GetByConceptUniqueKeyId(int? conceptUniqueKeyId)
        {
            return (Find (
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptUniqueKeyId == conceptUniqueKeyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKey> GetByConceptUniqueKeyIdAsync(int? conceptUniqueKeyId)
        {
            return (await FindAsync (
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptUniqueKeyId == conceptUniqueKeyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKey GetRichEntityByConceptUniqueKeyId(int? conceptUniqueKeyId)
        {
            return (Find(
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptUniqueKeyId == conceptUniqueKeyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKey> GetRichEntityByConceptUniqueKeyIdAsync(int? conceptUniqueKeyId)
        {
            return (await FindAsync(
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptUniqueKeyId == conceptUniqueKeyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKey GetByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            return (Find (
                    conceptUniqueKey =>
                        (conceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKey> GetByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            return (await FindAsync (
                    conceptUniqueKey =>
                        (conceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKey GetRichEntityByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            return (Find(
                    conceptUniqueKey =>
                        (conceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKey> GetRichEntityByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            return (await FindAsync(
                    conceptUniqueKey =>
                        (conceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKey GetByConceptIdUniqueKeyName(
            int? conceptId,
            string uniqueKeyName)
        {
            return (Find (
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptId == conceptId)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKey> GetByConceptIdUniqueKeyNameAsync(
            int? conceptId,
            string uniqueKeyName)
        {
            return (await FindAsync (
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptId == conceptId)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKey GetRichEntityByConceptIdUniqueKeyName(
            int? conceptId,
            string uniqueKeyName)
        {
            return (Find(
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptId == conceptId)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKey> GetRichEntityByConceptIdUniqueKeyNameAsync(
            int? conceptId,
            string uniqueKeyName)
        {
            return (await FindAsync(
                    conceptUniqueKey =>
                        (conceptUniqueKey.ConceptId == conceptId)
                        && (conceptUniqueKey.UniqueKeyName == uniqueKeyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
