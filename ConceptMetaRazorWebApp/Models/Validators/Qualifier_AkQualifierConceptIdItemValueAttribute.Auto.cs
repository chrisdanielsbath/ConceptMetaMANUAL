/****************************
 * Qualifier_AkQualifierConceptIdItemValueAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.Qualifier" /> models
    /// </summary>
    public partial class Qualifier_AkQualifierConceptIdItemValueAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.Qualifier qualifier = (RazorModels.Qualifier)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.Qualifier existingQualifier = context.Qualifiers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptId == qualifier.ConceptId)
                        &&  (e.ItemValue == qualifier.ItemValue)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.QualifierId != qualifier.QualifierId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingQualifier != null)
            {
                return new ValidationResult("The Concept Id, Item Value must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
