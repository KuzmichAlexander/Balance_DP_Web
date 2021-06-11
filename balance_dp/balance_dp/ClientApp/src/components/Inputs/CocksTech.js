import React from "react";
import {OneInput} from "./OneInput";

const names = ['Fe', 'Cao', 'Sio2', 'Al2O3', 'MgO', 'P'];
const discr = ['%', '%', '%', '%', '%', '%'];

export const CocksTech = ({name, params, onChangeInput}) => {
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
            <h5>Состав золы кокса</h5>
            {setInputs()}
        </div>
    )
}
