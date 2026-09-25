using HRBolao.Model;
using HRBolao.ViewModel;

namespace HRBolao;

public partial class cvwJogo : ContentView
{
    #region Público

    public event EventHandler Evento_Salvar,
                              Evento_Voltar;

    public ApostaDTO Publico_JogoAposta
    {
        get
        {
            if (_ViewModel != null)
                return _ViewModel.JogoAposta;
            else
                return new ApostaDTO();
        }
        set
        {
            if (_ViewModel == null)
                _ViewModel = new JogoViewModel();

            _ViewModel.JogoAposta = new ApostaDTO()
            {
                IdCampeonatoJogo = value.IdCampeonatoJogo,
                Yyyy_Mm_Dd = value.Yyyy_Mm_Dd,
                Hh_Mm = value.Hh_Mm,
                IdTimeCasa = value.IdTimeCasa,
                TimeCasa = value.TimeCasa,
                GolsTimeCasa = value.GolsTimeCasa,
                IdTimeVisitante = value.IdTimeVisitante,
                TimeVisitante = value.TimeVisitante,
                GolsTimeVisitante = value.GolsTimeVisitante,
                PenaltisTimeCasa = value.PenaltisTimeCasa,
                PenaltisTimeVisitante = value.PenaltisTimeVisitante,
                MataMata = value.MataMata,
                Prorrogacao = value.Prorrogacao,
                DisputaPenaltis = value.DisputaPenaltis,
                Finalizado = value.Finalizado,
                Adiado = value.Adiado,
                Cancelado = value.Cancelado,
                Numero = value.Numero,
                GolsApostaTimeCasa = value.GolsApostaTimeCasa,
                GolsApostaTimeVisitante = value.GolsApostaTimeVisitante,
                GolsCasaOriginal = value.GolsCasaOriginal,
                GolsVisitanteOriginal = value.GolsVisitanteOriginal,
                IdAposta = value.IdAposta,
                Pontos = value.Pontos
            };
        }
    }

    #endregion

    #region Variáveis da Classe

    private JogoViewModel _ViewModel;

    #endregion

    #region Construtor
    
    public cvwJogo()
	{
		InitializeComponent();
        if (_ViewModel == null)
            _ViewModel = new JogoViewModel();

        BindingContext = _ViewModel;
    }

    #endregion

    #region Eventos

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        Evento_Salvar?.Invoke(_ViewModel.JogoAposta, e);
    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Evento_Voltar?.Invoke(null, e);
    }

    #endregion
}