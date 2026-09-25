namespace HRBolao;

public partial class cvwListaJogos : ContentView
{
    public event EventHandler Evento_Gol;
    
	public cvwListaJogos()
	{
		InitializeComponent();
	}

    private void clvJogos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void grdTemplate_Loaded(object sender, EventArgs e)
    {

    }

    private void cmmTimeCasa_Evento_Valor(object sender, EventArgs e)
    {
        Evento_Gol?.Invoke(sender, e);
    }

    private void cmmTimeVisitante_Evento_Valor(object sender, EventArgs e)
    {
        Evento_Gol?.Invoke(sender, e);
    }
}