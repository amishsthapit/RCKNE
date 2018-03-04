using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rotaract_Admin.Models
{
    public class ModuleModel
    {
        public Guid id { get; set; }
        public string Module { get; set; }
        public bool Value { get; set; }

        public static explicit operator ModuleModel(List<char> v)
        {
            throw new NotImplementedException();
        }
    }
}