namespace HRBolao.Model
{
    public class RankingEmpresaDTO: BaseModel
    {
        #region Variáveis da Classe

        private string _nomeApelido = "";
        private int _idJogador,
                    _pontos;

        #endregion

        #region Construtor

        public RankingEmpresaDTO() { }

        #endregion

        #region Propriedades

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
        public int Pontos
        {
            get => _pontos;
            set
            {
                if (_pontos != value)
                {
                    _pontos = value;
                    OnPropertyChanged(nameof(Pontos));
                }
            }
        }

        #endregion
    }
}