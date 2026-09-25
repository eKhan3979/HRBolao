using System.Data;

using MySqlConnector;

using HRBolao.Model;
using System.Security.AccessControl;

namespace HRBolao.Dados
{
    public class ApostaDados: BaseDados
    {
        #region Construtor

        public ApostaDados() { }

        #endregion

        #region Público

        public async Task<List<ApostaDTO>> GetApostasRodada(int idCampeonato,
                                                            int idJogador,
                                                            int rodada)
        {
            List<ApostaDTO> lstApostas = new List<ApostaDTO>();

            try
            {
                string strSql = $@"Call u258112148_1.SpBCampeonato_ApostasRodada(
{idCampeonato},
{idJogador},
{rodada});";

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
                                lstApostas.Add(new ApostaDTO()
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
                                    Cancelado = reader.GetBoolean(16),
                                    IdAposta = ParaInteiro(reader[17]),
                                    GolsApostaTimeCasa = ParaInteiro(reader[18]),
                                    GolsApostaTimeVisitante = ParaInteiro(reader[19]),
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

            return lstApostas;
        }

        public async Task<int> Gravar(ApostaModel aposta)
        {
            int intIdAposta = aposta.IdAposta;

            try
            {
                string strSql = $@"Call u258112148_1.SpBAposta_Gravar(
{aposta.IdAposta},
{aposta.IdCampeonatoJogo},
{aposta.IdJogador},
{aposta.GolsTimeCasa},
{aposta.GolsTimeVisitante},
{(aposta.Prorrogacao ? 1 : 0)},
{(aposta.DisputaPenaltis ? 1 : 0)},
{aposta.PenaltisTimeCasa},
{aposta.PenaltisTimeVisitante});";

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
                                intIdAposta = reader.GetInt32(0);

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

            return intIdAposta;
        }

        public async Task<List<ApostaEmpresaDTO>> PorEmpresa(int idEmpresa,
                                                      int idCampeonato)
        {
            List<ApostaEmpresaDTO> lstRanking = new List<ApostaEmpresaDTO>();

            try
            {
                string strSql = $@"Call u258112148_1.SpBAposta_RankingEmpresa(
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
                            while (await reader.ReadAsync())
                                lstRanking.Add(new ApostaEmpresaDTO()
                                {
                                    Rodada = reader.GetInt32(0),
                                    IdCampeonatoJogo = reader.GetInt32(1),
                                    GolsTimeCasa = reader.GetInt32(2),
                                    GolsTimeVisitante = reader.GetInt32(3),
                                    Finalizado = reader.GetBoolean(4),
                                    IdJogador = reader.GetInt32(5),
                                    Jogador = reader.GetString(6),
                                    ApostaGolsTimeCasa = reader.GetInt32(7),
                                    ApostaGolsTimeVisitante = reader.GetInt32(8),
                                    TimeCasa = reader.GetInt32(9),
                                    TimeVisitante = reader.GetInt32(10)
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

            return lstRanking;
        }

        #endregion
    }
}