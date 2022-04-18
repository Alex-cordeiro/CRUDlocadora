import {Cliente} from "./cliente";
import {Filme} from "./filme";

export default class Locacao {
    constructor(id: number, 
        id_Cliente: number,
        id_Filme: number,
        classificacaoIndicativa:string, 
        dataLocacao: Date,
        dataDevolucao: Date,
        cliente: Cliente,
        filmes: Array<Filme>){}
}