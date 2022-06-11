use p6g7;

go

-- Obter todos os funcion�rios de uma biblioteca
drop function Biblestia.obterFuncion�rios; 
go 
create function Biblestia.obterFuncion�rios(@biblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Funcionario
			where nomeBiblioteca = @biblioteca;
go
select * from Biblestia.obterFuncion�rios('Biblioteca Universit�ria de Aveiro')


