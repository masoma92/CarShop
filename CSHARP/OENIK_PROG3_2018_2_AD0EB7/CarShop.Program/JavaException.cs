// <copyright file="JavaException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Exception for java server
    /// </summary>
    public class JavaException : Exception
    {
        /// <summary>
        /// Gets costumer name
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Gets model name
        /// </summary>
        private readonly string model;

        /// <summary>
        /// Gets price
        /// </summary>
        private readonly int price;

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaException"/> class.
        /// Constructor which sets the properties
        /// </summary>
        /// <param name="name">Costumer name</param>
        /// <param name="model">Model name</param>
        /// <param name="price">Price name</param>
        public JavaException(string name, string model, int price)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.PrintFaultWithProperties();
        }

        /// <summary>
        /// Function for print the exception.
        /// </summary>
        private void PrintFaultWithProperties()
        {
            Console.WriteLine("Java server is not available or doesn't exist. Can't create offer for {0} {1} {2}", this.name, this.model, this.price);
        }
    }
}
