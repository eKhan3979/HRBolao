CREATE PROCEDURE u258112148_Khan.SpBLogin (
	 emailG		VarChar(100),
	 SenhaG		Char(10)
)
Begin

	Select	IdJogador,
			IdEmpresa,
			NomeApelido,
			email,
			Ativo
	From	u258112148_1.TbBJogador
	Where	email	=	emailG
		And	Senha	=	SenhaG;

End
