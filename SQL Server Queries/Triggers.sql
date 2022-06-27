use p6g7;
go
-- This file is not designed with the intent of being executed repeatedly

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
		delete from Biblestia.Cargo where idFuncionario in (select idFuncionario from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		update Biblestia.Atividade set idFuncResponsavel = null where idFuncResponsavel in (select idFuncionario from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		update Biblestia.Requisicao set idFuncResponsavel = null where idFuncResponsavel in (select idFuncionario from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Funcionario where idFuncionario in (select idFuncionario from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
	end
go
create trigger Delete_Leitor on Biblestia.Leitor instead of delete
as
	begin
		set nocount on;
		delete from Biblestia.AtividadeLeitor where idLeitor in (select idLeitor from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		update Biblestia.Requisicao set idLeitor = null where idLeitor in (select idLeitor from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Leitor where idLeitor in (select idLeitor from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
	end
go
create trigger Delete_Atividade on Biblestia.Atividade instead of delete
as
	begin
		set nocount on;
		delete from Biblestia.AtividadeLeitor where nomeAtividade in (select nomeAtividade from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Atividade where nomeAtividade in (select nomeAtividade from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
	end
go
create trigger Delete_Requisicao on Biblestia.Requisicao instead of delete
as
	begin
		set nocount on; 
		delete from Biblestia.RequisicaoMaterial where idRequisicao in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Requisicao where id in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
	end
go
create trigger Delete_Material on Biblestia.Material instead of delete
as
	begin
		set nocount on;
		delete from Biblestia.RequisicaoMaterial where idMaterial in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Livro where idMaterial in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Jornal where idMaterial in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Revista where idMaterial in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Jogo where idMaterial in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.CD where idMaterial in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
		delete from Biblestia.Material where id in (select id from deleted) and nomeBiblioteca in (select nomeBiblioteca from deleted)
	end
go
create trigger checkDatesFuncionario on Biblestia.Cargo for insert, update
as
	begin
		if ((update(dataFim) or update(dataInicio)) and exists(select 1 from inserted where dataInicio>dataFim))
		begin
			raiserror('As datas inseridas não fazem sentido',16,1);
			rollback;
		end
	end
go