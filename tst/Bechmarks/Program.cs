using Bechmarks.Benchs.ModelsBenchs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(typeof(ValidationResultBench).Assembly);