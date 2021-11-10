import '../../assets/css/login.css'
import '../../assets/css/header.css'
import Header_top from '../../components/header/header'; 


import { Component } from "react";
import axios from 'axios';

export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: 'saulo@hotmail.com',
            senha: 'saulo123',
            erroMensagem: ''
        };
    };

    efetuaLogin = (event) => {
        this.setState({ erroMensagem: " " })
        event.preventDefault();
        axios.post('http://localhost:5000/api/login', {
            email: this.state.email,
            senha: this.state.senha
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log("Meu token é: " + resposta.data.token)
                    localStorage.setItem('usuario-token', resposta.data.token)
                }
            })

            .catch(() => {
                this.setState({ erroMensagem: "E-mail ou senha inválidos!" })
            })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (
            <div>
                <Header_top>

                </Header_top>
                <main>
                    <div className="cor">
                        <div className="container container_consultas">
                            <h1>Login</h1>
                            <div class="box_login fundo">
                                <form class="box_info" onSubmit={this.efetuaLogin}>
                                    <input 
                                    type="text"
                                    name="email"
                                    value={this.state.email}
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Email"
                                    />
                                    <input 
                                    type="password"
                                    name="senha"
                                    value={this.state.senha}
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Senha"/>
                                    <button type="submit">Entrar</button>
                                </form>
                                    <p style={{color: 'red', fontSize:'25px'}}>{this.state.erroMensagem}</p>
                            </div>
                        </div>
                    </div>
                </main>



            </div>
    )}
}