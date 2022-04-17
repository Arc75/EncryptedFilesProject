import React from 'react'
import { Component } from 'react';
import { LoginActions, QueryParameterNames, ApplicationPaths } from './ApiAuthorizationConstants';
import { LoginComponent } from './AnimatedLogin';
import {variables} from './../variables.js';

// The main responsibility of this component is to handle the user's login process.
// This is the starting point for the login process. Any component that needs to authenticate
// a user can simply perform a redirect to this component with a returnUrl query parameter and
// let the component perform the login and return back to the return url.
export class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            message: undefined
        };
    }

    componentDidMount() {
        const action = this.props.action;
        switch (action) {
            case LoginActions.Login:
                    return ( <LoginComponent mode={'login'} onSubmit={ function() { debugger; console.log('submit'); } }/>);
                case LoginActions.Profile:
                case LoginActions.Register:
                    return (<LoginComponent mode={'signup'} onSubmit={ function() { debugger;  console.log('submit'); } }/>);
                default:
                    throw new Error(`Invalid action '${action}'`);
        }
    }

    render() {
        const action = this.props.action;
        const { message } = this.state;

        if (!!message) {
            return <div>{message}</div>
        } else {
            switch (action) {
                case LoginActions.Login:
                    return ( <LoginComponent mode={'login'} onSubmit={ this.Login()}/>);
                case LoginActions.Profile:
                case LoginActions.Register:
                    return (<LoginComponent mode={'signup'} onSubmit={ function() { console.log('submit'); } }/>);
                default:
                    throw new Error(`Invalid action '${action}'`);
            }
        }
    }
    
    async Login(email, pw){
        if (!email || !pw)
            return;
            
        alert("");
        debugger;
        let response = await fetch(variables.API_URL+variables.Login, {
            method: "POST",
            headers:{
                "Content-Type":"application/json",
                "Access-Control-Allow-Origin": "*",
                'Access-Control-Allow-Headers': "*",
                "Access-Control-Request-Method": "*",
                "Access-Control-Allow-Methods": "*"
            },
            body: JSON.stringify({Email: email, Password: pw })
            
        })
        .then(response => response.json())
        .then(x=>{
            alert(x);
            document.getElementById('1234').innerHTML += x;
        });
    }
}
