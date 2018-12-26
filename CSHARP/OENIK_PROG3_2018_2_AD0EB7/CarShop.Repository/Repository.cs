// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// Implements IRepository interface (CRUD methods).
    /// </summary>
    public class Repository : IRepository
    {
        private readonly CarsEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// This constructor is creating a new entity of our database.
        /// </summary>
        public Repository()
        {
            this.db = new CarsEntities();
        }

        /// <summary>
        /// List function of the carbrands.
        /// </summary>
        /// <returns>returns an IEnumerable carbrand</returns>
        public IEnumerable<CARBRAND> GetCarBrands()
        {
            return this.db.CARBRANDS;
        }

        /// <summary>
        /// List function of the models.
        /// </summary>
        /// <returns>returns an IEnumerable model</returns>
        public IEnumerable<MODEL> GetModels()
        {
            return this.db.MODELS;
        }

        /// <summary>
        /// List function of the extras.
        /// </summary>
        /// <returns>returns an IEnumerable extra</returns>
        public IEnumerable<EXTRA> GetExtras()
        {
            return this.db.EXTRAS;
        }

        /// <summary>
        /// List function of the MODELEXTRASWITCHER.
        /// </summary>
        /// <returns>returns an IEnumerable MODELEXTRASWITCHER</returns>
        public IEnumerable<MODELEXTRASWITCHER> GetMes()
        {
            return this.db.MODELEXTRASWITCHERs;
        }

        /// <summary>
        /// Inserting a new element into the database.
        /// </summary>
        /// <param name="num">decide into which table we'll insert</param>
        /// <param name="values">values of the element</param>
        public void Insert(int num, string[] values)
        {
            if (num == 1)
            {
                CARBRAND newcb = new CARBRAND()
                {
                    brand_id = int.Parse(values[0]),
                    car_name = values[1],
                    country = values[2],
                    url = values[3],
                    year_of_foundation = int.Parse(values[4]),
                    income_bill = decimal.Parse(values[5])
                };

                this.db.CARBRANDS.Add(newcb);
                this.db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Insert OK");
                Console.ReadLine();
            }
            else if (num == 2)
            {
                MODEL newModel = new MODEL()
                {
                    model_id = int.Parse(values[0]),
                    brand_id = int.Parse(values[1]),
                    model_name = values[2],
                    release_date = int.Parse(values[3]),
                    engine_volume = decimal.Parse(values[4]),
                    horsepower = int.Parse(values[5]),
                    price = int.Parse(values[6])
                };

                this.db.MODELS.Add(newModel);
                this.db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Insert OK");
                Console.ReadLine();
            }
            else if (num == 3)
            {
                EXTRA newEx = new EXTRA()
                {
                    extra_id = int.Parse(values[0]),
                    category = values[1],
                    extra_name = values[2],
                    extra_price = int.Parse(values[3]),
                    color = values[4],
                    usagemorethanonce = values[5]
                };

                this.db.EXTRAS.Add(newEx);
                this.db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Insert OK");
                Console.ReadLine();
            }
            else if (num == 4)
            {
                MODELEXTRASWITCHER newMes = new MODELEXTRASWITCHER()
                {
                    msd_id = int.Parse(values[0]),
                    extra_id = int.Parse(values[1]),
                    model_id = int.Parse(values[2])
                };

                this.db.MODELEXTRASWITCHERs.Add(newMes);
                this.db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Insert OK");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Deleting an element from the database.
        /// </summary>
        /// <param name="num">decide which table we'll delete from</param>
        /// <param name="id">id of the element</param>
        public void Delete(int num, int id)
        {
            if (num == 1)
            {
                try
                {
                    CARBRAND cb = this.db.CARBRANDS.Single(x => x.brand_id == id);

                    var models = this.db.MODELS.Where(x => x.brand_id == cb.brand_id);

                    foreach (var item in models.Select(x => x.model_id))
                    {
                        var temp = this.db.MODELEXTRASWITCHERs.Where(x => x.model_id == item);
                        this.db.MODELEXTRASWITCHERs.RemoveRange(temp);
                    }

                    this.db.MODELS.RemoveRange(models);
                    this.db.CARBRANDS.Remove(cb);
                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Delete OK");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
            else if (num == 2)
            {
                try
                {
                    MODEL m = this.db.MODELS.Single(x => x.model_id == id);

                    var mes = this.db.MODELEXTRASWITCHERs.Where(x => x.model_id == m.model_id);

                    this.db.MODELEXTRASWITCHERs.RemoveRange(mes);
                    this.db.MODELS.Remove(m);
                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Delete OK");
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
            else if (num == 3)
            {
                try
                {
                    EXTRA ex = this.db.EXTRAS.Single(x => x.extra_id == id);

                    var mes = this.db.MODELEXTRASWITCHERs.Where(x => x.extra_id == ex.extra_id);

                    this.db.MODELEXTRASWITCHERs.RemoveRange(mes);
                    this.db.EXTRAS.Remove(ex);
                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Delete OK");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
            else if (num == 4)
            {
                try
                {
                    MODELEXTRASWITCHER mes = this.db.MODELEXTRASWITCHERs.Single(x => x.msd_id == id);

                    this.db.MODELEXTRASWITCHERs.Remove(mes);
                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Delete OK");
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Modifying an element in the database.
        /// </summary>
        /// <param name="num">decide from which table we'll modify</param>
        /// <param name="id">id of the element</param>
        public void Modify(int num, int id)
        {
            if (num == 1)
            {
                try
                {
                    CARBRAND cb = cb = this.db.CARBRANDS.Single(x => x.brand_id == id);

                    Console.WriteLine("\nWhich parameter would you like to modify?");
                    string parameter = Console.ReadLine();
                    Console.Write("Value: ");
                    switch (parameter)
                    {
                        case "Brand_ID":
                            cb.brand_id = int.Parse(Console.ReadLine());
                            break;
                        case "Name":
                            cb.car_name = Console.ReadLine();
                            break;
                        case "Country":
                            cb.country = Console.ReadLine();
                            break;
                        case "Url":
                            cb.url = Console.ReadLine();
                            break;
                        case "Year":
                            cb.year_of_foundation = int.Parse(Console.ReadLine());
                            break;
                        case "Income":
                            cb.income_bill = decimal.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Wrong parameter, use within the list!");
                            this.Modify(1, id);
                            break;
                    }

                    CARBRAND brand = cb;
                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Update OK");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
            else if (num == 2)
            {
                try
                {
                    MODEL mo = this.db.MODELS.Single(x => x.model_id == id);

                    Console.WriteLine("\nWhich parameter would you like to modify?");
                    string parameter = Console.ReadLine();
                    Console.Write("Value: ");
                    switch (parameter)
                    {
                        case "Brand_IDFK":
                            mo.brand_id = int.Parse(Console.ReadLine());
                            break;
                        case "Model_ID":
                            mo.model_id = int.Parse(Console.ReadLine());
                            break;
                        case "Name":
                            mo.model_name = Console.ReadLine();
                            break;
                        case "EngineVolume":
                            mo.engine_volume = decimal.Parse(Console.ReadLine());
                            break;
                        case "HorsePower":
                            mo.horsepower = decimal.Parse(Console.ReadLine());
                            break;
                        case "Price":
                            mo.price = int.Parse(Console.ReadLine());
                            break;
                        case "ReleaseDate":
                            mo.release_date = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Wrong parameter, use within the list!");
                            this.Modify(2, id);
                            break;
                    }

                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Update OK");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
            else if (num == 3)
            {
                try
                {
                    EXTRA ex = this.db.EXTRAS.Single(x => x.extra_id == id);

                    Console.WriteLine("\nWhich parameter would you like to modify?");
                    string parameter = Console.ReadLine();
                    Console.Write("Value: ");
                    switch (parameter)
                    {
                        case "Extra_ID":
                            ex.extra_id = int.Parse(Console.ReadLine());
                            break;
                        case "Category":
                            ex.category = Console.ReadLine();
                            break;
                        case "Name":
                            ex.extra_name = Console.ReadLine();
                            break;
                        case "Color":
                            ex.color = Console.ReadLine();
                            break;
                        case "Price":
                            ex.extra_price = int.Parse(Console.ReadLine());
                            break;
                        case "MoreThanOnce":
                            ex.usagemorethanonce = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Wrong parameter, use within the list!");
                            this.Modify(3, id);
                            break;
                    }

                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Update OK!");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                    Console.ReadLine();
                }
            }
            else if (num == 4)
            {
                try
                {
                    MODELEXTRASWITCHER mes = this.db.MODELEXTRASWITCHERs.Single(x => x.msd_id == id);

                    Console.WriteLine("\nWhich parameter would you like to modify?");
                    string parameter = Console.ReadLine();
                    Console.Write("Value: ");
                    switch (parameter)
                    {
                        case "MES_ID":
                            mes.msd_id = int.Parse(Console.ReadLine());
                            break;
                        case "Extra_ID":
                            mes.extra_id = int.Parse(Console.ReadLine());
                            break;
                        case "Model_ID ":
                            mes.model_id = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("You can only change: MES_ID or Extra_ID or Model_ID!");
                            this.Modify(4, id);
                            break;
                    }

                    this.db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Update OK");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong parameter!");
                }
            }
        }
    }
}
