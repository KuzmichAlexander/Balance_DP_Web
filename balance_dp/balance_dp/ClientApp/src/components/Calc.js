import React from "react";
import {fetchData, getData} from "../DAl/api";
import {CastIron} from "./Inputs/Cast__iron";
import {BlastFur} from "./Inputs/BlastFur";
import {Blowing} from "./Inputs/Blowing";
import {FurnaceGas} from "./Inputs/FurnaceGas";
import {Slag} from "./Inputs/Slag";
import {ResultContainer} from "./Results/ResultContainer";
import {MaterialConsuption} from "./Inputs/MaterialConsuption";
import {Flus} from "./Inputs/Flus";
import {ZRRM} from "./Inputs/ZHRM";


export class Calc extends React.Component {
    state = {
        data: null,
        result: null
    };

    componentDidMount(event) {
        this.setState({data: getData()});
    };

    onBlurFunction = (e) => {
        const value = e.target.value;
        if (value < 837) {
            alert('Допустимый диапозон значений 837 < x < 1257');
            e.target.value = 837;
        } else if (value > 1257) {
            alert('Допустимый диапозон значений 837 < x < 1257');
            e.target.value = 1257;
        }
    }

    onInputChange = (e) => {
        const value = +e.target.value;
        if (!isNaN(value)) {
            const [firstDeep, secondDeep, thirdDeep, forthDeep] = e.target.id.split('-');
            if (forthDeep) {
                this.setState(() => {
                    this.state.data[firstDeep][secondDeep][thirdDeep][forthDeep] = value; //и за это тоже
                })
                this.forceUpdate(); //да простят меня боги
            } else {
                this.setState(() => {
                    this.state.data[firstDeep][secondDeep][thirdDeep] = value; //и за это тоже
                })
                this.forceUpdate(); //да простят меня боги
            }
        }
    };

    onSelectChange = (e) => {
        const value = +e.target.value;
        console.log(this.state)
        this.setState(() => {
            this.state.data.InputIndicators.blowing.list1_C35_NaturalBlowingConsumption = value;
        });
    };

    sendData = async (e) => {
        const fetchedData = await fetchData(this.state.data);
        console.log(fetchedData)
        this.setState({result: fetchedData})
    };

    render() {
        return (
            <div className='content'>
                <div className='inputs__container'>
                    <div className={'DP-work__inputs'}>
                        <h3>Исходные данные (показатели)</h3>
                        {this.state.data ?
                            <>
                                <CastIron name={'InputIndicators-CastIron'}
                                          params={this.state.data.InputIndicators.CastIron}
                                          onChangeInput={this.onInputChange}/>
                                <BlastFur name={'InputIndicators-BlastFur'}
                                          params={this.state.data.InputIndicators.BlastFur}
                                          onChangeInput={this.onInputChange}
                                          onBlurFunc={this.onBlurFunction}/>
                                <Blowing name={'InputIndicators-blowing'}
                                         params={this.state.data.InputIndicators.blowing}
                                         onChangeInput={this.onInputChange} onSelectChange={this.onSelectChange}/>
                                <FurnaceGas name={'InputIndicators-FurnaceGas'}
                                            params={this.state.data.InputIndicators.FurnaceGas}
                                            onChangeInput={this.onInputChange}/>
                                <Slag name={'InputIndicators-slag'} params={this.state.data.InputIndicators.slag}
                                      onChangeInput={this.onInputChange}/>
                            </>
                            : 'Данные подгружаются'}
                    </div>
                    <div className={'DP-work__inputs'}>
                        <h3>Исходные данные (ввод составов)</h3>
                        {this.state.data ?
                            <>
                                <MaterialConsuption name={'InputData2-materialCons'}
                                                    params={this.state.data.InputData2.materialCons}
                                                    onChangeInput={this.onInputChange}/>
                                <Flus name={'InputData2-flus'} params={this.state.data.InputData2.flus}
                                      onChangeInput={this.onInputChange}/>
                                <ZRRM name={'InputIndicators-zhrm'}
                                      params={this.state.data.InputIndicators.zhrm}
                                      onChangeInput={this.onInputChange}/>
                            </>
                            : 'Данные подгружаются'}
                    </div>
                </div>
                <input type="button" className={'send-button'} onClick={this.sendData} value={'Произвести рассчёт'}/>
                <br/>
                {this.state.result ? <ResultContainer results={this.state.result}/>
                    : 'Бесы опять шалят, данных пока нет'}
            </div>
        )
    }
}
