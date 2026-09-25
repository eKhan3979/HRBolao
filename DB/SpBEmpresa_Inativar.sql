CREATE PROCEDURE u258112148_Khan.SpBEmpresa_Inativar (IdEmpresaG		Int)
Begin

	UpDate	u258112148_1.TbBEmpresa
	Set		Ativo		=	0
	Where	IdEmpresa	=	IdEmpresaG;
		
End