import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect, Switch } from 'react-router-dom';




import Home from './pages/Home/Home.jsx';
import Login from './pages/Login/Login.jsx';
import NotFound from './pages/NotFound/NotFound.js';
import ListarAdm from './pages/ListarAdm/ListarAdm.jsx';
import ListarPaciente from './pages/ListarPaciente/ListarPaciente.jsx';
import ListarMedico from './pages/ListarMedico/ListarMedico.jsx';

import reportWebVitals from './reportWebVitals';


const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/login" component={Login} /> {/* Login */}
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Route path="/listarAdm" component={ListarAdm} /> {/* Listar Adm */}
        <Route path="/listarPaciente" component={ListarPaciente} /> {/* Listar Paciente */}
        <Route path="/listarMedico" component={ListarMedico} /> {/* Listar Médico */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
