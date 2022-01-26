using SiparisVeKargoYonetimi.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.Core.Models
{
    public class ArasCargo
    {
        [Key]
        public string ArasCargoNo { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public decimal Price { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public CargoStatus Status { get; set; }

        public Clothing Clothing { get; set; }
    }
}
