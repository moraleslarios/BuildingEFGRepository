using BuildingEFGRepository.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuildingEFGRepository.DAL.Tests
{
    [TestClass]
    public class DisconGenericRepositoryTests
    {
        public IDisconGenericRepository<FootballClub> instance;



        [TestInitialize]
        public void Initialize()
        {
            Func<DbContext> contextCreator = () => new MyDBEntities() as DbContext;

            instance = new DisconGenericRepository<FootballClub>(dbContextCreator: contextCreator);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowException()
        {
            instance = new DisconGenericRepository<FootballClub>(null);
        }




        [TestMethod]
        public void All_OK()
        {
            IEnumerable<FootballClub> result = instance.All();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task AllAsync_OK()
        {
            IEnumerable<FootballClub> result = await instance.AllAsync();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }


        [TestMethod]
        public void Find_OK()
        {
            object[] pks = new object[] { 1 };

            FootballClub result = instance.Find(pks);

            Assert.AreEqual(result.Id, 1);
        }


        [TestMethod]
        public async Task FindAsync_OK()
        {
            object[] pks = new object[] { 1 };

            FootballClub result = await instance.FindAsync(pks);

            Assert.AreEqual(result.Id, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_PksNull_ThrowException()
        {
            object[] pks = null;

            FootballClub result = instance.Find(pks);
        }




        [TestMethod]
        public void GetData_OK()
        {
            Expression<Func<FootballClub, bool>> filter = a => a.Name == "Real Madrid C. F.";

            IEnumerable<FootballClub> result = instance.GetData(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 1);
        }


        [TestMethod]
        public async Task GetDataAsync_OK()
        {
            Expression<Func<FootballClub, bool>> filter = a => a.Name == "Real Madrid C. F.";

            IEnumerable<FootballClub> result = await instance.GetDataAsync(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 1);
        }


        [TestMethod]
        public void Add_SimpleItem_OK()
        {
            FootballClub newEntity = new FootballClub
            {
                CityId = 1,
                Name = "New Team",
                Members = 0,
                Stadium = "New Stadium",
                FundationDate = DateTime.Today
            };

            int result = instance.Add(newEntity);
            int expected = 1;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public async Task AddAsync_SimpleItem_OK()
        {
            FootballClub newEntity = new FootballClub
            {
                CityId = 1,
                Name = "New Team",
                Members = 0,
                Stadium = "New Stadium",
                FundationDate = DateTime.Today
            };

            int result = await instance.AddAsync(newEntity);
            int expected = 1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_MultiItems_OK()
        {
            IEnumerable<FootballClub> newEntities = new List<FootballClub>
            {
                new FootballClub
                {
                    CityId = 1,
                    Name = "New Team",
                    Members = 0,
                    Stadium = "New Stadium",
                    FundationDate = DateTime.Today
                },
                    new FootballClub
                    {
                        CityId = 1,
                        Name = "New Team 2",
                        Members = 0,
                        Stadium = "New Stadium 2",
                        FundationDate = DateTime.Today
                    }
            };

            int result = instance.Add(newEntities);
            int expected = 2;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public async Task AddAsync_MultiItems_OK()
        {
            IEnumerable<FootballClub> newEntities = new List<FootballClub>
            {
                new FootballClub
                {
                    CityId = 1,
                    Name = "New Team",
                    Members = 0,
                    Stadium = "New Stadium",
                    FundationDate = DateTime.Today
                },
                    new FootballClub
                    {
                        CityId = 1,
                        Name = "New Team 2",
                        Members = 0,
                        Stadium = "New Stadium 2",
                        FundationDate = DateTime.Today
                    }
            };

            int result = await instance.AddAsync(newEntities);
            int expected = 2;

            Assert.AreEqual(expected, result);
        }



        [TestMethod]
        public void Remove_SimpleItem_forEntity_OK()
        {
            /// changed pk for tests

            var removeEntity = instance.Find(99);

            int result = instance.Remove(removeEntity);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public async Task RemoveAsync_SimpleItem_forEntity_OK()
        {
            /// changed pk for tests

            FootballClub removeEntity = new FootballClub
            {
                Id            = 9999,
                CityId        = 1,
                Name          = "New Team",
                Members       = 0,
                Stadium       = "New Stadium",
                FundationDate = DateTime.Today
            };

            int result = await instance.RemoveAsync(removeEntity);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Remove_MultiItems_forEntity_OK()
        {
            /// changed pk for tests

            IEnumerable<FootballClub> removeEntities = new List<FootballClub>
            {
                new FootballClub
                {
                    Id            = 9999,
                    CityId        = 1,
                    Name          = "New Team",
                    Members       = 0,
                    Stadium       = "New Stadium",
                    FundationDate = DateTime.Today
                },
                    new FootballClub
                    {
                        Id            = 100,
                        CityId        = 1,
                        Name          = "New Team 2",
                        Members       = 0,
                        Stadium       = "New Stadium 2",
                        FundationDate = DateTime.Today
                    }
            };

            int result = instance.Remove(removeEntities);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public async Task RemoveAsync_MultiItems_forEntity_OK()
        {
            /// changed pks for tests

            IEnumerable<FootballClub> removeEntities = new List<FootballClub>
            {
                new FootballClub
                {
                    Id            = 9999,
                    CityId        = 1,
                    Name          = "New Team",
                    Members       = 0,
                    Stadium       = "New Stadium",
                    FundationDate = DateTime.Today
                },
                    new FootballClub
                    {
                        Id            = 9999,
                        CityId        = 1,
                        Name          = "New Team 2",
                        Members       = 0,
                        Stadium       = "New Stadium 2",
                        FundationDate = DateTime.Today
                    }
            };

            int result = await instance.RemoveAsync(removeEntities);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }






        [TestMethod]
        public void Remove_SimpleItem_forPK_OK()
        {
            /// changed pk for tests

            int result = instance.Remove(pks: 9999);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public async Task RemoveAsync_SimpleItem_forPK_OK()
        {
            /// changed pk for tests

            int result = await instance.RemoveAsync(pks: 9999);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Update_OK()
        {
            /// changed values for tests

            FootballClub updateEntity = new FootballClub
            {
                Id            = 45,
                CityId        = 1,
                Name          = "New Team 3",
                Members       = 10,
                Stadium       = "New Stadium 3",
                FundationDate = DateTime.Today
            };

            int result = instance.Update(updateEntity);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task UpdateAsync_OK()
        {
            /// changed values for tests

            FootballClub updateEntity = new FootballClub
            {
                Id            = 44,
                CityId        = 1,
                Name          = "New Team 2",
                Members       = 10,
                Stadium       = "New Stadium 2",
                FundationDate = DateTime.Today
            };

            int result = await instance.UpdateAsync(updateEntity);
            int expected = 0;

            Assert.AreEqual(expected, result);
        }






        //[TestCleanup]
        //public void Cleanup()
        //{
        //    instance.Dispose();
        //}




    }
}
