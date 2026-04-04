using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;

namespace br.com.jokenpo.Services
{
    public interface IJokenpoService
    {
        JokenpoResultadoRodadaModel Jogar(JokenpoEscolhasEnum userChoiceEnum);
    }
}