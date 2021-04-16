import React, {useState} from 'react';
import {registration} from "../DAl/api";

export const RegistrationView = () => {
    const [name, setName] = useState('');
    const [login, setLogin] = useState('');
    const [pass, setPass] = useState('');
    const [serverAnswer, setServerAnswer] = useState('');

    const [accept, setAccept] = useState(true);

    const acceptChange = () => {
        setAccept(prev => !prev);
    }

    const regUser = async (e) => {
        e.preventDefault();
        const response = await registration(login, pass, name);
        console.log(response)
        setServerAnswer(response)
    }


    return (
        <div className={'container'}>
            <form className={'reg-form'} onSubmit={regUser}>
                <label className={'reg-label'}>
                    <p>Имя</p>
                    <input type="text" value={name} onChange={e => setName(e.target.value)}/>
                </label>
                <label className={'reg-label'}>
                    <p>Логин</p>
                    <input type="text" value={login} onChange={e => setLogin(e.target.value)}/>
                </label>
                <label className={'reg-label'}>
                    <p>Пароль</p>
                    <input className={'pass'} type="password" value={pass} onChange={e => setPass(e.target.value)}/>
                </label>
                <label className={'input__container'}>
                    <input type="checkbox" className="custom-checkbox" id="happy" name="happy" value="yes" />
                    <label onClick={acceptChange} className={'custom-checkbox-label'} htmlFor="happy">Обязуюсь подарить автору печеньки</label>
                </label>
                {serverAnswer ? <p className={serverAnswer.includes('уже') ? "message-warning" : "message-success"}>{serverAnswer}</p> : null}
                <button disabled={accept} className={'submit-button'} type={'submit'}>Зарегистрироваться</button>
            </form>
        </div>
    );
};
