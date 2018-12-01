using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace EqualityStructs
{
    [ClrJob]
    [RankColumn]
    public class HashSetBenchmark
    {
        StringFirst[] stringFirst;
        GuidFirst[] guidFirst;
        StringFirst[] stringFirstSameTenant;
        GuidFirst[] guidFirstSameTenant;
        GuidFirstWithEquatable[] guidFirstWithEquatableSameTenant;
        GuidFirstWithDefaultGetHashCode[] guidFirstWithDefaultGetHashCodeTenant;

        [Params(10)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            Guid tenantId = Guid.NewGuid();
            stringFirst = new StringFirst[N];
            guidFirst = new GuidFirst[N];
            stringFirstSameTenant = new StringFirst[N];
            guidFirstSameTenant = new GuidFirst[N];
            guidFirstWithEquatableSameTenant = new GuidFirstWithEquatable[N];
            guidFirstWithDefaultGetHashCodeTenant = new GuidFirstWithDefaultGetHashCode[N];

            for (int i = 0; i < N; i++)
            {
                Guid g = Guid.NewGuid();
                stringFirst[i] = new StringFirst(g.ToString(), g);
                guidFirst[i] = new GuidFirst(g.ToString(), g);
                stringFirstSameTenant[i] = new StringFirst(g.ToString(), tenantId);
                guidFirstSameTenant[i] = new GuidFirst(g.ToString(), tenantId);
                guidFirstWithEquatableSameTenant[i] = new GuidFirstWithEquatable(g.ToString(), tenantId);
                guidFirstWithDefaultGetHashCodeTenant[i] = new GuidFirstWithDefaultGetHashCode(g.ToString(), tenantId);
            }
        }

        [Benchmark]
        public void StringFirst()
        {
            var set = new HashSet<StringFirst>();

            for (int i = 0; i < N; i++)
            {
                if (!set.Contains(stringFirst[i]))
                {
                    set.Add(stringFirst[i]);
                }
            }
        }

        [Benchmark]
        public void GuidFirst()
        {
            var set = new HashSet<GuidFirst>();

            for (int i = 0; i < N; i++)
            {
                if (!set.Contains(guidFirst[i]))
                {
                    set.Add(guidFirst[i]);
                }
            }
        }

        [Benchmark]
        public void StringFirstSameTenant()
        {
            var set = new HashSet<StringFirst>();

            for (int i = 0; i < N; i++)
            {
                if (!set.Contains(stringFirstSameTenant[i]))
                {
                    set.Add(stringFirstSameTenant[i]);
                }
            }
        }

        [Benchmark]
        public void GuidFirstSameTenant()
        {
            var set = new HashSet<GuidFirst>();

            for (int i = 0; i < N; i++)
            {
                if (!set.Contains(guidFirstSameTenant[i]))
                {
                    set.Add(guidFirstSameTenant[i]);
                }
            }
        }

        [Benchmark]
        public void GuidFirstWithEquatableSameTenant()
        {
            var set = new HashSet<GuidFirstWithEquatable>();

            for (int i = 0; i < N; i++)
            {
                if (!set.Contains(guidFirstWithEquatableSameTenant[i]))
                {
                    set.Add(guidFirstWithEquatableSameTenant[i]);
                }
            }
        }

        [Benchmark]
        public void GuidFirstWithDefaultGetHashCodeSameTenant()
        {
            var set = new HashSet<GuidFirstWithDefaultGetHashCode>();

            for (int i = 0; i < N; i++)
            {
                if (!set.Contains(guidFirstWithDefaultGetHashCodeTenant[i]))
                {
                    set.Add(guidFirstWithDefaultGetHashCodeTenant[i]);
                }
            }
        }

    }
}
