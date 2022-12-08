namespace Polaris.VE.Domain.SeedWork;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }
    protected bool IsTransient => Id.Equals(default);
    private int? _requestedHashCode = null;


    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }   
        
        if (ReferenceEquals(this, other))
        {
            return true;
        }   
        
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Entity other && Equals(other);
    }

    public override int GetHashCode()
    {
        if (IsTransient)
        {
            return base.GetHashCode();
        }

        if (_requestedHashCode is null)
        {
            _requestedHashCode = HashCode.Combine(Id);
        }

        return _requestedHashCode.Value;
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (left is null)
        {
            return right is null;
        }

        if (ReferenceEquals(left, right))
        {
            return true;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}