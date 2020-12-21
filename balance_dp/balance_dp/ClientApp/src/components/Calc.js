import React from "react";
import {fetchData, getData} from "../DAl/api";
import {CastIron} from "./Inputs/Cast__iron";
import {BlastFur} from "./Inputs/BlastFur";
import {Blowing} from "./Inputs/Blowing";
import {FurnaceGas} from "./Inputs/FurnaceGas";


export class Calc extends React.Component {
    state = {
        data: null
    };

    componentDidMount(event) {
        this.setState({data: getData()});
    };

    onInputChange = (e) => {
        console.log(this.state)
        const value = +e.target.value;
        if(!isNaN(value)){
            const [firstDeep, secondDeep, thirdDeep] = e.target.id.split('-');
            if (thirdDeep === 'list1_C24_HeatLoses_ofBlastFurnace') {
                if (value < 837 || value > 1257) {
                    alert('нельзя так много в это поле писать')
                }
            } else {
                this.setState(() =>{
                    this.state.data[firstDeep][secondDeep][thirdDeep] = value; //и за это тоже
                })
                this.forceUpdate(); //да простят меня боги
            }
        }
    };

    onSelectChange = (e) => {
        const value = +e.target.value;
        console.log(this.state)
        this.setState(() =>{
             this.state.data.InputData1.blowing.list1_C35_NaturalBlowingConsumption = value;
        });
    };

    sendData = async (e) => {
        const data = fetchData(this.state.data);
    };

    render() {
        return (
        <div className='content'>
            <div className='inputs__container'>
                <div className={'DP-work__inputs'}>
                    <h3>Исходные данные (показатели)</h3>
                    {this.state.data ?
                        <>
                            <CastIron name={'InputData1-CastIron'} params={this.state.data.InputData1.CastIron} onChangeInput={this.onInputChange} />
                            <BlastFur name={'InputData1-BlastFur'} params={this.state.data.InputData1.BlastFur} onChangeInput={this.onInputChange} />
                            <Blowing name={'InputData1-blowing'} params={this.state.data.InputData1.blowing} onChangeInput={this.onInputChange} onSelectChange={this.onSelectChange} />
                            <FurnaceGas name={'InputData1-FurnaceGas'} params={this.state.data.InputData1.FurnaceGas} onChangeInput={this.onInputChange} />
                        </>
                         : 'Данные подгружаются'}
                </div>
                <div className={'DP-work__inputs'}>
                    <h3>Исходные данные (ввод составов)</h3>
                </div>
            </div>
            <input type="button" onClick={this.sendData} value={'Рассчитать'}/>
        </div>
        )
    }
}
