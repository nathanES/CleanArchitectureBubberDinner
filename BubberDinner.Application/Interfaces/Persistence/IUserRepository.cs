using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Interfaces.Persistence;

public interface IUserRepository
{
   User? GetUserByEmail(string email);
   void Add(User user); 
}