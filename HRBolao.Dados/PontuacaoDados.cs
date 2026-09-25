using System.Data;

using MySqlConnector;

using HRBolao.Model;

namespace HRBolao.Dados
{
    public class PontuacaoDados: BaseDados
    {
        #region Construtor

        public PontuacaoDados() { }

        #endregion

        #region Público

        public async Task<List<PontuacaoModel>> Lista()
        {
            List<PontuacaoModel> lstPontuacao = new List<PontuacaoModel>();

            try
            {
                string strSql = "Call u258112148_1.SpBPontuacao_Lista();";

                using (MySqlConnection conexao = PegarConexao())
                {
                    using (MySqlCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText = strSql;
                        comando.CommandType = CommandType.Text;

                        if (conexao.State == ConnectionState.Closed)
                            await conexao.OpenAsync();

                        using (MySqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lstPontuacao.Add(new PontuacaoModel()
                                {
                                    IdPontuacao = reader.GetInt32(0),
                                    Descricao = reader.GetString(1),
                                    Pontos = reader.GetInt32(2)
                                });
                            }

                            await reader.CloseAsync();
                            await reader.DisposeAsync();
                        }

                        await comando.DisposeAsync();
                    }

                    await conexao.CloseAsync();
                    await conexao.DisposeAsync();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return lstPontuacao;
        }

        #endregion
    }
}