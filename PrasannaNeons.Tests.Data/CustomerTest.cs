using System.Linq;
using NUnit.Framework;
using PrasannaNeons.Data;
using PrasannaNeons.DataEntities;

namespace PrasannaNeons.Tests.Data
{
    [TestFixture]
    public class CustomerTest
    {

        [TestCase]
        public void CustomerDetails()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customer = new Customer
                    {
                        Id = 1,
                        Name = "Vasu"
                    };
                    session.Save(customer);
                    transaction.Commit();
                }
            }            
        }

        [TestCase]
        public void Repository_CreateCustomer()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Test"
            };
            var repository = new StatelessRepository();
            repository.Create<Customer>(customer);

        }

        [TestCase]
        public void Repository_GetCustomerById()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Test"
            };
            var repository = new StatelessRepository();
            var result = (Customer) repository.Get<Customer>(customer.Id);
            Assert.AreEqual("Test", result.Name);
        }

        [TestCase]
        public void Repository_GetAll()
        {
            var repository = new StatelessRepository();
            var result = repository.LoadAll<Customer>();
            int count = result.Count;
        }

        [TestCase]
        public void Repository_QueryOver()
        {
            var repository = new StatelessRepository();
            var result = repository.QueryOver<Customer>(x => x.Name == "Test").FirstOrDefault();
        }

        [TestCase]
        public void Repository_Exists()
        {
            var repository = new StatelessRepository();
            var result = repository.Exist<Customer>(x => x.Name == "Test" && x.Id == 2);
            Assert.AreEqual(true,result);
        }


    }
}
