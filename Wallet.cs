/*
 * Wallet.cs - Klass som beskriver spelarens plånbok.
 */
namespace CasinoSlot
{
    /*
     * 'Wallet'-klassen ärver fr. 'Person'-klassen eftersom plånboken tillhör
     * spelaren och därmed delar dess metadata.
     */
    class Wallet : Person
    {
        private uint walletSize;

        public uint WalletSize
        {
            get => walletSize;
            set => walletSize = value;
        }
    }
}
