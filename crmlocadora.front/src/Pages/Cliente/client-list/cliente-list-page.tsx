import axios from 'axios';
import React from 'react';

const apiUrl = axios.create({
    baseURL:"http://localhost:41269/api"
});

export function ClienteListPage(){
    const [clientes, setClientes] = React.useState(null);

   
    React.useEffect(() => {
        apiUrl.get("/cliente").then((response) => {
            setClientes(response.data);
        });
    }, []);

    if(!clientes){
        
    }
    console.log(clientes);
    
   
    
    return (
        <div className="container">
            <div className="page-top">
                <div className="page-top__title">
                    <h2>Clientes</h2>
                    <p>Listagem dos clientes</p>
                </div>
                <div className="page-top__aside">
                    <button className="btn btn-primary">
                        Pesquisar
                    </button>
                </div>

                <div>
                    <h1></h1>
                    <p></p>
                </div>
            </div>
        </div>
    )
    

}
