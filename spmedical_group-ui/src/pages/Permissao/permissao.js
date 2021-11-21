import '../Home/App.css';
import { Link } from 'react-router-dom';

export default function permissao() {
    return (
      <div className="App">
        <header className="App-header">
          <h1>Você não possui permissão para cadastrar!</h1>
          <div className="links">
            <Link to="/">Home</Link>
        <Link to="/Login">Login</Link>
          </div>
        </header>
          
        
        

      </div>
    );
  }
  
