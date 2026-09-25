using HRBolao.Model;

namespace HRBolao.Manager.Comum
{
    public static class RotinasGerais
    {
        #region Público

        public static JogadorModel GetUsuarioLocal()
        {
            JogadorModel jogador = new JogadorModel();

            try
            {
                jogador.email = Preferences.Get("HRBolaoManager_Email", "");
                jogador.IdJogador = Preferences.Get("HRBolaoManager_IdJogador", 0);
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
                Preferences.Set("HRBolaoManager_IdJogador", logado.IdJogador);
                Preferences.Set("HRBolaoManager_Email", logado.email);

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