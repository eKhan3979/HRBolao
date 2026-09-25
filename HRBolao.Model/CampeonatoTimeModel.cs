namespace HRBolao.Model
{
    public class CampeonatoTimeModel : BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonatoTime,
                    _idCampeonato,
                    _idTime;

        #endregion

        #region Construtor

        public CampeonatoTimeModel() { }

        #endregion

        #region Propriedades

        public int IdCampeonatoTime
        {
            get => _idCampeonatoTime;
            set
            {
                if (_idCampeonatoTime != value)
                {
                    _idCampeonatoTime = value;
                    OnPropertyChanged(nameof(IdCampeonatoTime));
                }
            }
        }
        public int IdCampeonato
        {
            get => _idCampeonato;
            set
            {
                if (_idCampeonato != value)
                {
                    _idCampeonato = value;
                    OnPropertyChanged(nameof(IdCampeonato));
                }
            }
        }
        public int IdTime
        {
            get => _idTime;
            set
            {
                if (_idTime != value)
                {
                    _idTime = value;
                    OnPropertyChanged(nameof(IdTime));
                }
            }
        }

        #endregion
    }
}