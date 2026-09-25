namespace HRBolao.Model
{
    public class EmpresaCampeonatoModel : BaseModel
    {
        #region Variáveis da Classe

        private int _idEmpresaCampeonato,
                    _idEmpresa,
                    _idCampeonato;
        private bool _ativo;

        #endregion

        #region Construtor

        public EmpresaCampeonatoModel() { }

        #endregion

        #region Propriedades

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
        public int IdEmpresa
        {
            get => _idEmpresa;
            set
            {
                if (_idEmpresa != value)
                {
                    _idEmpresa = value;
                    OnPropertyChanged(nameof(IdEmpresa));
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