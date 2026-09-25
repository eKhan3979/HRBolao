namespace HRBolao.Model
{
    public class JogadorGravadoDTO: BaseModel
    {
        private int _idJogador;
        public JogadorGravadoDTO() { }
        public int IdJogador
        {
            get => _idJogador;
            set
            {
                if (_idJogador != value)
                {
                    _idJogador = value;
                    OnPropertyChanged(nameof(IdJogador));
                }
            }
        }
    }
}
