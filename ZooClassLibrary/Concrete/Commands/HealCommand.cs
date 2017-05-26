using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Concrete.Commands
{
    public class HealCommand : Command
    {
        public HealCommand(IRepository repo) : base(repo)
        {
        }

        public override void Execute()
        {
            Console.Write("HEALING: Input animal's name: ");
            string name = Console.ReadLine();
            repository.HealAnimal(name);
        }
    }
}
