import axios from 'axios';
const url = 'https://localhost:44379/api/CalculateDP';

export const getData = () => {
    return data;
}

export const fetchData = async (params) => {
    console.log(params)
    const { data } = await axios.post(url, params);
    console.log(data);
}

const data = {
    InputData1: {
        CastIron: {
            list1_C9_Si: 0.521,
            list1_C10_Mn: 0.467,
            list1_C11_S: 0.016,
            list1_C12_P: 0.062,
            list1_C13_Ti: 0.44,
            list1_C14_Cr: 0.033,
            list1_C15_V: 0,
            list1_C16_C: 4.762,
            list1_C17_CastIronTemperature: 1405
        },
        BlastFur: {
            list1_C20_Dailyproductivity: 4131.63,
            list1_C21_CockCUMsuption: 424.1,
            list1_C23_EffectVolume: 1370,
            list1_C24_HeatLoses_ofBlastFurnace: 1047
        },

        CockParam: {
            CocksComposit: {
                list2_A42_AhsCocks: 11.45,
                list2_B42_SulfurCocks: 0.46,
                list2_C42_LiquidCocks: 0.98
                },
            CocksAsh: {
                list2_A46_Fe:6.258,
                list2_B46_Cao: 6.355,
                list2_C46_Sio2: 50.15,
                list2_D46_Al2O3: 24.95,
                list2_E46_MgO: 23.94,
                list2_F46_P: 0
            },
            list1_C29_WaterCOCKs: 3.5,
            list1_C30_FeoCOCKs: 12
            },
        FurnaceGas: {
            list1_C61_GasTemperature: 222,
            list1_C62_CO2_Capacity: 18.93,
            list1_C63_CO_Capacity: 25.78,
            list1_C64_H2_Capacity: 11.68,
            list1_C66_DustExit: 9.1,
            list1_C67_FeO_Capacity: 12
        },
        blowing: {
            list1_C32_BlowingConsumptionPerMinute: 2500,
            list1_C33_HotBlowingTemperature: 1240,
            list1_C34_BlowingMoistureTechReport: 1.8,
            list1_C35_NaturalBlowingConsumption: 11,

            list1_C37_PersentOxygenInBlowing:  30.98,
            list1_C38_SpecificConsuptionNaturalGas: 139.6,
            list1_C39_CH4Consuption:100,
            list1_C40_C2H6Comsuption: 0,
            list1_C41_C3H8Comsuption: 0,
            list1_C42_CO2Comsuption: 0,
            list1_C43_C_Capacity: 1,
            list1_C44_H2_Capacity: 2,

            list1_C46_limestoneWaterCapacity: 0,
            list1_C47_limestoneWeightLoss: 44.4
        }
    },
    InputData2: {
        flus: {
            Limestone: {
                list2_B33flusConsuption: 0,
                list2_C33_CaO_Capacity: 52.7,
                list2_D33_SiO2_Capacity: 0.09,
                list2_E33_Al2O3_Capacity: 0.04,
                list2_F33_MgO_Capacity: 2.6,
                list2_G33_TiO2Capacity: 0,
                list2_H33_MnO_Capacity: 0,
                list2_I33_P_Capacity: 0,
                list2_J33_S_Capacity:0,
            },
            Fluospat: {
                list2_B33flusConsuption: 0,
                list2_C33_CaO_Capacity: 34.8,
                list2_D33_SiO2_Capacity: 0.13,
                list2_E33_Al2O3_Capacity: 0.04,
                list2_F33_MgO_Capacity: 18,
                list2_G33_TiO2Capacity: 0,
                list2_H33_MnO_Capacity: 0,
                list2_I33_P_Capacity: 0,
                list2_J33_S_Capacity:0,
            },
            Quartzite: {
                list2_B33flusConsuption: 4.3,
                list2_C33_CaO_Capacity: 0,
                list2_D33_SiO2_Capacity: 98.4,
                list2_E33_Al2O3_Capacity: 0.44,
                list2_F33_MgO_Capacity: 0,
                list2_G33_TiO2Capacity: 0,
                list2_H33_MnO_Capacity: 0,
                list2_I33_P_Capacity: 0,
                list2_J33_S_Capacity:0,
            },
            Slug: {
                list2_B33flusConsuption: 0,
                list2_C33_CaO_Capacity: 39,
                list2_D33_SiO2_Capacity: 37,
                list2_E33_Al2O3_Capacity: 11.6,
                list2_F33_MgO_Capacity: 7.7,
                list2_G33_TiO2Capacity: 0.73,
                list2_H33_MnO_Capacity: 0,
                list2_I33_P_Capacity: 0,
                list2_J33_S_Capacity:0.97,
            }
        }
    }
}