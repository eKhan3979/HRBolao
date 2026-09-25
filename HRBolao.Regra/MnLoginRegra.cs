using System;
using System.Text;

using HRBolao.Model;
using HRBolao.Servico;
using HRBolao.ViewModel;

namespace HRBolao.Regra
{
    public class MnLoginRegra
    {
        #region Variáveis da Classe

        private MnLoginViewModel _vm;

        #endregion

        #region Construtor

        public MnLoginRegra(ref MnLoginViewModel vm)
        {
            _vm = vm;
        }

        #endregion

        #region Público

        public async Task<bool> Iniciar()
        {
            if (_vm == null)
                _vm = new MnLoginViewModel();

            _vm.ErroIndex = 0;
            _vm.ErroMsg = new StringBuilder();
            _vm.Iniciado = true;

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> LoginManager()
        {
            bool boolOk = false;

            try
            {
                _vm.JogadorLogin = await (new JogadorServico()).LoginManager(_vm.JogadorLogin.email,
                                                                             _vm.JogadorLogin.Senha);

                boolOk = (_vm.JogadorLogin.IdJogador > 0);
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        #endregion    
    }
}