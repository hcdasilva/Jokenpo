using br.com.jokenpo.Application;
using br.com.jokenpo.Services;
using br.com.jokenpo.Views;
using Microsoft.Extensions.DependencyInjection;

namespace br.com.jokenpo;

public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var servicesCollection = new ServiceCollection();

            servicesCollection.AddScoped<IJokenpoMachineChoiceGenerator, JokenpoMachineChoiceRandomGenerator>();
            servicesCollection.AddScoped<IJokenpoService, JokenpoService>();
            servicesCollection.AddScoped<IJokenpoView, JokenpoView>();
            servicesCollection.AddScoped<IJokenpoApplication, JokenpoApplication>();

            var serviceProvider = servicesCollection.BuildServiceProvider();

            IJokenpoApplication jokenpoApplication = serviceProvider.GetRequiredService<IJokenpoApplication>();

            jokenpoApplication.Jogar();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}