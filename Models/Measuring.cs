using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyUI.Models
{
    public class Measuring
    {
        public int id { get; set; }
        public int parameter_id { get; set; }
        public int meter_id { get; set; }
        public float value { get; set; }
        public DateTime value_dt { get; set; }
    }
}
