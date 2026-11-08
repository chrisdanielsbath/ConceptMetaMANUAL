/****************************
 * ConceptPropertyFamilyBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.ConceptPropertyFamily" /> entity
    /// </summary>
    public partial class ConceptPropertyFamilyBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.ConceptPropertyFamily, DbEntities.ConceptPropertyFamily, IConceptMetaDbUnitOfWork>,
        IConceptPropertyFamilyBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptPropertyFamilyBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.ConceptPropertyFamily> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptPropertyFamily
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptPropertyFamily conceptPropertyFamily)
        {
            return new object[] { conceptPropertyFamily.ConceptPropertyFamilyId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptPropertyFamily ToDbEntity(BlueprintModels.ConceptPropertyFamily blueprintObj)
        {
            return (DbEntities.ConceptPropertyFamily)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptPropertyFamily),
                typeof(DbEntities.ConceptPropertyFamily));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptPropertyFamily> ToDbEntities(IEnumerable<BlueprintModels.ConceptPropertyFamily> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptPropertyFamily>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptPropertyFamily>),
                typeof(IEnumerable<DbEntities.ConceptPropertyFamily>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptPropertyFamily ToBlueprintObject(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptPropertyFamily result = (BlueprintModels.ConceptPropertyFamily)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptPropertyFamily,
                typeof(DbEntities.ConceptPropertyFamily),
                typeof(BlueprintModels.ConceptPropertyFamily));

            // sort nested objects
            BlueprintUnitOfWork.ConceptPropertyFamilies.SortNestedObjects(new List<BlueprintModels.ConceptPropertyFamily> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptPropertyFamily> ToBlueprintObjects(IEnumerable<DbEntities.ConceptPropertyFamily> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptPropertyFamily> result = (IEnumerable<BlueprintModels.ConceptPropertyFamily>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptPropertyFamily>),
                typeof(IEnumerable<BlueprintModels.ConceptPropertyFamily>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptPropertyFamilies.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptPropertyFamily> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptPropertyFamily>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptPropertyFamily> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptPropertyFamily> result = (IEnumerable<BlueprintModels.ConceptPropertyFamily>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptPropertyFamily, BlueprintModels.ConceptPropertyFamily>>),
                typeof(IEnumerable<BlueprintModels.ConceptPropertyFamily>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptPropertyFamilies.SortNestedObjects(result);

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
        public override BlueprintModels.ConceptPropertyFamily GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string propertyFamilyName = (string)keyValues[2];
            return GetByModelNameConceptNamePropertyFamilyName(
                modelName,
                conceptName,
                propertyFamilyName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptPropertyFamily> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string propertyFamilyName = (string)keyValues[2];
            return await GetByModelNameConceptNamePropertyFamilyNameAsync(
                modelName,
                conceptName,
                propertyFamilyName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptPropertyFamily> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a conceptPropertyFamily to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptPropertyFamily, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.PropertyFamilyName != null ? e.PropertyFamilyName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptPropertyFamily, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptPropertyFamilyId == default || e.ConceptPropertyFamilyId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptPropertyFamily fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptPropertyFamily> toObjects)
        {
            foreach (BlueprintModels.ConceptPropertyFamily obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptPropertyFamilyId = fromBlueprintObj.ConceptPropertyFamilyId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptPropertyFamily> items)
        {
            foreach (BlueprintModels.ConceptPropertyFamily item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptId == default || item.ConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != "")
                    {
                        item.ConceptId = DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptName(
                            item.ModelName,
                            item.ConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptPropertyFamily> items)
        {
            foreach (BlueprintModels.ConceptPropertyFamily item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptId == default || item.ConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != "")
                    {
                        item.ConceptId = await DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptNameAsync(
                            item.ModelName,
                            item.ConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptPropertyFamily> items)
        {
            foreach (BlueprintModels.ConceptPropertyFamily item in items)
            {
                if (item.ConceptPropertyFamilyId == default || item.ConceptPropertyFamilyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptPropertyFamilyId = DbUnitOfWork.ConceptPropertyFamilies.GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyName(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyFamilyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptPropertyFamily> items)
        {
            foreach (BlueprintModels.ConceptPropertyFamily item in items)
            {
                if (item.ConceptPropertyFamilyId == default || item.ConceptPropertyFamilyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptPropertyFamilyId = await DbUnitOfWork.ConceptPropertyFamilies.GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyFamilyName);
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
            IEnumerable<BlueprintModels.ConceptPropertyFamily> items,
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
            IEnumerable<BlueprintModels.ConceptPropertyFamily> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptPropertyFamily GetByConceptPropertyFamilyId(int conceptPropertyFamilyId)
        {
            // get the rich entity
            DbEntities.ConceptPropertyFamily conceptPropertyFamily =
                DbUnitOfWork.ConceptPropertyFamilies.GetRichEntityByConceptPropertyFamilyId(
                    conceptPropertyFamilyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptPropertyFamily);
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptPropertyFamily> GetByConceptPropertyFamilyIdAsync(int conceptPropertyFamilyId)
        {
            // get the rich entity
            DbEntities.ConceptPropertyFamily conceptPropertyFamily =
                await DbUnitOfWork.ConceptPropertyFamilies.GetRichEntityByConceptPropertyFamilyIdAsync(
                    conceptPropertyFamilyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptPropertyFamily);
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptPropertyFamily GetByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptPropertyFamily conceptPropertyFamily =
                DbUnitOfWork.ConceptPropertyFamilies.GetRichEntityByModelNameConceptNamePropertyFamilyName(
                    modelName,
                    conceptName,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptPropertyFamily);
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptPropertyFamily> GetByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptPropertyFamily conceptPropertyFamily =
                await DbUnitOfWork.ConceptPropertyFamilies.GetRichEntityByModelNameConceptNamePropertyFamilyNameAsync(
                    modelName,
                    conceptName,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptPropertyFamily);
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptPropertyFamily GetByConceptIdPropertyFamilyName(
            int conceptId,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptPropertyFamily conceptPropertyFamily =
                DbUnitOfWork.ConceptPropertyFamilies.GetRichEntityByConceptIdPropertyFamilyName(
                    conceptId,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptPropertyFamily);
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptPropertyFamily> GetByConceptIdPropertyFamilyNameAsync(
            int conceptId,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptPropertyFamily conceptPropertyFamily =
                await DbUnitOfWork.ConceptPropertyFamilies.GetRichEntityByConceptIdPropertyFamilyNameAsync(
                    conceptId,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptPropertyFamily);
        }

        #endregion
    }
}
