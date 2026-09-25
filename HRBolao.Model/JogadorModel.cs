namespace HRBolao.Model
{
    public class JogadorModel : BaseModel
    {
        #region Variáveis da Classe

        private int _idJogador,
                    _idEmpresa;
        private string _nomeApelido = "",
                       _senha = "",
                       _email = "";
        private DateTime _dataCadastro;
        private bool _ativo,
                     _administrador;

        #endregion

        #region Construtor

        public JogadorModel() { }

        #endregion

        #region Propriedades

        public int IdJogador
        {
            get => _idJogador;
            set
            {
                if (_idJogador != value)
                {
                    _idJogador = value;
                    OnPropertyChanged(nameof(IdJogador));
                }
            }
        }
        public int IdEmpresa
        {
            get => _idEmpresa;
            set
            {
                if (_idEmpresa != value)
                {
                    _idEmpresa = value;
                    OnPropertyChanged(nameof(IdEmpresa));
                }
            }
        }
        public string NomeApelido
        {
            get => _nomeApelido;
            set
            {
                if (_nomeApelido != value)
                {
                    _nomeApelido = value;
                    OnPropertyChanged(nameof(NomeApelido));
                }
            }
        }
        public string Senha
        {
            get => _senha;
            set
            {
                if (_senha != value)
                {
                    _senha = value;
                    OnPropertyChanged(nameof(Senha));
                }
            }
        }
        public string email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(email));
                }
            }
        }
        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set
            {
                if (_dataCadastro != value)
                {
                    _dataCadastro = value;
                    OnPropertyChanged(nameof(DataCadastro));
                }
            }
        }
        public bool Ativo
        {
            get => _ativo;
            set
            {
                if (_ativo != value)
                {
                    _ativo = value;
                    OnPropertyChanged(nameof(Ativo));
                }
            }
        }
        public bool Administrador
        {
            get => _administrador;
            set
            {
                if (_administrador != value)
                {
                    _administrador = value;
                    OnPropertyChanged(nameof(Administrador));
                }
            }
        }

        #endregion
    }
}