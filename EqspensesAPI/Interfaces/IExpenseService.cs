using EqspensesAPI.Entities;
using EqspensesAPI.ViewModel;

namespace EqspensesAPI.Interfaces;

public interface IExpenseService
{
    Task AddAsync(ExpenseViewModel expenseViewModel);
    Task<IEnumerable<Expense>> GetExpensesAsync();
    Task<Expense> GetExpenseByExpenseId(string expenseId);
    Task<IEnumerable<Expense>> GetExpenseByUserGoogleId(User user);
    Task<ExpensePerMonthAndTotalCostViewModel> GetUserExpenseByMonth(User user, int month);
    Task Update(Expense expense);

    Decimal GetTotalCosts(IEnumerable<Expense> expenseList);
    Task Delete(string id);
}