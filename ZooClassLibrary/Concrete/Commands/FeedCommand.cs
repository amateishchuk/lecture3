using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Concrete.Commands
{
    public class FeedCommand : Command
    {
        public FeedCommand(IRepository repo) : base(repo)
        {

        }

        public override void Execute()
        {
            Console.Write("FEEDING: Input animal's name: ");
            string name = Console.ReadLine();

            repository.FeedAnimal(name);
        }
    }
}
