using EqspensesAPI.Authentication;
using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.Mapper;
using EqspensesAPI.ViewModel;
using MongoDB.Driver;

namespace EqspensesAPI.Services;

public class ExpenseService : IExpenseService
{
    private readonly IMongoRepository<Expense> _expenseRepository;
    private readonly IMongoRepository<User> _userRepository;
    private readonly IExpenseMapper _expenseMapper;
    private readonly IExpenseViewModelMapper _expenseViewModelMapper;
    
    public ExpenseService(IMongoRepository<Expense> expenseRepository, IExpenseMapper expenseMapper, IMongoRepository<User> userRepository, IExpenseViewModelMapper expenseViewModelMapper)
    {
        _expenseRepository = expenseRepository;
        _expenseMapper = expenseMapper;
        _userRepository = userRepository;
        _expenseViewModelMapper = expenseViewModelMapper;
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

        var expenses = await _expenseRepository.FilterBy(e => e.User.Equals(user) );
        return expenses;
    }

    public async Task<ExpensePerMonthAndTotalCostViewModel> GetUserExpenseByMonth(User user, int month)
    {
        var expenses =  await _expenseRepository.FilterBy(e => e.User.Equals(user) && e.MonthId.Equals(month));
        var totalCost = GetTotalCosts(expenses);
        var totalCostAndExpensesPerMonth = _expenseViewModelMapper.Map(expenses, totalCost);
        return totalCostAndExpensesPerMonth;
    }

    public Task Update(Expense expense)
    {
        throw new NotImplementedException();
    }

    public decimal GetTotalCosts(IEnumerable<Expense> expenseList)
    {
        return expenseList.Sum(e => e.TotalCost);
    }

    public async Task Delete(string id)
    {
        await _expenseRepository.DeleteOneAsync(e => e.Id.Equals(id));
    }
}