using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Handlers;
using CollegeFootballApp.Application.Infrastructure;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Infrastructure;
using CollegeFootballApp.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var services = new ServiceCollection();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
services.AddTransient(typeof(UploadGameDataFromCsvCommandHandler));
services.AddTransient<ICsvFileService, CsvFileService>();
services.AddTransient<IUnitOfWork, UnitOfWork>();

// Add DbContext
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("YourConnectionStringHere"));

var serviceProvider = services.BuildServiceProvider();
var mediator = serviceProvider.GetService<IMediator>();

while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Process Games CSV");
    Console.WriteLine("2. Exit");
    Console.Write("Select an option (1/2): ");

    var choice = Console.ReadLine();

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