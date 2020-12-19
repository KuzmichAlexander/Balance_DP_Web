import React from "react";

export const OneInput = ({discr, name, text, value, onChangeInput}) => {
    return (
        <div className='input__container'>
            <p className={'input__description'}>{text}</p>
            <input id={name} type="text" value={value} onChange={onChangeInput}/>
            <p className={'input__value-tag'}>{discr}</p>
        </div>
    )
}
