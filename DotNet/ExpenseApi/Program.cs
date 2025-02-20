using Microsoft.EntityFrameworkCore;
using ExpenseApi.Data;
using ExpenseApi.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IExpenseService, ExpenseService>();

// Add services to the container.
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
