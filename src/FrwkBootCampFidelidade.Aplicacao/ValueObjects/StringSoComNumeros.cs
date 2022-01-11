using System.Linq;

namespace FrwkBootCampFidelidade.Aplicacao.ValueObjects
{
    public static class StringSoComNumeros
    {
        public static string ApenasNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
