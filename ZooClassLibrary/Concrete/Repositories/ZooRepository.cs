using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;
using ZooClassLibrary.Concrete.AnimalFactories;
using ZooClassLibrary.Concrete.Animals;
using ZooClassLibrary.Enums;
using ZooClassLibrary.Extensions;

namespace ZooClassLibrary.Concrete
{
    public class ZooRepository : IRepository
    {
        List<Animal> animals = new List<Animal>
        {
            new Fox("Лис"),
            new Fox("Лиса"),
            new Tiger("Тигр"),
            new Tiger("Тигрица"),
            new Lion("Лев"),
            new Lion("Львица"),
            new Bear("Медведь"),
            new Bear("Медведица"),
            new Elephant("Слон"),
            new Elephant("Слониха"),
            new Wolf("Волк"),
            new Wolf("Волчица")
        };

        public void ChangeRandomAnimalState(object obj)
        {
            int notDeadAnimalsCount = animals.Where(a => a.State != State.Dead).Count();

            int randomIndex = new Random().Next(0, notDeadAnimalsCount);
            animals[randomIndex].ChangeState();

            animals = animals.OrderBy(a => a.State).ToList();         
        }

        public bool IsAnythingAlive()
        {
            return animals.Where(a => a.State != State.Dead).ToList().Count > 0;
        }

        public void DeleteAnimal(string name)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null)
            {
                if (animal.State == State.Dead)
                {
                    animals.Remove(animal);
                    Console.WriteLine($"{name} was deleted from repository");
                }
                else
                    Console.WriteLine($"You can delete {name}, because its not dead");               
            }
            else
                Console.WriteLine($"The animal with specified name ({name}) is apsend in repository");
        }

        public void FeedAnimal(string name)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null && animal.State != State.Dead)
            {
                animal.Eat();
                Console.WriteLine($"{name} was fed");
            }
            else
                Console.WriteLine($"The animal with specified name ({name}) is apsend in repository");
        }

        public void HealAnimal(string name)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null)
            {
                animal.HealthUp();
            }
            else
                Console.WriteLine($"The animal with specified name ({name}) is apsend in repository");
        }

        public void InsertAnimal(string name, string kind)
        {
            kind = kind.FormatWord();

            Animal animal = getAnimalByName(name);

            if (animal != null)
                Console.WriteLine($"The animal with specified name ({name}) is present in repository");
            else
            {
                animal = returnNewAnimal(name, kind);

                if (animal != null)
                {
                    animals.Add(animal);
                    Console.WriteLine($"The Animal was inserted (name: {name}, kind: {kind})");
                }

                else
                    Console.WriteLine("The specified kind of animal isn't implemented");
            }
        }

        public void ShowAnimals()
        {
            animals.ForEach(); // Extensions.ListExtensions.cs
        }

        public void ShowAnimalsGroupedByKind()
        {
            var groupedAnimals = animals.GroupBy(a => a.GetType().Name);
            
            foreach(var kind in groupedAnimals)
            {
                Console.WriteLine(kind.Key);
                kind.ForEach();
            }
        }


        public void ShowAnimalsByState(State state)
        {
            var stateAnimals = animals.Where(a => a.State == state);
            stateAnimals.ForEach();
        }

        public void ShowTigersWhichAreSick()
        {
            var sickTigers = animals.Where(a => a.GetType().Name == "Tiger" && a.State == State.Sick);
            sickTigers.ForEach();
        }

        public void ShowElephantWithSpecifiedName(string name)
        {
            if (name != null)
            {
                var elephant = animals.FirstOrDefault(a => a.GetType().Name == "Elephant" && a.Name == name);
                Console.WriteLine(elephant);
            }
            Console.WriteLine();

        }

        public void ShowAnimalsNamesWhichAreHungry()
        {
            var hungryAnimals = animals.Where(a => a.State == State.Hungry).Select(a => a.Name);

            foreach (var animal in hungryAnimals)
                Console.WriteLine(animal);

            Console.WriteLine();
        }

        public void ShowTheHealthestAnimalEachKinds()
        {
            var animalGroups = animals.GroupBy(a => a.GetType().Name)
                                      .Select(a => (Kind: a.Key,
                                                    TheHealthestAnimal: a.OrderByDescending(an=>an.Health).First()));
            foreach (var animalGroup in animalGroups)
                Console.WriteLine($"{animalGroup.Kind} {animalGroup.TheHealthestAnimal}");

            Console.WriteLine();
        }

        public void ShowCountDeadAnimalsEachKinds()
        {
            var animalGroups = animals.GroupBy(a => a.GetType().Name)
                                      .Select(a => (Kind: a.Key, 
                                                    Count: a.Count(an => an.State == State.Dead)));
            foreach (var animalGroup in animalGroups)
                Console.WriteLine($"{animalGroup.Kind} {animalGroup.Count}");

            Console.WriteLine();

        }

        public void ShowAllWolfAndBearsWhichHealthAboveThree()
        {
            var wolfAndBears = from a in animals
                               where (a.GetType().Name == "Wolf" ||
                                     a.GetType().Name == "Bear") &&
                                     a.Health > 3
                               select a;

            wolfAndBears.ForEach();
        }

        public void ShowAnimalWithMaxHealthAndAnimalWithMinHealth()
        {
            var maxmin = animals.OrderByDescending(a => a.Health).Take(1)
                  .Union(animals.OrderBy(a => a.Health).Take(1));
                        
            maxmin.ForEach();


        }

        public void ShowAverageHealthAllAnimals()
        {
            var avgHealth = animals.Average(a => a.Health);
            Console.WriteLine($"{(int)avgHealth}\n");
        }

        private Animal getAnimalByName(string name)
        {
            return animals
                .FirstOrDefault(a => a.Name.FormatWord() == name.FormatWord());
        }
        
        private Animal returnNewAnimal(string name, string kind)
        {
            Animal animal = null;

            switch (kind)
            {
                case "lion":
                    animal = new LionFactory().CreateAnimal(name);
                    break;

                case "tiger":
                    animal = new TigerFactory().CreateAnimal(name);
                    break;

                case "elephant":
                    animal = new ElephantFactory().CreateAnimal(name);
                    break;

                case "bear":
                    animal = new BearFactory().CreateAnimal(name);
                    break;

                case "wolf":
                    animal = new WolfFactory().CreateAnimal(name);
                    break;

                case "fox":
                    animal = new FoxFactory().CreateAnimal(name);
                    break;
            }

            return animal;
        }

    }
}

