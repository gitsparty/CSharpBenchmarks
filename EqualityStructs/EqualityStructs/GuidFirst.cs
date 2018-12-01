using System;

namespace EqualityStructs
{
    public struct GuidFirst
    {
        private readonly Guid _tenant;

        private readonly string _str;

        public GuidFirst(string first, Guid tenant)
        {
            _str = first;
            _tenant = tenant;
        }
    }
}
