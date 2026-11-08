/****************************
 * ConceptPropertyFamilyRepository.Auto.cs
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
    /// Repository class for the <see cref="DbEntities.ConceptPropertyFamily" /> entity
    /// </summary>
    public partial class ConceptPropertyFamilyRepository
        : ConceptMetaDbRepository<DbEntities.ConceptPropertyFamily>,
        IConceptPropertyFamilyRepository
    {

        #region Constructors
        public ConceptPropertyFamilyRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptPropertyFamily
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return new object[] { conceptPropertyFamily.ConceptPropertyFamilyId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the conceptPropertyFamily with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptPropertyFamily, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ConceptPropertyFamilyId == (int)keyValues[0]) && (e.ConceptPropertyFamilyId != default && e.ConceptPropertyFamilyId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified conceptPropertyFamily
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptPropertyFamily, bool>> GetPrimaryKeyPredicate(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return (e => 
                (e.ConceptPropertyFamilyId == conceptPropertyFamily.ConceptPropertyFamilyId) && (e.ConceptPropertyFamilyId != default && e.ConceptPropertyFamilyId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified conceptPropertyFamily
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptPropertyFamily, bool>> GetLogicalKeyPredicate(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return (e => 
                (e.ConceptId == conceptPropertyFamily.ConceptId) && 
                (e.PropertyFamilyName == conceptPropertyFamily.PropertyFamilyName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified conceptPropertyFamily
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return new object[] { conceptPropertyFamily.ModelName, conceptPropertyFamily.ConceptName, conceptPropertyFamily.PropertyFamilyName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the conceptPropertyFamily with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.ConceptPropertyFamily, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.ConceptName == (string)keyValues[1]) && (e.ConceptName != default && e.ConceptName != "") && 
                (e.PropertyFamilyName == (string)keyValues[2]) && (e.PropertyFamilyName != default && e.PropertyFamilyName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.ConceptPropertyFamily from,
            DbEntities.ConceptPropertyFamily to)
        {
            to.ConceptId = from.ConceptId;
            to.PropertyFamilyName = from.PropertyFamilyName;
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
        /// <param name="conceptPropertyFamily"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.ConceptPropertyFamily conceptPropertyFamily)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="conceptPropertyFamily"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.ConceptPropertyFamily conceptPropertyFamily,
            out DbEntities.ConceptPropertyFamily sterilisedEntity)
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
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.ConceptPropertyFamily e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptPropertyFamilyId == default || e.ConceptPropertyFamilyId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptPropertyFamilyId = GetConceptPropertyFamilyIdByConceptIdPropertyFamilyName(
                    e.ConceptId,
                    e.PropertyFamilyName);

                // test whether the item has been found within the database
                if (conceptPropertyFamilyId != default && conceptPropertyFamilyId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptPropertyFamilyId = conceptPropertyFamilyId;
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
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.ConceptPropertyFamily e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.ConceptPropertyFamilyId == default || e.ConceptPropertyFamilyId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int conceptPropertyFamilyId = await GetConceptPropertyFamilyIdByConceptIdPropertyFamilyNameAsync(
                    e.ConceptId,
                    e.PropertyFamilyName);

                // test whether the item has been found within the database
                if (conceptPropertyFamilyId != default && conceptPropertyFamilyId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.ConceptPropertyFamilyId = conceptPropertyFamilyId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.ConceptPropertyFamily> items)
        {
            foreach (DbEntities.ConceptPropertyFamily item in items)
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
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.ConceptPropertyFamily> items)
        {
            foreach (DbEntities.ConceptPropertyFamily item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.Properties != null)
                {
                    foreach (DbEntities.ConceptRef childItem in item.Properties)
                    {
                        if (item.ConceptPropertyFamilyId != default && item.ConceptPropertyFamilyId != default(int))
                        {
                            childItem.ConceptPropertyFamilyId = item.ConceptPropertyFamilyId;
                        }
                    }
                }
                if (item.PropertyFamilyRefs != null)
                {
                    foreach (DbEntities.ConceptSubTypePropertyFamilyRef childItem in item.PropertyFamilyRefs)
                    {
                        if (item.ConceptPropertyFamilyId != default && item.ConceptPropertyFamilyId != default(int))
                        {
                            childItem.ConceptPropertyFamilyId = item.ConceptPropertyFamilyId;
                        }
                    }
                }
                if (item.UniqueKeyPropertyFamilyRefs != null)
                {
                    foreach (DbEntities.ConceptUniqueKeyPropertyFamilyRef childItem in item.UniqueKeyPropertyFamilyRefs)
                    {
                        if (item.ConceptPropertyFamilyId != default && item.ConceptPropertyFamilyId != default(int))
                        {
                            childItem.ConceptPropertyFamilyId = item.ConceptPropertyFamilyId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptPropertyFamily to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.ConceptPropertyFamily, string> GetLogicalKeyFunction()
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
        public override Func<DbEntities.ConceptPropertyFamily, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptPropertyFamilyId == default || e.ConceptPropertyFamilyId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.ConceptPropertyFamily fromEntity,
            IEnumerable<DbEntities.ConceptPropertyFamily> toObjects)
        {
            foreach (DbEntities.ConceptPropertyFamily obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptPropertyFamilyId = fromEntity.ConceptPropertyFamilyId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public int GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            return (Find(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.Concept.ConceptModel.ModelName == modelName)
                        && (conceptPropertyFamily.Concept.ConceptName == conceptName)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptPropertyFamily => conceptPropertyFamily.ConceptPropertyFamilyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.Concept.ConceptModel.ModelName == modelName)
                        && (conceptPropertyFamily.Concept.ConceptName == conceptName)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptPropertyFamily => conceptPropertyFamily.ConceptPropertyFamilyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public int GetConceptPropertyFamilyIdByConceptIdPropertyFamilyName(
            int conceptId,
            string propertyFamilyName)
        {
            return (Find(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptId == conceptId)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptPropertyFamily => conceptPropertyFamily.ConceptPropertyFamilyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<int> GetConceptPropertyFamilyIdByConceptIdPropertyFamilyNameAsync(
            int conceptId,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptId == conceptId)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .Select(conceptPropertyFamily => conceptPropertyFamily.ConceptPropertyFamilyId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptPropertyFamily GetByConceptPropertyFamilyId(int? conceptPropertyFamilyId)
        {
            return (Find (
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptPropertyFamily> GetByConceptPropertyFamilyIdAsync(int? conceptPropertyFamilyId)
        {
            return (await FindAsync (
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptPropertyFamilyId == conceptPropertyFamilyId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public DbEntities.ConceptPropertyFamily GetRichEntityByConceptPropertyFamilyId(int? conceptPropertyFamilyId)
        {
            return (Find(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptPropertyFamilyId == conceptPropertyFamilyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptPropertyFamily> GetRichEntityByConceptPropertyFamilyIdAsync(int? conceptPropertyFamilyId)
        {
            return (await FindAsync(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptPropertyFamilyId == conceptPropertyFamilyId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptPropertyFamily GetByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            return (Find (
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.Concept.ConceptModel.ModelName == modelName)
                        && (conceptPropertyFamily.Concept.ConceptName == conceptName)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptPropertyFamily> GetByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            return (await FindAsync (
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.Concept.ConceptModel.ModelName == modelName)
                        && (conceptPropertyFamily.Concept.ConceptName == conceptName)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptPropertyFamily GetRichEntityByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            return (Find(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.Concept.ConceptModel.ModelName == modelName)
                        && (conceptPropertyFamily.Concept.ConceptName == conceptName)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptPropertyFamily> GetRichEntityByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.Concept.ConceptModel.ModelName == modelName)
                        && (conceptPropertyFamily.Concept.ConceptName == conceptName)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptPropertyFamily GetByConceptIdPropertyFamilyName(
            int? conceptId,
            string propertyFamilyName)
        {
            return (Find (
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptId == conceptId)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptPropertyFamily> GetByConceptIdPropertyFamilyNameAsync(
            int? conceptId,
            string propertyFamilyName)
        {
            return (await FindAsync (
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptId == conceptId)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public DbEntities.ConceptPropertyFamily GetRichEntityByConceptIdPropertyFamilyName(
            int? conceptId,
            string propertyFamilyName)
        {
            return (Find(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptId == conceptId)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptPropertyFamily> GetRichEntityByConceptIdPropertyFamilyNameAsync(
            int? conceptId,
            string propertyFamilyName)
        {
            return (await FindAsync(
                    conceptPropertyFamily =>
                        (conceptPropertyFamily.ConceptId == conceptId)
                        && (conceptPropertyFamily.PropertyFamilyName == propertyFamilyName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}
