using ZenSquad.Domain.Common.Models;

namespace ZenSquad.Domain.Users.ValueObjects;

public class UserId : IdValueBase, IEquatable<UserId>
{
    public UserId(Guid value) : base(value) { }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != this.GetType())
            return false;

        return Equals((UserId)obj);
    }

    public override int GetHashCode() { return base.GetHashCode(); }
    public bool Equals(UserId? other) { return this.Value == other?.Value; }
}