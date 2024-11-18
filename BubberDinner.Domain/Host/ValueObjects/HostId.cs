using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Host.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    
    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}