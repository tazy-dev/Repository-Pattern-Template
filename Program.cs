using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Repository_Pattern_Template.Data;
using Repository_Pattern_Template.Models;
using Repository_Pattern_Template.Repository.implementations;
using Repository_Pattern_Template.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var mongoDbSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
var client = new MongoClient(mongoDbSettings!.ConnectionString);
builder.Services.Configure <MongoDBSettings> (builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddDbContext<StudentDatabaseContext>(option => option.UseMongoDB(client,mongoDbSettings!.DatabaseName));

builder.Services.AddScoped<StudentDatabaseContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
