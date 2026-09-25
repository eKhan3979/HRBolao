namespace HRBolao.Model
{
    public class JogadorRankingDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _idJogador;
        private string _nomeApelido = "",
                       _email = "";
        private int _totalPontos;

        #endregion

        #region Construtor

        public JogadorRankingDTO() { }

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
        public int TotalPontos
        {
            get => _totalPontos;
            set
            {
                if (_totalPontos != value)
                {
                    _totalPontos = value;
                    OnPropertyChanged(nameof(TotalPontos));
                }
            }
        }

        #endregion
    }
}