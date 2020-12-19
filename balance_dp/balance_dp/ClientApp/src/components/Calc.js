import React from "react";
import { getData } from "../DAl/api";
import {CastIron} from "./Inputs/Cast__iron";
import {BlastFur} from "./Inputs/BlastFur";
import {Blowing} from "./Inputs/Blowing";
import {FurnaceGas} from "./Inputs/FurnaceGas";


export class Calc extends React.Component {
    state = {
            data: null
        }

    componentDidMount(event) {
        this.setState({data: getData()});
    }

    onInputChange = (e) => {
        console.log(this.state)
        const value = +e.target.value;
        if(!isNaN(value)){
            const [firstDeep, secondDeep] = e.target.id.split('-');
            if (secondDeep === 'list1_C24_HeatLoses_ofBlastFurnace') {
                if (value < 837 || value > 1257) {
                    alert('нельзя так много в это поле писать')
                }
            } else {
                this.setState(() =>{
                    this.state.data[firstDeep][secondDeep] = value; //и за это тоже
                })
                this.forceUpdate(); //да простят меня боги
            }
        }
    }

    onSelectChange = (e) => {
        const value = +e.target.value;
        console.log(this.state)
        this.setState(() =>{
             this.state.data.blowing.list1_C35_NaturalBlowingConsumption = value;
        });
    }
    render() {
        return (
        <div className='content'>
            <div className='inputs__container'>
                <div className={'DP-work__inputs'}>
                    <h3>Исходные данные (показатели)</h3>
                    {this.state.data ?
                        <>
                            <CastIron name={'CastIron'} params={this.state.data.CastIron} onChangeInput={this.onInputChange} />
                            <BlastFur name={'BlastFur'} params={this.state.data.BlastFur} onChangeInput={this.onInputChange} />
                            <Blowing name={'blowing'} params={this.state.data.blowing} onChangeInput={this.onInputChange} onSelectChange={this.onSelectChange} />
                            <FurnaceGas name={'FurnaceGas'} params={this.state.data.FurnaceGas} onChangeInput={this.onInputChange} />
                        </>
                         : 'Данные подгружаются'}
                </div>
                <div className={'DP-work__inputs'}>
                    <h3>Исходные данные (ввод составов)</h3>
                </div>
            </div>
        </div>
        )
    }
}
