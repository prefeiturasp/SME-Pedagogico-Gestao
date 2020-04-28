using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Utilitarios
{
    public static class UtilCriptografia
    {
        public static string ConverterBase64(string entrada)
        {
            if (string.IsNullOrWhiteSpace(entrada))
                return string.Empty;

            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(entrada);

            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public static string DesconverterBase64(string entrada)
        {
            if (string.IsNullOrWhiteSpace(entrada))
                return string.Empty;

            byte[] encodedDataAsBytes = Convert.FromBase64String(entrada);

            return Encoding.ASCII.GetString(encodedDataAsBytes);
        }
    }
}
