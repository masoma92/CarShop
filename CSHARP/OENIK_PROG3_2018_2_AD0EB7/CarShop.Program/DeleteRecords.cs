// <copyright file="DeleteRecords.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// Helps in deleting records into the database
    /// </summary>
    public class DeleteRecords
    {
        /// <summary>
        /// Ask for the id of the record you'd like to delete.
        /// </summary>
        /// <param name="num">decide what kind of records you'd like to remove</param>
        /// <returns>values with the new record</returns>
        public int Delete(int num)
        {
            if (num == 1)
            {
                Console.WriteLine("\nWhich car brand would you like to delete? (Brand_ID)");
                int brandID = int.Parse(Console.ReadLine());
                return brandID;
            }
            else if (num == 2)
            {
                Console.WriteLine("\nWhich model would you like to delete? (Model_ID)");
                int modelID = int.Parse(Console.ReadLine());
                return modelID;
            }
            else if (num == 3)
            {
                Console.WriteLine("\nWhich extra would you like to delete? (Extra_id)");
                int extraID = int.Parse(Console.ReadLine());
                return extraID;
            }
            else if (num == 4)
            {
                Console.WriteLine("\nWhich extra would you like to delete? (MES_ID)");
                int mesID = int.Parse(Console.ReadLine());
                return mesID;
            }

            return 0;
        }
    }
}
