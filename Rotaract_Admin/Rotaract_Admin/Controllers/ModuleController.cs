using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rotaract_Admin.Controllers
{
    public class ModuleController : Controller
    {
        RotaractEntities obj = new RotaractEntities();
        tbl_module o_module = new tbl_module();
        List<tbl_module> lst_module = new List<tbl_module>();
        // GET: Module
        public ActionResult Index()
        {
            return View(obj.tbl_module.OrderByDescending(x=> x.CreateTS).ToList());
        }

        // GET: Module/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Module/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Module/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                o_module.Module_Name = collection[collection.AllKeys[1]];
                o_module.Createdby = "Admin";
                o_module.Updatedby = "Admin";
                o_module.CreateTS = DateTime.UtcNow;
                o_module.UpdateTS = DateTime.UtcNow;
                o_module.ID = Guid.NewGuid();

                obj.tbl_module.Add(o_module);
                obj.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    ViewData["error"] = "Module already exists!";
                    return View(o_module);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "An error occured. Please try again!";
                return View(o_module);
            }
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Module/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Module/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
