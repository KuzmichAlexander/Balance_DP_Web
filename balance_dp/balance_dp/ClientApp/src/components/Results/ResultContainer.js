import React from "react";
import {HeatBalance} from "./HeatBalance";
import {MaterialBalance} from "./MaterialBalance";

export const ResultContainer = ({results}) => {

    return (
        <>
            <h2>Результаты расчёта</h2>
            <div className={'inputs__container result'}>

                <HeatBalance result={results.hb} />
                <MaterialBalance result={results.mb} />
            </div>
        </>
    )
}
