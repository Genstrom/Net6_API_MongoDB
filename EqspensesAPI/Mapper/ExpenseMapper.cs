using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.ViewModel;

namespace EqspensesAPI.Mapper;

public class ExpenseMapper : IExpenseMapper
{
    public Expense Map(ExpenseViewModel model, User user)
    {
        return new()
        {
            Date = model.Date,
            Specification = model.Specification,
            Invoice = model.Invoice,
            TotalCost = model.TotalCost,
            Vat = model.VatAmount,
            ExVat = model.ExVatAmount,
            VatPercent = model.VatPercentage,
            Currency = model.Currency,
            ImageUrl = model.ImageUrl,
            MonthId = model.Date.Month,
            User = user,


        };
    }
}