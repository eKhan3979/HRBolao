using HRBolao.Model;
using HRBolao.Regra;
using HRBolao.ViewModel;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace HRBolao.Manager.Controles;

public partial class cpgResultados : ContentPage
{
    #region Variáveis da Classe

    private MnResultadosViewModel _ViewModel;
    private MnResultadosRegra _Regras;

    #endregion

    #region Construtor

    public cpgResultados(JogadorModel administrador)
	{
		InitializeComponent();

        if (_ViewModel == null)
            _ViewModel = new MnResultadosViewModel();

        _ViewModel.Administrador = administrador;

        this.BindingContext = _ViewModel;

        _Regras = new MnResultadosRegra(ref _ViewModel);
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if ((_ViewModel != null) && (!_ViewModel.Iniciado))
            await Inicializacao();
    }

    private async Task<bool> Inicializacao()
    {
        try
        {
            _ViewModel.Iniciado = await _Regras.Inicializacao();
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro inicialização", excErro.Message, "Fechar");
        }

        return _ViewModel.Iniciado;
    }

    #endregion

    #region Private

    #endregion

    #region Eventos

    private void cmmCasa_Evento_Valor(object sender, EventArgs e)
    {
        _ViewModel.JogoEdit.GolsTimeCasa = (int)sender;
    }

    private void cmmVisitante_Evento_Valor(object sender, EventArgs e)
    {
        _ViewModel.JogoEdit.GolsTimeVisitante = (int)sender;
    }

    private void ibnFechar_Clicked(object sender, EventArgs e)
    {
        _ViewModel.VerJogo = false;
    }

    private async void ibnGravar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await _Regras.Gravar())
            {
                await Toast.Make("- Resultado gravado !", ToastDuration.Long, 14).Show();

                _ViewModel.JogoEdit = new JogoDTO()
                {
                    GolsTimeCasa = 0,
                    GolsTimeVisitante = 0,
                    Finalizado = false,
                    IdCampeonatoJogo = 0,
                    IdTimeCasa = 0,
                    IdTimeVisitante = 0,
                    TimeCasa = "",
                    TimeVisitante = ""
                };

                _ViewModel.VerJogo = false;
            }
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro", excErro.Message, "Fechar");
        }
    }

    private void ibnPlacar_Clicked(object sender, EventArgs e)
    {
        _Regras.Editar((JogoDTO)((ImageButton)sender).BindingContext);
    }

    private async void pckCampeonatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((_ViewModel.CampeonatoSelecionado != null) && 
                (_ViewModel.CampeonatoSelecionado.IdCampeonato > 0))
            {
                _ViewModel.Aguarde = true;

                if (!await _Regras.CarregarCampeonato())
                {
                    throw new Exception(_ViewModel.ErroMsg.ToString());
                }
            }
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Campeonato", excErro.Message, "Fechar");
        }
        finally
        {
            _ViewModel.Aguarde = false;
        }
    }

    private async void pckRodada_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (await _Regras.CarregarJogos())
            {

            }
            else
            {
                if (_ViewModel.ErroIndex > 0)
                    throw new Exception(_ViewModel.ErroMsg.ToString());
                else
                    throw new Exception("- Não foi possível carragar a lista de Jogos");
            }
        }
        catch (Exception excErro)
        {
            await DisplayAlertAsync("Erro Lista Jogos", excErro.Message, "Fechar");
        }
    }

    #endregion
}