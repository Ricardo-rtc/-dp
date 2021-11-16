import '../../assets/css/cadastro.css'
import '../../assets/css/footer.css'
import Header from '../../components/header/header';

import { Component } from "react";
// import axios from 'axios';

export default class Cadastrar extends Component {

    render() {
        return (
            <div>
                <Header></Header>
                <main className="main_cadastro">
        <div className="container container_consultas">
            <h1>Cadastrar Consulta</h1>
            <div className="box_consulta">
                <form className="box_info-cadastro">
                    <input type="date" placeholder="Data"></input>
                    <input type="time" placeholder="Hora"></input>
                    <input type="text" placeholder="Paciente"></input>
                    <input type="text" placeholder="Médico"></input>
                    <button type="submit">Cadastrar</button>
                    
                </form>
                </div>
            </div>
        </main>
        
        <footer>
            <div className="container container_footer">
                <span className="span_footer">
                    ©2020 Cia. da Consulta - Todos os direitos reservados
                </span>
                <span className="span_footer">
                    Os médicos da Central de Consultas são especialistas ou estão em conclusão de sua pós-graduação.
                </span>
            </div>
        </footer>
            </div>
        )
    }
}