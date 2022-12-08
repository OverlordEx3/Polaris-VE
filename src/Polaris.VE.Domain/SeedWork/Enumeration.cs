namespace Polaris.VE.Domain.SeedWork;

public abstract class Enumeration : IComparable<Enumeration>, IComparable
{
    protected Enumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

#pragma warning disable CS8618
    private Enumeration() { }
#pragma warning restore CS8618

    public int Id { get; private set; }
    public string Name { get; private set; }

    public int CompareTo(Enumeration? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }   
        
        if (other is null)
        {
            return 1;
        }   
        
        return Id.CompareTo(other.Id);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (ReferenceEquals(this, obj))
        {
            return 0;
        }

        return obj is Enumeration other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Enumeration)}");
    }
}