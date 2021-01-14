import React from "react";
import {OneInput} from "./OneInput";

const names = ['Зола', 'Сера', 'Летучие'];
const discr = ['%', '%', '%'];

export const COCKS_consuption = ({name, params, onChangeInput}) => {
    const Inputs = [];
    const setInputs = () => {
        let counter = 0;
        for (const key in params) {
            Inputs.push(<OneInput discr={discr[counter]} name={`${name}-${key}`} key={counter} value={params[key]} text={names[counter]} onChangeInput={onChangeInput} />);
            counter++;
        }
        Inputs.pop();
        return Inputs;
    }
    return (
        <div>
            <h5>Технический состав кокса</h5>
            {setInputs()}
            <hr />
        </div>
    )
}
