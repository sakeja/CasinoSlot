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
        private string EXC_BAL_MSG =
            "Ange pengar i din plånbok!\n" +
            (uint.MinValue + 1).ToString() +
            " till " +
            uint.MaxValue.ToString() +
            " tillåtet.";

        protected uint balance;

        public uint Balance
        {
            get { return balance; }

            set
            {
                try
                {
                    if (value < uint.MinValue || value > uint.MaxValue)
                        throw new ArgumentOutOfRangeException(
                            "balance",
                            EXC_BAL_MSG);

                    if (value == 0)
                        MessageBox.Show(
                            EXC_BAL_MSG,
                            MSGBOX_ERR_TITLE);

                    else balance = value;
                }

                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(
                        e.ToString(),
                        MSGBOX_ERR_TITLE);
                }
            }
        }
    }
}
