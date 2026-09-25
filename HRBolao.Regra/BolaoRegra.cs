using System;
using System.Collections.Generic;
using System.Text;

using HRBolao.Model;
using HRBolao.Servico;
using HRBolao.ViewModel;

namespace HRBolao.Regra
{
    public class BolaoRegra
    {
        #region Variáveis da Classe

        private BolaoViewModel _vm;

        #endregion

        #region Construtor

        public BolaoRegra(ref BolaoViewModel vm)
        {
            _vm = vm;
        }

        #endregion

        #region Private

        private int pontuacaoJogo(ApostaDTO aposta)
        {
            int intPontuacao = 0;

            try
            {
                if ((aposta.GolsTimeCasa == aposta.GolsApostaTimeCasa) &&
                    (aposta.GolsTimeVisitante == aposta.GolsApostaTimeVisitante))
                    intPontuacao = _vm.ListaPontuacao[EnumPontuacao.ResultadoExato.GetHashCode()].Pontos;
                else
                {
                    if ((aposta.GolsTimeCasa == aposta.GolsTimeVisitante) &&
                        (aposta.GolsApostaTimeCasa == aposta.GolsApostaTimeVisitante))
                        intPontuacao = _vm.ListaPontuacao[EnumPontuacao.ResultadoCerto.GetHashCode()].Pontos;
                    else if ((aposta.GolsTimeCasa > aposta.GolsTimeVisitante) &&
                             (aposta.GolsApostaTimeCasa > aposta.GolsApostaTimeVisitante))
                        intPontuacao = _vm.ListaPontuacao[EnumPontuacao.ResultadoCerto.GetHashCode()].Pontos;
                    else if ((aposta.GolsTimeCasa < aposta.GolsTimeVisitante) &&
                             (aposta.GolsApostaTimeCasa < aposta.GolsApostaTimeVisitante))
                        intPontuacao = _vm.ListaPontuacao[EnumPontuacao.ResultadoCerto.GetHashCode()].Pontos;

                    if ((aposta.GolsTimeCasa == aposta.GolsApostaTimeCasa) ||
                        (aposta.GolsTimeVisitante == aposta.GolsApostaTimeVisitante))
                        intPontuacao += _vm.ListaPontuacao[EnumPontuacao.GolsCerto.GetHashCode()].Pontos;
                }
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return intPontuacao;
        }

        private string yyyy_Mm_Dd(string strDd_Mm_Yyyy)
        {
            return strDd_Mm_Yyyy.Substring(6, 4) + "/" +
                   strDd_Mm_Yyyy.Substring(3, 2) + "/" +
                   strDd_Mm_Yyyy.Substring(0, 2);
        }

        #endregion

        #region Público

        public void AtualizarAposta(ApostaGolDTO aposta)
        {
            ApostaDTO apostaSelecionada = _vm.ListaApostas.FirstOrDefault(t => t.IdCampeonatoJogo.Equals(aposta.IdCampeonatoJogo));

            if (aposta.GolsTimeCasa > -1)
                apostaSelecionada.GolsApostaTimeCasa = aposta.GolsTimeCasa;
            else
                apostaSelecionada.GolsApostaTimeVisitante = aposta.GolsTimeVisitante;
        }

        public async Task<bool> CarregarApostas()
        {
            if ((_vm != null) &&
                (_vm.Iniciado))
            {
                _vm.ErroIndex = 0;

                try
                {
                    _vm.ErroMsg.Clear();

                    _vm.PontosNaRodada = 0;
                    _vm.ListaApostas = new List<ApostaDTO>();

                    if ((_vm.CampeonatoSelecionado != null) &&
                        (_vm.Logado != null))
                    {
                        List<ApostaDTO> lstApostas = await (new ApostaServico()).GetApostasRodada(_vm.CampeonatoSelecionado.IdCampeonato,
                                                                                                  _vm.Logado.IdJogador,
                                                                                                  _vm.RodadaSelecionada.Rodada);

                        string strYyyy_Mm_Dd = DateTime.Today.ToString("yyyy/MM/dd"),
                                    strHh_Mm = DateTime.Now.ToString("HH:mm");

                        for (int intAposta = 0; intAposta < lstApostas.Count; intAposta++)
                        {
                            lstApostas[intAposta].Numero = intAposta + 1;
                            lstApostas[intAposta].GolsCasaOriginal = lstApostas[intAposta].GolsApostaTimeCasa;
                            lstApostas[intAposta].GolsVisitanteOriginal = lstApostas[intAposta].GolsApostaTimeVisitante;

                            if (lstApostas[intAposta].Finalizado)
                            {
                                lstApostas[intAposta].Pontos = pontuacaoJogo(lstApostas[intAposta]);
                                lstApostas[intAposta].Editavel = false;
                                lstApostas[intAposta].VerResultado = true;
                            }
                            else
                            {
                                lstApostas[intAposta].Pontos = 0;

                                string strYyyy_Mm_Dd_Jogo = lstApostas[intAposta].Yyyy_Mm_Dd.Replace("-", "/");

                                switch (strYyyy_Mm_Dd_Jogo.CompareTo(strYyyy_Mm_Dd))
                                {
                                    case < 0:
                                        lstApostas[intAposta].Editavel = false;
                                        lstApostas[intAposta].VerResultado = true;
                                        break;
                                    case 0:
                                        if (lstApostas[intAposta].Hh_Mm.CompareTo(strHh_Mm) < 0)
                                        {
                                            lstApostas[intAposta].Editavel = false;
                                            lstApostas[intAposta].VerResultado = true;
                                        }
                                        else
                                        {
                                            lstApostas[intAposta].Editavel = true;
                                            lstApostas[intAposta].VerResultado = false;
                                        }
                                        break;
                                    case > 0:
                                        lstApostas[intAposta].Editavel = true;
                                        lstApostas[intAposta].VerResultado = false;
                                        break;
                                }                                
                            }
                        }

                        _vm.ListaApostas = lstApostas;

                        _vm.PontosNaRodada = _vm.ListaApostas.Select(t => t.Pontos).Sum();
                    }
                }
                catch (Exception excErro)
                {
                    _vm.ErroIndex = 1;
                    _vm.ErroMsg.AppendLine(excErro.Message);
                }

                return (_vm.ErroIndex == 0);
            }
            else
                return false;
        }

        public async Task<bool> CarregarCampeonato()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                _vm.ListaRodadas = await (new CampeonatoServico()).CampeonatoRodadas(_vm.CampeonatoSelecionado.IdCampeonato);

                _vm.RodadaAtual = await (new JogoServico()).RodadaAtual(_vm.CampeonatoSelecionado.IdCampeonato);

                _vm.RodadaSelecionada = new RodadaDTO();

                if (_vm.ListaRodadas.Count > 0)
                {
                    _vm.RodadaPrimeira = _vm.ListaRodadas[0].Rodada;
                    _vm.RodadaUltima = _vm.ListaRodadas[_vm.ListaRodadas.Count - 1].Rodada;

                    RodadaDTO rodada = _vm.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_vm.RodadaAtual));

                    _vm.RodadaSelecionada = new RodadaDTO()
                    {
                        Rodada = rodada.Rodada,
                        RodadaNome = rodada.RodadaNome
                    };                        
                }

                List<ApostaDTO> lstApostas = await (new ApostaServico()).GetApostasRodada(_vm.CampeonatoSelecionado.IdCampeonato,
                                                                                          _vm.Logado.IdJogador,
                                                                                          _vm.RodadaSelecionada.Rodada);

                string strYyyy_Mm_Dd = DateTime.Today.ToString("yyyy/MM/dd"),
                            strHh_Mm = DateTime.Now.ToString("HH:mm");

                for (int intNumero = 0; intNumero < lstApostas.Count; intNumero++)
                {
                    lstApostas[intNumero].Numero = intNumero + 1;
                    lstApostas[intNumero].GolsCasaOriginal = lstApostas[intNumero].GolsApostaTimeCasa;
                    lstApostas[intNumero].GolsVisitanteOriginal = lstApostas[intNumero].GolsApostaTimeVisitante;

                    if (lstApostas[intNumero].Finalizado)
                        lstApostas[intNumero].Pontos = pontuacaoJogo(lstApostas[intNumero]);
                    else
                        lstApostas[intNumero].Pontos = 0;

                    if (lstApostas[intNumero].Finalizado)
                    {
                        lstApostas[intNumero].Pontos = pontuacaoJogo(lstApostas[intNumero]);
                        lstApostas[intNumero].Editavel = false;
                        lstApostas[intNumero].VerResultado = true;
                    }
                    else
                    {
                        lstApostas[intNumero].Pontos = 0;

                        string strYyyy_Mm_Dd_Jogo = lstApostas[intNumero].Yyyy_Mm_Dd.Replace("-", "/");

                        switch (strYyyy_Mm_Dd_Jogo.CompareTo(strYyyy_Mm_Dd))
                        {
                            case < 0:
                                lstApostas[intNumero].Editavel = false;
                                lstApostas[intNumero].VerResultado = true;
                                break;
                            case 0:
                                if (lstApostas[intNumero].Hh_Mm.CompareTo(strHh_Mm) < 0)
                                {
                                    lstApostas[intNumero].Editavel = false;
                                    lstApostas[intNumero].VerResultado = true;
                                }
                                else
                                {
                                    lstApostas[intNumero].Editavel = true; 
                                    lstApostas[intNumero].VerResultado = false;
                                }
                                break;
                            case > 0:
                                lstApostas[intNumero].Editavel = true;
                                lstApostas[intNumero].VerResultado = false;
                                break;
                        }

                        lstApostas[intNumero].VerResultado = !lstApostas[intNumero].Editavel;

                        /*
                        if (_vm.ListaApostas[intNumero].Yyyy_Mm_Dd.CompareTo(strYyyy_Mm_Dd) > 0)
                            _vm.ListaApostas[intNumero].Editavel = false;
                        else if (_vm.ListaApostas[intNumero].Yyyy_Mm_Dd.CompareTo(strYyyy_Mm_Dd) == 0)
                        {
                            if (_vm.ListaApostas[intNumero].Hh_Mm.CompareTo(strHh_Mm) > 0)
                                _vm.ListaApostas[intNumero].Editavel = false;
                            else
                                _vm.ListaApostas[intNumero].Editavel = true;
                        }
                        else
                            _vm.ListaApostas[intNumero].Editavel = true;

                        _vm.ListaApostas[intNumero].EmAndamento = !_vm.ListaApostas[intNumero].Editavel;
                        */
                    }

                    _vm.ListaApostas = lstApostas;
                }

                _vm.PontosNaRodada = _vm.ListaApostas.Select(t => t.Pontos).Sum();

                await CarregarMeusPontos();
                await CarregarRanking();
            }
            catch (Exception excErro)
            {
                _vm.ErroMsg.AppendLine(excErro.Message);
                _vm.ErroIndex = 1;
            }

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> CarregarMeusPontos()
        {
            bool boolOk = false;

            try
            {
                _vm.ListaMeusPontos = await (new PontuacaoServico()).MeusPontos(_vm.Logado.IdJogador,
                                                                                _vm.CampeonatoSelecionado.IdCampeonato);

                boolOk = true;
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<bool> CarregarJogadorPontosRodada(int idJogador)
        {
            bool boolOk = false;

            try
            {
                List<PontoRodadaDTO> lstPontos = await (new PontuacaoServico()).PontosRodadaJogador(idJogador,
                                                                                                   _vm.CampeonatoSelecionado.IdCampeonato,
                                                                                                   _vm.RodadaSelecionada.Rodada);

                for (int intNumero = 0; intNumero < lstPontos.Count; intNumero++)
                    lstPontos[intNumero].Numero = intNumero + 1;

                _vm.ListaPontosDetalhes = lstPontos;

                boolOk = true;
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<bool> CarregarRanking()
        {
            bool boolOk = false;

            try
            {
                List<RankingEmpresaDTO> lstRanking = await (new PontuacaoServico()).RankingEmpresaRodada(_vm.Logado.IdEmpresa,
                                                                                                         _vm.CampeonatoSelecionado.IdCampeonato,
                                                                                                         _vm.RodadaSelecionada.Rodada);

                List<RankingEmpresaNmDto> lstRankingNm = new List<RankingEmpresaNmDto>();

                for (int intRank = 0; intRank < lstRanking.Count; intRank++)
                    lstRankingNm.Add(new RankingEmpresaNmDto()
                    {
                        Numero = intRank + 1,
                        IdJogador = lstRanking[intRank].IdJogador,
                        NomeApelido = lstRanking[intRank].NomeApelido,
                        Pontos = lstRanking[intRank].Pontos
                    });

                _vm.ListaRanking = lstRankingNm;

                boolOk = true;
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        public async Task<bool> GravarAposta(int idJogador, JogoDTO jogo)
        {
            bool boolOk = false;

            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                ApostaModel aposta = new ApostaModel()
                {
                    IdAposta = jogo.IdAposta,
                    IdCampeonatoJogo = jogo.IdCampeonatoJogo,
                    IdJogador = idJogador,
                    GolsTimeCasa = jogo.GolsTimeCasa,
                    GolsTimeVisitante = jogo.GolsTimeVisitante,
                    Prorrogacao = jogo.Prorrogacao,
                    DisputaPenaltis = jogo.DisputaPenaltis,
                    PenaltisTimeCasa = jogo.PenaltisTimeCasa,
                    PenaltisTimeVisitante = jogo.PenaltisTimeVisitante,
                    Pontos = 0
                };

                aposta.IdAposta = await (new ApostaServico()).apostaGravar(aposta);

                if (aposta.IdAposta > 0)
                {
                    ApostaDTO? apostaEdit = _vm.ListaApostas.FirstOrDefault(t => t.IdAposta.Equals(aposta.IdAposta));

                    if (apostaEdit != null)
                        apostaEdit = new ApostaDTO()
                        {
                            Finalizado = apostaEdit.Finalizado,
                            GolsApostaTimeCasa = apostaEdit.GolsApostaTimeCasa,
                            GolsApostaTimeVisitante = apostaEdit.GolsApostaTimeVisitante,
                            GolsCasaOriginal = apostaEdit.GolsApostaTimeCasa,
                            GolsTimeCasa = apostaEdit.GolsTimeCasa,
                            GolsTimeVisitante = apostaEdit.GolsTimeVisitante,
                            GolsVisitanteOriginal = apostaEdit.GolsApostaTimeVisitante,
                            Hh_Mm = apostaEdit.Hh_Mm,
                            IdAposta = apostaEdit.IdAposta,
                            IdCampeonatoJogo = apostaEdit.IdCampeonatoJogo,
                            IdTimeCasa = apostaEdit.IdTimeCasa,
                            IdTimeVisitante = apostaEdit.IdTimeVisitante,
                            Numero = apostaEdit.Numero,
                            Pontos = apostaEdit.Pontos,
                            TimeCasa = apostaEdit.TimeCasa,
                            TimeVisitante = apostaEdit.TimeVisitante,
                            Yyyy_Mm_Dd = apostaEdit.Yyyy_Mm_Dd
                        };
                    else
                        _vm.ListaApostas.Add(apostaEdit);
                }
                else
                    throw new Exception("- Erro na gravação !");
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return boolOk;
        }

        public async Task<bool> GravarApostas()
        {
            _vm.ErroIndex = 0;

            try
            {
                _vm.ErroMsg.Clear();

                List<ApostaGolDTO> lstApostas = new List<ApostaGolDTO>();

                foreach (ApostaDTO jogo in _vm.ListaApostas)
                {
                    /*
                    if ((jogo.IdAposta == 0) ||
                        (jogo.GolsApostaTimeCasa != jogo.GolsCasaOriginal) ||
                        (jogo.GolsApostaTimeVisitante != jogo.GolsVisitanteOriginal))
                    {
                        */
                    lstApostas.Add(new ApostaGolDTO()
                    {
                        IdAposta = jogo.IdAposta,
                        IdCampeonatoJogo = jogo.IdCampeonatoJogo,
                        IdJogador = _vm.Logado.IdJogador,
                        GolsTimeCasa = jogo.GolsApostaTimeCasa,
                        GolsTimeVisitante = jogo.GolsApostaTimeVisitante
                    });
                    //}
                }

                List<ApostaIdDTO> lstIds = await (new ApostaServico()).GravarLista(lstApostas);

                foreach (ApostaDTO jogo in _vm.ListaApostas)
                {
                    ApostaIdDTO? ids = lstIds.FirstOrDefault(t => t.IdCampeonatoJogo.Equals(jogo.IdCampeonatoJogo));

                    if (ids != null)
                        jogo.IdAposta = ids.IdAposta;
                }

                /*
                foreach (JogoDTO jogo in _vm.ListaJogos)
                {
                    ApostaIdDTO? ids = lstIds.FirstOrDefault(t => t.IdCampeonatoJogo.Equals(jogo.IdCampeonatoJogo));

                    if (ids != null)
                        jogo.IdAposta = ids.IdAposta;
                }
                */
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);

                throw excErro;
            }

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> Iniciar()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg = new StringBuilder();

                _vm.ListaApostas = new List<ApostaDTO>();
                _vm.ListaCampeonatos = await (new CampeonatoServico()).CampeonatosDaEmpresa(_vm.Logado.IdEmpresa);
                _vm.ListaPontuacao = await (new PontuacaoServico()).GetLista();

                if (_vm.ListaCampeonatos.Count > 0)
                    _vm.CampeonatoSelecionado = _vm.ListaCampeonatos[0];

                _vm.JogosVisible = true;
                _vm.MeusPontosVisible = false;
                _vm.RankingVisible = false;
                _vm.ApostaDetalhesVisible = false;

                _vm.Iniciado = true;
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return (_vm.ErroIndex == 0);
        }

        #endregion
    }
}