use p6g7;
go

drop index indexDataAtividade on Biblestia.Atividade;
go
create nonclustered index indexDataAtividade
on Biblestia.Atividade(nomeAtividade asc)
go