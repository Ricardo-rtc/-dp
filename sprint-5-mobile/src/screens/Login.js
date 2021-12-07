import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'roberto.possarle@spmedicalgroup.com.br',
            senha: 'possarle123',
        };
    }
    //como vamos trabalhar com assync historage,
    //nossa funcao tem que ser async.
    realizarLogin = async () => {
        //nao temos mais  console log.
        //vamos utilizar console.warn.

        //apenas para teste.
        console.warn(this.state.email + ' ' + this.state.senha);

        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha,
        });

        //mostrar no swagger para montar.
        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        //agora sim podemos descomentar.
        if (resposta.status == 200) {
            this.props.navigation.navigate('Main');
        }

        console.warn(token);

        //
    };

    render() {
        return (
            <ImageBackground
                source={require('../../assets/img/fundologin.png')}
                style={StyleSheet.absoluteFillObject}>
                {/* retangulo roxo */}
                <View style={styles.overlay}>
                    <View style={styles.main}>
                        <Image
                            source={require('../../assets/img/logofull.png')}
                            style={styles.mainImgLogin}
                        />

                        <View style={styles.boxLogin}>
                            <TextInput
                                style={styles.inputLogin}
                                placeholder="Email"
                                placeholderTextColor="#FFF"
                                keyboardType="email-address"
                                // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
                                onChangeText={email => this.setState({ email })}
                            />

                            <TextInput
                                style={styles.inputLogin}
                                placeholder="Senha"
                                placeholderTextColor="#FFF"
                                keyboardType="default" //para default nao obrigatorio.
                                secureTextEntry={true} //proteje a senha.
                                // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
                                onChangeText={senha => this.setState({ senha })}
                            />

                            <TouchableOpacity
                                style={styles.btnLogin}
                                onPress={this.realizarLogin}>
                                <Text style={styles.btnLoginText}>Entrar</Text>
                            </TouchableOpacity>
                        </View>
                    </View>
                </View>
            </ImageBackground>
        );
    }
}

const styles = StyleSheet.create({
    //antes da main
    overlay: {
        ...StyleSheet.absoluteFillObject, //todas as prop do styleShhet, e vamos aplica o abosluteFIL...
        backgroundColor: 'rgba(5, 91, 192, 0.60);', //rgba pq vamos trabalhar com transparencia.
    },

    // conteúdo da main
    main: {
        // flex: 1,
        //backgroundColor: '#F1F1F1', retirar pra nao ter conflito.
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    mainImgLogin: {
        margin: 60, //espacamento em todos os lados,menos pra cima.
        marginTop: 0, // tira espacamento pra cima
        width: 250,
    },

    boxLogin:{
        borderColor: '#FFF', //linha separadora
        borderWidth: 4, //espessura.
        borderRadius: 25,
        backgroundColor: 'transparent',
        paddingLeft:30,
        paddingRight:30,
        paddingTop:50,
        paddingBottom:50,
        alignItems: 'center',
        justifyContent: 'center',
    },

    inputLogin: {
        width: 260, //largura mesma do botao
        marginBottom: 40, //espacamento pra baixo
        fontSize: 18,
        color: '#FFF',
        borderColor: '#FFF', //linha separadora
        borderWidth: 3, //espessura.
        borderRadius: 25,
        backgroundColor: 'transparent',
        paddingLeft:20,
        paddingTop:10,
        paddingBottom:10,
    },

    btnLoginText: {
        fontSize: 16, //aumentar um pouco
        fontFamily: 'Open Sans Light', //troca de fonte
        color: '#fff', //mesma cor identidade
        // letterSpacing: 6, //espacamento entre as letras
        textTransform: 'uppercase', //estilo maiusculo
    },
    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 93,
        // borderWidth: 1,
        shadowOffset: { height: 1, width: 1 },
        borderColor: '#055BC0', //linha separadora
        borderWidth: 2, //espessura.
        borderRadius: 25,
        backgroundColor: '#055BC0'
    },
});