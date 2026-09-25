using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class JogoViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private string _tituloJogo = "";
        private ApostaDTO _jogoAposta = new();

        #endregion

        #region Construtor

        public JogoViewModel() { }

        #endregion

        #region Propriedades

        public string TituloJogo
        {
            get => _tituloJogo;
            set
            {
                if (_tituloJogo != value)
                {
                    _tituloJogo = value;
                    OnPropertyChanged(nameof(TituloJogo));
                }
            }
        }

        public ApostaDTO JogoAposta
        {
            get => _jogoAposta;
            set
            {
                if (_jogoAposta != value)
                {
                    _jogoAposta = value;
                    OnPropertyChanged(nameof(JogoAposta));

                    TituloJogo = _jogoAposta.TimeCasa + " x " +
                                 _jogoAposta.TimeVisitante + "  (" +
                                 _jogoAposta.Hh_Mm + ")";
                }
            }
        }

        #endregion
    }
}