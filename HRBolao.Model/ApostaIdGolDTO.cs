namespace HRBolao.Model
{
    public class ApostaIdGolDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonatoJogo,
                    _golsTimeCasa,
                    _golsTimeVisitante;

        #endregion

        #region Construtor

        public ApostaIdGolDTO() { }

        #endregion

        #region Propriedades

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
        public int GolsTimeCasa
        {
            get => _golsTimeCasa;
            set
            {
                if (_golsTimeCasa != value)
                {
                    _golsTimeCasa = value;
                    OnPropertyChanged(nameof(GolsTimeCasa));
                }
            }
        }
        public int GolsTimeVisitante
        {
            get => _golsTimeVisitante;
            set
            {
                if (_golsTimeVisitante != value)
                {
                    _golsTimeVisitante = value;
                    OnPropertyChanged(nameof(GolsTimeVisitante));
                }
            }
        }

        #endregion
    }
}