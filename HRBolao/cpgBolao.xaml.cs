using HRBolao.Model;
using HRBolao.Regra;
using HRBolao.ViewModel;

namespace HRBolao;

public partial class cpgBolao : ContentPage
{
    #region Variáveis da Classe

    private BolaoRegra _Regra;
    private BolaoViewModel _ViewModel;

    #endregion

    #region Construtor

    public cpgBolao(JogadorModel logado)
    {
        InitializeComponent();

        //Dispatcher.Dispatch(() => grdAguarde.IsVisible = true);

        _ViewModel = new BolaoViewModel()
        {
            Logado = logado,
            Aguarde = true
        };

        this.BindingContext = _ViewModel;

        _Regra = new BolaoRegra(ref _ViewModel);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if ((_ViewModel != null) && (!_ViewModel.Iniciado))
        {
            await Inicializacao();
        }
    }

    #endregion

    #region Private

    private async Task<bool> Inicializacao()
    {
        bool boolOk = false;

        try
        {
            if (await _Regra.Iniciar())
            {
                //cvwBolaoJogos.Publico_JogadorLogin = _ViewModel.Logado;
                //cvwBolaoJogos.Publico_CampeonatoSelecionado = _ViewModel.CampeonatoSelecionado;
            }

            boolOk = true;
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Inicialização", excErro.Message, "Fechar");
        }

        return boolOk;
    }

    #endregion

    #region Eventos

    private void btnJogos_Clicked(object sender, EventArgs e)
    {
        try
        {
            //_ViewModel.JogoAposta = true;
            _ViewModel.Aguarde = true;
            _ViewModel.JogosVisible = true;
            _ViewModel.MeusPontosVisible = false;
            _ViewModel.RankingVisible = false;
            _ViewModel.ApostaDetalhesVisible = false;
        }
        catch (Exception excErro)
        {
            Dispatcher.Dispatch(() =>
            {
                DisplayAlertAsync("Erro Carregar Campeonato", excErro.Message, "Fechar");
            });
        }
        finally
        {
            _ViewModel.Aguarde = false;
        }
    }

    private async void btnMeusPontos_Clicked(object sender, EventArgs e)
    {
        try
        {
            _ViewModel.Aguarde = false;
            _ViewModel.JogosVisible = false;
            _ViewModel.MeusPontosVisible = true;
            _ViewModel.RankingVisible = false;
            _ViewModel.ApostaDetalhesVisible = false;
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Ranking", "- " + excErro.Message, "Fechar");
        }
        finally
        {
            _ViewModel.Aguarde = false;
        }
    }

    private async void btnRanking_Clicked(object sender, EventArgs e)
    {
        try
        {
            _ViewModel.Aguarde = true;
            _ViewModel.JogosVisible = false;
            _ViewModel.MeusPontosVisible = false;
            _ViewModel.RankingVisible = true;
            _ViewModel.ApostaDetalhesVisible = false;

            //await _Regra.CarregarRanking();
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Ranking", "- " + excErro.Message, "Fechar");
        }
        finally
        {
            _ViewModel.Aguarde = false;
        }
    }

    private void cvwApostasDetalhes_Evento_Voltar(object sender, EventArgs e)
    {
        _ViewModel.ApostaDetalhesVisible = false;
        _ViewModel.RankingVisible = true;
    }

    private void cvwBolaoJogos_Evento_ExibirAguarde(object sender, EventArgs e)
    {
        _ViewModel.Aguarde = true;
    }

    private async void cvwBolaoJogos_Evento_Mensagem(object sender, EventArgs e)
    {
        _ViewModel.Aguarde = false;

        string[] arrMsg = sender.ToString().Split('|');

        await DisplayAlertAsync(arrMsg[0], arrMsg[1], "Fechar");
    }

    private async void cvwBolaoJogos_Evento_Pergunta(object sender, EventArgs e)
    {

    }

    private async void cvwBolaoJogos_Evento_RodadaAvancar(object sender, EventArgs e)
    {
        if (await DisplayAlertAsync("Confirmar", sender.ToString(), "Gravar", "Descartar") == true)
        {

        }
    }

    private async void cvwBolaoJogos_Evento_RodadaRetroceder(object sender, EventArgs e)
    {
        if (await DisplayAlertAsync("Confirmar", sender.ToString(), "Gravar", "Descartar") == true)
        {

        }
    }

    private void cvwListaJogos_Evento_Gol(object sender, EventArgs e)
    {
        _Regra.AtualizarAposta((ApostaGolDTO)sender);
    }

    private async void cvwJogo_Evento_Salvar(object sender, EventArgs e)
    {
        try
        {
            if (await _Regra.GravarAposta(_ViewModel.Logado.IdJogador,
                                                        (JogoDTO)sender))
            {
                _ViewModel.JogoAposta = false;
            }
            else if (_ViewModel.ErroIndex > 0)
                throw new Exception(_ViewModel.ErroMsg.ToString());
            else
                throw new Exception("- Não houve retorno esperado da gravação");
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Salvar Aposta", excErro.Message, "Fechar");
        }
    }

    private void cvwJogo_Evento_Voltar(object sender, EventArgs e)
    {
        _ViewModel.JogoAposta = false;
    }

    private async void cvwRanking_Evento_RankingDetalhes(object sender, EventArgs e)
    {
        try
        {
            _ViewModel.Aguarde = true;

            RankingEmpresaNmDto rank = (RankingEmpresaNmDto)((ImageButton)sender).BindingContext;

            if (await _Regra.CarregarJogadorPontosRodada(rank.IdJogador))
            {
                _ViewModel.JogadorDetalheNome = rank.NomeApelido;
                _ViewModel.RankingVisible = false;
                _ViewModel.ApostaDetalhesVisible = true;
            }
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro", excErro.Message, "Fechar");
        }
        finally
        {
            _ViewModel.Aguarde = false;
        }
    }

    private async void ibnMais_Clicked(object sender, EventArgs e)
    {
        if (_ViewModel.RodadaSelecionada.Rodada < _ViewModel.RodadaUltima)
        {
            /*
            if (_Regra.MudouAposta())
            {
                Evento_Pergunta?.Invoke("Gravar alteração de aposta(s) ?", new EventArgs());
            }
            else
            {
                */
            try
            {
                _ViewModel.Aguarde = true;

                _ViewModel.RodadaSelecionada.Rodada++;

                await _Regra.CarregarApostas();
                await _Regra.CarregarRanking();

                var rodada = _ViewModel.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_ViewModel.RodadaSelecionada.Rodada));

                if (rodada != null)
                    _ViewModel.RodadaSelecionada = new RodadaDTO()
                    {
                        RodadaNome = rodada.RodadaNome,
                        Rodada = rodada.Rodada
                    };
                else
                {
                    int intRodada = _ViewModel.RodadaSelecionada.Rodada;

                    _ViewModel.RodadaSelecionada = new RodadaDTO()
                    {
                        Rodada = intRodada,
                        RodadaNome = ""
                    };
                }


                //cvwListaJogos.Publico_VaiListaApostas(_ViewModel.ListaApostas);
            }
            catch (Exception excErro)
            {
                _ViewModel.Aguarde = false;

                await DisplayAlertAsync("Erro Rodada", "- " + excErro.Message, "Fechar");
            }
            finally
            {
                _ViewModel.Aguarde = false;
            }
            //}
        }

    }

    private async void ibnMenos_Clicked(object sender, EventArgs e)
    {
        if (_ViewModel.RodadaSelecionada.Rodada > _ViewModel.RodadaPrimeira)
        {
            /*
            if (_Regra.MudouAposta())
            {
                Evento_Pergunta?.Invoke("Gravar alteração de aposta(s) ?", new EventArgs());
            }
            else
            {
                */
            try
            {
                _ViewModel.Aguarde = true;

                _ViewModel.RodadaSelecionada.Rodada--;

                await _Regra.CarregarApostas();
                await _Regra.CarregarRanking();

                var rodada = _ViewModel.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_ViewModel.RodadaSelecionada.Rodada));

                if (rodada != null)
                    _ViewModel.RodadaSelecionada = new RodadaDTO()
                    {
                        Rodada = rodada.Rodada,
                        RodadaNome = rodada.RodadaNome
                    };
                else
                {
                    int intRodada = _ViewModel.RodadaSelecionada.Rodada;

                    _ViewModel.RodadaSelecionada = new RodadaDTO()
                    {
                        Rodada = intRodada,
                        RodadaNome = ""
                    };
                }
            }
            catch (Exception excErro)
            {
                await DisplayAlertAsync("Erro", " - " + excErro.Message, "Fechar");
            }
            finally
            {
                _ViewModel.Aguarde = false;
            }
            //}
        }
    }

    private async void ibnSalvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            _ViewModel.Aguarde = true;

            if (await _Regra.GravarApostas())
                await DisplayAlertAsync("HR: Bolão", "- Apostas gravadas !", "Fechar");
            else
                throw new Exception("- Não houve gravação !");
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro", "- " + excErro.Message, "Fechar");
        }
        finally
        {
            _ViewModel.Aguarde = false;
        }
    }

    private async void pckCampeonatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _ViewModel.Aguarde = true;

            if (!await _Regra.CarregarCampeonato())
            {
                throw new Exception(_ViewModel.ErroMsg.ToString());
            }
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Campeonato", excErro.Message, "Fechar");
        }
        finally
        {
            _ViewModel.JogosVisible = true;
            _ViewModel.MeusPontosVisible = false;
            _ViewModel.RankingVisible = false;
            _ViewModel.ApostaDetalhesVisible = false;

            _ViewModel.Aguarde = false;
        }
    }

    #endregion
}