namespace HRBolao.Model
{
    public class RodadaAtualDTO: BaseModel
    {
        private int _rodadaAtual;

        public RodadaAtualDTO() { }

        public int RodadaAtual
        {
            get => _rodadaAtual;
            set
            {
                if (_rodadaAtual != value)
                {
                    _rodadaAtual = value;
                    OnPropertyChanged(nameof(RodadaAtual));
                }
            }
        }
    }
}
