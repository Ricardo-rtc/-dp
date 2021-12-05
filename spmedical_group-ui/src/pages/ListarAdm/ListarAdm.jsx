import '../../assets/css/home.css'
import '../../assets/css/footer.css'
import '../../assets/css/consultas-listar.css'
import Header from '../../components/header/header';
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import api from '../../services/api';


export default function ListarAdm() {

    const [listaConsultasAdm, setListaConsultasAdm] = useState([]);
    // const [ isLoading, setIsLoading ] = useState( false );

    function buscarConsultasAdm() {
        console.log('vamos fazer a chamada para a API');

        api.get('/Consulta/listarTodos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultasAdm(resposta.data)
                }
            })

            // caso ocorra algum erro, exibe no console do navegador este erro
            .catch(erro => console.log(erro));
    };

    // estrutura do Hook useEffect
    // useEffect( efeito, causa )
    // useEffect( { o que vai ser feito }, { o que será escutado } )
    // dessa forma, 
    useEffect(buscarConsultasAdm, []);


    return (
        <div>
            <Header />
            <main className="main_listar">
                <div className="container container_consultas">
                    <h1>Consultas</h1>
                    {
                        listaConsultasAdm.map((Consulta) => {
                            return (

                                <div className="box_consulta" key={Consulta.idConsulta}>
                                    <div className="space">
                                        <h2 className="h2_consulta" >Consulta {Consulta.idConsulta}</h2>
                                        
                                    </div>
                                    <div className="box_info">
                                        <h3>Data</h3>
                                        <p>{Intl.DateTimeFormat("pt-BR", {
                                            year: 'numeric', month: 'short', day: 'numeric',
                                            hour: 'numeric', minute: 'numeric',
                                            hour12: true
                                        }).format(new Date(Consulta.dataConsulta))}</p>
                                        <h3>Descrição</h3>
                                        <p>{Consulta.descricao}</p>
                                        <h3>Situação</h3>
                                        <p>{Consulta.idSituacaoNavigation.situacao1}</p>
                                    </div>
                                    <h2 className="h2_consulta">Paciente</h2>
                                    <div className="box_info">
                                        <h3>Nome</h3>
                                        <p>{Consulta.idPacienteNavigation.nomePaciente}</p>
                                        <h3>RG</h3>
                                        <p>{Consulta.idPacienteNavigation.rg}</p>
                                        <h3>CPF</h3>
                                        <p>{Consulta.idPacienteNavigation.cpf}</p>
                                        <h3>Data Nascimento</h3>
                                        <p>{Intl.DateTimeFormat("pt-BR", {
                                            year: 'numeric', month: 'short', day: 'numeric',

                                        }).format(new Date(Consulta.idPacienteNavigation.dataNasc))}</p>
                                        <h3>Telefone</h3>
                                        <p>{Consulta.idPacienteNavigation.telefone}</p>
                                    </div>
                                    <h2 className="h2_consulta">Médico</h2>
                                    <div className="box_info">
                                        <h3>Nome</h3>
                                        <p>{Consulta.idMedicoNavigation.nomeMed}</p>
                                        <h3>CRM</h3>
                                        <p>{Consulta.idMedicoNavigation.crm}</p>
                                        <h3>Especialidade</h3>
                                        <p>{Consulta.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</p>
                                    </div>
                                </div>
                            )
                        })}


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
