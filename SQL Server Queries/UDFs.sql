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

-- Obter cargos de um dado funcionario
drop function Biblestia.obterCargosFuncionario; 
go 
create function Biblestia.obterCargosFuncionario(@id int, @biblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Cargo
			where idFuncionario = @id and nomeBiblioteca = @biblioteca
go 

-- Obter cargos de um dado funcionario
drop function Biblestia.obterMateriais; 
go 
create function Biblestia.obterMateriais(@biblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Cargo
			where nomeBiblioteca = @biblioteca;
go  
