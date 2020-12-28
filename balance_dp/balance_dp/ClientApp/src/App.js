import React, {Component} from 'react';
import {Route} from 'react-router';
import {Home} from './components/Home.js';
import {Nav} from './components/Nav';
import {Calc} from "./components/Calc";
import './custom.css';
import {Help} from "./components/Help";
import {Footer} from "./components/Footer";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <>
                <div className='image__container'>
                    <div className='container'>
                        <Nav/>
                        <section className='content__container'>
                            <Route exact path='/' component={Home}/>
                            <Route exact path='/Calc' component={Calc}/>
                            <Route exact path='/Help' component={Help}/>
                        </section>
                    </div>
                    <Footer/>

                </div>

            </>
        );
    };
};
