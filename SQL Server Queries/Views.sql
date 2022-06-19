drop view RequisicaoDados;
go
create view RequisicaoDados
as
	select Requisicao.*, RequisicaoMaterial.idMaterial, Funcionario.nomeCompleto as nomeCompletoFuncResponsavel, Leitor.nomeCompleto as nomeCompletoLeitor
	from	((Biblestia.Requisicao join Biblestia.RequisicaoMaterial on id=idRequisicao) 
			join Biblestia.Funcionario on idFuncionario=idFuncResponsavel)
			join Biblestia.Leitor on Requisicao.IdLeitor=Leitor.idLeitor;
go 

