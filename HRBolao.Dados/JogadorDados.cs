using System.Data;

using MySqlConnector;

using HRBolao.Model;

namespace HRBolao.Dados
{
    public class JogadorDados: BaseDados
    {
        #region Construtor

        public JogadorDados() { }

        #endregion

        #region Público

        public async Task<JogadorModel> Get(int intIdEmpresa,
                                         string strNomeApelido)
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                string strSql = $@"Call u258112148_1.SpBJogador_Get({intIdEmpresa}, '{strNomeApelido}');";

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
                            if (reader.Read())
                                jogador = new JogadorModel()
                                {
                                    IdJogador = reader.GetInt32(0),
                                    IdEmpresa = reader.GetInt32(1),
                                    NomeApelido = reader.GetString(2),
                                    Senha = reader.GetString(3),
                                    email = reader.GetString(4),
                                    DataCadastro = reader.GetDateTime(5),
                                    Ativo = reader.GetBoolean(6)
                                };

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

            return jogador;
        }

        public async Task<int> Gravar(JogadorModel jogador)
        {
            int intIdJogador = jogador.IdJogador;

            try
            {
                string strSql = $@"Call u258112148_1.SpBJogador_Gravar
({jogador.IdJogador},
 {jogador.IdEmpresa},
'{jogador.NomeApelido}',
'{jogador.Senha}',
'{jogador.email}');";

                using (MySqlConnection conexao = PegarConexao())
                {
                    using (MySqlCommand comando = conexao.CreateCommand())
                    {
                        if (conexao.State == System.Data.ConnectionState.Closed)
                            await conexao.OpenAsync();

                        comando.CommandText = strSql;
                        comando.CommandType = System.Data.CommandType.Text;

                        using (MySqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                                intIdJogador = reader.GetInt32(0);

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

            return intIdJogador;
        }

        public async Task<List<JogadorModel>> ListaDaEmpresa(int idEmpresa)
        {
            List<JogadorModel> lstJogadores = new List<JogadorModel>();

            try
            {
                string strSql = $"Call u258112148_1.SpBJogador_ListaDaEmpresa({idEmpresa});";

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
                                lstJogadores.Add(new JogadorModel()
                                {
                                    IdJogador   = reader.GetInt32(0),
                                    IdEmpresa = reader.GetInt32(1),
                                    NomeApelido = reader.GetString(2),
                                    email = reader.GetString(3),
                                    DataCadastro = reader.GetDateTime(4)
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

            return lstJogadores;
        }

        public async Task<JogadorModel> Login(int idEmpresa,
                                           string nomeApelido,
                                           string senha)
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                string strSql = $@"Call u258112148_1.SpBJogador_Login
({idEmpresa},
'{nomeApelido}',
'{senha}');";

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
                            if (reader.Read())
                                jogador = new JogadorModel()
                                {
                                    IdJogador = reader.GetInt32(0),
                                    IdEmpresa = reader.GetInt32(1),
                                    NomeApelido = reader.GetString(2),
                                    Senha = reader.GetString(3),
                                    email = reader.GetString(4),
                                    DataCadastro = reader.GetDateTime(5),
                                    Ativo = reader.GetBoolean(6)
                                };

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

            return jogador;
        }

        #endregion
    }
}