/****************************
 * ConceptUniqueKeyPropertyFamilyRef_AkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyIdConceptPropertyFamilyIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptUniqueKeyPropertyFamilyRef" /> models
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRef_AkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyIdConceptPropertyFamilyIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef = (RazorModels.ConceptUniqueKeyPropertyFamilyRef)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptUniqueKeyPropertyFamilyRef existingConceptUniqueKeyPropertyFamilyRef = context.ConceptUniqueKeyPropertyFamilyRefs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptUniqueKeyId == conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId)
                        &&  (e.ConceptPropertyFamilyId == conceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamilyId)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptUniqueKeyPropertyFamilyRefId != conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptUniqueKeyPropertyFamilyRef != null)
            {
                return new ValidationResult("The Concept Unique Key Id, Concept Property Family Id must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
