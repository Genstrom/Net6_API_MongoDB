using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.Services;

namespace EqspensesAPI.Data;

public class UnitOfWork : IUnitOfWork
{

    private readonly IMongoRepository<User> _userRepository;
    private readonly IMongoRepository<Expense> _expenseRepository;
    private readonly IExpenseMapper _expenseMapper;
    private readonly IExpenseViewModelMapper _expenseViewModelMapper;

    public UnitOfWork(IMongoRepository<User> userRepository, IMongoRepository<Expense> expenseRepository, IExpenseMapper expenseMapper, IExpenseViewModelMapper expenseViewModelMapper)
    {
        _userRepository = userRepository;
        _expenseRepository = expenseRepository;
        _expenseMapper = expenseMapper;
        _expenseViewModelMapper = expenseViewModelMapper;
    }

    public IUserService Users => new UserService(_userRepository);
    public IExpenseService Expenses => new ExpenseService(_expenseRepository,_expenseMapper, _userRepository, _expenseViewModelMapper);
}