namespace BubberDinner.Application.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}