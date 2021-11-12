import '../../assets/css/home.css'
import '../../assets/css/footer.css'
import '../../assets/css/consultas-listar.css'
import HeaderTop from '../../components/header/header';

import { Component } from "react";
import { Link } from 'react-router-dom';


export default class Home extends Component {

  render() {
    return (
        <div>
        <HeaderTop/>
        <main className="main_listar">
        <div className="container container_consultas">
            <h1>Consultas</h1>
            <div className="box_consulta">
                <h2>Consulta</h2>
                <div class="box_info">
                    <span>Data</span>
                    <span>Hora</span>
                    <span>Situação</span>
                    <span id="descricao">Descrição</span>
                </div>
                <h2>Paciente</h2>
                <div class="box_info">
                    <span>Nome</span>
                    <span>Data de Nascimento</span>
                    <span>Telefone</span>
                    <span>RG</span>
                    <span>CPF</span>
                </div>
                <h2>Médico</h2>
                <div class="box_info">
                    <span>Nome</span>
                    <span>CRM</span>
                    <span>Especialidade</span>
                </div>
                <Link to='/'><button>Voltar</button></Link>
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
