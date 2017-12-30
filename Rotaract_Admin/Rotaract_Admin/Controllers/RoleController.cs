using Rotaract_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rotaract_Admin.Controllers
{
    public class RoleController : Controller
    {
        RotaractEntities obj = new RotaractEntities();
        tbl_role o_role = new tbl_role();
        List<tbl_role> lst_role = new List<tbl_role>();

        private RoleModel RolePage()
        {
            RoleModel role = new RoleModel();
            List<ModuleModel> module = new List<ModuleModel>();
            List<string> lst_module = new List<string>();
            lst_module = obj.tbl_module.Select(x => x.Module_Name).ToList();
            foreach (string mod in lst_module)
            {
                ModuleModel aa = new ModuleModel();
                aa.Module = mod;
                module.Add(aa);
            }
            role.lst_module = module;
            return (role);
        }
        // GET: Role
        public ActionResult Index()
        {
            return View(obj.tbl_role.OrderByDescending(x=>x.CreateTS).ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View(RolePage());
        }

        // POST: Role/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //var temp1 = collection[collection.AllKeys[2]];
                //var temp2 = collection[collection.AllKeys[3]];
                //var temp = collection[collection.AllKeys.Where(k => k.Contains("Projects")).FirstOrDefault()];


                var keys = collection.AllKeys.ToList();
                var module = obj.tbl_module.ToList();
                tbl_role o_role = new tbl_role();
                o_role.ID = Guid.NewGuid();
                o_role.Name = collection[collection.AllKeys[1]];
                o_role.Status = true;
                o_role.Createdby = "Admin";
                o_role.Updatedby = "Admin";
                o_role.CreateTS = DateTime.UtcNow;
                o_role.UpdateTS = DateTime.UtcNow;
                obj.tbl_role.Add(o_role);

                foreach (var key in keys)
                {
                    if( module.Select(x=>x.Module_Name).Contains(key.ToString()))
                    {
                        tbl_role_module role_module = new tbl_role_module();
                        role_module.ID = Guid.NewGuid();
                        role_module.Role_ID = o_role.ID;
                        role_module.Module_ID = module.Where(y => y.Module_Name == key.ToString()).Select(x=> x.ID).FirstOrDefault();
                        role_module.Status = false;
                        if (collection[collection.AllKeys.Where(k => k.Contains(key)).FirstOrDefault()] != "false")
                        {
                            role_module.Status = true;
                        }                        
                        role_module.Createdby = "Admin";
                        role_module.Updatedby = "Admin";
                        role_module.CreateTS = DateTime.UtcNow;
                        role_module.UpdateTS = DateTime.UtcNow;
                        obj.tbl_role_module.Add(role_module);
                    }
                }
                obj.SaveChanges();
                //List<ModuleModel> test1 = collection[collection.AllKeys[2]];
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    ViewData["error"] = "Role already exists!";
                    return View(RolePage());
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "An error occured. Please try again!";
                return View(RolePage());
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Role/Edit/5
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

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
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
