using SiparisVeKargoYonetimi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.Core.Dtos
{
    public class FoodDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool InStock { get; set; }
        public CargoStatus Status { get; set; }
    }
}
