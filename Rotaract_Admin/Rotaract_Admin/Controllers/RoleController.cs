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


        /*Returns the modules associated with the role.
        Parameters:
        id: Role ID
        */
        private RoleModel RolePage(string id)
        {
            RoleModel role = new RoleModel();
            List<ModuleModel> module = new List<ModuleModel>();            
            List<string> rolemodule = new List<string>();
            var lst_module = obj.tbl_module.Select(x => new { x.Module_Name, x.ID }).ToList();   
            if(id != null)
            {
                role.Role_ID = Guid.Parse(id);
                rolemodule = obj.tbl_module.Where(x => obj.tbl_role_module.Where(y => y.Role_ID == role.Role_ID && y.Status == true).Select(y => y.Module_ID).ToList().Contains(x.ID)).Select(x => x.Module_Name).ToList();
                role.Role = obj.tbl_role.Where(y => y.ID == role.Role_ID).Select(x => x.Name).FirstOrDefault();
                
            }
            
            foreach (var mod in lst_module)
            {
                ModuleModel aa = new ModuleModel();
                aa.id = mod.ID;
                aa.Module = mod.Module_Name;
                if(rolemodule.Contains(mod.Module_Name))
                {
                    aa.Value = true;
                }
                else
                {
                    aa.Value = false;
                }
                module.Add(aa);
            }
            role.lst_module = module;
            return (role);
        }


        private bool RoleCheck(string role)
        {
            if (obj.tbl_role.Where(x => x.Name == role).Count() != 0)
                return true;
            else
                return false;
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
            return View(RolePage(null));
        }

        // POST: Role/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(RoleModel roleModel)
        {
            if (RoleCheck(roleModel.Role))
            {
                ViewData["error"] = "The Role already exists.";
                return View(RolePage(null));
            }
            try
            {                
                tbl_role o_role = new tbl_role();
                o_role.ID = Guid.NewGuid();
                o_role.Name = roleModel.Role;                

                o_role.Status = true;
                o_role.Createdby = "Admin";
                o_role.Updatedby = "Admin";
                o_role.CreateTS = DateTime.UtcNow;
                o_role.UpdateTS = DateTime.UtcNow;
                obj.tbl_role.Add(o_role);

                foreach (var module in roleModel.lst_module)
                {
                    if(module.Value)
                    {                    
                        tbl_role_module role_module = new tbl_role_module();
                        role_module.ID = Guid.NewGuid();
                        role_module.Role_ID = o_role.ID;
                        role_module.Module_ID = module.id;
                        role_module.Status = module.Value;                       
                        role_module.Createdby = "Admin";
                        role_module.Updatedby = "Admin";
                        role_module.CreateTS = DateTime.UtcNow;
                        role_module.UpdateTS = DateTime.UtcNow;
                        obj.tbl_role_module.Add(role_module);
                    }
                }
                obj.SaveChanges();
                ViewData["success"] = "The Role is created successfully";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    ViewData["error"] = "Role already exists!";
                    return View(RolePage(null));
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "An error occured. Please try again!";
                return View(RolePage(null));
            }
            
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {             
            return View(RolePage(id));
        }

        // POST: Role/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(RoleModel roleModel)
        {
            tbl_role o_role = obj.tbl_role.Where(x => x.ID == roleModel.Role_ID).FirstOrDefault();
            if (RoleCheck(roleModel.Role) == true && o_role.Name != roleModel.Role)
            {
                ViewData["error"] = "The Role already exists.";
                return View(RolePage(null));
            }
            try
            {
                                
                o_role.Name = roleModel.Role;
                o_role.Status = true;                
                o_role.Updatedby = "Admin";                
                o_role.UpdateTS = DateTime.UtcNow;                
                obj.SaveChanges();

                foreach (var module in roleModel.lst_module)
                {
                    tbl_role_module role_module = obj.tbl_role_module.Where(x => x.Role_ID == roleModel.Role_ID && x.Module_ID == module.id).FirstOrDefault();                        
                    if(role_module == null && module.Value == true)
                    {
                        tbl_role_module new_role = new tbl_role_module();
                        new_role.ID = Guid.NewGuid();
                        new_role.Role_ID = o_role.ID;
                        new_role.Module_ID = module.id;
                        new_role.Status = module.Value;
                        new_role.Createdby = "Admin";
                        new_role.CreateTS = DateTime.UtcNow;
                        new_role.Updatedby = "Admin";
                        new_role.UpdateTS = DateTime.UtcNow;
                        obj.tbl_role_module.Add(new_role);
                    }
                    else if (role_module == null)
                    {
                        continue;
                    }
                    else
                    {
                        if(role_module.Status != module.Value)
                        {
                            role_module.Status = module.Value;
                            role_module.Updatedby = "Admin";
                            role_module.UpdateTS = DateTime.UtcNow;
                        }                                                        
                    }
                    obj.SaveChanges();
                }
                

                return RedirectToAction("Index");
            }
            //catch (DbUpdateException ex)
            //{
            //    SqlException innerException = ex.InnerException.InnerException as SqlException;
            //    if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
            //    {
            //        ViewData["error"] = "Role already exists!";
            //        return View(RolePage(null));
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            catch (Exception ex)
            {
                ViewData["error"] = "An error occured. Please try again!";
                return View(RolePage(null));
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
