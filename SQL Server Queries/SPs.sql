use p6g7;
go

-- Adicionar um funcionário
drop proc Biblestia.adicionarFuncionario;
go      
create proc Biblestia.adicionarFuncionario (@nif int, @nomeCompleto varchar(60), @nomeBiblioteca varchar(60), @ssn bigint, @email varchar(60), @morada varchar(60), @telefone int, @dataNascimento date = null)
as 
	declare @idFuncionario as int

	select @idFuncionario = max(idFuncionario) from Biblestia.Funcionario where nomeBiblioteca = @nomeBiblioteca;
	select @idFuncionario = @idFuncionario + 1

	insert into Biblestia.Funcionario values (@nif, @nomeCompleto, @idFuncionario, @nomeBiblioteca, @ssn, @email,@morada, @telefone, @dataNascimento)
go

-- Editar um funcionário
drop proc Biblestia.editarFuncionario;
go
create proc Biblestia.editarFuncionario (@nif int, @nomeCompleto varchar(60), @idFuncionario int, @nomeBiblioteca varchar(60), @ssn bigint, @email varchar(60), @morada varchar(60), @telefone int, @dataNascimento date = null)
as
	update Biblestia.Funcionario set nif = @nif, nomeCompleto = @nomeCompleto, ssn = @ssn, email = @email, morada = @morada, telefone = @telefone, dataNascimento = @dataNascimento where @idFuncionario=idFuncionario and @nomeBiblioteca=nomeBiblioteca;
go

-- Remover um funcionário
drop proc Biblestia.removerFuncionario;
go
create proc Biblestia.removerFuncionario (@nomeBiblioteca varchar(60), @idFuncionario int)
as
	delete from Biblestia.Funcionario where nomeBiblioteca = @nomeBiblioteca and idFuncionario = @idFuncionario;
go


-- Adicionar um leitor
drop proc Biblestia.adicionarLeitor;
go      
create proc Biblestia.adicionarLeitor (@nif int, @nomeCompleto varchar(60), @nomeBiblioteca varchar(60), @email varchar(60), @morada varchar(60), @telefone int, @dataNascimento date = null)
as
	declare @idLeitor as int

	select @idLeitor = max(idLeitor) from Biblestia.Leitor
	where nomeBiblioteca = @nomeBiblioteca;

	insert into Biblestia.Leitor values (@nif, @nomeCompleto, @idLeitor, @nomeBiblioteca, @email,@morada, @telefone, @dataNascimento)
go

-- Editar um leitor 
drop proc Biblestia.editarLeitor;
go
create proc Biblestia.editarLeitor (@nif int, @nomeCompleto varchar(60), @idLeitor int, @nomeBiblioteca varchar(60), @email varchar(60), @morada varchar(60), @telefone int, @dataNascimento date = null)
as
	update Biblestia.Leitor set nif = @nif, nomeCompleto = @nomeCompleto, email = @email, morada = @morada, telefone = @telefone, dataNascimento = @dataNascimento where @idLeitor=idLeitor and @nomeBiblioteca=nomeBiblioteca;
go

-- Editar um cargo de um funcionario 
drop proc Biblestia.editarCargo;
go
create proc Biblestia.editarCargo (@nomeBiblioteca varchar(60), @idFuncionario int, @nomeCargo varchar(60), @dataInicio date, @dataFim date = null)
as
	update Biblestia.Cargo set nomeBiblioteca = @nomeBiblioteca, idFuncionario = @idFuncionario, nomeCargo = @nomeCargo, dataInicio = @dataInicio, dataFim = @dataFim where @nomeBiblioteca=nomeBiblioteca and @idFuncionario=idFuncionario and @nomeCargo=nomeCargo;
go

-- Remover um leitor
drop proc Biblestia.removerLeitor;
go
create proc Biblestia.removerLeitor (@nomeBiblioteca varchar(60), @idLeitor int)
as
	delete from Biblestia.Leitor where nomeBiblioteca = @nomeBiblioteca and idLeitor = @idLeitor;
go
 
-- Adicionar um novo cargo a um funcionario
drop proc Biblestia.adicionarCargo;
go 
create proc Biblestia.adicionarCargo (@nomeBiblioteca varchar(60), @idFuncionario int, @nomeCargo varchar(60), @dataInicio date, @dataFim date = null)
as
	insert into Biblestia.Cargo values (@nomeBiblioteca, @idFuncionario, @nomeCargo, @dataInicio,  @dataFim)
go

-- Remover um novo cargo a um funcionario
drop proc Biblestia.removerCargo;
go 
create proc Biblestia.removerCargo (@nomeBiblioteca varchar(60), @idFuncionario int, @nomeCargo varchar(60))
as
	delete from Biblestia.Cargo where @nomeBiblioteca=nomeBiblioteca and @idFuncionario=idFuncionario and @nomeCargo=nomeCargo
go

---- Saber o tipo de um dadod material
--drop proc Biblestia.saberTipo;
--go 
--create proc Biblestia.saberTipo (@idMaterial int, @nomeBiblioteca varchar(60)) 
--as
--	declare @return varchar(60);
--	declare @i int; set @i = @idMaterial;
--	declare @b varchar(60); set @b = @nomeBiblioteca;

--	if @i in (select idMaterial from Biblestia.Livro where nomeBiblioteca=@b)
--	begin
--		set @return = 'Livro';
--	end
--	if @i in (select idMaterial from Biblestia.Jornal where nomeBiblioteca=@b)
--	begin
--		set @return = 'Jornal';
--	end
--	if @i in (select idMaterial from Biblestia.Revista where nomeBiblioteca=@b)
--	begin
--		set @return = 'Revista';
--	end
--	if @i in (select idMaterial from Biblestia.Jogo where nomeBiblioteca=@b)
--	begin
--		set @return = 'Jogo';
--	end
--	if @i in (select idMaterial from Biblestia.CD where nomeBiblioteca=@b)
--	begin
--		set @return = 'CD';
--	end
--go

-- Saber o tipo de um dadod material
drop proc Biblestia.saberTipo;
go 
create proc Biblestia.saberTipo (@idMaterial int, @nomeBiblioteca varchar(60), @return varchar(60) output) 
as
	declare @i int; set @i = @idMaterial;
	declare @b varchar(60); set @b = @nomeBiblioteca;

	if @i in (select idMaterial from Biblestia.Livro where nomeBiblioteca=@b)
	begin
		set @return = 'Livro';
	end
	if @i in (select idMaterial from Biblestia.Jornal where nomeBiblioteca=@b)
	begin
		set @return = 'Jornal';
	end
	if @i in (select idMaterial from Biblestia.Revista where nomeBiblioteca=@b)
	begin
		set @return = 'Revista';
	end
	if @i in (select idMaterial from Biblestia.Jogo where nomeBiblioteca=@b)
	begin
		set @return = 'Jogo';
	end
	if @i in (select idMaterial from Biblestia.CD where nomeBiblioteca=@b)
	begin
		set @return = 'CD';
	end
go
