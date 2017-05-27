using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Enums;

namespace ZooClassLibrary.Abstract
{
    public abstract class Animal
    {
        public string Name { get; protected set; }
        public State State { get; protected set; }
        public int Health { get; protected set; }
        public readonly int MAXHEALTH;

        public Animal(string name, int maxhealth)
        {
            Name = name;
            State = State.Full;
            Health = maxhealth;
            MAXHEALTH = maxhealth;
        }

        public void HealthUp()
        {
            if (State == State.Dead)
            {
                Console.WriteLine($"{Name} is dead");
                Console.WriteLine("You can delete from repository");
            }
            else if (Health < MAXHEALTH)
            {
                Health++;
                Console.WriteLine($"{Name} was heal");
                if (Health == MAXHEALTH)
                    State--;
            }
            else
                Console.WriteLine($"{Name} is healthy");
        }

        public void Eat()
        {
            if (State != State.Full)
                State = State.Full;
            else
                Console.WriteLine($"{Name} is full already");
        }

        public void ChangeState()
        {
            if (State == State.Sick)
            {
                if (Health > 0)
                {
                    Health--;
                    if (Health == 0)
                        State = State.Dead;
                }
                else
                    State = State.Dead;
            }
            else
            {
                State++;
                if (State == State.Sick)
                {
                    if (Health > 0)
                    {
                        Health--;
                        if (Health == 0)
                            State = State.Dead;
                    }
                    else
                        State = State.Dead;
                }
            }
        }

        public override string ToString()
        {
            return String.Format($"{Name}\t\t{Health}\t{MAXHEALTH}\t{State}");
        }
    }
}