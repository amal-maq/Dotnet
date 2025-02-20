using Microsoft.EntityFrameworkCore;
using ExpenseApi.Data;
using ExpenseApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseApi.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseDbContext _context;

        public ExpenseService(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<Expense> CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateExpense(int id, Expense expense)
        {
            var existingExpense = await _context.Expenses.FindAsync(id);
            if (existingExpense == null) return null;

            existingExpense.Description = expense.Description;
            existingExpense.Amount = expense.Amount;
            existingExpense.Payer = expense.Payer;
            existingExpense.Participants = expense.Participants;
            existingExpense.Date = expense.Date;

            await _context.SaveChangesAsync();
            return existingExpense;
        }

        public async Task<bool> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
