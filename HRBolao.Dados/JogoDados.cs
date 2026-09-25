using System.Data;

using MySqlConnector;

using HRBolao.Model;
using System.Runtime.InteropServices.Marshalling;

namespace HRBolao.Dados
{
    public class JogoDados: BaseDados
    {
        #region Construtor

        public JogoDados() { }

        #endregion

        #region Público

        public async Task<bool> GravarResultado(JogoDTO jogo)
        {
            bool boolOk = false;

            try
            {
                string strSql = $@"Call u258112148_1.SpBJogo_Resultado
({jogo.IdCampeonatoJogo},
 {jogo.GolsTimeCasa},
 {jogo.GolsTimeVisitante},
 {jogo.Finalizado});";

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

                boolOk = true;
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<int> Insert(CampeonatoJogoModel jogo,
                                                   string rodadaNome)
        {
            int intIdCampeonatoJogo = 0;

            try
            {
                string strSql = $@"Call u258112148_1.SpBJogo_Insert
({jogo.IdCampeonato},
{jogo.Rodada},
'{rodadaNome}',
'{jogo.Yyyy_Mm_Dd}',
'{jogo.Hh_Mm}',
{jogo.IdTimeCasa},
{jogo.IdTimeVisitante});";

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
                                intIdCampeonatoJogo = reader.GetInt32(0);

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

            return intIdCampeonatoJogo;
        }

        public async Task<List<JogoCampeonatoDTO>> JogosDoCampeonato(int idCampeonato)
        {
            List<JogoCampeonatoDTO> lstJogos = new List<JogoCampeonatoDTO>();

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonato_ListaJogos({idCampeonato});";

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
                                lstJogos.Add(new JogoCampeonatoDTO()
                                {
                                    IdCampeonatoJogo = reader.GetInt32(0),
                                    Rodada = reader.GetInt32(1),
                                    Yyyy_Mm_Dd = reader.GetString(2),
                                    Hh_Mm = reader.GetString(3),
                                    IdTimeCasa = reader.GetInt32(4),
                                    TimeCasa = reader.GetString(5),
                                    GolsTimeCasa = reader.GetInt32(6),
                                    IdTimeVisitante = reader.GetInt32(7),
                                    TimeVisitante = reader.GetString(8),
                                    GolsTimeVisitante = reader.GetInt32(9),
                                    Finalizado = reader.GetBoolean(10),
                                    Adiado = reader.GetBoolean(11),
                                    Cancelado = reader.GetBoolean(12),
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

            return lstJogos;
        }

        public async Task<List<JogoDTO>> JogosDaRodada(int idCampeonato, int rodada)
        {
            List<JogoDTO> lstJogos = new List<JogoDTO>();

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonato_JogosDaRodada({idCampeonato}, {rodada});";

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
                            while (reader.Read())
                            {
                                lstJogos.Add(new JogoDTO()
                                {
                                    IdCampeonatoJogo = reader.GetInt32(0),
                                    Yyyy_Mm_Dd = reader.GetString(1),
                                    Hh_Mm = reader.GetString(2),
                                    IdTimeCasa = reader.GetInt32(3),
                                    TimeCasa = reader.GetString(4),
                                    GolsTimeCasa = reader.GetInt32(5),
                                    IdTimeVisitante = reader.GetInt32(6),
                                    TimeVisitante = reader.GetString(7),
                                    GolsTimeVisitante = reader.GetInt32(8),
                                    PenaltisTimeCasa = reader.GetInt32(9),
                                    PenaltisTimeVisitante = reader.GetInt32(10),
                                    MataMata = reader.GetBoolean(11),
                                    Prorrogacao = reader.GetBoolean(12),
                                    DisputaPenaltis = reader.GetBoolean(13),
                                    Finalizado = reader.GetBoolean(14),
                                    Adiado = reader.GetBoolean(15),
                                    Cancelado = reader.GetBoolean(16)
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

            return lstJogos;
        }

        public async Task<int> RodadaAtual(int idCampeonato)
        {
            int intRodadaAtual = 1;

            try
            {
                string strSql = $"Call u258112148_1.SpBCampeonato_RodadaEmAndamento({idCampeonato});";

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
                                intRodadaAtual = reader.GetInt32(0);

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

            return intRodadaAtual;
        }

        #endregion
    }
}