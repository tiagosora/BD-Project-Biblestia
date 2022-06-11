use p6g7;

go
-- This query takes for completed a previous creation of the schema Biblestia (create schema Biblestia).
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
alter table Biblestia.Cargo drop constraint CargoBiblioteca;
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
	idFuncResponsavel	int,
	primary key (nomeAtividade, nomeBiblioteca)
);
create table Biblestia.AtividadeLeitor(
	nomeBiblioteca	varchar(60),
	nomeAtividade	varchar(60),
	idLeitor		int				not null,
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
	idLeitor			int				not null,
	idFuncResponsavel	int				not null,
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
alter table Biblestia.Funcionario add constraint FuncionarioBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome) on delete cascade;
alter table Biblestia.Cargo add constraint CargoBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome) on delete cascade;
alter table Biblestia.Cargo add constraint CargoFuncionario foreign key (idFuncionario, nomeBiblioteca) references Biblestia.Funcionario(idFuncionario, nomeBiblioteca);
alter table Biblestia.Leitor add constraint LeitorBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome) on delete cascade;
alter table Biblestia.Atividade add constraint AtividadeResponsavel foreign key (idFuncResponsavel, nomeBiblioteca) references Biblestia.Funcionario(idFuncionario, nomeBiblioteca);
alter table Biblestia.Atividade add constraint AtividadeBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome) on delete cascade;
alter table Biblestia.AtividadeLeitor add constraint AtividadeLeitorLeitor foreign key (idLeitor, nomeBiblioteca) references Biblestia.Leitor(idLeitor, nomeBiblioteca);
alter table Biblestia.AtividadeLeitor add constraint AtividadeLeitorAtividade foreign key (nomeAtividade, nomeBiblioteca) references Biblestia.Atividade(nomeAtividade, nomeBiblioteca);
alter table Biblestia.Material add constraint MaterialBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome) on delete cascade;
alter table Biblestia.Livro add constraint LivroMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca) on delete cascade;
alter table Biblestia.Jornal add constraint JornalMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca) on delete cascade;
alter table Biblestia.Revista add constraint RevistaMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca) on delete cascade;
alter table Biblestia.Jogo add constraint JogoMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca) on delete cascade;
alter table Biblestia.CD add constraint CDMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca) on delete cascade;
alter table Biblestia.Requisicao add constraint RequisicaoBiblioteca foreign key (nomeBiblioteca) references Biblestia.Biblioteca(nome) on delete cascade;
alter table Biblestia.Requisicao add constraint RequisicaoLeitor foreign key (idLeitor, nomeBiblioteca) references Biblestia.Leitor(idLeitor, nomeBiblioteca);
alter table Biblestia.Requisicao add constraint RequisicaoResponsavel foreign key (idFuncResponsavel, nomeBiblioteca) references Biblestia.Funcionario(idFuncionario, nomeBiblioteca);
alter table Biblestia.RequisicaoMaterial add constraint RequisicaoMaterialRequisicao foreign key (idRequisicao, nomeBiblioteca) references Biblestia.Requisicao(id, nomeBiblioteca) on delete cascade;
alter table Biblestia.RequisicaoMaterial add constraint RequisicaoMaterialMaterial foreign key (idMaterial, nomeBiblioteca) references Biblestia.Material(id, nomeBiblioteca);

-- Default Values 

-- 1 Biblioteca
insert into Biblestia.Biblioteca values ('Biblioteca Universitária de Aveiro', 'Campus Universitário de, R. Santiago, 3810-193 Aveiro', 234370860 , 'bibliotecaua@ua.pt');
 
-- 14 Funcionários
insert into Biblestia.Funcionario values (985211391, 'Garrott Bleibaum', 1, 'Biblioteca Universitária de Aveiro', 42973815340, 'gbleibaum0@surveymonkey.com', '81 Hansons Center', 210519092, '1952-06-03');
insert into Biblestia.Funcionario values (354332960, 'Ofella Pottell', 2, 'Biblioteca Universitária de Aveiro', 85010758213, 'opottell1@amazon.com', '30 Farragut Pass', 741606794, '1950-06-08');
insert into Biblestia.Funcionario values (935431014, 'Rosamund Zanetti', 3, 'Biblioteca Universitária de Aveiro', 34640302149, 'rzanetti2@goo.ne.jp', '64 Pond Plaza', 593733149, '1979-04-11');
insert into Biblestia.Funcionario values (626837437, 'Rivy Van Der Walt', 4, 'Biblioteca Universitária de Aveiro', 25683772021, null, null, null, null);
insert into Biblestia.Funcionario values (618957741, 'Marylin Gristwood', 5, 'Biblioteca Universitária de Aveiro', 48803781998, 'mgristwood4@ucoz.com', '41956 International Court', 388395100, '1969-06-06');
insert into Biblestia.Funcionario values (219315925, 'Reid Bernhardt', 6, 'Biblioteca Universitária de Aveiro', 63045647380, 'rbernhardt5@digg.com', '0018 Summer Ridge Crossing', 687719729, '1960-10-24');
insert into Biblestia.Funcionario values (217705317, 'Lucille Quainton', 7, 'Biblioteca Universitária de Aveiro', 32279064237, 'lquainton6@hubpages.com', '80124 Center Road', 523373431, '1960-01-26');
insert into Biblestia.Funcionario values (673305505, 'Jaymee Storie', 8, 'Biblioteca Universitária de Aveiro', 32366583262, 'jstorie7@tuttocitta.it', '4286 Mayfield Lane', 768231638, '1955-05-16');
insert into Biblestia.Funcionario values (471978502, 'Sutherland Keddie', 9, 'Biblioteca Universitária de Aveiro', 68395675185, 'skeddie8@wikimedia.org', '101 Cordelia Park', 243634795, '1989-01-31');
insert into Biblestia.Funcionario values (273867518, 'Joyann Leney', 10, 'Biblioteca Universitária de Aveiro', 89676330359, 'jleney9@fema.gov', '08041 Oak Valley Terrace', 550597359, '1986-04-23');
-- Já não trabalham na biblioteca
insert into Biblestia.Funcionario values (327496827, 'Erhard Kornousek', 11, 'Biblioteca Universitária de Aveiro', 12345678901, 'ekornousek0@tamu.edu', '2 Upham Lane', null, null);
insert into Biblestia.Funcionario values (412915705, 'Gabie Boulger', 12, 'Biblioteca Universitária de Aveiro', 12345678902, 'gboulger1@google.fr', '70 Parkside Park', 650922541, '1981-08-06');
insert into Biblestia.Funcionario values (570448932, 'Margaretha Slinger', 13, 'Biblioteca Universitária de Aveiro', 12345678903, 'mslinger2@vkontakte.ru', '68379 Holy Cross Park', 189258306, '1982-03-19');
insert into Biblestia.Funcionario values (845301929, 'Bartholomeus Futty', 14, 'Biblioteca Universitária de Aveiro', 12345678904, 'bfutty3@list-manage.com', '99576 Cherokee Road', null, '1946-02-26');

-- Cargos para os 14 funcionários
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 1, 'Auxiliar', '1992-05-19', '2000-02-22');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 1, 'Segurança', '2000-02-22', '2010-04-12');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 1, 'Gerente', '2010-04-12', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 2, 'Segurança', '2010-03-12', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 3, 'Gerente', '2010-03-12', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 4, 'Auxiliar', '1967-03-17', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 5, 'Auxiliar', '1989-08-03', '2000-01-01');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 5, 'Gerente', '2000-01-01', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 6, 'Segurança', '2005-06-24', '2010-04-12');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 6, 'Gerente', '2010-04-12', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 7, 'Auxiliar', '2010-07-22', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 8, 'Auxiliar', '1967-03-17', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 9, 'Auxiliar', '1978-02-20', null);
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 10, 'Auxiliar', '1997-12-23', null);
 -- Já não trabalham na biblioteca
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 11, 'Auxiliar', '1967-03-17', '2000-01-01');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 12, 'Auxiliar', '1967-03-17', '2000-01-01');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 13, 'Auxiliar', '1978-02-20', '2000-01-01');
insert into Biblestia.Cargo values ('Biblioteca Universitária de Aveiro', 14, 'Auxiliar', '1997-12-23', '2000-01-01');

-- 40 Leitores
insert into Biblestia.Leitor values (427770709, 'Philippe Ollin', 1, 'Biblioteca Universitária de Aveiro', 'pollin0@amazonaws.com', '61 Clyde Gallagher Terrace', 695693309, '1933-10-09');
insert into Biblestia.Leitor values (934064675, 'Fernanda Garner', 2, 'Biblioteca Universitária de Aveiro', 'fgarner1@kickstarter.com', '8 Mitchell Pass', 568464927, '1987-10-14');
insert into Biblestia.Leitor values (204722969, 'Thorndike Petrolli', 3, 'Biblioteca Universitária de Aveiro', 'tpetrolli2@pinterest.com', '280 Banding Trail', 648423860, '1993-10-07');
insert into Biblestia.Leitor values (111257816, 'Dyna Rounce', 4, 'Biblioteca Universitária de Aveiro', 'drounce3@slashdot.org', '8 Tennessee Park', 778012791, '1984-09-10');
insert into Biblestia.Leitor values (538486784, 'Cherie De Roberto', 5, 'Biblioteca Universitária de Aveiro', 'cde4@wisc.edu', '261 Butternut Center', 156744550, null);
insert into Biblestia.Leitor values (219113128, 'Myrah Nutting', 6, 'Biblioteca Universitária de Aveiro', 'mnutting5@answers.com', '061 Ramsey Lane', 674846811, '1951-07-27');
insert into Biblestia.Leitor values (301186957, 'Josie Godthaab', 7, 'Biblioteca Universitária de Aveiro', 'jgodthaab6@webeden.co.uk', null, 672063546, '1953-01-28');
insert into Biblestia.Leitor values (908067560, 'Millisent Top', 8, 'Biblioteca Universitária de Aveiro', 'mtop7@youtu.be', null, 227177556, '1952-12-02');
insert into Biblestia.Leitor values (245992031, 'Say Wigfield', 9, 'Biblioteca Universitária de Aveiro', 'swigfield8@blinklist.com', null, 664850972, '1932-10-21');
insert into Biblestia.Leitor values (768178335, 'Vasily Ivakhnov', 10, 'Biblioteca Universitária de Aveiro', 'vivakhnov9@123-reg.co.uk', '18229 Arapahoe Parkway', 175753799, '1963-05-22');
insert into Biblestia.Leitor values (673758728, 'Kacy Blastock', 11, 'Biblioteca Universitária de Aveiro', 'kblastocka@wikimedia.org', '586 Cascade Circle', null, '1988-12-03');
insert into Biblestia.Leitor values (419622884, 'Nettle Dmych', 12, 'Biblioteca Universitária de Aveiro', null, '335 Milwaukee Circle', 693557521, '1953-12-15');
insert into Biblestia.Leitor values (869774619, 'Raychel Gilardi', 13, 'Biblioteca Universitária de Aveiro', 'rgilardic@mysql.com', '66658 Magdeline Drive', 206650097, '1981-03-17');
insert into Biblestia.Leitor values (822576066, 'Briano Bulloch', 14, 'Biblioteca Universitária de Aveiro', 'bbullochd@hao123.com', '38 Bonner Point', 214032787, '1945-10-20');
insert into Biblestia.Leitor values (931069303, 'Rosalia Olford', 15, 'Biblioteca Universitária de Aveiro', 'rolforde@tripadvisor.com', '52124 Stang Circle', 301359906, '1975-09-10');
insert into Biblestia.Leitor values (229531489, 'Engracia MacKeig', 16, 'Biblioteca Universitária de Aveiro', 'emackeigf@state.tx.us', '91 Merchant Parkway', null, '1976-10-28');
insert into Biblestia.Leitor values (764498352, 'Jemmie Archibold', 17, 'Biblioteca Universitária de Aveiro', 'jarchiboldg@uiuc.edu', '60 Farmco Court', 858756900, '1981-01-09');
insert into Biblestia.Leitor values (556079743, 'Chere Hornig', 18, 'Biblioteca Universitária de Aveiro', 'chornigh@smugmug.com', '818 Westerfield Road', 531625133, '1975-10-14');
insert into Biblestia.Leitor values (115325341, 'Ezra Odda', 19, 'Biblioteca Universitária de Aveiro', 'eoddai@joomla.org', '7083 Farwell Junction', 762126302, '1990-03-21');
insert into Biblestia.Leitor values (573884815, 'Bari Van der Brugge', 20, 'Biblioteca Universitária de Aveiro', 'bvanj@reuters.com', '04997 Lotheville Point', 559397795, null);
insert into Biblestia.Leitor values (390186978, 'Cthrine Francescuccio', 21, 'Biblioteca Universitária de Aveiro', 'cfrancescucciok@ning.com', '5035 Swallow Place', null, null);
insert into Biblestia.Leitor values (383405430, 'Alard Mungin', 22, 'Biblioteca Universitária de Aveiro', 'amunginl@multiply.com', '8223 Pond Road', 733888917, null);
insert into Biblestia.Leitor values (962101800, 'Bowie Granger', 23, 'Biblioteca Universitária de Aveiro', null, '11 Kipling Terrace', null, '1947-10-23');
insert into Biblestia.Leitor values (152880815, 'Zorana Ferrers', 24, 'Biblioteca Universitária de Aveiro', 'zferrersn@vinaora.com', '94235 Clemons Alley', 787645834, null);
insert into Biblestia.Leitor values (208197498, 'Vi Crosston', 25, 'Biblioteca Universitária de Aveiro', 'vcrosstono@histats.com', '5 Hauk Point', 342215127, '1944-01-21');
insert into Biblestia.Leitor values (537206133, 'Chadd Ormond', 26, 'Biblioteca Universitária de Aveiro', 'cormondp@chronoengine.com', '753 Holy Cross Avenue', 513858850, '1952-06-26');
insert into Biblestia.Leitor values (815932193, 'Juliane Flux', 27, 'Biblioteca Universitária de Aveiro', 'jfluxq@aol.com', null, 956145758, null);
insert into Biblestia.Leitor values (717859628, 'Hamlen Berthome', 28, 'Biblioteca Universitária de Aveiro', 'hberthomer@google.co.jp', '50 Moulton Crossing', 793406926, '1945-09-24');
insert into Biblestia.Leitor values (889557222, 'Jonah Deakin', 29, 'Biblioteca Universitária de Aveiro', 'jdeakins@cocolog-nifty.com', '6 Sunfield Place', null, '1969-04-20');
insert into Biblestia.Leitor values (616307821, 'David Wordesworth', 30, 'Biblioteca Universitária de Aveiro', 'dwordeswortht@nationalgeographic.com', '501 Forest Junction', 338783902, '1972-02-29');
insert into Biblestia.Leitor values (853655201, 'Franciska Fulmen', 31, 'Biblioteca Universitária de Aveiro', null, '67 Lillian Court', 767975101, null);
insert into Biblestia.Leitor values (437960011, 'Loralee Rosebotham', 32, 'Biblioteca Universitária de Aveiro', 'lrosebothamv@linkedin.com', '5867 Northland Way', 652678771, '1992-10-30');
insert into Biblestia.Leitor values (738742409, 'Vinita Whistan', 33, 'Biblioteca Universitária de Aveiro', 'vwhistanw@bizjournals.com', '857 Artisan Crossing', 535346372, '1944-09-29');
insert into Biblestia.Leitor values (252461740, 'Christina Evesque', 34, 'Biblioteca Universitária de Aveiro', 'cevesquex@mit.edu', '4 Sullivan Lane', 496946893, '1973-01-11');
insert into Biblestia.Leitor values (416596550, 'Ezekiel Lubbock', 35, 'Biblioteca Universitária de Aveiro', null, '91652 Fuller Drive', 288226127, '1931-08-06');
insert into Biblestia.Leitor values (655355159, 'Bourke Lougheed', 36, 'Biblioteca Universitária de Aveiro', 'blougheedz@wikispaces.com', '3066 Emmet Junction', null, '1932-07-26');
insert into Biblestia.Leitor values (270127333, 'Broderic Bather', 37, 'Biblioteca Universitária de Aveiro', 'bbather10@wired.com', null, 900294028, '1934-06-25');
insert into Biblestia.Leitor values (298413240, 'Erena Pavia', 38, 'Biblioteca Universitária de Aveiro', 'epavia11@123-reg.co.uk', '2368 Bartillon Circle', 992971329, '1937-10-21');
insert into Biblestia.Leitor values (519496454, 'Mag Bartos', 39, 'Biblioteca Universitária de Aveiro', 'mbartos12@paypal.com', '68943 Autumn Leaf Lane', null, '1984-02-27');
insert into Biblestia.Leitor values (281146449, 'Creight Deacon', 40, 'Biblioteca Universitária de Aveiro', 'cdeacon13@nhs.uk', '8961 Bultman Crossing', null, '1977-09-30');

-- 12 Atividades
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Como fazer um bolo?', '2013-10-22', 'Apresentação', 184, 1);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'O Principezinho', '2014-01-11', 'Leitura', 21, 1);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Os Maias', '2012-10-23', 'Leitura', 238, 1);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Os Lusíadas', '2015-02-09', 'Leitura', 0, 4);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Filmes de Terror', '2018-09-24', 'Cinema', 114, 5);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Noite de Cinema', '2019-08-20', 'Cinema', 24, 5);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', '2015-05-23', 'Teatro', 109, 7);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'A Ponte de Rubi', '2015-06-08', 'Leitura', 39, 8);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Como fazer boas bases de dados!', '2017-08-28', 'Workshop', 228, 9);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', '2015-09-13', 'Apresentação', 100, 8);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Quem fez o mundo?', null, null, 50, 9);
insert into Biblestia.Atividade values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', '2013-09-20', 'Cinema', 134, 9); 

-- 65 Participações nas 12 Atividades
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer um bolo?', 13);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer um bolo?', 29);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer um bolo?', 8);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'O Principezinho', 35);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'O Principezinho', 14);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'O Principezinho', 38);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'O Principezinho', 36);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'O Principezinho', 34);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'O Principezinho', 15);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias', 11);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias', 32);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias', 18);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias', 21);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias', 17);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Filmes de Terror', 10);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Filmes de Terror', 38);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Filmes de Terror', 15);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Filmes de Terror', 12);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Filmes de Terror', 17);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Noite de Cinema', 9);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Noite de Cinema', 7);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 27);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 39);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 37);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 1);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 14);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 30);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 2);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 22);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Bela e o Mostro - Peça de Teatro', 16);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Ponte de Rubi', 20);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Ponte de Rubi', 37);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Ponte de Rubi', 5);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Ponte de Rubi', 38);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'A Ponte de Rubi', 31);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer boas bases de dados!', 13);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer boas bases de dados!', 4);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer boas bases de dados!', 33);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer boas bases de dados!', 5);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Como fazer boas bases de dados!', 40);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', 37);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', 36);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', 35);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', 7);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', 27);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Apresentação Mozard 2015', 4);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Quem fez o mundo?', 31);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Quem fez o mundo?', 34);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Quem fez o mundo?', 40);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Quem fez o mundo?', 25);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Quem fez o mundo?', 6);
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 26); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 16); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 8); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 29); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 19); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 37); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 34); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 20); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 17); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 6); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 12); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 40); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 11); 
insert into Biblestia.AtividadeLeitor values ('Biblioteca Universitária de Aveiro', 'Os Maias - O Filme', 31); 

-- 40 Materiais
insert into Biblestia.Material values (1, 'Biblioteca Universitária de Aveiro', '11X-45', 'Disponível');
insert into Biblestia.Material values (2, 'Biblioteca Universitária de Aveiro', '79M-78', 'Requisitado');
insert into Biblestia.Material values (3, 'Biblioteca Universitária de Aveiro', '47R-90', 'Disponível');
insert into Biblestia.Material values (4, 'Biblioteca Universitária de Aveiro', '16T-93', 'Requisitado');
insert into Biblestia.Material values (5, 'Biblioteca Universitária de Aveiro', '39E-81', 'Requisitado');
insert into Biblestia.Material values (6, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (7, 'Biblioteca Universitária de Aveiro', '57D-76', 'Requisitado');
insert into Biblestia.Material values (8, 'Biblioteca Universitária de Aveiro', '94I-79', 'Disponível');
insert into Biblestia.Material values (9, 'Biblioteca Universitária de Aveiro', '23M-50', 'Disponível');
insert into Biblestia.Material values (10, 'Biblioteca Universitária de Aveiro', '45E-11', 'Disponível');
insert into Biblestia.Material values (11, 'Biblioteca Universitária de Aveiro', '54Q-85', 'Requisitado');
insert into Biblestia.Material values (12, 'Biblioteca Universitária de Aveiro', '61C-06', 'Disponível');
insert into Biblestia.Material values (13, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (14, 'Biblioteca Universitária de Aveiro', '85W-90', 'Disponível');
insert into Biblestia.Material values (15, 'Biblioteca Universitária de Aveiro', '64X-37', 'Requisitado');
insert into Biblestia.Material values (16, 'Biblioteca Universitária de Aveiro', '23K-98', 'Disponível');
insert into Biblestia.Material values (17, 'Biblioteca Universitária de Aveiro', '26P-99', 'Disponível');
insert into Biblestia.Material values (18, 'Biblioteca Universitária de Aveiro', '47A-22', 'Disponível');
insert into Biblestia.Material values (19, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (20, 'Biblioteca Universitária de Aveiro', '44Q-94', 'Disponível');
insert into Biblestia.Material values (21, 'Biblioteca Universitária de Aveiro', '64Y-47', 'Requisitado');
insert into Biblestia.Material values (22, 'Biblioteca Universitária de Aveiro', '56J-93', 'Disponível');
insert into Biblestia.Material values (23, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (24, 'Biblioteca Universitária de Aveiro', '40A-69', 'Requisitado');
insert into Biblestia.Material values (25, 'Biblioteca Universitária de Aveiro', '20S-61', 'Disponível');
insert into Biblestia.Material values (26, 'Biblioteca Universitária de Aveiro', '16F-44', 'Disponível');
insert into Biblestia.Material values (27, 'Biblioteca Universitária de Aveiro', '70T-68', 'Requisitado');
insert into Biblestia.Material values (28, 'Biblioteca Universitária de Aveiro', '01S-87', 'Disponível');
insert into Biblestia.Material values (29, 'Biblioteca Universitária de Aveiro', '53H-99', 'Requisitado');
insert into Biblestia.Material values (30, 'Biblioteca Universitária de Aveiro', '60G-19', 'Disponível');
insert into Biblestia.Material values (31, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (32, 'Biblioteca Universitária de Aveiro', '56A-26', 'Requisitado');
insert into Biblestia.Material values (33, 'Biblioteca Universitária de Aveiro', '38Q-40', 'Disponível');
insert into Biblestia.Material values (34, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (35, 'Biblioteca Universitária de Aveiro', '70Y-69', 'Requisitado');
insert into Biblestia.Material values (36, 'Biblioteca Universitária de Aveiro', '73V-99', 'Disponível');
insert into Biblestia.Material values (37, 'Biblioteca Universitária de Aveiro', '44H-43', 'Disponível');
insert into Biblestia.Material values (38, 'Biblioteca Universitária de Aveiro', null, 'Disponível');
insert into Biblestia.Material values (39, 'Biblioteca Universitária de Aveiro', '36X-78', 'Disponível');
insert into Biblestia.Material values (40, 'Biblioteca Universitária de Aveiro', '35K-63', 'Disponível');

-- 8 Livros
insert into Biblestia.Livro values (1, 'Biblioteca Universitária de Aveiro', 'Ordeal, The (Calvaire)', 'Tabina McCoy', null, null, 'Gradiva');
insert into Biblestia.Livro values (3, 'Biblioteca Universitária de Aveiro', 'Boy A', 'Genna Ponting', 'Conto', 2016, 'Editorial Presença');
insert into Biblestia.Livro values (4, 'Biblioteca Universitária de Aveiro', 'Ashura', 'Culley Tuft', 'Épico', 2012, 'Gradiva');
insert into Biblestia.Livro values (5, 'Biblioteca Universitária de Aveiro', 'House Party 2', 'Leonard Keeney', null, 2011, 'Plátano Editora');
insert into Biblestia.Livro values (6, 'Biblioteca Universitária de Aveiro', '41-Year-Old Who Knocked Up Sarah Marshall', 'Fania Ingleby', null, 2002, 'Planeta');
insert into Biblestia.Livro values (7, 'Biblioteca Universitária de Aveiro', 'Hi-Line, The', 'Kaleb Gothliff', 'Fábula', null, null);
insert into Biblestia.Livro values (8, 'Biblioteca Universitária de Aveiro', 'Retreat', 'Loise Salzen', 'Épico', 1992, 'Grupo Lidel');

-- 8 Jornais 
insert into Biblestia.Jornal values (9, 'Biblioteca Universitária de Aveiro', 'Drug War (Du zhan)', '2020-03-10', null); 
insert into Biblestia.Jornal values (10, 'Biblioteca Universitária de Aveiro', 'Danube Exodus, The', '2001-08-03', 'Keeling-Huels');
insert into Biblestia.Jornal values (11, 'Biblioteca Universitária de Aveiro', 'Brain, The', '2000-10-19', 'Jakubowski and Sons');
insert into Biblestia.Jornal values (12, 'Biblioteca Universitária de Aveiro', 'All Dogs Christmas Carol, An', '2002-08-07', null);
insert into Biblestia.Jornal values (13, 'Biblioteca Universitária de Aveiro', 'Sword of Desperation (Hisshiken torisashi)', '2004-10-27', 'Cole, Turner and Heidenreich');
insert into Biblestia.Jornal values (14, 'Biblioteca Universitária de Aveiro', 'Prophecy', '2011-06-26', 'Marks, Hansen and DuBuque');
insert into Biblestia.Jornal values (15, 'Biblioteca Universitária de Aveiro', 'Flirtation Walk', null, 'Boyer and Sons');
insert into Biblestia.Jornal values (16, 'Biblioteca Universitária de Aveiro', 'Baggage Claim', '2011-12-13', 'Klein, McCullough and Gaylord');

---- 8 Revistas
insert into Biblestia.Revista values (17, 'Biblioteca Universitária de Aveiro', 'Dark Blue World (Tmavomodrý svet)', 'Informativa', '2012-04-20', 'Heathcote, Braun and Hintz');
insert into Biblestia.Revista values (18, 'Biblioteca Universitária de Aveiro', 'Charisma (Karisuma)', 'Comida', '2001-12-29', 'Turcotte-Marquardt');
insert into Biblestia.Revista values (19, 'Biblioteca Universitária de Aveiro', 'Hamlet Goes Business (Hamlet liikemaailmassa)', 'Comida', '2022-01-01', 'Witting-Kunde');
insert into Biblestia.Revista values (20, 'Biblioteca Universitária de Aveiro', 'White Noise', 'Científica', '2018-03-08', 'Moen, Balistreri and Weissnat');
insert into Biblestia.Revista values (21, 'Biblioteca Universitária de Aveiro', '27 Club, The', 'Notícia', '2006-01-04', 'Hagenes Inc');
insert into Biblestia.Revista values (22, 'Biblioteca Universitária de Aveiro', 'Strange Love of Martha Ivers, The', 'Informativa', '2001-05-20', 'Hermann LLC');
insert into Biblestia.Revista values (23, 'Biblioteca Universitária de Aveiro', 'With Friends Like These...', 'Informativa', '2012-01-16', 'Walker, Hoppe and Friesen');
insert into Biblestia.Revista values (24, 'Biblioteca Universitária de Aveiro', 'Born to Fight', 'Magazine', '2004-01-07', 'Sanford Inc');
---- 8 Jogos 
insert into Biblestia.Jogo values (25, 'Biblioteca Universitária de Aveiro', 'Adventure in the Jungle', 'Aventura', 2009, null);
insert into Biblestia.Jogo values (26, 'Biblioteca Universitária de Aveiro', 'Son is Back', 'Aventura', 1996, 'Wisozk-Kautzer');
insert into Biblestia.Jogo values (27, 'Biblioteca Universitária de Aveiro', 'Get a girlfriend', 'História', null, 'Harvey, Lind and Walsh');
insert into Biblestia.Jogo values (28, 'Biblioteca Universitária de Aveiro', 'How?', 'Aventura', 1995, 'Weissnat, Glover and Runte');
insert into Biblestia.Jogo values (29, 'Biblioteca Universitária de Aveiro', 'Create Your Own Boat', 'Sandbox', null, 'Runte, Schmitt and Bergnaum');
insert into Biblestia.Jogo values (30, 'Biblioteca Universitária de Aveiro', 'Wanna Play?', 'Passa-tempo', 2001, 'Rippin, Gulgowski and Dare');
insert into Biblestia.Jogo values (31, 'Biblioteca Universitária de Aveiro', 'Im Tired Of Doing Inserts', null, 1999, 'O''Conner Inc');
insert into Biblestia.Jogo values (32, 'Biblioteca Universitária de Aveiro', 'Ahhhhh', 'Sandbox', 1999, null);
---- 8 cds
insert into Biblestia.CD values (33, 'Biblioteca Universitária de Aveiro', 'Get a life', 'Áudio', 2014, 'Feest, Hilll and Terry');
insert into Biblestia.CD values (34, 'Biblioteca Universitária de Aveiro', 'Beta', 'Áudio', 1995, null);
insert into Biblestia.CD values (35, 'Biblioteca Universitária de Aveiro', 'AltF3', 'Áudio', 1996, 'Koss, Kozey and Maggio');
insert into Biblestia.CD values (36, 'Biblioteca Universitária de Aveiro', 'Arte Rupestre', 'Vídeo', 2006, 'Dibbert, Jaskolski and Wyman');
insert into Biblestia.CD values (37, 'Biblioteca Universitária de Aveiro', 'Coluna', 'Misto', null, null);
insert into Biblestia.CD values (38, 'Biblioteca Universitária de Aveiro', 'RFMF', 'Áudio', 2005, 'Ratke-Erdman');
insert into Biblestia.CD values (39, 'Biblioteca Universitária de Aveiro', 'Como fazer batatas fritas!', 'Misto', 1991, 'Borer Group');
insert into Biblestia.CD values (40, 'Biblioteca Universitária de Aveiro', 'Segurança Pública', 'Misto', 2013, 'Weissnat, Hoppe and Bailey');

-- 40 Requisições (excluída a possibilidade de requisições depois de 2000)
insert into Biblestia.Requisicao values (1, 'Biblioteca Universitária de Aveiro', 39, 2, '2018-01-22', '2018-01-29', '2018-01-23');
insert into Biblestia.Requisicao values (2, 'Biblioteca Universitária de Aveiro', 28, 3, '2012-01-15', '2012-01-23', '2012-01-30');
insert into Biblestia.Requisicao values (3, 'Biblioteca Universitária de Aveiro', 31, 6, '2022-03-19', '2022-04-03', null);
insert into Biblestia.Requisicao values (4, 'Biblioteca Universitária de Aveiro', 13, 4, '2009-05-12', '2009-05-22', null);
insert into Biblestia.Requisicao values (5, 'Biblioteca Universitária de Aveiro', 2, 2, '2015-01-23', '2015-02-01', '2015-01-23');
insert into Biblestia.Requisicao values (6, 'Biblioteca Universitária de Aveiro', 21, 6, '2007-11-28', '2007-12-09', '2007-12-10');
insert into Biblestia.Requisicao values (7, 'Biblioteca Universitária de Aveiro', 1, 4, '2002-09-06', '2002-09-21', '2002-09-07');
insert into Biblestia.Requisicao values (8, 'Biblioteca Universitária de Aveiro', 9, 9, '2002-01-26', '2002-02-05', '2002-01-29');
insert into Biblestia.Requisicao values (9, 'Biblioteca Universitária de Aveiro', 11, 7, '2019-02-05', '2019-02-17', null);
insert into Biblestia.Requisicao values (10, 'Biblioteca Universitária de Aveiro', 5, 10, '2013-10-20', '2013-11-04', '2013-10-21');
insert into Biblestia.Requisicao values (11, 'Biblioteca Universitária de Aveiro', 24, 6, '2015-06-16', '2015-06-30', '2015-06-16');
insert into Biblestia.Requisicao values (12, 'Biblioteca Universitária de Aveiro', 5, 7, '2001-10-21', '2001-11-03', null);
insert into Biblestia.Requisicao values (13, 'Biblioteca Universitária de Aveiro', 34, 2, '2009-12-09', '2009-12-16', '2009-12-19');
insert into Biblestia.Requisicao values (14, 'Biblioteca Universitária de Aveiro', 29, 5, '2007-05-22', '2007-06-01', '2007-07-20');
insert into Biblestia.Requisicao values (15, 'Biblioteca Universitária de Aveiro', 30, 4, '2012-08-09', '2012-08-22', '2012-08-29');
insert into Biblestia.Requisicao values (16, 'Biblioteca Universitária de Aveiro', 14, 9, '2021-07-09', '2021-07-20', null);
insert into Biblestia.Requisicao values (17, 'Biblioteca Universitária de Aveiro', 33, 4, '2019-12-15', '2019-12-26', null);
insert into Biblestia.Requisicao values (18, 'Biblioteca Universitária de Aveiro', 38, 6, '2009-04-03', '2009-04-17', '2009-04-05');
insert into Biblestia.Requisicao values (19, 'Biblioteca Universitária de Aveiro', 10, 9, '2020-04-01', '2020-04-10', null);
insert into Biblestia.Requisicao values (20, 'Biblioteca Universitária de Aveiro', 4, 10, '2005-04-04', '2005-04-17', '2005-04-07');
insert into Biblestia.Requisicao values (21, 'Biblioteca Universitária de Aveiro', 35, 8, '2010-01-15', '2010-01-28', '2010-01-15');
insert into Biblestia.Requisicao values (22, 'Biblioteca Universitária de Aveiro', 38, 3, '2010-05-10', '2010-05-24', '2010-05-17');
insert into Biblestia.Requisicao values (23, 'Biblioteca Universitária de Aveiro', 29, 7, '2008-12-08', '2008-12-16', '2008-12-18');
insert into Biblestia.Requisicao values (24, 'Biblioteca Universitária de Aveiro', 14, 10, '2005-11-06', '2005-11-18', null);
insert into Biblestia.Requisicao values (25, 'Biblioteca Universitária de Aveiro', 16, 9, '2011-08-16', '2011-08-31', '2011-08-16');
insert into Biblestia.Requisicao values (26, 'Biblioteca Universitária de Aveiro', 18, 7, '2006-04-29', '2006-05-09', null);
insert into Biblestia.Requisicao values (27, 'Biblioteca Universitária de Aveiro', 32, 5, '2015-04-28', '2015-05-13', '2015-04-29');
insert into Biblestia.Requisicao values (28, 'Biblioteca Universitária de Aveiro', 22, 10, '2016-10-03', '2016-10-18', '2016-10-09');
insert into Biblestia.Requisicao values (29, 'Biblioteca Universitária de Aveiro', 38, 9, '2003-05-25', '2003-06-04', '2003-05-29');
insert into Biblestia.Requisicao values (30, 'Biblioteca Universitária de Aveiro', 9, 6, '2007-08-23', '2007-09-04', '2007-08-29');
insert into Biblestia.Requisicao values (31, 'Biblioteca Universitária de Aveiro', 11, 4, '2000-03-26', '2000-04-09', null);
insert into Biblestia.Requisicao values (32, 'Biblioteca Universitária de Aveiro', 23, 7, '2004-05-18', '2004-06-02', '2004-08-05');
insert into Biblestia.Requisicao values (33, 'Biblioteca Universitária de Aveiro', 21, 5, '2006-11-21', '2006-12-02', '2006-12-30');
insert into Biblestia.Requisicao values (34, 'Biblioteca Universitária de Aveiro', 20, 1, '2006-08-26', '2006-09-04', '2006-08-29');
insert into Biblestia.Requisicao values (35, 'Biblioteca Universitária de Aveiro', 14, 2, '2000-02-03', '2000-02-16', '2000-02-05');
insert into Biblestia.Requisicao values (36, 'Biblioteca Universitária de Aveiro', 15, 5, '2019-02-22', '2019-03-04', null);
insert into Biblestia.Requisicao values (37, 'Biblioteca Universitária de Aveiro', 26, 8, '2012-05-23', '2012-06-01', '2012-05-25');
insert into Biblestia.Requisicao values (38, 'Biblioteca Universitária de Aveiro', 34, 8, '2011-08-07', '2011-08-18', '2011-08-15');
insert into Biblestia.Requisicao values (39, 'Biblioteca Universitária de Aveiro', 3, 7, '2003-08-12', '2003-08-27', '2003-08-27');
insert into Biblestia.Requisicao values (40, 'Biblioteca Universitária de Aveiro', 8, 5, '2008-08-14', '2008-08-23', null);

------- 2, 4, 5, 7, 11, 15, 21, 24, 27, 29, 32, 35 requisitados
insert into Biblestia.RequisicaoMaterial values (1, 1, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (1, 21, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (1, 24, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (4, 4, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (4, 7, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (4, 11, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (4, 15, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (6, 25, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (27, 27, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (27, 35, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (36, 29, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (36, 32, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (37, 5, 'Biblioteca Universitária de Aveiro');
------- 2, 4, 5, 7, 11, 15, 21, 24, 27, 29, 32, 35 requisitados
insert into Biblestia.RequisicaoMaterial values (2, 16, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (2, 31, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (3, 12, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (3, 10, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (3, 9, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (5, 25, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (5, 22, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (5, 23, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (7, 8, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (7, 18, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (8, 34, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (9, 20, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (9, 22, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (10, 19, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (10, 18, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (11, 23, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (11, 22, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (12, 14, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (13, 28, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (14, 36, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (15, 6, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (15, 8, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (16, 33, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (17, 25, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (17, 26, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (18, 39, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (19, 17, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (19, 26, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (20, 33, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (21, 7, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (22, 33, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (23, 26, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (24, 1, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (25, 12, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (26, 12, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (28, 20, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (29, 9, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (30, 17, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (31, 10, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (32, 10, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (33, 33, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (34, 25, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (35, 16, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (38, 3, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (39, 10, 'Biblioteca Universitária de Aveiro');
insert into Biblestia.RequisicaoMaterial values (40, 8, 'Biblioteca Universitária de Aveiro');
 