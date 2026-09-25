namespace HRBolao.Model
{
    public class RankingDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _rodada,
                    _idCampeonatoJogo,
                    _golsTimeCasa,
                    _golsTimeVisitante;
        private bool _finalizado;
        private int _idJogador;
        private string _jogador = "";
        private int _apostaGolsTimeCasa,
                    _apostaGolsTimeVisitante,
                    _timeCasa,
                    _timeVisitante;

        #endregion

        #region Construtor

        public RankingDTO() { }

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
        public string Jogador
        {
            get => _jogador;
            set
            {
                if (_jogador != value)
                {
                    _jogador = value;
                    OnPropertyChanged(nameof(Jogador));
                }
            }
        }
        public int ApostaGolsTimeCasa
        {
            get => _apostaGolsTimeCasa;
            set
            {
                if (_apostaGolsTimeCasa != value)
                {
                    _apostaGolsTimeCasa = value;
                    OnPropertyChanged(nameof(ApostaGolsTimeCasa));
                }
            }
        }
        public int ApostaGolsTimeVisitante
        {
            get => _apostaGolsTimeVisitante;
            set
            {
                if (_apostaGolsTimeVisitante != value)
                {
                    _apostaGolsTimeVisitante = value;
                    OnPropertyChanged(nameof(ApostaGolsTimeVisitante));
                }
            }
        }
        public int TimeCasa
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
        public int TimeVisitante
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

        #endregion
    }
}