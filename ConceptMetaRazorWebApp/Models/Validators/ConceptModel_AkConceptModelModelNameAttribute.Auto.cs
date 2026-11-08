/****************************
 * ConceptModel_AkConceptModelModelNameAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptModel" /> models
    /// </summary>
    public partial class ConceptModel_AkConceptModelModelNameAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptModel conceptModel = (RazorModels.ConceptModel)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptModel existingConceptModel = context.ConceptModels
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ModelName == conceptModel.ModelName)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptModelId != conceptModel.ConceptModelId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptModel != null)
            {
                return new ValidationResult("The Model Name must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
