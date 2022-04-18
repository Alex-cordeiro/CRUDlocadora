export class Cliente {
    id?: number;
    nome: string;
    cpf: string;
    dataNascimento: string;
    constructor(id: number, nome: string, cpf:string, dataNascimento: string){
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.dataNascimento = dataNascimento;
    }
}