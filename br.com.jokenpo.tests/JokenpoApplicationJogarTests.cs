using br.com.jokenpo.Enums;

namespace br.com.jokenpo.tests
{
    public class JokenpoApplicationJogarTests
    {
        [Theory]
        [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Pedra)]
        [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Papel)]
        [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Tesoura)]
        public void TestarEmpate(JokenpoEscolhasEnum usuario, JokenpoEscolhasEnum maquina)
        {
            var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(maquina);
            var view = JokenpoViewTestFactory.CriarComEscolhaDoUsuario(usuario);

            var application = JokenpoApplicationTestFactory.CriarComServiceEView(service, view);
            application.Jogar();

            Assert.Equal(JokenpoStatusEnum.Empate, application.Status);
        }

        [Theory]
        [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Tesoura)]
        [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Pedra)]
        [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Papel)]
        public void TestarVitoria(JokenpoEscolhasEnum usuario, JokenpoEscolhasEnum maquina)
        {
            var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(maquina);
            var view = JokenpoViewTestFactory.CriarComEscolhaDoUsuario(usuario);

            var application = JokenpoApplicationTestFactory.CriarComServiceEView(service, view);
            application.Jogar();

            Assert.Equal(JokenpoStatusEnum.Vitoria, application.Status);
        }

        [Theory]
        [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Papel)]
        [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Tesoura)]
        [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Pedra)]
        public void TestarDerrota(JokenpoEscolhasEnum usuario, JokenpoEscolhasEnum maquina)
        {
            var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(maquina);
            var view = JokenpoViewTestFactory.CriarComEscolhaDoUsuario(usuario);

            var application = JokenpoApplicationTestFactory.CriarComServiceEView(service, view);
            application.Jogar();

            Assert.Equal(JokenpoStatusEnum.Derrota, application.Status);
        }
    }
}