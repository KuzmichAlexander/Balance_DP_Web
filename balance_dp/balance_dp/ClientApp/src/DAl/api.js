import axios from 'axios';

const baseURL = document.location.origin;

export const getData = async (name) => { //Запрос на входные параметры
    const url = `${baseURL}/api/ThreadParams/${name}`;
    const {data} = await axios.get(url);
    return data;
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

export const deleteData = async (name, token) => {
    const url = `${baseURL}/api/RemoveParams`;
    const {data} = await axios.post(url, {paramsName: name}, {headers: {Authorization: token}});
    return data;
}

//Для отладки фронта
const inputParams = {"Id":0,"NAME":null,"UserId":0,"InputIndicatorsId":0,"InputIndicators":{"ID":0,"CastIronElementsPercentsId":0,"CastIron":{"ID":0,"list1_C9_Si":0.521,"list1_C10_Mn":0.467,"list1_C11_S":0.016,"list1_C12_P":0.062,"list1_C13_Ti":0.04,"list1_C14_Cr":0.033,"list1_C15_V":0.0,"list1_С16_C":4.762,"list1_C17_CastIronTemperature":1405.0,"list1_C18_CastIronHeatCapacity":0.9},"BlastFurnaceId":0,"BlastFur":{"ID":0,"list1_C20_Dailyproductivity":4131.63,"list1_C21_CockCUMsuption":424.1,"list1_C23_EffectVolume":1370.0,"list1_C24_HeatLoses_ofBlastFurnace":1047.0},"COCKsParamsPersentId":0,"CockParam":{"ID":0,"COCKsCompositionid":0,"CocksComposit":{"ID":0,"list2_A42_AhsCocks":11.45,"list2_B42_SulfurCocks":0.46,"list2_C42_LiquidCocks":0.98,"list2_D42_Snell":87.11},"COCKsAshId":0,"CocksAsh":{"ID":0,"list2_A46_Fe":6.258,"list2_B46_Cao":6.355,"list2_C46_Sio2":50.15,"list2_D46_Al2O3":23.95,"list2_E46_MgO":2.485,"list2_F46_P":0.0},"list1_C29_WaterCOCKs":3.5,"list1_C30_FeoCOCKs":12.0},"BlastFurnaceGasId":0,"FurnaceGas":{"ID":0,"list1_C61_GasTemperature":222.0,"list1_C62_CO2_Capacity":18.93,"list1_C63_CO_Capacity":25.78,"list1_C64_H2_Capacity":11.86,"list1_C65_N2_Capacity":43.43,"list1_C66_DustExit":9.1,"list1_C67_FeO_Capacity":12.0},"BlowingParamsId":0,"blowing":{"ID":0,"list1_C32_BlowingConsumptionPerMinute":2500.0,"list1_C33_HotBlowingTemperature":1240.0,"list1_C34_BlowingMoistureTechReport":1.8,"list1_C35_NaturalBlowingConsumption":11.0,"list1_C36_BlowingMoistureSumm":12.8,"list1_C37_PersentOxygenInBlowing":30.98,"list1_C38_SpecificConsuptionNaturalGas":139.6,"list1_C39_CH4Consuption":100.0,"list1_C40_C2H6Comsuption":0.0,"list1_C41_C3H8Comsuption":0.0,"list1_C42_CO2Comsuption":0.0,"list1_C43_C_Capacity":1.0,"list1_C44_H2_Capacity":2.0,"list1_C46_limestoneWaterCapacity":0.0,"list1_C47_limestoneWeightLoss":44.4},"SlagId":0,"slag":{"ID":0,"list1_C49_SlagOutput":367.5,"list1_C50_SulfurCapacity":0.6,"list1_C51_HeatCapacity":1.26,"list1_C53_CaO_Capacity":38.86,"list1_C54_SiO2_Caacity":38.81,"list1_C55_Al2O3_Capacity":10.45,"list1_C56_MgO_Capacity":7.96,"list1_C57_S_Capacity":0.6,"list1_C58_TiO2_Capacity":0.73,"list1_C59_CaOSiO2_Capacity":1.0012883},"ZHRMId":0,"zhrm":{"ID":0,"c69":1604.3,"c70":80.2,"c71":0.0,"c72_waterCapacity":0.0}},"InputData2Id":0,"InputData2":{"ID":0,"FlusId":0,"flus":{"ID":0,"Limestone":{"ID":0,"list2_B33flusConsuption":0.0,"list2_C33_CaO_Capacity":52.7,"list2_D33_SiO2_Capacity":0.09,"list2_E33_Al2O3_Capacity":0.04,"list2_F33_MgO_Capacity":2.6,"list2_G33_TiO2Capacity":0.0,"list2_H33_MnO_Capacity":0.0,"list2_I33_P_Capacity":0.0,"list2_J33_S_Capacity":0.0},"Fluospat":{"ID":0,"list2_B33flusConsuption":0.0,"list2_C33_CaO_Capacity":34.8,"list2_D33_SiO2_Capacity":0.13,"list2_E33_Al2O3_Capacity":0.04,"list2_F33_MgO_Capacity":18.0,"list2_G33_TiO2Capacity":0.0,"list2_H33_MnO_Capacity":0.0,"list2_I33_P_Capacity":0.0,"list2_J33_S_Capacity":0.0},"Quartzite":{"ID":0,"list2_B33flusConsuption":4.3,"list2_C33_CaO_Capacity":0.0,"list2_D33_SiO2_Capacity":98.4,"list2_E33_Al2O3_Capacity":0.44,"list2_F33_MgO_Capacity":0.0,"list2_G33_TiO2Capacity":0.0,"list2_H33_MnO_Capacity":0.0,"list2_I33_P_Capacity":0.0,"list2_J33_S_Capacity":0.0},"Slug":{"ID":0,"list2_B33flusConsuption":0.0,"list2_C33_CaO_Capacity":39.0,"list2_D33_SiO2_Capacity":37.0,"list2_E33_Al2O3_Capacity":11.6,"list2_F33_MgO_Capacity":7.7,"list2_G33_TiO2Capacity":0.73,"list2_H33_MnO_Capacity":0.0,"list2_I33_P_Capacity":0.0,"list2_J33_S_Capacity":0.97},"Reserve":null},"MaterialConsuptionId":0,"materialCons":{"ID":0,"A8_Fe":57.128,"B8_FeO":10.131,"C8_Fe2O3":49.815,"D8_SiO2":7.782,"E8_AlO3":1.392,"F8_CaO":8.35,"G8_MgO":1.525,"H8_P":0.025,"I8_S":0.039,"J8_MnO":0.189,"K8_Zn":0.017,"L8_Pmpp":0.0,"M8_H20":0.097,"N8_TiO2":0.213,"O8_Cr":0.015},"InputZRHMs":{"ID":0,"A9_Aglomerat2":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":55.7,"D9_Fe0":11.6,"E9_Fe2O3":66.775,"F9_SiO2":5.97,"G9_Al203":2.1,"H9_CaO":10.37,"I9_Mgo":2.05,"J9_P":0.037,"K9_S":0.045,"L9_MnO":0.0,"M9_Zn":0.039,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.32,"Q9_Cr":0.032,"R9_basicity":1.7370185},"A10_Aglomerat3":{"ID":0,"B9_CastIronConsuption":40.3,"C9_FE":55.48,"D9_Fe0":12.5,"E9_Fe2O3":65.4,"F9_SiO2":7.04,"G9_Al203":2.01,"H9_CaO":10.41,"I9_Mgo":1.91,"J9_P":0.03,"K9_S":0.052,"L9_MnO":0.29,"M9_Zn":0.042,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.027,"Q9_Cr":0.02,"R9_basicity":1.4786931},"A11_Aglomerat4":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":54.8,"D9_Fe0":9.3,"E9_Fe2O3":68.0,"F9_SiO2":6.57,"G9_Al203":1.67,"H9_CaO":11.5,"I9_Mgo":2.08,"J9_P":0.027,"K9_S":0.054,"L9_MnO":0.32,"M9_Zn":0.028,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.32,"Q9_Cr":0.038,"R9_basicity":1.7503805},"A12_Aglomerat5":{"ID":0,"B9_CastIronConsuption":1047.7,"C9_FE":56.48,"D9_Fe0":12.9,"E9_Fe2O3":66.5,"F9_SiO2":6.85,"G9_Al203":1.459,"H9_CaO":10.16,"I9_Mgo":1.7,"J9_P":0.024,"K9_S":0.043,"L9_MnO":0.184,"M9_Zn":0.016,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.27,"Q9_Cr":0.01,"R9_basicity":1.4832116},"A13_AglomeratNotCleared":{"ID":0,"B9_CastIronConsuption":36.1,"C9_FE":55.7,"D9_Fe0":12.868,"E9_Fe2O3":0.0,"F9_SiO2":6.756,"G9_Al203":1.872,"H9_CaO":10.497,"I9_Mgo":1.87,"J9_P":0.03,"K9_S":0.057,"L9_MnO":0.0,"M9_Zn":0.044,"N9_Pmpp":0.0,"O9_H20":0.454,"P9_TiO2":0.174,"Q9_Cr":0.025,"R9_basicity":1.55373},"A14_AglomeratYama":{"ID":0,"B9_CastIronConsuption":173.4,"C9_FE":55.48,"D9_Fe0":12.75,"E9_Fe2O3":65.147,"F9_SiO2":7.055,"G9_Al203":2.025,"H9_CaO":10.395,"I9_Mgo":1.91,"J9_P":0.03,"K9_S":0.056,"L9_MnO":0.295,"M9_Zn":0.042,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.27,"Q9_Cr":0.02,"R9_basicity":1.4734232},"A15_Okat_Sokolov":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":62.681,"D9_Fe0":0.0,"E9_Fe2O3":0.0,"F9_SiO2":5.29,"G9_Al203":1.75,"H9_CaO":1.92,"I9_Mgo":1.04,"J9_P":0.013,"K9_S":0.026,"L9_MnO":0.2,"M9_Zn":0.01,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.34,"Q9_Cr":0.013,"R9_basicity":0.36294895},"A16_Okat_Lebed":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":65.8,"D9_Fe0":1.1,"E9_Fe2O3":92.9,"F9_SiO2":5.0,"G9_Al203":0.27,"H9_CaO":0.26,"I9_Mgo":0.23,"J9_P":0.011,"K9_S":0.006,"L9_MnO":0.03,"M9_Zn":0.021,"N9_Pmpp":0.1,"O9_H20":0.0,"P9_TiO2":0.0,"Q9_Cr":0.009,"R9_basicity":0.051999997},"A17_Okat_Kachkan":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":60.4,"D9_Fe0":3.4,"E9_Fe2O3":82.6,"F9_SiO2":4.37,"G9_Al203":2.51,"H9_CaO":1.24,"I9_Mgo":2.44,"J9_P":0.005,"K9_S":0.005,"L9_MnO":0.2,"M9_Zn":0.013,"N9_Pmpp":0.1,"O9_H20":0.0,"P9_TiO2":2.67,"Q9_Cr":0.058,"R9_basicity":0.28375286},"A18_Okat_Mikhay":{"ID":0,"B9_CastIronConsuption":306.8,"C9_FE":63.8,"D9_Fe0":0.0,"E9_Fe2O3":0.0,"F9_SiO2":8.16,"G9_Al203":0.17,"H9_CaO":0.59,"I9_Mgo":0.28,"J9_P":0.01,"K9_S":0.007,"L9_MnO":0.021,"M9_Zn":0.005,"N9_Pmpp":0.0,"O9_H20":0.42,"P9_TiO2":0.0,"Q9_Cr":0.005,"R9_basicity":0.07230392},"A19_Welding_slag":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":68.6,"D9_Fe0":57.9,"E9_Fe2O3":33.8,"F9_SiO2":4.9,"G9_Al203":0.77,"H9_CaO":0.5,"I9_Mgo":0.64,"J9_P":0.01,"K9_S":0.038,"L9_MnO":0.76,"M9_Zn":0.027,"N9_Pmpp":0.1,"O9_H20":0.0,"P9_TiO2":0.0,"Q9_Cr":0.43,"R9_basicity":0.10204081},"A20_Korolek":{"ID":0,"B9_CastIronConsuption":46.7,"C9_FE":67.2,"D9_Fe0":7.94,"E9_Fe2O3":6.5,"F9_SiO2":6.24,"G9_Al203":1.62,"H9_CaO":11.0,"I9_Mgo":4.36,"J9_P":0.111,"K9_S":0.053,"L9_MnO":1.22,"M9_Zn":0.0,"N9_Pmpp":0.0,"O9_H20":0.378,"P9_TiO2":0.26,"Q9_Cr":0.157,"R9_basicity":1.7628206},"A21_Domen_prisad":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":0.0,"D9_Fe0":0.0,"E9_Fe2O3":0.0,"F9_SiO2":0.0,"G9_Al203":0.0,"H9_CaO":0.0,"I9_Mgo":0.0,"J9_P":0.0,"K9_S":0.0,"L9_MnO":0.0,"M9_Zn":0.0,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.0,"Q9_Cr":0.0,"R9_basicity":0.0},"A22_Ruda_Mn_Nizgul":{"ID":0,"B9_CastIronConsuption":33.5,"C9_FE":14.3,"D9_Fe0":0.0,"E9_Fe2O3":0.0,"F9_SiO2":41.4,"G9_Al203":5.64,"H9_CaO":3.73,"I9_Mgo":0.67,"J9_P":0.036,"K9_S":0.057,"L9_MnO":0.0,"M9_Zn":0.0,"N9_Pmpp":0.0,"O9_H20":0.0,"P9_TiO2":0.0,"Q9_Cr":0.0,"R9_basicity":0.090096615},"A23_Ruda_Mn_Jairem":{"ID":0,"B9_CastIronConsuption":0.0,"C9_FE":24.6,"D9_Fe0":0.0,"E9_Fe2O3":0.0,"F9_SiO2":13.34,"G9_Al203":0.92,"H9_CaO":4.86,"I9_Mgo":0.4,"J9_P":0.034,"K9_S":0.081,"L9_MnO":23.23,"M9_Zn":0.0,"N9_Pmpp":0.0,"O9_H20":1.7,"P9_TiO2":0.0,"Q9_Cr":0.0,"R9_basicity":0.36431783}}}}
