CREATE PROCEDURE u258112148_Khan.SpBJogador_ListaDaEmpresa (
	 IdEmpresaG		Int
)
Begin

	Select		IdJogador,
				IdEmpresa,
				NomeApelido,
				email,
				DataCadastro,
				Ativo
	From		u258112148_1.TbBJogador
	Where		IdEmpresa	=	IdEmpresaG
		And		Ativo		=	1
	Order	By	NomeApelido;

End