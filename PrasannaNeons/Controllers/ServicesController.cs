using System.Web.Mvc;
using PrasannaNeons.Data;
using PrasannaNeons.DataEntities;

namespace PrasannaNeons.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IStatelessRepository _repository;
        private CustomerUser _sessionLogin;

        public ServicesController(IStatelessRepository repository)
        {
            _repository = repository;
        }
        
        public ActionResult Index()
        {
            _sessionLogin = (CustomerUser) Session["loginUser"];

            if(_sessionLogin != null)
                return View();
            return RedirectToAction("Index", "Account");
        }

    }
}
