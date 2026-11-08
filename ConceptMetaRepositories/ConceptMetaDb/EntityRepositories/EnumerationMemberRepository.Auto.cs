/****************************
 * EnumerationMemberRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.EnumerationMember" /> entity
    /// </summary>
    public partial class EnumerationMemberRepository
        : ConceptMetaDbRepository<DbEntities.EnumerationMember>,
        IEnumerationMemberRepository
    {

        #region Constructors
        public EnumerationMemberRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified enumerationMember
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.EnumerationMember enumerationMember)
        {
            return new object[] { enumerationMember.EnumerationMemberId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the enumerationMember with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.EnumerationMember, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.EnumerationMemberId == (int)keyValues[0]) && (e.EnumerationMemberId != default && e.EnumerationMemberId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified enumerationMember
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.EnumerationMember, bool>> GetPrimaryKeyPredicate(DbEntities.EnumerationMember enumerationMember)
        {
            return (e => 
                (e.EnumerationMemberId == enumerationMember.EnumerationMemberId) && (e.EnumerationMemberId != default && e.EnumerationMemberId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified enumerationMember
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.EnumerationMember, bool>> GetLogicalKeyPredicate(DbEntities.EnumerationMember enumerationMember)
        {
            return (e => 
                (e.EnumerationId == enumerationMember.EnumerationId) && 
                (e.EnumeratedValue == enumerationMember.EnumeratedValue));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified enumerationMember
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.EnumerationMember enumerationMember)
        {
            return new object[] { enumerationMember.ModelName, enumerationMember.EnumerationName, enumerationMember.EnumeratedValue };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the enumerationMember with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.EnumerationMember, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.EnumerationName == (string)keyValues[1]) && (e.EnumerationName != default && e.EnumerationName != "") && 
                (e.EnumeratedValue == (string)keyValues[2]) && (e.EnumeratedValue != default && e.EnumeratedValue != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.EnumerationMember from,
            DbEntities.EnumerationMember to)
        {
            to.EnumerationId = from.EnumerationId;
            to.EnumeratedValue = from.EnumeratedValue;
            to.EnumeratedValueDescription = from.EnumeratedValueDescription;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
            RichEntityIncludes.Add("Enumeration");
            RichEntityIncludes.Add("Enumeration.ConceptModel");
            RichEntityIncludes.Add("Enumeration.DataType");
            RichEntityIncludes.Add("Enumeration.DataType.ConceptModel");
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.EnumerationMember enumerationMember)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.EnumerationMember enumerationMember,
            out DbEntities.EnumerationMember sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.EnumerationMember e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.EnumerationMemberId == default || e.EnumerationMemberId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int enumerationMemberId = GetEnumerationMemberIdByEnumerationIdEnumeratedValue(
                    e.EnumerationId,
                    e.EnumeratedValue);

                // test whether the item has been found within the database
                if (enumerationMemberId != default && enumerationMemberId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.EnumerationMemberId = enumerationMemberId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.EnumerationMember e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.EnumerationMemberId == default || e.EnumerationMemberId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int enumerationMemberId = await GetEnumerationMemberIdByEnumerationIdEnumeratedValueAsync(
                    e.EnumerationId,
                    e.EnumeratedValue);

                // test whether the item has been found within the database
                if (enumerationMemberId != default && enumerationMemberId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.EnumerationMemberId = enumerationMemberId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.EnumerationMember> items)
        {
            foreach (DbEntities.EnumerationMember item in items)
            {
                // populate foreign key fields
                if (item.Enumeration != null)
                {
                    if (item.Enumeration.EnumerationId != default && item.Enumeration.EnumerationId != default(int))
                    {
                        item.EnumerationId = item.Enumeration.EnumerationId;
                    }
                }
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.EnumerationMember> items)
        {
            foreach (DbEntities.EnumerationMember item in items)
            {
                // populate foreign key fields within child objects (if any)
            }
        }

        /// <summary>
        /// Gets a function that maps a enumerationMember to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.EnumerationMember, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.EnumerationId.ToString() + "|"
                + (e.EnumeratedValue != null ? e.EnumeratedValue.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.EnumerationMember, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.EnumerationMemberId == default || e.EnumerationMemberId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.EnumerationMember fromEntity,
            IEnumerable<DbEntities.EnumerationMember> toObjects)
        {
            foreach (DbEntities.EnumerationMember obj in toObjects)
            {
                // populate the primary key within the object
                obj.EnumerationMemberId = fromEntity.EnumerationMemberId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public int GetEnumerationMemberIdByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            return (Find(
                    enumerationMember =>
                        (enumerationMember.Enumeration.ConceptModel.ModelName == modelName)
                        && (enumerationMember.Enumeration.EnumerationName == enumerationName)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .Select(enumerationMember => enumerationMember.EnumerationMemberId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<int> GetEnumerationMemberIdByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            return (await FindAsync(
                    enumerationMember =>
                        (enumerationMember.Enumeration.ConceptModel.ModelName == modelName)
                        && (enumerationMember.Enumeration.EnumerationName == enumerationName)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .Select(enumerationMember => enumerationMember.EnumerationMemberId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public int GetEnumerationMemberIdByEnumerationIdEnumeratedValue(
            int enumerationId,
            string enumeratedValue)
        {
            return (Find(
                    enumerationMember =>
                        (enumerationMember.EnumerationId == enumerationId)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .Select(enumerationMember => enumerationMember.EnumerationMemberId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<int> GetEnumerationMemberIdByEnumerationIdEnumeratedValueAsync(
            int enumerationId,
            string enumeratedValue)
        {
            return (await FindAsync(
                    enumerationMember =>
                        (enumerationMember.EnumerationId == enumerationId)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .Select(enumerationMember => enumerationMember.EnumerationMemberId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        public DbEntities.EnumerationMember GetByEnumerationMemberId(int? enumerationMemberId)
        {
            return (Find (
                    enumerationMember =>
                        (enumerationMember.EnumerationMemberId == enumerationMemberId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        public async Task<DbEntities.EnumerationMember> GetByEnumerationMemberIdAsync(int? enumerationMemberId)
        {
            return (await FindAsync (
                    enumerationMember =>
                        (enumerationMember.EnumerationMemberId == enumerationMemberId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        public DbEntities.EnumerationMember GetRichEntityByEnumerationMemberId(int? enumerationMemberId)
        {
            return (Find(
                    enumerationMember =>
                        (enumerationMember.EnumerationMemberId == enumerationMemberId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        public async Task<DbEntities.EnumerationMember> GetRichEntityByEnumerationMemberIdAsync(int? enumerationMemberId)
        {
            return (await FindAsync(
                    enumerationMember =>
                        (enumerationMember.EnumerationMemberId == enumerationMemberId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public DbEntities.EnumerationMember GetByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            return (Find (
                    enumerationMember =>
                        (enumerationMember.Enumeration.ConceptModel.ModelName == modelName)
                        && (enumerationMember.Enumeration.EnumerationName == enumerationName)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.EnumerationMember> GetByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            return (await FindAsync (
                    enumerationMember =>
                        (enumerationMember.Enumeration.ConceptModel.ModelName == modelName)
                        && (enumerationMember.Enumeration.EnumerationName == enumerationName)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public DbEntities.EnumerationMember GetRichEntityByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            return (Find(
                    enumerationMember =>
                        (enumerationMember.Enumeration.ConceptModel.ModelName == modelName)
                        && (enumerationMember.Enumeration.EnumerationName == enumerationName)
                        && (enumerationMember.EnumeratedValue == enumeratedValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.EnumerationMember> GetRichEntityByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            return (await FindAsync(
                    enumerationMember =>
                        (enumerationMember.Enumeration.ConceptModel.ModelName == modelName)
                        && (enumerationMember.Enumeration.EnumerationName == enumerationName)
                        && (enumerationMember.EnumeratedValue == enumeratedValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public DbEntities.EnumerationMember GetByEnumerationIdEnumeratedValue(
            int? enumerationId,
            string enumeratedValue)
        {
            return (Find (
                    enumerationMember =>
                        (enumerationMember.EnumerationId == enumerationId)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.EnumerationMember> GetByEnumerationIdEnumeratedValueAsync(
            int? enumerationId,
            string enumeratedValue)
        {
            return (await FindAsync (
                    enumerationMember =>
                        (enumerationMember.EnumerationId == enumerationId)
                        && (enumerationMember.EnumeratedValue == enumeratedValue)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public DbEntities.EnumerationMember GetRichEntityByEnumerationIdEnumeratedValue(
            int? enumerationId,
            string enumeratedValue)
        {
            return (Find(
                    enumerationMember =>
                        (enumerationMember.EnumerationId == enumerationId)
                        && (enumerationMember.EnumeratedValue == enumeratedValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<DbEntities.EnumerationMember> GetRichEntityByEnumerationIdEnumeratedValueAsync(
            int? enumerationId,
            string enumeratedValue)
        {
            return (await FindAsync(
                    enumerationMember =>
                        (enumerationMember.EnumerationId == enumerationId)
                        && (enumerationMember.EnumeratedValue == enumeratedValue),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
