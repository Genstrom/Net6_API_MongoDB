using System.Security.Claims;
using EqspensesAPI.Entities;

namespace EqspensesAPI.Interfaces;

public interface IUserService
{
    Task AddAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByGoogleId(string googleId);
    Task<User> GetUserByEmail(string email);
    Task<List<User>> GetUserByExpenseId(string expenseId);
    Task Update(User user);
    Task Delete(User user);
    Task<bool> SaveAllChangesAsync();
    Task<bool> CheckForDuplicate(string email);
}