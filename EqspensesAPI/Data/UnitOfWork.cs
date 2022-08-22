using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.Services;

namespace EqspensesAPI.Data;

public class UnitOfWork : IUnitOfWork
{

    private readonly IMongoRepository<User> _userRepository;
    private readonly IMongoRepository<Expense> _expenseRepository;
    private readonly IExpenseMapper _expenseMapper;

    public UnitOfWork(IMongoRepository<User> userRepository, IMongoRepository<Expense> expenseRepository, IExpenseMapper expenseMapper)
    {
        _userRepository = userRepository;
        _expenseRepository = expenseRepository;
        _expenseMapper = expenseMapper;
    }

    public IUserService Users => new UserService(_userRepository);
    public IExpenseService Expenses => new ExpenseService(_expenseRepository,_expenseMapper, _userRepository);
}