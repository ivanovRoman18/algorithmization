using System;
using System.Collections.Generic;

namespace AnimalManagementSystem
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Animal Left { get; set; }
        public Animal Right { get; set; }

        public Animal(int id, string name)
        {
            Id = id;
            Name = name.Length > 50 ? name.Substring(0, 50) : name;
            Left = null;
            Right = null;
        }
    }

    public class AnimalTree
    {
        private const int MaxCapacity = 50;
        private readonly List<Animal> _animalBuffer = new List<Animal>(MaxCapacity);

        public Animal Root { get; private set; }

        public bool AddAnimal(int id, string name)
        {
            if (_animalBuffer.Count >= MaxCapacity)
            {
                Console.WriteLine("Превышено максимальное количество животных");
                return false;
            }

            var newAnimal = new Animal(id, name);
            _animalBuffer.Add(newAnimal);

            if (Root == null)
            {
                Root = newAnimal;
            }
            else
            {
                InsertAnimal(Root, newAnimal);
            }

            return true;
        }

        private void InsertAnimal(Animal current, Animal newAnimal)
        {
            while (true)
            {
                if (newAnimal.Id > current.Id)
                {
                    if (current.Right == null)
                    {
                        current.Right = newAnimal;
                        return;
                    }
                    current = current.Right;
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = newAnimal;
                        return;
                    }
                    current = current.Left;
                }
            }
        }

        public void PrintTree()
        {
            PrintInOrder(Root);
        }

        private void PrintInOrder(Animal animal)
        {
            if (animal == null) return;

            PrintInOrder(animal.Left);
            Console.WriteLine($"{animal.Id}: {animal.Name}");
            PrintInOrder(animal.Right);
        }
    }

    public class Program
    {
        public static void Main()
        {
            var animalTree = new AnimalTree();

            animalTree.AddAnimal(10, "Слон");
            animalTree.AddAnimal(5, "Носорог");
            animalTree.AddAnimal(12, "Пантера");
            animalTree.AddAnimal(6, "Бегемот");

            animalTree.PrintTree();
        }
    }
}
