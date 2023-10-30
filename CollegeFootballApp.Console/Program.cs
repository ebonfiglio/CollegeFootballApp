using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Handlers;
using CollegeFootballApp.Application.Infrastructure;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Infrastructure;
using CollegeFootballApp.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Reflection;

var services = new ServiceCollection();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UploadGameDataFromCsvCommandHandler).Assembly));
services.AddTransient<ICsvFileService, CsvFileService>();
services.AddTransient<IUnitOfWork, UnitOfWork>();

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

IConfiguration configuration = builder.Build();

// Add DbContext
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


var serviceProvider = services.BuildServiceProvider();
var mediator = serviceProvider.GetService<IMediator>();



while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Process Games CSV");
    Console.WriteLine("2. Exit");
    Console.Write("Select an option (1/2): ");

    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter the path to the CSV file: ");
                var filePath = Console.ReadLine();

                // Create and send the command using MediatR
                var command = new UploadGameDataFromCsvCommand { FilePath = filePath };
                var result = await mediator.Send(command);

                if (result)
                {
                    Console.WriteLine("Games processed successfully!");
                }
                else
                {
                    Console.WriteLine("An error occurred while processing the games.");
                }
                break;
            case "2":
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.InnerException?.Message);
    }
}