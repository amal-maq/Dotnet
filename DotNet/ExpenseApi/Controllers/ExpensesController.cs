using Microsoft.AspNetCore.Mvc;
using ExpenseApi.Models;
using ExpenseApi.Services;

namespace ExpenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/expenses
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _expenseService.GetAllExpenses();
            return Ok(expenses);
        }

        // GET: api/expenses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpense(int id)
        {
            var expense = await _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound("Expense not found");
            }
            return Ok(expense);
        }

        // POST: api/expenses
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense)
        {
            if (expense.Amount < 0)
            {
                return BadRequest("Amount should be non-negative.");
            }

            var createdExpense = await _expenseService.CreateExpense(expense);
            return CreatedAtAction(nameof(GetExpense), new { id = createdExpense.Id }, createdExpense);
        }

        // PUT: api/expenses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] Expense expense)
        {
            if (expense.Amount < 0)
            {
                return BadRequest("Amount should be non-negative.");
            }

            var updatedExpense = await _expenseService.UpdateExpense(id, expense);
            if (updatedExpense == null)
            {
                return NotFound("Expense not found");
            }

            return Ok(updatedExpense);
        }

        // DELETE: api/expenses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var success = await _expenseService.DeleteExpense(id);
            if (!success)
            {
                return NotFound("Expense not found");
            }

            return NoContent();
        }
    }
}
