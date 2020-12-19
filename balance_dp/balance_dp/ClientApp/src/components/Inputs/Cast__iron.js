import React from "react";
import {OneInput} from "./OneInput";

const names = ['Si', 'Mn', 'S', 'P', 'Ti', 'Cr', 'V', 'C', 'Температура чугуна'];
const discr = ['%', '%', '%', '%', '%', '%', '%', '%', '°С'];

export const CastIron = ({name, params, onChangeInput}) => {
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
            <h5>Содержание элементов в чугуне</h5>
            {setInputs()}
            <hr />
        </div>
    )
}
