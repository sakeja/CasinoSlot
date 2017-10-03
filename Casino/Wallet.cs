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
        protected decimal wallet;

        public decimal Wallet
        {
            get { return wallet; }

            set
            {
                try
                {
                    if (value <= 0)
                        throw new ArgumentNullException("name", EXC_NAME_MSG);

                    name = value;
                }

                catch (ArgumentNullException e)
                {
                    MessageBox.Show(e.ToString(), MSGBOX_ERR_TITLE);
                }
            }
        }
    }
}
