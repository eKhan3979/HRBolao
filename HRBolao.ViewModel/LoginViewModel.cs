using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private EmpresaModel _empresaSelecionada = new();
        private JogadorModel _jogadorLogin = new();

        private List<EmpresaModel> _listaEmpresas = [];

        #endregion

        #region Construtor

        public LoginViewModel() { }

        #endregion

        #region Propriedades

        public EmpresaModel EmpresaSelecionada
        {
            get => _empresaSelecionada;
            set
            {
                if (_empresaSelecionada != value)
                {
                    _empresaSelecionada = value;
                    OnPropertyChanged(nameof(EmpresaSelecionada));

                    if (JogadorLogin == null)
                        JogadorLogin = new JogadorModel();

                    JogadorLogin.IdEmpresa = _empresaSelecionada.IdEmpresa;
                }
            }
        }

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

        public List<EmpresaModel> ListaEmpresas
        {
            get => _listaEmpresas;
            set
            {
                if (_listaEmpresas != value)
                {
                    _listaEmpresas = value;
                    OnPropertyChanged(nameof(ListaEmpresas));
                }
            }            
        }

        #endregion
    }
}