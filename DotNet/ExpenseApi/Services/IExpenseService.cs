using ExpenseApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseApi.Services
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);
        Task<Expense> CreateExpense(Expense expense);
        Task<Expense> UpdateExpense(int id, Expense expense);
        Task<bool> DeleteExpense(int id);
    }
}
