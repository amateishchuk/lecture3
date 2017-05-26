using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Abstract
{
    public abstract class Command
    {
        protected IRepository repository;

        public Command(IRepository repo)
        {
            repository = repo;
        }
        public abstract void Execute();
    }
}
