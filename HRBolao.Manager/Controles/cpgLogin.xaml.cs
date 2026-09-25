using HRBolao.Manager.Comum;
using HRBolao.Model;
using HRBolao.Regra;
using HRBolao.ViewModel;

namespace HRBolao.Manager.Controles;

public partial class cpgLogin : ContentPage
{
    #region Variáveis da Classe

    private MnLoginRegra _Regra;
    private MnLoginViewModel _ViewModel;
    private cpgResultados _cpgResultados;

    #endregion

    #region Construtor

    public cpgLogin()
    {
        InitializeComponent();

        _ViewModel = new MnLoginViewModel();

        _Regra = new MnLoginRegra(ref _ViewModel);

        this.BindingContext = _ViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if ((_ViewModel != null) && !_ViewModel.Iniciado)
        {
            if (!await inicializacao())
            {
                await DisplayAlertAsync("Erro na Inicialização", "- " + _ViewModel.ErroMsg.ToString(), "Fechar");
            }
        }
    }

    #endregion

    #region Público

    public async Task<bool> Confirmar(string strMensagem,
                                      string strTitulo = "HR: Bolão")
    {
        return await DisplayAlertAsync(strTitulo, strMensagem, "Sim", "Não");
    }

    public void ExibirMensagem(string strMensagem,
                               string strTitulo = "HR: Bolão")
    {
        DisplayAlertAsync(strTitulo, strMensagem, "Fechar");
    }

    #endregion

    #region Private

    private async Task<bool> inicializacao()
    {
        try
        {
            _ViewModel.ErroIndex = 0;

            JogadorModel jogador = RotinasGerais.GetUsuarioLocal();

            if (jogador.IdJogador > 0)
                _ViewModel.JogadorLogin = jogador;
            else
                _ViewModel.JogadorLogin = new JogadorModel();

            if (await _Regra.Iniciar())
            {
                if (!string.IsNullOrWhiteSpace(jogador.email))
                    edtSenha.Focus();
                else
                    edtEmail.Focus();
            }
            else
                throw new Exception(_ViewModel.ErroMsg.ToString());
        }
        catch (Exception excErro)
        {
            _ViewModel.ErroIndex = 1;

            if (_ViewModel.ErroMsg.Length == 0)
                _ViewModel.ErroMsg.AppendLine(excErro.Message);
        }

        return (_ViewModel.ErroIndex == 0);
    }

    #endregion

    #region Eventos

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await _Regra.LoginManager())
            {
                RotinasGerais.SetUsuarioLocal(_ViewModel.JogadorLogin);

                if (_cpgResultados == null)
                {
                    _cpgResultados = new cpgResultados(_ViewModel.JogadorLogin);
                }

                Application.Current.Windows[0].Page = _cpgResultados;
            }
            else
                throw new Exception("Usuário " + _ViewModel.JogadorLogin.NomeApelido + " não é Administrador !");
        }
        catch (Exception excErro)
        {
            ExibirMensagem(excErro.Message, "Erro no Login");
        }
    }

    #endregion
}