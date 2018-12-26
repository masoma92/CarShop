// <copyright file="ModifyRecords.cs" company="PlaceholderCompany">
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
    /// Helps in modifying records in the database
    /// </summary>
    public class ModifyRecords
    {
        /// <summary>
        /// Ask for the id of the record.
        /// </summary>
        /// <param name="num">decide what kind of records you'd like to modify</param>
        /// <returns>id of the record</returns>
        public int Modify(int num)
        {
            if (num == 1)
            {
                Console.WriteLine("\nWhich car brand would you like to modify? (Brand_ID)");
                int brandID = int.Parse(Console.ReadLine());
                return brandID;
            }
            else if (num == 2)
            {
                Console.WriteLine("\nWhich model would you like to modify? (Model_ID)");
                int modelID = int.Parse(Console.ReadLine());
                return modelID;
            }
            else if (num == 3)
            {
                Console.WriteLine("\nWhich extra would you like to modify? (Extra_ID)");
                int extraID = int.Parse(Console.ReadLine());
                return extraID;
            }
            else if (num == 4)
            {
                Console.WriteLine("\nWhich record would you like to modify? (MES_ID)");
                int mesID = int.Parse(Console.ReadLine());
                return mesID;
            }

            return 0;
        }
    }
}
