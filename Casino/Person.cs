using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Casino
{
    class Person
    {
        private const string EXC_NAME_MSG = "Ange ditt namn!";
        protected const string MSGBOX_ERR_TITLE = "Ett fel uppstod!";

        protected string name;

        public string Name
        {
            get { return name; }

            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
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
