using BankingApplication.Application.Handler;
using BankingApplication.Application.Interfaces;
using BankingApplication.Application.Validators;
using BankingApplication.Domain.AccountFactory;
using BankingApplication.Domain.AccountFactory.Interface;
using BankingApplication.Infrastructure.Data;
using BankingApplication.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<CreateAccountHandler>());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAccountFactory,SavingAccountFactory>();

builder.Services.AddScoped<IAccountFactory,CurrentAccountFactory>();

builder.Services.AddScoped<IAccountFactoryProvider,AccountFactoryProvider>();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountCommandValidator>();

builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

