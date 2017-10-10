/*
 * ErrorMessages.cs - Klass som tillgängliggör informativa felmedd. för vanligt
 * förekommande fel.
 */
using System;
using System.Windows;

namespace CasinoSlot
{
    class ErrorMessages
    {
        // Fönstertitel för felmedd.
        private const string MSGBOX_ERR_CAP = "Ett fel uppstod!";
        // Felmedd. - dessa bör ses som konstanta/statiska och därför ej ändras.
        public static readonly string
            invalidName =
                "Ange ditt namn!",
            invalidWalletSize =
                "Din plånbok får ej:\n" +
                "Vara mindre än 1.\n" +
                "Vara större än " +
                UInt32.MaxValue.ToString() +
                ".",
            invalidBet =
                "Din insats får ej:\n" +
                "Vara mindre än 1.\n" +
                "Vara större än din plånbok.\n" +
                "Vara större än " +
                UInt32.MaxValue.ToString() +
                ".";
        // Metod för att visa felmedd. i form av en MessageBox.
        public static void Show(string errMsg) => MessageBox.Show(
                errMsg,
                MSGBOX_ERR_CAP);
    }
}
