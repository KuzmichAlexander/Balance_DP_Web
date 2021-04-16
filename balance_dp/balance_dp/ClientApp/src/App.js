import React, {Component} from 'react';
import {Route} from 'react-router';
import {Home} from './components/Home.js';
import {Nav} from './components/Nav';
import {Calc} from "./components/Calc";
import './custom.css';
import {Help} from "./components/Help";
import {Footer} from "./components/Footer";
import {RegistrationView} from "./components/RegistrationView";
import {tokenAuth} from "./DAl/api";

export default class App extends Component {
    state = {
        name: ''
    }
    static displayName = App.name;
    async componentDidMount() {
        const token = localStorage.getItem('token');
        if (token) {
            const data = await tokenAuth(token);
            this.setState({name: data.name})
        }
    }

    setName = (newName) => {
        this.setState({name: newName})
    }

    render() {
        return (
            <>
                <div className='image__container'>
                    <div className='container'>
                        <Nav name={this.state.name} setName={this.setName}/>
                        <section className='content__container'>
                            <Route exact path='/' component={Home}/>
                            <Route exact path='/Calc' component={Calc}/>
                            <Route exact path='/Help' component={Help}/>
                            <Route exact path='/Reg' component={RegistrationView}/>
                        </section>
                    </div>
                    <Footer/>

                </div>

            </>
        );
    };
};
