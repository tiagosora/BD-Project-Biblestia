use p6g7;
go
-- This file is not designed with the intent of being executed repeatedly
-- Executing this query will restart the tables and the values.
-- create schema Biblestia

-- Constraint Drop
alter table Biblestia.RequisicaoMaterial drop constraint RequisicaoMaterialMaterial;
alter table Biblestia.RequisicaoMaterial drop constraint RequisicaoMaterialRequisicao;
alter table Biblestia.Requisicao drop constraint RequisicaoResponsavel;
alter table Biblestia.Requisicao drop constraint RequisicaoLeitor;
alter table Biblestia.Requisicao drop constraint RequisicaoBiblioteca;
alter table Biblestia.CD drop constraint CDMaterial;
alter table Biblestia.Jogo drop constraint JogoMaterial; 
alter table Biblestia.Revista drop constraint RevistaMaterial;
alter table Biblestia.Jornal drop constraint JornalMaterial;
alter table Biblestia.Livro drop constraint LivroMaterial;
alter table Biblestia.Material drop constraint MaterialBiblioteca;
alter table Biblestia.AtividadeLeitor drop constraint AtividadeLeitorAtividade;
alter table Biblestia.AtividadeLeitor drop constraint AtividadeLeitorLeitor;
alter table Biblestia.Atividade drop constraint AtividadeResponsavel;
alter table Biblestia.Atividade drop constraint AtividadeBiblioteca;
alter table Biblestia.Leitor drop constraint LeitorBiblioteca;
alter table Biblestia.Cargo drop constraint CargoFuncionario;  
alter table Biblestia.Funcionario drop constraint FuncionarioBiblioteca;
 
---- Table Drop 
drop table Biblestia.Biblioteca;
drop table Biblestia.Funcionario;
drop table Biblestia.Cargo;  
drop table Biblestia.Leitor;
drop table Biblestia.Atividade;
drop table Biblestia.AtividadeLeitor; 
drop table Biblestia.Material;
drop table Biblestia.Livro;
drop table Biblestia.Jornal;
drop table Biblestia.Revista;
drop table Biblestia.Jogo;
drop table Biblestia.CD;
drop table Biblestia.Requisicao;
drop table Biblestia.RequisicaoMaterial;
  
-- Table Creation
create table Biblestia.Biblioteca (
	nome			varchar(60),
	morada			varchar(60),
	telefone		int,
	email			varchar(60),
	primary key (nome)
);
create table Biblestia.Funcionario (
	nif				int,
	nomeCompleto	varchar(60),
	idFuncionario	int,
	nomeBiblioteca	varchar(60),
	ssn				bigint 			not null,
	email			varchar(60),
	morada			varchar(60),
	telefone		int,
	dataNascimento	date,
	unique(nif),
	primary key (idFuncionario, nomeBiblioteca)
);
create table Biblestia.Cargo(
	nomeBiblioteca	varchar(60),
	idFuncionario	int,
	nomeCargo		varchar(60),
	dataInicio		date			not null,
	dataFim			date,
	primary key (nomeBiblioteca, idFuncionario, nomeCargo)
);
create table Biblestia.Leitor(
	nif				int				not null,
	nomeCompleto	varchar(60),
	idLeitor		int				not null,
	nomeBiblioteca	varchar(60)		not null,
	email			varchar(60),
	morada			varchar(60),
	telefone		int,
	dataNascimento	date,
	unique(nif),
	primary key (idLeitor, nomeBiblioteca),
);
create table Biblestia.Atividade(
	nomeBiblioteca		varchar(60),
	nomeAtividade		varchar(60),
	dataAtividade		date,
	tematica			varchar(60), 
	duracaoMin			int,  
	idFuncResponsavel	int null,
	primary key (nomeAtividade, nomeBiblioteca)
);
create table Biblestia.AtividadeLeitor(
	nomeBiblioteca	varchar(60),
	nomeAtividade	varchar(60),
	idLeitor		int,
	primary key (nomeBiblioteca, nomeAtividade, idLeitor)
);
create table Biblestia.Material(
	id				int,
	nomeBiblioteca	varchar(60),
	seccaoExposicao	varchar(60),
	estado			varchar(60) check (estado = 'Disponível' or estado = 'Requisitado') not null,
	primary key (id, nomeBiblioteca)
);
create table Biblestia.Livro(
	idMaterial		int,
	nomeBiblioteca	varchar(60),
	titulo			varchar(60),
	autor			varchar(60),
	genero			varchar(60),
	ano				int check ((ano > 0 and ano < 2055) or ano = null),
	nomeEditora		varchar(60),
	primary key (idMaterial, nomeBiblioteca)
);
create table Biblestia.Jornal(
	idMaterial		int,
	nomeBiblioteca	varchar(60),
	nome			varchar(60),
	dataPublicacao	date,
	nomeEditora		varchar(60),
	primary key (idMaterial, nomeBiblioteca)
);
create table Biblestia.Revista(
	idMaterial		int,
	nomeBiblioteca	varchar(60),
	nome			varchar(60),
	categoria		varchar(60),
	dataPublicacao	date,
	nomeEditora		varchar(60),
	primary key (idMaterial, nomeBiblioteca)
);
create table Biblestia.Jogo(
	idMaterial		int,
	nomeBiblioteca	varchar(60),
	nome			varchar(60),
	categoria		varchar(60),
	ano				int check ((ano > 0 and ano < 2055) or ano = null),
	marcaProdutora	varchar(60),
	primary key (idMaterial, nomeBiblioteca)
);
create table Biblestia.CD(
	idMaterial		int,
	nomeBiblioteca	varchar(60),
	nome			varchar(60),
	categoria		varchar(60) check (categoria = 'Áudio' or categoria = 'Vídeo' or categoria = 'Misto'),
	ano				int check ((ano > 0 and ano < 2055) or ano =		 null),
	marcaProdutora	varchar(60),
	primary key (idMaterial, nomeBiblioteca)
);
create table Biblestia.Requisicao(
	id					int, 
	nomeBiblioteca		varchar(60),
	idLeitor			int				null,
	idFuncResponsavel	int				null,
	dataInicio			date			not null,
	dataLimite			date,
	dataEntrega			date,
	primary key (id, nomeBiblioteca)
);
create table Biblestia.RequisicaoMaterial(
	idRequisicao	int,
	idMaterial		int,
	nomeBiblioteca	varchar(60),
	primary key(idRequisicao, idMaterial, nomeBiblioteca),
);  

-- Constraint Creation
alter table Biblestia.Funcionario add constraint FuncionarioBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome);
alter table Biblestia.Cargo add constraint CargoFuncionario foreign key (idFuncionario, nomeBiblioteca) references Biblestia.Funcionario(idFuncionario, nomeBiblioteca);
alter table Biblestia.Leitor add constraint LeitorBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome);
alter table Biblestia.Atividade add constraint AtividadeResponsavel foreign key (idFuncResponsavel, nomeBiblioteca) references Biblestia.Funcionario(idFuncionario, nomeBiblioteca);
alter table Biblestia.Atividade add constraint AtividadeBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome);
alter table Biblestia.AtividadeLeitor add constraint AtividadeLeitorLeitor foreign key (idLeitor, nomeBiblioteca) references Biblestia.Leitor(idLeitor, nomeBiblioteca);
alter table Biblestia.AtividadeLeitor add constraint AtividadeLeitorAtividade foreign key (nomeAtividade, nomeBiblioteca) references Biblestia.Atividade(nomeAtividade, nomeBiblioteca);
alter table Biblestia.Material add constraint MaterialBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome);
alter table Biblestia.Livro add constraint LivroMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);
alter table Biblestia.Jornal add constraint JornalMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);
alter table Biblestia.Revista add constraint RevistaMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);
alter table Biblestia.Jogo add constraint JogoMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);
alter table Biblestia.CD add constraint CDMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);
alter table Biblestia.Requisicao add constraint RequisicaoBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome);
alter table Biblestia.Requisicao add constraint RequisicaoLeitor foreign key (idLeitor, nomeBiblioteca) references Biblestia.Leitor(idLeitor, nomeBiblioteca);
alter table Biblestia.Requisicao add constraint RequisicaoResponsavel foreign key (idFuncResponsavel, nomeBiblioteca) references Biblestia.Funcionario(idFuncionario, nomeBiblioteca);
alter table Biblestia.RequisicaoMaterial add constraint RequisicaoMaterialRequisicao foreign key (idRequisicao, nomeBiblioteca) references Biblestia.Requisicao(id, nomeBiblioteca);
alter table Biblestia.RequisicaoMaterial add constraint RequisicaoMaterialMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);
go