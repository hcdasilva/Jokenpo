using br.com.jokenpo.Application;
using br.com.jokenpo.Services;
using br.com.jokenpo.Views;
using Moq;

namespace br.com.jokenpo.tests
{
    public class JokenpoApplicationTestFactory
    {
        internal static JokenpoApplication CriarComServiceEView(IJokenpoService service, IJokenpoView view)
        {
            return new JokenpoApplication(service, view, new Mock<Microsoft.Extensions.Logging.ILogger<JokenpoApplication>>().Object);
        }
    }
}