using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;
using br.com.jokenpo.Views;
using Moq;

namespace br.com.jokenpo.tests
{
    public class JokenpoViewTestFactory
    {
        internal static IJokenpoView CriarComEscolhaDoUsuario(JokenpoEscolhasEnum escolhaUsuario)
        {
            var mockView = new Mock<IJokenpoView>();
            mockView.Setup(v => v.ObterEscolhaDoUsuario()).Returns(escolhaUsuario);
            return mockView.Object;
        }

        internal static (IJokenpoView view, Func<JokenpoResultadoRodadaViewModel?> obterResultadoCapturado)
            CriarComEscolhaDoUsuarioECapturaDeResultado(JokenpoEscolhasEnum escolhaUsuario)
        {
            JokenpoResultadoRodadaViewModel? resultadoCapturado = null;

            var mockView = new Mock<IJokenpoView>();
            mockView.Setup(v => v.ObterEscolhaDoUsuario()).Returns(escolhaUsuario);
            mockView.Setup(v => v.TratarResultado(It.IsAny<JokenpoResultadoRodadaViewModel>()))
                .Callback<JokenpoResultadoRodadaViewModel>(resultado => resultadoCapturado = resultado);

            return (mockView.Object, () => resultadoCapturado);
        }
        
    }
}