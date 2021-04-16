using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class DPInputData
    {
        //[Key]
        public int Id { get; set; }
        public string NAME { get; set; }
        public int UserId { get; set; }

        public int InputIndicatorsId { get; set; }
        //[ForeignKey(nameof(InputIndicatorsId))]
        public InputParametrsList1 InputIndicators { get; set; }


        public int InputData2Id { get; set; }
        //[ForeignKey(nameof(InputData2))]
        public InputParametrsList2 InputData2 { get; set; }
        //public int CastID { get; set; }
        //[ForeignKey(nameof(CastID))]
       
    }
}
