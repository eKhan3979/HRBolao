namespace HRBolao.Model
{
    public class JogoCampeonatoDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonatoJogo,
                    _rodada;
        private string _yyyy_Mm_Dd = "",
                       _hh_Mm = "";
        private int _idTimeCasa;
        private string _timeCasa = "";
        private int _golsTimeCasa,
                    _idTimeVisitante;
        private string _timeVisitante = "";
        private int _golsTimeVisitante;
        private bool _finalizado,
                    _adiado,
                    _cancelado;

        #endregion

        #region Construtor

        public JogoCampeonatoDTO() { }

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
        public string Yyyy_Mm_Dd
        {
            get => _yyyy_Mm_Dd;
            set
            {
                if (_yyyy_Mm_Dd != value)
                {
                    _yyyy_Mm_Dd = value;
                    OnPropertyChanged(nameof(Yyyy_Mm_Dd));
                }
            }
        }
        public string Hh_Mm
        {
            get => _hh_Mm;
            set
            {
                if (_hh_Mm != value)
                {
                    _hh_Mm = value;
                    OnPropertyChanged(nameof(Hh_Mm));
                }
            }
        }
        public int IdTimeCasa
        {
            get => _idTimeCasa;
            set
            {
                if (_idTimeCasa != value)
                {
                    _idTimeCasa = value;
                    OnPropertyChanged(nameof(IdTimeCasa));
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
        public int IdTimeVisitante
        {
            get => _idTimeVisitante;
            set
            {
                if (_idTimeVisitante != value)
                {
                    _idTimeVisitante = value;
                    OnPropertyChanged(nameof(IdTimeVisitante));
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
        public bool Finalizado
        {
            get => _finalizado;
            set
            {
                if (_finalizado != value)
                {
                    _finalizado = value;
                    OnPropertyChanged(nameof(Finalizado));
                }
            }
        }
        public bool Adiado
        {
            get => _adiado;
            set
            {
                if (_adiado != value)
                {
                    _adiado = value;
                    OnPropertyChanged(nameof(Adiado));
                }
            }
        }
        public bool Cancelado
        {
            get => _cancelado;
            set
            {
                if (_cancelado != value)
                {
                    _cancelado = value;
                    OnPropertyChanged(nameof(Cancelado));
                }
            }
        }

        #endregion
    }
}