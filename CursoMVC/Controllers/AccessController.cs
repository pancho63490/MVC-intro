using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string User, string Pass)
        {
            try
            {
                using (CursoMVCEntities1 db = new CursoMVCEntities1())
                {
                    var list = from d in db.User
                               where d.Correo == User && d.password == Pass && d.IdState == 1
                               select d;
                    if (list.Count() > 0)
                    {
                        User oUser = list.First();
                        Session["user"] = list.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario o Contrasena erronea");
                    }
                }
            
            }
            catch(Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}