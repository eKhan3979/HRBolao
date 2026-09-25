namespace HRBolao.Model
{
    public class MeusPontosDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _rodada,
                    _pontos;

        #endregion

        #region Construtor
        
        public MeusPontosDTO() { }

        #endregion

        #region Propriedades

        public int Rodada
        {
            get => _rodada;
            set
            {
                if (_rodada != value)
                {
                    _rodada = value;
                    OnPropertyChanged(nameof(Rodada));
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