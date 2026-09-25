namespace HRBolao.Model
{
    public class ApostaIdDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _idAposta,
                    _idCampeonatoJogo;

        #endregion

        #region Construtor

        public ApostaIdDTO() { }

        #endregion

        #region Propriedades

        public int IdAposta
        {
            get => _idAposta;
            set
            {
                if (_idAposta != value)
                {
                    _idAposta = value;
                    OnPropertyChanged(nameof(IdAposta));
                }
            }
        }
        public int IdCampeonatoJogo
        {
            get => _idCampeonatoJogo;
            set
            {
                if (_idCampeonatoJogo != value)
                {
                    _idCampeonatoJogo = value;
                    OnPropertyChanged(nameof(IdCampeonatoJogo));
                }
            }
        }

        #endregion
    }
}