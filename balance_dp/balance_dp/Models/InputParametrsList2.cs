using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class InputParametrsList2
    {
        public int ID { get; set; }
        public int FlusId { get; set; }
        public Flus flus { get; set; }
        public int MaterialConsuptionId { get; set; }
        public MaterialConsuption materialCons { get; set; }
    }

    public class FlusModels
    {
        public int ID { get; set; }
        public float list2_B33flusConsuption { get; set; }
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
        public int ID { get; set; }
        //public int LimestoneId { get; set; }
        public FlusModels Limestone { get; set; }
        //public int FluospatId { get; set; }
        public FlusModels Fluospat { get; set; } //!
        //public int QuartziteId { get; set; }
        public FlusModels Quartzite { get; set; }
        //public int SlugId { get; set; }
        public FlusModels Slug { get; set; }
        //public int ReserveId { get; set; }
        public FlusModels Reserve { get; set; // ДОБАВИЛ РЕЗЕРВНЫЕ ФЛЮСЫ,НЕ ЗАБЫТЬ СКАЗАТЬ САНЕ
        }
    }
    public class MaterialConsuption 
    {
        public int ID { get; set; }
        public float A8_Fe { get; set; }
        public float B8_FeO { get; set; }
        public float C8_Fe2O3 { get; set; }
        public float D8_SiO2 { get; set; }
        public float E8_AlO3 { get; set; }
        public float F8_CaO { get; set; }
        public float G8_MgO{ get; set; }
        public float H8_P{ get; set; }
        public float I8_S { get; set; }
        public float J8_MnO { get; set; }
        public float K8_Zn { get; set; }
        public float L8_Pmpp { get; set; }
        public float M8_H20 { get; set; }
        public float N8_TiO2 { get; set; }
        public float O8_Cr { get; set; }
    }
}
