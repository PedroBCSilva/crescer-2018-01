import React from 'react'

export default class Error extends React.Component{
    render(){
        return <div className="alert alert-danger" role="alert">
        {this.props.error}
        </div>
    }
}