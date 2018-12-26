// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.Repository;

    /// <summary>
    /// Implements ILogic interface.
    /// </summary>
    public class Logic : ILogic
    {
        private readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// 1. constructor wasiting for an IRepository instance
        /// </summary>
        /// <param name="repository">IRepository instance</param>
        public Logic(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// 2. constructor, creates a new repository.
        /// </summary>
        public Logic()
        {
            this.repository = new Repository();
        }

        /// <summary>
        /// List function of the carbrands.
        /// </summary>
        /// <returns>returns an IEnumerable carbrand</returns>
        public IEnumerable<CARBRAND> ListCarBrands()
        {
            return this.repository.GetCarBrands().Select(g => new CARBRAND()
            {
                brand_id = g.brand_id,
                car_name = g.car_name,
                country = g.country,
                income_bill = g.income_bill,
                url = g.url,
                year_of_foundation = g.year_of_foundation
            });
        }

        /// <summary>
        /// List function of the models.
        /// </summary>
        /// <returns>returns an IEnumerable model</returns>
        public IEnumerable<MODEL> ListModels()
        {
            return this.repository.GetModels().Select(g => new MODEL()
            {
                brand_id = g.brand_id,
                model_id = g.model_id,
                model_name = g.model_name,
                engine_volume = g.engine_volume,
                horsepower = g.horsepower,
                price = g.price,
                release_date = g.release_date,
            });
        }

        /// <summary>
        /// List function of the extras.
        /// </summary>
        /// <returns>returns an IEnumerable extra</returns>
        public IEnumerable<EXTRA> ListExtras()
        {
            return this.repository.GetExtras().Select(g => new EXTRA()
            {
                extra_id = g.extra_id,
                color = g.color,
                extra_name = g.extra_name,
                category = g.category,
                extra_price = g.extra_price,
                usagemorethanonce = g.usagemorethanonce
            });
        }

        /// <summary>
        /// List function of the MODELEXTRASWITCHER.
        /// </summary>
        /// <returns>returns an IEnumerable MODELEXTRASWITCHER</returns>
        public IEnumerable<MODELEXTRASWITCHER> ListMes()
        {
            return this.repository.GetMes().Select(g => new MODELEXTRASWITCHER()
            {
                msd_id = g.msd_id,
                extra_id = g.extra_id,
                model_id = g.model_id
            });
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
                try
                {
                    int brandid = int.Parse(values[0]);
                    string carname = values[1];
                    string country = values[2];
                    string url = values[3];
                    int yearoffoundation = int.Parse(values[4]);
                    decimal incomebill = decimal.Parse(values[5]);

                    this.repository.Insert(num, values);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong parameters!");
                    Console.ReadLine();
                }
            }
            else if (num == 2)
            {
                try
                {
                    int modelId = int.Parse(values[0]);
                    int brandId = int.Parse(values[1]);
                    string modelName = values[2];
                    int releaseDate = int.Parse(values[3]);
                    decimal engineVolume = decimal.Parse(values[4]);
                    int horsePower = int.Parse(values[5]);
                    int price = int.Parse(values[6]);

                    this.repository.Insert(num, values);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong parameter try again!");
                    Console.ReadLine();
                }
            }
            else if (num == 3)
            {
                try
                {
                    int extraID = int.Parse(values[0]);
                    string category = values[1];
                    string extraName = values[2];
                    int extraPrice = int.Parse(values[3]);
                    string color = values[4];
                    string usageMoreThanOnce = values[5];

                    this.repository.Insert(num, values);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong parameter try again!");
                    Console.ReadLine();
                }
            }
            else if (num == 4)
            {
                try
                {
                    int msd_id = int.Parse(values[0]);
                    int extra_id = int.Parse(values[1]);
                    int model_id = int.Parse(values[2]);

                    this.repository.Insert(num, values);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong parameter, try again!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Deleting an element from the database.
        /// </summary>
        /// <param name="num">decide which table we'll delete from</param>
        /// <param name="id">id of the element</param>
        public void Delete(int num, int id)
        {
            if (num > 0 && id >= 0)
            {
                this.repository.Delete(num, id);
            }
        }

        /// <summary>
        /// Modifying an element in the database.
        /// </summary>
        /// <param name="num">decide from which table we'll modify</param>
        /// <param name="id">id of the element</param>
        public void Modify(int num, int id)
        {
            if (num > 0 && id >= 0)
            {
                this.repository.Modify(num, id);
            }
        }

        /// <summary>
        /// Lists the prices of models+extras.
        /// </summary>
        /// <returns>IEnumrable collection</returns>
        public IEnumerable PriceOfModelsWithExtras()
        {
            var q = from x in this.repository.GetModels()
                    from y in this.repository.GetExtras()
                    from z in this.repository.GetMes()
                    where x.model_id == z.model_id && y.extra_id == z.extra_id
                    select new { Model = x.model_name, Price = x.price + y.extra_price };
            return q;
        }

        /// <summary>
        /// Lists the avarage price of models by brands.
        /// </summary>
        /// <returns>IEnumrable collection</returns>
        public IEnumerable AvgPriceOfModelsByBrands()
        {
            var q = from x in this.repository.GetModels()
                    from y in this.repository.GetCarBrands()
                    where x.brand_id == y.brand_id
                    group x by y.car_name into g
                    select new { Brand = g.Key, AvaragePrice = g.Average(x => x.price) };

            return q;
        }

        /// <summary>
        /// Lists the count of extras.
        /// </summary>
        /// <returns>IEnumrable collection</returns>
        public IEnumerable CountOfExtras()
        {
            var q = from x in this.repository.GetModels()
                    from y in this.repository.GetExtras()
                    from z in this.repository.GetMes()
                    where x.model_id == z.model_id && y.extra_id == z.extra_id
                    group y by y.category into g
                    select new { Category = g.Key, Count = g.Select(x => x.MODELEXTRASWITCHERs.Select(y => y.extra_id)).Count() };

            return q;
        }
    }
}
