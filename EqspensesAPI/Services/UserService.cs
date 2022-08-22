using System.Security.Claims;
using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;

namespace EqspensesAPI.Services;

public class UserService : IUserService
{
    
    private readonly IMongoRepository<User> _userRepository;

    public UserService(IMongoRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task AddAsync(User user)
    {
        _userRepository.InsertOne(user);
        return Task.CompletedTask;
    }


    

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _userRepository.AsQueryable();
    }

    public async Task<User> GetUserByGoogleId(string googleId)
    {
        return await _userRepository.FindOneAsync(e => e.GoogleUserId == googleId);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.FindOneAsync(e => e.Email == email);
    }

    public Task<List<User>> GetUserByExpenseId(string expenseId)
    {
        throw new NotImplementedException();
    }

    public async Task Update(User user)
    {
        await _userRepository.ReplaceOneAsync(user);
    }

    public async Task Delete(User user)
    {
       await _userRepository.DeleteOneAsync(e => e.Id == user.Id);
    }

    public Task<bool> SaveAllChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckForDuplicate(string email)
    { 
        var user =  await _userRepository.FindOneAsync(u => u.Email == email);
        return user != null;
    }
}