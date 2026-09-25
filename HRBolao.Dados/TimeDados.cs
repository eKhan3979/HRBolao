using System.Data;

using MySqlConnector;

using HRBolao.Model;

namespace HRBolao.Dados
{
    public class TimeDados: BaseDados
    {
        #region Construtor

        public TimeDados() { }

        #endregion

        #region Público

        public async Task<int> Gravar(TimeModel time)
        {
            int intIdTime = time.IdTime;

            try
            {
                string strSql = $@"Call u258112148_1.SpBTime_Gravar(
 {time.IdTime},
'{time.Nome}',
'{time.UF}',
'{time.Cidade}',
 {time.Ativo},
'{time.Abreviatura}');";

                using (MySqlConnection conexao = PegarConexao())
                {
                    using (MySqlCommand comando = conexao.CreateCommand())
                    {
                        if (conexao.State == ConnectionState.Closed)
                            await conexao.OpenAsync();

                        comando.CommandText = strSql;
                        comando.CommandType = CommandType.Text;

                        using (MySqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                                intIdTime = reader.GetInt32(0);

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

            return intIdTime;
        }

        public async Task<List<TimeModel>> Lista(bool soAtivos = true)
        {
            List<TimeModel> lstTimes = new List<TimeModel>();

            string strSql = $"Call u258112148_1.SpBTimes_Lista({(soAtivos ? 1 : 0)});";

            try
            {
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
                                lstTimes.Add(new TimeModel()
                                {
                                    IdTime = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    UF = reader.GetString(2),
                                    Cidade = reader.GetString(3),
                                    Ativo = reader.GetBoolean(4),
                                    Abreviatura = reader.GetString(5)
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

            return lstTimes;
        }

        public async Task<List<TimeModel>> TimesDoCampeonato(int idCampeonato)
        {
            List<TimeModel> lstTimes = new List<TimeModel>();

            try
            {
                string strSql = $"Call  u258112148_1.SpBCampeonatoTimes({idCampeonato});";

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
                                lstTimes.Add(new TimeModel()
                                {
                                    IdTime = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    UF = reader.GetString(2),
                                    Cidade = reader.GetString(3),
                                    Ativo = reader.GetBoolean(4)
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

            return lstTimes;
        }

        #endregion
    }
}