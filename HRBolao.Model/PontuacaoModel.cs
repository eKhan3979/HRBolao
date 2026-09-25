namespace HRBolao.Model
{
    public class PontuacaoModel: BaseModel
    {
        #region Variáveis da Classe

        private int _idPontuacao;
        private string _descricao = "";
        private int _pontos;

        #endregion

        #region Construtor

        public PontuacaoModel() { }

        #endregion

        #region Propriedades

        public int IdPontuacao
        {
            get => _idPontuacao;
            set
            {
                if (_idPontuacao != value)
                {
                    _idPontuacao = value;
                    OnPropertyChanged(nameof(IdPontuacao));
                }
            }
        }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (_descricao != value)
                {
                    _descricao = value;
                    OnPropertyChanged(nameof(Descricao));
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