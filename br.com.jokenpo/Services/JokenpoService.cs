using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Services
{
    public class JokenpoService(IJokenpoMachineChoiceGenerator machineChoiceGenerator) : IJokenpoService
    {
        private readonly IJokenpoMachineChoiceGenerator _machineChoiceGenerator = machineChoiceGenerator;

        public JokenpoStatusEnum Jogar(JokenpoEscolhasEnum userChoiceEnum, out JokenpoEscolhasEnum machineChoiceEnum)
        {
            machineChoiceEnum = _machineChoiceGenerator.Gerar();

            return AvaliarResultado(userChoiceEnum, machineChoiceEnum);
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