import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import App from './App'
import './index.css'

import {ClienteListPage} from './Pages/Cliente/client-list/cliente-list-page';
import {ClienteEditPage} from './Pages/Cliente/cliente-edit/cliente-edit-page';
import IndexCliente from './Pages/Cliente/index.cliente.component'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App/>}>
          <Route path="/listar-clientes" element={<IndexCliente/>}/>
          <Route path="/novo-cliente" element={<ClienteEditPage/>}/>
          <Route path="/novo-cliente/:id" element={<ClienteEditPage/>}/>
        </Route>
      </Routes>
  </BrowserRouter>
  </>
 
)
