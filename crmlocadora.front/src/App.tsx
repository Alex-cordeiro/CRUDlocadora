import { useState } from 'react';
import logo from './logo.svg';
import { Layout, Menu, Breadcrumb, Button, Avatar } from 'antd';
import { UserOutlined, LaptopOutlined, NotificationOutlined } from '@ant-design/icons';
import './App.css'
import { Header } from 'antd/lib/layout/layout';
import {Outlet,Link} from 'react-router-dom';
import { PlaySquareOutlined } from '@ant-design/icons';


import {HomePage} from './Pages/home/home.page';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <div className="App">   
      <Header className="header">
        <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
         
          <Menu.Item><Avatar size={32} icon={<PlaySquareOutlined />} /><Link to="/"></Link></Menu.Item>
          <Menu.Item><Link to="/listar-clientes">Listar Clientes</Link></Menu.Item>
          <Menu.Item>nav 3</Menu.Item>
          
        </Menu>
      </Header>
      <Outlet />
        {/* <Route path='/' exact={true} component={HomePage} /> */}
    </div>
    </>
  )
}

export default App
