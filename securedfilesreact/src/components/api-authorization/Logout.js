import React from 'react'
import { Component } from 'react';
import { QueryParameterNames, LogoutActions, ApplicationPaths } from './ApiAuthorizationConstants';

// The main responsibility of this component is to handle the user's logout process.
// This is the starting point for the logout process, which is usually initiated when a
// user clicks on the logout button on the LoginMenu component.
export class Logout extends Component {
    constructor(props) {
        super(props);

        this.state = {
            message: undefined,
            isReady: false,
            authenticated: false
        };
    }

    componentDidMount() {
        const action = this.props.action;
        switch (action) {
            case LogoutActions.Logout:
                if (!!window.history.state.state.local) {
                    this.logout(this.getReturnUrl());
                } else {
                    // This prevents regular links to <app>/authentication/logout from triggering a logout
                    this.setState({ isReady: true, message: "The logout was not initiated from within the page." });
                }
                break;
            case LogoutActions.LogoutCallback:
                this.processLogoutCallback();
                break;
            case LogoutActions.LoggedOut:
                this.setState({ isReady: true, message: "You successfully logged out!" });
                break;
            default:
                throw new Error(`Invalid action '${action}'`);
        }

        this.populateAuthenticationState();
    }

    render() {
        const { isReady, message } = this.state;
        if (!isReady) {
            return <div></div>
        }
        if (!!message) {
            return (<div>{message}</div>);
        } else {
            const action = this.props.action;
            switch (action) {
                case LogoutActions.Logout:
                    return (<div>Processing logout</div>);
                case LogoutActions.LogoutCallback:
                    return (<div>Processing logout callback</div>);
                case LogoutActions.LoggedOut:
                    return (<div>{message}</div>);
                default:
                    throw new Error(`Invalid action '${action}'`);
            }
        }
    }    
}
