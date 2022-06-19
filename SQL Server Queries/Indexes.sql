use p6g7;
go

drop index indexDataAtividade on Biblestia.Atividade;
go
create nonclustered index indexDataAtividade
on Biblestia.Atividade(dataAtividade asc)
go