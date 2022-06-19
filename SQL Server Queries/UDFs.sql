use p6g7;
go

-- Obter todos os funcionários de uma biblioteca
drop function Biblestia.obterFuncionários; 
go 
create function Biblestia.obterFuncionários(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Funcionario
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter os funcionários atuais de um biblioteca
drop function Biblestia.obterFuncionariosAtuais;
go
create function Biblestia.obterFuncionariosAtuais(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as FuncionariosAtuais
			from (Biblestia.Funcionario join Biblestia.Cargo on Funcionario.idFuncionario = Cargo.idFuncionario)
			where Funcionario.nomeBiblioteca = @nomeBiblioteca and dataFim is null;
go  

-- Obter cargos de um dado funcionario
drop function Biblestia.obterCargosFuncionario; 
go 
create function Biblestia.obterCargosFuncionario(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Cargo
			where idFuncionario = @id and nomeBiblioteca = @nomeBiblioteca
go 

-- Obter cargos de um dado funcionario
drop function Biblestia.obterMateriais; 
go 
create function Biblestia.obterMateriais(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Cargo
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todos os funcionários de uma biblioteca
drop function Biblestia.obterLeitores; 
go 
create function Biblestia.obterLeitores(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Leitor
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter as atividades de um dado leitor
drop function Biblestia.obterAtividadesLeitor; 
go
create function Biblestia.obterAtividadesLeitor(@idLeitor int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.AtividadeLeitor
			where idLeitor = @idLeitor and nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as atividades de uma biblioteca
drop function Biblestia.obterAtvidades; 
go
create function Biblestia.obterAtvidades(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Atividade
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as atividades em que um dado funcionário foi responsável
drop function Biblestia.obterAtvidadesResponsavel; 
go
create function Biblestia.obterAtvidadesResponsavel(@idFuncionario int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Atividade
			where idFuncResponsavel = @idFuncionario and nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de todos os tipos de materiais de um biblioteca
drop function Biblestia.obterDadosMateriais; 
go 
create function Biblestia.obterDadosMateriais(@nomeBiblioteca varchar(60)) returns table
as
	return	select A.name, sum(B.rows) as count
			from sys.objects A inner join sys.partitions B on A.object_id = B.object_id
			where	schema_name(A.schema_id) = 'Biblestia' and
					(A.name='Livro' or A.name='Revista' or A.name='Jornal' or A.name='Jogo' or A.name='CD')
			group by A.schema_id, A.name;
go

-- Obter todos os materiais de uma biblioteca
drop function Biblestia.obterMateriais
go
create function Biblestia.obterMateriais(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Material
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterLivros
go
create function Biblestia.obterLivros(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Livro
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterJornais
go
create function Biblestia.obterJornais(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Jornal
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterRevistas 
go
create function Biblestia.obterRevistas(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Revista
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterJogos
go
create function Biblestia.obterJogos(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Jogo
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterCDs
go
create function Biblestia.obterCDs(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.CD
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as requisições de uma biblioteca;
drop function Biblestia.obterRequisicoes
go
create function Biblestia.obterRequisicoes(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from RequisicaoDados
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter requisições de um dado Material
drop function Biblestia.obterRequisicoesMaterial
go
create function Biblestia.obterRequisicoesMaterial(@idMaterial int, @nomeBiblioteca varchar(60)) returns table 
as
	return	select * from RequisicaoDados
			where idMaterial = @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go 

-- Obter o número de livros de uma requisição
drop function Biblestia.obterLivrosRequisicao;
go
create function Biblestia.obterLivrosRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Livro on RequisicaoMaterial.idMaterial = Livro.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
-- Obter o número de jornais de uma requisição
drop function Biblestia.obterJornaisRequisicao;
go
create function Biblestia.obterJornaisRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Jornal on RequisicaoMaterial.idMaterial = Jornal.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go 
-- Obter o número de revistas de uma requisição
drop function Biblestia.obterRevistasRequisicao;
go
create function Biblestia.obterRevistasRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Revista on RequisicaoMaterial.idMaterial = Revista.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
-- Obter o número de jogos de uma requisição
drop function Biblestia.obterJogosRequisicao;
go
create function Biblestia.obterJogosRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Jogo on RequisicaoMaterial.idMaterial = Jogo.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
-- Obter o número de cds de uma requisição
drop function Biblestia.obterCDsRequisicao;
go
create function Biblestia.obterCDsRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join CD on RequisicaoMaterial.idMaterial = CD.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
