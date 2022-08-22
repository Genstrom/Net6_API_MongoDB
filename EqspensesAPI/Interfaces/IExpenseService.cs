using EqspensesAPI.Entities;
using EqspensesAPI.ViewModel;

namespace EqspensesAPI.Interfaces;

public interface IExpenseService
{
    Task AddAsync(ExpenseViewModel expenseViewModel);
    Task<IEnumerable<Expense>> GetExpensesAsync();
    Task<Expense> GetExpenseByExpenseId(string expenseId);
    Task<IEnumerable<Expense>> GetExpenseByUserGoogleId(User user);
    Task<IEnumerable<Expense>> GetUserExpenseByMonth(User user, int month);
    Task Update(Expense expense);
    Task Delete(Expense expense);
}