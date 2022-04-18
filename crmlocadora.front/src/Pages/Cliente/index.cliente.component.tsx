import * as React from "react";
import TableRow from "./TableRow";
import {Cliente} from "../../models/cliente"
import {BaseService} from "../../Service/base.service";
interface IProps {}
interface IState {
  listPersons: Array<Cliente>;
  isReady: Boolean;
  hasError: Boolean;
}

class IndexCliente extends React.Component<IProps, IState> {
  public state: IState = {
    listPersons: new Array<Cliente>(),
    isReady: false,
    hasError: false,
  };
  constructor(props: IProps) {
    super(props);
    this.state = {
      isReady: false,
      listPersons: Array<Cliente>(),
      hasError: false,
    };
  }

  public componentDidMount() {
    BaseService.getAll<Cliente>("/cliente").then((rp) => {
      if (rp.Status) {
        const data = rp.Data;
        const listPersons = new Array<Cliente>();

        (data || []).forEach((c: any) => {
          listPersons.push(new Cliente(c.id, c.nome, c.cpf, c.dataNascimento));
        });

        this.setState({ listPersons: listPersons }); 
        this.setState({ isReady: true });
      } else {
        this.setState({ isReady: true });
        this.setState({ hasError: true });
        console.log("Messages: " + rp.Messages);
        console.log("Exception: " + rp.Exception);
      }
    });

    setTimeout(() => {
      if (!this.state.isReady) {
        alert(
          "It is possible that the service is being restarted, please wait more ..."
        );
      }

      if (this.state.hasError) {
        alert(
          "An error occurred!",    
        )
      }
    }, 2000);
  }

  public tabRow = () => {
    if (!this.state.isReady) {
      return (
        <tr>
          <td colSpan={6} className="text-center">
            <div className="spinner-border" role="status">
              <span className="visually-hidden">Loading...</span>
            </div>
          </td>
        </tr>
      );
    }
    if (this.state.hasError) {
      return (
        <tr>
          <td colSpan={6} className="text-center">
            <div className="alert alert-danger" role="alert">
              An error occurred!
            </div>
          </td>
        </tr>
      );
    }

    return this.state.listPersons.map(function (object, i) {
      return <TableRow key={i} index={i + 1} cliente={object} />;
    });
  };

  public render(): React.ReactNode {
    return (
      <div>
        <h3 className="text-center">Persons List</h3>
        <table className="table table-striped" style={{ marginTop: 20 }}>
          <thead>
            <tr>
              <th>Index</th>
              <th>Full Name</th>
              <th>Adress</th>
              <th>Age</th>
              <th className="text-center" colSpan={2}>
                Action
              </th>
            </tr>
          </thead>
          <tbody>{this.tabRow()}</tbody>
        </table>
      </div>
    );
  }
}
export default IndexCliente;
