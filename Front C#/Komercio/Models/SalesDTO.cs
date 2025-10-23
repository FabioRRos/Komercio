using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    internal class SalesDTO
    {
    
        public class SalesDto
        {
            public int SaleId { get; set; } 
            public int CustomerId { get; set; }          
            public float TotalAmount { get; set; }       
            public float DiscountAmount { get; set; }    
            public float FinalAmount { get; set; }       
            public DateTime SaleDate { get; set; }       
            public string PaymentMethod { get; set; }    
            public int SellerId { get; set; }            
            public string SaleNotes { get; set; }        

        }
    }


}
