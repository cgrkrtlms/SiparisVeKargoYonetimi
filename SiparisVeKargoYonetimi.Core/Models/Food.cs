using SiparisVeKargoYonetimi.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.Core.Models
{
    public class Food
    {
        [Key]
        public string ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Barcode { get; set; }
        public bool InStock { get; set; }
        public CargoStatus Status { get; set; }



        [ForeignKey("YurticiCargo")]
        public string YurticiCargoNo { get; set; }
        public YurticiCargo YurticiCargo { get; set; }
    }
}
