using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PreOwned268.Models
{
    public class Purchase
    {
        // Foreign key to customer
        
        [ForeignKey("Staff")]
        [DisplayName("Staff Name")]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        // Foreign key to customer
        [ForeignKey("Cust")]
        public int CustID { get; set; }
        public virtual Cust Cust { get; set; }

        // Foreign key to customer
        [ForeignKey("Trans")]
        [DisplayName("Vehicle Name")]
        public int TransId { get; set; }
        public virtual Trans Trans { get; set; }

        public int PurchaseID { get; set; }
        [Required(ErrorMessage = "Enter Manufactured Year.")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [DataType(DataType.Currency)]
        public int? Cost { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public decimal VAT { get; set; }

    }
}