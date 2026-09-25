using HRBolao.Model;

using Newtonsoft.Json;

namespace HRBolao.Servico
{
    public class PontuacaoServico : BaseServico
    {
        #region Construtor

        public PontuacaoServico() { }

        #endregion

        #region Público

        public async Task<List<PontuacaoModel>> GetLista()
        {
            List<PontuacaoModel> lstPontuacoes = new List<PontuacaoModel>();

            try
            {
                string strLink = $"{BaseLink}pontuacaoLista";

                using (HttpClient cliente = new HttpClient())
                {
                    cliente.Timeout = new TimeSpan(0, 0, 30);
                    var retorno = await cliente.GetStringAsync(strLink);

                    lstPontuacoes = JsonConvert.DeserializeObject<List<PontuacaoModel>>(retorno);

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstPontuacoes;
        }

        public async Task<List<MeusPontosDTO>> MeusPontos(int idJogador, int idCampeonato)
        {
            List<MeusPontosDTO> lstPontos = new List<MeusPontosDTO>();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}meusPontos/{idJogador}/{idCampeonato}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    lstPontos = JsonConvert.DeserializeObject<List<MeusPontosDTO>>(retorno);

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstPontos;
        }

        public async Task<List<PontoRodadaDTO>> PontosRodadaJogador(int idJogador, 
                                                                    int idCampeontao,
                                                                    int rodada)
        {
            List<PontoRodadaDTO> lstPontuacao = new List<PontoRodadaDTO>();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}pontosJogador/{idJogador}/{idCampeontao}/{rodada}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    lstPontuacao = JsonConvert.DeserializeObject<List<PontoRodadaDTO>>(retorno);

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstPontuacao;
        }

        public async Task<List<RankingEmpresaDTO>> RankingEmpresaRodada(int idEmpresa,
                                                                        int idCampeonato,
                                                                        int rodada)
        {
            List<RankingEmpresaDTO> lstRanking = new List<RankingEmpresaDTO>();

            try
            {
                string strLink = normalizaLink($@"{BaseLink}rankingRodada
/{idEmpresa}
/{idCampeonato}
/{rodada}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    if (retorno != null)
                        lstRanking = JsonConvert.DeserializeObject<List<RankingEmpresaDTO>>(retorno);

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstRanking;
        }

        #endregion
    }
}