using EqspensesAPI.Entities;
using EqspensesAPI.ViewModel;

namespace EqspensesAPI.Interfaces;

public interface IExpenseViewModelMapper
{
    public ExpensePerMonthAndTotalCostViewModel Map (IEnumerable<Expense> _expenseList, decimal totalCost);
    public IEnumerable<ExpenseViewModel> Map(IEnumerable<Expense> _expenseList);
}