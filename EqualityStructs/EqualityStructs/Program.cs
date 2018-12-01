using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace EqualityStructs
{
    class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
