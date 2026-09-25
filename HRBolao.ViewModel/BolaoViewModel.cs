using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class BolaoViewModel : BaseViewModel
    {
        #region Variáveis da Classe

        private CampeonatoDTO _campeonatoSelecionado = new();
        private bool _aguarde,
                     _apostaDetalhesVisible,
                     _jogoAposta,
                     _jogosVisible,
                     _meusPontosVisible,
                     _rankingVisible;
        private JogadorModel _logado = new();
        private RodadaDTO _rodadaSelecionada = new();
        private int _pontosNaRodada,
                    _rodadaAtual,
                    _rodadaPrimeira,
                    _rodadaUltima;
        private string _jogadorDetalheNome;

        private List<ApostaDTO> _listaApostas = [];
        private List<CampeonatoDTO> _listaCampeonatos = [];
        private List<PontuacaoModel> _listaPontuacao = [];
        private List<PontoRodadaDTO> _listaPontosDetalhes = [];
        private List<MeusPontosDTO> _listaMeusPontos = [];
        private List<RankingEmpresaNmDto> _listaRanking = [];
        private List<RodadaDTO> _listaRodadas = [];

        #endregion

        #region Construtor

        public BolaoViewModel() { }

        #endregion

        #region Propriedades

        public bool Aguarde
        {
            get => _aguarde;
            set
            {
                _aguarde = value;
                OnPropertyChanged(nameof(Aguarde));
            }
        }

        public bool ApostaDetalhesVisible
        {
            get => _apostaDetalhesVisible;
            set
            {
                if (_apostaDetalhesVisible != value)
                {
                    _apostaDetalhesVisible = value;
                    OnPropertyChanged(nameof(ApostaDetalhesVisible));
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

        public bool JogoAposta
        {
            get => _jogoAposta;
            set
            {
                if (_jogoAposta != value)
                {
                    _jogoAposta = value;
                    OnPropertyChanged(nameof(JogoAposta));
                }
            }
        }

        public string JogadorDetalheNome
        {
            get => _jogadorDetalheNome;
            set
            {
                if (_jogadorDetalheNome != value)
                {
                    _jogadorDetalheNome = value;
                    OnPropertyChanged(nameof(JogadorDetalheNome));
                }
            }
        }

        public bool JogosVisible
        {
            get => _jogosVisible;
            set
            {
                if (_jogosVisible != value)
                {
                    _jogosVisible = value;
                    OnPropertyChanged(nameof(JogosVisible));
                }
            }
        }

        public JogadorModel Logado
        {
            get => _logado;
            set
            {
                if (_logado != value)
                {
                    _logado = value;
                    OnPropertyChanged(nameof(Logado));
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

        public List<CampeonatoDTO> ListaCampeonatos
        {
            get => _listaCampeonatos;
            set
            {
                if (_listaCampeonatos != value)
                {
                    _listaCampeonatos = value;
                    OnPropertyChanged(nameof(ListaCampeonatos));
                }
            }
        }

        public List<MeusPontosDTO> ListaMeusPontos
        {
            get => _listaMeusPontos;
            set
            {
                if (_listaMeusPontos != value)
                {
                    _listaMeusPontos = value;
                    OnPropertyChanged(nameof(ListaMeusPontos));
                }
            }
        }

        public List<PontoRodadaDTO> ListaPontosDetalhes
        {
            get => _listaPontosDetalhes;
            set
            {
                if (_listaPontosDetalhes != value)
                {
                    _listaPontosDetalhes = value;
                    OnPropertyChanged(nameof(ListaPontosDetalhes));
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

        public List<RankingEmpresaNmDto> ListaRanking
        {
            get => _listaRanking;
            set
            {
                if (_listaRanking != value)
                {
                    _listaRanking = value;
                    OnPropertyChanged(nameof(ListaRanking));
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

        public bool MeusPontosVisible
        {
            get => _meusPontosVisible;
            set
            {
                if (_meusPontosVisible != value)
                {
                    _meusPontosVisible = value;
                    OnPropertyChanged(nameof(MeusPontosVisible));
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

        public bool RankingVisible
        {
            get => _rankingVisible;
            set
            {
                if (_rankingVisible != value)
                {
                    _rankingVisible = value;
                    OnPropertyChanged(nameof(RankingVisible));
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

        public RodadaDTO RodadaSelecionada
        {
            get => _rodadaSelecionada;
            set
            {
                if (_rodadaSelecionada != value)
                {
                    _rodadaSelecionada = value;
                    OnPropertyChanged(nameof(RodadaSelecionada));
                }
            }
        }

        #endregion
    }
}