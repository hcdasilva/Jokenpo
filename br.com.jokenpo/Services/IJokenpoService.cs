using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Services
{
    public interface IJokenpoService
    {
        JokenpoStatusEnum Jogar(JokenpoEscolhasEnum userChoiceEnum, out JokenpoEscolhasEnum machineChoiceEnum);
    }
}