using Application.Configuration.Extentions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql("Host=localhost;Port=8410;Database=catito_database;Username=catito_user;Password=secret"));
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
