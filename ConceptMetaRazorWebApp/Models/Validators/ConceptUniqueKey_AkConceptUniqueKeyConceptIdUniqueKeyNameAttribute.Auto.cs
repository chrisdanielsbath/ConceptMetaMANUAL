/****************************
 * ConceptUniqueKey_AkConceptUniqueKeyConceptIdUniqueKeyNameAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptUniqueKey" /> models
    /// </summary>
    public partial class ConceptUniqueKey_AkConceptUniqueKeyConceptIdUniqueKeyNameAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptUniqueKey conceptUniqueKey = (RazorModels.ConceptUniqueKey)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptUniqueKey existingConceptUniqueKey = context.ConceptUniqueKeys
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptId == conceptUniqueKey.ConceptId)
                        &&  (e.UniqueKeyName == conceptUniqueKey.UniqueKeyName)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptUniqueKeyId != conceptUniqueKey.ConceptUniqueKeyId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptUniqueKey != null)
            {
                return new ValidationResult("The Concept Id, Unique Key Name must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
