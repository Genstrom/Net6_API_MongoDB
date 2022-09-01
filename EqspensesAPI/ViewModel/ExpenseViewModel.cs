namespace EqspensesAPI.ViewModel;

public class ExpenseViewModel
{
    public string? Specification { get; set; }
    public DateTime Date { get; set; }
    public bool Invoice { get; set; }
    public decimal TotalCost { get; set; }
    public decimal VatAmount { get; set; }
    public decimal ExVatAmount { get; set; }
    public decimal VatPercentage { get; set; }
    public string? Currency { get; set; }
    public string? ImageUrl { get; set; }
}

public class ExpensePerMonthAndTotalCostViewModel
{
    public IEnumerable<ExpenseViewModel> ExpenseList { get; set; }
    public decimal TotalExpensesCost { get; set; }
}