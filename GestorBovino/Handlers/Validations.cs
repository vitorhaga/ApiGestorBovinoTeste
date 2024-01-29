using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiGestorBovino.GestorBovino.Handlers
{
    public static class Validations
    {
        public static bool IsValidObject(this object obj)
        {
            if (obj != null)
                return true;
            else
                return false;
        }

        public static bool IsValidDecimal(this string value)
        {
            decimal procValue;
            return decimal.TryParse(value, out procValue);
        }

        public static bool IsValidInt(this string value)
        {
            int procValue;
            return int.TryParse(value, out procValue);
        }

        public static bool IsValidLong(this string value)
        {
            long procValue;
            return long.TryParse(value, out procValue);
        }

        public static bool IsValidInt(this object value)
        {
            if (value == null)
                return false;

            int procValue;
            return int.TryParse(value.ToString(), out procValue);
        }

        public static bool IsValidDouble(this string value)
        {
            double procValue;
            return double.TryParse(value, out procValue);
        }

        public static bool IsValidDate(this string value)
        {
            DateTime procValue;
            return DateTime.TryParse(value, out procValue);
        }

        public static bool IsValidDate(this DateTime? value)
        {
            return (value.IsValidObject());
        }

        public static bool IsValidInt(this char value)
        {
            int procValue;
            return int.TryParse(value.ToString(), out procValue);
        }

        public static bool IsGreaterOrEqual(this int value, int number = 0)
        {
            if (value >= number)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this int? value)
        {
            if (!value.IsValidObject())
                return false;

            if (value > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this string value)
        {
            if (!value.IsValidInt())
                return false;

            if (Convert.ToInt32(value) > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this double? value)
        {
            if (!value.IsValidObject())
                return false;

            if (value > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this double value)
        {
            if (!value.IsValidObject())
                return false;

            if (value > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this int value)
        {
            if (value > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this long value)
        {
            if (value > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this long? value)
        {
            if (value != null && value > 0)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this decimal value)
        {
            if (value > 0.00m)
                return true;
            else
                return false;
        }

        public static bool IsPositive(this decimal? value)
        {
            if (!value.IsValidObject())
                return false;

            if (value > 0.00m)
                return true;
            else
                return false;
        }

        public static bool IsNegative(this int value)
        {
            if (value < 0)
                return true;
            else
                return false;
        }

        public static bool IsValidString(this string text, int size)
        {
            return !string.IsNullOrEmpty(text) && text.Length.IsGreaterOrEqual(size);
        }

        public static bool IsValidString(this string text)
        {
            if (text != null && !text.Trim().Equals(string.Empty))
                return true;
            else
                return false;
        }

        public static bool IsValidStringNoSpecialChar(this string text)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!string.IsNullOrEmpty(text.Trim()) && regexItem.IsMatch(text))
                return true;
            else
                return false;
        }

        public static string ReturnOnlyNumbers(this string text)
        {
            if (text.IsValidString())
                return Regex.Replace(text, @"[^\d]", "").Trim();
            else
                return string.Empty;
        }

        public static bool IsValidList<T>(this List<T> list)
        {
            if (list != null && list.Any())
                return true;
            else
                return false;
        }

        public static bool IsValidList<T>(this IEnumerable<T> ienumerable)
        {
            if (ienumerable != null && ienumerable.Any())
                return true;
            else
                return false;
        }

        public static bool IsValidArray<T>(this T[] array)
        {
            if (array != null && array.Any())
                return true;
            else
                return false;
        }

        public static string DecimalAmericanToBr(this string value)
        {
            if (value.IsValidString())
            {
                string procValue = value.Trim().Replace("..", ".").Replace(".", ",");
                int index = procValue.IndexOf(',');

                if (index > 0)
                {
                    while ((procValue.Substring(index)).Length < 3)
                        procValue = procValue + "0";

                    return procValue.Substring(0, (index + 3));
                }
                else return "0,00";
            }
            else return "0,00";
        }

        public static string NumericPostgres(this string value)
        {
            if (value.IsValidString())
            {
                string procValue = value.Trim().Replace(".", string.Empty).Replace(",", ".");
                int index = procValue.IndexOf('.');

                if (index > 0)
                {
                    while ((procValue.Substring(index)).Length < 3)
                        procValue = procValue + "0";

                    return procValue.Substring(0, (index + 3));
                }
                else return "0.00";
            }
            else return "0.00";
        }

        public static string MaskDecimal(this string value)
        {
            if (value.IsValidString())
            {
                string procValue = value.Trim().Replace(",", string.Empty).Replace(".", ",");
                int index = procValue.IndexOf(',');

                if (index > 0)
                {
                    while ((procValue.Substring(index)).Length < 3)
                        procValue = procValue + "0";

                    return procValue.Substring(0, (index + 3));
                }
                else return "0,00";
            }
            else return "0,00";
        }

        public static bool IsValidHttpWebResponse(this HttpWebResponse response)
        {
            return (response.IsValidObject() && (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created));
        }

        public static string RemoveAccent(this string text)
        {
            if (!text.IsValidString())
                return string.Empty;

            text = text.Replace("'", string.Empty);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text); //Tailspin uses Cyrillic (ISO-8859-5); others use Hebraw (ISO-8859-8)
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static bool IsLowerOrEqual(this DateTime? date, DateTime dateToCompare)
        {
            return date <= dateToCompare;
        }

        public static bool ExcluidoLogicamente<T>(this T objeto)
        {
            var propriedades = objeto.GetType().GetProperties().ToList();

            if (!propriedades.IsValidList())
                return false;

            var propriedade = propriedades.Where(x => x.Name.Equals("DtExc")).FirstOrDefault();

            return propriedade.IsValidObject() && propriedade.GetValue(objeto, null).IsValidObject();
        }

        public static bool IsValidCpf(this string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            resto = resto < 2 ? resto = 0 : resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? resto = 0 : resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsValidCnpj(this string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;
            // Remover caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verificar se o CNPJ possui 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verificar se todos os dígitos são iguais (caso especial)
            bool todosDigitosIguais = cnpj.Distinct().Count() == 1;
            if (todosDigitosIguais)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Calcula o primeiro dígito verificador
            int soma1 = 0;
            for (int i = 0; i < 12; i++)
                soma1 += (cnpj[i] - '0') * multiplicador1[i];
            int resto1 = soma1 % 11;
            int digito1 = resto1 < 2 ? 0 : 11 - resto1;

            // Calcula o segundo dígito verificador
            int soma2 = 0;
            for (int i = 0; i < 13; i++)
                soma2 += (cnpj[i] - '0') * multiplicador2[i];
            int resto2 = soma2 % 11;
            int digito2 = resto2 < 2 ? 0 : 11 - resto2;

            // Verifica se os dígitos verificadores conferem
            return (cnpj[12] - '0') == digito1 && (cnpj[13] - '0') == digito2;
        }
    }
}
