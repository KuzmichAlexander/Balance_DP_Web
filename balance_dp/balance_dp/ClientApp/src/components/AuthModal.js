import React, {useState} from 'react';
import {auth} from "../DAl/api";

export const AuthModal = ({toggle, setName}) => {
    const [login, setLogin] = useState('');
    const [pass, setPass] = useState('');
    const [warn, setWarn] = useState('');

    const getAuth = async (e) => {
        e.preventDefault();
        const data = await auth(login, pass);

        if (!data.isAuth) {
            setWarn('Неверный логин или пароль');
            return;
        }

        localStorage.setItem('token', data.Token);
        setName(data.Name);
        toggle();

    }

    return (
        <div onClick={() => toggle()} className={'modal-wrapper'}>
            <div onClick={e => e.stopPropagation()} className={'auth-modal'}>
                <form onSubmit={getAuth} className={'auth-form'}>
                    <h2>Авторизация</h2>
                    <label className={'form-label'}>
                        <p>Логин</p>
                        <input type="text" value={login} onChange={(e) => setLogin(e.target.value)}/>
                    </label>
                    <label className={'form-label'}>
                        <p>Пароль</p>
                        <input type="password" value={pass} onChange={(e) => setPass(e.target.value)}/>
                    </label>
                    {warn ? <p className={'message-warning'}>{warn}</p> : null}
                    <button type={'submit'} className={'submit-button'}>Войти</button>
                </form>


            </div>
        </div>
    );
};
