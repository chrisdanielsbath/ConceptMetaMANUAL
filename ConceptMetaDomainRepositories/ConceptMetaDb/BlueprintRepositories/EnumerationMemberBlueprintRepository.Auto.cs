/****************************
 * EnumerationMemberBlueprintRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Blueprint.Comparers;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositories
{
    /// <summary>
    /// Repository class for the <see cref="BlueprintModels.EnumerationMember" /> entity
    /// </summary>
    public partial class EnumerationMemberBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.EnumerationMember, DbEntities.EnumerationMember, IConceptMetaDbUnitOfWork>,
        IEnumerationMemberBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public EnumerationMemberBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.EnumerationMember> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified enumerationMember
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.EnumerationMember enumerationMember)
        {
            return new object[] { enumerationMember.EnumerationMemberId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.EnumerationMember ToDbEntity(BlueprintModels.EnumerationMember blueprintObj)
        {
            return (DbEntities.EnumerationMember)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.EnumerationMember),
                typeof(DbEntities.EnumerationMember));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.EnumerationMember> ToDbEntities(IEnumerable<BlueprintModels.EnumerationMember> blueprintObjects)
        {
            return (IEnumerable<DbEntities.EnumerationMember>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.EnumerationMember>),
                typeof(IEnumerable<DbEntities.EnumerationMember>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="enumerationMember"></param>
        /// <returns></returns>
        protected override BlueprintModels.EnumerationMember ToBlueprintObject(DbEntities.EnumerationMember enumerationMember)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.EnumerationMember result = (BlueprintModels.EnumerationMember)BlueprintUnitOfWork.FromEntityMapper.Map(
                enumerationMember,
                typeof(DbEntities.EnumerationMember),
                typeof(BlueprintModels.EnumerationMember));

            // sort nested objects
            BlueprintUnitOfWork.EnumerationMembers.SortNestedObjects(new List<BlueprintModels.EnumerationMember> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.EnumerationMember> ToBlueprintObjects(IEnumerable<DbEntities.EnumerationMember> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.EnumerationMember> result = (IEnumerable<BlueprintModels.EnumerationMember>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.EnumerationMember>),
                typeof(IEnumerable<BlueprintModels.EnumerationMember>));

            // sort nested objects
            BlueprintUnitOfWork.EnumerationMembers.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.EnumerationMember> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.EnumerationMember>),
                typeof(IEnumerable<KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.EnumerationMember> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.EnumerationMember> result = (IEnumerable<BlueprintModels.EnumerationMember>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.EnumerationMember, BlueprintModels.EnumerationMember>>),
                typeof(IEnumerable<BlueprintModels.EnumerationMember>));

            // sort nested objects
            BlueprintUnitOfWork.EnumerationMembers.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override BlueprintModels.EnumerationMember GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string enumerationName = (string)keyValues[1];
            string enumeratedValue = (string)keyValues[2];
            return GetByModelNameEnumerationNameEnumeratedValue(
                modelName,
                enumerationName,
                enumeratedValue
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.EnumerationMember> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string enumerationName = (string)keyValues[1];
            string enumeratedValue = (string)keyValues[2];
            return await GetByModelNameEnumerationNameEnumeratedValueAsync(
                modelName,
                enumerationName,
                enumeratedValue
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.EnumerationMember> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a enumerationMember to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.EnumerationMember, string> GetLogicalKeyFunction()
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
        public override Func<BlueprintModels.EnumerationMember, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.EnumerationMemberId == default || e.EnumerationMemberId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.EnumerationMember fromBlueprintObj,
            IEnumerable<BlueprintModels.EnumerationMember> toObjects)
        {
            foreach (BlueprintModels.EnumerationMember obj in toObjects)
            {
                // populate the primary key within the object
                obj.EnumerationMemberId = fromBlueprintObj.EnumerationMemberId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.EnumerationMember> items)
        {
            foreach (BlueprintModels.EnumerationMember item in items)
            {
                // populate non-recursive foreign key fields
                if (item.EnumerationId == default || item.EnumerationId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != "")
                    {
                        item.EnumerationId = DbUnitOfWork.Enumerations.GetEnumerationIdByModelNameEnumerationName(
                            item.ModelName,
                            item.EnumerationName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.EnumerationMember> items)
        {
            foreach (BlueprintModels.EnumerationMember item in items)
            {
                // populate non-recursive foreign key fields
                if (item.EnumerationId == default || item.EnumerationId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != "")
                    {
                        item.EnumerationId = await DbUnitOfWork.Enumerations.GetEnumerationIdByModelNameEnumerationNameAsync(
                            item.ModelName,
                            item.EnumerationName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.EnumerationMember> items)
        {
            foreach (BlueprintModels.EnumerationMember item in items)
            {
                if (item.EnumerationMemberId == default || item.EnumerationMemberId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != ""
                        && item.EnumeratedValue != default && item.EnumeratedValue != "")
                    {
                        item.EnumerationMemberId = DbUnitOfWork.EnumerationMembers.GetEnumerationMemberIdByModelNameEnumerationNameEnumeratedValue(
                            item.ModelName,
                            item.EnumerationName,
                            item.EnumeratedValue);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.EnumerationMember> items)
        {
            foreach (BlueprintModels.EnumerationMember item in items)
            {
                if (item.EnumerationMemberId == default || item.EnumerationMemberId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != ""
                        && item.EnumeratedValue != default && item.EnumeratedValue != "")
                    {
                        item.EnumerationMemberId = await DbUnitOfWork.EnumerationMembers.GetEnumerationMemberIdByModelNameEnumerationNameEnumeratedValueAsync(
                            item.ModelName,
                            item.EnumerationName,
                            item.EnumeratedValue);
                    }
                }
            }
        }

        /// <summary>
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void RenumberNestedObjects(
            IEnumerable<BlueprintModels.EnumerationMember> items,
            bool recurse = true)
        {
            // nothing to renumber
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.EnumerationMember> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        public BlueprintModels.EnumerationMember GetByEnumerationMemberId(int enumerationMemberId)
        {
            // get the rich entity
            DbEntities.EnumerationMember enumerationMember =
                DbUnitOfWork.EnumerationMembers.GetRichEntityByEnumerationMemberId(
                    enumerationMemberId);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumerationMember);
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.EnumerationMember> GetByEnumerationMemberIdAsync(int enumerationMemberId)
        {
            // get the rich entity
            DbEntities.EnumerationMember enumerationMember =
                await DbUnitOfWork.EnumerationMembers.GetRichEntityByEnumerationMemberIdAsync(
                    enumerationMemberId);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumerationMember);
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public BlueprintModels.EnumerationMember GetByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            // get the rich entity
            DbEntities.EnumerationMember enumerationMember =
                DbUnitOfWork.EnumerationMembers.GetRichEntityByModelNameEnumerationNameEnumeratedValue(
                    modelName,
                    enumerationName,
                    enumeratedValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumerationMember);
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.EnumerationMember> GetByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue)
        {
            // get the rich entity
            DbEntities.EnumerationMember enumerationMember =
                await DbUnitOfWork.EnumerationMembers.GetRichEntityByModelNameEnumerationNameEnumeratedValueAsync(
                    modelName,
                    enumerationName,
                    enumeratedValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumerationMember);
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public BlueprintModels.EnumerationMember GetByEnumerationIdEnumeratedValue(
            int enumerationId,
            string enumeratedValue)
        {
            // get the rich entity
            DbEntities.EnumerationMember enumerationMember =
                DbUnitOfWork.EnumerationMembers.GetRichEntityByEnumerationIdEnumeratedValue(
                    enumerationId,
                    enumeratedValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumerationMember);
        }

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.EnumerationMember> GetByEnumerationIdEnumeratedValueAsync(
            int enumerationId,
            string enumeratedValue)
        {
            // get the rich entity
            DbEntities.EnumerationMember enumerationMember =
                await DbUnitOfWork.EnumerationMembers.GetRichEntityByEnumerationIdEnumeratedValueAsync(
                    enumerationId,
                    enumeratedValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumerationMember);
        }

        #endregion
    }
}
