namespace HRBolao.Model
{
    public class RodadaDTO: BaseModel
    {
        #region Variáveis da Classe

        private int _rodada;
        private string _rodadaNome = "";

        #endregion

        #region Construtor

        public RodadaDTO() { }

        #endregion

        #region Propriedades

        public int Rodada
        {
            get => _rodada;
            set
            {
                if (_rodada != value)
                {
                    _rodada = value;
                    OnPropertyChanged(nameof(Rodada));
                }
            }
        }
        public string RodadaNome
        {
            get => _rodadaNome;
            set
            {
                if (_rodadaNome != value)
                {
                    _rodadaNome = value;
                    OnPropertyChanged(nameof(RodadaNome));
                }
            }
        }

        #endregion
    }
}