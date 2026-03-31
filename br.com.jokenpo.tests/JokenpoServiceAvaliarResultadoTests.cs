using br.com.jokenpo.Enums;

namespace br.com.jokenpo.tests;

public class JokenpoServiceAvaliarResultadoTests
{
    [Theory]
    [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Tesoura)]
    [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Pedra)]
    [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Papel)]
    public void DeveRetornarVitoria_QuandoJogadorTemCombinacaoVencedora(
        JokenpoEscolhasEnum escolhaJogador,
        JokenpoEscolhasEnum escolhaMaquina)
    {
        var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(JokenpoEscolhasEnum.Pedra);
        var resultado = service.AvaliarResultado(escolhaJogador, escolhaMaquina);

        Assert.Equal(JokenpoStatusEnum.Vitoria, resultado);
    }

    [Theory]
    [InlineData(JokenpoEscolhasEnum.Pedra)]
    [InlineData(JokenpoEscolhasEnum.Papel)]
    [InlineData(JokenpoEscolhasEnum.Tesoura)]
    public void DeveRetornarEmpate_QuandoEscolhasForemIguais(JokenpoEscolhasEnum escolha)
    {
        var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(JokenpoEscolhasEnum.Pedra);
        var resultado = service.AvaliarResultado(escolha, escolha);

        Assert.Equal(JokenpoStatusEnum.Empate, resultado);
    }

    [Theory]
    [InlineData(JokenpoEscolhasEnum.Pedra, JokenpoEscolhasEnum.Papel)]
    [InlineData(JokenpoEscolhasEnum.Papel, JokenpoEscolhasEnum.Tesoura)]
    [InlineData(JokenpoEscolhasEnum.Tesoura, JokenpoEscolhasEnum.Pedra)]
    public void DeveRetornarDerrota_QuandoJogadorTemCombinacaoPerdedora(
        JokenpoEscolhasEnum escolhaJogador,
        JokenpoEscolhasEnum escolhaMaquina)
    {
        var service = JokenpoServiceTestFactory.CriarComEscolhaDaMaquina(JokenpoEscolhasEnum.Pedra);
        var resultado = service.AvaliarResultado(escolhaJogador, escolhaMaquina);

        Assert.Equal(JokenpoStatusEnum.Derrota, resultado);
    }
}