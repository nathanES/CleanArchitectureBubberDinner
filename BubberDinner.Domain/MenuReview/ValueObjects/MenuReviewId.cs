using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.MenuReview.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }
    
    public HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}