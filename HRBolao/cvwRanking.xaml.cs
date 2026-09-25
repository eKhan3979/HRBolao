namespace HRBolao;

public partial class cvwRanking : ContentView
{
    public event EventHandler Evento_RankingDetalhes;
    
	public cvwRanking()
	{
		InitializeComponent();
	}

    private void grdTemplate_Loaded(object sender, EventArgs e)
    {

    }

    private void ibnDetalhes_Clicked(object sender, EventArgs e)
    {
        Evento_RankingDetalhes?.Invoke(sender, e);
    }
}