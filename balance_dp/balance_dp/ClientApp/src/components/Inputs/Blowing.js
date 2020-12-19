import React from "react";
import {OneInput} from "./OneInput";

const names = ['Минутный расход дутья', 'Температура горячего дутья', 'Влажность дутья (из техотчета)', 'Естественная влажность дутья', 'Содержание кислорода в дутье', 'Удельный расход природного газа', 'Состав природного газа: CH4', 'Состав природного газа: C2H6', 'Состав природного газа: C3H8', 'Состав природного газа: CO2', 'Содержание С в природном газе', 'Содержание Н2 в природном газе'];
const discr = ['м3/мин', '°С', 'г/м3', 'г/м3', '%', 'м3/т чугуна', '%', '%', '%', '%', 'м3/м3', 'м3/м3'];

export const Blowing = ({name, params, onChangeInput, onSelectChange}) => {
    const Inputs = [];
    const setInputs = () => {
        let counter = 0;
        for (const key in params) {
            if (key === 'list1_C35_NaturalBlowingConsumption') {
                Inputs.push(<div className={'input__container'}>
                    <p className={'input__description'}>Время года</p>
                    <select onChange={onSelectChange}>
                        <option value="1.5">Январь</option>
                        <option value="1.5">Февраль</option>
                        <option value="2">Март</option>
                        <option value="3.5">Апрель</option>
                        <option value="7">Май</option>
                        <option value="11">Июнь</option>
                        <option value="11">Июль</option>
                        <option value="11">Август</option>
                        <option value="7">Сентярбрь</option>
                        <option value="5.5">Октябрь</option>
                        <option value="3">Ноябрь</option>
                        <option value="2">Декабрь</option>
                    </select>
                </div> )
            }
            Inputs.push(<OneInput discr={discr[counter]} name={`${name}-${key}`} key={counter} value={params[key]} text={names[counter]} onChangeInput={onChangeInput} />);
            counter++;
        }
        Inputs.pop();
        Inputs.pop();

        return Inputs;
    }
    return (
        <div>
            <h5>Параметры дутья</h5>
            {setInputs()}
            <h5>Параметры Известняка</h5>
            <OneInput discr={'м3/м3'} name={`${name}-list1_C46_limestoneWaterCapacity`} value={params.list1_C46_limestoneWaterCapacity} text={'Содержание влаги в известняке'} onChangeInput={onChangeInput} />
            <OneInput discr={'%'} name={`${name}-list1_C47_limestoneWeightLoss`} value={params.list1_C47_limestoneWeightLoss} text={'Потеря массы при прокаливании'} onChangeInput={onChangeInput} />
            <hr />
        </div>
    )
}
