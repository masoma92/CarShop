 // <copyright file="LogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.Logic;
    using CarShop.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class of the Logic
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        private Mock<IRepository> mock;

        /// <summary>
        /// Setup of the mock.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.mock = new Mock<IRepository>();

            CARBRAND cb = new CARBRAND() { brand_id = 1, car_name = "BMW", country = "Germany", url = "www.bmw.com", year_of_foundation = 1916, income_bill = 11 };
            CARBRAND cb2 = new CARBRAND() { brand_id = 2, car_name = "Volkswagen", country = "Germany", url = "www.volkswagen.com", year_of_foundation = 1952, income_bill = 18 };

            MODEL mo = new MODEL() { brand_id = 1, model_id = 1, model_name = "Z4", release_date = 2002, engine_volume = 3, horsepower = 189, price = 32000 };
            MODEL mo2 = new MODEL() { brand_id = 1, model_id = 2, model_name = "i3", release_date = 2015, engine_volume = 3, horsepower = 189, price = 32000 };

            EXTRA ex = new EXTRA() { extra_id = 1, category = "windows", extra_name = "motoric windows", color = null, extra_price = 500, usagemorethanonce = "no" };
            EXTRA ex2 = new EXTRA() { extra_id = 2, category = "windows", extra_name = "color", color = "red", extra_price = 200, usagemorethanonce = "no" };

            MODELEXTRASWITCHER mes = new MODELEXTRASWITCHER() { extra_id = 1, model_id = 1, msd_id = 1 };
            MODELEXTRASWITCHER mes2 = new MODELEXTRASWITCHER() { extra_id = 2, model_id = 2, msd_id = 2 };

            this.mock.Setup(m => m.GetCarBrands()).Returns(new[] { cb, cb2 });
            this.mock.Setup(m => m.GetModels()).Returns(new[] { mo, mo2 });
            this.mock.Setup(m => m.GetExtras()).Returns(new[] { ex, ex2 });
            this.mock.Setup(m => m.GetMes()).Returns(new[] { mes, mes2 });
        }

        /// <summary>
        /// Testing of ListCarBrands functions with mock.
        /// </summary>
        [Test]
        public void List_WhenGettingCarBrands_ReturnsCorrectly()
        {
            Logic logic = new Logic(this.mock.Object);

            var result = logic.ListCarBrands();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Where(b => b.car_name == "BMW" || b.car_name == "Volkswagen").Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Testing of ListModels functions with mock.
        /// </summary>
        [Test]
        public void List_WhenGettingModels_ReturnsCorrectly()
        {
            Logic logic = new Logic(this.mock.Object);

            var result = logic.ListModels();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Where(m => m.model_name == "Z4" || m.model_name == "i3").Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Testing of ListExtras functions with mock.
        /// </summary>
        [Test]
        public void List_WhenGettingExtras_ReturnsCorrectly()
        {
            Logic logic = new Logic(this.mock.Object);

            var result = logic.ListExtras();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Where(e => e.extra_name == "motoric windows" || e.extra_name == "color").Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Testing of ListModelsAndExtras functions with mock.
        /// </summary>
        [Test]
        public void List_WhenGettingMes_ReturnsCorrectly()
        {
            Logic logic = new Logic(this.mock.Object);

            var result = logic.ListMes();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Select(m => m.msd_id).Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Test of insert record with valid inputs.
        /// </summary>
        [Test]
        public void InsertValidInputs_ReturnsNothing()
        {
            Logic l = new Logic(this.mock.Object);

            string[] temp = new string[] { "1", "2", "3" };

            Assert.That(() => l.Insert(4, temp), Throws.Nothing);
        }

        /// <summary>
        /// Test of insert record with invalid inputs.
        /// </summary>
        [Test]
        public void InsertInValidInputs_ReturnsNothing()
        {
            Logic l = new Logic(this.mock.Object);

            Assert.That(() => l.Insert(-1, null), Throws.Nothing);
        }

        /// <summary>
        /// Test of delete record with valid inputs.
        /// </summary>
        [Test]
        public void DeleteWithValidInputs_ReturnsNothing()
        {
            Logic l = new Logic(this.mock.Object);

            Assert.That(() => l.Delete(1, 0), Throws.Nothing);
        }

        /// <summary>
        /// Test of delete record with invalid inputs.
        /// </summary>
        [Test]
        public void DeleteWithInvalidInputs_ReturnsNothing()
        {
            Logic l = new Logic(this.mock.Object);

            Assert.That(() => l.Delete(-1, -1), Throws.Nothing);
        }

        /// <summary>
        /// Test of modify record with valid inputs.
        /// </summary>
        [Test]
        public void ModifyWithValidInputs_ReturnsNothing()
        {
            Logic l = new Logic(this.mock.Object);

            Assert.That(() => l.Modify(1, 1), Throws.Nothing);
        }

        /// <summary>
        /// Test of modify record with invalid inputs.
        /// </summary>
        [Test]
        public void ModifyWithInvalidInputs_ReturnsNothing()
        {
            Logic l = new Logic(this.mock.Object);

            Assert.That(() => l.Modify(-1, -1), Throws.Nothing);
        }

        /// <summary>
        /// Test of PriceOfModelsWithExtras function.
        /// </summary>
        [Test]
        public void PriceOfModelsWithExtras_ReturnsCorrectQuery()
        {
            Logic l = new Logic(this.mock.Object);

            var pme = l.PriceOfModelsWithExtras();
            int count = 0;

            foreach (var item in pme)
            {
                count++;
            }

            Assert.That(pme, Is.Not.Null);
            Assert.That(count, Is.EqualTo(2));
        }

        /// <summary>
        /// Test of AvgPriceOfModelsByBrands function.
        /// </summary>
        [Test]
        public void AvgPriceOfModelsByBrands_ReturnsCorrectQuery()
        {
            Logic l = new Logic(this.mock.Object);

            var apm = l.AvgPriceOfModelsByBrands();
            int count = 0;

            foreach (var item in apm)
            {
                count++;
            }

            Assert.That(apm, Is.Not.Null);
            Assert.That(count, Is.EqualTo(1));
        }

        /// <summary>
        /// Test of CountOfExtras function.
        /// </summary>
        [Test]
        public void CountOfExtras_ReturnCorrectQuery()
        {
            Logic l = new Logic(this.mock.Object);

            var coe = l.CountOfExtras();
            int count = 0;

            foreach (var item in coe)
            {
                count++;
            }

            Assert.That(coe, Is.Not.Null);
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
