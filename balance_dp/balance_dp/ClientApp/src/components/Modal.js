import React, {useState, useEffect} from "react";
import {withMobileDialog} from "@material-ui/core";

const block = ['/', ':', '\\', '*', '?', '"', '<', '>', '|'];

export const CustomModal = ({onToggle, saveParams, type, nameParams, fetch, isSave, isSemi, reWriteParams}) => {
    let select = null;
    const [name, setName] = useState('');
    const [warning, setWarning] = useState(false);
    useEffect(() => {
        if (nameParams)
            setName(nameParams[0] || 'сервер не отвечает');
    }, []);

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

    console.log(type)

    let content;

    switch (type) {
        case 'save':
            return ( <div className='modal-wrapper' onClick={onToggle}>
                <div className="modal-custom" onClick={event => event.stopPropagation()}>
                    <><h2>Сохранение входных параметров</h2>
                        <p>Введите имя для текущих параметров, чтобы в будущем их можно было использовать повторно:</p>
                        <input placeholder={'Имя для схранения параметров'} className={'modal-custom__input'}
                               type="text"
                               value={name} onChange={nameChanger}/>
                        <input value={'Сохранить'} className={'modal-custom__button'} type="button"
                               onClick={() => saveParams(name)}/>
                        {warning ? <p>Символы, запрещенные для ввода: {block.map(item => <code>{item} </code>)} </p>
                            : null}
                        {isSave ? <p style={{color: 'green'}}>Успешно сохранено!</p> : null}
                        {isSemi ? <><p style={{color: 'red'}}>Параметры с таким именем уже существуют, хотите их
                            перезаписать?</p>
                            <input value={'Перезаписать'} className={'modal-custom__button'} type="button"
                                   onClick={() => reWriteParams(name)}/>
                        </> : null}
                    </>
                </div>
            </div> )
        case "delete":
            return ( <div className='modal-wrapper' onClick={onToggle}>
                <div className="modal-custom" onClick={event => event.stopPropagation()}>
                    <><h2>Удаление входных параметров</h2>
                        <select onChange={selectChange} value={name} className={'modal__select'}>{nameParams.map(elem => {
                            return <option key={elem + Math.random() * 42} value={elem}>{elem}</option>
                        })}</select>

                        <input value={'Удалить'} className={'modal-custom__button'} type="button"
                               onClick={() => saveParams(name)}/>
                        {isSave ? <p style={{color: 'green'}}>Успешно сохранено!</p> : null}
                    </>
                </div>
            </div> )
        default:
            return ( <div className='modal-wrapper' onClick={onToggle}>
                <div className="modal-custom" onClick={event => event.stopPropagation()}>
                    <>
                        <h2>Загрузка исходных данных</h2>
                        <p>Выберите данные для расчёта. Если вы впервые пользуетесь программой, рекомендуем использовать
                            "Ознакомительный"</p>
                        <select onChange={selectChange} value={name} className={'modal__select'}>{nameParams.map(elem => {
                            return <option key={elem + Math.random() * 42} value={elem}>{elem}</option>
                        })}</select>
                        <input value={'Выбрать'} className={'modal-custom__button'} type="button"
                               onClick={() => {
                                   onToggle();
                                   fetch(name);
                               }}/>
                    </>
                </div>
            </div>)
    }
};
