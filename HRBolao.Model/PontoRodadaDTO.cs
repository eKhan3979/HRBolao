namespace HRBolao.Model
{
    public class PontoRodadaDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonatoJogo,
                    _golsCasaAposta,
                    _golsVisitanteAposta,
                    _golsCasa,
                    _golsVisitante,
                    _pontos,
                    _numero;

        private string _timeCasa = "",
                       _timeVisitante = "";

        #endregion

        #region Construtor

        public PontoRodadaDTO() { }

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
        public int GolsCasaAposta
        {
            get => _golsCasaAposta;
            set
            {
                if (_golsCasaAposta != value)
                {
                    _golsCasaAposta = value;
                    OnPropertyChanged(nameof(GolsCasaAposta));
                }
            }
        }
        public int GolsVisitanteAposta
        {
            get => _golsVisitanteAposta;
            set
            {
                if (_golsVisitanteAposta != value)
                {
                    _golsVisitanteAposta = value;
                    OnPropertyChanged(nameof(GolsVisitanteAposta));
                }
            }
        }
        public int GolsCasa
        {
            get => _golsCasa;
            set
            {
                if (_golsCasa != value)
                {
                    _golsCasa = value;
                    OnPropertyChanged(nameof(GolsCasa));
                }
            }
        }
        public int GolsVisitante
        {
            get => _golsVisitante;
            set
            {
                if (_golsVisitante != value)
                {
                    _golsVisitante = value;
                    OnPropertyChanged(nameof(GolsVisitante));
                }
            }
        }
        public string TimeCasa
        {
            get => _timeCasa;
            set
            {
                if (_timeCasa != value)
                {
                    _timeCasa = value;
                    OnPropertyChanged(nameof(TimeCasa));
                }
            }
        }
        public string TimeVisitante
        {
            get => _timeVisitante;
            set
            {
                if (_timeVisitante != value)
                {
                    _timeVisitante = value;
                    OnPropertyChanged(nameof(TimeVisitante));
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
        public int Numero
        {
            get => _numero;
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                    OnPropertyChanged(nameof(Numero));
                }
            }
        }

        #endregion
    }
}