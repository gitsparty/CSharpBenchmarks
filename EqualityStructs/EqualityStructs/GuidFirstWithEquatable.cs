using System;

namespace EqualityStructs
{
    public struct GuidFirstWithEquatable : IEquatable<GuidFirstWithEquatable>
    {
        private readonly Guid _tenant;

        private readonly string _str;

        public GuidFirstWithEquatable(string first, Guid tenant)
        {
            _str = first;
            _tenant = tenant;
        }

        public override bool Equals(object rhs)
        {
            return EqualPrivate(this, (GuidFirstWithEquatable)rhs);
        }

        public override int GetHashCode()
        {
            return (_tenant.ToString() + _str ?? string.Empty).GetHashCode();
        }
        bool IEquatable<GuidFirstWithEquatable>.Equals(GuidFirstWithEquatable rhs)
        {
            return EqualPrivate(this, rhs);
        }

        bool EqualPrivate(GuidFirstWithEquatable lhs, GuidFirstWithEquatable rhs)
        {
            return lhs._tenant.Equals(rhs._tenant)
                && lhs._str.Equals(rhs._str, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
