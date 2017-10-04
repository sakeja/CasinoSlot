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

        public string Name { get; protected set; } = DEF_NAME;

        public Person(string name) { Name = name; }
    }
}
