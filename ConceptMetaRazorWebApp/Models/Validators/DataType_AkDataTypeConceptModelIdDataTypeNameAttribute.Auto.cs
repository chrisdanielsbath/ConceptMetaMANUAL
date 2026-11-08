/****************************
 * DataType_AkDataTypeConceptModelIdDataTypeNameAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to prevent duplicate <see cref="RazorModels.DataType" /> models
    /// </summary>
    public partial class DataType_AkDataTypeConceptModelIdDataTypeNameAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.DataType dataType = (RazorModels.DataType)validationContext.ObjectInstance;

            ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RazorModels.DataType existingDataType = context.DataTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                            // find any matching item
                            (e.ConceptModelId == dataType.ConceptModelId)
                        &&  (e.DataTypeName == dataType.DataTypeName)
                            // ...but ignore the item that shares the same primary key
                        &&  (    (e.DataTypeId != dataType.DataTypeId)
                            )
                    )
                    .GetAwaiter()
                    .GetResult();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existingDataType != null)
            {
                return new ValidationResult("The Concept Model Id, Data Type Name must be unique");
            }

            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
