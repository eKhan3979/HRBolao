using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class MnLoginViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private JogadorModel _jogadorLogin = new();

        #endregion

        #region Construtor

        public MnLoginViewModel() { }

        #endregion

        #region Propriedades

        public JogadorModel JogadorLogin
        {
            get => _jogadorLogin;
            set
            {
                if (_jogadorLogin != value)
                {
                    _jogadorLogin = value;
                    OnPropertyChanged(nameof(JogadorLogin));
                }
            }
        }

        #endregion
    }
}