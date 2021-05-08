import React from "react";

export const OneInput = ({discr, name, text, value, onChangeInput, onBlurFunction}) => {
    return (
        <div className='input__container'>
            <p className={'input__description'}>{text}</p>
            {onBlurFunction ?
                <input id={name} type="text" value={value} onChange={onChangeInput} onBlur={onBlurFunction}/> :
                <input autoComplete='off' id={name} type="text" value={value} onChange={onChangeInput}/>
            }

            <p className={'input__value-tag'}>{discr}</p>
        </div>
    )
}
