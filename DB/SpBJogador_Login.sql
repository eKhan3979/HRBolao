CREATE PROCEDURE u258112148_Khan.SpBJogador_Login (
	 IdEmpresaG		Int,
	 NomeApelidoG	VarChar(100),
	 SenhaG			Char(10)
)
Begin

	Select	IdJogador,
			IdEmpresa,
			NomeApelido,
			Senha,
			email,
			DataCadastro,
			Ativo
	From	u258112148_1.TbBJogador
	Where	IdEmpresa	=	IdEmpresaG
		And	NomeApelido	=	NomeApelidoG
		And	Senha		=	SenhaG;

End