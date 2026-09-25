using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using HRBolao.Model;

namespace HRBolao.Servico
{
    public class JogoServico: BaseServico
    {
        #region Construtor

        public JogoServico() { }

        #endregion

        #region Público

        public async Task<bool> JogoResultado(JogoDTO jogo)
        {
            bool boolOk = false;

            try
            {
                string strLink = normalizaLink($@"{BaseLink}jogoResultado
/{jogo.IdCampeonatoJogo}
/{jogo.GolsTimeCasa}
/{jogo.GolsTimeVisitante}
/{(jogo.Finalizado ? 1 : 0)}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var check = JsonConvert.DeserializeObject<int>(retorno);

                    boolOk = (check == 1);

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<List<JogoDTO>> JogosDaRodada(int idCampeonato, int rodada)
        {
            List<JogoDTO> lstJogos = new List<JogoDTO>();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}jogosDaRodada
/{idCampeonato}
/{rodada}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    try
                    {
                        object[] lista = JsonConvert.DeserializeObject<object[]>(retorno);

                        lstJogos = JsonConvert.DeserializeObject<List<JogoDTO>>(lista[0].ToString());
                    }
                    catch { }

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstJogos;
        }

        public async Task<int> RodadaAtual(int idCampeonato)
        {
            int intRodadaAtual = 1;

            try
            {
                string strLink = normalizaLink($"{BaseLink}rodadaAtual/{idCampeonato}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var resposta = JsonConvert.DeserializeObject<RodadaAtualDTO[]>(retorno);

                    if (resposta != null)
                        intRodadaAtual = resposta[0].RodadaAtual;

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return intRodadaAtual;
        }

        #endregion
    }
}