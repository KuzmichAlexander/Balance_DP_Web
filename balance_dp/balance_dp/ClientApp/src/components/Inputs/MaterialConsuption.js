import React from "react";
import {OneInput} from "./OneInput";

const names = ['Fe', 'FeO', 'Fe2O3', 'SiO2', 'Al2O3', 'CaO', 'MgO', 'P', 'S', 'MnO', 'Zn', 'Пмпп', 'H2O', 'TiO2', 'Cr'];
const discr = ['%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%'];

export const MaterialConsuption = ({name, params, onChangeInput}) => {
    const Inputs = [];
    const setInputs = () => {
        let counter = 0;
        for (const key in params) {
            Inputs.push(<OneInput discr={discr[counter]} name={`${name}-${key}`} key={counter} value={params[key]} text={names[counter]} onChangeInput={onChangeInput} />);
            counter++;
        }
        return Inputs;
    }
    return (
        <div>
            <h5>Средневзвешенный состав рудного материала</h5>
            {setInputs()}
            <hr />
        </div>
    )
}
