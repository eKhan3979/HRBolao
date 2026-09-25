namespace HRBolao.Model
{
    public class TimeModel : BaseModel
    {
        #region Variáveis da Classe

        private int _idTime;
        private string _nome = "",
                       _uf = "",
                       _cidade = "",
                       _abreviatura = "";
        private bool _ativo;

        #endregion

        #region Construtor

        public TimeModel() { }

        #endregion

        #region Propriedades

        public int IdTime
        {
            get => _idTime;
            set
            {
                if (_idTime != value)
                {
                    _idTime = value;
                    OnPropertyChanged(nameof(IdTime));
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
        public string UF
        {
            get => _uf;
            set
            {
                if (_uf != value)
                {
                    _uf = value;
                    OnPropertyChanged(nameof(UF));
                }
            }
        }
        public string Cidade
        {
            get => _cidade;
            set
            {
                if (_cidade != value)
                {
                    _cidade = value;
                    OnPropertyChanged(nameof(Cidade));
                }
            }
        }
        public string Abreviatura
        {
            get => _abreviatura;
            set
            {
                if (_abreviatura != value)
                {
                    _abreviatura = value;
                    OnPropertyChanged(nameof(Abreviatura));
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