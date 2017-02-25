using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Conventions;
using Microsoft.Ajax.Utilities;
using PrasannaNeons.Data;
using PrasannaNeons.DataEntities;
using PrasannaNeons.Models;

namespace PrasannaNeons.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStatelessRepository _repository;

        public AccountController(IStatelessRepository repository)
        {
            _repository = repository;
        }
        
        
        public ActionResult Index(UserModel userModel)
        {
            if (userModel.UserName.IsNullOrWhiteSpace()) 
                return View();

            var userLogin = Session["loginUser"] = _repository.QueryOver<CustomerUser>(x => x.
                UserName == userModel.UserName && x.
                    Password == userModel.Password).FirstOrDefault();

            if (userLogin == null)return View();

            MvcApplication.LoginUser = userModel.UserName;
            return RedirectToAction("Index", "Services");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            MvcApplication.LoginUser = null;
            Session.Remove("loginUser");
            return RedirectToAction("Index", "Home");
        }


    }
}
