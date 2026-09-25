namespace HRBolao;

public partial class cvwApostasDetalhes : ContentView
{
    public event EventHandler Evento_Voltar;
    
	public cvwApostasDetalhes()
	{
		InitializeComponent();
	}

    private void ibnVoltar_Clicked(object sender, EventArgs e)
    {
        Evento_Voltar?.Invoke(null, new EventArgs());
    }
}