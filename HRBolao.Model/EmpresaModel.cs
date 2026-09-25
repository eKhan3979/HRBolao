using System.ComponentModel.DataAnnotations;

namespace HRBolao.Model
{
    public class EmpresaModel: BaseModel
    {
        #region Variáveis da Classe

        private int _idEmpresa;
        private string _nomeEmpresa = "";
        private DateTime _dataCadastro;
        private bool _ativo;

        #endregion

        #region Construtor

        public EmpresaModel() { }

        #endregion

        #region Propriedades

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
        [Required]
        [StringLength(100)]
        public string NomeEmpresa
        {
            get => _nomeEmpresa;
            set
            {
                if (_nomeEmpresa != value)
                {
                    _nomeEmpresa = value;
                    OnPropertyChanged(nameof(NomeEmpresa));
                }
            }
        }
        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set
            {
                if (_dataCadastro != value)
                {
                    _dataCadastro = value;
                    OnPropertyChanged(nameof(DataCadastro));
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