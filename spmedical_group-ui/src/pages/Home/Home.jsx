import '../../assets/css/home.css'
import '../../assets/css/footer.css'
import HeaderTop from '../../components/header/header';

import { Component } from "react";
// import axios from 'axios';

export default class Home extends Component {

  render() {
    return (
      <div>
        <HeaderTop Login="Login" />

        <main className="main_home">
          <div className="cor_Home">
            <div class="container">
              <h1 className="h1_home">O cuidado completo com a sua saúde<span id="ponto_blue">.</span></h1>
              <p class="texto_sobre_nos">Somos uma plataforma de gestão de saúde que nasceu em 2011 com o propósito de salvar vidas. Abrimos
                nosso
                primeiro centro médico na região da Lapa e hoje, quase 10 anos depois, temo 45 centros médicos, em
                regiões de fácil acesso próximo a estações de metrô, em São Paulo, Rio de Janeiro e Belo Horizonte.
              </p>
            </div>
          </div>
        </main>

        <footer>
          <div class="container container_footer">
            <span class="span_footer">
              ©2020 Cia. da Consulta - Todos os direitos reservados
            </span>
            <span class="span_footer">
              Os médicos da Central de Consultas são especialistas ou estão em conclusão de sua pós-graduação.
            </span>
          </div>
        </footer>
      </div>

    )

  }
}

