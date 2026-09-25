using System;

using Newtonsoft.Json;

using HRBolao.Model;

namespace HRBolao.Servico
{
    public class ApostaServico: BaseServico
    {
        #region Construtor

        public ApostaServico() { }

        #endregion

        #region Público

        public async Task<List<ApostaDTO>> GetApostasRodada(int idCampeonato,
                                                            int idJogador,
                                                            int rodada)
        {
            List<ApostaDTO> lstApostas = new List<ApostaDTO>();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}apostasDaRodada
/{idCampeonato}
/{idJogador}
/{rodada}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var lista = JsonConvert.DeserializeObject<List<ApostaDTO>>(retorno);

                    if (lista != null)
                        lstApostas = lista;

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw new Exception(excErro.Message);
            }

            return lstApostas;        
        }

        public async Task<int> apostaGravar(ApostaModel aposta)
        {
            int intIdAposta = aposta.IdAposta;

            try
            {
                string strLink = normalizaLink($@"{BaseLink}SetAposta
/{aposta.IdAposta}
/{aposta.IdCampeonatoJogo}
/{aposta.IdJogador}
/{aposta.GolsTimeCasa}
/{aposta.GolsTimeVisitante}
/0
/0
/0
/0");

                /*
                string strLink = normalizaLink($@"{BaseLink}SetAposta
?idAposta={aposta.IdAposta}
&idCampeonatoJogo={aposta.IdCampeonatoJogo}
&idJogador={aposta.IdJogador}
&gols1={aposta.GolsTimeCasa}
&gols2={aposta.GolsTimeVisitante}
&prorrogacao={(aposta.Prorrogacao ? 1: 0)}
&penaltis={(aposta.DisputaPenaltis ? 1 : 0)}
&penaltis1={aposta.PenaltisTimeVisitante}
&penaltis2={aposta.PenaltisTimeVisitante}");
                */

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    intIdAposta = JsonConvert.DeserializeObject<int>(retorno);

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw new Exception(excErro.Message);
            }

            return intIdAposta;
        }

        public async Task<List<ApostaIdDTO>> GravarLista(List<ApostaGolDTO> lstApostas)
        {
            List<ApostaIdDTO> lstIds = new List<ApostaIdDTO>();

            try
            {
                string strLink = "";

                int intId = 0;

                using (HttpClient cliente = new HttpClient())
                {
                    foreach (ApostaGolDTO aposta in lstApostas)
                    {
                        strLink = normalizaLink($@"{BaseLink}apostaGravar
/{((aposta.IdAposta != null) ? aposta.IdAposta : 0)}
/{aposta.IdCampeonatoJogo}
/{aposta.IdJogador}
/{((aposta.GolsTimeCasa != null) ? aposta.GolsTimeCasa : 0)}
/{((aposta.GolsTimeVisitante != null) ? aposta.GolsTimeVisitante : 0)}");

                        var retorno = await cliente.GetStringAsync(strLink);

                        var id = JsonConvert.DeserializeObject<List<ApostaRetornoDTO>>(retorno);

                        if ((id != null) && (id.Count > 0))
                            lstIds.Add(new ApostaIdDTO()
                            {
                                IdAposta = id[0].IdAposta,
                                IdCampeonatoJogo = aposta.IdCampeonatoJogo
                            });
                    }

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw new Exception(excErro.Message);
            }

            return lstIds;
        }

        #endregion
    }
}