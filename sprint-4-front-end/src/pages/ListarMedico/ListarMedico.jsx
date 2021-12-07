import '../../assets/css/home.css'
import '../../assets/css/footer.css'
import '../../assets/css/consultas-listar.css'
import Lapis from '../../assets/img/lapis.png';
import Header from '../../components/header/header';

import { Link } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import api from '../../services/api';


export default function ListarMedico() {

    const [listaConsultasMedico, setListaConsultasMedico] = useState([]);
    const [descricao, setDescricao] = useState("");
    // const [ isLoading, setIsLoading ] = useState( false );

    function buscarConsultasMedico() {


        api.get('/Consulta/minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultasMedico(resposta.data)
                    console.log(resposta.data)
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

    function atualizarDescricao(idConsulta) {

        api.patch("/Consulta/descricao/" + idConsulta, {
            descricaoConsulta: descricao
        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log("descricao da consulta" + idConsulta + "atualizada");
                    // document.getElementById(idConsulta).setAttribute("readOnly");
                    var btn = document.getElementById("btn" + idConsulta)
                    btn.style.display = "none";
                    buscarConsultasMedico();
                    setDescricao("")
                }
            }).catch(erro => console.log(erro))
    }

    function permitirTextArea(idConsulta, descricaoConsulta) {
        // console.log("Você está editando a situação da consulta " + idConsulta + "e a situação é " + idSituacao)
        setDescricao(descricaoConsulta);
        console.log(descricaoConsulta)
        var textoDescricao = document.getElementById("descricao" + idConsulta)
        // textoDescricao.removeAttribute("readOnly");
        // descricao = descricaoConsulta
        document.getElementById("descricao" + idConsulta).value = descricaoConsulta

        if (textoDescricao.value === null || textoDescricao.value === "") {
            textoDescricao.value = "Consulta sem descrição";

        }
        var btn = document.getElementById("btn" + idConsulta);

        if (btn.style.display === "none") {
            btn.style.display = "";
            textoDescricao.removeAttribute("readOnly");
        } else {

            document.getElementById("descricao" + idConsulta).setAttribute("readOnly", "readOnly");

            setDescricao("")
            btn.style.display = "none";
        }


    }


    return (
        <div>
            <Header />
            <main className="main_listar">
                <div className="container container_consultas">
                    <h1>Consultas</h1>
                    {
                        listaConsultasMedico.map((Consulta) => {
                            return (
                                <div className="box_consulta" key={Consulta.idConsulta}>
                                    <div className="space">
                                        <h2 className="h2_consulta" >Consulta {Consulta.idConsulta}</h2>
                                        <button onClick={() => permitirTextArea(Consulta.idConsulta, Consulta.descricao)} type="button" className="vazio"><img className="lapis" src={Lapis} alt="Alterar situação" /></button>

                                    </div>
                                    <div className="box_info">
                                        <h3>Data</h3>
                                        <p>{Intl.DateTimeFormat("pt-BR", {
                                            year: 'numeric', month: 'short', day: 'numeric',
                                            hour: 'numeric', minute: 'numeric',
                                            hour12: true
                                        }).format(new Date(Consulta.dataConsulta))}</p>
                                        <h3>Descrição</h3>
                                        {/* <p id={"desc"+ Consulta.idConsulta}>{Consulta.descricao}</p> */}
                                        <textarea name="descricao" className="descricao" id={"descricao" + Consulta.idConsulta}
                                            cols="1" rows="5" readOnly defaultValue={Consulta.descricao} onChange={(campo) => setDescricao(campo.target.value)}></textarea>
                                        <button onClick={() =>atualizarDescricao(Consulta.idConsulta)} style={{ display: "none" }} id={"btn" + Consulta.idConsulta} className="btn_home">ATUALIZAR</button>
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

                                </div>
                            )
                        })}

                    <Link to='/'><button className="btn_home">VOLTAR</button></Link>
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

