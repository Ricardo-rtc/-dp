import Logo from '../../assets/img/Logo-full.png';
import Menu from '../../assets/img/menu-hamb.png';
import Home from '../../pages/Home/Home.jsx';

import { Route, Redirect } from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from '../../services/auth.js';

import React, { Component } from "react";
import { Link } from 'react-router-dom';

export default class Header extends Component {

        
    toggleMenu = () => {

        const nav = document.getElementById('nav');
        nav.classList.toggle('active');
    }

    listar = () => { 
        
        console.log("logou")
        switch (parseJwt().role) {
            case '1':
                // verifica se o usuário logado é do tipo paciente
                <Redirect to="/listarPaciente"  /> 
                console.log('estou logado: ' + usuarioAutenticado())
                
                break;
                case '2':
                    // verifica se o usuário logado é do tipo administrador
                    <Redirect to="/listarAdm"  />
                console.log('estou logado: ' + usuarioAutenticado())

                break;
            case '3':
                // verifica se o usuário logado é do tipo médico
                <Redirect to="/listarMedico" />
                console.log('estou logado: ' + usuarioAutenticado())
                break;
            default:
                <Route exact path="/" component={Home} />
                console.log('estou logado: ' + usuarioAutenticado())
                break;
        }
    }

    render() {

        return (
            <header>
                <div className="container container_header">
                    <button id="btnMenu" onClick={() => this.toggleMenu()} >
                        <img className="menu-hamb" src={Menu} alt="Menu Hamburguer" />
                    </button>
                    <nav id="nav">
                        <ul id="menu">
                            <Link to="/">Home</Link>
                            <Link to="/cadastrar">Cadastrar</Link>
                            <button onClick={() => this.listar()}>Listar</button>
                            
                        </ul>

                    </nav>
                    <Link to="/"><img className="logo" src={Logo} alt="Logo completo" /></Link>
                    <span></span>
                    <Link to="/login" className="login">{this.props.Login}</Link>
                </div>
            </header>

        )
    }
}

