using br.com.jokenpo.Enums;
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
            InicializaPrompt();

            var valor = Console.ReadLine();

            var servicesCollection = new ServiceCollection();

            servicesCollection.AddScoped<IJokenpoMachineChoiceGenerator, JokenpoMachineChoiceRandomGenerator>();
            servicesCollection.AddScoped<IJokenpoService, JokenpoService>();
            servicesCollection.AddScoped<IJokenpoView, JokenpoView>();

            var serviceProvider = servicesCollection.BuildServiceProvider();

            IJokenpoService jokenpoService = serviceProvider.GetRequiredService<IJokenpoService>();
            IJokenpoView jokenpoView = serviceProvider.GetRequiredService<IJokenpoView>();
            
            if (!string.IsNullOrWhiteSpace(valor) && Enum.TryParse<JokenpoEscolhasEnum>(valor, out var userChoice))
            {
                JokenpoStatusEnum statusEnum = jokenpoService.Jogar(userChoice, out var machineChoice);
                
                jokenpoView.TratarResultado(userChoice, machineChoice, statusEnum);

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void InicializaPrompt()
    {
        Console.WriteLine("Bem vindo ao jogo Jokenpo do Banco Pan");
        Console.WriteLine("Nesse jogo você precisa escolher um valor de 0 a 2.");
        Console.WriteLine("Onde:");

        foreach (var choice in Enum.GetValues<JokenpoEscolhasEnum>())
        {
            Console.WriteLine($"{(int)choice} ({Enum.GetName(choice)})");
        }

        Console.WriteLine("Boa Sorte e Bom Jogo.");
    }
}