import React from "react";
import {animateScroll as scroll} from "react-scroll";
import {fetchData, getData, saveDataRequest} from "../DAl/api";
import {CastIron} from "./Inputs/Cast__iron";
import {BlastFur} from "./Inputs/BlastFur";
import {Blowing} from "./Inputs/Blowing";
import {FurnaceGas} from "./Inputs/FurnaceGas";
import {Slag} from "./Inputs/Slag";
import {ResultContainer} from "./Results/ResultContainer";
import {MaterialConsuption} from "./Inputs/MaterialConsuption";
import {Flus} from "./Inputs/Flus";
import {ZRRM} from "./Inputs/ZHRM";
import {CustomModal} from "./Modal";


export class Calc extends React.Component {
    state = {
        data: null,
        result: null,
        save: null,
        modalActive: false,
        sendButtonDisabled: false,
    };

    async componentDidMount(event) {
        const fetchedData = await getData();
        this.setState({data: fetchedData});
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
        this.setState(() => {
            this.state.data.InputIndicators.blowing.list1_C35_NaturalBlowingConsumption = value;
        });
    };

    sendData = async (e) => {
        this.toggleSendButton();
        const fetchedData = await fetchData(this.state.data);
        this.setState({result: fetchedData});
        const scrollTo = window.pageYOffset + window.innerHeight - 150;
        setTimeout(()=>scroll.scrollTo(scrollTo), 0)
    };

    toggleSendButton = () => {
        if (this.state.sendButtonDisabled) {
            this.setState({sendButtonDisabled: false})
        } else {
            this.setState({sendButtonDisabled: true})
        }
    }

    toggleModal = () => {
        if (this.state.modalActive) {
            this.setState({modalActive: false})
        } else {
            this.setState({modalActive: true})
        }
    }

    saveData = async (name) => {
        const result = await saveDataRequest(this.state.data, name);
        this.setState({save: true});
    };

    reset = () => {
        this.setState({result: null});
        this.toggleSendButton();
    }

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
                                <ZRRM name={'InputIndicators-zhrm'}
                                      params={this.state.data.InputIndicators.zhrm}
                                      onChangeInput={this.onInputChange}/>
                            </>
                            : 'Данные подгружаются'}
                    </div>
                </div>
                <div className={'flus__container'}>
                    {this.state.data ?
                        <Flus name={'InputData2-flus'}
                              params={this.state.data.InputData2.flus}
                              onChangeInput={this.onInputChange}/>
                        : null}
                </div>
                <div className="buttons__container">
                    <input type="button" className={'send-button'} onClick={this.toggleModal}
                           value={'Сохранить входные параметры'}/>
                    <input type="button" className={'send-button'} onClick={this.sendData} value={'Произвести расчёт'}
                           disabled={this.state.sendButtonDisabled}/>
                </div>
                <br />
                {this.state.result ?
                    <>
                        <ResultContainer results={this.state.result}/>
                        <input type="button" style={{margin: '0 auto'}} className={'send-button'} onClick={this.reset}
                               value={'Посчитать ещё раз'}/>
                    </>
                    : 'Бесы опять шалят, данных пока нет'}
                {this.state.modalActive ? <CustomModal onToggle={this.toggleModal} saveParams={this.saveData}/> : null}
            </div>
        )
    }
}
