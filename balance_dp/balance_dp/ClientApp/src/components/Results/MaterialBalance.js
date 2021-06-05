import React, {useState} from "react";
import {Tables} from "./Tables";
import {ChartModal} from "./ChartModal";
import {createData, prihod, rashod} from "../../utils/consts";
import {nevyazkaDescription, prihodDescription, rashodDescription} from "../../utils/materialBalance";

export const MaterialBalance = ({result}) => {
    const [activeModal, setActiveModal] = useState(false);
    const [chartLabels, setChartLabels] = useState([]);
    const [chartData, setChartData] = useState([]);
    const [chartTitle, setChartTitle] = useState('');

    const rows_prihod = [
        createData(prihodDescription[0], result.list5_C23, result.list5_C23_percent),
        createData(prihodDescription[1], result.list5_C25, result.list5_C25_percent),
        createData(prihodDescription[2], result.list5_C27, result.list5_C27_percent),
        createData(prihodDescription[3], result.list5_C29, result.list5_C29_percent),
        createData(prihodDescription[4], result.list5_C31, result.list5_C31_percent),
        createData('Сумма приходных статей', result.C33, result.C33_percent),
    ];

    const rows_rashod = [
        createData(rashodDescription[0], result.list5_C37, result.list5_C37_percent),
        createData(rashodDescription[1], result.list5_C39, result.list5_C39_percent),
        createData(rashodDescription[2], result.list5_C41, result.list5_C41_percent),
        createData(rashodDescription[3], result.list5_C43, result.list5_C43_percent),
        createData(rashodDescription[4], result.list5_C45, result.list5_C45_percent),
        createData('Сумма расходных статей', result.C47, result.C47_persent),
    ];

    const rows_nevyazka = [
        createData(nevyazkaDescription[0], result.list5_C50, result.list5_C50_percent),
    ];

    const toggleModal = (e) => {
        setActiveModal(prev => !prev);
        switch (e.target.name) {
            case prihod:
                setChartData([result.list5_C23, result.list5_C25, result.list5_C27, result.list5_C29, result.list5_C31]);
                setChartLabels(prihodDescription);
                setChartTitle('Диаграмма прихода');
                break;
            case rashod:
                setChartData([result.list5_C37, result.list5_C39, result.list5_C41, result.list5_C43, result.list5_C45]);
                setChartLabels(rashodDescription);
                setChartTitle('Диаграмма расхода');
                break;
            default: break;
        }
    }

    return (
        <>
            <h1 className={'title'}>Материальный баланс</h1>
            <div className={'result-table'}>
                <div className={'result-row'}>
                    <Tables rows = {rows_prihod} isComming={true}/>
                    <button name={prihod} className={'send-button'} onClick={toggleModal}>Диаграмма прихода</button>
                </div>
                <div className={'result-row'}>
                    <Tables rows = {rows_rashod}/>
                    <button name={rashod} className={'send-button'} onClick={toggleModal}>Диаграмма расхода</button>
                    <h5 style={{textAlign:'center'}}>Невязка материального баланса</h5>
                    <Tables rows={rows_nevyazka} title={true}/>
                </div>
            </div>
            {activeModal ? <ChartModal title={chartTitle} onToggle={toggleModal} data={chartData} labels={chartLabels} /> : null}
        </>
    )
};


