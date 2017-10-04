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
        public string Name { get; protected set; }

        public Person(string name) { Name = name; }
    }
}
