using br.com.jokenpo.Enums;
using br.com.jokenpo.Services;
using Moq;

namespace br.com.jokenpo.tests;

internal static class JokenpoServiceTestFactory
{
    internal static JokenpoService CriarComEscolhaDaMaquina(JokenpoEscolhasEnum escolhaDaMaquina)
    {
        var machineChoiceGeneratorMock = new Mock<IJokenpoMachineChoiceGenerator>();
        machineChoiceGeneratorMock.Setup(generator => generator.Gerar()).Returns(escolhaDaMaquina);
        return new JokenpoService(machineChoiceGeneratorMock.Object, new Mock<Microsoft.Extensions.Logging.ILogger<JokenpoService>>().Object);
    }
}