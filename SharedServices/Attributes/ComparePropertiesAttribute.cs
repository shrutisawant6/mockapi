using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ComparePropertiesAttribute : ValidationAttribute
{
    public string FirstProperty { get; }
    public string SecondProperty { get; }

    public ComparePropertiesAttribute(string firstProperty, string secondProperty)
    {
        FirstProperty = firstProperty;
        SecondProperty = secondProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var type = context.ObjectType;
        var firstProp = type.GetProperty(FirstProperty);
        var secondProp = type.GetProperty(SecondProperty);

        if (firstProp == null || secondProp == null)
            return new ValidationResult($"Invalid property names: {FirstProperty} or {SecondProperty}");

        var firstValue = firstProp.GetValue(value) as IComparable;
        var secondValue = secondProp.GetValue(value) as IComparable;

        if (firstValue == null || secondValue == null)
            return ValidationResult.Success;

        if (firstValue.CompareTo(secondValue) <= 0)
            return new ValidationResult($"{FirstProperty} must be greater than {SecondProperty}");

        return ValidationResult.Success;
    }
}
