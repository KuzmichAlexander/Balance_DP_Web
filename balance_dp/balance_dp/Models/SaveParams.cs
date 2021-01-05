using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace balance_dp.Models
{
    public class SaveParams
    {
        public DPInputData dpi { get; set; }
        public string name { get; set; }
    }
}
