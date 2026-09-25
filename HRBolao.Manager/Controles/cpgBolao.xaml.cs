using HRBolao.Model;
using HRBolao.Regra;
using HRBolao.ViewModel;

namespace HRBolao.Manager.Controles;

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

    private void pckCampeonatos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btnJogos_Clicked(object sender, EventArgs e)
    {

    }

    private void btnMeusPontos_Clicked(object sender, EventArgs e)
    {

    }

    private void btnRanking_Clicked(object sender, EventArgs e)
    {

    }

    private void ibnMenos_Clicked(object sender, EventArgs e)
    {

    }

    private void ibnMais_Clicked(object sender, EventArgs e)
    {

    }

    private void ibnSalvar_Clicked(object sender, EventArgs e)
    {

    }
}