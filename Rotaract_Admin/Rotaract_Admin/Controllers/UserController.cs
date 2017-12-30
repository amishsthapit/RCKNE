using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rotaract_Admin.Controllers
{
    public class UserController : Controller
    {
        RotaractEntities obj = new RotaractEntities();
        tbl_user o_user = new tbl_user();
        List<tbl_user> lst_user = new List<tbl_user>();
        // GET: User
        public ActionResult Index()
        {            
            return View(obj.tbl_user.Where(x => x.Status == true).OrderByDescending(x=>x.CreateTS).ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {                
                o_user.Name = collection[collection.AllKeys[1]];
                o_user.Email = collection[collection.AllKeys[2]];
                o_user.Phone = collection[collection.AllKeys[3]];
                o_user.Address = collection[collection.AllKeys[4]];
                o_user.Role = collection[collection.AllKeys[5]];
                o_user.Updatedby = "Admin";
                o_user.Createdby = "Admin";
                o_user.UpdateTS = DateTime.UtcNow;
                o_user.CreateTS = DateTime.UtcNow;
                o_user.Status = true;
                obj.tbl_user.Add(o_user);
                obj.SaveChanges();
                TempData["success"] = "The user was created sucessfully!";
                return RedirectToAction("Index");
            }
           
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    ViewData["error"] = "The Email already exists!";
                    return View(o_user);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "An error occured. Please try again!";
                return View(o_user);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(obj.tbl_user.Where(x=>x.SN == id).FirstOrDefault());
        }

        // POST: User/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            o_user = obj.tbl_user.Where(x => x.SN == id).FirstOrDefault();
            try
            {
                o_user.Name = collection[collection.AllKeys[2]];
                //o_user.Email = collection[collection.AllKeys[1]];
                o_user.Phone = collection[collection.AllKeys[3]];
                o_user.Address = collection[collection.AllKeys[4]];
                o_user.Role = collection[collection.AllKeys[5]];
                o_user.Updatedby = "Admin";
                //o_user.Createdby = "Admin";
                o_user.UpdateTS = DateTime.UtcNow;
                //o_user.CreateTS = DateTime.UtcNow;
                o_user.Status = true;
                o_user.SN = id;
                //obj.tbl_user.Add(o_user);
                obj.SaveChanges();
                TempData["success"] = "The user was updated sucessfully!";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    ViewData["error"] = "The Email already exists!";
                    return View(o_user);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "An error occured. Please try again!";
                return View(o_user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
