import React from 'react';
import {Charts} from "./Charts";

export const ChartModal = ({onToggle, data, labels, title}) => {
    console.log(data, labels);
    return (
        <div className='modal-wrapper' onClick={onToggle}>
            <div className="modal-custom chart-modal" onClick={event => event.stopPropagation()} style={{paddingTop: 10}}>
                <div className={'chart-header'}>
                    <h1 className={'chart-title'}>{title}</h1>
                    <span onClick={onToggle}>x</span>
                </div>
                <Charts
                    data = {data}
                    labels = {labels}
                />
            </div>
        </div>
    );
};
