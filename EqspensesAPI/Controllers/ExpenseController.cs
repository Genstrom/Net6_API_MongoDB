using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EqspensesAPI.Controllers;

[ApiController]
[Route("api/expenses")]
public class ExpenseController : Controller
{
    private readonly IMongoRepository<Expense> _unitOfWork;

    public ExpenseController(IMongoRepository<Expense> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    // GET

    [HttpGet]
    public async Task<ActionResult<Expense>> Get()
    {
        var expense = await _unitOfWork.AsQueryable();

        return Ok(expense);
    }

    [HttpPost]
    public async Task Post([FromBody] Expense expenseViewModel)
    {
        await _unitOfWork.InsertOneAsync(expenseViewModel);
    }
}