namespace ZenSquad.Domain.Common.Models;


// This File Copied From modular-monolith-with-ddd Repository
public abstract class IdValueBase : IEquatable<IdValueBase>
{

	public Guid Value { get; }

    protected IdValueBase(Guid value)
    {
        if (value == Guid.Empty)
        {
	        throw new ArgumentException("The ID value cannot be empty.", nameof(value));
        }

        Value = value;
    }

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}
	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}

		return obj is IdValueBase guidObj && Equals(guidObj);
	}
	public bool Equals(IdValueBase? other)
	{
		return this.Value == other?.Value;
	}


	public static bool operator ==(IdValueBase obj1, IdValueBase obj2)
	{
		if (Equals(obj1, null))
		{
			if (Equals(obj2, null))
			{
				return true;
			}

			return false;
		}

		return obj1.Equals(obj2);
	}

	public static bool operator !=(IdValueBase obj1, IdValueBase obj2)
	{
		return !(obj1 == obj2);
	}

}