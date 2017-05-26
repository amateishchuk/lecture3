using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Concrete.Animals
{
    public class Elephant : Animal
    {
        public Elephant(string name) : base(name, 7)
        {
        }
    }
}
