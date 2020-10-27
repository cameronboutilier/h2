import React from 'react';
import ItemList from './Components/ItemList'
import Container from 'react-bootstrap/Container';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="App">
      <Container style={{maxWidth: '500px'}}>
        <ItemList/>
      </Container>
    </div>
  );
}

export default App;
