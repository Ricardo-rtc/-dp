
import Logo from '../../assets/img/Logo-full.png'
import Menu from '../../assets/img/menu-hamb.png'

import React,{Component} from "react";
import { Link } from 'react-router-dom';

class Header_top extends Component{

 

toggleMenu = () => {

    const nav = document.getElementById('nav');
    nav.classList.toggle('active');

}


   render(){

       return (
                <header>
                <div className="container container_header">
                    <button id="btnMenu" onClick={() => this.toggleMenu()} >
                        <img className="menu-hamb" src={Menu} alt="Menu Hamburguer" />
                    </button>
                    <nav id="nav">
                        <ul id="menu">
                            <Link to="/">Home</Link>
                            <Link to="/">Cadastrar</Link>
                            <Link to="/">Listar</Link>
                        </ul>

                    </nav>
                            <Link to="/"><img className="logo" src={Logo} alt="Logo completo" /></Link>
                    <span></span>
                    <Link to="/login"  className="login">{this.props.Login}</Link>
                </div>
            </header>               

       )
   }
}

export default Header_top









