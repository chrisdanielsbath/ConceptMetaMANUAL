/****************************
 * ConceptUniqueKeyPropertyFamilyRefRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRefRepository
        : ConceptMetaDbRepository<DbEntities.ConceptUniqueKeyPropertyFamilyRef>,
        IConceptUniqueKeyPropertyFamilyRefRepository
    {

        #region Constructors
        public ConceptUniqueKeyPropertyFamilyRefRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptUniqueKeyPropertyFamilyRef
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return new object[] { conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptUniqueKeyPropertyFamilyRef with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKeyPropertyFamilyRef, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptUniqueKeyPropertyFamilyRefId == (int)keyValues[0]) && (e.ConceptUniqueKeyPropertyFamilyRefId != default && e.ConceptUniqueKeyPropertyFamilyRefId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptUniqueKeyPropertyFamilyRef
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKeyPropertyFamilyRef, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return (e => 
                (e.ConceptUniqueKeyPropertyFamilyRefId == conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId) && (e.ConceptUniqueKeyPropertyFamilyRefId != default && e.ConceptUniqueKeyPropertyFamilyRefId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptUniqueKeyPropertyFamilyRef
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKeyPropertyFamilyRef, bool>> GetLogicalKeyPredicate(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return (e => 
                (e.ConceptUniqueKeyId == conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId) && 
                (e.ConceptPropertyFamilyId == conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptUniqueKeyPropertyFamilyRef
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return new object[] { conceptUniqueKeyPropertyFamilyRef.ModelName, conceptUniqueKeyPropertyFamilyRef.ConceptName, conceptUniqueKeyPropertyFamilyRef.UniqueKeyName, conceptUniqueKeyPropertyFamilyRef.PropertyFamilyName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptUniqueKeyPropertyFamilyRef with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptUniqueKeyPropertyFamilyRef, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.UniqueKeyName == (string)keyValues[2]) && (e.UniqueKeyName != default && e.UniqueKeyName != "") && 
                (e.PropertyFamilyName == (string)keyValues[3]) && (e.PropertyFamilyName != default && e.PropertyFamilyName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptUniqueKeyPropertyFamilyRef from,
            DbEntities.ConceptUniqueKeyPropertyFamilyRef to)
        {
            to.ConceptUniqueKeyId = from.ConceptUniqueKeyId;
            to.ConceptPropertyFamilyId = from.ConceptPropertyFamilyId;
            to.SeqNo = from.SeqNo;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
            RichEntityIncludes.Add("ConceptUniqueKey");
            RichEntityIncludes.Add("ConceptPropertyFamily");
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef,
            out DbEntities.ConceptUniqueKeyPropertyFamilyRef sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptUniqueKeyPropertyFamilyRef e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptUniqueKeyPropertyFamilyRefId == default || e.ConceptUniqueKeyPropertyFamilyRefId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptUniqueKeyPropertyFamilyRefId = GetConceptUniqueKeyPropertyFamilyRefIdByConceptUniqueKeyIdConceptPropertyFamilyId(
                    e.ConceptUniqueKeyId,
                    e.ConceptPropertyFamilyId);

                // test whether the item has been found within the database
                if (conceptUniqueKeyPropertyFamilyRefId != default && conceptUniqueKeyPropertyFamilyRefId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptUniqueKeyPropertyFamilyRefId = conceptUniqueKeyPropertyFamilyRefId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptUniqueKeyPropertyFamilyRef e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptUniqueKeyPropertyFamilyRefId == default || e.ConceptUniqueKeyPropertyFamilyRefId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptUniqueKeyPropertyFamilyRefId = await GetConceptUniqueKeyPropertyFamilyRefIdByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
                    e.ConceptUniqueKeyId,
                    e.ConceptPropertyFamilyId);

                // test whether the item has been found within the database
                if (conceptUniqueKeyPropertyFamilyRefId != default && conceptUniqueKeyPropertyFamilyRefId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptUniqueKeyPropertyFamilyRefId = conceptUniqueKeyPropertyFamilyRefId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> items)
        {
            foreach (DbEntities.ConceptUniqueKeyPropertyFamilyRef item in items)
            {
                // populate foreign key fields
                if (item.ConceptUniqueKey != null)
                {
                    if (item.ConceptUniqueKey.ConceptUniqueKeyId != default && item.ConceptUniqueKey.ConceptUniqueKeyId != default(int))
                    {
                        item.ConceptUniqueKeyId = item.ConceptUniqueKey.ConceptUniqueKeyId;
                    }
                }
                if (item.ConceptPropertyFamily != null)
                {
                    if (item.ConceptPropertyFamily.ConceptPropertyFamilyId != default && item.ConceptPropertyFamily.ConceptPropertyFamilyId != default(int))
                    {
                        item.ConceptPropertyFamilyId = item.ConceptPropertyFamily.ConceptPropertyFamilyId;
                    }
                }
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> items)
        {
            foreach (DbEntities.ConceptUniqueKeyPropertyFamilyRef item in items)
            {
                // populate foreign key fields within child objects (if any)
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptUniqueKeyPropertyFamilyRef to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptUniqueKeyPropertyFamilyRef, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptUniqueKeyId.ToString() + "|"
                + e.ConceptPropertyFamilyId.ToString() + "|"
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptUniqueKeyPropertyFamilyRef, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptUniqueKeyPropertyFamilyRefId == default || e.ConceptUniqueKeyPropertyFamilyRefId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptUniqueKeyPropertyFamilyRef fromEntity,
            IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> toObjects)
        {
            foreach (DbEntities.ConceptUniqueKeyPropertyFamilyRef obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptUniqueKeyPropertyFamilyRefId = fromEntity.ConceptUniqueKeyPropertyFamilyRefId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public int GetConceptUniqueKeyPropertyFamilyRefIdByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            return (Find(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.UniqueKeyName == uniqueKeyName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptUniqueKeyPropertyFamilyRefIdByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.UniqueKeyName == uniqueKeyName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public int GetConceptUniqueKeyPropertyFamilyRefIdByConceptUniqueKeyIdConceptPropertyFamilyId(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId)
        {
            return (Find(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == conceptUniqueKeyId)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .Select(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<int> GetConceptUniqueKeyPropertyFamilyRefIdByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId)
        {
            return (await FindAsync(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == conceptUniqueKeyId)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .Select(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyPropertyFamilyRefId(int? conceptUniqueKeyPropertyFamilyRefId)
        {
            return (Find (
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId == conceptUniqueKeyPropertyFamilyRefId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyPropertyFamilyRefIdAsync(int? conceptUniqueKeyPropertyFamilyRefId)
        {
            return (await FindAsync (
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId == conceptUniqueKeyPropertyFamilyRefId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKeyPropertyFamilyRef GetRichEntityByConceptUniqueKeyPropertyFamilyRefId(int? conceptUniqueKeyPropertyFamilyRefId)
        {
            return (Find(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId == conceptUniqueKeyPropertyFamilyRefId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetRichEntityByConceptUniqueKeyPropertyFamilyRefIdAsync(int? conceptUniqueKeyPropertyFamilyRefId)
        {
            return (await FindAsync(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId == conceptUniqueKeyPropertyFamilyRefId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKeyPropertyFamilyRef GetByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            return (Find (
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.UniqueKeyName == uniqueKeyName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            return (await FindAsync (
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.UniqueKeyName == uniqueKeyName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKeyPropertyFamilyRef GetRichEntityByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            return (Find(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.UniqueKeyName == uniqueKeyName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetRichEntityByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptModel.ModelName == modelName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.Concept.ConceptName == conceptName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKey.UniqueKeyName == uniqueKeyName)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyIdConceptPropertyFamilyId(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId)
        {
            return (Find (
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == conceptUniqueKeyId)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId)
        {
            return (await FindAsync (
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == conceptUniqueKeyId)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptUniqueKeyPropertyFamilyRef GetRichEntityByConceptUniqueKeyIdConceptPropertyFamilyId(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId)
        {
            return (Find(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == conceptUniqueKeyId)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetRichEntityByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId)
        {
            return (await FindAsync(
                    conceptUniqueKeyPropertyFamilyRef =>
                        (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId == conceptUniqueKeyId)
                        && (conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
