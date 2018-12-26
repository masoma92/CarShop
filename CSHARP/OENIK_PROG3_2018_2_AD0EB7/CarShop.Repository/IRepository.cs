// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// CRUD methods.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Specifies the list function of the car brands.
        /// </summary>
        /// <returns>returns an ienumerable collection of the car brands</returns>
        IEnumerable<CARBRAND> GetCarBrands();

        /// <summary>
        /// Specifies the list function of the models.
        /// </summary>
        /// <returns>returns an ienumerable collection of the models</returns>
        IEnumerable<MODEL> GetModels();

        /// <summary>
        /// Specifies the list function of the extras.
        /// </summary>
        /// <returns>returns an ienumerable collection of the extras</returns>
        IEnumerable<EXTRA> GetExtras();

        /// <summary>
        /// Specifies the list function of the models and extras.
        /// </summary>
        /// <returns>returns an ienumerable collection of the models and extras</returns>
        IEnumerable<MODELEXTRASWITCHER> GetMes();

        /// <summary>
        /// Specifies the insert function.
        /// </summary>
        /// <param name="num">type number</param>
        /// <param name="values">values of the record</param>
        void Insert(int num, string[] values);

        /// <summary>
        /// Specifies the delete function.
        /// </summary>
        /// <param name="num">type number</param>
        /// <param name="iD">number of the record</param>
        void Delete(int num, int iD);

        /// <summary>
        /// Specifies the modify function.
        /// </summary>
        /// <param name="num">type number</param>
        /// <param name="iD">number of the record</param>
        void Modify(int num, int iD);
    }
}
