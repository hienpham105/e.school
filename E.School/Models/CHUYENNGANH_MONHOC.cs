//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E.School.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHUYENNGANH_MONHOC
    {
        public int MACN { get; set; }
        public int MAMH { get; set; }
        public string TINHTRANGMH { get; set; }
    
        public virtual CHUYENNGANH CHUYENNGANH { get; set; }
        public virtual MONHOC MONHOC { get; set; }
    }
}