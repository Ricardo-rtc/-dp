
import Logo from '../../assets/img/Logo-full.png'
import Menu from '../../assets/img/menu-hamb.png'

import React,{Component} from "react";

class Header_top extends Component{

 

toggleMenu = () => {

    const nav = document.getElementById('nav');
    nav.classList.toggle('active');

}


   render(){

       return (
                <header>
                <div className="container container_header">
                    <a id="btnMenu" onClick={() => this.toggleMenu()} >
                        <img className="menu-hamb" src={Menu} alt="Menu Hamburguer" />
                    </a>
                    <nav id="nav">
                        <ul id="menu">
                            <a href="">Home</a>
                            <a href="">Cadastrar</a>
                            <a href="">Listar</a>
                        </ul>

                    </nav>
                    <img className="logo" src={Logo} alt="Logo completo" />
                    <a href="" className="login"></a>
                    <a href="" className="login"></a>
                </div>
            </header>               

       )
   }
}

export default Header_top









