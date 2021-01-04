import React from "react";
import {Charts} from "./Charts";
import {Tables} from "./Tables";

const prihodDescription = ['Горение кокса', 'Тепло нагретого дутья', 'Тепло конверсии газа'];
const rashodDescription = ['Прямое восстановление оксидов железа',
    'Прямое восстановление примесей чугуна',
    'Расход тепла на десульфурацию чугуна',
    'Восстановление оксидов железа водородом',
    'Тепло, уносимое чугуном',
    'Тепло, уносимое шлаком',
    'Разложение влаги дутья',
    'Расход тепла на разложение известняка',
    'Расход тепла на разложение влаги шихты',
    'Тепло, уносимое колошниковым газом '
];
const nevyazka = ['По методике А.Н. Рамма', 'По разности прихода и расхода', 'По методике А.Н. Рамма']

function createData(name, first, second) {
    return {name, first, second};
}

export const HeatBalance = ({result}) => {

    const rows_prihod = [
        createData(prihodDescription[0], result.heatOfBurningCocks, result.heatOfBurningCocks_persent),
        createData(prihodDescription[1], result.heatCountBlowin, result.heatCountBlowing_persent),
        createData(prihodDescription[2], result.heatCountOfConversion, result.heatCountOfConversion_persent),
        createData('Итого приход тепла', result.sum, result.sum_persent),
    ];

    const rows_loastHeat = [
        createData(nevyazka[0], result.c107, result.c107_persent),
        createData(nevyazka[1], result.c114, result.c114_persent),
    ];

    const rows_nevyzka = [
        createData(nevyazka[2], result.c112, result.c112_persent),
    ]

    const rows_rashod = [
        createData(rashodDescription[0], result.c81, result.c81_persent),
        createData(rashodDescription[1], result.c83, result.c83_persent),
        createData(rashodDescription[2], result.c85, result.c85_persent),
        createData(rashodDescription[3], result.c87, result.c87_persent),
        createData(rashodDescription[4], result.c89, result.c89_persent),
        createData(rashodDescription[5], result.c91, result.c91_persent),
        createData(rashodDescription[6], result.c93, result.c93_persent),
        createData(rashodDescription[7], result.c95, result.c95_persent),
        createData(rashodDescription[8], result.c97, result.c97_persent),
        createData(rashodDescription[9], result.c104, result.c104_persent),
    ];

    return (

        <div className={'DP-work__inputs result-table'}>
            <h5>Тепловой баланс</h5>
            <Tables rows = {rows_prihod} isComming={true}/>
            <Charts
                data={[result.heatOfBurningCocks, result.heatCountBlowin, result.heatCountOfConversion]}
                labels={prihodDescription}
            />
            <br/>{/* {//'-----------------------------------------------'}*/}
            <Tables rows = {rows_rashod}/>
            <h5>Тепловые потери печи с охлаждающей водой и в окружающее пространство</h5>
            <Tables rows={rows_loastHeat} title={true} />
            <h5>Невязка теплового баланса (по отношению к приходу тепла в печь)</h5>
            <Tables rows={rows_nevyzka} title={true} />
            <Charts
                data={[result.c81, result.c83, result.c85, result.c87, result.c89, result.c91, result.c93, result.c95, result.c97, result.c104]}
                labels={rashodDescription}
            />
        </div>
    )
}


