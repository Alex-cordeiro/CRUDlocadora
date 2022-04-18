import React from "react";
import { Link } from "react-router-dom";
import { Cliente } from "../../models/cliente";
import { BaseService } from "../../Service/base.service";

function Del(Id?: number) {
  BaseService.delete("/cliente/", {
    id: Id,
  }).then((rp) => {
    if (rp.Status) {
      alert("Cliente Deletado");
      window.location.reload();
    } else {
      alert(rp.Messages);
      console.log("Messages: " + rp.Messages);
      console.log("Exception: " + rp.Exception);
    }
  });
}

interface IProps {
  cliente: Cliente;
  index: Number;
}

const TableRow: React.FunctionComponent<IProps> = (props) => { 
  return (
    <tr>
      <td>{props.cliente.id || 'Default'}</td>
      <td>{props.cliente.nome}</td>
      <td>{props.cliente.cpf}</td>
      <td>{props.cliente.dataNascimento}</td>
      <td>
        <Link to={"/edit/" + props.cliente.id} className="btn btn-primary">
          Edit
        </Link>
      </td>
      <td>
        <button onClick={() => Del(props.cliente.id)} className="btn btn-danger">
          Delete
        </button>
      </td>
    </tr>
  );
};
export default TableRow;
