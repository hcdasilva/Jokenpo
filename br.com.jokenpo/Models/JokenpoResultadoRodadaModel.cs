using br.com.jokenpo.Enums;

namespace br.com.jokenpo.Models
{
    public class JokenpoResultadoRodadaModel
    {
        public JokenpoEscolhasEnum EscolhaJogador { get; set; }
        public JokenpoEscolhasEnum EscolhaMaquina { get; set; }
        public JokenpoStatusEnum Resultado { get; set; }
    }
}