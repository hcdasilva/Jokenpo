using br.com.jokenpo.Enums;
using br.com.jokenpo.Services;
using br.com.jokenpo.Views;

namespace br.com.jokenpo.Application
{
    public class JokenpoApplication(IJokenpoService jokenpoService, IJokenpoView jokenpoView) : IJokenpoApplication
    {
        private readonly IJokenpoService _jokenpoService = jokenpoService;
        private readonly IJokenpoView _jokenpoView = jokenpoView;

        private JokenpoEscolhasEnum _userChoice;
        private JokenpoEscolhasEnum _machineChoice;
        private JokenpoStatusEnum _statusEnum;
        public JokenpoStatusEnum Status => _statusEnum;
        public void Jogar()
        {
            _jokenpoView.IniciarInstrucoes();
            _userChoice = _jokenpoView.ObterEscolhaDoUsuario();
            _statusEnum = _jokenpoService.Jogar(_userChoice, out _machineChoice);
            _jokenpoView.TratarResultado(_userChoice, _machineChoice, _statusEnum);
        }
    }
}