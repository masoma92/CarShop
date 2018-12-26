// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using CarShop.Data;
    using CarShop.Logic;

    /// <summary>
    /// Documentation of Menu.
    /// </summary>
    public class Menu
    {
        private readonly Logic operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.operations = new Logic();
            this.DisplayMenu();
        }

        /// <summary>
        /// Displaymenu fuction shows the main menu.
        /// </summary>
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("/// 1. List ///");
            Console.WriteLine("/// 2. Add Item ///");
            Console.WriteLine("/// 3. Delete Item ///");
            Console.WriteLine("/// 4. Modify Item ///");
            Console.WriteLine("/// 5. Execute Query ///");
            Console.WriteLine("/// 6. Java/Web Interaction ///");
            ConsoleKeyInfo keyPressed;
            keyPressed = Console.ReadKey();
            switch (keyPressed.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    this.List();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    this.Add();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    this.Delete();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    this.Modify();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    this.ExecuteQuery();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Console.Clear();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Price: ");
                    int price = int.Parse(Console.ReadLine());
                    this.JavaInterAction(name, model, price);
                    break;
                default:
                    this.DisplayMenu();
                    break;
            }
        }

        /// <summary>
        /// List fuction shows the List options (READ).
        /// </summary>
        public void List()
        {
            Console.Clear();
            Console.WriteLine("/// 1. List car brands ///");
            Console.WriteLine("/// 2. List models ///");
            Console.WriteLine("/// 3. List extras ///");
            Console.WriteLine("/// 4. List models + extras ///\n");

            Console.WriteLine("Go back to main menu? - Press any other button.");
            ConsoleKeyInfo keyPressed;
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
            {
                this.PrintCarBrand(this.operations.ListCarBrands());
            }

            if (keyPressed.Key == ConsoleKey.D2 || keyPressed.Key == ConsoleKey.NumPad2)
            {
                this.PrintModels(this.operations.ListModels());
            }

            if (keyPressed.Key == ConsoleKey.D3 || keyPressed.Key == ConsoleKey.NumPad3)
            {
                this.PrintExtras(this.operations.ListExtras());
            }

            if (keyPressed.Key == ConsoleKey.D4 || keyPressed.Key == ConsoleKey.NumPad4)
            {
                this.PrintMes(this.operations.ListMes());
            }

            Console.Clear();
            this.DisplayMenu();
        }

        /// <summary>
        /// With this function you can add new items to the database (CREATE).
        /// </summary>
        public void Add()
        {
            Console.Clear();
            bool repeat = false;
            do
            {
                Console.WriteLine("/// 1. Add car brand ///");
                Console.WriteLine("/// 2. Add model ///");
                Console.WriteLine("/// 3. Add extra ///");
                Console.WriteLine("/// 4. Add model + extra ///\n");

                Console.WriteLine("Go back to main menu? - Press any other button.");
                ConsoleKeyInfo keyPressed;
                keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                {
                    this.PrintCarBrand(this.operations.ListCarBrands());
                    string[] values = new AddRecord().AddNewRecords(1);
                    this.operations.Insert(1, values);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D2 || keyPressed.Key == ConsoleKey.NumPad2)
                {
                    this.PrintModels(this.operations.ListModels());
                    string[] values = new AddRecord().AddNewRecords(2);
                    this.operations.Insert(2, values);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D3 || keyPressed.Key == ConsoleKey.NumPad3)
                {
                    this.PrintExtras(this.operations.ListExtras());
                    string[] values = new AddRecord().AddNewRecords(3);
                    this.operations.Insert(3, values);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D4 || keyPressed.Key == ConsoleKey.NumPad4)
                {
                    this.PrintMes(this.operations.ListMes());
                    string[] values = new AddRecord().AddNewRecords(4);
                    this.operations.Insert(4, values);
                    repeat = true;
                    Console.Clear();
                }
                else
                {
                    repeat = false;
                }
            }
            while (repeat == true);

            Console.Clear();
            this.DisplayMenu();
        }

        /// <summary>
        /// This function lets you to delete an item (DELETE).
        /// </summary>
        public void Delete()
        {
            Console.Clear();
            bool repeat = false;
            do
            {
                Console.WriteLine("/// 1. Delete car brand ///");
                Console.WriteLine("/// 2. Delete model ///");
                Console.WriteLine("/// 3. Delete extra ///");
                Console.WriteLine("/// 4. Delete models + extra ///\n");

                Console.WriteLine("Go back to main menu? - Press any other button.");
                ConsoleKeyInfo keyPressed;
                keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                {
                    this.PrintCarBrand(this.operations.ListCarBrands());
                    int brandId = new DeleteRecords().Delete(1);
                    this.operations.Delete(1, brandId);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D2 || keyPressed.Key == ConsoleKey.NumPad2)
                {
                    this.PrintModels(this.operations.ListModels());
                    int modelID = new DeleteRecords().Delete(2);
                    this.operations.Delete(2, modelID);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D3 || keyPressed.Key == ConsoleKey.NumPad3)
                {
                    this.PrintExtras(this.operations.ListExtras());
                    int extraID = new DeleteRecords().Delete(3);
                    this.operations.Delete(3, extraID);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D4 || keyPressed.Key == ConsoleKey.NumPad4)
                {
                    this.PrintMes(this.operations.ListMes());
                    int mesID = new DeleteRecords().Delete(4);
                    this.operations.Delete(4, mesID);
                    repeat = true;
                    Console.Clear();
                }
                else
                {
                    repeat = false;
                }
            }
            while (repeat == true);
            Console.Clear();
            this.DisplayMenu();
        }

        /// <summary>
        /// This function lets you to Modify an item (UPDATE).
        /// </summary>
        public void Modify()
        {
            Console.Clear();
            bool repeat = false;
            do
            {
                Console.WriteLine("/// 1. Modify car brand ///");
                Console.WriteLine("/// 2. Modify model ///");
                Console.WriteLine("/// 3. Modify extra ///");
                Console.WriteLine("/// 4. Modify model + extra ///\n");

                Console.WriteLine("Go back to main menu? - Press any other button.");
                ConsoleKeyInfo keyPressed;
                keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                {
                    this.PrintCarBrand(this.operations.ListCarBrands());
                    int cb = new ModifyRecords().Modify(1);
                    this.operations.Modify(1, cb);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D2 || keyPressed.Key == ConsoleKey.NumPad2)
                {
                    this.PrintModels(this.operations.ListModels());
                    int m = new ModifyRecords().Modify(2);
                    this.operations.Modify(2, m);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D3 || keyPressed.Key == ConsoleKey.NumPad3)
                {
                    this.PrintExtras(this.operations.ListExtras());
                    int ex = new ModifyRecords().Modify(3);
                    this.operations.Modify(3, ex);
                    repeat = true;
                    Console.Clear();
                }

                if (keyPressed.Key == ConsoleKey.D4 || keyPressed.Key == ConsoleKey.NumPad4)
                {
                    this.PrintMes(this.operations.ListMes());
                    int mes = new ModifyRecords().Modify(4);
                    this.operations.Modify(4, mes);
                    repeat = true;
                    Console.Clear();
                }
                else
                {
                    repeat = false;
                }
            }
            while (repeat == true);
            Console.Clear();
            this.DisplayMenu();
        }

        /// <summary>
        /// This function lets you to Execute a type of query.
        /// </summary>
        public void ExecuteQuery()
        {
            Console.Clear();
            Console.WriteLine("/// 1. List prices of models and extras ///");
            Console.WriteLine("/// 2. Avarage price of models by brands ///");
            Console.WriteLine("/// 3. List numbers of used extras by their category ///\n");

            Console.WriteLine("Go back to main menu? - Press any other button.");
            ConsoleKeyInfo keyPressed;
            keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
            {
                this.PrintQuery(this.operations.PriceOfModelsWithExtras());
            }

            if (keyPressed.Key == ConsoleKey.D2 || keyPressed.Key == ConsoleKey.NumPad2)
            {
                this.PrintQuery(this.operations.AvgPriceOfModelsByBrands());
            }

            if (keyPressed.Key == ConsoleKey.D3 || keyPressed.Key == ConsoleKey.NumPad3)
            {
                this.PrintQuery(this.operations.CountOfExtras());
            }
            else
            {
                this.DisplayMenu();
            }

            this.DisplayMenu();
        }

        /// <summary>
        /// Java Endpoint
        /// </summary>
        /// <param name="name">Costumer name</param>
        /// <param name="model">Model name</param>
        /// <param name="price">Price of the model</param>
        public void JavaInterAction(string name, string model, int price)
        {
            try
            {
                name.Replace(' ', '+');
                model.Replace(' ', '+');
                string url = $"http://localhost:8080/OENIK_PROG3_2018_1_AD0EB7/DataRequest?costumername={name}&modelname={model}&price={price}";

                XDocument xdoc = XDocument.Load(url);

                var q = xdoc.Root.Elements("offer").Select(x => new
                {
                    Model = x.Element("model").Value,
                    Costumer = x.Element("costumerName").Value,
                    Price = x.Element("price").Value
                }).ToList();

                this.PrintQuery(q);
            }
            catch (Exception)
            {
                throw new JavaException(name, model, price);
            }

            Console.Clear();
            this.DisplayMenu();
        }

        private void PrintQuery(IEnumerable input)
        {
            Console.Clear();
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress ENTER.");
            Console.ReadLine();
        }

        private void PrintCarBrand(IEnumerable<CARBRAND> input)
        {
            Console.Clear();
            foreach (var item in input)
            {
                Console.Write("Brand_ID: {0} | Name: {1} | Country: {2} | Url: {3} | Year: {4} | Income: {5}\n", item.brand_id, item.car_name, item.country, item.url, item.year_of_foundation, item.income_bill);
            }

            Console.WriteLine("\nPress ENTER.");
            Console.ReadLine();
        }

        private void PrintModels(IEnumerable<MODEL> input)
        {
            Console.Clear();
            foreach (var item in input)
            {
                Console.Write("Brand_IDFK: {0} | Model_ID: {1} | Name: {2} | EngineVolume: {3} | HorsePower: {4} | Price: {5} | ReleaseDate: {6}\n", item.brand_id, item.model_id, item.model_name, item.engine_volume, item.horsepower, item.price, item.release_date);
            }

            Console.WriteLine("\nPress ENTER.");
            Console.ReadLine();
        }

        private void PrintExtras(IEnumerable<EXTRA> input)
        {
            Console.Clear();
            foreach (var item in input)
            {
                Console.Write("Extra_ID: {0} | Category: {1} | Name: {2} | Color: {3} | Price: {4} | MoreThanOnce: {5}\n", item.extra_id, item.category, item.extra_name, item.color, item.extra_price, item.usagemorethanonce);
            }

            Console.WriteLine("\nPress ENTER.");
            Console.ReadLine();
        }

        private void PrintMes(IEnumerable<MODELEXTRASWITCHER> input)
        {
            Console.Clear();
            foreach (var item in input)
            {
                Console.Write("MES_ID: {0} | Extra_ID: {1} | Model_ID: {2}\n", item.msd_id, item.extra_id, item.model_id);
            }

            Console.WriteLine("\nPress ENTER.");
            Console.ReadLine();
        }
    }
}
