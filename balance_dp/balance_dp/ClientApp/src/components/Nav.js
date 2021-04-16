import React, {useState} from "react";
import {Link} from "react-router-dom";
import {AuthModal} from "./AuthModal";
import { Redirect } from 'react-router-dom';

export const Nav = ({name, setName}) => {
    const [authModal, setAuthModal] = useState(false);
    const [leaveFlag, setLeaveFlag] = useState(false);

    if (leaveFlag) {
        console.log('попал')
        setLeaveFlag(false);
        return <Redirect to={'/Reg'} />
    }

    const toggleModal = () => {
        setAuthModal(!authModal);
    }

    const userLeave = () => {
        setName('');
        localStorage.removeItem('token');
        setLeaveFlag(true)
    }


    return (
        <div className='nav__container'>
            <nav>
                <Link to={'/'}>Описание</Link>
                <Link to={'/Calc'}>Расчёт</Link>
                <Link to={'/Help'}>Справка</Link>
                {name ? <a onClick={userLeave}>Выйти</a> : <a onClick={() => toggleModal()}>Авторизация</a>}
                {name ? null : <Link to={'/Reg'}>Регистрация</Link>}
            </nav>
            {name
                ? <div style={{marginRight: 20, fontSize: '18px'}}>Здраствуйте, {name}</div>
                : <div className='logo'> </div>}

            {authModal ? <AuthModal setName={setName} toggle={toggleModal}/> : null}
        </div>
    )
}
