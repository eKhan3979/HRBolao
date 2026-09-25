using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class BolaoJogosViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private ApostaDTO _apostaSelecionada = new();
        private CampeonatoDTO _campeonatoSelecionado = new();
        private bool _alterouAposta,
                     _editJogo;
        private JogadorModel _jogadorLogin = new();

        private int _contadorApostas,
                    _pontosNaRodada,
                    _rodadaAtual,
                    _rodadaPrimeira,
                    _rodadaSelecionada,
                    _rodadaUltima;

        private RodadaDTO _rodadaSelecionadaDTO = new();

        private List<ApostaDTO> _listaApostas = [];
        private List<PontuacaoModel> _listaPontuacao = [];
        private List<RodadaDTO> _listaRodadas = [];

        #endregion

        #region Construtor

        public BolaoJogosViewModel() { }

        #endregion

        #region Propriedades

        public bool AlterouAposta
        {
            get => _alterouAposta;
            set
            {
                if (_alterouAposta != value)
                {
                    _alterouAposta = value;
                    OnPropertyChanged(nameof(AlterouAposta));
                }
            }
        }

        public ApostaDTO ApostaSelecionada
        {
            get => _apostaSelecionada;
            set
            {
                if (_apostaSelecionada != value)
                {
                    _apostaSelecionada = value;
                    OnPropertyChanged(nameof(ApostaSelecionada));
                }
            }
        }

        public CampeonatoDTO CampeonatoSelecionado
        {
            get => _campeonatoSelecionado;
            set
            {
                if (_campeonatoSelecionado != value)
                {
                    _campeonatoSelecionado = value;
                    OnPropertyChanged(nameof(CampeonatoSelecionado));
                }
            }
        }

        public int ContadorApostas
        {
            get => _contadorApostas;
            set
            {
                if (_contadorApostas != value)
                {
                    _contadorApostas = value;
                    OnPropertyChanged(nameof(ContadorApostas));
                }
            }
        }

        public bool EditJogo
        {
            get => _editJogo;
            set
            {
                if (_editJogo != value)
                {
                    _editJogo = value;
                    OnPropertyChanged(nameof(EditJogo));
                }
            }
        }

        public JogadorModel JogadorLogin
        {
            get => _jogadorLogin;
            set
            {
                if (_jogadorLogin != value)
                {
                    _jogadorLogin = value;
                    OnPropertyChanged(nameof(JogadorLogin));
                }
            }
        }

        public int PontosNaRodada
        {
            get => _pontosNaRodada;
            set
            {
                if (_pontosNaRodada != value)
                {
                    _pontosNaRodada = value;
                    OnPropertyChanged(nameof(PontosNaRodada));
                }
            }
        }

        public int RodadaAtual
        {
            get => _rodadaAtual;
            set
            {
                if (_rodadaAtual != value)
                {
                    _rodadaAtual = value;
                    OnPropertyChanged(nameof(RodadaAtual));
                }
            }
        }
        public int RodadaPrimeira
        {
            get => _rodadaPrimeira;
            set
            {
                if (_rodadaPrimeira != value)
                {
                    _rodadaPrimeira = value;
                    OnPropertyChanged(nameof(RodadaPrimeira));
                }
            }
        }
        public int RodadaSelecionada
        {
            get => _rodadaSelecionada;
            set
            {
                if (_rodadaSelecionada != value)
                {
                    _rodadaSelecionada = value;
                    OnPropertyChanged(nameof(RodadaSelecionada));

                    if ((ListaRodadas != null) && (ListaRodadas.Count > 0))
                        RodadaSelecionadaDTO = ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_rodadaSelecionada));
                }
            }
        }
        public RodadaDTO RodadaSelecionadaDTO
        {
            get => _rodadaSelecionadaDTO;
            set
            {
                if (_rodadaSelecionadaDTO != value)
                {
                    _rodadaSelecionadaDTO = value;
                    OnPropertyChanged(nameof(RodadaSelecionadaDTO));
                }
            }
        }
        public int RodadaUltima
        {
            get => _rodadaUltima;
            set
            {
                if (_rodadaUltima != value)
                {
                    _rodadaUltima = value;
                    OnPropertyChanged(nameof(RodadaUltima));
                }
            }
        }

        public List<ApostaDTO> ListaApostas
        {
            get => _listaApostas;
            set
            {
                if (_listaApostas != value)
                {
                    _listaApostas = value;
                    OnPropertyChanged(nameof(ListaApostas));
                }
            }
        }

        public List<PontuacaoModel> ListaPontuacao
        {
            get => _listaPontuacao;
            set
            {
                if (_listaPontuacao != value)
                {
                    _listaPontuacao = value;
                    OnPropertyChanged(nameof(ListaPontuacao));
                }
            }
        }

        public List<RodadaDTO> ListaRodadas
        {
            get => _listaRodadas;
            set
            {
                if (_listaRodadas != value)
                {
                    _listaRodadas = value;
                    OnPropertyChanged(nameof(ListaRodadas));
                }
            }
        }

        #endregion
    }
}