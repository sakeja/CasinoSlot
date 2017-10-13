/*
 * InputConverter.cs - Klass som konverterar mellan olika datatyper.
 */
using System;

namespace CasinoSlot
{
    public static class InputConverter
    {
        // Metod för att konvertera en sträng till ett heltal (uint).
        public static uint TryConvertToUInt32(string s)
        {
            /*
             * Om konverteringen kan genomföras, returnera konverterat heltal.
             * Returnera annars konstanten "UInt32.MinValue" som är 0.
             */
            return (UInt32.TryParse(s, out uint numStr)) ? numStr : UInt32.MinValue;
        }
    }
}
