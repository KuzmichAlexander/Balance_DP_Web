import React from "react";
import { Link } from "react-router-dom";

export const Nav = () => {
    return (
        <div className='nav__container'>
            <nav>
                <Link to={'/'}>Описание</Link>
                <Link to={'/Calc'}>Рассчёт</Link>
                <Link to={'/Help'}>Справка</Link>
            </nav>
            <div className='logo'>

            </div>
        </div>
    )
}
