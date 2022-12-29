using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;

public readonly record struct ValidationResult
{
    // Properties
    public IEnumerable<ValidationMessage> ValidationMessageCollection { get; }
    public IEnumerable<ValidationMessage> InformationValidationMessageCollection => ValidationMessageCollection.Where(q => q.ValidationMessageType == ValidationMessageType.Information);
    public IEnumerable<ValidationMessage> WarningValidationMessageCollection => ValidationMessageCollection.Where(q => q.ValidationMessageType == ValidationMessageType.Warning);
    public IEnumerable<ValidationMessage> ErrorValidationMessageCollection => ValidationMessageCollection.Where(q => q.ValidationMessageType == ValidationMessageType.Error);

    public bool HasValidationMessage => ValidationMessageCollection.Any();
    public bool HasInformationMessages => InformationValidationMessageCollection.Any();
    public bool HasWariningMessages => WarningValidationMessageCollection.Any();
    public bool HasErrorMessages => ErrorValidationMessageCollection.Any();
    public bool IsValid => !HasValidationMessage || !HasErrorMessages;

    // Constructors
    public ValidationResult()
    {
        ValidationMessageCollection = Enumerable.Empty<ValidationMessage>();
    }
    public ValidationResult(IEnumerable<ValidationMessage> validationMessageCollection)
    {
        ValidationMessageCollection = validationMessageCollection.ToArray();
    }

    // Public Methods
    public ValidationResult DeepClone()
    {
        return new ValidationResult(ValidationMessageCollection.ToArray());
    }
}
