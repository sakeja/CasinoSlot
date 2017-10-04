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
        private const string DEF_NAME = "Testperson";
        protected string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Person() { name = DEF_NAME; }
        public Person(string name) { this.name = name; }
    }
}
