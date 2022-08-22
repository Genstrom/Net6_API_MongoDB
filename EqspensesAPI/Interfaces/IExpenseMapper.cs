using EqspensesAPI.Entities;
using EqspensesAPI.ViewModel;

namespace EqspensesAPI.Interfaces;

public interface IExpenseMapper
{
    Expense Map(ExpenseViewModel model, User user);
}