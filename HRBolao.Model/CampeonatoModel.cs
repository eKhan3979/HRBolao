namespace HRBolao.Model
{
    public class CampeonatoModel : BaseModel
    {
        #region Variáveis da Classe

        private int _idCampeonato;
        private string _nome = "";
        private int _ano;
        private bool _ativo;

        #endregion

        #region Construtor

        public CampeonatoModel() { }

        #endregion

        #region Propriedades

        public int IdCampeonato
        {
            get => _idCampeonato;
            set
            {
                if (_idCampeonato != value)
                {
                    _idCampeonato = value;
                    OnPropertyChanged(nameof(IdCampeonato));
                }
            }
        }
        public string Nome
        {
            get => _nome;
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                    OnPropertyChanged(nameof(Nome));
                }
            }
        }
        public int Ano
        {
            get => _ano;
            set
            {
                if (_ano != value)
                {
                    _ano = value;
                    OnPropertyChanged(nameof(Ano));
                }
            }
        }
        public bool Ativo
        {
            get => _ativo;
            set
            {
                if (_ativo != value)
                {
                    _ativo = value;
                    OnPropertyChanged(nameof(Ativo));
                }
            }
        }

        #endregion
    }
}