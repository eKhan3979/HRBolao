namespace HRBolao.Servico
{
    public class BaseServico
    {
        //public string BaseLink = @"https://Investapp.Somee.com/hrbolao/";
        public string BaseLink = @"https://lightcyan-echidna-380972.hostingersite.com/bolao/";

        public string normalizaLink(string strLink)
        {
            return strLink = Uri.UnescapeDataString(strLink.Replace("\r\n", ""));
        }
    }
}