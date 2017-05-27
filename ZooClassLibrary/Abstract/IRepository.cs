using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Enums;

namespace ZooClassLibrary.Abstract
{
    public interface IRepository
    {
        void InsertAnimal(string name, string kind);
        void FeedAnimal(string name);
        void HealAnimal(string name);
        void DeleteAnimal(string name);
        void ShowAnimals();
        bool IsAnythingAlive();
        void ChangeRandomAnimalState(object obj);
        void ShowAnimalsGroupedByKind();
        void ShowAnimalsByState(State state);
        void ShowTigersWhichAreSick();
        void ShowElephantWithSpecifiedName(string name);
        void ShowAnimalsNamesWhichAreHungry();
        void ShowTheHealthestAnimalEachKinds();
        void ShowCountDeadAnimalsEachKinds();
        void ShowAllWolfAndBearsWhichHealthAboveThree();
        void ShowAnimalWithMaxHealthAndAnimalWithMinHealth();
        void ShowAverageHealthAllAnimals();
    }
}
