using System.Data;

using MySqlConnector;

using HRBolao.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace HRBolao.Dados
{
    public class CampeonatoDados: BaseDados
    {
        #region Construtor

        public CampeonatoDados() { }

        #endregion

        #region Público

        public async Task<List<CampeonatoDTO>> CampeonatosDaEmpresa(int idEmpresa)
        {
            List<CampeonatoDTO> lstCampeonatos = new List<CampeonatoDTO>();

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonatosEmpresa_Ativos({idEmpresa});";

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
                                lstCampeonatos.Add(new CampeonatoDTO()
                                {
                                    Nome = reader.GetString(0),
                                    IdCampeonato = reader.GetInt32(1),
                                    Ano = reader.GetInt32(2),
                                    IdEmpresaCampeonato = reader.GetInt32(3)
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

            return lstCampeonatos;
        }

        public async Task<List<RodadaDTO>> Campeonato_Rodadas(int idCampeonato)
        {
            List<RodadaDTO> lstRodadas = new List<RodadaDTO>();

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonato_Rodadas({idCampeonato});";

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
                                lstRodadas.Add(new RodadaDTO()
                                {
                                    Rodada = reader.GetInt32(0),
                                    RodadaNome = reader.GetString(1)
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

            return lstRodadas;
        }

        public async Task<int> CampeonatoTime_Insert(CampeonatoTimeModel cTime)
        {
            int intIdCampeonatoTime = 0;

            try
            {
                string strSql = $@"Call u258112148_1.SpBCampeonatoTimes_Insert
(
{cTime.IdCampeonato},
{cTime.IdTime});";

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
                                intIdCampeonatoTime = reader.GetInt32(0);

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

            return intIdCampeonatoTime;
        }

        public async Task<bool> Inativar(int idCampeonato)
        {
            bool boolOk = false;

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonato_Inativar({idCampeonato});";

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

        public async Task<int> Insert(CampeonatoModel campeonato)
        {
            int intIdCampeonato = campeonato.IdCampeonato;

            try
            {
                string strSql = $@"Call u258112148_1.SpBCampeonato_Insert(
'{campeonato.Nome}',
{campeonato.Ano});";

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
                                intIdCampeonato = reader.GetInt32(0);

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

            return intIdCampeonato;
        }

        public async Task<List<CampeonatoModel>> Lista(bool soAtivos = true)
        {
            List<CampeonatoModel> lstCampeonatos = new List<CampeonatoModel>();

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonatos_Lista({(soAtivos ? 1 : 0)});";

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
                                lstCampeonatos.Add(new CampeonatoModel()
                                {
                                    IdCampeonato = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    Ano = reader.GetInt32(2),
                                    Ativo = reader.GetBoolean(3)
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

            return lstCampeonatos;
        }

        #endregion
    }
}