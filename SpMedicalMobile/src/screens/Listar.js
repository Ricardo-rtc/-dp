import React, {Component} from 'react';
import {
    Image,
    FlatList,
    StyleSheet,
    Text,
    View,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';
import { ScrollView } from 'react-native-gesture-handler';

export default class Listar extends Component {

    constructor(props) {
        super(props);
        this.state = {
            listaMedico: [],
        };
    }

    buscarConsultas = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');
            const resposta = await api.get('/consulta/minhas', {
                headers: {
                    Authorization: 'Bearer ' + token,
                },
            });

            if (resposta.status === 200) {
                const dadosDaApi = resposta.data;
                this.setState({ listaMedico: dadosDaApi });
            }
        } catch (error) {
            console.warn(error);
        }
    };

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <View style={styles.overlay}>
                
                    <View style={styles.main}>
                        <Image
                            source={require('../../assets/img/logo.png')}
                            style={styles.mainImgLogin}
                        />
                        <View style={styles.Container}>

                            <View style={styles.Box_tiutlo}>
                                <Text style={styles.Titulo}>
                                    {'Consultas'.toUpperCase()}
                                </Text>
                            </View>

                            <FlatList
                                data={this.state.listaMedico}
                                keyExtractor={item => item.idConsulta}
                                renderItem={this.renderItem}
                            />
                        </View>
                    </View>
            </View>
        );
    }

    renderItem = ({ item }) => (
        <View>
            <View style={styles.ListarDiv}>
                <View style={styles.Box_Projeto}>
                    <Text style={styles.ListagemNome}>{'CONSULTA '+ item.idConsulta }</Text>
                </View>

                <Text style={styles.ListagemTitulo}>Data</Text>
                <Text style={styles.ListagemDados}>{Intl.DateTimeFormat("pt-BR", {
                                year: 'numeric', month: 'numeric', day: 'numeric',
                                hour: 'numeric', minute: 'numeric',
                                hour12: true                                                
                            }).format(new Date(item.dataConsulta))}</Text>
                <Text style={styles.ListagemTitulo}>Descrição</Text>
                <Text style={styles.ListagemDados}>{item.descricao}</Text>
                <Text style={styles.ListagemTitulo}>Situação</Text>
                <Text style={styles.ListagemDados}>{item.idSituacaoNavigation.situacao1}</Text>

                <Text style={styles.ListagemNome}>PACIENTE</Text>
                <Text style={styles.ListagemTitulo}>Nome</Text>
                <Text style={styles.ListagemDados}>{item.idPacienteNavigation.nomePaciente}</Text>
                <Text style={styles.ListagemTitulo}>RG</Text>
                <Text style={styles.ListagemDados}>{item.idPacienteNavigation.rg}</Text>
                <Text style={styles.ListagemTitulo}>CPF</Text>
                <Text style={styles.ListagemDados}>{item.idPacienteNavigation.cpf}</Text>
                <Text style={styles.ListagemTitulo}>Data Nascimento</Text>
                <Text style={styles.ListagemDados}>{Intl.DateTimeFormat("pt-BR", {
                                            year: 'numeric', month: 'short', day: 'numeric',

                                        }).format(new Date(item.idPacienteNavigation.dataNasc))}</Text>
                <Text style={styles.ListagemTitulo}>Telefone</Text>
                <Text style={styles.ListagemDados}>{item.idPacienteNavigation.telefone}</Text>

                <Text style={styles.ListagemNome}>MÉDICO</Text>
                <Text style={styles.ListagemTitulo}>Nome</Text>
                <Text style={styles.ListagemDados}>{item.idMedicoNavigation.nomeMed}</Text>
                <Text style={styles.ListagemTitulo}>CRM</Text>
                <Text style={styles.ListagemDados}>{item.idMedicoNavigation.crm}</Text>
                <Text style={styles.ListagemTitulo}>Especialidade</Text>
                <Text style={styles.ListagemDados}>{item.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</Text>


            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    mainBodyContent: {
        backgroundColor: "#440793",
        width: 300,
        height: 320,
        borderRadius: 20,
        marginTop: 30,
        marginBottom: 300,
    },

    Box_tiutlo: {
        alignItems: 'center',
        color: "white",
        width:320
    },

    Fundo: {
        flex: 1,
        backgroundColor: 'rgba(109, 175, 236, 1)'
    },

    Container: {
        flex: 1,
        marginLeft: 35,
        marginRight: 35,
        marginBottom: 35
    },

    Titulo: {
        color: "white",
        fontWeight: 'bold',
        fontSize: 30,
        marginTop: 36,
        borderBottomColor: 'white',
        borderBottomWidth: 2
    },

    Listagem: {
        color: "white",
        borderColor: 'white',
        fontWeight: 'bold'
    },

    Box_Projeto: {
        
        // backgroundColor
        
    },

    ListagemNome: {
        color: 'white',
        fontWeight: "900",
        fontSize: 18,
        marginLeft: 8,
        margin: 3
    },

    ListagemDados: {
        color: "white",
        // fontWeight: 'bold',
        fontSize: 15,
        marginLeft: 8,
        marginRight: 8,
        marginBottom: 8,
        marginTop: 8,
        padding:5,
        borderColor: 'white',
        borderWidth:2,
        borderRadius:25
    },

    ListagemTitulo: {
        color: "white",
        fontWeight: "600",
        fontSize: 18,
        marginLeft: 8,
        marginTop: 10,
        marginBottom: 3
    },

    ListagemExemplo: {
        color: 'black',
        marginLeft: 10,
        fontSize: 12,
        marginBottom: 32
    },

    ListarDiv: {
        borderColor: 'white',
        borderWidth: 3,
        borderRadius: 10,
        marginTop: 20
        // alignItems: 'flex-end'
    },


    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: '#6DAFEC',
    },

    main: {
        // flex: 1,
        //backgroundColor: '#F1F1F1', retirar pra nao ter conflito.
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    mainImgLogin: {
        margin: 30, //espacamento em todos os lados,menos pra cima.
        marginBottom: 10, // tira espacamento pra cima
    },
})