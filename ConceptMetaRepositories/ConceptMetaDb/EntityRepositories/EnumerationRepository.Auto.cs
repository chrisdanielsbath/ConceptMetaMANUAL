/****************************
 * EnumerationRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.Enumeration" /> entity
    /// </summary>
    public partial class EnumerationRepository
        : ConceptMetaDbRepository<DbEntities.Enumeration>,
        IEnumerationRepository
    {

        #region Instance Properties
        protected IEnumerationMemberRepository EnumerationMemberRepository => DbUnitOfWork.EnumerationMembers;

        #endregion

        #region Constructors
        public EnumerationRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified enumeration
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.Enumeration enumeration)
        {
            return new object[] { enumeration.EnumerationId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the enumeration with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Enumeration, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.EnumerationId == (int)keyValues[0]) && (e.EnumerationId != default && e.EnumerationId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified enumeration
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Enumeration, bool>> GetPrimaryKeyPredicate(DbEntities.Enumeration enumeration)
        {
            return (e => 
                (e.EnumerationId == enumeration.EnumerationId) && (e.EnumerationId != default && e.EnumerationId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified enumeration
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Enumeration, bool>> GetLogicalKeyPredicate(DbEntities.Enumeration enumeration)
        {
            return (e => 
                (e.ConceptModelId == enumeration.ConceptModelId) && 
                (e.EnumerationName == enumeration.EnumerationName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified enumeration
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.Enumeration enumeration)
        {
            return new object[] { enumeration.ModelName, enumeration.EnumerationName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the enumeration with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.Enumeration, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.EnumerationName == (string)keyValues[1]) && (e.EnumerationName != default && e.EnumerationName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.Enumeration from,
            DbEntities.Enumeration to)
        {
            to.ConceptModelId = from.ConceptModelId;
            to.EnumerationName = from.EnumerationName;
            to.EnumerationDescription = from.EnumerationDescription;
            to.DataTypeId = from.DataTypeId;
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
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.Enumeration enumeration)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="enumeration"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.Enumeration enumeration,
            out DbEntities.Enumeration sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.Enumeration e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.EnumerationId == default || e.EnumerationId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int enumerationId = GetEnumerationIdByConceptModelIdEnumerationName(
                    e.ConceptModelId,
                    e.EnumerationName);

                // test whether the item has been found within the database
                if (enumerationId != default && enumerationId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.EnumerationId = enumerationId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.Enumeration e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.EnumerationId == default || e.EnumerationId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int enumerationId = await GetEnumerationIdByConceptModelIdEnumerationNameAsync(
                    e.ConceptModelId,
                    e.EnumerationName);

                // test whether the item has been found within the database
                if (enumerationId != default && enumerationId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.EnumerationId = enumerationId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.Enumeration> items)
        {
            foreach (DbEntities.Enumeration item in items)
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
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.Enumeration> items)
        {
            foreach (DbEntities.Enumeration item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.EnumeratedValues != null)
                {
                    foreach (DbEntities.EnumerationMember childItem in item.EnumeratedValues)
                    {
                        if (item.EnumerationId != default && item.EnumerationId != default(int))
                        {
                            childItem.EnumerationId = item.EnumerationId;
                        }
                    }
                }
                if (item.Concepts != null)
                {
                    foreach (DbEntities.Concept childItem in item.Concepts)
                    {
                        if (item.EnumerationId != default && item.EnumerationId != default(int))
                        {
                            childItem.EnumerationId = item.EnumerationId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a enumeration to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Enumeration, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptModelId.ToString() + "|"
                + (e.EnumerationName != null ? e.EnumerationName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.Enumeration, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.EnumerationId == default || e.EnumerationId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.Enumeration fromEntity,
            IEnumerable<DbEntities.Enumeration> toObjects)
        {
            foreach (DbEntities.Enumeration obj in toObjects)
            {
                // populate the primary key within the object
                obj.EnumerationId = fromEntity.EnumerationId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public int GetEnumerationIdByModelNameEnumerationName(
            string modelName,
            string enumerationName)
        {
            return (Find(
                    enumeration =>
                        (enumeration.ConceptModel.ModelName == modelName)
                        && (enumeration.EnumerationName == enumerationName)))
                .Select(enumeration => enumeration.EnumerationId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<int> GetEnumerationIdByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName)
        {
            return (await FindAsync(
                    enumeration =>
                        (enumeration.ConceptModel.ModelName == modelName)
                        && (enumeration.EnumerationName == enumerationName)))
                .Select(enumeration => enumeration.EnumerationId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public int GetEnumerationIdByConceptModelIdEnumerationName(
            int conceptModelId,
            string enumerationName)
        {
            return (Find(
                    enumeration =>
                        (enumeration.ConceptModelId == conceptModelId)
                        && (enumeration.EnumerationName == enumerationName)))
                .Select(enumeration => enumeration.EnumerationId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<int> GetEnumerationIdByConceptModelIdEnumerationNameAsync(
            int conceptModelId,
            string enumerationName)
        {
            return (await FindAsync(
                    enumeration =>
                        (enumeration.ConceptModelId == conceptModelId)
                        && (enumeration.EnumerationName == enumerationName)))
                .Select(enumeration => enumeration.EnumerationId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        public DbEntities.Enumeration GetByEnumerationId(int? enumerationId)
        {
            return (Find (
                    enumeration =>
                        (enumeration.EnumerationId == enumerationId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Enumeration> GetByEnumerationIdAsync(int? enumerationId)
        {
            return (await FindAsync (
                    enumeration =>
                        (enumeration.EnumerationId == enumerationId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        public DbEntities.Enumeration GetRichEntityByEnumerationId(int? enumerationId)
        {
            return (Find(
                    enumeration =>
                        (enumeration.EnumerationId == enumerationId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        public async Task<DbEntities.Enumeration> GetRichEntityByEnumerationIdAsync(int? enumerationId)
        {
            return (await FindAsync(
                    enumeration =>
                        (enumeration.EnumerationId == enumerationId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public DbEntities.Enumeration GetByModelNameEnumerationName(
            string modelName,
            string enumerationName)
        {
            return (Find (
                    enumeration =>
                        (enumeration.ConceptModel.ModelName == modelName)
                        && (enumeration.EnumerationName == enumerationName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Enumeration> GetByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName)
        {
            return (await FindAsync (
                    enumeration =>
                        (enumeration.ConceptModel.ModelName == modelName)
                        && (enumeration.EnumerationName == enumerationName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public DbEntities.Enumeration GetRichEntityByModelNameEnumerationName(
            string modelName,
            string enumerationName)
        {
            return (Find(
                    enumeration =>
                        (enumeration.ConceptModel.ModelName == modelName)
                        && (enumeration.EnumerationName == enumerationName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Enumeration> GetRichEntityByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName)
        {
            return (await FindAsync(
                    enumeration =>
                        (enumeration.ConceptModel.ModelName == modelName)
                        && (enumeration.EnumerationName == enumerationName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public DbEntities.Enumeration GetByConceptModelIdEnumerationName(
            int? conceptModelId,
            string enumerationName)
        {
            return (Find (
                    enumeration =>
                        (enumeration.ConceptModelId == conceptModelId)
                        && (enumeration.EnumerationName == enumerationName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Enumeration> GetByConceptModelIdEnumerationNameAsync(
            int? conceptModelId,
            string enumerationName)
        {
            return (await FindAsync (
                    enumeration =>
                        (enumeration.ConceptModelId == conceptModelId)
                        && (enumeration.EnumerationName == enumerationName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public DbEntities.Enumeration GetRichEntityByConceptModelIdEnumerationName(
            int? conceptModelId,
            string enumerationName)
        {
            return (Find(
                    enumeration =>
                        (enumeration.ConceptModelId == conceptModelId)
                        && (enumeration.EnumerationName == enumerationName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<DbEntities.Enumeration> GetRichEntityByConceptModelIdEnumerationNameAsync(
            int? conceptModelId,
            string enumerationName)
        {
            return (await FindAsync(
                    enumeration =>
                        (enumeration.ConceptModelId == conceptModelId)
                        && (enumeration.EnumerationName == enumerationName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
