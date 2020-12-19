using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class InputParametrsList1
    {
        public CastIronElementsPercent CastIron { get; set; }
        public BlastFurnace BlastFur { get; set; }
        public COCKsParamsPersent CockParam { get; set; }
        public Season season { get; set; }
        public BlastFurnaceGas FurnaceGas { get; set; }
        public BlowingParams blowing { get; set; }
    }

    public class Season
    {
        public float list1_C35_NaturalBlowingConsumption { get; set; } //берется из списка о времени года
    }
    public class CastIronElementsPercent // Состав чугуна и его характеристики
    {
        public float list1_C9_Si { get; set; }
        public float list1_C10_Mn { get; set; }
        public float list1_C11_S { get; set; }
        public float list1_C12_P { get; set; }
        public float list1_C13_Ti { get; set; }
        public float list1_C14_Cr { get; set; }
        public float list1_C15_V { get; set; }
        public float list1_c16_C { get; set; }

        public float list1_C17_CastIronTemperature { get; set; }
        public float list1_C18_CastIronHeatCapacity { get; set; } = 0.9f; // в КИЛОДЖОУЛЯХ!

    }
    public class BlastFurnace // Доменная печь и её характеристики
    {


        public float list1_C20_Dailyproductivity { get; set; } // Продуктивность печи по чугуну т/сут
        public float list1_C21_CockCUMsuption { get; set; } // Удельный расход кокса кг/ т.чугуна
        public float list1_C23_EffectVolume { get; set; } // Полезный объем печи м3
        private float heatlosesvalue;

        public float list1_C24_HeatLoses_ofBlastFurnace // Отработать на фронте
        {
            set
            {
                if (value < 837 || value > 1257)
                {
                    throw new Exception("Invalid Param: Тепловые потери печи");
                }
                else
                    heatlosesvalue = value;
            }
            get { return heatlosesvalue; }
        } // Тепловые потери печи при интерсивности плавки J=1(837-1257) !!!!!!!!!!
    }

    public class COCKsParamsPersent
    {
        public COCKsComposition CocksComposit { get; set; }
        public COCKsAsh CocksAsh { get; set; }

       
        
        public float list1_C29_WaterCOCKs { get; set; } // влага Cock'са
        public float list1_C30_FeoCOCKs { get; set; } // Содержание FeO в золе Cock'са
    }
    public class COCKsComposition
    {
        public float list2_A42_AhsCocks { get; set; }
        public float list2_B42_SulfurCocks { get; set; }
        public float list2_C42_LiquidCocks { get; set; }

        public float list2_D42_Snell
        {
            get { return 100 - (list2_A42_AhsCocks + list2_B42_SulfurCocks + list2_C42_LiquidCocks); }
        }



    }
    public class COCKsAsh
    {
        public float list2_A46_Fe { get; set; }
        public float list2_B46_Cao { get; set; }
        public float list2_C46_Sio2 { get; set; }
        public float list2_D46_Al2O3 { get; set; }
        public float list2_E46_MgO { get; set; }
        public float list2_F46_P { get; set; }
    }
    public class BlowingParams
    {
        public float list1_C32_BlowingConsumptionPerMinute { get; set; } //Минутный расход дутья
        public float list1_C33_HotBlowingTemperature { get; set; }
        public float list1_C34_BlowingMoistureTechReport { get; set; } //Влажность дутья (из техотчета)
        public float list1_C35_NaturalBlowingConsumption { get; set; } //Естественная влажность дутья (зависит от времени года)
        public float list1_C36_BlowingMoistureSumm // ВлажностьДутьясумма
        {
            get { return list1_C35_NaturalBlowingConsumption +list1_C34_BlowingMoistureTechReport; }
        } 

        public float list2_D42_Snell
        {

            get { return list1_C35_NaturalBlowingConsumption + list1_C34_BlowingMoistureTechReport; }
        }

        public float list1_C37_PersentOxygenInBlowing { get; set; } //Содержание кислорода в дутье
        public float list1_C38_SpecificConsuptionNaturalGas { get; set; } //Удельный расход природного газа
        public float list1_C39_CH4Consuption { get; set; } // Состав природного газа %
        public float list1_C40_C2H6Comsuption { get; set; } //Состав природного газа %
        public float list1_C41_C3H8Comsuption { get; set; } //Состав природного газа %
        public float list1_C42_CO2Comsuption { get; set; } //Состав природного газа %
        public float list1_C43_C_Capacity { get; set; } // Содержание в природном газе м3/м3
        public float list1_C44_H2_Capacity { get; set; } //Содержание в природном газе м3/м3


        //------- Известняк -------//
        public float list1_C46_limestoneWaterCapacity { get; set; } //Содержание в природном газе м3/м3
        public float list1_C47_limestoneWeightLoss { get; set; } //Содержание в природном газе м3/м3
                                                                 //------- Известняк конец -------//

    }

    public class Slag
    {
        public float list1_C49_SlagOutput { get; set; }
        public float list1_C50_SulfurCapacity { get; set; }
        public float list1_C51_HeatCapacity { get; set; }

        public float list1_C53_CaO_Capacity { get; set; }
        public float list1_C54_SiO2_Caacity { get; set; }
        public float list1_C55_Al2O3_Capacity { get; set; }
        public float list1_C56_MgO_Capacity { get; set; }
        public float list1_C57_S_Capacity { get; set; }
        public float list1_C58_TiO2_Capacity { get; set; }

        public float list1_C59_CaOSiO2_Capacity => list1_C53_CaO_Capacity / list1_C54_SiO2_Caacity;
    }

    public class BlastFurnaceGas //Koloshnikovyi
    {
        public float list1_C61_GasTemperature { get; set; }
        public float list1_C62_CO2_Capacity { get; set; }
        public float list1_C63_CO_Capacity { get; set; }
        public float list1_C64_H2_Capacity { get; set; }
        private float n2_capacity { get; set; }

        public float list1_C65_N2_Capacity => 100 - (list1_C62_CO2_Capacity + list1_C63_CO_Capacity + list1_C64_H2_Capacity);
        public float list1_C66_DustExit { get; set; }
        public float list1_C67_FeO_Capacity { get; set; }
    }
}
