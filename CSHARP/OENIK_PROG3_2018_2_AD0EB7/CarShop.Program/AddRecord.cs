// <copyright file="AddRecord.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// Helps in adding records into the database
    /// </summary>
    public class AddRecord
    {
        /// <summary>
        /// Ask for the new parameters of the record.
        /// </summary>
        /// <param name="num">decide what kind of records you'd like to add</param>
        /// <returns>values with the new record</returns>
        public string[] AddNewRecords(int num)
        {
            if (num == 1)
            {
                Console.WriteLine("Add new parameters!");
                Type t = typeof(CARBRAND);
                PropertyInfo[] pi = t.GetProperties();
                string[] values = new string[pi.Length - 1];
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(pi[i].Name + ": ");
                    values[i] = Console.ReadLine();
                }

                return values;
            }
            else if (num == 2)
            {
                Console.WriteLine("Add new parameters!");
                Type t = typeof(MODEL);
                PropertyInfo[] pi = t.GetProperties();
                string[] values = new string[pi.Length - 2];
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(pi[i].Name + ": ");
                    values[i] = Console.ReadLine();
                }

                return values;
            }
            else if (num == 3)
            {
                Console.WriteLine("Add new parameters!");
                Type t = typeof(EXTRA);
                PropertyInfo[] pi = t.GetProperties();
                string[] values = new string[pi.Length - 1];
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(pi[i].Name + ": ");
                    values[i] = Console.ReadLine();
                }

                return values;
            }
            else if (num == 4)
            {
                Console.WriteLine("Add new parameters!");
                Type t = typeof(MODELEXTRASWITCHER);
                PropertyInfo[] pi = t.GetProperties();
                string[] values = new string[pi.Length - 2];
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(pi[i].Name + ": ");
                    values[i] = Console.ReadLine();
                }

                return values;
            }

            return null;
        }
    }
}
