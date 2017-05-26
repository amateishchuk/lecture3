using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Concrete.Animals
{
    public class Bear : Animal
    {
        public Bear(string name) : base(name, 6)
        {
        }
    }
}
