//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rotaract_Admin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public System.Guid ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public string Venue { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime CreateTS { get; set; }
        public System.Guid UpdatedBy { get; set; }
        public System.DateTime UpdateTS { get; set; }
        public string RotaYear { get; set; }
    }
}