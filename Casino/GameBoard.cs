using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class GameBoard : Wallet
    {
        public uint Bet { get; private set; }

        public GameBoard() { }
        public GameBoard(string name, uint walletSize, uint bet)
        {
            Name = name;
            WalletSize = walletSize;
            Bet = bet;
        }
    }
}
