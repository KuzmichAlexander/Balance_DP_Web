import React from "react";
import {HeatBalance} from "./HeatBalance";
import {MaterialBalance} from "./MaterialBalance";
import {Sostav} from "./Sostav";

export const ResultContainer = ({results}) => {

    return (
        <>
            <h1 className={'chart-title'}>Результаты расчёта</h1>
            <hr/>
            <div>
                <HeatBalance result={results.hb} />
                <MaterialBalance result={results.mb} />
            </div>
            <Sostav result={results.mb} />
        </>
    )
};
