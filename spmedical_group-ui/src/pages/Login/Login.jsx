import '../../assets/css/login.css'
import '../../assets/css/header.css'
import HeaderTop from '../../components/header/header';
import { parseJwt, usuarioAutenticado } from '../../services/auth';


import { Component } from "react";
import axios from 'axios';

export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: 'saulo@hotmail.com',
            senha: 'saulo123',
            erroMensagem: '',
            isLoading: false
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
                    this.setState({ isLoading: false });

                    console.log(localStorage.getItem('usuario-token'))

                    switch (parseJwt().role) {
                        case '1':
                            // verifica se o usuário logado é do tipo paciente
                            this.props.history.push('/listarPaciente');
                            console.log('estou logado: ' + usuarioAutenticado())
                            
                            break;
                            case '2':
                            // verifica se o usuário logado é do tipo administrador
                            this.props.history.push('/listarAdm');
                            console.log('estou logado: ' + usuarioAutenticado())
                            
                            break;
                            case '3':
                            // verifica se o usuário logado é do tipo médico
                            this.props.history.push('/listarMedico');
                            console.log('estou logado: ' + usuarioAutenticado())
                            break;
                        default:
                            this.props.history.push('/');
                            console.log('estou logado: ' + usuarioAutenticado())
                            break;
                    }
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
                <HeaderTop />

                <main className="main_login">
                    <div className="cor_login">
                        <div className="container container_consultas">
                            <h1 className="h1_login">Login</h1>
                            <div className="box_login fundo">
                                <form className="box_info" onSubmit={this.efetuaLogin}>
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
                                        placeholder="Senha" />
                                    <button type="submit">Entrar</button>
                                </form>
                                <p style={{ color: 'red', fontSize: '25px' }}>{this.state.erroMensagem}</p>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        )
    }
}