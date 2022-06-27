use p6g7;
go

drop view Biblestia.RequisicaoDados;
go
create view Biblestia.RequisicaoDados
as
	select Requisicao.*, RequisicaoMaterial.idMaterial, Funcionario.nomeCompleto as nomeCompletoFuncResponsavel, Leitor.nomeCompleto as nomeCompletoLeitor
	from	((Biblestia.Requisicao join Biblestia.RequisicaoMaterial on id=idRequisicao) 
			join Biblestia.Funcionario on idFuncionario=idFuncResponsavel)
			join Biblestia.Leitor on Requisicao.IdLeitor=Leitor.idLeitor;
go 

drop view Biblestia.LeitoresTaxaParticipacao;
go
create view Biblestia.LeitoresTaxaParticipacao
as
	select	contAti, contReq, contAti*contReq as score, Leitor.*
	from	((Biblestia.LeitoresNumeroAtividades join Biblestia.LeitoresNumeroRequisicoes 
				on (LeitoresNumeroAtividades.idLeitor=LeitoresNumeroRequisicoes.idLeitor 
				and LeitoresNumeroAtividades.nomeBiblioteca=LeitoresNumeroRequisicoes.nomeBiblioteca)) 
			join Biblestia.Leitor on LeitoresNumeroAtividades.idLeitor=Leitor.idLeitor)
go

drop view Biblestia.LeitoresNumeroAtividades;
go
create view Biblestia.LeitoresNumeroAtividades
as
	select nomeBiblioteca, idLeitor, count(*) as contAti from Biblestia.AtividadeLeitor
	group by nomeBiblioteca, idLeitor
go

drop view Biblestia.LeitoresNumeroRequisicoes;
go
create view Biblestia.LeitoresNumeroRequisicoes
as
	select nomeBiblioteca, idLeitor, count(*) as contReq from Biblestia.Requisicao
	group by nomeBiblioteca, idLeitor
go


