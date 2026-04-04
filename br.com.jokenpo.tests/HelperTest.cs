using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;

namespace br.com.jokenpo.tests
{
    public static class HelperTest
    {
        public static void ValidaSaidaApplication(
            JokenpoEscolhasEnum usuario,
            JokenpoEscolhasEnum maquina,
            JokenpoStatusEnum statusEsperado,
            JokenpoResultadoRodadaViewModel? resultadoCapturado)
        {
            Assert.NotNull(resultadoCapturado);
            Assert.Equal(Enum.GetName(usuario), resultadoCapturado!.EscolhaJogador);
            Assert.Equal(Enum.GetName(maquina), resultadoCapturado.EscolhaMaquina);
            Assert.Equal(Enum.GetName(statusEsperado), resultadoCapturado.Resultado);
        }
    }
}