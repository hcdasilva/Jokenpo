using System.Diagnostics.CodeAnalysis;
using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;
using Microsoft.Extensions.Logging;

namespace br.com.jokenpo.Views
{
    public class JokenpoView(ILogger<JokenpoView> logger) : IJokenpoView
    {
        private readonly ILogger<JokenpoView> _logger = logger;

        [ExcludeFromCodeCoverage]
        public void IniciarInstrucoes()
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

        public JokenpoEscolhasEnum ObterEscolhaDoUsuario()
        {
            var valor = Console.ReadLine();
            if (int.TryParse(valor, out var escolha) && Enum.IsDefined(typeof(JokenpoEscolhasEnum), escolha))
            {
                return (JokenpoEscolhasEnum)escolha;
            }

            throw new ArgumentException("Valor inválido. Por favor, insira um número entre 0 e 2.");
        }

        [ExcludeFromCodeCoverage]
        public void TratarResultado(JokenpoResultadoRodadaViewModel resultadoRodada)
        {
            Console.WriteLine($"Sua escolha: {resultadoRodada.EscolhaJogador}");
            Console.WriteLine($"Escolha da máquina: {resultadoRodada.EscolhaMaquina}");
            Console.WriteLine($"Resultado: {resultadoRodada.Resultado}");
        }
    }
}