Drop Procedure If Exists u258112148_1.SpBEmpresa_Get;

Delimiter @@

Create Procedure u258112148_Khan.SpBEmpresa_Get (
	IdEmpresaG	Int
)

Begin

	Select	IdEmpresa,
			NomeEmpresa,
			DataCadastro,
			Ativo
	From	u258112148_1.TbBEmpresa
	Where	IdEmpresa = IdEmpresaG;

End @@

Delimiter ;