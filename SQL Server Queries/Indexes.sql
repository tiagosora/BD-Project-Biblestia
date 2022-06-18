use p6g7;
go

drop index nomeAtividade on Biblestia.Atividade;
go
create nonclustered index nomeAtividade
on Biblestia.Atividade(nomeAtividade asc)
go