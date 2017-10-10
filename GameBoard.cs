/*
 * GameBoard.cs - Klass som beskriver spelplanen.
 */
using System;

namespace CasinoSlot
{
    /*
     * 'GameBoard'-klassen ärver fr. 'Wallet'-klassen eftersom spelplanen
     * är logiskt kopplad till spelarens plånbok.
     */
    class GameBoard : Wallet
    {
        // Strängar som genererar vinst.
        private string[] winStrings = new string[6] {
            "9", "10", "J", "Q", "K", "D" };
        private uint
            bet,
            prize;

        private ulong betTotal;

        public uint Bet
        {
            get => bet;
            set => bet = value;
        }

        public uint Prize
        {
            get => prize;
            set => prize = value;
        }

        public ulong BetTotal
        {
            get => betTotal;
            set => betTotal = value;
        }
        // Konstruktor som används när applikationen startar.
        public GameBoard() { }
        // Konstruktor som används när spelaren väljer att starta om.
        public GameBoard(
            string name,
            uint walletSize,
            uint bet)
        {
            Name = name;
            WalletSize = walletSize;
            Bet = bet;
        }
        // Metod som generar spelplanen.
        public string[,] GenerateBoard(
            byte rows,
            byte columns)
        {
            // Sannolikhetsdistribution-vektor.
            string[] probDistVect = new string[100];
            // 2D-matris som representerar spelplanen.
            string[,] board = new string[rows, columns];
            /*
             * Slumptalsgenerator för att mappa slumpat element ur
             * 'probDistVect' mot element i 'board'-matrisen.
             */
            Random rnd = new Random();
            // Sätt upp sannolikhetsdistributionen.
            for (byte i = 0; i < 100; i++)
            {
                // 30% av vektorn ska utgöras av strängen "9".
                if (i < 30)
                    probDistVect[i] = winStrings[0];
                // 25% av vektorn ska utgöras av strängen "10".
                if (i >= 30 && i < 55)
                    probDistVect[i] = winStrings[1];
                // 20% av vektorn ska utgöras av strängen "J".
                if (i >= 55 && i < 75)
                    probDistVect[i] = winStrings[2];
                // 15% av vektorn ska utgöras av strängen "Q".
                if (i >= 75 && i < 90)
                    probDistVect[i] = winStrings[3];
                // 8% av vektorn ska utgöras av strängen "K".
                if (i >= 90 && i < 98)
                    probDistVect[i] = winStrings[4];
                // 2% av vektorn ska utgöras av strängen "D".
                if (i >= 98 && i < 100)
                    probDistVect[i] = winStrings[5];
            }
            /*
             * Iterera genom 'board'-matrisen och tilldela varje element en
             * slumad sträng ur 'probDistVect'-vektorn.
             */
            for (byte y = 0; y < rows; y++)
            {
                for (byte x = 0; x < columns; x++)
                {
                    board[y, x] =
                        probDistVect[
                            rnd.Next(
                                0,
                                100)];
                }
            }

            return board;
        }
        // Metod som detekterar vinstrader.
        public void SetWinningRows(string[,] board)
        {

            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
                CalcPrize(board[0, 0]);
            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
                CalcPrize(board[1, 0]);
            if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
                CalcPrize(board[2, 0]);
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                CalcPrize(board[0, 0]);
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                CalcPrize(board[0, 2]);
        }
        // Metod som beräknar vinst baserat på vinststräng (ur 'winStrings').
        public void CalcPrize(string winStr)
        {
            // Avgör vilken sträng vinstraden utgörs av.
            for (byte i = 0; i < winStrings.Length; i++)
            {
                /*
                 * Addera den ensilda radens vinstbelopp baserat på sträng
                 * till den totala vinsten.
                 */
                 /*
                  * OBS: Algoritmen för vinstgenerering är ej realistisk och
                  * endast tänkt som ett simpelt illustrativt exempel.
                  */
                /*
                 * TODO: Modifiera vinst-algo så att plånboken tar slut
                 * snabbare och därmed gör spelet mer realistiskt.
                 */
                if (winStr == winStrings[i]) Prize += Bet * (uint)(2 + i);
            }
        }
    }
}
