using System;

namespace EqualityStructs
{
    public struct StringFirst
    {
        private readonly string _str;

        private readonly Guid _tenant;

        public StringFirst(string first, Guid tenant)
        {
            _str = first;
            _tenant = tenant;
        }
    }
}
