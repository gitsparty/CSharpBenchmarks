__C# Struct: comparison of Default Equality and GetHashCode Functions__


__TL;DR__

- Default equality comparators are ~10 times slower than their respective IEquatable<T> implementations. 

- When using a struct in collections like HashSet, provide IEquatable implementation for the struct. 

__Background__

These measurements are based on a blog article by Sergey Teplyakov. See https://blogs.msdn.microsoft.com/seteplia/2018/07/17/performance-implications-of-default-struct-equality-in-c/. 

The article points out that the default implementation of equality operator and GetHashCode function in a C# struct is sub optimal at best and unpredictable at worst. 

These measurements breakout the performance of GetHashCode vs. Equality operator. 

__Peformance of default Equality Operator (Equality Benchmark)__

Default equality comparators are ~10 times slower than their respective IEquatable<T> implementations. 


|                          Method |  N |        Mean |      Error |       StdDev |      Median | Rank |
|-------------------------------- |--- |------------:|-----------:|-------------:|------------:|-----:|
|                     StringFirst | 10 | 12,466.6 ns | 605.278 ns | 1,784.677 ns | 12,454.8 ns |    4 |
|                       GuidFirst | 10 | 11,739.2 ns | 510.061 ns | 1,503.928 ns | 12,014.4 ns |    3 |
|          GuidFirstWithEquatable | 10 |    794.7 ns |  55.060 ns |   162.344 ns |    740.7 ns |    2 |
| GuidFirstWithDefaultGetHashCode | 10 |    584.9 ns |   1.828 ns |     1.427 ns |    584.7 ns |    1 |



__Peformance of default GetHashCode Implementation (HashSet Benchmark)__

When a struct gets used in a HashSet, GetHashCode should distribute the hash evenly among all elements in the 

set. GuidFirstSameTenant does't distribute the hashcode evenly. GuidFirstWithEquatableSameTenant does. The 

performance difference between the two is around 17 times. 


|                                    Method |  N |       Mean |     Error |    StdDev |     Median | Rank |
|------------------------------------------ |--- |-----------:|----------:|----------:|-----------:|-----:|
|                               StringFirst | 10 |  11.278 us | 0.4549 us |  1.222 us |  11.652 us |    3 |
|                                 GuidFirst | 10 |  16.132 us | 0.6257 us |  1.845 us |  15.849 us |    4 |
|                     StringFirstSameTenant | 10 |  10.128 us | 0.5647 us |  1.665 us |  10.613 us |    2 |
|                       GuidFirstSameTenant | 10 | 124.214 us | 7.0020 us | 20.645 us | 132.795 us |    6 |
|          GuidFirstWithEquatableSameTenant | 10 |   7.756 us | 0.4093 us |  1.200 us |   7.882 us |    1 |
| GuidFirstWithDefaultGetHashCodeSameTenant | 10 |  23.735 us | 1.4718 us |  4.340 us |  20.888 us |    5 |

__Machine Configuration__

``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.14393.2608 (1607/AnniversaryUpdate/Redstone1)

Intel Xeon CPU E5640 2.67GHz, 2 CPU, 16 logical and 8 physical cores

Frequency=2597654 Hz, Resolution=384.9627 ns, Timer=TSC

  [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3221.0

  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3221.0


Job=Clr  Runtime=Clr  

```

