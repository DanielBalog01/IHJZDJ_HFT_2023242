using IHJZDJ_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using ConsoleTools;

namespace IHJZDJ_HFT_2023242.Client
{
    internal class Program
    {
        static RestService rest;


        static void Create(string entity)
        {
            if (entity == "Dog")
            {
                Console.WriteLine("Input Dog Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Input Dog Age:");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Dog BreedId:");
                int breedId = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Dog OwnerId:");
                int ownerId = int.Parse(Console.ReadLine());
                Dog dog = new Dog() { DogName = name, Age = age, BreedId = breedId, OwnerId = ownerId };
                rest.Post(dog, "dog");
            }
            else if (entity == "Breed")
            {
                Console.WriteLine("Input Breed Name:");
                string name = Console.ReadLine();
                Breed breed = new Breed() { BreedName = name };
                rest.Post(breed, "breed");
            }
            else if (entity == "Owner")
            {
                Console.WriteLine("Input Owner Name:");
                string name = Console.ReadLine();
                Owner owner = new Owner() { OwnerName = name };
                rest.Post(owner, "owner");
            }
            Console.WriteLine("Successful create! Press Enter!");
            Console.ReadLine();
        }

        static void List(string entity)
        {
            if (entity == "Dog")
            {
                List<Dog> dogs = rest.Get<Dog>("Dog");
                foreach (var item in dogs)
                {
                    Console.WriteLine(item.DogId + ": " + item.DogName);
                }
            }
            else if (entity == "Breed")
            {
                List<Breed> breeds = rest.Get<Breed>("Breed");
                foreach (var item in breeds)
                {
                    Console.WriteLine(item.BreedId + ": " + item.BreedName);
                }
            }
            else if (entity == "Owner")
            {
                List<Owner> owners = rest.Get<Owner>("Owner");
                foreach (var item in owners)
                {
                    Console.WriteLine(item.OwnerId + ": " + item.OwnerName);
                }
            }
            Console.ReadLine();
        }


        static void Update(string entity)
        {
            if (entity == "Dog")
            {
                Console.Write("Enter Dog's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Dog Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Input Dog Age:");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Dog BreedId:");
                int breedId = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Dog OwnerId:");
                int ownerId = int.Parse(Console.ReadLine());
                Dog dog = new Dog() { DogId = id, DogName = name, Age = age, BreedId = breedId, OwnerId = ownerId };
                rest.Put(dog, "dog");
            }
            else if (entity == "Breed")
            {
                Console.Write("Enter Breed's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Breed Name:");
                string name = Console.ReadLine();
                Breed breed = new Breed() { BreedId = id, BreedName = name };
                rest.Put(breed, "breed");
            }
            else if (entity == "Owner")
            {
                Console.Write("Enter Owner's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Owner Name:");
                string name = Console.ReadLine();
                Owner owner = new Owner() { OwnerId = id, OwnerName = name };
                rest.Put(owner, "owner");
            }
            Console.WriteLine("Successful update! Press Enter!");
            Console.ReadLine();
        }

        static void Delete(string entity)
        {
            if (entity == "Dog")
            {
                Console.Write("Enter Dog's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "dog");
            }
            else if (entity == "Breed")
            {
                Console.Write("Enter Breed's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "breed");
            }
            else if (entity == "Owner")
            {
                Console.Write("Enter Owner's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "owner");
            }
            Console.WriteLine("Successful delete! Press Enter!");
            Console.ReadLine();
        }



        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:36502/","dog");

            var dogSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Dog"))
                .Add("Create", () => Create("Dog"))
                .Add("Delete", () => Delete("Dog"))
                .Add("Update", () => Update("Dog"));

            var breedSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Breed"))
                .Add("Create", () => Create("Breed"))
                .Add("Delete", () => Delete("Breed"))
                .Add("Update", () => Update("Breed"))
                .Add("Exit", ConsoleMenu.Close);

            var ownerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Owner"))
                .Add("Create", () => Create("Owner"))
                .Add("Delete", () => Delete("Owner"))
                .Add("Update", () => Update("Owner"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Dogs", () => dogSubMenu.Show())
                .Add("Breeds", () => breedSubMenu.Show())
                .Add("Owners", () => ownerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();




        }
    }
}
