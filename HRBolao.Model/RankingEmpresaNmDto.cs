namespace HRBolao.Model
{
    public class RankingEmpresaNmDto: RankingEmpresaDTO
    {
        #region Variáveis da Classe

        private int _numero;

        #endregion

        #region Construtor

        public RankingEmpresaNmDto() { }

        #endregion

        #region Propriedades

        public int Numero
        {
            get => _numero;
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                    OnPropertyChanged(nameof(Numero));
                }
            }
        }

        #endregion
    }
}