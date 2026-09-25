using MySqlConnector;

using System.Text.RegularExpressions;

namespace HRBolao.Dados
{
    public class BaseDados
    {
        public string DateTimeParaDdMmYyyy(Nullable<DateTime> dtmConverter)
        {
            if (dtmConverter != null)
                return dtmConverter.Value.ToString("dd/MM/yyyy");
            else
                return null;
        }

        public string Dd_Mm_Yyyy(string strYyyy_Mm_Dd)
        {
            if (!string.IsNullOrWhiteSpace(strYyyy_Mm_Dd))
                return strYyyy_Mm_Dd.Substring(8, 2) + "/" +
                       strYyyy_Mm_Dd.Substring(5, 2) + "/" +
                       strYyyy_Mm_Dd.Substring(0, 4);
            else
                return "";
        }

        public decimal DecimalNaoNull(object objValor)
        {
            if ((objValor != null) && (objValor != System.DBNull.Value))
                return (decimal)objValor;
            else
                return 0;
        }

        public string GetString(object objValor)
        {
            if ((objValor != System.DBNull.Value) &&
                (objValor != null))
                return objValor.ToString();
            else
                return string.Empty;
        }

        public string IntPositivoOrNull(int? intValor)
        {
            if ((intValor != null) && (intValor.HasValue) && (intValor.Value > 0))
                return intValor.Value.ToString();
            else
                return "null";
        }

        public string IntPositivoOrNull(int intValor)
        {
            if (intValor > 0)
                return intValor.ToString();
            else
                return "null";
        }

        public bool ParaBoolean(object objValor)
        {
            bool boolValor = false;

            try { bool.TryParse(objValor.ToString(), out boolValor); }
            catch { }

            return boolValor;
        }

        public DateTime ParaDateTime(object objValor)
        {
            DateTime dtmValor = DateTime.Now;

            try { DateTime.TryParse(objValor.ToString(), out dtmValor); }
            catch { }

            return dtmValor;
        }

        public decimal ParaDecimal(string strValor)
        {
            try { return decimal.Parse(strValor.Replace(".", "").Replace(",", ".")); }
            catch { return 0; }
        }

        public decimal? ParaDecimal(object objValor)
        {
            try
            {
                return decimal.Parse(objValor.ToString());
            }
            catch { return null; }
        }

        public decimal ParaDecimalZero(object objValor)
        {
            try
            {
                return decimal.Parse(objValor.ToString());
            }
            catch { return 0; }
        }

        public string ParaDecimalSQLServer(string strValor)
        {
            try { return strValor.Replace(".", "").Replace(",", "."); }
            catch { return "0.00"; }
        }

        public int ParaInteiro(object objValor)
        {
            try
            {
                if (objValor != System.DBNull.Value)
                    return int.Parse(objValor.ToString().Replace(".", ""));
                else
                    return 0;
            }
            catch { return 0; }
        }

        public short ParaShort(object objValor)
        {
            short shtValor = 0;

            try { shtValor = Convert.ToInt16(objValor); }
            catch { }

            return shtValor;
        }

        public string ParaStringSpaceLeft(string strValor, int intLength = 5)
        {
            string strReturn = "          " + strValor;

            return strReturn.Substring(strReturn.Length - intLength, intLength);
        }

        public string ParaStringSpaceRight(string strValor, int intLength = 5)
        {
            string strReturn = strValor + "                    ";

            return strReturn.Substring(0, intLength);
        }

        public string ParaString(object objValor)
        {
            if (objValor != null)
                return objValor.ToString().Trim();
            else
                return string.Empty;
        }

        public string ParaString(decimal? dcmValor)
        {
            return (((dcmValor != null) && (dcmValor.Value != 0)) ? dcmValor.Value.ToString("#.#0") : "");
        }

        public MySqlConnection PegarConexao()
        {
            return new MySqlConnection($@"Server=193.203.175.121; " +
                                         "Database=u258112148_1; " +
                                         "User Id=u258112148_Khan; " +
                                         "Password=0W*_3%#k7; " +
                                         "Port=3306;");
        }

        public string SoNumeros(string strValor)
        {
            Regex regex = new Regex(@"[^\d]");

            return regex.Replace(strValor, "");
        }

        public string TrimNaoNull(string strValor)
        {
            if (strValor != null)
                return strValor.Trim();
            else
                return "";
        }

        public string Yyyy_Mm_Dd(string strDd_Mm_Yyyy)
        {
            string strYyyy_Mm_Dd = "Null";

            try
            {
                if (strDd_Mm_Yyyy != null)
                    strYyyy_Mm_Dd = "'" + strDd_Mm_Yyyy.Substring(6, 4) + "/" +
                                          strDd_Mm_Yyyy.Substring(3, 2) + "/" +
                                          strDd_Mm_Yyyy.Substring(0, 2) + "'";
            }
            catch { }

            return strYyyy_Mm_Dd;
        }

        public string Yyyy_Mm_Dd(DateTime? dtmConverter)
        {
            string strYyyy_Mm_Dd = "Null";

            try
            {
                if (dtmConverter != null)
                    strYyyy_Mm_Dd = "'" + dtmConverter.Value.ToString("yyyy/MM/dd") + "'";
            }
            catch { }

            return strYyyy_Mm_Dd;
        }
    }
}