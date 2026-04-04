using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;
using Microsoft.Extensions.Logging;

namespace br.com.jokenpo.Services
{
    public class JokenpoService(IJokenpoMachineChoiceGenerator machineChoiceGenerator, ILogger<JokenpoService> logger) : IJokenpoService
    {
        private readonly IJokenpoMachineChoiceGenerator _machineChoiceGenerator = machineChoiceGenerator;
        private readonly ILogger<JokenpoService> _logger = logger;

        public JokenpoResultadoRodadaModel Jogar(JokenpoEscolhasEnum userChoiceEnum)
        {
            var machineChoiceEnum = _machineChoiceGenerator.Gerar();
            var resultado = AvaliarResultado(userChoiceEnum, machineChoiceEnum);

            var rodada = new JokenpoResultadoRodadaModel
            {
                EscolhaJogador = userChoiceEnum,
                EscolhaMaquina = machineChoiceEnum,
                Resultado = resultado
            };

            _logger.LogDebug(
                "Dominio calculado. EscolhaUsuario: {EscolhaUsuario}; EscolhaMaquina: {EscolhaMaquina}; Resultado: {Resultado}",
                rodada.EscolhaJogador,
                rodada.EscolhaMaquina,
                rodada.Resultado);

            return rodada;
        }

        public JokenpoStatusEnum AvaliarResultado(JokenpoEscolhasEnum userChoiceEnum, JokenpoEscolhasEnum machineChoiceEnum)
        {
            JokenpoStatusEnum resultado = (userChoiceEnum, machineChoiceEnum) switch
            {
                (JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Tesoura) => JokenpoStatusEnum.Vitoria,
                (JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Papel) => JokenpoStatusEnum.Vitoria,
                (JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Pedra) => JokenpoStatusEnum.Vitoria,
                var (user, machine) when user == machine => JokenpoStatusEnum.Empate,
                _ => JokenpoStatusEnum.Derrota
            };

            return resultado;
        }
    }
}