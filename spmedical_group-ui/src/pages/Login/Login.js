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
                <main>
                    <section>
                        <p>Bem vindo(a)! <br /> Faça login para acessar a sua conta.</p>

                        <form onSubmit={this.efetuaLogin}>
                            <input
                                type="text"
                                name="email"
                                value={this.state.email}
                                onChange={this.atualizaStateCampo}
                                placeholder="Email"
                            />

                            <div></div>
                            <input
                                type="password"
                                name="senha"
                                value={this.state.senha}
                                onChange={this.atualizaStateCampo}
                                placeholder="Senha"
                            />
                            <div></div>
                            <button type="submit">Login</button>
                            <p style={{color: 'red'}}>{this.state.erroMensagem}</p>

                        </form>
                    </section>
                </main>



            </div>
        )
    }
}