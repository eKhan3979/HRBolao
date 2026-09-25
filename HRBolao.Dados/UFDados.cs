using System.Data;

using MySqlConnector;

using HRBolao.Model;

namespace HRBolao.Dados
{
    public class UFDados: BaseDados
    {
        #region Construtor

        public UFDados() { }

        #endregion

        #region Público

        public async Task<List<UFModel>> Lista()
        {
            List<UFModel> lstUFs = new List<UFModel>();

            try
            {
                using (MySqlConnection conexao = PegarConexao())
                {
                    using (MySqlCommand comando = conexao.CreateCommand())
                    {
                        if (conexao.State == ConnectionState.Closed)
                            await conexao.OpenAsync();

                        comando.CommandText = "Call u258112148_1.SpBUF_Lista();";
                        comando.CommandType = CommandType.Text;

                        using (MySqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                                lstUFs.Add(new UFModel()
                                {
                                    UF = reader.GetString(0)
                                });

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

            return lstUFs;
        }

        #endregion
    }
}