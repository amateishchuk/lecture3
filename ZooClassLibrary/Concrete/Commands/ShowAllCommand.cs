using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Concrete.Commands
{
    public class ShowAllCommand : Command
    {
        public ShowAllCommand(IRepository repo) : base(repo)
        {
        }

        public override void Execute()
        {
            repository.ShowAnimals();
        }
    }
}
