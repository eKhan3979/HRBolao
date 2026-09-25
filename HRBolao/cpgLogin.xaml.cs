using HRBolao.Comum;
using HRBolao.Model;
using HRBolao.Regra;
using HRBolao.ViewModel;

namespace HRBolao;

public partial class cpgLogin : ContentPage
{
    #region Variáveis da Classe

    private LoginRegra _Regra;
    private LoginViewModel _ViewModel;
    private cvwCadastro _cadastro;
    private cpgBolao _bolao;

    #endregion

    #region Construtor

    public cpgLogin()
	{
		InitializeComponent();

        _ViewModel = new LoginViewModel();

        _Regra = new LoginRegra(ref _ViewModel);

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
                //if (_ViewModel.ListaEmpresas.Count == 1)
                //{
                if (!string.IsNullOrWhiteSpace(jogador.email))
                    edtSenha.Focus();
                else
                    edtEmail.Focus();
                //}
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

    private void btnCadastro_Clicked(object sender, EventArgs e)
    {
        if (_cadastro == null)
        {
            _cadastro = new cvwCadastro(this);
            _cadastro.Evento_Fechar += Cadastro_Evento_Fechar;
            _cadastro.Evento_Gravar += Cadastro_Evento_Gravar;

            grdCadastro.Children.Add(_cadastro);

            Grid.SetRow(_cadastro, 1);
            Grid.SetColumn(_cadastro, 1);
        }

        grdCadastro.IsVisible = true;
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await _Regra.LoginToken())
            {
                RotinasGerais.SetUsuarioLocal(_ViewModel.JogadorLogin);

                if (_bolao == null)
                {
                    _bolao = new cpgBolao(_ViewModel.JogadorLogin);
                }

                Application.Current.Windows[0].Page = _bolao;
            }
            else
                throw new Exception("Usuário " + _ViewModel.JogadorLogin.NomeApelido + " não cadastrado !");
        }
        catch (Exception excErro)
        {
            ExibirMensagem(excErro.Message, "Erro no Login");
        }
    }

    private void Cadastro_Evento_Fechar(object? sender, EventArgs e)
    {
        grdCadastro.IsVisible = false;

        if ((sender != null) &&
            ((int)sender > 0))
        {
            _ViewModel.JogadorLogin.IdJogador = (int)sender;
        }
    }

    private async void Cadastro_Evento_Gravar(object? sender, EventArgs e)
    {
        try
        {
            if (await _Regra.PodeGravar())
            {
                if (await Confirmar("- Confirma a gravação ?",
                                    "Novo Jogador"))
                {
                    try
                    {
                        _ViewModel.JogadorLogin.IdJogador = await _Regra.Gravar();

                        if (_ViewModel.ErroIndex == 0)
                        {
                            RotinasGerais.SetUsuarioLocal(_ViewModel.JogadorLogin);

                            grdCadastro.IsVisible = false;
                        }
                        else
                            throw new Exception(_ViewModel.ErroMsg.ToString());
                    }
                    catch (Exception excErro)
                    {
                        ExibirMensagem(excErro.Message,
                                      "Erro na gravação");
                    }
                }
            }
            else
            {
                ExibirMensagem(_ViewModel.ErroMsg.ToString(),
                               "Operação não permitida !");
            }
        }
        catch (Exception excErro1)
        {
            ExibirMensagem("Erro (1) : - " + excErro1.Message);
        }
    }

    #endregion
}