using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Views
{
    public interface IJokenpoView
    {
        void TratarResultado(JokenpoEscolhasEnum userChoiceEnum, JokenpoEscolhasEnum machineChoiceEnum, JokenpoStatusEnum statusEnum);
    }
}