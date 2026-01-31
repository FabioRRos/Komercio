using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ProductNotificationSettingsDTO
    {
        public int Id_productNotification { get; set; }
        public string Productname { get; set; }
        public int Productstock { get; set; }
        public bool Notify_enabled { get; set; }
    }
}
