CREATE PROCEDURE u258112148_Khan.SpBJogador_Get (
	 IdEmpresaG		Int,
	 NomeApelidoG	VarChar(100)
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
	Where	IdEmpresa	= IdEmpresaG
		And	NomeApelido	= NomeApelidoG;

End