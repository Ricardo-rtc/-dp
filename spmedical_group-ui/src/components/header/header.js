import React, { useState } from 'react';

import Logo from '../../assets/img/Logo-full.png'
import MenuHamb from '../../assets/img/menu-hamb.png'


import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';

import { Link } from 'react-router-dom';



function Header_top() {
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    


    

        return (
            <header>
                <div className="container container_header">
                    <Button
                        id="basic-button"
                        aria-controls="basic-menu"
                        aria-haspopup="true"
                        aria-expanded={open ? 'true' : undefined}
                        onClick={handleClick}
                    >
                        <img className="menu-hamb" src={Menu} alt="Menu Hamburguer" />
                    </Button>
                    <Menu
                        id="basic-menu"
                        anchorEl={anchorEl}
                        open={open}
                        onClose={handleClose}
                        MenuListProps={{
                            'aria-labelledby': 'basic-button',
                        }}
                    >
                        <MenuItem onClick={handleClose}>Profile</MenuItem>
                        <MenuItem onClick={handleClose}>My account</MenuItem>
                        <MenuItem onClick={handleClose}>Logout</MenuItem>
                    </Menu>
                    <button id="btnMenu" onClick={() => this.toggleMenu()} >
                        <img className="menu-hamb" src={MenuHamb} alt="Menu Hamburguer" />
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
                    <Link to="/login" className="login">{this.props.Login}</Link>
                </div>
            </header>

        )   
}

export default Header_top









