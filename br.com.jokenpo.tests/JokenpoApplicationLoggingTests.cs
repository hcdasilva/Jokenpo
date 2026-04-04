using br.com.jokenpo.Application;
using br.com.jokenpo.Enums;
using br.com.jokenpo.Models;
using br.com.jokenpo.Services;
using br.com.jokenpo.Views;
using Microsoft.Extensions.Logging;
using Moq;

namespace br.com.jokenpo.tests
{
    public class JokenpoApplicationLoggingTests
    {
        [Fact]
        public void DeveRegistrarLogDeSucesso_QuandoRodadaFinalizaComSucesso()
        {
            var loggerMock = new Mock<ILogger<JokenpoApplication>>();
            var serviceMock = new Mock<IJokenpoService>();
            var viewMock = new Mock<IJokenpoView>();

            viewMock.Setup(v => v.ObterEscolhaDoUsuario()).Returns(JokenpoEscolhasEnum.Pedra);
            serviceMock.Setup(s => s.Jogar(JokenpoEscolhasEnum.Pedra)).Returns(new JokenpoResultadoRodadaModel
            {
                EscolhaJogador = JokenpoEscolhasEnum.Pedra,
                EscolhaMaquina = JokenpoEscolhasEnum.Tesoura,
                Resultado = JokenpoStatusEnum.Vitoria
            });

            var application = new JokenpoApplication(serviceMock.Object, viewMock.Object, loggerMock.Object);

            application.Jogar();

            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains("Rodada finalizada com sucesso.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);

            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Never);
        }

        [Fact]
        public void DeveRegistrarLogDeErro_QuandoRodadaFalha()
        {
            var loggerMock = new Mock<ILogger<JokenpoApplication>>();
            var serviceMock = new Mock<IJokenpoService>();
            var viewMock = new Mock<IJokenpoView>();
            var exception = new InvalidOperationException("Falha simulada.");

            viewMock.Setup(v => v.ObterEscolhaDoUsuario()).Returns(JokenpoEscolhasEnum.Pedra);
            serviceMock.Setup(s => s.Jogar(JokenpoEscolhasEnum.Pedra)).Throws(exception);

            var application = new JokenpoApplication(serviceMock.Object, viewMock.Object, loggerMock.Object);

            var thrown = Assert.Throws<InvalidOperationException>(() => application.Jogar());

            Assert.Equal(exception.Message, thrown.Message);

            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains("Rodada finalizada com erro.")),
                    exception,
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);

            viewMock.Verify(v => v.TratarResultado(It.IsAny<JokenpoResultadoRodadaViewModel>()), Times.Never);
        }
    }
}
