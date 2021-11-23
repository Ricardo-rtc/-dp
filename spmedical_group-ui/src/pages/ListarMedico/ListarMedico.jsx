import '../../assets/css/home.css'
import '../../assets/css/footer.css'
import '../../assets/css/consultas-listar.css'
import Lapis from '../../assets/img/lapis.png';
import Header from '../../components/header/header';

import { Link } from 'react-router-dom';    
import axios from 'axios';
import React, { useState, useEffect } from 'react';


export default function ListarMedico(){
    
    const [listaConsultasMedico, setListaConsultasMedico] = useState([]);
    // const [ isLoading, setIsLoading ] = useState( false );

    function buscarConsultasMedico() {
        

        axios('http://localhost:5000/api/Consulta/minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultasMedico(resposta.data)
                }
            })

            // caso ocorra algum erro, exibe no console do navegador este erro
            .catch(erro => console.log(erro));
    };

    // estrutura do Hook useEffect
    // useEffect( efeito, causa )
    // useEffect( { o que vai ser feito }, { o que será escutado } )
    // dessa forma, 
    useEffect(buscarConsultasMedico, []);

 
    return (
        <div>
        <Header/>
        <main className="main_listar">
        <div className="container container_consultas">
            <h1>Consultas</h1>
            {
                            listaConsultasMedico.map((Consulta) => {
                                return (
                                <div className="box_consulta" key={Consulta.idConsulta}>
                                    <h2 className="h2_consulta">Consulta {Consulta.idConsulta}</h2>
                                    <div  className="box_info">
                                        <p>Data</p>
                                        <span>{ Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'short', day: 'numeric',
                                                hour: 'numeric', minute: 'numeric',
                                                hour12: true                                                
                                            }).format(new Date(Consulta.dataConsulta)) }</span>
                                        <p>Descrição</p>
                                        <span className="space">{Consulta.descricao} <img className="lapis" src={Lapis} alt="Alterar Descrição" /></span>
                                        <p>Situação</p>
                                        <span className="space">{Consulta.idSituacaoNavigation.situacao1}<img className="lapis" src={Lapis} alt="Alterar situação" /></span>
                                    </div>
                                        <h2 className="h2_consulta">Paciente</h2>
                                    <div  className="box_info">
                                        <p>Nome</p>
                                        <span>{Consulta.idPacienteNavigation.nomePaciente}</span>
                                        <p>RG</p>
                                        <span>{Consulta.idPacienteNavigation.rg}</span>
                                        <p>CPF</p>
                                        <span>{Consulta.idPacienteNavigation.cpf}</span>
                                        <p>Data Nascimento</p>
                                        <span>{ Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'short', day: 'numeric',
                                                                                              
                                            }).format(new Date(Consulta.idPacienteNavigation.dataNasc))}</span>
                                        <p>Telefone</p>
                                        <span>{Consulta.idPacienteNavigation.telefone}</span>
                                        </div>
                                        
                                </div>
                                )})}
            
                <Link to='/'><button className="btn_home">Voltar</button></Link>
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

