using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;

public record struct ValidationMessage(
    ValidationMessageType ValidationMessageType,
    string Code,
    string Description
);