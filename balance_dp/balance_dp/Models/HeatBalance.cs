using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public static class Calculate
    {
        public static ResultHeat Calculator(DPInputData did)
        {
            ResultHeat rh = new ResultHeat();
            rh.hb = new HeatBalance();
            rh.mb = new MaterialBalance();
            Indicators indicators = new Indicators();
            // ----------- ТЕПЛОВОЙ БАЛАНС ПОШЕЛ ----------- //
            // -------- ПРИХОД ТЕПЛОВОГО -------- //
            indicators.list3_C7_RD_GoglibFourmula = 0.54f - 0.00214f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas;
            indicators.list3_C8_FE_CapacityInCastIron = 100 - did.InputIndicators.CastIron.list1_C9_Si - did.InputIndicators.CastIron.list1_C10_Mn - did.InputIndicators.CastIron.list1_C11_S - did.InputIndicators.CastIron.list1_C12_P - did.InputIndicators.CastIron.list1_C13_Ti - did.InputIndicators.CastIron.list1_C14_Cr - did.InputIndicators.CastIron.list1_C15_V - did.InputIndicators.CastIron.list1_С16_C;
            indicators.list3_C9_Spr_CarbonConsuptionOnFe = indicators.list3_C8_FE_CapacityInCastIron * 10 * indicators.list3_C7_RD_GoglibFourmula * 12 / 56;
            indicators.list3_C10_Sprim_CarbonConsuptionOnElements = 10 * (did.InputIndicators.CastIron.list1_C10_Mn * (12f / 55f) + did.InputIndicators.CastIron.list1_C12_P * (60f / 62f) + did.InputIndicators.CastIron.list1_C9_Si * (24f / 28f) + did.InputIndicators.CastIron.list1_C11_S * (12f / 32f) + did.InputIndicators.CastIron.list1_C15_V * (60f / 110f) + did.InputIndicators.CastIron.list1_C13_Ti * (12f / 48f) + did.InputIndicators.CastIron.list1_C14_Cr * (48f / 104f));
            indicators.list3_C11_Snel_UnflightInCocksCount = 100 - (did.InputIndicators.CockParam.CocksComposit.list2_A42_AhsCocks + did.InputIndicators.CockParam.CocksComposit.list2_B42_SulfurCocks + did.InputIndicators.CockParam.CocksComposit.list2_C42_LiquidCocks);
            indicators.list3_C12_Sprish_CarbonInFurnaceWithCocks = 0.01f * did.InputIndicators.BlastFur.list1_C21_CockCUMsuption * indicators.list3_C11_Snel_UnflightInCocksCount;
            indicators.list3_C13_SCH4_CarbonOnMetan = 0.008f * indicators.list3_C12_Sprish_CarbonInFurnaceWithCocks;
            indicators.list3_C14_Sch_CarbonDissolutionInCastIron = 10 * did.InputIndicators.CastIron.list1_С16_C;
            //Да прибудет с тобой сила
            // Да пускай боги смилосердятся. о великий рандо.
            indicators.list3_C15_Sf_CarbonBurnInFurma = indicators.list3_C12_Sprish_CarbonInFurnaceWithCocks - (indicators.list3_C14_Sch_CarbonDissolutionInCastIron + indicators.list3_C9_Spr_CarbonConsuptionOnFe + indicators.list3_C10_Sprim_CarbonConsuptionOnElements + indicators.list3_C13_SCH4_CarbonOnMetan);
            indicators.list3_C16_Vd1_BlastConsuptionFor1Cocks = 0.9333f / ((0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing) + (0.00062f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm));
            indicators.list3_C17_Vd2_BlastConsuptionForGas = 0.5f / (0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + (0.00062f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm));
            indicators.list3_C18_GasConsuptionFor1Cocks = did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / indicators.list3_C15_Sf_CarbonBurnInFurma;
            indicators.list3_C19_BlastConsuptiomSumm = indicators.list3_C16_Vd1_BlastConsuptionFor1Cocks + indicators.list3_C17_Vd2_BlastConsuptionForGas * indicators.list3_C18_GasConsuptionFor1Cocks;
            indicators.list3_C20_Qd_BlastConsuptionCalculate = indicators.list3_C19_BlastConsuptiomSumm * indicators.list3_C15_Sf_CarbonBurnInFurma;
            indicators.list3_C21_O2BlastConsuptionCalculate = indicators.list3_C20_Qd_BlastConsuptionCalculate * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing * 0.01f;
            indicators.list3_C22_N2BlastConsuptionCalculate = (indicators.list3_C20_Qd_BlastConsuptionCalculate * (100 - did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing) * 0.01f);
            indicators.list3_C23_BlastConsuptionForMinute = indicators.list3_C20_Qd_BlastConsuptionCalculate * did.InputIndicators.BlastFur.list1_C20_Dailyproductivity / 1440;
            indicators.list3_C24_Vg1_FurmaGasOutputFor1Cocks = 1.8667f + indicators.list3_C16_Vd1_BlastConsuptionFor1Cocks * (1 - 0.1f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm);
            indicators.list3_C25_Vg2_FurmaGasOutputForConversion = 3 + indicators.list3_C17_Vd2_BlastConsuptionForGas * (1 - 0.1f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm);
            indicators.list3_C26_Vgg_FurmaGasOutputSumm = indicators.list3_C24_Vg1_FurmaGasOutputFor1Cocks + did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / (indicators.list3_C15_Sf_CarbonBurnInFurma * indicators.list3_C25_Vg2_FurmaGasOutputForConversion);
            indicators.list3_C27_Qgg_FurmaGasOutput = indicators.list3_C15_Sf_CarbonBurnInFurma * indicators.list3_C26_Vgg_FurmaGasOutputSumm;
            indicators.list3_C28_Vco_FurmaGasCOCapacity = 1.8667f + did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / (indicators.list3_C15_Sf_CarbonBurnInFurma * did.InputIndicators.blowing.list1_C43_C_Capacity);
            indicators.list3_C29_Vh2_FurmaGasH2Capacity = (0.9333f + 0.5f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / indicators.list3_C15_Sf_CarbonBurnInFurma) / (0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) * 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm + did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / indicators.list3_C15_Sf_CarbonBurnInFurma * did.InputIndicators.blowing.list1_C44_H2_Capacity;
            indicators.list3_C30_Vn2_FurmaGasN2Capacity = (0.9333f + 0.5f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas / indicators.list3_C15_Sf_CarbonBurnInFurma * 1) / (0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing + 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) * (1 - 0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing);
            indicators.list3_C31_CO_FurmaGasCOElementCapacity = indicators.list3_C28_Vco_FurmaGasCOCapacity / (indicators.list3_C28_Vco_FurmaGasCOCapacity + indicators.list3_C29_Vh2_FurmaGasH2Capacity + indicators.list3_C30_Vn2_FurmaGasN2Capacity);
            indicators.list3_C32_H2_FurmaGasH2ElementCapacity = indicators.list3_C29_Vh2_FurmaGasH2Capacity / (indicators.list3_C28_Vco_FurmaGasCOCapacity + indicators.list3_C29_Vh2_FurmaGasH2Capacity + indicators.list3_C30_Vn2_FurmaGasN2Capacity); ;
            indicators.list3_C33_N2_FurmaGasN2ElementCapacity = 1 - (indicators.list3_C31_CO_FurmaGasCOElementCapacity + indicators.list3_C32_H2_FurmaGasH2ElementCapacity);
            indicators.list3_C34_Vpv_CO2ForOxids = 10 * 22.4f * (indicators.list3_C8_FE_CapacityInCastIron * (indicators.list3_C7_RD_GoglibFourmula / 56) + (did.InputIndicators.CastIron.list1_C10_Mn / 55) + 2 * (did.InputIndicators.CastIron.list1_C9_Si / 28) + (did.InputIndicators.slag.list1_C50_SulfurCapacity / 32));
            indicators.list3_C35_nCO_PowerCoUses = did.InputIndicators.FurnaceGas.list1_C62_CO2_Capacity / (did.InputIndicators.FurnaceGas.list1_C62_CO2_Capacity + did.InputIndicators.FurnaceGas.list1_C63_CO_Capacity);
            indicators.list3_C36_nH_PowerHUses = 0.88f * indicators.list3_C35_nCO_PowerCoUses + 0.1f;
            indicators.list3_C37_Vt1000CO_VolumeCOon1000 = indicators.list3_C28_Vco_FurmaGasCOCapacity * indicators.list3_C15_Sf_CarbonBurnInFurma + indicators.list3_C34_Vpv_CO2ForOxids;
            indicators.list3_C38_Vt1000H2_VolumeH2on1000 = indicators.list3_C29_Vh2_FurmaGasH2Capacity * indicators.list3_C15_Sf_CarbonBurnInFurma * (1 - indicators.list3_C36_nH_PowerHUses);
            indicators.list3_C39_Vt1000N2_VolumeN2on1000 = indicators.list3_C30_Vn2_FurmaGasN2Capacity * indicators.list3_C15_Sf_CarbonBurnInFurma;
            indicators.list3_C40_Vgas_VolumeGason1000 = indicators.list3_C37_Vt1000CO_VolumeCOon1000 + indicators.list3_C38_Vt1000H2_VolumeH2on1000 + indicators.list3_C39_Vt1000N2_VolumeN2on1000;
            indicators.list3_C41_Co_1000_COCapacityOn1000 = indicators.list3_C37_Vt1000CO_VolumeCOon1000 / indicators.list3_C40_Vgas_VolumeGason1000;
            indicators.list3_C42_h2_1000_H2CapacityOn1000 = indicators.list3_C38_Vt1000H2_VolumeH2on1000 / indicators.list3_C40_Vgas_VolumeGason1000;
            indicators.list3_C43_N2_1000_N2CapacityOn1000 = indicators.list3_C39_Vt1000N2_VolumeN2on1000 / indicators.list3_C40_Vgas_VolumeGason1000;
            indicators.list3_C44_ViCO2_VolumeCO2OnLime = 0.01f * did.InputData2.flus.Limestone.list2_B33flusConsuption * (22.4f / 44) * did.InputIndicators.blowing.list1_C47_limestoneWeightLoss;
            indicators.list3_C45_VkvCO2_VolumeCO2OnFe = indicators.list3_C37_Vt1000CO_VolumeCOon1000 * indicators.list3_C35_nCO_PowerCoUses;
            indicators.list3_C46_VkgCO2_VolumeCO2onBlastFurnaceGas = indicators.list3_C45_VkvCO2_VolumeCO2OnFe + indicators.list3_C44_ViCO2_VolumeCO2OnLime;
            indicators.list3_C47_VkgCO_VolumeCOonBlastFurnaceGas = indicators.list3_C37_Vt1000CO_VolumeCOon1000 - indicators.list3_C45_VkvCO2_VolumeCO2OnFe;
            indicators.list3_C48_VkgCH4_VolumeCH4onBlastFurnaceGas = indicators.list3_C13_SCH4_CarbonOnMetan * (22.4f / 12);
            indicators.list3_C49_VkgH2_VolumeH2onBlastFurnaceGas = indicators.list3_C39_Vt1000N2_VolumeN2on1000;
            indicators.list3_C50_VkgN2_VolumeN2onBlastFurnaceGas = indicators.list3_C38_Vt1000H2_VolumeH2on1000;
            indicators.list3_C51_Vkg_BlastFurnaceGasOut = indicators.list3_C46_VkgCO2_VolumeCO2onBlastFurnaceGas + indicators.list3_C47_VkgCO_VolumeCOonBlastFurnaceGas + indicators.list3_C48_VkgCH4_VolumeCH4onBlastFurnaceGas + indicators.list3_C49_VkgH2_VolumeH2onBlastFurnaceGas + indicators.list3_C50_VkgN2_VolumeN2onBlastFurnaceGas;
            indicators.list3_C52_BlastFurnaceGasСomposition_С02 = indicators.list3_C46_VkgCO2_VolumeCO2onBlastFurnaceGas / indicators.list3_C51_Vkg_BlastFurnaceGasOut;
            indicators.list3_C53_BlastFurnaceGasСomposition_С02_persent = indicators.list3_C52_BlastFurnaceGasСomposition_С02 * 100;
            indicators.list3_C54_BlastFurnaceGasСomposition_С0 = indicators.list3_C47_VkgCO_VolumeCOonBlastFurnaceGas / indicators.list3_C51_Vkg_BlastFurnaceGasOut;
            indicators.list3_C55_BlastFurnaceGasСomposition_С0_persent = indicators.list3_C54_BlastFurnaceGasСomposition_С0 * 100;
            indicators.list3_C56_BlastFurnaceGasСomposition_H2 = indicators.list3_C50_VkgN2_VolumeN2onBlastFurnaceGas / indicators.list3_C51_Vkg_BlastFurnaceGasOut;
            indicators.list3_C57_BlastFurnaceGasСomposition_H2_persent = indicators.list3_C56_BlastFurnaceGasСomposition_H2 * 100;
            indicators.list3_C58_BlastFurnaceGasСomposition_CH4 = indicators.list3_C48_VkgCH4_VolumeCH4onBlastFurnaceGas / indicators.list3_C51_Vkg_BlastFurnaceGasOut;
            indicators.list3_C59_BlastFurnaceGasСomposition_CH4_persent = indicators.list3_C58_BlastFurnaceGasСomposition_CH4 * 100;
            indicators.list3_C60_BlastFurnaceGasСomposition_N2 = 1 - (indicators.list3_C52_BlastFurnaceGasСomposition_С02 + indicators.list3_C54_BlastFurnaceGasСomposition_С0 + indicators.list3_C56_BlastFurnaceGasСomposition_H2 + indicators.list3_C58_BlastFurnaceGasСomposition_CH4);
            indicators.list3_C61_BlastFurnaceGasСomposition_N2_persent = indicators.list3_C60_BlastFurnaceGasСomposition_N2 * 100;
            indicators.list3_C62_BlastFurnaceGasDencity = (44 / 22.4f * indicators.list3_C52_BlastFurnaceGasСomposition_С02) + (28 / 22.4f * indicators.list3_C54_BlastFurnaceGasСomposition_С0) + (2 / 22.4f * indicators.list3_C58_BlastFurnaceGasСomposition_CH4) + (28 / 22.4f * indicators.list3_C60_BlastFurnaceGasСomposition_N2);
            indicators.list3_C63_BlastFurnaceGasForSeconds = (indicators.list3_C51_Vkg_BlastFurnaceGasOut * did.InputIndicators.BlastFur.list1_C20_Dailyproductivity) / (24 * 60 * 60);
            indicators.C66_HeatOfBurningCocks = indicators.list3_C15_Sf_CarbonBurnInFurma * 9800 * 0.001f;
            indicators.C68_02_HeatCapacity = 1.2897f + 0.000121f * did.InputIndicators.blowing.list1_C33_HotBlowingTemperature;
            indicators.C69_N2_HeatCapacity = 1.2897f + 0.000121f * did.InputIndicators.blowing.list1_C33_HotBlowingTemperature;
            indicators.C70_H20_HeatCapacity = 1.456f + 0.000282f * did.InputIndicators.blowing.list1_C33_HotBlowingTemperature;
            indicators.C71_HeatCountBlowing = 0.001f * indicators.list3_C20_Qd_BlastConsuptionCalculate * ((0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing * indicators.C68_02_HeatCapacity + (1 - 0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing) * indicators.C69_N2_HeatCapacity) * (1 - 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) + 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm * indicators.C70_H20_HeatCapacity) * did.InputIndicators.blowing.list1_C33_HotBlowingTemperature;
            indicators.C73_HeatCountOfConversion = 0.001f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas * (0.01f * (1657f * did.InputIndicators.blowing.list1_C39_CH4Consuption + 6046 * did.InputIndicators.blowing.list1_C40_C2H6Comsuption - 12644 * did.InputIndicators.blowing.list1_C42_CO2Comsuption));
            indicators.C75_HeatCountOfSlug = 1128 * 0.00001f * did.InputData2.flus.Limestone.list2_B33flusConsuption * did.InputIndicators.blowing.list1_C47_limestoneWeightLoss;
            indicators.C77_InputHeatSumm = indicators.C66_HeatOfBurningCocks + indicators.C71_HeatCountBlowing + indicators.C73_HeatCountOfConversion + indicators.C75_HeatCountOfSlug;
            indicators.C67_HeatOfBurningCocks_persent = indicators.C66_HeatOfBurningCocks / indicators.C77_InputHeatSumm;
            indicators.C72_HeatCountBlowing_persent = indicators.C71_HeatCountBlowing / indicators.C77_InputHeatSumm;
            indicators.C74_HeatCountOfConversion_persent = indicators.C73_HeatCountOfConversion / indicators.C77_InputHeatSumm;
            indicators.C76_HeatCountOfSlug_persent = indicators.C75_HeatCountOfSlug / indicators.C77_InputHeatSumm;
            indicators.C78_InputHeatSumm_persent = indicators.C67_HeatOfBurningCocks_persent + indicators.C72_HeatCountBlowing_persent + indicators.C74_HeatCountOfConversion_persent + indicators.C76_HeatCountOfSlug_persent;


            ///------- ЖРМ ПОШЛИ СЧИТАТЬ ----- ///
            indicators.B27_SUMMZHRM_Simple = (did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption + did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption + did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption + did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption + did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption + did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption + did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption + did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption + did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption + did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption);
            indicators.B28_MetalAdd_Simple = (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption + did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption + did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption + did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption + did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption);
            indicators.B29_SUMM_Ruda_Simple = (indicators.B27_SUMMZHRM_Simple + indicators.B28_MetalAdd_Simple);

            indicators.C27_SUMMZHRM_Fe = (did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple * did.InputData2.InputZRHMs.A9_Aglomerat2.C9_FE + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.C9_FE + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.C9_FE + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.C9_FE + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.C9_FE + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.C9_FE + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.C9_FE + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.C9_FE + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.C9_FE + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.C9_FE);
            indicators.C28_MetalAdd_Fe = (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple * did.InputData2.InputZRHMs.A19_Welding_slag.C9_FE + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A20_Korolek.C9_FE + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.C9_FE + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.C9_FE + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.C9_FE);
            indicators.C29_SUMM_Ruda_Fe = (did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple * did.InputData2.InputZRHMs.A9_Aglomerat2.C9_FE + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.C9_FE + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.C9_FE + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.C9_FE + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.C9_FE + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.C9_FE + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.C9_FE + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.C9_FE + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.C9_FE + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.C9_FE + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple * did.InputData2.InputZRHMs.A19_Welding_slag.C9_FE + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.C9_FE + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.C9_FE + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.C9_FE + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.C9_FE));

            indicators.D27_SUMMZHRM_FeO = (did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple * did.InputData2.InputZRHMs.A9_Aglomerat2.D9_Fe0 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.D9_Fe0 + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.D9_Fe0 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.D9_Fe0 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.D9_Fe0 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.D9_Fe0 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.D9_Fe0 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.D9_Fe0 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.D9_Fe0 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B27_SUMMZHRM_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.D9_Fe0);
            indicators.D28_MetalAdd_FeO = (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple * did.InputData2.InputZRHMs.A19_Welding_slag.D9_Fe0 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A20_Korolek.D9_Fe0 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.D9_Fe0 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.D9_Fe0 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B28_MetalAdd_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.D9_Fe0);
            indicators.D29_SUMM_Ruda_FeO = (did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple * did.InputData2.InputZRHMs.A9_Aglomerat2.D9_Fe0 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.D9_Fe0 + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.D9_Fe0 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.D9_Fe0 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.D9_Fe0 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.D9_Fe0 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.D9_Fe0 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.D9_Fe0 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.D9_Fe0 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.D9_Fe0 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple * did.InputData2.InputZRHMs.A19_Welding_slag.D9_Fe0 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.D9_Fe0 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.D9_Fe0 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.D9_Fe0 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.D9_Fe0));

            indicators.S9_basicity = did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption * did.InputData2.InputZRHMs.A9_Aglomerat2.C9_FE;
            indicators.S10_basicity = did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption * did.InputData2.InputZRHMs.A10_Aglomerat3.C9_FE;
            indicators.S11_basicity = did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption * did.InputData2.InputZRHMs.A11_Aglomerat4.C9_FE;
            indicators.S12_basicity = did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption * did.InputData2.InputZRHMs.A12_Aglomerat5.C9_FE;
            indicators.S13_basicity = did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.C9_FE;
            indicators.S14_basicity = did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption * did.InputData2.InputZRHMs.A14_AglomeratYama.C9_FE;
            indicators.S15_basicity = did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption * did.InputData2.InputZRHMs.A12_Aglomerat5.C9_FE;
            indicators.S16_basicity = did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption * did.InputData2.InputZRHMs.A16_Okat_Lebed.C9_FE;
            indicators.S17_basicity = did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption * did.InputData2.InputZRHMs.A17_Okat_Kachkan.C9_FE;
            indicators.S18_basicity = did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption * did.InputData2.InputZRHMs.A18_Okat_Mikhay.C9_FE;
            indicators.S19_basicity = did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption * did.InputData2.InputZRHMs.A19_Welding_slag.C9_FE;
            indicators.S20_basicity = did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption * did.InputData2.InputZRHMs.A20_Korolek.C9_FE;
            indicators.S21_basicity = did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption * did.InputData2.InputZRHMs.A21_Domen_prisad.C9_FE;
            indicators.S22_basicity = did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.C9_FE;
            indicators.S23_basicity = did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.C9_FE;
            indicators.basicity_summ = (indicators.S9_basicity + indicators.S10_basicity + indicators.S11_basicity + indicators.S12_basicity + indicators.S13_basicity + indicators.S14_basicity + indicators.S15_basicity + indicators.S16_basicity + indicators.S17_basicity + indicators.S18_basicity + indicators.S19_basicity + indicators.S20_basicity + indicators.S21_basicity + indicators.S22_basicity + indicators.S23_basicity) / indicators.B29_SUMM_Ruda_Simple;




            // --- ВЫВОД ПРИХОДА ТЕПЛОВОГО ---- ///
            rh.hb.HeatOfBurningCocks = ResultToString(indicators.C66_HeatOfBurningCocks);
            rh.hb.HeatCountBlowin = ResultToString(indicators.C71_HeatCountBlowing);
            rh.hb.HeatCountOfConversion = ResultToString(indicators.C73_HeatCountOfConversion);
            rh.hb.HeatOfBurningCocks_persent = PersentToString(indicators.C67_HeatOfBurningCocks_persent);
            rh.hb.HeatCountBlowing_persent = PersentToString(indicators.C72_HeatCountBlowing_persent);
            rh.hb.HeatCountOfConversion_persent = PersentToString(indicators.C74_HeatCountOfConversion_persent);
            rh.hb.Sum = ResultToString(indicators.C66_HeatOfBurningCocks + indicators.C71_HeatCountBlowing + indicators.C73_HeatCountOfConversion);
            rh.hb.Sum_persent = PersentToString(indicators.C67_HeatOfBurningCocks_persent + indicators.C72_HeatCountBlowing_persent + indicators.C74_HeatCountOfConversion_persent);
            // --- РАСХОД ТЕПЛОВОГО ---- ////
            indicators.С81_HeatLosesOnRegeneratiOnFe = 0.01f * indicators.list3_C8_FE_CapacityInCastIron * indicators.list3_C7_RD_GoglibFourmula * 2716;
            indicators.С83_HeatLosesOnRegeneratiOnCastIron = 0.01f * (5220 * did.InputIndicators.CastIron.list1_C10_Mn + 22600 * did.InputIndicators.CastIron.list1_C9_Si + 15490 * did.InputIndicators.CastIron.list1_C12_P + 36167 * did.InputIndicators.CastIron.list1_C13_Ti + 7982 * did.InputIndicators.CastIron.list1_C15_V);
            indicators.С85_HeatLosesOnDeSulfurOnCastIron = 1734 * 0.00001f * did.InputIndicators.slag.list1_C49_SlagOutput * did.InputIndicators.slag.list1_C50_SulfurCapacity;
            indicators.С87_HeatLosesOnRegeneratiFeOnH = 1731 * 0.001f * (0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm * indicators.list3_C20_Qd_BlastConsuptionCalculate + 0.01f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas * (2 * did.InputIndicators.blowing.list1_C39_CH4Consuption + 3 * did.InputIndicators.blowing.list1_C40_C2H6Comsuption)) * indicators.list3_C36_nH_PowerHUses;
            indicators.С89_HeatLosesOnLiquidCastIron = 1 * did.InputIndicators.CastIron.list1_C18_CastIronHeatCapacity * did.InputIndicators.CastIron.list1_C17_CastIronTemperature;
            indicators.С91_HeatLosesOnLiquidSlug = 0.001f * did.InputIndicators.slag.list1_C49_SlagOutput * did.InputIndicators.slag.list1_C51_HeatCapacity * (did.InputIndicators.CastIron.list1_C17_CastIronTemperature + 50);
            indicators.С93_HeatLosesOnWaterBlowing = 1.24f * 0.000001f * indicators.list3_C20_Qd_BlastConsuptionCalculate * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm * 6912;
            indicators.С95_HeatLosesOnLime = 4042 * 0.000001f * did.InputData2.flus.Limestone.list2_B33flusConsuption * did.InputIndicators.blowing.list1_C47_limestoneWeightLoss;
            indicators.С97_HeatLosesOnWaterShicht = 2452 * 0.00001f * (indicators.B27_SUMMZHRM_Simple * did.InputIndicators.zhrm.c72_waterCapacity + did.InputData2.flus.Limestone.list2_B33flusConsuption * did.InputIndicators.blowing.list1_C46_limestoneWaterCapacity + did.InputIndicators.BlastFur.list1_C21_CockCUMsuption * did.InputIndicators.CockParam.list1_C29_WaterCOCKs);
            indicators.С99_CO_HeatCapacityBlastFurnaceGas = 1.2938f + 0.0000895f * did.InputIndicators.FurnaceGas.list1_C61_GasTemperature;
            indicators.С100_CO2_HeatCapacityBlastFurnaceGas = 1.6448f + 0.0007065f * did.InputIndicators.FurnaceGas.list1_C61_GasTemperature;
            indicators.С101_H2_HeatCapacityBlastFurnaceGas = 1.3012f;
            indicators.С102_H20_HeatCapacityBlastFurnaceGas = 1.4743f + 0.0002205f * did.InputIndicators.FurnaceGas.list1_C61_GasTemperature;
            indicators.С103_N2_HeatCapacityBlastFurnaceGas = 1.308f;
            indicators.С104_HeatLosesFromBlastFurnaceGas = 0.00001f * ((did.InputIndicators.FurnaceGas.list1_C62_CO2_Capacity * indicators.С100_CO2_HeatCapacityBlastFurnaceGas + did.InputIndicators.FurnaceGas.list1_C63_CO_Capacity * indicators.С99_CO_HeatCapacityBlastFurnaceGas + did.InputIndicators.FurnaceGas.list1_C65_N2_Capacity * indicators.С103_N2_HeatCapacityBlastFurnaceGas + did.InputIndicators.FurnaceGas.list1_C64_H2_Capacity * indicators.С101_H2_HeatCapacityBlastFurnaceGas) * indicators.list3_C51_Vkg_BlastFurnaceGasOut + (indicators.B27_SUMMZHRM_Simple * did.InputIndicators.zhrm.c72_waterCapacity + did.InputData2.flus.Limestone.list2_B33flusConsuption * did.InputIndicators.blowing.list1_C46_limestoneWaterCapacity + did.InputIndicators.BlastFur.list1_C21_CockCUMsuption * did.InputIndicators.CockParam.list1_C29_WaterCOCKs + indicators.list3_C51_Vkg_BlastFurnaceGasOut * did.InputIndicators.FurnaceGas.list1_C64_H2_Capacity * indicators.list3_C36_nH_PowerHUses / (1 - indicators.list3_C36_nH_PowerHUses)) * indicators.С102_H20_HeatCapacityBlastFurnaceGas) * did.InputIndicators.FurnaceGas.list1_C61_GasTemperature;
            indicators.С106_IntensionOfMeltingOnCocks = (did.InputIndicators.BlastFur.list1_C20_Dailyproductivity * did.InputIndicators.BlastFur.list1_C21_CockCUMsuption * 0.001f) / did.InputIndicators.BlastFur.list1_C23_EffectVolume;
            indicators.С107_HeatLosesOnFurnaceRamm = ((did.InputIndicators.BlastFur.list1_C24_HeatLoses_ofBlastFurnace / indicators.С106_IntensionOfMeltingOnCocks) * did.InputIndicators.CockParam.CocksComposit.list2_D42_Snell) / 100;
            indicators.С82_HeatLosesOnRegeneratiOnFe_persent = indicators.С81_HeatLosesOnRegeneratiOnFe / indicators.C77_InputHeatSumm;
            indicators.С84_HeatLosesOnRegeneratiOnCastIron_persent = indicators.С83_HeatLosesOnRegeneratiOnCastIron / indicators.C77_InputHeatSumm;
            indicators.С86_HeatLosesOnDeSulfurOnCastIron_persent = indicators.С85_HeatLosesOnDeSulfurOnCastIron / indicators.C77_InputHeatSumm;
            indicators.С88_HeatLosesOnRegeneratiFeOnH_persent = indicators.С87_HeatLosesOnRegeneratiFeOnH / indicators.C77_InputHeatSumm;
            indicators.С90_HeatLosesOnLiquidCastIron_persent = indicators.С89_HeatLosesOnLiquidCastIron / indicators.C77_InputHeatSumm;
            indicators.С92_HeatLosesOnLiquidSlug_persent = indicators.С91_HeatLosesOnLiquidSlug / indicators.C77_InputHeatSumm;
            indicators.С94_HeatLosesOnWaterBlowing_persent = indicators.С93_HeatLosesOnWaterBlowing / indicators.C77_InputHeatSumm;
            indicators.С96_HeatLosesOnLime_persent = indicators.С95_HeatLosesOnLime / indicators.C77_InputHeatSumm;
            indicators.С98_HeatLosesOnWaterWhicht_persent = indicators.С97_HeatLosesOnWaterShicht / indicators.C77_InputHeatSumm;
            indicators.С105_HeatLosesFromBlastFurnaceGas_persent = indicators.С104_HeatLosesFromBlastFurnaceGas / indicators.C77_InputHeatSumm;
            indicators.С108_HeatLosesOnFurnaceRamm_persent = indicators.С107_HeatLosesOnFurnaceRamm / indicators.C77_InputHeatSumm;
            indicators.С109_OutputHeatSumm = indicators.С81_HeatLosesOnRegeneratiOnFe + indicators.С83_HeatLosesOnRegeneratiOnCastIron + indicators.С85_HeatLosesOnDeSulfurOnCastIron + indicators.С87_HeatLosesOnRegeneratiFeOnH + indicators.С89_HeatLosesOnLiquidCastIron + indicators.С91_HeatLosesOnLiquidSlug + indicators.С93_HeatLosesOnWaterBlowing + indicators.С95_HeatLosesOnLime + indicators.С97_HeatLosesOnWaterShicht + indicators.С104_HeatLosesFromBlastFurnaceGas + indicators.С107_HeatLosesOnFurnaceRamm;
            indicators.С110_OutputHeatSumm_persent = indicators.С82_HeatLosesOnRegeneratiOnFe_persent + indicators.С84_HeatLosesOnRegeneratiOnCastIron_persent + indicators.С86_HeatLosesOnDeSulfurOnCastIron_persent + indicators.С88_HeatLosesOnRegeneratiFeOnH_persent + indicators.С90_HeatLosesOnLiquidCastIron_persent + indicators.С92_HeatLosesOnLiquidSlug_persent + indicators.С94_HeatLosesOnWaterBlowing_persent + indicators.С96_HeatLosesOnLime_persent + indicators.С98_HeatLosesOnWaterWhicht_persent + indicators.С105_HeatLosesFromBlastFurnaceGas_persent + indicators.С108_HeatLosesOnFurnaceRamm_persent;
            indicators.С112_POGreshnostHeatBalance = indicators.C77_InputHeatSumm - indicators.С109_OutputHeatSumm;
            indicators.С112_POGreshnostHeatBalance__persent = indicators.С112_POGreshnostHeatBalance / indicators.C77_InputHeatSumm;
            indicators.С112_HeatBalanceHeatLoses = indicators.С107_HeatLosesOnFurnaceRamm + indicators.С112_POGreshnostHeatBalance;
            indicators.С112_HeatBalanceHeatLoses__persent = indicators.С112_HeatBalanceHeatLoses / indicators.C77_InputHeatSumm;
            // ----------- ВЫВОД РАСХОДА ТЕПЛОВОГО ----------- //
            rh.hb.C81 = ResultToString(indicators.С81_HeatLosesOnRegeneratiOnFe);
            rh.hb.C81_persent = PersentToString(indicators.С82_HeatLosesOnRegeneratiOnFe_persent);
            rh.hb.C83 = ResultToString(indicators.С83_HeatLosesOnRegeneratiOnCastIron);
            rh.hb.C83_persent = PersentToString(indicators.С84_HeatLosesOnRegeneratiOnCastIron_persent);
            rh.hb.C85 = ResultToString(indicators.С85_HeatLosesOnDeSulfurOnCastIron);
            rh.hb.C85_persent = PersentToString(indicators.С86_HeatLosesOnDeSulfurOnCastIron_persent);
            rh.hb.C87 = ResultToString(indicators.С87_HeatLosesOnRegeneratiFeOnH);
            rh.hb.C87_persent = PersentToString(indicators.С88_HeatLosesOnRegeneratiFeOnH_persent);
            rh.hb.C89 = ResultToString(indicators.С89_HeatLosesOnLiquidCastIron);
            rh.hb.C89_persent = PersentToString(indicators.С90_HeatLosesOnLiquidCastIron_persent);
            rh.hb.C91 = ResultToString(indicators.С91_HeatLosesOnLiquidSlug);
            rh.hb.C91_persent = PersentToString(indicators.С92_HeatLosesOnLiquidSlug_persent);
            rh.hb.C93 = ResultToString(indicators.С93_HeatLosesOnWaterBlowing);
            rh.hb.C93_persent = PersentToString(indicators.С94_HeatLosesOnWaterBlowing_persent);
            rh.hb.C95 = ResultToString(indicators.С95_HeatLosesOnLime);
            rh.hb.C95_persent = PersentToString(indicators.С96_HeatLosesOnLime_persent);
            rh.hb.C97 = ResultToString(indicators.С97_HeatLosesOnWaterShicht);
            rh.hb.C97_persent = PersentToString(indicators.С98_HeatLosesOnWaterWhicht_persent);
            rh.hb.C104 = ResultToString(indicators.С104_HeatLosesFromBlastFurnaceGas);
            rh.hb.C104_persent = PersentToString(indicators.С105_HeatLosesFromBlastFurnaceGas_persent);
            rh.hb.C107 = ResultToString(indicators.С107_HeatLosesOnFurnaceRamm);
            rh.hb.C107_persent = PersentToString(indicators.С108_HeatLosesOnFurnaceRamm_persent);
            rh.hb.C114 = ResultToString(indicators.С112_HeatBalanceHeatLoses);
            rh.hb.C114_persent = PersentToString(indicators.С112_HeatBalanceHeatLoses__persent);
            rh.hb.C112 = ResultToString(indicators.С112_POGreshnostHeatBalance);
            rh.hb.C112_persent = PersentToString(indicators.С112_POGreshnostHeatBalance__persent);

            // --------------- МАТЕРИАЛЬНЫЙ БАЛАНС ПОШЕЛ ------------ //
            rh.mb.list5_C11 = 94 * 1000 / did.InputData2.materialCons.A8_Fe;
            // ------- ЗДЕСЬ ПОСЛЕ ДОБАВЛЕНИЯ РЕЗЕРВНЫХ ФЛЮСОВ НАДО СНЯТЬ КОММЕНТАРИЙ ----////
            rh.mb.list5_C12 = (rh.mb.list5_C11 * did.InputData2.materialCons.F8_CaO + 0.01f * did.InputIndicators.BlastFur.list1_C21_CockCUMsuption * did.InputIndicators.CockParam.CocksComposit.list2_A42_AhsCocks * did.InputIndicators.CockParam.CocksAsh.list2_B46_Cao + did.InputData2.flus.Limestone.list2_C33_CaO_Capacity * did.InputData2.flus.Limestone.list2_B33flusConsuption + did.InputData2.flus.Fluospat.list2_C33_CaO_Capacity * did.InputData2.flus.Fluospat.list2_B33flusConsuption + did.InputData2.flus.Quartzite.list2_C33_CaO_Capacity * did.InputData2.flus.Quartzite.list2_B33flusConsuption + did.InputData2.flus.Slug.list2_C33_CaO_Capacity * did.InputData2.flus.Slug.list2_B33flusConsuption)/* + did.InputData2.flus.Reserve.list2_C33_CaO_Capacity * did.InputData2.flus.Reserve.list2_B33flusConsuption) */ / did.InputIndicators.slag.list1_C53_CaO_Capacity;
            rh.mb.list5_C13 = 0.00124f * indicators.list3_C20_Qd_BlastConsuptionCalculate * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm + 0.01f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas * (2 * did.InputIndicators.blowing.list1_C39_CH4Consuption + 3 * did.InputIndicators.blowing.list1_C40_C2H6Comsuption + 4 * did.InputIndicators.blowing.list1_C41_C3H8Comsuption);
            rh.mb.list5_C14 = 0.01f * indicators.list3_C51_Vkg_BlastFurnaceGasOut * indicators.list3_C57_BlastFurnaceGasСomposition_H2_persent;
            rh.mb.list5_C15 = rh.mb.list5_C13 - rh.mb.list5_C14;
            rh.mb.list5_C16 = (18 / 22.4f) * rh.mb.list5_C15;
            rh.mb.list5_C17 = 0.01f * did.InputIndicators.blowing.list1_C38_SpecificConsuptionNaturalGas * (1 / 22.4f) * (16 * did.InputIndicators.blowing.list1_C39_CH4Consuption + 30 * did.InputIndicators.blowing.list1_C40_C2H6Comsuption + 44 * did.InputIndicators.blowing.list1_C41_C3H8Comsuption);

            rh.mb.list5_C18 = indicators.list3_C20_Qd_BlastConsuptionCalculate * ((((1 - 0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing) * 28) / 22.4f + 0.01f * did.InputIndicators.blowing.list1_C37_PersentOxygenInBlowing * 32 / 22.4f) * (1 - 0.00124f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm) + 0.001f * did.InputIndicators.blowing.list1_C36_BlowingMoistureSumm);

            rh.mb.list5_C19 = 0.01f * indicators.list3_C51_Vkg_BlastFurnaceGasOut * (1 / 22.4f) * (44 * indicators.list3_C53_BlastFurnaceGasСomposition_С02_persent + 28 * indicators.list3_C55_BlastFurnaceGasСomposition_С0_persent + 16 * indicators.list3_C59_BlastFurnaceGasСomposition_CH4_persent + 2 * indicators.list3_C57_BlastFurnaceGasСomposition_H2_persent + 28 * indicators.list3_C61_BlastFurnaceGasСomposition_N2_persent);

            //---- Приходная часть материального ---- ////
            rh.mb.list5_C23 = ResultToString(indicators.B27_SUMMZHRM_Simple + indicators.B28_MetalAdd_Simple);
            // ------ ЗДЕСЬ ТОЖЕ РЕЗЕРВНЫЕ ФЛЮСЫ УБРАТЬ КОММИТ -- //
            rh.mb.list5_C25 = ResultToString(did.InputData2.flus.Limestone.list2_B33flusConsuption + did.InputData2.flus.Fluospat.list2_B33flusConsuption + did.InputData2.flus.Quartzite.list2_B33flusConsuption + did.InputData2.flus.Slug.list2_B33flusConsuption /*+ did.InputData2.flus.Reserve.list2_B33flusConsuption*/);
            rh.mb.list5_C27 = ResultToString(did.InputIndicators.BlastFur.list1_C21_CockCUMsuption);
            rh.mb.list5_C29 = ResultToString(rh.mb.list5_C17);
            rh.mb.list5_C31 = ResultToString(rh.mb.list5_C18);
            rh.mb.list5_InputMeterial = (indicators.B27_SUMMZHRM_Simple + indicators.B28_MetalAdd_Simple) + did.InputData2.flus.Limestone.list2_B33flusConsuption + did.InputData2.flus.Fluospat.list2_B33flusConsuption + did.InputData2.flus.Quartzite.list2_B33flusConsuption + did.InputData2.flus.Slug.list2_B33flusConsuption /*+ did.InputData2.flus.Reserve.list2_B33flusConsuption*/  + did.InputIndicators.BlastFur.list1_C21_CockCUMsuption + rh.mb.list5_C17 + rh.mb.list5_C18;
            rh.mb.list5_C23_percent = PersentToString((indicators.B27_SUMMZHRM_Simple + indicators.B28_MetalAdd_Simple) / rh.mb.list5_InputMeterial);
            rh.mb.list5_C25_percent = PersentToString(did.InputData2.flus.Limestone.list2_B33flusConsuption + did.InputData2.flus.Fluospat.list2_B33flusConsuption + did.InputData2.flus.Quartzite.list2_B33flusConsuption + did.InputData2.flus.Slug.list2_B33flusConsuption /*+ did.InputData2.flus.Reserve.list2_B33flusConsuption*/ / rh.mb.list5_InputMeterial);
            rh.mb.list5_C27_percent = PersentToString(did.InputIndicators.BlastFur.list1_C21_CockCUMsuption / rh.mb.list5_InputMeterial);
            rh.mb.list5_C29_percent = PersentToString(rh.mb.list5_C17 / rh.mb.list5_InputMeterial);
            rh.mb.list5_C31_percent = PersentToString(rh.mb.list5_C18 / rh.mb.list5_InputMeterial);
            rh.mb.list5_InputMaterial_percent = ((indicators.B27_SUMMZHRM_Simple + indicators.B28_MetalAdd_Simple) / rh.mb.list5_InputMeterial) + ((did.InputData2.flus.Limestone.list2_B33flusConsuption + did.InputData2.flus.Fluospat.list2_B33flusConsuption + did.InputData2.flus.Quartzite.list2_B33flusConsuption + did.InputData2.flus.Slug.list2_B33flusConsuption /*+ did.InputData2.flus.Reserve.list2_B33flusConsuption*/ ) / rh.mb.list5_InputMeterial) + (did.InputIndicators.BlastFur.list1_C21_CockCUMsuption / rh.mb.list5_InputMeterial) + (rh.mb.list5_C17 / rh.mb.list5_InputMeterial) + (rh.mb.list5_C18 / rh.mb.list5_InputMeterial);
            rh.mb.C33 = ResultToString(rh.mb.list5_InputMeterial);
            rh.mb.C33_percent = PersentToString(rh.mb.list5_InputMaterial_percent);
            // ------ Расходная часть материального баланса ----- ////
            rh.mb.list5_C37 = 1000.ToString();
            rh.mb.list5_C39 = ResultToString(rh.mb.list5_C12);
            rh.mb.list5_C41 = ResultToString(rh.mb.list5_C19);
            rh.mb.list5_C43 = ResultToString(rh.mb.list5_C16);
            rh.mb.list5_C45 = ResultToString(did.InputIndicators.FurnaceGas.list1_C66_DustExit);
            rh.mb.list5_Output = 1000 + rh.mb.list5_C12 + rh.mb.list5_C19 + rh.mb.list5_C16 + did.InputIndicators.FurnaceGas.list1_C66_DustExit;

            rh.mb.list5_C37_percent = PersentToString(1000 / rh.mb.list5_Output);
            rh.mb.list5_C39_percent = PersentToString(rh.mb.list5_C12 / rh.mb.list5_Output);
            rh.mb.list5_C41_percent = PersentToString(rh.mb.list5_C19 / rh.mb.list5_Output);
            rh.mb.list5_C43_percent = PersentToString(rh.mb.list5_C16 / rh.mb.list5_Output);
            rh.mb.list5_C45_percent = PersentToString(did.InputIndicators.FurnaceGas.list1_C66_DustExit / rh.mb.list5_Output);
            rh.mb.list5_Output_percent = (1000 / rh.mb.list5_Output) + (rh.mb.list5_C12 / rh.mb.list5_Output) + (rh.mb.list5_C19 / rh.mb.list5_Output) + (rh.mb.list5_C16 / rh.mb.list5_Output) + (did.InputIndicators.FurnaceGas.list1_C66_DustExit / rh.mb.list5_Output);
            rh.mb.C47 = ResultToString(rh.mb.list5_Output);
            rh.mb.C47_persent = PersentToString(rh.mb.list5_Output_percent);
            rh.mb.list5_C50 = ResultToString(rh.mb.list5_InputMeterial - rh.mb.list5_Output);
            rh.mb.list5_C50_percent = PersentToString((rh.mb.list5_InputMeterial - rh.mb.list5_Output) / rh.mb.list5_InputMeterial);
          
            did.InputData2.materialCons.A8_Fe = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.C9_FE + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.C9_FE + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.C9_FE + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.C9_FE + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.C9_FE + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.C9_FE + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.C9_FE + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.C9_FE + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.C9_FE + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.C9_FE + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.C9_FE + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.C9_FE + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.C9_FE + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.C9_FE + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.C9_FE);
            did.InputData2.materialCons.B8_FeO = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.D9_Fe0 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.D9_Fe0 + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.D9_Fe0 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.D9_Fe0 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.D9_Fe0 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.D9_Fe0 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.D9_Fe0 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.D9_Fe0 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.D9_Fe0 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.D9_Fe0 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.D9_Fe0 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.D9_Fe0 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.D9_Fe0 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.D9_Fe0 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.D9_Fe0);
            did.InputData2.materialCons.C8_Fe2O3 = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.E9_Fe2O3 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.E9_Fe2O3 + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.E9_Fe2O3 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.E9_Fe2O3 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.E9_Fe2O3 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.E9_Fe2O3 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.E9_Fe2O3 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.E9_Fe2O3 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.E9_Fe2O3 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.E9_Fe2O3 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.E9_Fe2O3 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.E9_Fe2O3 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.E9_Fe2O3 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.E9_Fe2O3 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.E9_Fe2O3);
            did.InputData2.materialCons.D8_SiO2 = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.F9_SiO2 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.F9_SiO2 + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.F9_SiO2 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.F9_SiO2 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.F9_SiO2 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.F9_SiO2 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.F9_SiO2 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.F9_SiO2 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.F9_SiO2 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.F9_SiO2 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.F9_SiO2 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.F9_SiO2 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.F9_SiO2 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.F9_SiO2 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.F9_SiO2);
            
            did.InputData2.materialCons.E8_AlO3 = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.G9_Al203 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.G9_Al203 + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.G9_Al203 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.G9_Al203 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.G9_Al203 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.G9_Al203 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.G9_Al203 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.G9_Al203 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.G9_Al203 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.G9_Al203 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.G9_Al203 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.G9_Al203 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.G9_Al203 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.G9_Al203 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.G9_Al203);

            did.InputData2.materialCons.F8_CaO = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.H9_CaO + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.H9_CaO + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.H9_CaO + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.H9_CaO + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.H9_CaO + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.H9_CaO + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.H9_CaO + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.H9_CaO + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.H9_CaO + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.H9_CaO + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.H9_CaO + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.H9_CaO + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.H9_CaO + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.H9_CaO + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.H9_CaO);

            did.InputData2.materialCons.G8_MgO = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.I9_Mgo + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.I9_Mgo + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.I9_Mgo + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.I9_Mgo + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.I9_Mgo + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.I9_Mgo + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.I9_Mgo + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.I9_Mgo + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.I9_Mgo + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.I9_Mgo + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.I9_Mgo + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.I9_Mgo + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.I9_Mgo + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.I9_Mgo + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.I9_Mgo);


            did.InputData2.materialCons.H8_P = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.J9_P + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.J9_P + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.J9_P + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.J9_P + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.J9_P + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.J9_P + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.J9_P + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.J9_P + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.J9_P + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.J9_P + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.J9_P + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.J9_P + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.J9_P + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.J9_P + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.J9_P);

            did.InputData2.materialCons.I8_S = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.K9_S + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.K9_S + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.K9_S + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.K9_S + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.K9_S + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.K9_S + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.K9_S + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.K9_S + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.K9_S + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.K9_S + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.K9_S + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.K9_S + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.K9_S + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.K9_S + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.K9_S);

            did.InputData2.materialCons.J8_MnO = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.L9_MnO + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.L9_MnO + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.L9_MnO + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.L9_MnO + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.L9_MnO + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.L9_MnO + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.L9_MnO + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.L9_MnO + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.L9_MnO + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.L9_MnO + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.L9_MnO + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.L9_MnO + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.L9_MnO + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.L9_MnO + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.L9_MnO);

            did.InputData2.materialCons.K8_Zn = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.M9_Zn + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.M9_Zn + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.M9_Zn + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.M9_Zn + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.M9_Zn + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.M9_Zn + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.M9_Zn + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.M9_Zn + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.M9_Zn + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.M9_Zn + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.M9_Zn + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.M9_Zn + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.M9_Zn + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.M9_Zn + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.M9_Zn);

            did.InputData2.materialCons.L8_Pmpp = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.N9_Pmpp + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.K9_S + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.N9_Pmpp + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.N9_Pmpp + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.N9_Pmpp + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.N9_Pmpp + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.N9_Pmpp + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.N9_Pmpp + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.N9_Pmpp + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.N9_Pmpp + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.N9_Pmpp + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.N9_Pmpp + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.N9_Pmpp + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.N9_Pmpp + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.N9_Pmpp);

            did.InputData2.materialCons.M8_H20 = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.O9_H20 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.K9_S + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.O9_H20 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.O9_H20 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.O9_H20 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.O9_H20 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.O9_H20 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.O9_H20 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.O9_H20 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.O9_H20 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.O9_H20 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.O9_H20 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.O9_H20 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.O9_H20 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.O9_H20);

            did.InputData2.materialCons.N8_TiO2 = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.P9_TiO2 + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.K9_S + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.P9_TiO2 + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.P9_TiO2 + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.P9_TiO2 + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.P9_TiO2 + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.P9_TiO2 + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.P9_TiO2 + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.P9_TiO2 + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.P9_TiO2 + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.P9_TiO2 + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.P9_TiO2 + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.P9_TiO2 + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.P9_TiO2 + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.P9_TiO2);

            did.InputData2.materialCons.O8_Cr = ((did.InputData2.InputZRHMs.A9_Aglomerat2.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A9_Aglomerat2.Q9_Cr + (did.InputData2.InputZRHMs.A10_Aglomerat3.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A10_Aglomerat3.K9_S + (did.InputData2.InputZRHMs.A11_Aglomerat4.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A11_Aglomerat4.Q9_Cr + (did.InputData2.InputZRHMs.A12_Aglomerat5.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A12_Aglomerat5.Q9_Cr + (did.InputData2.InputZRHMs.A13_AglomeratNotCleared.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A13_AglomeratNotCleared.Q9_Cr + (did.InputData2.InputZRHMs.A14_AglomeratYama.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A14_AglomeratYama.Q9_Cr + (did.InputData2.InputZRHMs.A15_Okat_Sokolov.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A15_Okat_Sokolov.Q9_Cr + (did.InputData2.InputZRHMs.A16_Okat_Lebed.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A16_Okat_Lebed.Q9_Cr + (did.InputData2.InputZRHMs.A17_Okat_Kachkan.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A17_Okat_Kachkan.Q9_Cr + (did.InputData2.InputZRHMs.A18_Okat_Mikhay.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A18_Okat_Mikhay.Q9_Cr + (did.InputData2.InputZRHMs.A19_Welding_slag.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A19_Welding_slag.Q9_Cr + (did.InputData2.InputZRHMs.A20_Korolek.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A20_Korolek.Q9_Cr + (did.InputData2.InputZRHMs.A21_Domen_prisad.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A21_Domen_prisad.Q9_Cr + (did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A22_Ruda_Mn_Nizgul.Q9_Cr + (did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.B9_CastIronConsuption / indicators.B29_SUMM_Ruda_Simple) * did.InputData2.InputZRHMs.A23_Ruda_Mn_Jairem.Q9_Cr);

            rh.mb.A8_Fe = ResultToString(did.InputData2.materialCons.A8_Fe);
            rh.mb.B8_FeO = ResultToString(did.InputData2.materialCons.B8_FeO);
            rh.mb.C8_Fe2O3 = ResultToString(did.InputData2.materialCons.C8_Fe2O3);
            rh.mb.D8_SiO2 = ResultToString(did.InputData2.materialCons.D8_SiO2);
            rh.mb.E8_AlO3 = ResultToString(did.InputData2.materialCons.E8_AlO3);
            rh.mb.F8_CaO = ResultToString(did.InputData2.materialCons.F8_CaO);
            rh.mb.G8_MgO = ResultToString(did.InputData2.materialCons.G8_MgO);
            rh.mb.H8_P = ResultToString(did.InputData2.materialCons.H8_P);
            rh.mb.I8_S = ResultToString(did.InputData2.materialCons.I8_S);
            rh.mb.J8_MnO = ResultToString(did.InputData2.materialCons.J8_MnO);
            rh.mb.K8_Zn = ResultToString(did.InputData2.materialCons.K8_Zn);
            rh.mb.M8_H20 = ResultToString(did.InputData2.materialCons.M8_H20);
            rh.mb.N8_TiO2 = ResultToString(did.InputData2.materialCons.N8_TiO2);
            rh.mb.O8_Cr = ResultToString(did.InputData2.materialCons.O8_Cr);
           

            return rh;
        }
        static string ResultToString(float num)
        {
            string result = Math.Round(num, 2).ToString();
            return result;
        }

        static string PersentToString(float num)
        {
            string result = Math.Round(num * 100, 2).ToString();
            return result;
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
        public float list3_C62_BlastFurnaceGasDencity;
        public float list3_C63_BlastFurnaceGasForSeconds;

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

        public float B27_SUMMZHRM_Simple;
        public float C27_SUMMZHRM_Fe;
        public float D27_SUMMZHRM_FeO;

        public float B28_MetalAdd_Simple;
        public float C28_MetalAdd_Fe;
        public float D28_MetalAdd_FeO;

        public float B29_SUMM_Ruda_Simple;
        public float C29_SUMM_Ruda_Fe;
        public float D29_SUMM_Ruda_FeO;

        public float S9_basicity;
        public float S10_basicity;
        public float S11_basicity;
        public float S12_basicity;
        public float S13_basicity;
        public float S14_basicity;
        public float S15_basicity;
        public float S16_basicity;
        public float S17_basicity;
        public float S18_basicity;
        public float S19_basicity;
        public float S20_basicity;
        public float S21_basicity;
        public float S22_basicity;
        public float S23_basicity;
        public float basicity_summ;



    }

    public class HeatBalance
    {

        //  --- ПРИХОД ТЕПЛА СТАТЬИ (: клиент :)--- //
        public string HeatOfBurningCocks { get; set; }
        public string HeatOfBurningCocks_persent { get; set; }
        public string HeatCountBlowin { get; set; }
        public string HeatCountBlowing_persent { get; set; }
        public string HeatCountOfConversion { get; set; }
        public string HeatCountOfConversion_persent { get; set; }
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
        public string C112 { get; set; }
        public string C112_persent { get; set; }
        public string C114 { get; set; }
        public string C114_persent { get; set; }
    }

    public class ResultHeat
    {
        public MaterialBalance mb { get; set; }
        public HeatBalance hb { get; set; }
    }
}
