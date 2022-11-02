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
public class ValidationResultBench
{
    [Params(1, 10, 100, 1_000)]
    public int IterationCount { get; set; }

    private static ValidationMessage CreateValidationMessage() => new(
        ValidationMessageType: ValidationMessageType.Error,
        Code: new string('a', 50),
        Description: new string('a', 50)
    );

    [Benchmark(Baseline = true)]
    public ValidationResult ValidationResultDeclarationWithNoValidationMessages()
    {
        var lastValidationResult = default(ValidationResult);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationResult = new ValidationResult();

            lastValidationResult = validationResult;
        }

        return lastValidationResult;
    }

    [Benchmark]
    public ValidationResult ValidationResultDeclarationWith3ValidationMessages()
    {
        var lastValidationResult = default(ValidationResult);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationResult = new ValidationResult(
                new[]
                {
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                }
            );

            lastValidationResult = validationResult;
        }

        return lastValidationResult;
    }

    [Benchmark]
    public ValidationResult ValidationResultDeclarationWith5ValidationMessages()
    {
        var lastValidationResult = default(ValidationResult);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationResult = new ValidationResult(
                new[]
                {
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                }
            );

            lastValidationResult = validationResult;
        }

        return lastValidationResult;
    }

    [Benchmark]
    public ValidationResult ValidationResultDeclarationWith10ValidationMessages()
    {
        var lastValidationResult = default(ValidationResult);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationResult = new ValidationResult(
                new[]
                {
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                }
            );

            lastValidationResult = validationResult;
        }

        return lastValidationResult;
    }

    [Benchmark]
    public ValidationResult ValidationResultDeclarationWith20ValidationMessages()
    {
        var lastValidationResult = default(ValidationResult);

        for (int i = 0; i < IterationCount; i++)
        {
            var validationResult = new ValidationResult(
                new[]
                {
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                    CreateValidationMessage(),
                }
            );

            lastValidationResult = validationResult;
        }

        return lastValidationResult;
    }
}
