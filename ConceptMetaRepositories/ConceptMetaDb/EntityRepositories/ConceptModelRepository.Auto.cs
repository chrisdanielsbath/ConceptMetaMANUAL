/****************************
 * ConceptModelRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;
using ConceptMeta.Collections;

namespace ConceptMeta.ConceptMetaDb.EntityRepositories
{
    /// <summary>
    /// Repository class for the <see cref="DbEntities.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelRepository
        : ConceptMetaDbAggregateRootRepository<DbEntities.ConceptModel>,
        IConceptModelRepository
    {

        #region Instance Properties
        protected IDataTypeRepository DataTypeRepository => DbUnitOfWork.DataTypes;
        protected IEnumerationRepository EnumerationRepository => DbUnitOfWork.Enumerations;
        protected IEnumerationMemberRepository EnumerationMemberRepository => DbUnitOfWork.EnumerationMembers;
        protected IConceptRepository ConceptRepository => DbUnitOfWork.Concepts;
        protected IIncludeRepository IncludeRepository => DbUnitOfWork.Includes;
        protected IQualifierRepository QualifierRepository => DbUnitOfWork.Qualifiers;
        protected IConceptPropertyFamilyRepository ConceptPropertyFamilyRepository => DbUnitOfWork.ConceptPropertyFamilies;
        protected IConceptUniqueKeyRepository ConceptUniqueKeyRepository => DbUnitOfWork.ConceptUniqueKeys;
        protected IConceptUniqueKeyPropertyFamilyRefRepository ConceptUniqueKeyPropertyFamilyRefRepository => DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs;
        protected IConceptSubTypeRepository ConceptSubTypeRepository => DbUnitOfWork.ConceptSubTypes;
        protected IConceptSubTypePropertyFamilyRefRepository ConceptSubTypePropertyFamilyRefRepository => DbUnitOfWork.ConceptSubTypePropertyFamilyRefs;
        protected IConceptRefRepository ConceptRefRepository => DbUnitOfWork.ConceptRefs;

        #endregion

        #region Constructors
        public ConceptModelRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptModel
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptModel conceptModel)
        {
            return new object[] { conceptModel.ConceptModelId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptModel with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptModel, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptModelId == (int)keyValues[0]) && (e.ConceptModelId != default && e.ConceptModelId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptModel
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptModel, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptModel conceptModel)
        {
            return (e => 
                (e.ConceptModelId == conceptModel.ConceptModelId) && (e.ConceptModelId != default && e.ConceptModelId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptModel
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptModel, bool>> GetLogicalKeyPredicate(DbEntities.ConceptModel conceptModel)
        {
            return (e => 
                (e.ModelName == conceptModel.ModelName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptModel
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptModel conceptModel)
        {
            return new object[] { conceptModel.ModelName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptModel with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptModel, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptModel from,
            DbEntities.ConceptModel to)
        {
            to.ModelName = from.ModelName;
            to.DefaultStringLength = from.DefaultStringLength;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptModel conceptModel)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptModel conceptModel,
            out DbEntities.ConceptModel sterilisedEntity)
        {
            sterilisedEntity = null;
        }

        /// <summary>
        /// Adds child entities to the set of items to be returned by queries
        /// </summary>
        protected override void PopulateAggregateIncludes()
        {
            // add the paths to included entities
            AggregateIncludes.Add("DataTypes");
            AggregateIncludes.Add("Enumerations");
            AggregateIncludes.Add("Enumerations.EnumeratedValues");
            AggregateIncludes.Add("Concepts");
            AggregateIncludes.Add("Concepts.Includes");
            AggregateIncludes.Add("Concepts.Qualifiers");
            AggregateIncludes.Add("Concepts.PropertyFamilies");
            AggregateIncludes.Add("Concepts.UniqueKeys");
            AggregateIncludes.Add("Concepts.SubTypes");
            AggregateIncludes.Add("Concepts.UniqueKeys.PropertyFamilyRefs");
            AggregateIncludes.Add("Concepts.SubTypes.PropertyFamilyRefs");
            AggregateIncludes.Add("Concepts.Properties");
        }

        #endregion

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptModel e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptModelId == default || e.ConceptModelId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptModelId = GetConceptModelIdByModelName(
                    e.ModelName);

                // test whether the item has been found within the database
                if (conceptModelId != default && conceptModelId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptModelId = conceptModelId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptModel e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptModelId == default || e.ConceptModelId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptModelId = await GetConceptModelIdByModelNameAsync(
                    e.ModelName);

                // test whether the item has been found within the database
                if (conceptModelId != default && conceptModelId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptModelId = conceptModelId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptModel> items)
        {
            foreach (DbEntities.ConceptModel item in items)
            {
                // populate foreign key fields
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptModel> items)
        {
            foreach (DbEntities.ConceptModel item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.DataTypes != null)
                {
                    foreach (DbEntities.DataType childItem in item.DataTypes)
                    {
                        if (item.ConceptModelId != default && item.ConceptModelId != default(int))
                        {
                            childItem.ConceptModelId = item.ConceptModelId;
                        }
                    }
                }
                if (item.Enumerations != null)
                {
                    foreach (DbEntities.Enumeration childItem in item.Enumerations)
                    {
                        if (item.ConceptModelId != default && item.ConceptModelId != default(int))
                        {
                            childItem.ConceptModelId = item.ConceptModelId;
                        }
                    }
                }
                if (item.Concepts != null)
                {
                    foreach (DbEntities.Concept childItem in item.Concepts)
                    {
                        if (item.ConceptModelId != default && item.ConceptModelId != default(int))
                        {
                            childItem.ConceptModelId = item.ConceptModelId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptModel to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptModel, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + (e.ModelName != null ? e.ModelName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptModel, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptModelId == default || e.ConceptModelId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptModel fromEntity,
            IEnumerable<DbEntities.ConceptModel> toObjects)
        {
            foreach (DbEntities.ConceptModel obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptModelId = fromEntity.ConceptModelId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptModelId of the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public int GetConceptModelIdByModelName(string modelName)
        {
            return (Find(
                    conceptModel =>
                        (conceptModel.ModelName == modelName)))
                .Select(conceptModel => conceptModel.ConceptModelId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptModelId of the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptModelIdByModelNameAsync(string modelName)
        {
            return (await FindAsync(
                    conceptModel =>
                        (conceptModel.ModelName == modelName)))
                .Select(conceptModel => conceptModel.ConceptModelId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetByConceptModelId(int? conceptModelId)
        {
            return (Find (
                    conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetByConceptModelIdAsync(int? conceptModelId)
        {
            return (await FindAsync (
                    conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetRichEntityByConceptModelId(int? conceptModelId)
        {
            return (Find(
                    conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetRichEntityByConceptModelIdAsync(int? conceptModelId)
        {
            return (await FindAsync(
                    conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetAggregateByConceptModelId(int? conceptModelId)
        {
            return (Find(
                    conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId),
                    AggregateIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetAggregateByConceptModelIdAsync(int? conceptModelId)
        {
            return (await FindAsync(
                    conceptModel =>
                        (conceptModel.ConceptModelId == conceptModelId),
                    AggregateIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetByModelName(string modelName)
        {
            return (Find (
                    conceptModel =>
                        (conceptModel.ModelName == modelName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetByModelNameAsync(string modelName)
        {
            return (await FindAsync (
                    conceptModel =>
                        (conceptModel.ModelName == modelName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetRichEntityByModelName(string modelName)
        {
            return (Find(
                    conceptModel =>
                        (conceptModel.ModelName == modelName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetRichEntityByModelNameAsync(string modelName)
        {
            return (await FindAsync(
                    conceptModel =>
                        (conceptModel.ModelName == modelName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetAggregateByModelName(string modelName)
        {
            return (Find(
                    conceptModel =>
                        (conceptModel.ModelName == modelName),
                    AggregateIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetAggregateByModelNameAsync(string modelName)
        {
            return (await FindAsync(
                    conceptModel =>
                        (conceptModel.ModelName == modelName),
                    AggregateIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
