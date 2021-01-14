import React, {useState} from "react";

const block = ['/', ':', '\\', '*', '?', '"', '<', '>', '|'];

export const CustomModal = ({onToggle, saveParams, type, nameParams, fetch}) => {
    console.log(type, nameParams)
    let select = null;
    if (type) {
        select = nameParams.map(elem => {
            return <option value={elem}>{elem}</option>
        })
    }
    let [name, setName] = useState('');
    let [warning, setWarning] = useState(false);

    function selectChange(e) {
        setName(e.target.value);
    }

    function nameChanger(e) {
        let isContain = false;
        const value = e.target.value;
        block.forEach(item => {
            if (value.includes(item)) isContain = true;
        })
        if (isContain) {
            setWarning(true);
            return;
        }
        setName(e.target.value);
    }

    return (
        <div className='modal-wrapper' onClick={onToggle}>
            <div className="modal-custom" onClick={event => event.stopPropagation()}>
                {!type ? <><h2>Сохранение входных параметров</h2>
                        <p>Введите имя для текущих параметров, чтобы в будущем их можно было использовать повторно:</p>
                        <input placeholder={'Имя для схранения параметров'} className={'modal-custom__input'} type="text"
                               value={name} onChange={nameChanger}/>
                        <input value={'Сохранить'} className={'modal-custom__button'} type="button"
                               onClick={() => saveParams(name)}/>
                        {warning ? <p>Символы, запрещенные для ввода: {block.map(item => <code>{item} </code>)} </p>
                            : null} </> :
                    <>
                        <p>Выберите данные для расчёта:</p>
                        <select onChange={selectChange}>{select}</select>
                        <input value={'Выбрать'} className={'modal-custom__button'} type="button"
                               onClick={() => fetch(name)}/>
                    </>
                }</div>
        </div>
    )
};
