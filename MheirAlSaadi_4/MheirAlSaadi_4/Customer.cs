//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MheirAlSaadi_4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public short CustNo { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public decimal CreditLimit { get; set; }
        public short AcctRepNo { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}