namespace HRBolao.Model
{
    public class JogoDTO : BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonatoJogo;
        private string _yyyy_Mm_Dd = "",
                       _hh_Mm = "";
        private int _idTimeCasa;
        private string _timeCasa = "";
        private int _golsTimeCasa,
                    _idTimeVisitante;
        private string _timeVisitante = "";
        private int _golsTimeVisitante,
                    _penaltisTimeCasa,
                    _penaltisTimeVisitante;
        private bool _mataMata,
                     _prorrogacao,
                     _disputaPenaltis,
                     _finalizado,
                     _adiado,
                     _cancelado;
        private int _numero,
                    _idAposta;
        private int _golsTimeCasaOriginal,
                    _golsTimeVisitanteOriginal;
        private string _background = "";

        #endregion

        #region Construtor

        public JogoDTO() { }

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
        public int PenaltisTimeCasa
        {
            get => _penaltisTimeCasa;
            set
            {
                if (_penaltisTimeCasa != value)
                {
                    _penaltisTimeCasa = value;
                    OnPropertyChanged(nameof(PenaltisTimeCasa));
                }
            }
        }
        public int PenaltisTimeVisitante
        {
            get => _penaltisTimeVisitante;
            set
            {
                if (_penaltisTimeVisitante != value)
                {
                    _penaltisTimeVisitante = value;
                    OnPropertyChanged(nameof(PenaltisTimeVisitante));
                }
            }
        }
        public bool MataMata
        {
            get => _mataMata;
            set
            {
                if (_mataMata != value)
                {
                    _mataMata = value;
                    OnPropertyChanged(nameof(MataMata));
                }
            }
        }
        public bool Prorrogacao
        {
            get => _prorrogacao;
            set
            {
                if (_prorrogacao != value)
                {
                    _prorrogacao = value;
                    OnPropertyChanged(nameof(Prorrogacao));
                }
            }
        }
        public bool DisputaPenaltis
        {
            get => _disputaPenaltis;
            set
            {
                if (_disputaPenaltis != value)
                {
                    _disputaPenaltis = value;
                    OnPropertyChanged(nameof(DisputaPenaltis));
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
        public string Dd_Mm_Yyyy
        {
            get
            {
                if ((!string.IsNullOrWhiteSpace(Yyyy_Mm_Dd)) && (Yyyy_Mm_Dd.Length == 10))
                    return Yyyy_Mm_Dd.Substring(8, 2) + "/" +
                           Yyyy_Mm_Dd.Substring(5, 2) + "/" +
                           Yyyy_Mm_Dd.Substring(0, 4);
                else
                    return "";
            }
        }
        public string ProrrogacaoSim
        {
            get { return (Prorrogacao ? "Sim" : "-"); }
        }
        public string PenaltisSim
        {
            get { return (DisputaPenaltis ? "Sim" : "-"); }
        }
        public bool Editavel
        {
            get => (!Finalizado && !Cancelado);
        }
        public string JogoEncerrado
        {
            get { return ((Finalizado) ? "(Jogo encerrado)" : ""); }
        }
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
        public int GolsTimeCasaOriginal
        {
            get => _golsTimeCasaOriginal;
            set
            {
                if (_golsTimeCasaOriginal != value) 
                {
                    _golsTimeCasaOriginal = value;
                    OnPropertyChanged(nameof(GolsTimeCasaOriginal));
                }
            }
        }
        public int GolsTimeVisitanteOriginal
        {
            get => _golsTimeVisitanteOriginal;
            set
            {
                if (_golsTimeVisitanteOriginal != value)
                {
                    _golsTimeVisitanteOriginal = value;
                    OnPropertyChanged(nameof(GolsTimeVisitanteOriginal));
                }
            }
        }

        public string Background
        {
            get => _background;
            set
            {
                if (_background != value)
                {
                    _background = value;
                    OnPropertyChanged(nameof(Background));
                }
            }
        }

        #endregion
    }
}