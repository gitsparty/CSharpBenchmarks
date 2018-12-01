using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace EqualityStructs
{
    [ClrJob]
    [RankColumn]
    public class EqualityBenchmark
    {
        StringFirst[] stringFirst;
        GuidFirst[] guidFirst;
        GuidFirstWithEquatable[] guidFirstWithEquatable;
        GuidFirstWithDefaultGetHashCode[] guidFirstWithDefaultGetHashCode;

        [Params(10)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            Guid tenantId = Guid.NewGuid();
            stringFirst = new StringFirst[N];
            guidFirst = new GuidFirst[N];
            guidFirstWithEquatable = new GuidFirstWithEquatable[N];
            guidFirstWithDefaultGetHashCode = new GuidFirstWithDefaultGetHashCode[N];

            for (int i = 0; i < N; i++)
            {
                Guid g = Guid.NewGuid();
                stringFirst[i] = new StringFirst(g.ToString(), g);
                guidFirst[i] = new GuidFirst(g.ToString(), g);
                guidFirstWithEquatable[i] = new GuidFirstWithEquatable(g.ToString(), g);
                guidFirstWithDefaultGetHashCode[i] = new GuidFirstWithDefaultGetHashCode(g.ToString(), g);
            }
        }

        [Benchmark]
        public void StringFirst()
        {
            for (int i = 0; i < N; i++)
            {
                if (!stringFirst[i].Equals(stringFirst[i]))
                {
                    throw new Exception("What?");
                }
            }
        }

        [Benchmark]
        public void GuidFirst()
        {
            for (int i = 0; i < N; i++)
            {
                if (!guidFirst[i].Equals(guidFirst[i]))
                {
                    throw new Exception("What?");
                }
            }
        }

        [Benchmark]
        public void GuidFirstWithEquatable()
        {
            for (int i = 0; i < N; i++)
            {
                if (!guidFirstWithEquatable[i].Equals(guidFirstWithEquatable[i]))
                {
                    throw new Exception("What?");
                }
            }
        }

        [Benchmark]
        public void GuidFirstWithDefaultGetHashCode()
        {
            for (int i = 0; i < N; i++)
            {
                if (!guidFirstWithDefaultGetHashCode[i].Equals(guidFirstWithDefaultGetHashCode[i]))
                {
                    throw new Exception("What?");
                }
            }
        }
    }
}
