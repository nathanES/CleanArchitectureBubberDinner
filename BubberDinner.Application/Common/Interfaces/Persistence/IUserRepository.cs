using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
   User? GetUserByEmail(string email);
   void Add(User user); 
}