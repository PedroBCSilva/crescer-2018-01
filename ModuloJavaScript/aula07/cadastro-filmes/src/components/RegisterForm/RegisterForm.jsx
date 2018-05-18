import React from 'react'

import Button from '../generic/Button/Button'
import Input from '../generic/Input/Input'

export default class RegisterForm extends React.Component{
    
    render(){
        return (
            <div className="d-flex justify-content-center">
                <form>
                    <h1 className="display-4">Cadastro</h1>
                    <Input type="email" placeholder="Email aqui!" name="email" id="email" label="Email"/>
                    <Input type="text" placeholder="Nome aqui!" name="name" id="name" label="Nome"/>
                    <Input type="password" placeholder="Senha aqui!" name="password" id="password" label="Senha"/>
                    <Button type="button" typeButton="btn-primary" text="Registrar-se"/>
                    <Button type="button" onClick={this.props.onClick} id="LOGIN" typeButton="btn-primary" text="Voltar para login"/>
                </form>
            </div>
        )
    }
}