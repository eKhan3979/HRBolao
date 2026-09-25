using System.Data;

using MySqlConnector;

using HRBolao.Model;

namespace HRBolao.Dados
{
    public class EmpresaDados: BaseDados
    {
        #region Construtor

        public EmpresaDados() { }

        #endregion

        #region Público

        public async Task<int> AdicionarCampeonato(int idEmpresa, int idCampeonato)
        {
            int idEmpresaCampeonato = 0;

            try
            {
                string strSql = $@"Call u258112148_1.SpBEmpresaCampeonato_Adicionar (
{idEmpresa},
{idCampeonato});";

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
                            if (await reader.ReadAsync())
                                idEmpresaCampeonato = reader.GetInt32(0);

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

            return idEmpresaCampeonato;
        }

        public async Task<EmpresaModel> Get(int idEmpresa)
        {
            EmpresaModel empresa = new EmpresaModel();

            try
            {
                string strSql = $"Call u258112148_1.SpBEmpresa_Get({idEmpresa});";

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
                            if (reader.Read())
                                empresa = new EmpresaModel()
                                {
                                    IdEmpresa = reader.GetInt32(0),
                                    NomeEmpresa = reader.GetString(1),
                                    DataCadastro = reader.GetDateTime(2),
                                    Ativo = reader.GetBoolean(3)
                                };

                            await reader.CloseAsync();
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

            return empresa;
        }

        public async Task<int> Gravar(EmpresaModel empresa)
        {
            int intIdEmpresa = 0;

            try
            {
                string strSql = $@"Call u258112148_1.SpBEmpresa_Gravar(
{empresa.IdEmpresa},
'{empresa.NomeEmpresa}');";

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
                            if (reader.Read())
                                intIdEmpresa = reader.GetInt32(0);

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

            return intIdEmpresa;
        }

        public async Task<bool> Inativar(int intIdEmpresa)
        {
            bool boolOk = false;

            try
            {
                string strSql = $"Call u258112148_1.SpBEmpresa_Inativar({intIdEmpresa});";

                using (MySqlConnection conexao = PegarConexao())
                {
                    using (MySqlCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText = strSql;
                        comando.CommandType = CommandType.Text;

                        if (conexao.State == ConnectionState.Closed)
                            await conexao.OpenAsync();

                        await comando.ExecuteNonQueryAsync();

                        await comando.DisposeAsync();

                        boolOk = true;
                    }

                    await conexao.CloseAsync();
                    await conexao.DisposeAsync();
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<List<EmpresaModel>> Lista(bool soAtivos = true)
        {
            List<EmpresaModel> lstEmpresas = new List<EmpresaModel>();

            try
            {
                using (MySqlConnection conexao = PegarConexao())
                {
                    using (MySqlCommand comando = conexao.CreateCommand())
                    {
                        if (conexao.State == ConnectionState.Closed)
                            conexao.Open();

                        comando.CommandText = $"Call u258112148_1.SpEmpresa_Lista({((soAtivos) ? 1 : 0)});";
                        comando.CommandType = CommandType.Text;

                        using (MySqlDataReader reader = await comando.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                                lstEmpresas.Add(new EmpresaModel()
                                {
                                    IdEmpresa = reader.GetInt32(0),
                                    NomeEmpresa = reader.GetString(1),
                                    DataCadastro = reader.GetDateTime(2),
                                    Ativo = reader.GetBoolean(3)
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

            return lstEmpresas;
        }

        #endregion
    }
}