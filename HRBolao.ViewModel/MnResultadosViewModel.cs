using System;
using System.Collections.Generic;

using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class MnResultadosViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private JogadorModel _administrador;
        private bool _aguarde,
                     _verJogo;
        private CampeonatoDTO _campeonatoSelecionado = new();
        private JogoDTO _jogoEdit = new();
        private int _rodadaAtual;
        private RodadaDTO _rodadaSelecionada = new();

        private List<CampeonatoDTO> _listaCampeonatos = [];
        private List<JogoDTO> _listaJogos = [];
        private List<RodadaDTO> _listaRodadas = [];

        #endregion

        #region Construtor

        public MnResultadosViewModel() { }

        #endregion

        #region Propriedades

        public JogadorModel Administrador
        {
            get => _administrador;
            set
            {
                if (_administrador != value)
                {
                    _administrador = value;
                    OnPropertyChanged(nameof(Administrador));
                }
            }
        }

        public bool Aguarde
        {
            get => _aguarde;
            set
            {
                if (_aguarde != value)
                {
                    _aguarde = value;
                    OnPropertyChanged(nameof(Aguarde));
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

        public JogoDTO JogoEdit
        {
            get => _jogoEdit;
            set
            {
                if (_jogoEdit != value)
                {
                    _jogoEdit = value;
                    OnPropertyChanged(nameof(JogoEdit));
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

        public List<JogoDTO> ListaJogos
        {
            get => _listaJogos;
            set
            {
                if (_listaJogos != value)
                {
                    _listaJogos = value;
                    OnPropertyChanged(nameof(ListaJogos));
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

        public RodadaDTO RodadaSelecionada
        {
            get => _rodadaSelecionada;
            set
            {
                _rodadaSelecionada = value;
                OnPropertyChanged(nameof(RodadaSelecionada));
            }
        }

        public bool VerJogo
        {
            get => _verJogo;
            set
            {
                if (_verJogo != value)
                {
                    _verJogo = value;
                    OnPropertyChanged(nameof(VerJogo));
                }
            }
        }

        #endregion
    }
}