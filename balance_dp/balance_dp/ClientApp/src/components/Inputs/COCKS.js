import React from "react";
import {COCKS_consuption} from "./COCKS_consuption";
import {COCKS_tech} from "./COCKS_tech";
import {OneInput} from "./OneInput";

export const COCKS = ({name, params, onChangeInput}) => {
    return (
        <div>
            <COCKS_consuption name={`${name}-CocksComposit`} params={params.CocksComposit}
                              onChangeInput={onChangeInput} />
            <COCKS_tech name={`${name}-CocksAsh`} params={params.CocksAsh}
                        onChangeInput={onChangeInput}/>

            <OneInput key={`${name}-list1_C29_WaterCOCKs`} discr={'%'} name={`${name}-list1_C29_WaterCOCKs`} value={params.list1_C29_WaterCOCKs} text={'Влага кокса'} onChangeInput={onChangeInput} />
            <OneInput key={`${name}-list1_C30_FeoCOCKs`} discr={'%'} name={`${name}-list1_C30_FeoCOCKs`} value={params.list1_C30_FeoCOCKs} text={'Содержание FeO в золе кокса'} onChangeInput={onChangeInput} />
            <hr />
        </div>
    )
}
