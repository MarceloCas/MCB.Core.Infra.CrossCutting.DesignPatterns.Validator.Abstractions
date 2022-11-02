using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;

namespace Bechmarks.Benchs.ModelsBenchs;

[SimpleJob(RunStrategy.Throughput, launchCount: 1)]
[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
[MemoryDiagnoser]
[HtmlExporter]
public class ValidationMessageBench
{
    [Params(10, 1_000, 100_000, 1_000_000)]
    public int IterationCount { get; set; }

    [Benchmark(Baseline = true)]
    public ValidationMessage ValidationMessageDeclarationWithNoCharacter()
    {
        var lastValidationMessage = default(ValidationMessage);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationMessage = new ValidationMessage(
                ValidationMessageType: ValidationMessageType.Information,
                Code: string.Empty,
                Description: string.Empty
            );

            lastValidationMessage = validationMessage;
        }

        return lastValidationMessage;
    }

    [Benchmark]
    public ValidationMessage ValidationMessageDeclarationWith50Character()
    {
        var lastValidationMessage = default(ValidationMessage);
        var code = new string('a', 50);
        var description = new string('a', 50);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationMessage = new ValidationMessage(
                ValidationMessageType: ValidationMessageType.Information,
                Code: code,
                Description: description
            );

            lastValidationMessage = validationMessage;
        }

        return lastValidationMessage;
    }

    [Benchmark]
    public ValidationMessage ValidationMessageDeclarationWith100Character()
    {
        var lastValidationMessage = default(ValidationMessage);
        var code = new string('a', 100);
        var description = new string('a', 100);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationMessage = new ValidationMessage(
                ValidationMessageType: ValidationMessageType.Information,
                Code: code,
                Description: description
            );

            lastValidationMessage = validationMessage;
        }

        return lastValidationMessage;
    }

    [Benchmark]
    public ValidationMessage ValidationMessageDeclarationWith150Character()
    {
        var lastValidationMessage = default(ValidationMessage);
        var code = new string('a', 150);
        var description = new string('a', 150);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationMessage = new ValidationMessage(
                ValidationMessageType: ValidationMessageType.Information,
                Code: code,
                Description: description
            );

            lastValidationMessage = validationMessage;
        }

        return lastValidationMessage;
    }

    [Benchmark]
    public ValidationMessage ValidationMessageDeclarationWith250Character()
    {
        var lastValidationMessage = default(ValidationMessage);
        var code = new string('a', 250);
        var description = new string('a', 250);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationMessage = new ValidationMessage(
                ValidationMessageType: ValidationMessageType.Information,
                Code: code,
                Description: description
            );

            lastValidationMessage = validationMessage;
        }

        return lastValidationMessage;
    }

    [Benchmark]
    public ValidationMessage ValidationMessageDeclarationWith500Character()
    {
        var lastValidationMessage = default(ValidationMessage);
        var code = new string('a', 500);
        var description = new string('a', 500);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationMessage = new ValidationMessage(
                ValidationMessageType: ValidationMessageType.Information,
                Code: code,
                Description: description
            );

            lastValidationMessage = validationMessage;
        }

        return lastValidationMessage;
    }
}
