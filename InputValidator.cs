/*
 * InputValidator.cs - Klass som validerar olika typer av inmatning.
 */
namespace CasinoSlot
{
    public static class InputValidator
    {
        /*
         * Metod som verifierar att inmatat heltal är inom tillåtna
         * gränsvärden.
         */
        public static bool ValidateInput(uint a)
        {
            return (a <= uint.MinValue || a > uint.MaxValue) ? false : true;
        }

        /*
         * Metod som verifierar att inmatade heltal är inom tillåtna
         * gränsvärden samt att variabel 'b' ej är större än 'a'.
         */
        public static bool ValidateInput(
            uint a,
            uint b)
        {
            if (!ValidateInput(a) || !ValidateInput(b)) return false;
            else return (a < b) ? false : true;
        }

        /*
         * Metod som verifierar att inmatad sträng ej är null eller enbart
         * består av tomt/blankt utrymme, t.ex. mellanslag.
         */
        public static bool ValidateInput(string s)
        {
            return (string.IsNullOrWhiteSpace(s)) ? false : true;
        }
    }
}
