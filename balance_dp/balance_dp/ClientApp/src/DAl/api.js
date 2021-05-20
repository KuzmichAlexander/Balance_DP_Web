import axios from 'axios';

const baseURL = document.location.origin;

export const getData = async (name) => { //Запрос на входные параметры
    // const url = `${baseURL}/api/ThreadParams/${name}`;
    // const {data} = await axios.get(url);
    console.log(inputParams)
    return inputParams;
    //return data;
};

export const getParamsNames = async (token) => { //Запрос на список параметров
    const url = `${baseURL}/api/ThreadParams`;
    const {data} = await axios.get(url, {headers: {Authorization: token}});
    return data;
};

export const fetchData = async (params) => { // Отправляем входные, получаем результат
    const url = `${baseURL}/api/CalculateDP`
    const {data} = await axios.post(url, params);
    return data;
};

export const saveDataRequest = async (params, name, token) => {
    const url = `${baseURL}/api/ThreadParams`;
    const sendData = {dpi: params, name: name};
    const {data} = await axios.post(url, sendData, {headers: {Authorization: token}});
    return data;
};

export const reWriteParam = async (params, name, token) => {
    const url = `${baseURL}/api/ThreadParams`;
    const sendData = {dpi: params, name: name};
    const {data} = await axios.patch(url, sendData, {headers: {Authorization: token}});
    return data; // true | false
};

export const auth = async (login, password) => {
    const url = `${baseURL}/api/Auth`;
    const sendData = {login, password};
    const {data} = await axios.post(url, sendData)
    return data
}

export const tokenAuth = async (token) => {
    const url = `${baseURL}/api/Auth`;
    const {data} = await axios.get(url, {headers: {Authorization: token}})
    return data
}

export const registration = async (login, password, name) => {
    const url = `${baseURL}/api/Register`;
    const sendData = {login, password, name};
    const {data} = await axios.post(url, sendData);
    return data;
}


//Для отладки фронта
const inputParams = {
    InputIndicators: {
        CastIron: {
            list1_C9_Si: 0.521,
            list1_C10_Mn: 0.467,
            list1_C11_S: 0.016,
            list1_C12_P: 0.062,
            list1_C13_Ti: 0.04,
            list1_C14_Cr: 0.033,
            list1_C15_V: 0,
            list1_С16_C: 4.762,
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
                list2_A46_Fe: 6.258,
                list2_B46_Cao: 6.355,
                list2_C46_Sio2: 50.15,
                list2_D46_Al2O3: 23.95,
                list2_E46_MgO: 2.485,
                list2_F46_P: 0
            },
            list1_C29_WaterCOCKs: 3.5,
            list1_C30_FeoCOCKs: 12
        },
        FurnaceGas: {
            list1_C61_GasTemperature: 222,
            list1_C62_CO2_Capacity: 18.93,
            list1_C63_CO_Capacity: 25.78,
            list1_C64_H2_Capacity: 11.86,
            list1_C66_DustExit: 9.1,
            list1_C67_FeO_Capacity: 12
        },
        blowing: {
            list1_C32_BlowingConsumptionPerMinute: 2500,
            list1_C33_HotBlowingTemperature: 1240,
            list1_C34_BlowingMoistureTechReport: 1.8,
            list1_C35_NaturalBlowingConsumption: 11,
            list1_C37_PersentOxygenInBlowing: 30.98,
            list1_C38_SpecificConsuptionNaturalGas: 139.6,
            list1_C39_CH4Consuption: 100,
            list1_C40_C2H6Comsuption: 0,
            list1_C41_C3H8Comsuption: 0,
            list1_C42_CO2Comsuption: 0,
            list1_C43_C_Capacity: 1,
            list1_C44_H2_Capacity: 2,

            list1_C46_limestoneWaterCapacity: 0,
            list1_C47_limestoneWeightLoss: 44.4
        },
        slag: {
            list1_C49_SlagOutput: 367.5,
            list1_C50_SulfurCapacity: 0.6,
            list1_C51_HeatCapacity: 1.26,
            list1_C53_CaO_Capacity: 38.86,
            list1_C54_SiO2_Caacity: 38.81,
            list1_C55_Al2O3_Capacity: 10.45,
            list1_C56_MgO_Capacity: 7.96,
            list1_C58_TiO2_Capacity: 0.73
        },
        zhrm: {
            c69: 1604.30,
            c70: 80.20,
            c71: 1684.50,
            c72_waterCapacity: 0
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
                list2_J33_S_Capacity: 0,
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
                list2_J33_S_Capacity: 0,
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
                list2_J33_S_Capacity: 0,
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
                list2_J33_S_Capacity: 0.97,
            }
        },
        materialCons: {
            A8_Fe: 57.128,
            B8_FeO: 10.131,
            C8_Fe2O3: 49.815,
            D8_SiO2: 7.782,
            E8_AlO3: 1.392,
            F8_CaO: 8.35,
            G8_MgO: 1.525,
            H8_P: 0.025,
            I8_S: 0.039,
            J8_MnO: 0.189,
            K8_Zn: 0.017,
            L8_Pmpp: 0,
            M8_H20: 0.097,
            N8_TiO2: 0.213,
            O8_Cr: 0.015
        },
        inputZRHMs:
            {
                A9_Aglomerat2: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A10_Aglomerat3: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A11_Aglomerat4: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A12_Aglomerat5: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A13_AglomeratNotCleared: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A14_AglomeratYama: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A15_Okat_Sokolov: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A16_Okat_Lebed: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A17_Okat_Kachkan: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A18_Okat_Mikhay: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A19_Welding_slag: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A20_Korolek: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A21_Domen_prisad: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A22_Ruda_Mn_Nizgul: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                },
                A23_Ruda_Mn_Jairem: {
                    B9_CastIronConsuption: 0,
                    C9_FE: 0,
                    D9_Fe0: 0,
                    E9_Fe2O3: 0,
                    F9_SiO2: 0,
                    G9_Al203: 0,
                    H9_CaO: 0,
                    I9_Mgo: 0,
                    J9_P: 0,
                    K9_S: 0,
                    L9_MnO: 0,
                    M9_Zn: 0,
                    N9_Pmpp: 0,
                    O9_H20: 0,
                    P9_TiO2: 0,
                    Q9_Cr: 0
                }
            }
    }
}
