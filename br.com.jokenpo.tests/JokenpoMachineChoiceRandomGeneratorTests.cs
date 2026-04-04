using br.com.jokenpo.Enums;
using br.com.jokenpo.Services;

namespace br.com.jokenpo.tests;

public class JokenpoMachineChoiceRandomGeneratorTests
{
    [Fact]
    public void Gerar_DeveRetornarValorValidoDoEnum()
    {
        var sut = new JokenpoMachineChoiceRandomGenerator();

        var resultado = sut.Gerar();

        Assert.True(Enum.IsDefined(resultado));
    }

    [Fact]
    public void Gerar_EmMultiplasExecucoes_DeveSempreRetornarValorValido()
    {
        var sut = new JokenpoMachineChoiceRandomGenerator();

        for (var i = 0; i < 500; i++)
        {
            var resultado = sut.Gerar();
            Assert.True(Enum.IsDefined(resultado));
        }
    }
}