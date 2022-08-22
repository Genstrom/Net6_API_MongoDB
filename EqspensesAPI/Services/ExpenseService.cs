using EqspensesAPI.Authentication;
using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.ViewModel;
using MongoDB.Driver;

namespace EqspensesAPI.Services;

public class ExpenseService : IExpenseService
{
    private readonly IMongoRepository<Expense> _expenseRepository;
    private readonly IMongoRepository<User> _userRepository;
    private readonly IExpenseMapper _expenseMapper;
    
    public ExpenseService(IMongoRepository<Expense> expenseRepository, IExpenseMapper expenseMapper, IMongoRepository<User> userRepository)
    {
        _expenseRepository = expenseRepository;
        _expenseMapper = expenseMapper;
        _userRepository = userRepository;
    }
    
    public async Task AddAsync(ExpenseViewModel expenseViewModel)
    {
        var user = FirebaseAuthenticationHandler.GetUser();

        var userFromDb = await _userRepository.FindOneAsync(u => u.Email == user!.Email);

        if (userFromDb == null)
        {
            await _userRepository.InsertOneAsync(user!);
        }

        var expense = _expenseMapper.Map(expenseViewModel, user!);

         await _expenseRepository.InsertOneAsync(expense);
    }
    
    public async Task<IEnumerable<Expense>> GetExpensesAsync()
    {
        return  await _expenseRepository.AsQueryable();
    }
    
    public Task<Expense> GetExpenseByExpenseId(string expenseId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<Expense>> GetExpenseByUserGoogleId(User user)
    {

        var expenses = await Task.FromResult(_expenseRepository.FilterBy(e => e.User.Equals(user) ));
        return expenses;
    }

    public async Task<IEnumerable<Expense>> GetUserExpenseByMonth(User user, int month)
    {
        var expenses = await Task.FromResult(_expenseRepository.FilterBy(e => e.User.Equals(user) && e.Date.Month.Equals(month) ));
        return expenses;
    }

    public Task Update(Expense expense)
    {
        throw new NotImplementedException();
    }
    
    public Task Delete(Expense expense)
    {
        throw new NotImplementedException();
    }
}