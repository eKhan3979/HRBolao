using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using HRBolao.Model;
using Newtonsoft.Json.Serialization;
using System.Collections.Immutable;

namespace HRBolao.Servico
{
    public class JogadorServico: BaseServico
    {
        #region Construtor

        public JogadorServico() { }

        #endregion

        #region Público

        public async Task<JogadorModel> Get(int idEmpresa, string nomeApelido)
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}jogadorGet
/{idEmpresa}
/{nomeApelido}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var jogadores = JsonConvert.DeserializeObject<List<JogadorModel>>(retorno);

                    if ((jogadores != null) && (jogadores.Count > 0))
                        jogador = jogadores[0];

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return jogador;
        }

        public async Task<int> Gravar(JogadorModel jogador)
        {
            try
            {
                string strLink = normalizaLink($@"{BaseLink}jogadorGravar
/{jogador.IdJogador}
/{jogador.IdEmpresa}
/{jogador.NomeApelido}
/{jogador.Senha}
/{jogador.email}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    List<JogadorGravadoDTO>? jogadores = JsonConvert.DeserializeObject<List<JogadorGravadoDTO>>(retorno);

                    if ((jogadores != null) && (jogadores.Count > 0))
                        jogador.IdJogador = jogadores[0].IdJogador;

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return jogador.IdJogador;
        }

        public async Task<JogadorModel> Login(int idEmpresa,
                                           string nomeApelido,
                                           string senha)
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}jogadorLogin
/{idEmpresa}
/{nomeApelido}
/{senha}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var jogadores = JsonConvert.DeserializeObject<List<JogadorModel>>(retorno);

                    if ((jogadores != null) && (jogadores.Count > 0))
                        jogador = jogadores[0];

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return jogador;
        }

        public async Task<JogadorModel> LoginManager(string email,
                                                     string senha)
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}jogadorLoginManager
/{email}
/{senha}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var jogadores = JsonConvert.DeserializeObject<List<JogadorModel>>(retorno);

                    if ((jogadores != null) && (jogadores.Count > 0))
                        jogador = jogadores[0];

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return jogador;
        }

        public async Task<JogadorModel> LoginToken(string email,
                                                   string senha)
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}loginToken
/{email}
/{senha}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var jogadores = JsonConvert.DeserializeObject<List<JogadorModel>>(retorno);

                    if ((jogadores != null) && (jogadores.Count > 0))
                        jogador = jogadores[0];

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return jogador;
        }

        #endregion
    }
}