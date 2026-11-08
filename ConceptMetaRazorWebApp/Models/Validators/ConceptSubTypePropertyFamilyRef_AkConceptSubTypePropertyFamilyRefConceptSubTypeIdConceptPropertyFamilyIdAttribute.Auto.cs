/****************************
 * ConceptSubTypePropertyFamilyRef_AkConceptSubTypePropertyFamilyRefConceptSubTypeIdConceptPropertyFamilyIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> models
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRef_AkConceptSubTypePropertyFamilyRefConceptSubTypeIdConceptPropertyFamilyIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = (RazorModels.ConceptSubTypePropertyFamilyRef)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptSubTypePropertyFamilyRef existingConceptSubTypePropertyFamilyRef = context.ConceptSubTypePropertyFamilyRefs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptSubTypeId == conceptSubTypePropertyFamilyRef.ConceptSubTypeId)
                        &&  (e.ConceptPropertyFamilyId == conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptSubTypePropertyFamilyRefId != conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptSubTypePropertyFamilyRef != null)
            {
                return new ValidationResult("The Concept Sub Type Id, Concept Property Family Id must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
