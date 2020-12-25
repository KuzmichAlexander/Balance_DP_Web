import React from 'react'
import { Pie } from "react-chartjs-2";

export const Charts = ({ data }) => {
    console.log(data)
    const pieData = data.map(item => parseFloat(item));

    return (
        <div style={{marginTop: '30px'}}>
            <Pie
                data={{
                    datasets: [
                        {
                            data: pieData,
                            backgroundColor: ['rgba(255, 0, 0, .5)', 'rgba(0, 255, 0, .5)', 'rgba(255, 255, 0, .5)'],
                        },
                    ],
                    labels :[
                        "rgba(77, 37, 221, 0.7)",
                        'red',
                        'blue'
                    ]
                }}
            />
        </div>
    );
};
