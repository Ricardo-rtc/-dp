import '../Home/App.css';
import { Link } from 'react-router-dom';

function NotFound() {
    return (
      <div className="App">
        <header className="App-header">
          <h1>404 - Página não encontrada</h1>
        <span> A META É TRANCAR O SENAI  </span>  
          <div className="links">
            <Link to="/"><a>Home</a></Link>
        <span>||||||||||</span> 
        <Link to="/Login"><a>Login</a></Link>
          </div>
        </header>
          
        
        

      </div>
    );
  }
  
  export default NotFound;