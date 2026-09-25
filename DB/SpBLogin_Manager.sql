Drop Procedure If Exists u258112148_1.SpBLogin_Manager;

Delimiter @@

Create Procedure u258112148_1.SpBLogin_Manager (
	 emailG		VarChar(100),
	 SenhaG		Char(10)
)
Begin

	Select	IdJogador,
			IdEmpresa,
			NomeApelido,
			email,
			DataCadastro,
			Ativo,
			Administrador
	From	u258112148_1.TbBJogador
	Where	email			=	emailG
		And	Senha			=	SenhaG
		And Administrador	=	1;

End @@

Delimiter ;
