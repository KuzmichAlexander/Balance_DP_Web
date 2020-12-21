using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public static class Calculate 
    {
        public static Indicators Calculator(DPInputData did)
        {
            ResultHeat rh = new ResultHeat();

            rh.hb = new HeatBalance();
            rh.mb = new MaterialBalance();



            Indicators indicators = new Indicators();

            indicators.list3_C7_RD_GoglibFourmula = 0.54f - 0.00214f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas;
            indicators.list3_C8_FE_CapacityInCastIron = 100 - did.InputIndicators.CastIron.list1_C9_Si - did.InputIndicators.CastIron.list1_C10_Mn - did.InputIndicators.CastIron.list1_C11_S - did.InputIndicators.CastIron.list1_C12_P - did.InputIndicators.CastIron.list1_C13_Ti - did.InputIndicators.CastIron.list1_C14_Cr - did.InputIndicators.CastIron.list1_C15_V - did.InputIndicators.CastIron.list1_С16_C;
            indicators.list3_C9_Spr_CarbonConsuptionOnFe = indicators.list3_C8_FE_CapacityInCastIron * 10 * indicators.list3_C7_RD_GoglibFourmula * 12 / 56;
            indicators.list3_C10_Sprim_CarbonConsuptionOnElements = 10 * (did.InputIndicators.CastIron.list1_C10_Mn * (12 / 56) + did.InputIndicators.CastIron.list1_C12_P * (60 / 12) + did.InputIndicators.CastIron.list1_C9_Si * (24 / 28) + did.InputIndicators.CastIron.list1_C11_S * (12 / 32) + did.InputIndicators.CastIron.list1_C15_V * (60 / 110) + did.InputIndicators.CastIron.list1_C13_Ti * (12 / 48) + did.InputIndicators.CastIron.list1_C14_Cr * (48 / 104));
            indicators.list3_C11_Snel_UnflightInCocksCount = 100 - (did.InputIndicators.CockParam.CocksComposit.list2_A42_AhsCocks + did.InputIndicators.CockParam.CocksComposit.list2_B42_SulfurCocks + did.InputIndicators.CockParam.CocksComposit.list2_C42_LiquidCocks);
            indicators.list3_C12_Sprish_CarbonInFurnaceWithCocks = 0.01f * did.InputIndicators.BlastFur.list1_C21_CockCUMsuption * indicators.list3_C11_Snel_UnflightInCocksCount;
            indicators.list3_C13_SCH4_CarbonOnMetan = 0.008f * indicators.list3_C12_Sprish_CarbonInFurnaceWithCocks;

            indicators.list3_C14_Sch_CarbonDissolutionInCastIron = 10 * did.InputIndicators.CastIron.list1_С16_C;

            indicators.list3_C15_Sf_CarbonBurnInFurma = indicators.list3_C12_Sprish_CarbonInFurnaceWithCocks - (indicators.list3_C14_Sch_CarbonDissolutionInCastIron + indicators.list3_C9_Spr_CarbonConsuptionOnFe + indicators.list3_C10_Sprim_CarbonConsuptionOnElements + indicators.list3_C13_SCH4_CarbonOnMetan);
            indicators.list3_C16_Vd1_BlastConsuptionFor1Cocks = 0.9333f / ((0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing) + (0.00062f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm));
            indicators.list3_C17_Vd2_BlastConsuptionForGas = 0.5f / (did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + (0.00062f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm));
            indicators.list3_C18_GasConsuptionFor1Cocks = did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / indicators.list3_C15_Sf_CarbonBurnInFurma;
            indicators.list3_C19_BlastConsuptiomSumm = indicators.list3_C16_Vd1_BlastConsuptionFor1Cocks + indicators.list3_C17_Vd2_BlastConsuptionForGas * indicators.list3_C18_GasConsuptionFor1Cocks;
            indicators.list3_C20_Qd_BlastConsuptionCalculate = indicators.list3_C19_BlastConsuptiomSumm * indicators.list3_C15_Sf_CarbonBurnInFurma;
            indicators.list3_C21_O2BlastConsuptionCalculate = indicators.list3_C20_Qd_BlastConsuptionCalculate * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing*0.01f;
            indicators.list3_C22_N2BlastConsuptionCalculate =  (indicators.list3_C20_Qd_BlastConsuptionCalculate *(100 - did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing)*0.01f);
            indicators.list3_C23_BlastConsuptionForMinute = indicators.list3_C20_Qd_BlastConsuptionCalculate* did.InputIndicators.BlastFur.list1_C20_Dailyproductivity/ 1440;
            indicators.list3_C24_Vg1_FurmaGasOutputFor1Cocks =1.8667f+ indicators.list3_C16_Vd1_BlastConsuptionFor1Cocks*(1 - 0.1f* did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + 0.00124f* did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) ;
            indicators.list3_C25_Vg2_FurmaGasOutputForConversion  =  3+ indicators.list3_C17_Vd2_BlastConsuptionForGas* (1- 0.1f* did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing+ 0.00124f *did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) ;
            indicators.list3_C26_Vgg_FurmaGasOutputSumm = indicators.list3_C24_Vg1_FurmaGasOutputFor1Cocks + did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas /( indicators.list3_C15_Sf_CarbonBurnInFurma* indicators.list3_C25_Vg2_FurmaGasOutputForConversion);
            indicators.list3_C27_Qgg_FurmaGasOutput =indicators.list3_C15_Sf_CarbonBurnInFurma * indicators.list3_C26_Vgg_FurmaGasOutputSumm ;
            indicators.list3_C28_Vco_FurmaGasCOCapacity = 1.8667f + did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / (indicators.list3_C15_Sf_CarbonBurnInFurma* did.InputIndicators.blowing.list1_C43_C_Capacity);
            indicators.list3_C29_Vh2_FurmaGasH2Capacity = (0.9333f + 0.5f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / (indicators.list3_C15_Sf_CarbonBurnInFurma * 1)) / ((0.1f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing) + (0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) * (0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm + did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas) / (indicators.list3_C15_Sf_CarbonBurnInFurma * did.InputIndicators.blowing.list1_C44_H2_Capacity));
            rh.hb.C104 = indicators.list3_C22_N2BlastConsuptionCalculate.ToString();
            rh.hb.C66 = indicators.list3_C17_Vd2_BlastConsuptionForGas.ToString();

            return indicators;
        }
    }

    public class Indicators
    {
        public float list3_C7_RD_GoglibFourmula;
        public float list3_C8_FE_CapacityInCastIron;
        public float list3_C9_Spr_CarbonConsuptionOnFe;
        public float list3_C10_Sprim_CarbonConsuptionOnElements;
        public float list3_C11_Snel_UnflightInCocksCount;
        public float list3_C12_Sprish_CarbonInFurnaceWithCocks;
        public float list3_C13_SCH4_CarbonOnMetan;
        public float list3_C14_Sch_CarbonDissolutionInCastIron;
        public float list3_C15_Sf_CarbonBurnInFurma;
        public float list3_C16_Vd1_BlastConsuptionFor1Cocks;
        public float list3_C17_Vd2_BlastConsuptionForGas;
        public float list3_C18_GasConsuptionFor1Cocks;
        public float list3_C19_BlastConsuptiomSumm;

        // ---- Расчет удельного расхода дутья ---- //
        public float list3_C20_Qd_BlastConsuptionCalculate;
        public float list3_C21_O2BlastConsuptionCalculate;
        public float list3_C22_N2BlastConsuptionCalculate;
        public float list3_C23_BlastConsuptionForMinute;
        // ---- Расчет удельного расхода дутья ---- //

        public float list3_C24_Vg1_FurmaGasOutputFor1Cocks;
        public float list3_C25_Vg2_FurmaGasOutputForConversion;
        public float list3_C26_Vgg_FurmaGasOutputSumm;
        public float list3_C27_Qgg_FurmaGasOutput;
        public float list3_C28_Vco_FurmaGasCOCapacity; // м3/кг
        public float list3_C29_Vh2_FurmaGasH2Capacity; // м3/кг
        public float list3_C30_Vn2_FurmaGasN2Capacity; // м3/кг

        // ---- Содержание отдельных составляющих в горновом газе ---- //
        public float list3_C31_CO_FurmaGasCOElementCapacity; // м3/м3
        public float list3_C32_H2_FurmaGasH2ElementCapacity; // м3/м3
        public float list3_C33_N2_FurmaGasN2ElementCapacity; // м3/м3
        // ---- Содержание отдельных составляющих в горновом газе ---- //

        public float list3_C34_Vpv_CO2ForOxids; 
        public float list3_C35_nCO_PowerCoUses; 
        public float list3_C36_nH_PowerHUses; 
        public float list3_C37_Vt1000CO_VolumeCOon1000; 
        public float list3_C38_Vt1000H2_VolumeH2on1000;
        public float list3_C39_Vt1000N2_VolumeN2on1000;
        public float list3_C40_Vgas_VolumeGason1000;
        public float list3_C41_Co_1000_COCapacityOn1000;
        public float list3_C42_h2_1000_H2CapacityOn1000;
        public float list3_C43_N2_1000_N2CapacityOn1000;
        public float list3_C44_ViCO2_VolumeCO2OnLime;
        public float list3_C45_VkvCO2_VolumeCO2OnFe;
        public float list3_C46_VkgCO2_VolumeCO2onBlastFurnaceGas;
        public float list3_C47_VkgCO_VolumeCOonBlastFurnaceGas;
        public float list3_C48_VkgCH4_VolumeCH4onBlastFurnaceGas;
        public float list3_C49_VkgH2_VolumeH2onBlastFurnaceGas;
        public float list3_C50_VkgN2_VolumeN2onBlastFurnaceGas;
        public float list3_C51_Vkg_BlastFurnaceGasOut;


        public float list3_C52_BlastFurnaceGasСomposition_С02;
        public float list3_C53_BlastFurnaceGasСomposition_С02_persent;
        public float list3_C54_BlastFurnaceGasСomposition_С0;
        public float list3_C55_BlastFurnaceGasСomposition_С0_persent;
        public float list3_C56_BlastFurnaceGasСomposition_H2;
        public float list3_C57_BlastFurnaceGasСomposition_H2_persent;
        public float list3_C58_BlastFurnaceGasСomposition_CH4;
        public float list3_C59_BlastFurnaceGasСomposition_CH4_persent;
        public float list3_C60_BlastFurnaceGasСomposition_N2;
        public float list3_C61_BlastFurnaceGasСomposition_N2_persent;

        ////////// ПРИХОДНЫЕ ПАРАМЕТРЫ
        public float C66_HeatOfBurningCocks { get; set; }
        public float C67_HeatOfBurningCocks_persent { get; set; }
        public float C68_02_HeatCapacity { get; set; }
        public float C69_N2_HeatCapacity { get; set; }
        public float C70_H20_HeatCapacity { get; set; }
        public float C71_HeatCountBlowing { get; set; }
        public float C72_HeatCountBlowing_persent { get; set; }
        public float C73_HeatCountOfConversion { get; set; }
        public float C74_HeatCountOfConversion_persent { get; set; }
        public float C75_HeatCountOfSlug { get; set; }
        public float C76_HeatCountOfSlug_persent { get; set; }
        public float C77_InputHeatSumm { get; set; }
        public float C78_InputHeatSumm_persent { get; set; }
        // РАСХОДНЫЕ ПАРАМЕТРЫ СЕРВЕР
        public float С81_HeatLosesOnRegeneratiOnFe;
        public float С82_HeatLosesOnRegeneratiOnFe_persent;
        public float С83_HeatLosesOnRegeneratiOnCastIron;
        public float С84_HeatLosesOnRegeneratiOnCastIron_persent;
        public float С85_HeatLosesOnDeSulfurOnCastIron;
        public float С86_HeatLosesOnDeSulfurOnCastIron_persent;
        public float С87_HeatLosesOnRegeneratiFeOnH;
        public float С88_HeatLosesOnRegeneratiFeOnH_persent;
        public float С89_HeatLosesOnLiquidCastIron;
        public float С90_HeatLosesOnLiquidCastIron_persent;
        public float С91_HeatLosesOnLiquidSlug;
        public float С92_HeatLosesOnLiquidSlug_persent;
        public float С93_HeatLosesOnWaterBlowing;
        public float С94_HeatLosesOnWaterBlowing_persent;
        public float С95_HeatLosesOnLime;
        public float С96_HeatLosesOnLime_persent;
        public float С97_HeatLosesOnWaterShicht;
        public float С98_HeatLosesOnWaterWhicht_persent;
        public float С99_CO_HeatCapacityBlastFurnaceGas;
        public float С100_CO2_HeatCapacityBlastFurnaceGas;
        public float С101_H2_HeatCapacityBlastFurnaceGas;
        public float С102_H20_HeatCapacityBlastFurnaceGas;
        public float С103_N2_HeatCapacityBlastFurnaceGas;
        public float С104_HeatLosesFromBlastFurnaceGas;
        public float С105_HeatLosesFromBlastFurnaceGas_persent;
        public float С106_IntensionOfMeltingOnCocks;
        public float С107_HeatLosesOnFurnaceRamm;
        public float С108_HeatLosesOnFurnaceRamm_persent;
        public float С109_OutputHeatSumm;
        public float С110_OutputHeatSumm_persent;
        public float С112_POGreshnostHeatBalance;
        public float С112_POGreshnostHeatBalance__persent;
        public float С112_HeatBalanceHeatLoses;
        public float С112_HeatBalanceHeatLoses__persent;




    }

    public class HeatBalance
    {
        
        //  --- ПРИХОД ТЕПЛА СТАТЬИ (: клиент :)--- //
        public string C66 { get; set; }
        public string C66_persent { get; set; }
        public string C71 { get; set; }
        public string C71_persent { get; set; }
        public string C73 { get; set; }
        public string C73_persent { get; set; }
        public string Sum { get; set; }
        public string Sum_persent { get; set; }

        //  --- РАСХОД ТЕПЛА СТАТЬИ (: клиент :)--- //
        public string C81 { get; set; }
        public string C81_persent { get; set; }
        public string C83 { get; set; }
        public string C83_persent { get; set; }
        public string C85 { get; set; }
        public string C85_persent { get; set; }
        public string C87 { get; set; }
        public string C87_persent { get; set; }
        public string C89 { get; set; }
        public string C89_persent { get; set; }
        public string C91 { get; set; }
        public string C91_persent { get; set; }
        public string C93 { get; set; }
        public string C93_persent { get; set; }
        public string C95 { get; set; }
        public string C95_persent { get; set; }
        public string C97 { get; set; }
        public string C97_persent { get; set; }
        public string C104 { get; set; }
        public string C104_persent { get; set; }
        public string C107 { get; set; }
        public string C107_persent { get; set; }
        public string C114 { get; set; }
        public string C114_persent { get; set; }
    }
    
    public class ResultHeat
    {
        public MaterialBalance mb { get; set; }
        public HeatBalance hb { get; set; }
    }
}
