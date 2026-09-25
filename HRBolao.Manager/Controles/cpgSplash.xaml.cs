namespace HRBolao.Manager.Controles;

public partial class cpgSplash : ContentPage
{
    public cpgSplash()
    {
        InitializeComponent();

        lblVersao.Text = "ver.: " + AppInfo.Current.VersionString;

        Loaded += cpgSplash_Loaded;
    }

    private void cpgSplash_Loaded(object? sender, EventArgs e)
    {
        Task.Run(() =>
        {
            Dispatcher.Dispatch(() =>
            {
                Thread.Sleep(1000);

                Application.Current.Windows[0].Page = new MainPage();
            });
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}