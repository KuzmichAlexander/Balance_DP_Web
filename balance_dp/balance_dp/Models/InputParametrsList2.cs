using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class InputParametrsList2
    {
        public Flus flus { get; set; }
    }

    public class FlusModels
    {
        public float list2_B33flusConsuption { get; set; } //!
        public float list2_C33_CaO_Capacity { get; set; }
        public float list2_D33_SiO2_Capacity { get; set; }
        public float list2_E33_Al2O3_Capacity { get; set; }
        public float list2_F33_MgO_Capacity { get; set; }
        public float list2_G33_TiO2Capacity { get; set; }
        public float list2_H33_MnO_Capacity { get; set; }
        public float list2_I33_P_Capacity { get; set; }
        public float list2_J33_S_Capacity { get; set; }

    }

    public class Flus
    {
        public FlusModels Limestone { get; set; }
        public FlusModels Fluospat { get; set; } //!
        public FlusModels Quartzite { get; set; }
        public FlusModels Slug { get; set; }
    }
}
