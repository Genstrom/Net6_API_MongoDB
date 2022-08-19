using EqspensesAPI.Settings;

namespace EqspensesAPI.Entities;

[BsonCollection("expenses")]
public class Expense : Document
{
    public DateTime Date { get; set; }
    public string Specification { get; set; } = null!;
    public string Invoice { get; set; }
    public decimal TotalCost { get; set; }
    public decimal Vat { get; set; }
    public decimal ExVat { get; set; }
    public decimal VatPercent { get; set; }
    public string Currency { get; set; }
    public string ImageUrl { get; set; }
    public User User { get; set; }
}