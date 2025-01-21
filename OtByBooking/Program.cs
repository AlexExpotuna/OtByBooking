using Microsoft.Extensions.Configuration;
using OtByBooking.Repository;
using OtByBooking.Repository.Interfaces;
using OtByBooking.Services;
using OtByBooking.Services.Interfaces;

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
        IClipboardService _clipboardService = new ClipboardService();
        IOtRepository _repository =
            new OtTestRepository(); // test
            //new OtRepository(_configuration); // Production
        IOtService _otService = new OtService(_repository);

        Application.Run(new OtByBooking(_otService, _clipboardService));
    }
}