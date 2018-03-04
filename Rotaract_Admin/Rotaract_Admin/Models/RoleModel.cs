using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rotaract_Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Rotaract_Admin.Models
{
    public class RoleModel
    {
        public Guid Role_ID { get; set; }
        public string Role { get; set; }
        public List<ModuleModel> lst_module { get; set; }
    }
}