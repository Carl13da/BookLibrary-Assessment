using BookLibrary.Application.QueryHandlers;
using BookLibrary.Application.Services;
using BookLibrary.Data.Contexts;
using BookLibrary.Data.Repositories;
using BookLibrary.Domain.Dto;
using BookLibrary.Domain.Events;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Domain.Interfaces.Services;
using BookLibrary.Domain.Queries;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<SqlContext>();

//ASP.NET HttpContenxt dependency
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// DOmain Bus (Mediator)
builder.Services.AddScoped<IMediatorHandler, InMemoryBus>();
builder.Services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

// Domain Service
builder.Services.AddScoped<IBookService, BookService>();

// Repos
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Domain Queries or Commands
builder.Services.AddScoped<IRequestHandler<SearchBooksQuery, List<BookDto>>, GetBooksQueryHandler>();

builder.Services.AddControllers();
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
