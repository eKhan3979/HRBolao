using HRBolao.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HRBolao.Servico
{
    public class EmpresaServico: BaseServico
    {
        #region Construtor

        public EmpresaServico() { }

        #endregion

        #region Público

        public async Task<List<EmpresaModel>> ListaEmpresas(bool boolSoAtivos)
        {
            List<EmpresaModel> lstEmpresas = new List<EmpresaModel>();

            try
            {
                string strLink = $"{BaseLink}empresas";
                
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 30);

                    var retorno = await client.GetStringAsync(strLink);

                    lstEmpresas = JsonConvert.DeserializeObject<List<EmpresaModel>>(retorno);

                    client.Dispose();
                }
                
                /*
                using (HttpClientServico cliente = new HttpClientServico())
                {
                    var retorno = await cliente.GetDadosStringAsync("https://olive-sparrow-185968.hostingersite.com/bolao/empresas");

                    lstEmpresas = JsonConvert.DeserializeObject<List<EmpresaModel>>(retorno);

                    cliente.Dispose();
                }
                */
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstEmpresas;
        }

        #endregion
    }
}