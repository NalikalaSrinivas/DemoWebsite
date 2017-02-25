using System.Web.Mvc;
using NHibernate;
using PrasannaNeons.Data;
using PrasannaNeons.DataEntities;

namespace PrasannaNeons.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStatelessRepository _repository;

        public HomeController(IStatelessRepository repository)
        {
            _repository = repository;
        }
        
        //Home
        public ActionResult Index()
        {
            var customer = (Customer) _repository.Get<Customer>(1);
            return View(customer);
        }
        
        //Resume
        public ActionResult DevelopedAndDesigned()
        {
            return View();
        }

        //Catalog
        public ActionResult Catalog()
        {
            return View();
        }

        //Contacts 
        public ActionResult Contact()
        {
            return View();
        }

    }
}


