using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class DPInputData
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public InputParametrsList1 InputIndicators { get; set; }
       public InputParametrsList2 InputData2 { get; set; }
    }
}
