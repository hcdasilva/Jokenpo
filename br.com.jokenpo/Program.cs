using System.Diagnostics.CodeAnalysis;
using br.com.jokenpo.Application;
using br.com.jokenpo.Services;
using br.com.jokenpo.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace br.com.jokenpo;

[ExcludeFromCodeCoverage]
public class Program
{
    private static void Main(string[] args)
    {
        var servicesCollection = new ServiceCollection();

        servicesCollection.AddLogging(config =>
        {
            config.AddConsole();
            config.SetMinimumLevel(LogLevel.Information);
        });
        servicesCollection.AddScoped<IJokenpoMachineChoiceGenerator, JokenpoMachineChoiceRandomGenerator>();
        servicesCollection.AddScoped<IJokenpoService, JokenpoService>();
        servicesCollection.AddScoped<IJokenpoView, JokenpoView>();
        servicesCollection.AddScoped<IJokenpoApplication, JokenpoApplication>();

        using var serviceProvider = servicesCollection.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            IJokenpoApplication jokenpoApplication = serviceProvider.GetRequiredService<IJokenpoApplication>();

            jokenpoApplication.Jogar();
        }
        catch (ArgumentException ex)
        {
            logger.LogWarning(ex, "Entrada inválida informada pelo usuário.");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro inesperado na execução do Jokenpo.");
            Console.WriteLine("Ocorreu um erro inesperado. Tente novamente mais tarde.");
        }
    }
}