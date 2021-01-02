import React from "react";
import {OneInput} from "./OneInput";

const names = ['Удельный расход ЖРМ', 'Удельный расход металлодобавок', 'Удельный расход рудной части', 'Содержание влаги в ЖРМ'];
const discr = ['кг/т чугуна', 'кг/т чугуна', 'кг/т чугуна', '% масс'];

export const ZRRM = ({name, params, onChangeInput}) => {
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
            <h5>Характеристики ЖРМ</h5>
            {setInputs()}
            <hr />
        </div>
    )
}

