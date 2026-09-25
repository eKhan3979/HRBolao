using HRBolao.Model;

namespace HRBolao.ViewModel
{
    public class CadastroViewModel: BaseViewModel
    {
        #region Variáveis da Classe

        private EmpresaModel _empresaSelecionada = new();

        private JogadorModel _jogadorNovo = new();

        private List<EmpresaModel> _listaEmpresas = [];

        #endregion

        #region Construtor

        public CadastroViewModel(List<EmpresaModel> lstEmpresas) 
        {
            ListaEmpresas = lstEmpresas; 

            if (lstEmpresas.Count == 1)
                EmpresaSelecionada = lstEmpresas[0];
        }

        #endregion

        #region Propriedades

        public EmpresaModel EmpresaSelecionada
        {
            get => _empresaSelecionada;
            set
            {
                if (_empresaSelecionada != value)
                {
                    _empresaSelecionada = value;
                    OnPropertyChanged(nameof(EmpresaSelecionada));

                    JogadorNovo.IdEmpresa = _empresaSelecionada.IdEmpresa;
                }
            }
        }

        public JogadorModel JogadorNovo
        {
            get => _jogadorNovo;
            set
            {
                if (_jogadorNovo != value)
                {
                    _jogadorNovo = value;
                    OnPropertyChanged(nameof(JogadorNovo));
                }
            }
        }

        private List<EmpresaModel> ListaEmpresas
        {
            get => _listaEmpresas;
            set
            {
                if (_listaEmpresas != value)
                {
                    _listaEmpresas = value;
                    OnPropertyChanged(nameof(ListaEmpresas));
                }
            }
        }

        #endregion
    }
}