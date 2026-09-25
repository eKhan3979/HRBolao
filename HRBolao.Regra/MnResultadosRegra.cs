using System;
using System.Text;

using HRBolao.Model;
using HRBolao.Servico;
using HRBolao.ViewModel;

namespace HRBolao.Regra
{
    public class MnResultadosRegra
    {
        #region Variáveis da Classe

        private MnResultadosViewModel _vm;

        #endregion

        #region Construtor

        public MnResultadosRegra(ref MnResultadosViewModel vm)
        {
            _vm = vm;
        }

        #endregion

        #region Público

        public async Task<bool> CarregarCampeonato()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();

                List<RodadaDTO> lstRodadas = await (new CampeonatoServico()).CampeonatoRodadas(_vm.CampeonatoSelecionado.IdCampeonato);

                _vm.RodadaAtual = await (new JogoServico()).RodadaAtual(_vm.CampeonatoSelecionado.IdCampeonato);

                _vm.RodadaSelecionada = new RodadaDTO();

                _vm.ListaRodadas = [];
                _vm.ListaRodadas = lstRodadas;

                if ((_vm.ListaRodadas != null) &&
                    (_vm.ListaRodadas.Count > 0))
                {
                    _vm.RodadaSelecionada = _vm.ListaRodadas.FirstOrDefault(t => t.Rodada.Equals(_vm.RodadaAtual));
                }
            }
            catch (Exception excErro)
            {
                _vm.ErroMsg.AppendLine(excErro.Message);
                _vm.ErroIndex = 1;
            }

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> CarregarJogos()
        {
            try
            {
                _vm.ErroIndex = 0;
                _vm.ErroMsg.Clear();
                _vm.Aguarde = false;
                _vm.VerJogo = false;

                var lista = await (new JogoServico()).JogosDaRodada(_vm.CampeonatoSelecionado.IdCampeonato,
                                                                    _vm.RodadaSelecionada.Rodada);

                for (int intRow = 0; intRow < lista.Count; intRow++)
                    lista[intRow].Background = ((intRow % 2 == 0) ? "#FFFFFFFF" : "#FFE9E9E9");

                _vm.ListaJogos = lista;
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return (_vm.ErroIndex == 0);
        }

        public void Editar(JogoDTO jogo)
        {
            _vm.JogoEdit = jogo;
            _vm.VerJogo = true;
        }

        public async Task<bool> Gravar()
        {
            _vm.ErroIndex = 0;
            _vm.ErroMsg.Clear();

            try
            {
                JogoDTO jogo = new()
                {
                    IdCampeonatoJogo = _vm.JogoEdit.IdCampeonatoJogo,
                    GolsTimeCasa = _vm.JogoEdit.GolsTimeCasa,
                    GolsTimeVisitante = _vm.JogoEdit.GolsTimeVisitante,
                    Finalizado = _vm.JogoEdit.Finalizado
                };

                if (!await (new JogoServico()).JogoResultado(jogo))
                {
                    throw new Exception("- Gravação não realizada !");
                }
            }
            catch (Exception excErro)
            {
                _vm.ErroIndex = 1;
                _vm.ErroMsg.AppendLine(excErro.Message);
            }

            return (_vm.ErroIndex == 0);
        }

        public async Task<bool> Inicializacao()
        {
            try
            {
                _vm.ErroIndex = 0;

                _vm.ErroMsg = new StringBuilder();
                _vm.JogoEdit = new JogoDTO();
                _vm.ListaJogos = [];
                _vm.ListaRodadas = [];

                List<CampeonatoDTO> lstCampeonatos = await (new CampeonatoServico()).CampeonatosDaEmpresa(1);

                lstCampeonatos.Insert(0, new CampeonatoDTO()
                {
                    IdCampeonato = 0,
                    Nome = "(Selecione o campeonato)",
                    Ano = 0
                });

                _vm.ListaCampeonatos = lstCampeonatos;
                _vm.CampeonatoSelecionado = _vm.ListaCampeonatos[0];
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