import React, {Component} from 'react';
import {Route} from 'react-router';
import {Home} from './components/Home.js';
import {Nav} from './components/Nav';

import './custom.css'
import {Calc} from "./components/Colc";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <div className='image__container'>
            <div className='container'>
                <Nav />
                <section className='content__container'>
                    <Route exact path='/' component={Home}/>
                    <Route exact path='/Calc' component={Calc}/>
                </section>
            </div>
            </div>
        );
    }
}
