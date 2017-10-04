using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Casino
{
    class Wallet : Person
    {
        protected uint balance;

        private const uint DEF_BAL = 1000;
        private string EXC_BAL_MSG =
            "Ange pengar i din plånbok!\n" +
            (uint.MinValue + 1).ToString() +
            " till " +
            uint.MaxValue.ToString() +
            " tillåtet.";

        public uint Balance
        {
            get { return balance; }

            set
            {
                try
                {
                    if (value < uint.MinValue || value > uint.MaxValue)
                        throw new ArgumentOutOfRangeException(
                            paramName: "balance",
                            message: EXC_BAL_MSG);

                    if (value == 0)
                        MessageBox.Show(
                            messageBoxText: EXC_BAL_MSG,
                            caption: MSGBOX_ERR_TITLE);

                    else balance = value;
                }

                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(
                        messageBoxText: e.ToString(),
                        caption: MSGBOX_ERR_TITLE);
                }
            }
        }

        public Wallet() { balance = DEF_BAL; }
        public Wallet(uint balance) { this.balance = balance; }
    }
}
