using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;
using System.Collections.Generic;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Tests.ModelsTests;

public class ValidationResultTest
{

    [Fact]
    public void ValidationResult_Should_Correctly_Initialized()
    {
        // Arrange
        var validationMessageCollection = new List<ValidationMessage>
        {
            new ValidationMessage(Enums.ValidationMessageType.Information, "1", "INFO"),
            new ValidationMessage(Enums.ValidationMessageType.Warning, "2", "WARNING"),
            new ValidationMessage(Enums.ValidationMessageType.Error, "3", "ERROR"),
        };

        // Act
        var validationResult = new ValidationResult(validationMessageCollection);
        var emptyValidationResult = new ValidationResult();

        // Assert
        validationResult.Should().NotBeNull();
        validationResult.HasValidationMessage.Should().BeTrue();
        validationResult.HasError.Should().BeTrue();
        validationResult.IsValid.Should().BeFalse();

        validationResult.ValidationMessageCollection.Should().NotBeNull();
        validationResult.ValidationMessageCollection.Should().NotBeSameAs(validationResult.ValidationMessageCollection);
        validationResult.ValidationMessageCollection.Should().HaveCount(3);

        emptyValidationResult.Should().NotBeNull();
        emptyValidationResult.HasValidationMessage.Should().BeFalse();
        emptyValidationResult.HasError.Should().BeFalse();
        emptyValidationResult.IsValid.Should().BeTrue();

        emptyValidationResult.ValidationMessageCollection.Should().NotBeNull();
        emptyValidationResult.ValidationMessageCollection.Should().NotBeSameAs(validationResult.ValidationMessageCollection);
        emptyValidationResult.ValidationMessageCollection.Should().HaveCount(0);
    }

    [Fact]
    public void ValidationResult_Should_Valid()
    {
        // Arrange and Act
        var validationResult = new ValidationResult(new List<ValidationMessage>());

        // Assert
        validationResult.Should().NotBeNull();
        validationResult.HasValidationMessage.Should().BeFalse();
        validationResult.HasError.Should().BeFalse();
        validationResult.IsValid.Should().BeTrue();

        validationResult.ValidationMessageCollection.Should().NotBeNull();
        validationResult.ValidationMessageCollection.Should().NotBeSameAs(validationResult.ValidationMessageCollection);
        validationResult.ValidationMessageCollection.Should().HaveCount(0);
    }

    [Fact]
    public void ValidationResult_Should_Deep_Clone()
    {
        // Arrange
        var validationMessageCollection = new List<ValidationMessage>
        {
            new ValidationMessage(Enums.ValidationMessageType.Information, "1", "INFO"),
            new ValidationMessage(Enums.ValidationMessageType.Warning, "2", "WARNING"),
            new ValidationMessage(Enums.ValidationMessageType.Error, "3", "ERROR"),
        };
        var validationResult = new ValidationResult(validationMessageCollection);

        // Act
        var clonedValidationResult = validationResult.DeepClone();
        validationResult = new ValidationResult(new List<ValidationMessage>());

        // Assert

        clonedValidationResult.Should().NotBeSameAs(validationResult);
        clonedValidationResult.ValidationMessageCollection.Should().NotBeSameAs(validationResult.ValidationMessageCollection);
        clonedValidationResult.Should().NotBeNull();
        clonedValidationResult.HasValidationMessage.Should().BeTrue();
        clonedValidationResult.HasError.Should().BeTrue();
        clonedValidationResult.IsValid.Should().BeFalse();

        clonedValidationResult.ValidationMessageCollection.Should().NotBeNull();
        clonedValidationResult.ValidationMessageCollection.Should().NotBeSameAs(clonedValidationResult.ValidationMessageCollection);
        clonedValidationResult.ValidationMessageCollection.Should().HaveCount(3);
    }
}
