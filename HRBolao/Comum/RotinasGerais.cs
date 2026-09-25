using HRBolao.Model;

namespace HRBolao.Comum
{
    public static class RotinasGerais
    {
        #region Público

        public static JogadorModel GetUsuarioLocal()
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                jogador.email = Preferences.Get("HRBolao_Email", "");
                jogador.IdJogador = Preferences.Get("HRBolao_IdJogador", 0);
                /*
                jogador.IdEmpresa = Preferences.Get("HRBolao_IdEmpresa", 0);
                jogador.IdJogador = Preferences.Get("HRBolao_IdJogador", 0);
                jogador.NomeApelido = Preferences.Get("HRBolao_NomeApelido", "");
                */
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return jogador;
        }

        public static bool SetUsuarioLocal(JogadorModel logado)
        {
            bool boolOk = false;

            try
            {
                //Preferences.Set("HRBolao_IdEmpresa", logado.IdEmpresa);
                Preferences.Set("HRBolao_IdJogador", logado.IdJogador);
                Preferences.Set("HRBolao_Email", logado.email);

                boolOk = true;
            }
            catch (Exception excErro)
            {
                throw excErro;
            }

            return boolOk;
        }

        #endregion
    }
}