//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCarsSold
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCarsSold()
        {
            this.tblCarLoans = new HashSet<tblCarLoan>();
            this.tblCustomerPayments = new HashSet<tblCustomerPayment>();
        }
    
        public int CarSold_ID { get; set; }
        public Nullable<int> Car_ID { get; set; }
        public Nullable<int> Customer_ID { get; set; }
        public decimal AgreedPrice { get; set; }
        public System.DateTime DateSold { get; set; }
        public Nullable<decimal> MonthlyPaymentAmount { get; set; }
        public Nullable<int> MonthlyPaymentDate { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
    
        public virtual tblCar tblCar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCarLoan> tblCarLoans { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual tblSupplier tblSupplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerPayment> tblCustomerPayments { get; set; }
    }
}
