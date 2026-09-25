using System;

using Newtonsoft.Json;

using HRBolao.Model;

namespace HRBolao.Servico
{
    public class CampeonatoServico: BaseServico
    {
        #region Construtor

        public CampeonatoServico() { }

        #endregion

        #region Público

        public async Task<List<CampeonatoDTO>> CampeonatosDaEmpresa(int idEmpresa)
        {
            List<CampeonatoDTO> lstCampeonatos = new List<CampeonatoDTO>();

            try
            {
                string strLink = normalizaLink($"{BaseLink}campeonatosDaEmpresa/{idEmpresa}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var lista = JsonConvert.DeserializeObject<List<CampeonatoDTO>>(retorno);

                    if (lista != null)
                        lstCampeonatos = lista;

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw new Exception(excErro.Message);
            }

            return lstCampeonatos;
        }

        public async Task<List<RodadaDTO>> CampeonatoRodadas(int idCampeonato)
        {
            List<RodadaDTO> lstRodadas = new List<RodadaDTO>();

            try
            {
                string strLink = normalizaLink($"{BaseLink}campeonatoRodadas/{idCampeonato}");

                using (HttpClient cliente = new HttpClient())
                {
                    var retorno = await cliente.GetStringAsync(strLink);

                    var lista = JsonConvert.DeserializeObject<List<RodadaDTO>>(retorno);

                    if (lista != null)
                        lstRodadas = lista;

                    cliente.Dispose();
                }
            }
            catch (Exception excErro)
            {
                throw new Exception(excErro.Message);
            }

            return lstRodadas;
        }

        #endregion
    }
}