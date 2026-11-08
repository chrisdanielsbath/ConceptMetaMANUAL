/****************************
 * ConceptSubTypeRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.ConceptSubType" /> entity
    /// </summary>
    public partial class ConceptSubTypeRepository
        : ConceptMetaDbRepository<DbEntities.ConceptSubType>,
        IConceptSubTypeRepository
    {

        #region Instance Properties
        protected IConceptSubTypePropertyFamilyRefRepository ConceptSubTypePropertyFamilyRefRepository => DbUnitOfWork.ConceptSubTypePropertyFamilyRefs;

        #endregion

        #region Constructors
        public ConceptSubTypeRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptSubType
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptSubType conceptSubType)
        {
            return new object[] { conceptSubType.ConceptSubTypeId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptSubType with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubType, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptSubTypeId == (int)keyValues[0]) && (e.ConceptSubTypeId != default && e.ConceptSubTypeId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptSubType
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubType, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptSubType conceptSubType)
        {
            return (e => 
                (e.ConceptSubTypeId == conceptSubType.ConceptSubTypeId) && (e.ConceptSubTypeId != default && e.ConceptSubTypeId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptSubType
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubType, bool>> GetLogicalKeyPredicate(DbEntities.ConceptSubType conceptSubType)
        {
            return (e => 
                (e.ConceptId == conceptSubType.ConceptId) && 
                (e.SubTypeName == conceptSubType.SubTypeName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptSubType
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptSubType conceptSubType)
        {
            return new object[] { conceptSubType.ModelName, conceptSubType.ConceptName, conceptSubType.SubTypeName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptSubType with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptSubType, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.SubTypeName == (string)keyValues[2]) && (e.SubTypeName != default && e.SubTypeName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptSubType from,
            DbEntities.ConceptSubType to)
        {
            to.ConceptId = from.ConceptId;
            to.SubTypeName = from.SubTypeName;
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
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptSubType conceptSubType)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptSubType conceptSubType,
            out DbEntities.ConceptSubType sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptSubType e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptSubTypeId == default || e.ConceptSubTypeId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptSubTypeId = GetConceptSubTypeIdByConceptIdSubTypeName(
                    e.ConceptId,
                    e.SubTypeName);

                // test whether the item has been found within the database
                if (conceptSubTypeId != default && conceptSubTypeId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptSubTypeId = conceptSubTypeId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptSubType e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptSubTypeId == default || e.ConceptSubTypeId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptSubTypeId = await GetConceptSubTypeIdByConceptIdSubTypeNameAsync(
                    e.ConceptId,
                    e.SubTypeName);

                // test whether the item has been found within the database
                if (conceptSubTypeId != default && conceptSubTypeId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptSubTypeId = conceptSubTypeId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptSubType> items)
        {
            foreach (DbEntities.ConceptSubType item in items)
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
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptSubType> items)
        {
            foreach (DbEntities.ConceptSubType item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.PropertyFamilyRefs != null)
                {
                    foreach (DbEntities.ConceptSubTypePropertyFamilyRef childItem in item.PropertyFamilyRefs)
                    {
                        if (item.ConceptSubTypeId != default && item.ConceptSubTypeId != default(int))
                        {
                            childItem.ConceptSubTypeId = item.ConceptSubTypeId;
                        }
                    }
                }
                if (item.SubTypeRefs != null)
                {
                    foreach (DbEntities.Concept childItem in item.SubTypeRefs)
                    {
                        if (item.ConceptSubTypeId != default && item.ConceptSubTypeId != default(int))
                        {
                            childItem.SpecialisedConceptSubTypeId = item.ConceptSubTypeId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptSubType to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptSubType, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.SubTypeName != null ? e.SubTypeName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptSubType, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptSubTypeId == default || e.ConceptSubTypeId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptSubType fromEntity,
            IEnumerable<DbEntities.ConceptSubType> toObjects)
        {
            foreach (DbEntities.ConceptSubType obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptSubTypeId = fromEntity.ConceptSubTypeId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public int GetConceptSubTypeIdByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            return (Find(
                    conceptSubType =>
                        (conceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .Select(conceptSubType => conceptSubType.ConceptSubTypeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptSubTypeIdByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            return (await FindAsync(
                    conceptSubType =>
                        (conceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .Select(conceptSubType => conceptSubType.ConceptSubTypeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public int GetConceptSubTypeIdByConceptIdSubTypeName(
            int conceptId,
            string subTypeName)
        {
            return (Find(
                    conceptSubType =>
                        (conceptSubType.ConceptId == conceptId)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .Select(conceptSubType => conceptSubType.ConceptSubTypeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptSubTypeIdByConceptIdSubTypeNameAsync(
            int conceptId,
            string subTypeName)
        {
            return (await FindAsync(
                    conceptSubType =>
                        (conceptSubType.ConceptId == conceptId)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .Select(conceptSubType => conceptSubType.ConceptSubTypeId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubType GetByConceptSubTypeId(int? conceptSubTypeId)
        {
            return (Find (
                    conceptSubType =>
                        (conceptSubType.ConceptSubTypeId == conceptSubTypeId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubType> GetByConceptSubTypeIdAsync(int? conceptSubTypeId)
        {
            return (await FindAsync (
                    conceptSubType =>
                        (conceptSubType.ConceptSubTypeId == conceptSubTypeId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubType GetRichEntityByConceptSubTypeId(int? conceptSubTypeId)
        {
            return (Find(
                    conceptSubType =>
                        (conceptSubType.ConceptSubTypeId == conceptSubTypeId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubType> GetRichEntityByConceptSubTypeIdAsync(int? conceptSubTypeId)
        {
            return (await FindAsync(
                    conceptSubType =>
                        (conceptSubType.ConceptSubTypeId == conceptSubTypeId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubType GetByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            return (Find (
                    conceptSubType =>
                        (conceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubType> GetByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            return (await FindAsync (
                    conceptSubType =>
                        (conceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubType GetRichEntityByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            return (Find(
                    conceptSubType =>
                        (conceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubType.SubTypeName == subTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubType> GetRichEntityByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            return (await FindAsync(
                    conceptSubType =>
                        (conceptSubType.Concept.ConceptModel.ModelName == modelName)
                        && (conceptSubType.Concept.ConceptName == conceptName)
                        && (conceptSubType.SubTypeName == subTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubType GetByConceptIdSubTypeName(
            int? conceptId,
            string subTypeName)
        {
            return (Find (
                    conceptSubType =>
                        (conceptSubType.ConceptId == conceptId)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubType> GetByConceptIdSubTypeNameAsync(
            int? conceptId,
            string subTypeName)
        {
            return (await FindAsync (
                    conceptSubType =>
                        (conceptSubType.ConceptId == conceptId)
                        && (conceptSubType.SubTypeName == subTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public DbEntities.ConceptSubType GetRichEntityByConceptIdSubTypeName(
            int? conceptId,
            string subTypeName)
        {
            return (Find(
                    conceptSubType =>
                        (conceptSubType.ConceptId == conceptId)
                        && (conceptSubType.SubTypeName == subTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptSubType> GetRichEntityByConceptIdSubTypeNameAsync(
            int? conceptId,
            string subTypeName)
        {
            return (await FindAsync(
                    conceptSubType =>
                        (conceptSubType.ConceptId == conceptId)
                        && (conceptSubType.SubTypeName == subTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
