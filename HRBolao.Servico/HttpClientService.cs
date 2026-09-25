using System;
using System.Net.Http.Headers;

namespace HRBolao.Servico
{
    public class HttpClientService: HttpClient
    {
        private string _token = "sN77deaH3hruj26Hklg7b17R9e4zS18We5d2eKHJ5aneT31bV";

        public HttpClientService()
        {
            this.BaseAddress = new Uri("https://lightcyan-echidna-380972.hostingersite.com/bolao/");
        }

        public async Task<string?> GetDadosStringAsync(string strLink)
        {
            this.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            var response = await this.GetAsync(strLink);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new Exception(
                    $"Erro {response.StatusCode}: {erro}"
                );
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}