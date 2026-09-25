CREATE PROCEDURE u258112148_Khan.SpBEmpresa_Gravar (IdEmpresaG		Int,
	 NomeEmpresaG	VarChar(100))
Begin

	Declare	Id Int;
	
	Set Id = 0;
	
	If Id = 0 Then
		Insert	Into u258112148_1.TbBEmpresa
				(NomeEmpresa, DataCadastro, Ativo)
		Values
				(NomeEmpresaG, Now(), 1);

		Select Last_Insert_ID() Into Id;
	Else
		UpDate	u258112148_1.TbBEmpresa
		Set		NomeEmpresa	=	NomeEmpresaG
		Where	IdEmpresa	=	IdEmpresaG;
		
		Select IdEmpresaG Into Id;
	End If;
	
	Select	Id	IdEmpresa;

End