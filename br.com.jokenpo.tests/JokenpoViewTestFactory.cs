using br.com.jokenpo.Enums;
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
        
    }
}