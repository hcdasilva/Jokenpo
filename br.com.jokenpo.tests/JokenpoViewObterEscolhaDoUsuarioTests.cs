using br.com.jokenpo.Enums;
using br.com.jokenpo.Views;

namespace br.com.jokenpo.tests;

public class JokenpoViewObterEscolhaDoUsuarioTests
{
    [Theory]
    [InlineData("0", JokenpoEscolhasEnum.Pedra)]
    [InlineData("1", JokenpoEscolhasEnum.Papel)]
    [InlineData("2", JokenpoEscolhasEnum.Tesoura)]
    public void DeveRetornarEscolhaQuandoValorForValido(string input, JokenpoEscolhasEnum escolhaEsperada)
    {
        var originalInput = Console.In;

        try
        {
            Console.SetIn(new StringReader(input));
            var view = new JokenpoView();

            var escolha = view.ObterEscolhaDoUsuario();

            Assert.Equal(escolhaEsperada, escolha);
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("3")]
    [InlineData("-1")]
    public void DeveLancarArgumentExceptionQuandoValorForInvalido(string input)
    {
        var originalInput = Console.In;

        try
        {
            Console.SetIn(new StringReader(input));
            var view = new JokenpoView();

            var exception = Assert.Throws<ArgumentException>(() => view.ObterEscolhaDoUsuario());

            Assert.Equal("Valor inválido. Por favor, insira um número entre 0 e 2.", exception.Message);
        }
        finally
        {
            Console.SetIn(originalInput);
        }
    }
}
