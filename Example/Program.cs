using StrictlyTyped.EntityFramework;
using System.Reflection;
using TodoApi.Models;
using StrictlyTyped.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoContext>(opt =>
{
    opt.UseSqlite(@"Data Source=.\Todos.db;Mode=ReadWrite");
    opt.EnableSensitiveDataLogging();
    opt.EnableDetailedErrors();
    opt.LogTo(Console.WriteLine);
    opt.AddStrictTypeConverters();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.UseStrictTypesDefinedIn(Assembly.GetExecutingAssembly());
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
