import React, { Component } from 'react';
import './App.css';

import RegisterForm from '../src/components/RegisterForm/RegisterForm'
import LoginForm from '../src/components/LoginForm/LoginForm'
import MovieTab from '../src/components/MoviesTab/MoviesTab'

const SELECTED_COMPONENTS={
  LOGIN:'LOGIN',
  REGISTERSCREEN: 'REGISTERSCREEN',
  MOVIESTAB: 'MOVIESTAB'
}

class App extends Component {

  constructor(){
    super()
    this.state={
      selectedComponent: SELECTED_COMPONENTS.LOGIN
    }
    this.onClickScreenChange=this.onClickScreenChange.bind(this)
    this.redirectTo=this.redirectTo.bind(this)
  }

  onClickScreenChange(event) {
    const target = event.target
    this.redirectTo(target.id)
  }

  redirectTo(id){
    this.setState({
      selectedComponent:id
    })
  }

  renderContent(){
    if(this.state.selectedComponent===SELECTED_COMPONENTS.LOGIN){
      return <LoginForm onClick={this.onClickScreenChange} redirectTo={this.redirectTo}/>
    }
    else if(this.state.selectedComponent===SELECTED_COMPONENTS.REGISTERSCREEN){
      return <RegisterForm onClick={this.onClickScreenChange} redirectTo={this.redirectTo}/>
    }
    else if(this.state.selectedComponent===SELECTED_COMPONENTS.MOVIESTAB){
      return <MovieTab redirectTo={this.redirectTo}/>
    }
  }


  render() {
    return (
      <div className="App">
        {this.renderContent()}
      </div>
    );
  }
}

export default App;
