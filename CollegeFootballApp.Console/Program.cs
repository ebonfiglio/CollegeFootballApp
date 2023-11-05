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

var services = new ServiceCollection();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UploadGameDataFromCsvCommandHandler).Assembly));
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpsertTeamCommandHandler).Assembly));
services.AddTransient<IReadFileService, JsonFileService>();
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
    Console.WriteLine("1. Process Game file");
    Console.WriteLine("2. Process Team file");
    Console.WriteLine("3. Exit");
    Console.Write("Select an option: ");

    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter the path to the JSON file: ");
                string filePath = Console.ReadLine();

                // Create and send the command using MediatR
                UploadGameDataFromCsvCommand command = new(filePath);
                bool result = await mediator.Send(command);

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
                Console.Write("Enter the path to the JSON file: ");
                string teamFilePath = Console.ReadLine();

                // Create and send the command using MediatR
                UpsertTeamCommand teamCommand = new(teamFilePath);
                bool teamResult = await mediator.Send(teamCommand);

                if (teamResult)
                {
                    Console.WriteLine("Teams processed successfully!");
                }
                else
                {
                    Console.WriteLine("An error occurred while processing the teams.");
                }
                break;
            case "3":
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