using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TicketUpService.Domain.Repository;
using TicketUpService.Repository.Contexts;
using TicketUpService.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddDbContext<TicketUpContext>(opt => opt.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Database=TicketUp;Trusted_Connection=True;MultipleActiveResultSets=true"));
    

builder.Services.AddTransient<IStoreRepository, StoreRepository>();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
