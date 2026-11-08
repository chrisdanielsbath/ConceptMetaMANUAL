/****************************
 * Include_AkIncludeConceptIdItemValueAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.Include" /> models
    /// </summary>
    public partial class Include_AkIncludeConceptIdItemValueAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.Include include = (RazorModels.Include)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.Include existingInclude = context.Includes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptId == include.ConceptId)
                        &&  (e.ItemValue == include.ItemValue)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.IncludeId != include.IncludeId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingInclude != null)
            {
                return new ValidationResult("The Concept Id, Item Value must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
