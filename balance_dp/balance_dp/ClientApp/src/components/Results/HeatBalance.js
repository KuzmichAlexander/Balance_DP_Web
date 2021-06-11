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
        createData(prihodDescription[0], result.HeatOfBurningCocks, result.HeatOfBurningCocks_persent),
        createData(prihodDescription[1], result.HeatCountBlowin, result.HeatCountBlowing_persent),
        createData(prihodDescription[2], result.HeatCountOfConversion, result.HeatCountOfConversion_persent),
        createData('Итого приход тепла', result.Sum, result.Sum_persent),
    ];

    const rows_loastHeat = [
        createData(nevyazka[0], result.C107, result.C107_persent),
        createData(nevyazka[1], result.C114, result.C114_persent),
    ];

    const rows_nevyzka = [
        createData(nevyazka[2], result.C112, result.C112_persent),
    ]

    const rows_rashod = [
        createData(rashodDescription[0], result.C81, result.C81_persent),
        createData(rashodDescription[1], result.C83, result.C83_persent),
        createData(rashodDescription[2], result.C85, result.C85_persent),
        createData(rashodDescription[3], result.C87, result.C87_persent),
        createData(rashodDescription[4], result.C89, result.C89_persent),
        createData(rashodDescription[5], result.C91, result.C91_persent),
        createData(rashodDescription[6], result.C93, result.C93_persent),
        createData(rashodDescription[7], result.C95, result.C95_persent),
        createData(rashodDescription[8], result.C97, result.C97_persent),
        createData(rashodDescription[9], result.C104, result.C104_persent),
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
                setChartData([result.C81, result.C83, result.C85, result.C87, result.C89, result.C91, result.C93, result.C95, result.C97, result.C104]);
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
                    <Tables rows = {rows_prihod} isComming={true} isHeat={true}/>
                    <button name={prihod} className={'send-button'} onClick={toggleModal}>Диаграмма прихода</button>
                </div>
                <div className={'result-row'}>
                    <Tables rows = {rows_rashod} isHeat={true}/>
                    <button name={rashod} className={'send-button'} onClick={toggleModal}>Диаграмма расхода</button>
                    <h5>Тепловые потери печи с охлаждающей водой и в окружающее пространство</h5>
                    <Tables rows={rows_loastHeat} title={true} isHeat={true}/>
                    <h5>Невязка теплового баланса (по отношению к приходу тепла в печь)</h5>
                    <Tables rows={rows_nevyzka} title={true} isHeat={true}/>
                </div>
            </div>
            {activeModal ? <ChartModal title={chartTitle} onToggle={toggleModal} data={chartData} labels={chartLabels} /> : null}
        </>
    )
}


