import React from "react";
import {Charts} from "./Charts";
import {Tables} from "./Tables";

const prihodDescription = ['Железорудный материал', 'Флюс', 'Кокс', 'Природный газ', 'Дутье'];
const rashodDescription = ['Чугун', 'Шлак', 'Колошниковый газ', 'Масса влаги от восстановления оксидов железа водородом', 'Колошниковая пыль'];

function createData(name, first, second) {
    return {name, first, second};
}

export const MaterialBalance = ({result}) => {

    const rows_prihod = [
        createData(prihodDescription[0], result.list5_C23, result.list5_C23_percent),
        createData(prihodDescription[1], result.list5_C25, result.list5_C25_percent),
        createData(prihodDescription[2], result.list5_C27, result.list5_C27_percent),
        createData(prihodDescription[3], result.list5_C29, result.list5_C29_percent),
        createData(prihodDescription[4], result.list5_C31, result.list5_C31_percent),
        createData('Сумма приходных статей материального баланса', result.c33, result.c33_percent),
    ];

    const rows_rashod = [
        createData(rashodDescription[0], result.list5_C37, result.list5_C37_percent),
        createData(rashodDescription[1], result.list5_C39, result.list5_C39_percent),
        createData(rashodDescription[2], result.list5_C41, result.list5_C41_percent),
        createData(rashodDescription[3], result.list5_C43, result.list5_C43_percent),
        createData(rashodDescription[4], result.list5_C45, result.list5_C45_percent),
        createData('Сумма расходных статей материального баланса', result.c47, result.c47_persent),
    ];

    return (
        <div className={'DP-work__inputs result-table'}>
            <h5>Материальный баланс</h5>
            <Tables rows = {rows_prihod} isComming={true}/>
            <Charts
                data = {[result.list5_C23, result.list5_C25, result.list5_C27, result.list5_C29, result.list5_C31]}
                labels = {prihodDescription}
            />
            <br/>{/* {//'-----------------------------------------------'}*/}
            <Tables rows = {rows_rashod}/>
            <Charts
                data = {[result.list5_C37, result.list5_C39, result.list5_C41, result.list5_C43, result.list5_C45]}
                labels = {rashodDescription}
            />
        </div>
    )
}


