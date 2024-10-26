using System.ComponentModel.DataAnnotations;

namespace formulario.Validaciones
{
    public class EmpezarMayus : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            char character = value.ToString()[0];
            
            if (char.IsUpper(character))
            {
                return ValidationResult.Success;
            } else {
                return new ValidationResult("El campo debe empezar con una letra mayúscula");
            }
        }
    }
}
