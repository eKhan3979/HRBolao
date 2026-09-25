namespace HRBolao.Model
{
    public class CampeonatoDTO : BaseModel
    {
        #region Variáveis da Classe

        private string _nome = "";
        private int _idCampeonato,
                    _ano,
                    _idEmpresaCampeonato;

        #endregion

        #region Construtor

        public CampeonatoDTO() { }

        #endregion

        #region Propriedades

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
        public int IdEmpresaCampeonato
        {
            get => _idEmpresaCampeonato;
            set
            {
                if (_idEmpresaCampeonato != value)
                {
                    _idEmpresaCampeonato = value;
                    OnPropertyChanged(nameof(IdEmpresaCampeonato));
                }
            }
        }

        #endregion
    }
}