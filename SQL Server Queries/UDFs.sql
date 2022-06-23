use p6g7;
go

-- Obter todos os funcionários de uma biblioteca
drop function Biblestia.obterFuncionários; 
go 
create function Biblestia.obterFuncionários(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Funcionario
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter os funcionários atuais de um biblioteca
drop function Biblestia.obterFuncionariosAtuais;
go
create function Biblestia.obterFuncionariosAtuais(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as FuncionariosAtuais
			from (Biblestia.Funcionario join Biblestia.Cargo on Funcionario.idFuncionario = Cargo.idFuncionario)
			where Funcionario.nomeBiblioteca = @nomeBiblioteca and dataFim is null;
go  

-- Obter cargos de um dado funcionario
drop function Biblestia.obterCargosFuncionario; 
go 
create function Biblestia.obterCargosFuncionario(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Cargo
			where idFuncionario = @id and nomeBiblioteca = @nomeBiblioteca
go 

-- Obter cargos de um dado funcionario
drop function Biblestia.obterMateriais; 
go 
create function Biblestia.obterMateriais(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Cargo
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todos os funcionários de uma biblioteca
drop function Biblestia.obterLeitores; 
go 
create function Biblestia.obterLeitores(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Leitor
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter as atividades de um dado leitor
drop function Biblestia.obterAtividadesLeitor; 
go
create function Biblestia.obterAtividadesLeitor(@idLeitor int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.AtividadeLeitor
			where idLeitor = @idLeitor and nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as atividades de uma biblioteca
drop function Biblestia.obterAtividades; 
go
create function Biblestia.obterAtividades(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Atividade
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as atividades em que um dado funcionário foi responsável
drop function Biblestia.obterAtvidadesResponsavel; 
go
create function Biblestia.obterAtvidadesResponsavel(@idFuncionario int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Atividade
			where idFuncResponsavel = @idFuncionario and nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de todos os tipos de materiais de um biblioteca
drop function Biblestia.obterDadosMateriais; 
go 
create function Biblestia.obterDadosMateriais(@nomeBiblioteca varchar(60)) returns table
as
	return	select A.name, sum(B.rows) as count
			from sys.objects A inner join sys.partitions B on A.object_id = B.object_id
			where	schema_name(A.schema_id) = 'Biblestia' and
					(A.name='Livro' or A.name='Revista' or A.name='Jornal' or A.name='Jogo' or A.name='CD')
			group by A.schema_id, A.name;
go

-- Obter todos os materiais de uma biblioteca
drop function Biblestia.obterMateriais
go
create function Biblestia.obterMateriais(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Material
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterLivros
go
create function Biblestia.obterLivros(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Livro
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterJornais
go
create function Biblestia.obterJornais(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Jornal
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterRevistas 
go
create function Biblestia.obterRevistas(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Revista
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterJogos
go
create function Biblestia.obterJogos(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Jogo
			where nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterCDs
go
create function Biblestia.obterCDs(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.CD
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as requisições de uma biblioteca;
drop function Biblestia.obterRequisicoes
go
create function Biblestia.obterRequisicoes(@nomeBiblioteca varchar(60)) returns table
as
	return	select * from RequisicaoDados
			where nomeBiblioteca = @nomeBiblioteca;
go

-- Obter requisições de um dado Material
drop function Biblestia.obterRequisicoesMaterial
go
create function Biblestia.obterRequisicoesMaterial(@idMaterial int, @nomeBiblioteca varchar(60)) returns table 
as
	return	select * from RequisicaoDados
			where idMaterial = @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go 

-- Obter o número de livros de uma requisição
drop function Biblestia.obterLivrosRequisicao;
go
create function Biblestia.obterLivrosRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Livro on RequisicaoMaterial.idMaterial = Livro.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
-- Obter o número de jornais de uma requisição
drop function Biblestia.obterJornaisRequisicao;
go
create function Biblestia.obterJornaisRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Jornal on RequisicaoMaterial.idMaterial = Jornal.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go 
-- Obter o número de revistas de uma requisição
drop function Biblestia.obterRevistasRequisicao;
go
create function Biblestia.obterRevistasRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Revista on RequisicaoMaterial.idMaterial = Revista.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
-- Obter o número de jogos de uma requisição
drop function Biblestia.obterJogosRequisicao;
go
create function Biblestia.obterJogosRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join Jogo on RequisicaoMaterial.idMaterial = Jogo.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go
-- Obter o número de cds de uma requisição
drop function Biblestia.obterCDsRequisicao;
go
create function Biblestia.obterCDsRequisicao(@id int, @nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont 
			from RequisicaoMaterial join CD on RequisicaoMaterial.idMaterial = CD.idMaterial
			where idRequisicao=@id and RequisicaoMaterial.nomeBiblioteca=@nomeBiblioteca;
go 

-- Obter os dados de um dado Material
drop function Biblestia.obterDadosMaterial
go
create function Biblestia.obterDadosMaterial(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Material
			where id =  @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterDadosLivro
go
create function Biblestia.obterDadosLivro(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Livro
			where idMaterial =  @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterDadosJornal
go
create function Biblestia.obterDadosJornal(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Jornal
			where idMaterial =  @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterDadosRevista
go
create function Biblestia.obterDadosRevista(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Revista
			where idMaterial =  @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterDadosJogo
go
create function Biblestia.obterDadosJogo(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Jogo
			where idMaterial =  @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go
drop function Biblestia.obterDadosCD
go
create function Biblestia.obterDadosCD(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.CD
			where idMaterial =  @idMaterial and nomeBiblioteca = @nomeBiblioteca;
go

-- Obter dados e de um leitor
drop function Biblestia.obterDadosLeitor
go
create function Biblestia.obterDadosLeitor(@idLeitor int, @nomeBiblioteca varchar(60)) returns table
as
	return	select * from Biblestia.Leitor
			where idLeitor = @idLeitor and nomeBiblioteca = @nomeBiblioteca;
go

-- Obter todas as requisições de um dado leitor
drop function Biblestia.obterRequisicoesLeitor
go
create function Biblestia.obterRequisicoesLeitor(@idLeitor int, @nomeBiblioteca varchar(60)) returns table
as
	return	select Requisicao.*, Leitor.nomeCompleto as nomeCompletoLeitor
			from (Biblestia.Requisicao join Biblestia.Leitor on Requisicao.IdLeitor=Leitor.idLeitor)
			where Requisicao.idLeitor = @idLeitor and Requisicao.nomeBiblioteca = @nomeBiblioteca;
go  

-- Obter o leitor que requisita um dado material
drop function Biblestia.obterRequisitor
go
create function Biblestia.obterRequisitor(@idMaterial int, @nomeBiblioteca varchar(60)) returns table
as
	return	select	Leitor.idLeitor, Leitor.nomeCompleto
			from	((Biblestia.RequisicaoMaterial join Biblestia.Requisicao on RequisicaoMaterial.idRequisicao = Requisicao.id)
					join Biblestia.Leitor on Requisicao.idLeitor = Leitor.idLeitor)
			where	Requisicao.dataEntrega is null and RequisicaoMaterial.idMaterial = @idMaterial and Requisicao.nomeBiblioteca = @nomeBiblioteca;
go

-- obter o numero total de livros de uma biblioteca
drop function Biblestia.obterNumeroTotalLivros;
go
create function Biblestia.obterNumeroTotalLivros(@nomeBiblioteca varchar(60)) returns table
as 
	return select count(*) as cont 
			from ((Biblestia.Livro join Biblestia.Material on Livro.idMaterial = Material.id)) 
				where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- obter o numero total de jornais de uma biblioteca
drop function Biblestia.obterNumeroTotalJornais;
go
create function Biblestia.obterNumeroTotalJornais(@nomeBiblioteca varchar(60)) returns table
as 
	return select count(*) as cont 
			from ((Biblestia.Jornal join Biblestia.Material on Jornal.idMaterial = Material.id)) 
				where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- obter o numero total de revistas de uma biblioteca
drop function Biblestia.obterNumeroTotalRevistas;
go
create function Biblestia.obterNumeroTotalRevistas(@nomeBiblioteca varchar(60)) returns table
as 
	return select count(*) as cont 
			from ((Biblestia.Revista join Biblestia.Material on Revista.idMaterial = Material.id)) 
				where Material.nomeBiblioteca = @nomeBiblioteca;
go
-- obter o numero total de jogos de uma biblioteca
drop function Biblestia.obterNumeroTotalJogos;
go
create function Biblestia.obterNumeroTotalJogos(@nomeBiblioteca varchar(60)) returns table
as  
	return select count(*) as cont 
			from ((Biblestia.Jogo join Biblestia.Material on Jogo.idMaterial = Material.id)) 
				where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- obter o numero total de Cd de uma biblioteca
drop function Biblestia.obterNumeroTotalCDs;
go
create function Biblestia.obterNumeroTotalCDs(@nomeBiblioteca varchar(60)) returns table
as 
	return select count(*) as cont 
			from ((Biblestia.CD join Biblestia.Material on CD.idMaterial = Material.id)) 
				where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de requisições
drop function Biblestia.nReq;
go
create function Biblestia.nReq(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont
			from Biblestia.RequisicaoMaterial
			where RequisicaoMaterial.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de livros em requisições
drop function Biblestia.nLivrosReq;
go
create function Biblestia.nLivrosReq(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont
			from	((Biblestia.RequisicaoMaterial join Biblestia.Material on RequisicaoMaterial.idMaterial=Material.id)
					join Biblestia.Livro on Material.id=Livro.idMaterial)
			where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de jornais em requisições
drop function Biblestia.nJornalReq;
go
create function Biblestia.nJornalReq(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont
			from	((Biblestia.RequisicaoMaterial join Biblestia.Material on RequisicaoMaterial.idMaterial=Material.id)
					join Biblestia.Jornal on Material.id=Jornal.idMaterial)
			where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de revistas em requisições
drop function Biblestia.nRevistaReq;
go
create function Biblestia.nRevistaReq(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont
			from	((Biblestia.RequisicaoMaterial join Biblestia.Material on RequisicaoMaterial.idMaterial=Material.id)
					join Biblestia.Revista on Material.id=Revista.idMaterial)
			where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de jogos em requisições
drop function Biblestia.nJogoReq;
go
create function Biblestia.nJogoReq(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont
			from	((Biblestia.RequisicaoMaterial join Biblestia.Material on RequisicaoMaterial.idMaterial=Material.id)
					join Biblestia.Jogo on Material.id=Jogo.idMaterial)
			where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter o número de cds em requisições
drop function Biblestia.nCDsReq;
go
create function Biblestia.nCDsReq(@nomeBiblioteca varchar(60)) returns table
as
	return	select count(*) as cont
			from	((Biblestia.RequisicaoMaterial join Biblestia.Material on RequisicaoMaterial.idMaterial=Material.id)
					join Biblestia.CD on Material.id=CD.idMaterial)
			where Material.nomeBiblioteca = @nomeBiblioteca;
go

-- Obter os generos dos livros
drop function Biblestia.obterContGeneros;
go
create function Biblestia.obterContGeneros(@nomeBiblioteca varchar(60)) returns table
as
	return	select genero, count(*) as cont
			from Biblestia.Livro
			where Livro.nomeBiblioteca = @nomeBiblioteca and genero is not null
			group by genero;
go

-- Obter a categoria revista 
drop function Biblestia.obterContCategoria;
go
create function Biblestia.obterContCategoria(@nomeBiblioteca varchar(60)) returns table
as 
	return	select categoria, count(*) as cont
			from Biblestia.Revista
			where Revista.nomeBiblioteca = @nomeBiblioteca and categoria is not null
			group by categoria;
go

-- Obter a categoria com mais jogos
drop function Biblestia.obterContCategoriaJogos;
go
create function Biblestia.obterContCategoriaJogos(@nomeBiblioteca varchar(60)) returns table
as
	return	select categoria, count(*) as cont
			from Biblestia.Jogo
			where Jogo.nomeBiblioteca = @nomeBiblioteca and categoria is not null
			group by categoria;
go

-- Obter tipo com mais CDS
drop function Biblestia.obterContTipoCds;
go
create function Biblestia.obterContTipoCds(@nomeBiblioteca varchar(60)) returns table
as
	return	select categoria, count(*) as cont
			from Biblestia.CD
			where CD.nomeBiblioteca = @nomeBiblioteca and categoria is not null
			group by categoria;
go

-- Obter maior editora // JORNAL
drop function Biblestia.obterContEditora;
go
create function Biblestia.obterContEditora(@nomeBiblioteca varchar(60)) returns table
as
	return	select nomeEditora, count(*) as cont
			from Biblestia.Jornal
			where Jornal.nomeBiblioteca = @nomeBiblioteca and nomeEditora is not null
			group by nomeEditora;
go

-- Obter o número de atividades de cada leitor (order by idLeitor desc)
drop function Biblestia.nAtividadesLeitor
go
create function Biblestia.nAtividadesLeitor(@nomeBiblioteca varchar(60)) returns table 
as 
	return select idLeitor, count(*) as cont 
		from Biblestia.AtividadeLeitor
		where nomeBiblioteca = @nomeBiblioteca
		group by idLeitor; 
go 

