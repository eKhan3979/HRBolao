using HRBolao.Model;
using HRBolao.Regra;
using HRBolao.ViewModel;

namespace HRBolao;

public partial class cvwBolaoJogos : ContentView
{
    #region Público

    public event EventHandler Evento_ExibirAguarde,
                              Evento_RetirarAguarde,
                              Evento_Jogo,
                              Evento_Mensagem,
                              Evento_Pergunta,
                              Evento_RodadaAvancar,
                              Evento_RodadaRetroceder;

    public CampeonatoDTO Publico_CampeonatoSelecionado
    {
        get
        {
            if (_ViewModel == null)
                _ViewModel = new BolaoJogosViewModel()
                {
                    CampeonatoSelecionado = new CampeonatoDTO()
                };

            return _ViewModel.CampeonatoSelecionado;
        }
        set
        {
            if (_ViewModel == null)
                _ViewModel = new BolaoJogosViewModel();

            _ViewModel.CampeonatoSelecionado = value;

            if ((_ViewModel.CampeonatoSelecionado != null) &&
                (_ViewModel.CampeonatoSelecionado.IdCampeonato > 0))
            {
                _ViewModel.ContadorApostas = 0;

                ThreadStart tstCampeonato = new ThreadStart(CarregarCampeonato);
                Thread thrCampeonato = new Thread(tstCampeonato);
                thrCampeonato.IsBackground = true;
                thrCampeonato.Start();
            }
            else
                Evento_RetirarAguarde?.Invoke(null, new EventArgs());
        }
    }

    public async Task<bool> Publico_Avancar()
    {
        if (_ViewModel.RodadaSelecionada < _ViewModel.RodadaUltima)
        {
            try
            {
                _ViewModel.RodadaSelecionada++;

                await _Regra.CarregarApostas();
            }
            catch (Exception excErro)
            {
                Evento_RodadaAvancar?.Invoke("Erro: - " + excErro.Message, new EventArgs());
            }
            finally
            {
                Evento_RetirarAguarde?.Invoke(null, new EventArgs());
            }
        }

        return true;
    }

    public async Task<bool> Publico_Retroceder()
    {
        if (_ViewModel.RodadaSelecionada > _ViewModel.RodadaPrimeira)
        {
            try
            {
                _ViewModel.RodadaSelecionada--;

                await _Regra.CarregarApostas();
            }
            catch (Exception excErro)
            {
                Evento_RodadaRetroceder?.Invoke("Erro: - " + excErro.Message, new EventArgs());
            }
            finally
            {
                Evento_RetirarAguarde?.Invoke(null, new EventArgs());
            }
        }

        return true;
    }

    public void Publico_Gravar()
    {

    }

    public JogadorModel Publico_JogadorLogin
    {
        get
        {
            if (_ViewModel == null)
                _ViewModel = new BolaoJogosViewModel()
                {
                    JogadorLogin = new JogadorModel()
                };

            return _ViewModel.JogadorLogin;
        }
        set
        {
            if (_ViewModel == null)
                _ViewModel = new BolaoJogosViewModel();

            _ViewModel.JogadorLogin = value;
        }
    }

    #endregion

    #region Variáveis da Classe

    private BolaoJogosRegra _Regra;
    private BolaoJogosViewModel _ViewModel;

    #endregion

    #region Construtor

    public cvwBolaoJogos()
	{
		InitializeComponent();

        _ViewModel = new BolaoJogosViewModel();

        this.BindingContext = _ViewModel;

        _Regra = new BolaoJogosRegra(ref _ViewModel);

        ThreadStart tstInicializacao = new ThreadStart(Inicializacao);
        Thread thrInicializacao = new Thread(tstInicializacao);
        thrInicializacao.IsBackground = true;
        thrInicializacao.Start();
    }

    #endregion

    #region Private

    private async void CarregarCampeonato()
    {
        try
        {
            await _Regra.CarregarCampeonato();
        }
        catch (Exception excErro)
        {
            Evento_Mensagem?.Invoke("Erro|Erro: " + excErro.Message, new EventArgs());
        }
    }

    private async void Inicializacao()
    {
        try
        {
            if (!await _Regra.Iniciar())
                throw new Exception(_ViewModel.ErroMsg.ToString());
        }
        catch (Exception excErro)
        {
            Evento_Mensagem?.Invoke("Erro|" + excErro.Message, new EventArgs());
        }
    }

    private async Task<bool> ShowRodada()
    {
        bool boolOk = false;

        try
        {
            //if (await _Regra.CarregarJogosDaRodada())
            if (await _Regra.CarregarApostas())
                boolOk = true;
            else
                throw new Exception(_ViewModel.ErroMsg.ToString());
        }
        catch (Exception excErro)
        {
            Evento_Mensagem?.Invoke("Erro|Erro: - " + excErro.Message, new EventArgs());
        }

        return boolOk;
    }

    #endregion

    #region Eventos

    private void clvJogos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //_Regra.AtualizarAposta((ApostaGolDTO)sender);

        //Evento_Jogo?.Invoke(_ViewModel.JogoSelecionado, new EventArgs());
    }

    private void cmmTimeCasa_Evento_Valor(object sender, EventArgs e)
    {
        _Regra.AtualizarAposta((ApostaGolDTO)sender);
    }

    private void grdTemplate_Loaded(object sender, EventArgs e)
    {
        if ((_ViewModel != null) &&
            (_ViewModel.ListaApostas != null))
        {
            _ViewModel.ContadorApostas++;

            if ((_ViewModel.ContadorApostas + 1) >= _ViewModel.ListaApostas.Count)
                Evento_RetirarAguarde?.Invoke(null, new EventArgs());
        }
        else
            Evento_RetirarAguarde?.Invoke(null, new EventArgs());
    }

    private void cmmTimeVisitante_Evento_Valor(object sender, EventArgs e)
    {
        _Regra.AtualizarAposta((ApostaGolDTO)sender);
    }

    private async void ibnMais_Clicked(object sender, EventArgs e)
    {
        if (_ViewModel.RodadaSelecionada < _ViewModel.RodadaUltima)
        {
            if (_Regra.MudouAposta())
            {
                Evento_Pergunta?.Invoke("Gravar alteração de aposta(s) ?", new EventArgs());
            }
            else
            {
                try
                {
                    Evento_ExibirAguarde?.Invoke(null, new EventArgs());

                    _ViewModel.RodadaSelecionada++;

                    await _Regra.CarregarApostas();
                }
                catch (Exception excErro)
                {
                    Evento_Mensagem?.Invoke("Erro|Erro: - " + excErro.Message, new EventArgs());
                }
            }
        }
    }

    private async void ibnMenos_Clicked(object sender, EventArgs e)
    {
        if (_ViewModel.RodadaSelecionada > _ViewModel.RodadaPrimeira)
        {
            if (_Regra.MudouAposta())
            {
                Evento_Pergunta?.Invoke("Gravar alteração de aposta(s) ?", new EventArgs());
            }
            else
            {
                try
                {
                    Evento_ExibirAguarde?.Invoke(null, new EventArgs());

                    _ViewModel.RodadaSelecionada--;

                    await _Regra.CarregarApostas();
                }
                catch (Exception excErro)
                {
                    Evento_Mensagem?.Invoke("Erro|Erro: - " + excErro.Message, new EventArgs());
                }
            }
        }
    }

    private async void ibnSalvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento_ExibirAguarde?.Invoke(null, new EventArgs());

            if (await _Regra.GravarApostas())
                Evento_Mensagem?.Invoke("HR: Bolão|- Apostas gravadas !", new EventArgs());
            else
                throw new Exception("- Não houve gravação !");
        }
        catch (Exception excErro)
        {
            Evento_Mensagem?.Invoke("Erro|Erro na gravação: - " + excErro.Message, new EventArgs());
        }
    }

    private async void stpRodada_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (_Regra.MudouAposta())
        {
            Evento_Pergunta?.Invoke("- Houve alteração de resultado, deseja gravar alteração(ôes) ?", new EventArgs());
        }
        else
        {
            Evento_ExibirAguarde?.Invoke(null, new EventArgs());

            await ShowRodada();
        }
    }

    #endregion
}