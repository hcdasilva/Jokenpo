using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Views
{
    public class JokenpoView : IJokenpoView
    {

        public void TratarResultado(JokenpoEscolhasEnum userChoiceEnum, JokenpoEscolhasEnum machineChoiceEnum, JokenpoStatusEnum statusEnum)
        {
            Console.WriteLine($"Sua escolha: {Enum.GetName(userChoiceEnum)}");
            Console.WriteLine($"Escolha da máquina: {Enum.GetName(machineChoiceEnum)}");
            Console.WriteLine($"Resultado: {Enum.GetName<JokenpoStatusEnum>(statusEnum)}");
        }
    }
}