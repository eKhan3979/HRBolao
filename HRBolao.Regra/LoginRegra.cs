using System;
using System.Text;

using HRBolao.Model;
using HRBolao.Servico;
using HRBolao.ViewModel;

namespace HRBolao.Regra
{
    public class LoginRegra
    {
        #region Variáveis da Classe

        private LoginViewModel _vm;

        #endregion

        #region Construtor

        public LoginRegra(ref LoginViewModel vm)
        {
            _vm = vm;
        }

        #endregion

        #region Público

        public async Task<bool> ExisteEmpresaNome()
        {
            bool boolExiste = false;

            try
            {
                JogadorModel jogador = await (new JogadorServico()).Get(_vm.EmpresaSelecionada.IdEmpresa,
                                                                        _vm.JogadorLogin.NomeApelido);

                boolExiste = ((jogador != null) && jogador.IdJogador > 0);
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolExiste;
        }

        public async Task<int> Gravar()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                JogadorModel jogador = new JogadorModel()
                {
                    IdEmpresa = _vm.EmpresaSelecionada.IdEmpresa,
                    IdJogador = 0,
                    NomeApelido = _vm.JogadorLogin.NomeApelido,
                    Senha = _vm.JogadorLogin.Senha,
                    email = _vm.JogadorLogin.email,
                    Ativo = true
                };

                jogador.IdJogador = await (new JogadorServico()).Gravar(jogador);

                if (jogador.IdJogador > 0)
                {
                    _vm.JogadorLogin.IdJogador = jogador.IdJogador;
                    _vm.JogadorLogin.IdEmpresa = jogador.IdEmpresa;
                    _vm.JogadorLogin.NomeApelido = jogador.NomeApelido;
                    _vm.JogadorLogin.Senha = jogador.Senha;
                    _vm.JogadorLogin.email = jogador.email;
                    _vm.JogadorLogin.Ativo = jogador.Ativo;
                }
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return _vm.JogadorLogin.IdJogador;
        }

        public async Task<bool> Iniciar()
        {
            _vm.ErroIndex = 0;

            try
            {
                _vm.ErroMsg = new StringBuilder();

                //_vm.ListaEmpresas = await (new EmpresaServico()).ListaEmpresas(true);

                //if (_vm.ListaEmpresas.Count == 1)
                    //_vm.EmpresaSelecionada = _vm.ListaEmpresas[0];

                _vm.Iniciado = true;
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> Login()
        {
            bool boolOk = false;

            try
            {
                _vm.JogadorLogin = await (new JogadorServico()).Login(_vm.JogadorLogin.IdEmpresa,
                                                                      _vm.JogadorLogin.NomeApelido,
                                                                      _vm.JogadorLogin.Senha);

                boolOk = (_vm.JogadorLogin.IdJogador > 0);
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<bool> LoginToken()
        {
            bool boolOk = false;

            try
            {
                string strEmail = _vm.JogadorLogin.email;

                _vm.JogadorLogin = await (new JogadorServico()).LoginToken(strEmail,
                                                                           _vm.JogadorLogin.Senha);

                boolOk = (_vm.JogadorLogin.IdJogador > 0);

                if (!boolOk)
                    _vm.JogadorLogin.email = strEmail;
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<bool> PodeGravar()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                if ((_vm.EmpresaSelecionada == null) ||
                    (_vm.EmpresaSelecionada.IdEmpresa == 0))
                {
                    _vm.ErroIndex = 1;
                    _vm.ErroMsg.AppendLine("- Selecione a Empresa");
                }
                if (string.IsNullOrWhiteSpace(_vm.JogadorLogin.NomeApelido))
                {
                    _vm.ErroIndex = ((_vm.ErroIndex == 0) ? 2 : _vm.ErroIndex);
                    _vm.ErroMsg.AppendLine("- Digite seu Nome/Apelido");
                }
                if (string.IsNullOrWhiteSpace(_vm.JogadorLogin.Senha) ||
                    _vm.JogadorLogin.Senha.Trim().Length < 3)
                {
                    _vm.ErroIndex = ((_vm.ErroIndex == 0) ? 3 : _vm.ErroIndex);
                    _vm.ErroMsg.AppendLine("- Digite uma senha (pelo menos 3 caracteres)");
                }
                if (string.IsNullOrWhiteSpace(_vm.JogadorLogin.email))
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

        #endregion    
    }
}