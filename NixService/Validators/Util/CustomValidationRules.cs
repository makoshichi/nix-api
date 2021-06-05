namespace NixService.Validators
{
    public static class CustomValidationRules
    {
        public static void CheckMaxLengthValidationFailure<T>(int length, int maxLength, string propertyName, FluentValidation.ValidationContext<T> validationContext)
        {
            if (length > maxLength)
                validationContext.AddFailure($"O tamanho do campo {propertyName} deve ser menor que {maxLength} caracteres. Você utilizou {length} caracteres.");;
        }
    }
}
