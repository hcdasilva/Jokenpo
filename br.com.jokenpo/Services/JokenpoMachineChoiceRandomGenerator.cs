using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;
using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Services
{
    public class JokenpoMachineChoiceRandomGenerator : IJokenpoMachineChoiceGenerator
    {
        public JokenpoEscolhasEnum Gerar()
        {
            try
            {
                var values = Enum.GetValues<JokenpoEscolhasEnum>();
                return values[Random.Shared.Next(values.Length)];
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar escolha da máquina: " + ex.Message);
            }
        }
    }
}