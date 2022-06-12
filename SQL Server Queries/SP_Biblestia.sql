use p6g7;

go

-- Obter todos os funcionários de uma biblioteca
drop function Biblestia.obterFuncionários; 
go 
create function Biblestia.obterFuncionários(@biblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Funcionario
			where nomeBiblioteca = @biblioteca;
go

-- Adicionar um funcionário
drop proc Biblestia.adicionarFuncionario;
go      
create proc Biblestia.adicionarFuncionario (@nif int, @nomeCompleto varchar(60), @nomeBiblioteca varchar(60), @ssn bigint, @email varchar(60), @morada varchar(60), @telefone int, @dataNascimento date)
as
	declare @idFuncionario as int

	select @idFuncionario = max(idFuncionario) from Biblestia.Funcionario
	where nomeBiblioteca = @nomeBiblioteca;

	insert into Biblestia.Funcionario values (@nif, @nomeCompleto, @idFuncionario, @nomeBiblioteca, @ssn, @email,@morada, @telefone, @dataNascimento)
	
go

-- Adicionar um leitor
drop proc Biblestia.adicionarLeitor;
go      
create proc Biblestia.adicionarLeitor (@nif int, @nomeCompleto varchar(60), @nomeBiblioteca varchar(60), @email varchar(60), @morada varchar(60), @telefone int, @dataNascimento date)
as
	declare @idLeitor as int

	select @idLeitor = max(idLeitor) from Biblestia.Leitor
	where nomeBiblioteca = @nomeBiblioteca;

	insert into Biblestia.Leitor values (@nif, @nomeCompleto, @idLeitor, @nomeBiblioteca, @email,@morada, @telefone, @dataNascimento)
	
go