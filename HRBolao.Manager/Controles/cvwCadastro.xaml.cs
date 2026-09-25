namespace HRBolao.Manager.Controles;

public partial class cvwCadastro : ContentView
{
    #region Variáveis da Classe

    private cpgLogin _loginParent;

    #endregion

    #region Construtor

    public cvwCadastro(cpgLogin loginParent)
    {
        InitializeComponent();

        _loginParent = loginParent;
    }

    #endregion

    #region Público

    public event EventHandler Evento_Fechar,
                              Evento_Gravar;

    #endregion

    #region Eventos

    private async void btnGravar_Clicked(object sender, EventArgs e)
    {
        Evento_Gravar?.Invoke(null, new EventArgs());
    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Evento_Fechar?.Invoke(0, new EventArgs());
    }

    #endregion
}