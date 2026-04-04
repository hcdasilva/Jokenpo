using br.com.jokenpo.Enums;

namespace br.com.jokenpo.tests
{
    public class JokenpoApplicationJogarTests
    {
        [Theory]
        [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Tesoura)]
        [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Pedra)]
        [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Papel)]
        [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Pedra)]
        [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Papel)]
        [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Tesoura)]
        [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Papel)]
        [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Tesoura)]
        [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Pedra)]
        public void DeveRetornarSaidaEsperada(JokenpoEscolhasEnum usuario, JokenpoEscolhasEnum maquina)
        {
            var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(maquina);
            var (view, obterResultadoCapturado) = JokenpoViewTestFactory.CriarComEscolhaDoUsuarioECapturaDeResultado(usuario);

            var application = JokenpoApplicationTestFactory.CriarComServiceEView(service, view);
            application.Jogar();
            var resultadoCapturado = obterResultadoCapturado();

            var statusEsperado = service.AvaliarResultado(usuario, maquina);

            HelperTest.ValidaSaidaApplication(usuario, maquina, statusEsperado, resultadoCapturado);
        }
    }
}