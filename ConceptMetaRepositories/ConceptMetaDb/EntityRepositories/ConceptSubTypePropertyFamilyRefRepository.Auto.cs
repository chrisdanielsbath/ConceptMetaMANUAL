/****************************
 * ConceptSubTypePropertyFamilyRefRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRefRepository
        : ConceptMetaDbRepository<DbEntities.ConceptSubTypePropertyFamilyRef>,
        IConceptSubTypePropertyFamilyRefRepository
    {

        #region Constructors
        public ConceptSubTypePropertyFamilyRefRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptSubTypePropertyFamilyRef
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return new object[] { conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptSubTypePropertyFamilyRef with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubTypePropertyFamilyRef, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptSubTypePropertyFamilyRefId == (int)keyValues[0]) && (e.ConceptSubTypePropertyFamilyRefId != default && e.ConceptSubTypePropertyFamilyRefId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptSubTypePropertyFamilyRef
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubTypePropertyFamilyRef, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return (e => 
                (e.ConceptSubTypePropertyFamilyRefId == conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId) && (e.ConceptSubTypePropertyFamilyRefId != default && e.ConceptSubTypePropertyFamilyRefId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptSubTypePropertyFamilyRef
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubTypePropertyFamilyRef, bool>> GetLogicalKeyPredicate(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return (e => 
                (e.ConceptSubTypeId == conceptSubTypePropertyFamilyRef.ConceptSubTypeId) && 
                (e.ConceptPropertyFamilyId == conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptSubTypePropertyFamilyRef
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return new object[] { conceptSubTypePropertyFamilyRef.ModelName, conceptSubTypePropertyFamilyRef.ConceptName, conceptSubTypePropertyFamilyRef.SubTypeName, conceptSubTypePropertyFamilyRef.PropertyFamilyName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptSubTypePropertyFamilyRef with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubTypePropertyFamilyRef, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.SubTypeName == (string)keyValues[2]) && (e.SubTypeName != default && e.SubTypeName != "") && 
                (e.PropertyFamilyName == (string)keyValues[3]) && (e.PropertyFamilyName != default && e.PropertyFamilyName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptSubTypePropertyFamilyRef from,
            DbEntities.ConceptSubTypePropertyFamilyRef to)
        {
            to.ConceptSubTypeId = from.ConceptSubTypeId;
            to.ConceptPropertyFamilyId = from.ConceptPropertyFamilyId;
            to.SeqNo = from.SeqNo;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
            RichEntityIncludes.Add("ConceptSubType");
            RichEntityIncludes.Add("ConceptPropertyFamily");
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef,
            out DbEntities.ConceptSubTypePropertyFamilyRef sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptSubTypePropertyFamilyRef e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptSubTypePropertyFamilyRefId == default || e.ConceptSubTypePropertyFamilyRefId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptSubTypePropertyFamilyRefId = GetConceptSubTypePropertyFamilyRefIdByConceptSubTypeIdConceptPropertyFamilyId(
                    e.ConceptSubTypeId,
                    e.ConceptPropertyFamilyId);

                // test whether the item has been found within the database
                if (conceptSubTypePropertyFamilyRefId != default && conceptSubTypePropertyFamilyRefId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptSubTypePropertyFamilyRefId = conceptSubTypePropertyFamilyRefId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptSubTypePropertyFamilyRef e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptSubTypePropertyFamilyRefId == default || e.ConceptSubTypePropertyFamilyRefId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptSubTypePropertyFamilyRefId = await GetConceptSubTypePropertyFamilyRefIdByConceptSubTypeIdConceptPropertyFamilyIdAsync(
                    e.ConceptSubTypeId,
                    e.ConceptPropertyFamilyId);

                // test whether the item has been found within the database
                if (conceptSubTypePropertyFamilyRefId != default && conceptSubTypePropertyFamilyRefId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptSubTypePropertyFamilyRefId = conceptSubTypePropertyFamilyRefId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> items)
        {
            foreach (DbEntities.ConceptSubTypePropertyFamilyRef item in items)
            {
                // populate foreign key fields
                if (item.ConceptSubType != null)
                {
                    if (item.ConceptSubType.ConceptSubTypeId != default && item.ConceptSubType.ConceptSubTypeId != default(int))
                    {
                        item.ConceptSubTypeId = item.ConceptSubType.ConceptSubTypeId;
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
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> items)
        {
            foreach (DbEntities.ConceptSubTypePropertyFamilyRef item in items)
            {
                // populate foreign key fields within child objects (if any)
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptSubTypePropertyFamilyRef to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptSubTypePropertyFamilyRef, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptSubTypeId.ToString() + "|"
                + e.ConceptPropertyFamilyId.ToString() + "|"
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptSubTypePropertyFamilyRef, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptSubTypePropertyFamilyRefId == default || e.ConceptSubTypePropertyFamilyRefId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptSubTypePropertyFamilyRef fromEntity,
            IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> toObjects)
        {
            foreach (DbEntities.ConceptSubTypePropertyFamilyRef obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptSubTypePropertyFamilyRefId = fromEntity.ConceptSubTypePropertyFamilyRefId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public int GetConceptSubTypePropertyFamilyRefIdByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            return (Find(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.SubTypeName == subTypeName)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptSubTypePropertyFamilyRefIdByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.SubTypeName == subTypeName)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public int GetConceptSubTypePropertyFamilyRefIdByConceptSubTypeIdConceptPropertyFamilyId(
            int conceptSubTypeId,
            int conceptPropertyFamilyId)
        {
            return (Find(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypeId == conceptSubTypeId)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .Select(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<int> GetConceptSubTypePropertyFamilyRefIdByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int conceptSubTypeId,
            int conceptPropertyFamilyId)
        {
            return (await FindAsync(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypeId == conceptSubTypeId)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .Select(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubTypePropertyFamilyRef GetByConceptSubTypePropertyFamilyRefId(int? conceptSubTypePropertyFamilyRefId)
        {
            return (Find (
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId == conceptSubTypePropertyFamilyRefId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypePropertyFamilyRefIdAsync(int? conceptSubTypePropertyFamilyRefId)
        {
            return (await FindAsync (
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId == conceptSubTypePropertyFamilyRefId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubTypePropertyFamilyRef GetRichEntityByConceptSubTypePropertyFamilyRefId(int? conceptSubTypePropertyFamilyRefId)
        {
            return (Find(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId == conceptSubTypePropertyFamilyRefId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetRichEntityByConceptSubTypePropertyFamilyRefIdAsync(int? conceptSubTypePropertyFamilyRefId)
        {
            return (await FindAsync(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId == conceptSubTypePropertyFamilyRefId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubTypePropertyFamilyRef GetByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            return (Find (
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.SubTypeName == subTypeName)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            return (await FindAsync (
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.SubTypeName == subTypeName)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubTypePropertyFamilyRef GetRichEntityByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            return (Find(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.SubTypeName == subTypeName)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetRichEntityByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubTypePropertyFamilyRef.ConceptSubType.SubTypeName == subTypeName)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubTypePropertyFamilyRef GetByConceptSubTypeIdConceptPropertyFamilyId(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId)
        {
            return (Find (
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypeId == conceptSubTypeId)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId)
        {
            return (await FindAsync (
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypeId == conceptSubTypeId)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubTypePropertyFamilyRef GetRichEntityByConceptSubTypeIdConceptPropertyFamilyId(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId)
        {
            return (Find(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypeId == conceptSubTypeId)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetRichEntityByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId)
        {
            return (await FindAsync(
                    conceptSubTypePropertyFamilyRef =>
                        (conceptSubTypePropertyFamilyRef.ConceptSubTypeId == conceptSubTypeId)
                        && (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId == conceptPropertyFamilyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
