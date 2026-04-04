using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;

namespace br.com.jokenpo.Views
{
    public interface IJokenpoView
    {
        void IniciarInstrucoes();
        JokenpoEscolhasEnum ObterEscolhaDoUsuario();
        void TratarResultado(JokenpoResultadoRodadaViewModel resultadoRodada);
    }
}