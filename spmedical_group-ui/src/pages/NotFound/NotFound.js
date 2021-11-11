import { Link } from 'react-router-dom';

function NotFound() {
    return (
      <div className="App">
        <header className="App-header">
          <h1>404 - Página não encontrada</h1>
        </header>
        
        <Link to="/">Home</Link>
        <span>        </span> 
        <Link to="/Login">login</Link>

      </div>
    );
  }
  
  export default NotFound;