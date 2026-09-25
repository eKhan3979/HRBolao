namespace HRBolao.Model
{
    public class ApostaRetornoDTO: BaseModel
    {
        private int _idAposta;
        public ApostaRetornoDTO() { }
        public int IdAposta
        {
            get => _idAposta;
            set
            {
                if (_idAposta != value)
                {
                    _idAposta = value;
                    OnPropertyChanged(nameof(IdAposta));
                }
            }
        }
    }
}