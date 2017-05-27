using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;
using ZooClassLibrary.Concrete;
using ZooClassLibrary.Concrete.Animals;
using ZooClassLibrary.Concrete.Commands;
using ZooClassLibrary.Concrete.ZooWorkers;
using ZooClassLibrary.Enums;

namespace ZooClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {

            //Animal animal = new Bear("LION");
            //Console.WriteLine(animal.GetType().Name);


            IRepository repository = new ZooRepository();
            Person zooWorker = new ZooWorker();

            var showAnimalsCommand = new ShowAllCommand(repository);
            var insertCommand = new InsertCommand(repository);
            var feedCommand = new FeedCommand(repository);
            var healCommand = new HealCommand(repository);
            var deleteCommand = new DeleteCommand(repository);

            //repository.ShowAnimalsGroupedByKind();
            //repository.ShowAnimalsByState(State.Full);

            Console.BufferHeight = 200;

            TimerCallback destFunc = new TimerCallback(repository.ChangeRandomAnimalState);
            Timer changeRandomAnimalStateFiveSec = new Timer(destFunc, null, 5000, 5000);

            while (repository.IsAnythingAlive())
            {
                Console.WriteLine("Name\t\tHP\tMaxHP\tState\n");

                Console.WriteLine("Показать всех животных, сгруппированных по виду животного");
                repository.ShowAnimalsGroupedByKind();

                Console.WriteLine("Показать животных по состоянию - в параметрах передать Состояние");
                repository.ShowAnimalsByState(State.Full);

                Console.WriteLine("Показать всех тигров, которые больны");
                repository.ShowTigersWhichAreSick();

                Console.WriteLine("Показать слона с определенной кличкой, которая задается в параметре");
                repository.ShowElephantWithSpecifiedName("Слониха");

                Console.WriteLine("Показать список всех кличек животных, которые голодны");
                repository.ShowAnimalsNamesWhichAreHungry();

                Console.WriteLine("Показать самых здоровых животных каждого вида (по одному на каждый вид)");
                repository.ShowTheHealthestAnimalEachKinds();

                Console.WriteLine("Показать количество мертвых животных каждого вида");
                repository.ShowCountDeadAnimalsEachKinds();

                Console.WriteLine("Показать всех волков и медведей, у которых здоровье выше 3");
                repository.ShowAllWolfAndBearsWhichHealthAboveThree();

                Console.WriteLine("Показать животное с максимальным здоровьем и животное с минимальным здоровьем (описать одним выражением)");
                repository.ShowAnimalWithMaxHealthAndAnimalWithMinHealth();

                Console.WriteLine("Показать средней количество здоровья у животных в зоопарке");
                repository.ShowAverageHealthAllAnimals();

                zooWorker.Command = showAnimalsCommand;
                zooWorker.Run();

                showCommands();

                int commandNumber;
                int.TryParse(Console.ReadLine().Trim(), out commandNumber);

                zooWorker.Command = null;

                switch (commandNumber)
                {
                    case 0:
                        Console.WriteLine("Unknown command");
                        break;
                    case 1:
                        zooWorker.Command = insertCommand;
                        break;
                    case 2:
                        zooWorker.Command = feedCommand;
                        break;
                    case 3:
                        zooWorker.Command = healCommand;
                        break;
                    case 4:
                        zooWorker.Command = deleteCommand;
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                
                zooWorker.Run();

                Console.WriteLine("Press any button for continue...");
                Console.ReadLine();

                Console.Clear();

            }

            zooWorker.Command = showAnimalsCommand;
            zooWorker.Run();
            Console.WriteLine("All animals died. :((99((9((");



        }
        static void showCommands()
        {
            Console.WriteLine("Choose command:");
            Console.WriteLine("1. Insert new animal");
            Console.WriteLine("2. Feed animal");
            Console.WriteLine("3. Heal animal");
            Console.WriteLine("4. Delete animal");
            Console.WriteLine("5. Refresh...");
            Console.Write("Input command's number: ");
        }
    }
}
