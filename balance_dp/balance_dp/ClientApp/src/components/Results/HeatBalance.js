import React, {useState} from "react";
import {Tables} from "./Tables";
import {ChartModal} from "./ChartModal";
import {createData, prihod, rashod} from "../../utils/consts";
import {nevyazka, prihodDescription, rashodDescription} from "../../utils/heatBalance";

export const HeatBalance = ({result}) => {
    const [activeModal, setActiveModal] = useState(false);
    const [chartLabels, setChartLabels] = useState([]);
    const [chartData, setChartData] = useState([]);
    const [chartTitle, setChartTitle] = useState('');

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

    const toggleModal = (e) => {
        setActiveModal(prev => !prev);
        switch (e.target.name) {
            case prihod:
                setChartData([result.heatOfBurningCocks, result.heatCountBlowin, result.heatCountOfConversion]);
                setChartLabels(prihodDescription);
                setChartTitle('Диаграмма прихода');
                break;
            case rashod:
                setChartData([result.c81, result.c83, result.c85, result.c87, result.c89, result.c91, result.c93, result.c95, result.c97, result.c104]);
                setChartLabels(rashodDescription);
                setChartTitle('Диаграмма расхода');
                break;
            default: break;
        }
    }

    return (
        <>
            <h1 className={'title'}>Тепловой баланс</h1>
            <div className={'result-table'}>
                <div className={'result-row'}>
                    <Tables rows = {rows_prihod} isComming={true}/>
                    <button name={prihod} className={'send-button'} onClick={toggleModal}>Диаграмма прихода</button>
                </div>
                <div className={'result-row'}>
                    <Tables rows = {rows_rashod}/>
                    <button name={rashod} className={'send-button'} onClick={toggleModal}>Диаграмма расхода</button>
                    <h5>Тепловые потери печи с охлаждающей водой и в окружающее пространство</h5>
                    <Tables rows={rows_loastHeat} title={true} />
                    <h5>Невязка теплового баланса (по отношению к приходу тепла в печь)</h5>
                    <Tables rows={rows_nevyzka} title={true} />
                </div>
            </div>
            {activeModal ? <ChartModal title={chartTitle} onToggle={toggleModal} data={chartData} labels={chartLabels} /> : null}
        </>
    )
}


