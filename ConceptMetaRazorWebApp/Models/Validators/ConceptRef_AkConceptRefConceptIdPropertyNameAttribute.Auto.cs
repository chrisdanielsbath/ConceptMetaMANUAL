/****************************
 * ConceptRef_AkConceptRefConceptIdPropertyNameAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptRef" /> models
    /// </summary>
    public partial class ConceptRef_AkConceptRefConceptIdPropertyNameAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptRef conceptRef = (RazorModels.ConceptRef)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptRef existingConceptRef = context.ConceptRefs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptId == conceptRef.ConceptId)
                        &&  (e.PropertyName == conceptRef.PropertyName)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptRefId != conceptRef.ConceptRefId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptRef != null)
            {
                return new ValidationResult("The Concept Id, Property Name must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
