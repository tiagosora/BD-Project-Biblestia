use p6g7;
go

create trigger Delete_Biblioteca on Biblestia.Biblioteca instead of delete
as
	begin
		set nocount on;
		delete from Biblestia.Funcionario where nomeBiblioteca in (select nome from deleted)
		delete from Biblestia.Leitor where nomeBiblioteca in (select nome from deleted)
		delete from Biblestia.Atividade where nomeBiblioteca in (select nome from deleted)
		delete from Biblestia.Requisicao where nomeBiblioteca in (select nome from deleted)
		delete from Biblestia.Material where nomeBiblioteca in (select nome from deleted)
		delete from Biblestia.Biblioteca where nome in (select nome from deleted)
	end
go

create trigger Delete_Funcionario on Biblestia.Funcionario instead of delete
as
	begin
		set nocount on;
		delete c from Biblestia.Cargo c join deleted d on c.idFuncionario=d.idFuncionario and c.nomeBiblioteca=d.nomeBiblioteca;
		update Biblestia.Atividade set idFuncResponsavel = null where idFuncResponsavel in (select idFuncionario from deleted)
		update Biblestia.Requisicao set idFuncResponsavel = null where idFuncResponsavel in (select idFuncionario from deleted)
		delete f from Biblestia.Funcionario f join deleted d on f.idFuncionario=d.idFuncionario and f.nomeBiblioteca=d.nomeBiblioteca;
	end
go

