# Friday Learning Sessions

## Benchmarks

Benchmarks are run on a countdown song from 1.000.000 to 0 bottles.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i5-7600K CPU 3.80GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
### Song Inline
| Method |     Mean |   Error |  StdDev |
|------- |---------:|--------:|--------:|
| Recite | 133.5 ms | 1.86 ms | 1.74 ms |


### Song Composition

| Method |     Mean |   Error |  StdDev |
|------- |---------:|--------:|--------:|
| Recite | 301.1 ms | 2.69 ms | 2.39 ms |


### Song Inheritance

| Method |     Mean |   Error |  StdDev |
|------- |---------:|--------:|--------:|
| Recite | 234.6 ms | 4.63 ms | 4.55 ms |
