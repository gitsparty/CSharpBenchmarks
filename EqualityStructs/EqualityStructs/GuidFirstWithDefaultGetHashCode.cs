using System;

namespace EqualityStructs
{
    public struct GuidFirstWithDefaultGetHashCode : IEquatable<GuidFirstWithDefaultGetHashCode>
    {
        private readonly Guid _tenant;

        private readonly string _str;

        public GuidFirstWithDefaultGetHashCode(string first, Guid tenant)
        {
            _str = first;
            _tenant = tenant;
        }

        public override bool Equals(object rhs)
        {
            return EqualPrivate(this, (GuidFirstWithDefaultGetHashCode)rhs);
        }

        public override int GetHashCode()
        {
            return _tenant.ToString().GetHashCode();
        }
        bool IEquatable<GuidFirstWithDefaultGetHashCode>.Equals(GuidFirstWithDefaultGetHashCode rhs)
        {
            return EqualPrivate(this, rhs);
        }

        bool EqualPrivate(GuidFirstWithDefaultGetHashCode lhs, GuidFirstWithDefaultGetHashCode rhs)
        {
            return lhs._tenant.Equals(rhs._tenant)
                && lhs._str.Equals(rhs._str, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
