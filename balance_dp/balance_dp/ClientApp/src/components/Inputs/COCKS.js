import React from "react";
import {CocksConsuption} from "./CocksConsuption";
import {CocksTech} from "./CocksTech";
import {OneInput} from "./OneInput";

export const COCKS = ({name, params, onChangeInput}) => {
    return (
        <div>
            <CocksConsuption name={`${name}-CocksComposit`} params={params.CocksComposit}
                             onChangeInput={onChangeInput} />
            <CocksTech name={`${name}-CocksAsh`} params={params.CocksAsh}
                       onChangeInput={onChangeInput}/>

            <OneInput key={`${name}-list1_C29_WaterCOCKs`} discr={'%'} name={`${name}-list1_C29_WaterCOCKs`} value={params.list1_C29_WaterCOCKs} text={'Влага кокса'} onChangeInput={onChangeInput} />
            <OneInput key={`${name}-list1_C30_FeoCOCKs`} discr={'%'} name={`${name}-list1_C30_FeoCOCKs`} value={params.list1_C30_FeoCOCKs} text={'Содержание FeO в золе кокса'} onChangeInput={onChangeInput} />
            <hr />
        </div>
    )
}
