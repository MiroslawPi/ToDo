using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using ToDo.Core.Repositories;
using ToDo.Infastructure.Data;
using ToDo.Infastructure.Mappers;
using ToDo.Infastructure.Repositories;
using ToDo.Infastructure.Services;


Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ToDoContext>());
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddScoped<IListOfTasksRepository, ListOfTasksRepository>();
builder.Services.AddScoped<IListOfTasksService, ListOfTasksService>();
//builder.Services.AddScoped<ITaskFromListRepository, TaskFromListRepositor>();
//builder.Services.AddScoped<ITaskFromListService, TaskFromListService>();
builder.Services.AddSingleton(AutoMapperConfig.Initialize());

//

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
