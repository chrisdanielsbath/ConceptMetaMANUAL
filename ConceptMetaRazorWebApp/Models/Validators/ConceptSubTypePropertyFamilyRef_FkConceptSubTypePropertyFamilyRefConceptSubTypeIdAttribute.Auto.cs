/****************************
 * ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptSubTypeIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> models meet the requirements of the
    /// FK_ConceptSubTypePropertyFamilyRef_ConceptSubTypeId foreign key constraint
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptSubTypeIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = (RazorModels.ConceptSubTypePropertyFamilyRef)validationContext.ObjectInstance;

            if (conceptSubTypePropertyFamilyRef.ConceptSubTypeId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.ConceptSubType referencedConceptSubType = context.ConceptSubTypes
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.ConceptSubTypeId == conceptSubTypePropertyFamilyRef.ConceptSubTypeId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedConceptSubType == null)
                {
                    return new ValidationResult("The Concept Sub Type could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
