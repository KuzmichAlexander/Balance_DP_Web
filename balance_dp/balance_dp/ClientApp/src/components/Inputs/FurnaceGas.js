import React from "react";
import {OneInput} from "./OneInput";

const names = ['Температура колошникового газа', 'Содержание СО2', 'Содержание СО', 'Содержание H2', 'Вынос колошниковой пыли (уловленной)', 'Содержание FeO в колошниковой пыли'];
const discr = ['°С', '%', '%', '%', 'кг/т чугуна', '%'];

export const FurnaceGas = ({name, params, onChangeInput}) => {
    const Inputs = [];
    const setInputs = () => {
        let counter = 0;
        for (const key in params) {
            if (key === 'list1_C65_N2_Capacity') continue;
            Inputs.push(<OneInput discr={discr[counter]} name={`${name}-${key}`} key={counter} value={params[key]} text={names[counter]} onChangeInput={onChangeInput} />);
            counter++;
        }
        return Inputs;
    }
    return (
        <div>
            <h5>Колошниковый газ</h5>
            {setInputs()}
            <hr />
        </div>
    )
}

