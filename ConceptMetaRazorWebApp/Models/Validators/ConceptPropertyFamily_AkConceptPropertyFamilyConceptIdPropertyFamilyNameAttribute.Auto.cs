/****************************
 * ConceptPropertyFamily_AkConceptPropertyFamilyConceptIdPropertyFamilyNameAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptPropertyFamily" /> models
    /// </summary>
    public partial class ConceptPropertyFamily_AkConceptPropertyFamilyConceptIdPropertyFamilyNameAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptPropertyFamily conceptPropertyFamily = (RazorModels.ConceptPropertyFamily)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptPropertyFamily existingConceptPropertyFamily = context.ConceptPropertyFamilies
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptId == conceptPropertyFamily.ConceptId)
                        &&  (e.PropertyFamilyName == conceptPropertyFamily.PropertyFamilyName)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptPropertyFamilyId != conceptPropertyFamily.ConceptPropertyFamilyId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptPropertyFamily != null)
            {
                return new ValidationResult("The Concept Id, Property Family Name must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
