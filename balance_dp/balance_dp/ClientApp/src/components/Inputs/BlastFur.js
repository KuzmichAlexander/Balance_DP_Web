import React from "react";
import {OneInput} from "./OneInput";

const names = ['Суточная производительность печи по чугуну', 'Удельный расход кокса', 'Полезный объем печи', 'Удельные тепловые потери'];
const discr = ['т/сут', 'кг/т чугуна', 'м3', 'кДж/кг чугуна'];

export const BlastFur = ({name, params, onChangeInput, onBlurFunc}) => {
    const Inputs = [];
    const setInputs = () => {
        let counter = 0;
        for (const key in params) {
            if (counter === 3) {
                Inputs.push(<OneInput discr={discr[counter]} name={`${name}-${key}`} key={counter} value={params[key]} text={names[counter]} onBlurFunction={onBlurFunc} onChangeInput={onChangeInput} />);
            } else {
                Inputs.push(<OneInput discr={discr[counter]} name={`${name}-${key}`} key={counter} value={params[key]} text={names[counter]} onChangeInput={onChangeInput} />);

            }
            counter++;
        }
        return Inputs;
    }
    return (
        <div>
            <h5>Режимные параметры</h5>
            {setInputs()}
            <hr />
        </div>
    )
}
