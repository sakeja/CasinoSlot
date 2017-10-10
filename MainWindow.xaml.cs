using System.Windows;

namespace CasinoSlot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instansiera 'GameBoard'-klassen vid applikationsstart.
        GameBoard GBoard = new GameBoard();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Spin_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Läs in plånboks- och betstorlek och försök konvertera dessa fr.
             * strängar till heltal.
             */
            uint
                inputWalletSize =
                    InputConverter.TryConvertToUInt32(TBox_WalletSize.Text),
                inputBetSize =
                    InputConverter.TryConvertToUInt32(TBox_Bet.Text);

            /*
             * Testa om inmatning av namn, plånbok och bet är giltig. Vad som
             * utgör giltig inmatning framgår i "InputValidator"-klassen.
             */
            bool
               isValidName =
                    InputValidator.ValidateInput(TBox_Name.Text),
               isValidWalletSize =
                    InputValidator.ValidateInput(inputWalletSize),
               isValidBet =
                    InputValidator.ValidateInput(
                        a: inputWalletSize,
                        b: inputBetSize);

            // Om inmatning är giltig, kör spelet.
            if (isValidName && isValidWalletSize && isValidBet)
            {
                Run(
                    walletSize: inputWalletSize,
                    betSize: inputBetSize);
            }

            /*
             * Om inmatning är ogiltig, visa felmedd. som förklarar felaktig
             * inmatning och vad som utgör korrekt sådan.
             */
            else
            {
                if (!isValidName)
                    ErrorMessages.Show(ErrorMessages.invalidName);

                if (!isValidWalletSize)
                    ErrorMessages.Show(ErrorMessages.invalidWalletSize);

                if (!isValidBet)
                    ErrorMessages.Show(ErrorMessages.invalidBet);

                // Tillåt spelaren att ändra plånbokens storlek.
                TBox_WalletSize.IsReadOnly = false;
            }
        }
        // Metod som kör spelet när spelaren klickar på "SPIN!"-knappen.
        void Run(
            uint walletSize,
            uint betSize)
        {
            // Tilldela klassegenskaper värde baserat på inmatning.
            SetProperties(
                inputWalletSize: walletSize,
                inputBetSize: betSize);
            // Generera en 3x3 2D-matris (spelplan).
            string[,] generatedBoard = GBoard.GenerateBoard(
                rows: 3,
                columns: 3);
            // Rita matrisen i grafiska gränssnittet.
            DrawBoard(generatedBoard);
            // Determinera matrisens vinstrader.
            GBoard.SetWinningRows(generatedBoard);
            // Kontrollera om spelaren vunnit.
            TestIfPlayerWon();
            // Testa om plånboken är tom.
            CheckWalletSize();
        }
        // Metod som ritar matrisen i grafiska gränssnittet.
        void DrawBoard(string[,] board)
        {
            // Tilldela vardera etikett motsv. element i matrisen.
            Lbl1.Content = board[0, 0];
            Lbl2.Content = board[0, 1];
            Lbl3.Content = board[0, 2];
            Lbl4.Content = board[1, 0];
            Lbl5.Content = board[1, 1];
            Lbl6.Content = board[1, 2];
            Lbl7.Content = board[2, 0];
            Lbl8.Content = board[2, 1];
            Lbl9.Content = board[2, 2];

            // Gör matrisen synlig.
            Lbl1.Visibility = Visibility.Visible;
            Lbl2.Visibility = Visibility.Visible;
            Lbl3.Visibility = Visibility.Visible;
            Lbl4.Visibility = Visibility.Visible;
            Lbl5.Visibility = Visibility.Visible;
            Lbl6.Visibility = Visibility.Visible;
            Lbl7.Visibility = Visibility.Visible;
            Lbl8.Visibility = Visibility.Visible;
            Lbl9.Visibility = Visibility.Visible;
        }
        // Metod som tilldelar klassegenskaper värde.
        void SetProperties(
            uint inputWalletSize,
            uint inputBetSize)
        {
            GBoard.Name = TBox_Name.Text;
            GBoard.WalletSize = inputWalletSize;
            GBoard.Bet = inputBetSize;
            GBoard.BetTotal += inputBetSize;
            // Nollställ tidigare vinst.
            GBoard.Prize = 0;
            // Förhindra spelaren att ändra storlek på sin plånbok efter start.
            TBox_WalletSize.IsReadOnly = true;
        }
        // Metod som kontrollerar om spelaren vunnit.
        void TestIfPlayerWon()
        {
            /*
             * Om spelaren vunnit är 'Prize'-egenskapens värde i
             * 'GameBoard'-klassen större än 0.
             */
            if (GBoard.Prize > 0)
            {
                /*
                 * Konstruera ett personligt gratulationsmedd. baserat på
                 * spelarens namn vid vinst.
                 */
                Lbl_Msg.Content = "GRATTIS";
                Lbl_Name.Content = GBoard.Name;
                Lbl_Res.Content = "DU VANN!";

                // Gör gratulationsmedd. synligt.
                Lbl_Msg.Visibility = Visibility.Visible;
                Lbl_Name.Visibility = Visibility.Visible;
                Lbl_Res.Visibility = Visibility.Visible;

                // Addera vinsten till tillgänglig kredit.
                GBoard.WalletSize += GBoard.Prize;
                TBox_WalletSize.Text = GBoard.WalletSize.ToString();
            }

            else
            {
                // Dölj gratulationsmedd. vid förlust.
                Lbl_Msg.Visibility = Visibility.Hidden;
                Lbl_Name.Visibility = Visibility.Hidden;
                Lbl_Res.Visibility = Visibility.Hidden;

                // Subtrahera förlusten fr. tillgänglig kredit.
                GBoard.WalletSize -= GBoard.Bet;
                TBox_WalletSize.Text = GBoard.WalletSize.ToString();
            }
            // Uppdatera spelstatistik.
            ShowStats();
        }
        // Metod som uppdaterar spelstatistik.
        void ShowStats()
        {
            // Tilldela kvarvarande krediter och totalt bet-belopp.
            Lbl_Credits.Content = GBoard.WalletSize;
            Lbl_BetTtl.Content = GBoard.BetTotal;

            // Synliggör kvarvarande krediter och totalt bet-belopp.
            Lbl_Credits.Visibility = Visibility.Visible;
            Lbl_BetTtl.Visibility = Visibility.Visible;
        }
        // Metod som kontrollerar om spelarens plånbok är tom.
        void CheckWalletSize()
        {
           /*
            * Om plånboken är tom, fråga om spelaren vill avsluta eller
            * starta om.
            */
            if (GBoard.WalletSize < GBoard.Bet)
            {
                if (MessageBox.Show(
                    "Din plånbok är tom! Vill du starta om?",
                    "Din plånbok är tom!",
                    MessageBoxButton.YesNo)
                    == MessageBoxResult.Yes)
                {
                    /*
                     * Om spelaren väljer att starta om, nollställ spelsessionen
                     * genom att skapa ett nytt 'GameBoard'-objekt.
                     */
                    GBoard = new GameBoard(
                        TBox_Name.Text,
                        0,
                        0);
                    // Dölj tidigare matris tills en ny genererats och ritats ut.
                    Lbl1.Visibility = Visibility.Hidden;
                    Lbl2.Visibility = Visibility.Hidden;
                    Lbl3.Visibility = Visibility.Hidden;
                    Lbl4.Visibility = Visibility.Hidden;
                    Lbl5.Visibility = Visibility.Hidden;
                    Lbl6.Visibility = Visibility.Hidden;
                    Lbl7.Visibility = Visibility.Hidden;
                    Lbl8.Visibility = Visibility.Hidden;
                    Lbl9.Visibility = Visibility.Hidden;
                    /*
                     * Dölj även tidigare kvarvarande kredit och totala bets tills
                     * spelet startats om.
                     */
                    Lbl_Credits.Visibility = Visibility.Hidden;
                    Lbl_BetTtl.Visibility = Visibility.Hidden;
                    // Tillåt spelaren ändra storlek på plånboken.
                    TBox_WalletSize.IsReadOnly = false;
                }
                // Om spelaren ej vill starta om, avsluta applikationen.
                else Application.Current.Shutdown();
            }
        }
    }
}
