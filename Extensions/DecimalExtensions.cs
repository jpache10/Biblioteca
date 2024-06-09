

using System.Globalization;

namespace Biblioteca.Extensions;

    public static class DecimalExtensions
    {
        public static string ToPercentage(this decimal value, int decimals = 2)
        {
            var percentage = value * 100;
            // Convertir a string sin ceros innecesarios
            var formatted = percentage.ToString($"F{decimals}", CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
            return $"{formatted}%";
        }
    }

