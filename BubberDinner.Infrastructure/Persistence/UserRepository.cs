using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new List<User>();

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
        return _users.FirstOrDefault(user => user.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}