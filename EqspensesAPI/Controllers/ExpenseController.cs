using System.Net;
using EqspensesAPI.Authentication;
using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EqspensesAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/expenses")]
public class ExpenseController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ExpenseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    // GET
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Expense>> GetExpense()
    {
        var expense = await _unitOfWork.Expenses.GetExpensesAsync();

        return Ok(expense);
    }
    [Authorize]
    [HttpGet("find/User-Expenses")]
    public async Task<ActionResult<Expense>> GetUserExpenses()
    {
        var user = FirebaseAuthenticationHandler.GetUser();
        var expense = await _unitOfWork.Expenses.GetExpenseByUserGoogleId(user);

        return Ok(expense);
    }
    [Authorize]
    [HttpGet("find/User-Expenses-month/{month}")]
    public async Task<ActionResult<Expense>> GetUserExpenses(int month)
    {
        var user = FirebaseAuthenticationHandler.GetUser();
        var expense = await _unitOfWork.Expenses.GetUserExpenseByMonth(user, month);

        return Ok(expense);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] ExpenseViewModel expenseViewModel)
    {
        await _unitOfWork.Expenses.AddAsync(expenseViewModel);
        
        return StatusCode(201);
    }
}