using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.ViewModel;

namespace EqspensesAPI.Mapper;

public class ExpenseViewModelMapper : IExpenseViewModelMapper
{
    public ExpensePerMonthAndTotalCostViewModel Map(IEnumerable<Expense> expenseList, decimal totalCost)
    {
        return new ExpensePerMonthAndTotalCostViewModel
        {
            ExpenseList = Map(expenseList),
            TotalExpensesCost = totalCost,
        };
    }

    public IEnumerable<ExpenseViewModel> Map(IEnumerable<Expense> expenseList)
    {
        return  expenseList.Select(e => new ExpenseViewModel
            {
                Specification = e.Specification,
                Date = e.Date,
                Invoice = e.Invoice,
                TotalCost = e.TotalCost,
                VatAmount = e.Vat,
                ExVatAmount = e.ExVat,
                VatPercentage = e.VatPercent,
                Currency = e.Currency,
                ImageUrl = e.ImageUrl

            })
            .ToList();
    }
}