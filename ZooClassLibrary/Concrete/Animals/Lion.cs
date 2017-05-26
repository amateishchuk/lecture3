using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Concrete.Animals
{
    public class Lion : Animal
    {
        public Lion(string name) : base(name, 5)
        {
        }
    }
}
