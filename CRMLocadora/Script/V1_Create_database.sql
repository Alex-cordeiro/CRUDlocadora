create Table Cliente (
  Id int(3) auto_increment not null,
  Nome varchar(200) not null,
  CPF varchar(11) not null,
  DataNascimento datetime not null,
  PRIMARY KEY (Id)
  );
  
  
 CREATE table Filme(
   Id int(3) auto_increment not null,
   Titulo varchar(100) not null,
   ClassificacaoIndicativa int(2),
   Lancamento TINYint(1),
   PRIMARY KEY (Id)
   );
   
 create table Locacao(
   Id int(3) auto_increment not null,
   Id_Cliente int(3) not null,
   Id_Filme int(3) not null,
   DataLocacao datetime NOT NULL,
   DataDevolucao datetime NOT NULL,
   PRIMARY KEY (id),
   CONSTRAINT `FK_Cliente_Idx` FOREIGN KEY (`Id_Cliente`) REFERENCES `Cliente` (`Id`),
   CONSTRAINT `FK_Filme_Idx` FOREIGN KEY (`Id_Filme`) REFERENCES `Filme` (`Id`)
   );















































