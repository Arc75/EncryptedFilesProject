import React, { Component } from 'react';
import {variables} from './variables.js';

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  async getA() {
    debugger;
    let response = await fetch(variables.API_URL+'Files', {
      //mode:'no-cors',
      method: "GET",
      headers:{
        "Access-Control-Allow-Origin": "*",
        'Access-Control-Allow-Headers': "*",
        "Access-Control-Request-Method": "*",
        "Access-Control-Allow-Methods": "*"
      }
      })
    .then(response => response.json())
    .then(x=>{
      alert(x);
      document.getElementById('1234').innerHTML += x;
    });
 }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>
        <div id="1234"></div>

        <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
        <button onClick={this.getA}>aaa</button>
      </div>
    );
  }
}
