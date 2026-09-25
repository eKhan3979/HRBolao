Create Table If Not Exists u258112148_1.TbBJogador
(
	IdJogador		int 			Not Null Primary Key AutoIncrement(1, 1),
	IdEmpresa		int				Not Null References u258112148_1.TbBEmpresa(IdEmpresa),
	NomeApelido		varchar(100)	Not Null,
	Senha			char(10)		Not Null,
	email			varchar(100)	Not Null,
	DataCadastro	datetime		Not Null,
	Ativo			bit				Not Null,
	Administrador	Bit				Null
);