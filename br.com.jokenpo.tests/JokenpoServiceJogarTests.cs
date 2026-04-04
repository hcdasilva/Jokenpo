using br.com.jokenpo.Enums;

namespace br.com.jokenpo.tests;

public class JokenpoServiceJogarTests
{
    [Theory]
    [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Tesoura, JokenpoStatusEnum.Vitoria)]
    [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Pedra, JokenpoStatusEnum.Vitoria)]
    [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Papel, JokenpoStatusEnum.Vitoria)]
    public void DeveUsarEscolhaDaMaquinaMockadaECalcularVitoria(
        JokenpoEscolhasEnum escolhaJogador,
        JokenpoEscolhasEnum escolhaMaquinaMockada,
        JokenpoStatusEnum statusEsperado)
    {
        var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(escolhaMaquinaMockada);

        var resultado = service.Jogar(escolhaJogador);

        Assert.Equal(escolhaMaquinaMockada, resultado.EscolhaMaquina);
        Assert.Equal(statusEsperado, resultado.Resultado);
    }

    [Theory]
    [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Pedra)]
    [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Papel)]
    [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Tesoura)]
    public void DeveUsarEscolhaDaMaquinaMockadaECalcularEmpate(
        JokenpoEscolhasEnum escolhaJogador,
        JokenpoEscolhasEnum escolhaMaquinaMockada)
    {
        var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(escolhaMaquinaMockada);

        var resultado = service.Jogar(escolhaJogador);

        Assert.Equal(escolhaMaquinaMockada, resultado.EscolhaMaquina);
        Assert.Equal(JokenpoStatusEnum.Empate, resultado.Resultado);
    }

    [Theory]
    [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Papel)]
    [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Tesoura)]
    [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Pedra)]
    public void DeveUsarEscolhaDaMaquinaMockadaECalcularDerrota(
        JokenpoEscolhasEnum escolhaJogador,
        JokenpoEscolhasEnum escolhaMaquinaMockada)
    {
        var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(escolhaMaquinaMockada);

        var resultado = service.Jogar(escolhaJogador);

        Assert.Equal(escolhaMaquinaMockada, resultado.EscolhaMaquina);
        Assert.Equal(JokenpoStatusEnum.Derrota, resultado.Resultado);
    }
}