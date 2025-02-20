using System;

namespace ExpenseApi.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }=string.Empty;
        public decimal Amount { get; set; }
        public string Payer { get; set; }=string.Empty;
        public string Participants { get; set; }=string.Empty;
        public DateTime Date { get; set; }
    }
}
