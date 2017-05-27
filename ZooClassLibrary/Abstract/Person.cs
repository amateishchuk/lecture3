using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Abstract
{
    public abstract class Person
    {
        public Command Command { protected get; set; }

        public void Run()
        {
            if (Command != null)
                Command.Execute();
        }
    }
}
