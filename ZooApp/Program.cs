using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;
using ZooClassLibrary.Concrete;
using ZooClassLibrary.Concrete.Commands;
using ZooClassLibrary.Concrete.ZooWorkers;

namespace ZooClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new ZooRepository();
            Person zooWorker = new ZooWorker();

            var showAnimalsCommand = new ShowAllCommand(repository);
            var insertCommand = new InsertCommand(repository);
            var feedCommand = new FeedCommand(repository);
            var healCommand = new HealCommand(repository);
            var deleteCommand = new DeleteCommand(repository);



            TimerCallback destFunc = new TimerCallback(repository.ChangeRandomAnimalState);
            Timer changeRandomAnimalStateFiveSec = new Timer(destFunc, null, 5000, 5000);

            while (repository.IsAnythingAlive())
            {
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
                Console.WriteLine();

                if (zooWorker.Command != null)
                    zooWorker.Run();

                Console.WriteLine("Wait 2 sec...");
                Thread.Sleep(2000);
                Console.Clear();

            }

            zooWorker.Command = showAnimalsCommand;
            zooWorker.Run();
            Console.WriteLine("All animals died");


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
