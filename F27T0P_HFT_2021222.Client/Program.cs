using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using F27T0P_HFT_2021222.Models;
using ConsoleTools;

namespace F27T0P_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand Name: ");
                string name = Console.ReadLine();
                rest.Post(new Brand() { Name = name }, "brand");
            }

            if (entity == "GpuType")
            {
                Console.Write("Enter GpuType Name: ");
                string name = Console.ReadLine();
                rest.Post(new GpuType() { Name = name }, "gputype");
            }

            if (entity == "Customer")
            {
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();
                rest.Post(new Customer() { Name = name }, "customer");
            }
        }

        static void List(string entity)
        {
            if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (var item in brands)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }

            if (entity == "GpuType")
            {
                List<GpuType> gpus = rest.Get<GpuType>("gputype");
                foreach (var item in gpus)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }

            if (entity == "Customer")
            {
                List<Customer> customers = rest.Get<Customer>("customer"); // itt customers volt 2022.11.25 16:19, valamint az endpointban a CustomerController el volt írva CustomersControllerre ezért nem volt jó a konzolos alkalmazás
                foreach (var item in customers)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "brand");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "brand");
            }

            if (entity == "GpuType")
            {
                Console.Write("Enter GpuType's id to update: ");
                int id = int.Parse(Console.ReadLine());
                GpuType one = rest.Get<GpuType>(id, "gputype");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "gputype");
            }

            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Customer one = rest.Get<Customer>(id, "customer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "customer");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }

            if (entity == "GpuType")
            {
                Console.Write("Enter GpuType's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "gputype");
            }

            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "customer");
            }
        }

        static void GetAverageGpuPrice()
        {
            var answer = rest.GetSingle<int>("/GpuTypeStat/GetAverageGpuPrice");

            Console.WriteLine("Average Price: " + answer);

            Console.ReadLine();
        }

        static void GetGpuWithoutOwner()
        {
            var list = rest.Get<string>("/GpuTypeStat/GetGpuWithoutOwner");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void GetGpuWithMultipleBrands()
        {
            var list = rest.Get<string>("/GpuTypeStat/GetGpuWithoutOwner");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void GetAverageGpuPriceForAPerson()
        {
            Console.WriteLine("Person id: ");
            int id = int.Parse(Console.ReadLine());

            var answer = rest.GetSingle<double>($"/CustomerStat/GetAverageGpuPriceForAPerson/{id}");
            Console.WriteLine("Average Price: " + answer);
            Console.ReadLine();
        }

        static void GetMostOwnedGpuCustomers()
        {
            var answer = rest.Get<KeyValuePair<string, int>>("/CustomerStat/GetMostOwnedGpuCustomers");

            foreach (var item in answer)
            {
                Console.WriteLine("Person Name: " + item.Key + "  Number of Gpus: " + item.Value);
            }

            Console.ReadLine();
        }

        static void GetOwnersOrderedByNumOfGpus()
        {
            var list = rest.Get<KeyValuePair<string, int>>("/CustomerStat/GetOwnersOrderedByNumOfGpus");

            foreach (var item in list)
            {
                Console.WriteLine("Persone Name: " + item.Key + "  Number of Gpus: " + item.Value);
            }
            Console.ReadLine();
        }

        static void GetLowestValueSpentCustomer()
        {
            var list = rest.Get<KeyValuePair<string, int>>("/CustomerStat/GetLowestValueSpentCustomer");

            foreach (var item in list)
            {
                Console.WriteLine("Person Name: " + item.Key + "    Money Spent: " + item.Value);
            }
            Console.ReadLine();
        }

        static void GetHighestValueSpentCustomer()
        {
            var list = rest.Get<KeyValuePair<string, int>>("/CustomerStat/GetHighestValueSpentCustomer");

            foreach (var item in list)
            {
                Console.WriteLine("Persone Name: " + item.Key + "   Money Spent: " + item.Value);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:42137/");
            ;
            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var gputypeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("GpuType"))
                .Add("Create", () => Create("GpuType"))
                .Add("Delete", () => Delete("GpuType"))
                .Add("Update", () => Update("GpuType"))
                .Add("GetAverageGpuPrice", () => GetAverageGpuPrice())
                .Add("GetGpuWithoutOwner", () => GetGpuWithoutOwner())
                .Add("GetGpuWithMultipleBrands", () => GetGpuWithMultipleBrands())
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("GetAverageGpuPriceForAPerson", () => GetAverageGpuPriceForAPerson())
                .Add("GetMostOwnedGpuCustomers", () => GetMostOwnedGpuCustomers())
                .Add("GetOwnersOrderedByNumOfGpus", () => GetOwnersOrderedByNumOfGpus())
                .Add("GetLowestValueSpentCustomer", () => GetLowestValueSpentCustomer())
                .Add("GetHighestValueSpentCustomer", () => GetHighestValueSpentCustomer())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Brands", () => brandSubMenu.Show())
                .Add("GpuTypes", () => gputypeSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
