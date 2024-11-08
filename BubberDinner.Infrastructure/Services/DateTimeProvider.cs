using BubberDinner.Application.Common.Interfaces.Services;

namespace BubberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}