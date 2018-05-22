import React from 'react'

import {Input, Label, Button } from 'reactstrap';
import LoginService from '../../../service/LoginService'

import { Redirect } from 'react-router-dom'


import './Login.css'

export default class Login extends React.Component{

    constructor(){
        super()
        this.state = {
            email:'',
            password:'',
            goPostList:false
        }
        this.handleChange=this.handleChange.bind(this)
        this.onSubmit = this.onSubmit.bind(this)
    }

    onSubmit(e){
        LoginService.login(this.state.email,this.state.password)
            .then((result)=>{
                localStorage.accessToken=result.data.accessToken
                localStorage.userEmail = this.state.email
                localStorage.id = result.data.id
                console.log(result)
                this.setState({
                    goPostList:true
                })
            }).catch((error)=>{
                console.log(error)
            })
    }

    handleChange(event){
        const target = event.target
        const value = target.value
        const name = target.name
        this.setState({
            [name]: value
        })
    }

    render(){
        return (
            <div className="login-container">
                {this.state.goPostList?<Redirect to="/posts"/>:undefined}
                <div className="login-form">
                    <Label for="email">Email</Label>
                    <Input type="email" id="email" placeholder="email@here" onChange={this.handleChange} name="email"/>

                    <Label for="password">Password</Label>
                    <Input type="password" id="password" placeholder="password here!" onChange={this.handleChange} name="password"/>
            
                    <Button color="success" onClick={this.onSubmit}>Login</Button>
                </div>
            </div>
        )
    }
}