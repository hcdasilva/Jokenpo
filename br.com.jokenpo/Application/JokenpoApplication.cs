using System.Diagnostics;
using br.com.jokenpo.Models;
using br.com.jokenpo.Services;
using br.com.jokenpo.Views;
using Microsoft.Extensions.Logging;

namespace br.com.jokenpo.Application
{
    public class JokenpoApplication(IJokenpoService jokenpoService, IJokenpoView jokenpoView, ILogger<JokenpoApplication> logger) : IJokenpoApplication
    {
        private readonly IJokenpoService _jokenpoService = jokenpoService;
        private readonly IJokenpoView _jokenpoView = jokenpoView;
        private readonly ILogger<JokenpoApplication> _logger = logger;

        public void Jogar()
        {
            var cronometro = Stopwatch.StartNew();
            string? escolhaUsuario = null;
            string? escolhaMaquina = null;
            string? resultado = null;

            try
            {
                _logger.LogInformation("Rodada iniciada.");
                _jokenpoView.IniciarInstrucoes();

                var userChoice = _jokenpoView.ObterEscolhaDoUsuario();
                escolhaUsuario = Enum.GetName(userChoice) ?? userChoice.ToString();
                _logger.LogInformation("Entrada recebida. EscolhaUsuario: {EscolhaUsuario}", escolhaUsuario);

                var resultadoRodada = _jokenpoService.Jogar(userChoice);

                JokenpoResultadoRodadaViewModel rodadaViewModel = new()
                {
                    EscolhaJogador = Enum.GetName(resultadoRodada.EscolhaJogador) ?? string.Empty,
                    EscolhaMaquina = Enum.GetName(resultadoRodada.EscolhaMaquina) ?? string.Empty,
                    Resultado = Enum.GetName(resultadoRodada.Resultado) ?? string.Empty
                };

                escolhaMaquina = rodadaViewModel.EscolhaMaquina;
                resultado = rodadaViewModel.Resultado;

                _jokenpoView.TratarResultado(rodadaViewModel);
                _logger.LogInformation(
                    "Rodada finalizada com sucesso. EscolhaUsuario: {EscolhaUsuario}; EscolhaMaquina: {EscolhaMaquina}; Resultado: {Resultado}; DuracaoMs: {DuracaoMs}",
                    escolhaUsuario,
                    escolhaMaquina,
                    resultado,
                    cronometro.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Rodada finalizada com erro. EscolhaUsuario: {EscolhaUsuario}; EscolhaMaquina: {EscolhaMaquina}; Resultado: {Resultado}; DuracaoMs: {DuracaoMs}",
                    escolhaUsuario,
                    escolhaMaquina,
                    resultado,
                    cronometro.ElapsedMilliseconds);
                throw;
            }
        }
    }
}