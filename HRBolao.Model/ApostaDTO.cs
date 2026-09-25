namespace HRBolao.Model
{
    public class ApostaDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonatoJogo;
        private string _yyyy_Mm_Dd = "",
                       _hh_Mm = "";
        private int _idTimeCasa;
        private string _timeCasa = "";
        private int? _golsTimeCasa;
        private int _idTimeVisitante;
        private string _timeVisitante = "";
        private int? _golsTimeVisitante;
        private int _penaltisTimeCasa,
                    _penaltisTimeVisitante;
        private bool _adiado,
                     _cancelado,
                     _disputaPenaltis,
                     _editavel,
                     _emAndamento,
                     _finalizado,
                     _mataMata,
                     _prorrogacao,
                     _verResultado;
        private int? _idAposta;
        private int? _golsApostaTimeCasa,
                     _golsApostaTimeVisitante;

        private int _pontos;

        private int _numero;

        private int? _golsCasaOriginal,
                     _golsVisitanteOriginal;

        #endregion

        #region Construtor

        public ApostaDTO() { }
        public ApostaDTO(ApostaJogoDTO aposta)
        {
            IdCampeonatoJogo = aposta.IdCampeonatoJogo;
            Yyyy_Mm_Dd = aposta.Yyyy_Mm_Dd;
            Hh_Mm = aposta.Hh_Mm;
            IdTimeCasa = aposta.IdTimeCasa;
            TimeCasa = aposta.TimeCasa;
            GolsTimeCasa = aposta.GolsTimeCasa;
            IdTimeVisitante = aposta.IdTimeVisitante;
            TimeVisitante = aposta.TimeVisitante;
            GolsTimeVisitante = aposta.GolsTimeVisitante;
            PenaltisTimeCasa = aposta.PenaltisTimeCasa;
            PenaltisTimeVisitante = aposta.PenaltisTimeVisitante;
            MataMata = aposta.MataMata;
            Prorrogacao = aposta.Prorrogacao;
            DisputaPenaltis = aposta.DisputaPenaltis;
            Finalizado = aposta.Finalizado;
            Adiado = aposta.Adiado;
            Cancelado = aposta.Cancelado;
            IdAposta = aposta.IdAposta;
            GolsApostaTimeCasa = aposta.GolsApostaTimeCasa;
            GolsApostaTimeVisitante = aposta.GolsApostaTimeVisitante;
        }

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
        public int? GolsTimeCasa
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
        public int? GolsTimeVisitante
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
        public int? IdAposta
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
        public int? GolsApostaTimeCasa
        {
            get => _golsApostaTimeCasa;
            set
            {
                if (_golsApostaTimeCasa != value)
                {
                    _golsApostaTimeCasa = value;
                    OnPropertyChanged(nameof(GolsApostaTimeCasa));
                }
            }
        }
        public int? GolsApostaTimeVisitante
        {
            get => _golsApostaTimeVisitante;
            set
            {
                if (_golsApostaTimeVisitante != value)
                {
                    _golsApostaTimeVisitante = value;
                    OnPropertyChanged(nameof(GolsApostaTimeVisitante));
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
        public int? GolsCasaOriginal
        {
            get => _golsCasaOriginal;
            set
            {
                if (_golsCasaOriginal != value)
                {
                    _golsCasaOriginal = value;
                    OnPropertyChanged(nameof(GolsCasaOriginal));
                }
            }
        }
        public int? GolsVisitanteOriginal
        {
            get => _golsVisitanteOriginal;
            set
            {
                if (_golsVisitanteOriginal != value)
                {
                    _golsVisitanteOriginal = value;
                    OnPropertyChanged(nameof(GolsVisitanteOriginal));
                }
            }
        }

        public bool Editavel
        {
            get => _editavel;
            set
            {
                if (_editavel != value)
                {
                    _editavel = value;
                    OnPropertyChanged(nameof(Editavel));
                }
            }
        }

        public bool EmAndamento
        {
            get => _emAndamento;
            set
            {
                if (_emAndamento != value)
                {
                    _emAndamento = value;
                    OnPropertyChanged(nameof(EmAndamento));
                }
            }
        }

        public string Dd_Mm_Yyyy
        {
            get => Yyyy_Mm_Dd.Substring(8, 2) + "/" +
                   Yyyy_Mm_Dd.Substring(5, 2) + "/" +
                   Yyyy_Mm_Dd.Substring(0, 4);
        }

        public string JogoEncerrado
        {
            get
            {
                if (EmAndamento)
                    return ($"(Jogo em andamento)");
                else if (Finalizado)
                    return ($"(Jogo encerrado: {GolsTimeCasa} x {GolsTimeVisitante})");
                else
                    return "";
            }
        }

        public bool VerResultado
        {
            get => _verResultado;
            set
            {
                if (_verResultado != value)
                {
                    _verResultado = value;
                    OnPropertyChanged(nameof(VerResultado));
                }
            }
        }

        #endregion
    }
}