using HRBolao.Model;

namespace HRBolao.Controles;

public partial class cvwMaisMenos : ContentView
{
    #region Private

    private int _valor;

    #endregion

    #region Construtor

    public cvwMaisMenos()
    {
        InitializeComponent();
    }

    #endregion

    #region Público

    public event EventHandler Evento_Valor;

    public bool TimeDaCasa { get; set; }

    public static readonly BindableProperty MaxProperty =
        BindableProperty.Create(
            nameof(Max),
            typeof(int),
            typeof(cvwMaisMenos),
            100);

    public static readonly BindableProperty MinProperty =
        BindableProperty.Create(
            nameof(Min),
            typeof(int),
            typeof(cvwMaisMenos),
            0);

    public static readonly BindableProperty ValorProperty =
        BindableProperty.Create(
            nameof(Valor),
            typeof(int),
            typeof(cvwMaisMenos),
            0,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((cvwMaisMenos)bindable).Valor = (int)newValue;
            });

    public int Max
    {
        get => (int)GetValue(MaxProperty);
        set => SetValue(MaxProperty, value);
    }

    public int Min
    {
        get => (int)GetValue(MinProperty);
        set => SetValue(MinProperty, value);
    }

    public int Valor
    {
        get => (int)GetValue(ValorProperty);
        set
        {
            SetValue(ValorProperty, value);

            _valor = value;
        }
    }

    public void Publico_ShowValor()
    {
        lblValor.Text = Valor.ToString();
    }

    #endregion

    #region Eventos

    private void ibnMenos_Clicked(object sender, EventArgs e)
    {
        if (this.Valor > this.Min)
        {
            this.Valor--;

            ibnMenos.IsEnabled = (this.Valor > this.Min);
            ibnMais.IsEnabled = true;

            lblValor.Text = this.Valor.ToString();

            Evento_Valor?.Invoke(new ApostaGolDTO()
            {
                IdCampeonatoJogo = ((ApostaDTO)this.BindingContext).IdCampeonatoJogo,
                GolsTimeCasa = ((TimeDaCasa) ? this.Valor : -1),
                GolsTimeVisitante = ((!TimeDaCasa) ? this.Valor : -1)
            }, new EventArgs());
        }
    }

    private void ibnMais_Clicked(object sender, EventArgs e)
    {
        if (this.Valor < this.Max)
        {
            this.Valor++;

            ibnMais.IsEnabled = (this.Valor < this.Max);
            ibnMenos.IsEnabled = true;

            lblValor.Text = this.Valor.ToString();

            Evento_Valor?.Invoke(new ApostaGolDTO()
            {
                IdCampeonatoJogo = ((ApostaDTO)this.BindingContext).IdCampeonatoJogo,
                GolsTimeCasa = ((TimeDaCasa) ? this.Valor : -1),
                GolsTimeVisitante = ((!TimeDaCasa) ? this.Valor : -1)
            }, e);
        }
    }

    #endregion
}