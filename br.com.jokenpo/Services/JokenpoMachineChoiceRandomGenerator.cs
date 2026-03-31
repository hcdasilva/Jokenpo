using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Services
{
    public class JokenpoMachineChoiceRandomGenerator : IJokenpoMachineChoiceGenerator
    {
        public JokenpoEscolhasEnum Gerar()
        {
            var values = Enum.GetValues<JokenpoEscolhasEnum>();
            return values[Random.Shared.Next(values.Length)];
        }
    }
}