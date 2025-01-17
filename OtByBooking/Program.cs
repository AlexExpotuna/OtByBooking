using Microsoft.Extensions.Configuration;
using OtByBooking.Repository;
using OtByBooking.Repository.Interfaces;

namespace OtByBooking;

internal static class Program
{
    private const bool ReloadOnChange = true;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        ApplicationConfiguration.Initialize();
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: ReloadOnChange);
        IConfiguration _configuration = builder.Build();
        IOtRepository _repository = new OtRepository(_configuration);
        Application.Run(new OtByBooking(_repository));
    }
}