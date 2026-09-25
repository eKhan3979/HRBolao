namespace HRBolao.Model
{
    public class ApostaModel : BaseModel
    {
        #region Variáveis da Classe

        private int _idAposta,
                    _idCampeonatoJogo,
                    _idJogador,
                    _golsTimeCasa,
                    _golsTimeVisitante;
        private bool _prorrogacao,
                     _disputaPenaltis;
        private int _penaltisTimeCasa,
                    _penaltisTimeVisitante,
                    _pontos;

        #endregion

        #region Construtor

        public ApostaModel() { }

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