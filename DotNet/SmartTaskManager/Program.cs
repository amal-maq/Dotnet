using Microsoft.EntityFrameworkCore;
using SmartTaskManager.Data;
using SmartTaskManager.Models; 
using SmartTaskManager.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add SQLite database context
        builder.Services.AddDbContext<TaskDbContext>(options =>
            options.UseSqlite("Data Source=tasks.db"));
        builder.Services.AddScoped<ITaskService, TaskService>();

        // Add services to the container.
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
