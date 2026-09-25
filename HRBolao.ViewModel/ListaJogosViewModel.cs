using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class ListaJogosViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private List<ApostaDTO> _listaApostas = [];

        #endregion

        #region Construtor

        public ListaJogosViewModel() { }

        #endregion

        #region Propriedades

        public List<ApostaDTO> ListaDeApostas
        {
            get => _listaApostas;
            set
            {
                if (_listaApostas != value)
                {
                    _listaApostas = value;
                    OnPropertyChanged(nameof(ListaDeApostas));
                }
            }
        }

        #endregion
    }
}