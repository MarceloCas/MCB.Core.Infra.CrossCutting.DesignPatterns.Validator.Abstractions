using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;
using System;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Tests.ModelsTests;

public class ValidationMessageTest
{
    [Fact]
    public void ValidationMessage_Should_Correctly_Initialized()
    {
        var validationMessageTypeCollection = Enum.GetValues<ValidationMessageType>();
        foreach (var validationMessageType in validationMessageTypeCollection)
        {
            // Arrange
            var code = Guid.NewGuid().ToString();
            var description = Guid.NewGuid().ToString();

            // Act
            var validationMessage = new ValidationMessage(validationMessageType, code, description);

            // Assert
            validationMessage.Should().NotBeNull();
            validationMessage.ValidationMessageType.Should().Be(validationMessageType);
            validationMessage.Code.Should().Be(code);
            validationMessage.Description.Should().Be(description);
        }
    }
}
