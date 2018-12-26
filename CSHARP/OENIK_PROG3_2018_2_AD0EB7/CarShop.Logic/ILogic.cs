// <copyright file="ILogic.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// CRUD + non CRUD methods.
    /// </summary>
    internal interface ILogic
    {
        /// <summary>
        /// Specifies the list function of the car brands.
        /// </summary>
        /// <returns>returns an ienumerable collection of the car brands</returns>
        IEnumerable<CARBRAND> ListCarBrands();

        /// <summary>
        /// Specifies the list function of the models.
        /// </summary>
        /// <returns>returns an ienumerable collection of the models</returns>
        IEnumerable<MODEL> ListModels();

        /// <summary>
        /// Specifies the list function of the extras.
        /// </summary>
        /// <returns>returns an ienumerable collection of the extras</returns>
        IEnumerable<EXTRA> ListExtras();

        /// <summary>
        /// Specifies the list function of the models and extras.
        /// </summary>
        /// <returns>returns an ienumerable collection of the models and extras</returns>
        IEnumerable<MODELEXTRASWITCHER> ListMes();

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

        /// <summary>
        /// Specifies the PriceOfModelsWithExtras function.
        /// </summary>
        /// <returns>returns IEnumerable collection</returns>
        IEnumerable PriceOfModelsWithExtras();

        /// <summary>
        /// Specifies the AvgPriceOfModelsByBrands function.
        /// </summary>
        /// <returns>returns IEnumerable collection</returns>
        IEnumerable AvgPriceOfModelsByBrands();

        /// <summary>
        /// Specifies the CountOfExtras function.
        /// </summary>
        /// <returns>returns IEnumerable collection</returns>
        IEnumerable CountOfExtras();
    }
}
