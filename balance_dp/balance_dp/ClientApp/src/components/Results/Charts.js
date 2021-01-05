import React from 'react'
import { Pie } from "react-chartjs-2";

const backgroundColors = ['rgba(255, 0, 0, .5)', 'rgba(0, 255, 0, .5)', 'rgba(255, 255, 0, .5)', 'rgba(255,123,0,0.5)', 'rgba(0,255,255,0.5)', 'rgba(0,0,255,0.5)', 'rgba(255,0,255,0.5)', 'rgba(119,207,67,0.5105392498796393)', 'rgba(176,81,186,0.5105392498796393)', 'rgba(190,56,119,0.5105392498796393)'];

const getBGColors = (count) => {
    const colors = [...backgroundColors.sort(() => 0.5 - Math.random())];
    colors.length = count;
    return colors;
}

export const Charts = ({ data, labels }) => {
    const pieData = data.map(item => parseFloat(item));

    return (
        <div style={{marginTop: '30px'}}>
            <Pie
                data={{
                    datasets: [
                        {
                            data: pieData,
                            backgroundColor: getBGColors(pieData.length),
                        },
                    ],
                    labels : labels,
                }}
            />
        </div>
    );
};
