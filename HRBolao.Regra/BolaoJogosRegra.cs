using System;
using System.Security.Principal;
using System.Text;

using HRBolao.Model;
using HRBolao.Servico;
using HRBolao.ViewModel;

namespace HRBolao.Regra
{
    public class BolaoJogosRegra
    {
        #region Variáveis da Classe

        private BolaoJogosViewModel _vm;

        #endregion

        #region Construtor

        public BolaoJogosRegra(ref BolaoJogosViewModel vm)
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

        #endregion

        #region Público

        public void AtualizarAposta(ApostaGolDTO aposta)
        {
            _vm.ApostaSelecionada = _vm.ListaApostas.FirstOrDefault(t => t.IdCampeonatoJogo.Equals(aposta.IdCampeonatoJogo));

            if (aposta.GolsTimeCasa > -1)
                _vm.ApostaSelecionada.GolsApostaTimeCasa = aposta.GolsTimeCasa;
            else
                _vm.ApostaSelecionada.GolsApostaTimeVisitante = aposta.GolsTimeVisitante;

            /*
            _vm.JogoSelecionado = _vm.ListaJogos.FirstOrDefault(t => t.IdCampeonatoJogo.Equals(aposta.IdCampeonatoJogo));

            if (aposta.GolsTimeCasa > -1)
                _vm.JogoSelecionado.GolsTimeCasa = aposta.GolsTimeCasa;
            else
                _vm.JogoSelecionado.GolsTimeVisitante = aposta.GolsTimeVisitante;
            */
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
                        (_vm.JogadorLogin != null))
                    {
                        _vm.ListaApostas = await (new ApostaServico()).GetApostasRodada(_vm.CampeonatoSelecionado.IdCampeonato,
                                                                                        _vm.JogadorLogin.IdJogador,
                                                                                        _vm.RodadaSelecionada);

                        for (int intAposta = 0; intAposta < _vm.ListaApostas.Count; intAposta++)
                        {
                            _vm.ListaApostas[intAposta].Numero = intAposta + 1;
                            _vm.ListaApostas[intAposta].GolsCasaOriginal = _vm.ListaApostas[intAposta].GolsApostaTimeCasa;
                            _vm.ListaApostas[intAposta].GolsVisitanteOriginal = _vm.ListaApostas[intAposta].GolsApostaTimeVisitante;

                            if (_vm.ListaApostas[intAposta].Finalizado)
                                _vm.ListaApostas[intAposta].Pontos = pontuacaoJogo(_vm.ListaApostas[intAposta]);
                            else
                                _vm.ListaApostas[intAposta].Pontos = 0;
                        }

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

                if (_vm.ListaRodadas.Count > 0)
                {
                    _vm.RodadaPrimeira = _vm.ListaRodadas[0].Rodada;
                    _vm.RodadaUltima = _vm.ListaRodadas[_vm.ListaRodadas.Count - 1].Rodada;
                    _vm.RodadaSelecionada = _vm.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_vm.RodadaAtual)).Rodada;
                }

                _vm.ListaApostas = await (new ApostaServico()).GetApostasRodada(_vm.CampeonatoSelecionado.IdCampeonato,
                                                                                _vm.JogadorLogin.IdJogador,
                                                                                _vm.RodadaSelecionada);

                for (int intNumero = 0; intNumero < _vm.ListaApostas.Count; intNumero++)
                {
                    _vm.ListaApostas[intNumero].Numero = intNumero + 1;
                    _vm.ListaApostas[intNumero].GolsCasaOriginal = _vm.ListaApostas[intNumero].GolsApostaTimeCasa;
                    _vm.ListaApostas[intNumero].GolsVisitanteOriginal = _vm.ListaApostas[intNumero].GolsApostaTimeVisitante;

                    if (_vm.ListaApostas[intNumero].Finalizado)
                        _vm.ListaApostas[intNumero].Pontos = pontuacaoJogo(_vm.ListaApostas[intNumero]);
                    else
                        _vm.ListaApostas[intNumero].Pontos = 0;
                }

                _vm.PontosNaRodada = _vm.ListaApostas.Select(t => t.Pontos).Sum();
            }
            catch (Exception excErro)
            {
                _vm.ErroMsg.AppendLine(excErro.Message);
                _vm.ErroIndex = 1;
            }

            return (_vm.ErroIndex == 0);
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
                            IdJogador = _vm.JogadorLogin.IdJogador,
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

                _vm.ListaPontuacao = await (new PontuacaoServico()).GetLista();

                if ((_vm.CampeonatoSelecionado != null) &&
                    (_vm.CampeonatoSelecionado.IdCampeonato > 0))
                    await CarregarCampeonato();

                _vm.Iniciado = true;
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return (_vm.ErroIndex == 0);
        }

        public bool MudouAposta()
        {
            bool boolMudou = false;

            foreach (ApostaDTO jogo in _vm.ListaApostas)
            {
                if ((jogo.GolsApostaTimeCasa != jogo.GolsCasaOriginal) ||
                    (jogo.GolsApostaTimeVisitante != jogo.GolsVisitanteOriginal))
                {
                    boolMudou = true;
                    break;
                }
            }

            return boolMudou;
        }

        public async void RodadaAvancar()
        {
            if (_vm.RodadaSelecionada < _vm.RodadaUltima)
            {
                try
                {
                    _vm.RodadaSelecionada++;
                    _vm.RodadaAtual = _vm.RodadaSelecionada;

                    var selecionada = _vm.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_vm.RodadaSelecionada));

                    if (selecionada != null)
                        _vm.RodadaSelecionadaDTO = selecionada;

                    //await CarregarJogosDaRodada();
                    await CarregarApostas();
                }
                catch (Exception excErro)
                {
                    throw excErro;
                }
            }
        }

        public async void RodadaRetroceder()
        {
            if (_vm.RodadaSelecionada > _vm.RodadaPrimeira)
            {
                try
                {
                    _vm.RodadaSelecionada--;
                    _vm.RodadaAtual = _vm.RodadaSelecionada;

                    var selecionada = _vm.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_vm.RodadaSelecionada));

                    if (selecionada != null)
                        _vm.RodadaSelecionadaDTO = selecionada;

                    //await CarregarJogosDaRodada();
                    await CarregarApostas();
                }
                catch (Exception excErro)
                {
                    throw excErro;
                }
            }
        }

        #endregion
    }
}