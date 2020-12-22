import React from "react";
import {OneInput} from "./OneInput";

const names = ['Выход шлака, кг/т чугуна (факт.)', 'Содержание серы в шлаке', 'Теплоемкость шлака', 'Содержание CaO', 'Содержание SiO2', 'Содержание Al2O3', 'Содержание MgO', 'Содержание TiO2'];
const discr = ['кг/т чугуна', '%', 'кДж/(кг*К)', '%', '%', '%', '%', '%'];

export const Slag = ({name, params, onChangeInput}) => {
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
            <h5>Жидкие продукты доменной плавки: доменный шлак</h5>
            {setInputs()}
            <hr />
        </div>
    )
}
