using System;
using System.Text;

using HRBolao.Model;
using HRBolao.Servico;
using HRBolao.ViewModel;

namespace HRBolao.Regra
{
    public class CadastroRegra
    {
        #region Variáveis da Classe

        private CadastroViewModel _vm;

        #endregion

        #region Construtor

        public CadastroRegra(ref CadastroViewModel vm)
        {
            _vm = vm;
        }

        #endregion

        #region Público

        public async Task<int> Gravar()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                JogadorModel jogador = new JogadorModel()
                {
                    IdEmpresa = _vm.JogadorNovo.IdEmpresa,
                    IdJogador = _vm.JogadorNovo.IdJogador,
                    NomeApelido = _vm.JogadorNovo.NomeApelido,
                    Senha = _vm.JogadorNovo.Senha,
                    email = _vm.JogadorNovo.email,
                    Ativo = true
                };

                jogador.IdJogador = await (new JogadorServico()).Gravar(jogador);
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return _vm.JogadorNovo.IdJogador;
        }

        public void Iniciar()
        {
            _vm.ErroIndex = 0;
            _vm.ErroMsg = new StringBuilder();
            _vm.JogadorNovo = new JogadorModel();
        }

        public async Task<bool> PodeGravar()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                if (_vm.JogadorNovo.IdEmpresa == 0)
                {
                    _vm.ErroIndex = 1;
                    _vm.ErroMsg.AppendLine("- Selecione a Empresa");
                }
                if (string.IsNullOrWhiteSpace(_vm.JogadorNovo.NomeApelido))
                {
                    _vm.ErroIndex = ((_vm.ErroIndex == 0) ? 2 : _vm.ErroIndex);
                    _vm.ErroMsg.AppendLine("- Digite seu Nome/Apelido");
                }
                if (string.IsNullOrWhiteSpace(_vm.JogadorNovo.Senha) ||
                    _vm.JogadorNovo.Senha.Trim().Length < 3)
                {
                    _vm.ErroIndex = ((_vm.ErroIndex == 0) ? 3 : _vm.ErroIndex);
                    _vm.ErroMsg.AppendLine("- Digite uma senha (pelo menos 3 caracteres)");
                }
                if (string.IsNullOrWhiteSpace(_vm.JogadorNovo.email))
                {
                    _vm.ErroIndex = ((_vm.ErroIndex == 0) ? 4 : _vm.ErroIndex);
                    _vm.ErroMsg.AppendLine("- Digite um e-mail (para o recuperador de senha)");
                }

                if (_vm.ErroIndex == 0)
                {
                    if (await ExisteEmpresaNome())
                    {
                        _vm.ErroIndex = 2;
                        _vm.ErroMsg.AppendLine("- Nome/Apelido já cadastrado nesta Empresa!");
                    }
                }
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 99;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> ExisteEmpresaNome()
        {
            bool boolExiste = false;

            try
            {
                JogadorModel jogador = await (new JogadorServico()).Get(_vm.JogadorNovo.IdEmpresa,
                                                                        _vm.JogadorNovo.NomeApelido);

                boolExiste = ((jogador != null) && jogador.IdJogador > 0);
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolExiste;
        }

        #endregion
    }
}