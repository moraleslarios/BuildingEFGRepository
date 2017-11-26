using BuildingEFGRepository.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuildingEFGRepository.DAL.Tests
{
    [TestClass]
    public class ConGenericRepositoryTests
    {
        public IConGenericRepository<FootballClub> instance;



        [TestInitialize]
        public void Initialize()
        {
            var context = new MyDBEntities() as DbContext;

            instance = new ConGenericRepository<FootballClub>(dbContext: context);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowException()
        {
            //instance.Dispose();

            instance = new ConGenericRepository<FootballClub>(null);
        }





        [TestMethod]
        public void All_OK()
        {
            ObservableCollection<FootballClub> result = instance.All();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public async Task AllAsync_OK()
        {
            ObservableCollection<FootballClub> result = await instance.AllAsync();

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

            ObservableCollection<FootballClub> result = instance.GetData(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
        }


        [TestMethod]
        public async Task GetDataAsync_OK()
        {
            Expression<Func<FootballClub, bool>> filter = a => a.Name == "Real Madrid C. F.";

            ObservableCollection<FootballClub> result = await instance.GetDataAsync(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
        }




        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetData_FilterNull_ThrowException()
        {
            Expression<Func<FootballClub, bool>> filter = null;

            ObservableCollection<FootballClub> result = instance.GetData(filter);
        }



        [TestMethod]
        public void GetData_AddAfterFilter_OK()
        {
            Expression<Func<FootballClub, bool>> filter = a => a.Name == "Real Madrid C. F.";

            ObservableCollection<FootballClub> result = instance.GetData(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);

            result.Add(new FootballClub
            {
                CityId = 1,
                Name = "New Team",
                Members = 0,
                Stadium = "New Stadium",
                FundationDate = DateTime.Today
            });

            var changes = ((ConGenericRepository<FootballClub>)instance)._dbContext.ChangeTracker.Entries<FootballClub>().Where(e => e.State == EntityState.Added).ToList();
            var change = changes.First().Entity as FootballClub;


            Assert.AreEqual(changes.Count, 1);
            Assert.AreEqual(change.Name, "New Team");
        }

        [TestMethod]
        public void GetData_RemoveAfterFilter_OK()
        {
            Expression<Func<FootballClub, bool>> filter = a => a.Name == "Real Madrid C. F.";

            ObservableCollection<FootballClub> result = instance.GetData(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);

            result.RemoveAt(0);

            var changes = ((ConGenericRepository<FootballClub>)instance)._dbContext.ChangeTracker.Entries<FootballClub>().Where(e => e.State == EntityState.Deleted).ToList();
            var change = changes.First().Entity as FootballClub;


            Assert.AreEqual(changes.Count, 1);
            Assert.AreEqual(change.Name, "Real Madrid C. F.");
        }

        [TestMethod]
        public void GetData_UpdateAfterFilter_OK()
        {
            var result = instance.All();

            Expression<Func<FootballClub, bool>> filter = a => a.Name == "Real Madrid C. F.";

            result = instance.GetData(filter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);

            result[0].Name = "Cambiada";

            var changes = ((ConGenericRepository<FootballClub>)instance)._dbContext.ChangeTracker.Entries<FootballClub>().Where(e => e.State == EntityState.Modified).ToList();
            var change = changes.First().Entity as FootballClub;


            Assert.AreEqual(changes.Count, 1);
            Assert.AreEqual(change.Name, "Cambiada");
        }



        [TestMethod]
        public void SaveChanges_OK()
        {
            ObservableCollection<FootballClub> data = instance.All();

            data.Add(new FootballClub
                {
                    CityId = 1,
                    Name = "New Team",
                    Members = 0,
                    Stadium = "New Stadium",
                    FundationDate = DateTime.Today
                });

            int result = instance.SaveChanges();
            int expected = 1;

            RemovedInsertRecords();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task SaveChangesAsync_OK()
        {
            ObservableCollection<FootballClub> data = instance.All();

            data.Add(new FootballClub
            {
                CityId = 1,
                Name = "New Team",
                Members = 0,
                Stadium = "New Stadium",
                FundationDate = DateTime.Today
            });

            int result = await instance.SaveChangesAsync();
            int expected = 1;

            RemovedInsertRecords();

            Assert.AreEqual(expected, result);
        }




        [TestCleanup]
        public void Cleanup()
        {
            //RemovedInsertRecords();

            instance.Dispose();
        }

        private void RemovedInsertRecords()
        {
            var data = instance.GetData(a => a.Members == 0);

            var removeRecoreds = data.ToList();

            removeRecoreds.ForEach(a => data.Remove(a));

            instance.SaveChanges();
        }


    }
}
