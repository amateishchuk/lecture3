﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;
using ZooClassLibrary.Concrete.Animals;

namespace ZooClassLibrary.Concrete.AnimalFactories
{
    public class LionFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string name)
        {
            return new Lion(name);
        }
    }
}
