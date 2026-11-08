/****************************
 * ConceptSubType_AkConceptSubTypeConceptIdSubTypeNameAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.ConceptSubType" /> models
    /// </summary>
    public partial class ConceptSubType_AkConceptSubTypeConceptIdSubTypeNameAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptSubType conceptSubType = (RazorModels.ConceptSubType)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.ConceptSubType existingConceptSubType = context.ConceptSubTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptId == conceptSubType.ConceptId)
                        &&  (e.SubTypeName == conceptSubType.SubTypeName)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.ConceptSubTypeId != conceptSubType.ConceptSubTypeId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingConceptSubType != null)
            {
                return new ValidationResult("The Concept Id, Sub Type Name must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
