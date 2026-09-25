namespace HRBolao.Model
{
    public class UFModel: BaseModel
    {
        #region Variáveis da Classe

        private string _uf = "";

        #endregion

        #region Construtor

        public UFModel()
        {
        }

        #endregion

        #region Propriedades

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

        #endregion
    }
}