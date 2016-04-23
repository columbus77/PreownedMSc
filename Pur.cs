using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PreOwned268.Models
{
    public class Pur
    {
        public int PurID { get; set; }
        public string Date { get; set; }
        public decimal Cost { get; set; }
        public string Quantity { get; set; }
        public decimal VAT { get; set; }
    }
}