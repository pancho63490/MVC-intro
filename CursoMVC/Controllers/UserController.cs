using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;


namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> list = null;
            using (CursoMVCEntities1 db = new CursoMVCEntities1())
            {
                list = (from d in db.User
                        where d.IdState == 1
                        orderby d.Correo
                        select new UserTableViewModel
                        {
                            Correo = d.Correo,
                            id = d.id,
                            edad = d.edad
                        }).ToList();
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            using (var db = new CursoMVCEntities1())
            {
                User oUser = new User();
                oUser.IdState = 1;
                oUser.Correo = model.Correo;
                oUser.edad = model.Edad;
                oUser.password = model.password;

                db.User.Add(oUser);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/user/"));
        }
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();
            using (var db = new CursoMVCEntities1())
            {
                var oUser = db.User.Find(id);
                model.Edad = (int)oUser.edad;
                model.Correo = oUser.Correo;
                model.id = oUser.id;


            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model) {

            if (!ModelState.IsValid)
            {
                return View(model);

            }
            using (var db = new CursoMVCEntities1())
            {
                var oUser = db.User.Find(model.id);
                oUser.Correo = model.Correo;
                oUser.edad = model.Edad;

                if(model.password!=null && model.password.Trim() != "")
                {
                    oUser.password = model.password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }

            return Redirect(Url.Content("~/user/"));

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

           
            using (var db = new CursoMVCEntities1())
            {
                var oUser = db.User.Find(id);
                oUser.IdState = 3;


                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }

            return Content("1");

        }
    }
 
}