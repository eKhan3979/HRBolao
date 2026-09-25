CREATE PROCEDURE u258112148_Khan.SpBEmpresaCampeonato_Adicionar(
	IdEmpresaP		Int,
	IdCampeonatoP	Int
)
Begin

	Insert 	Into	u258112148_1.TbBEmpresaCampeonato		
		(IdEmpresa, IdCampeonato, Ativo)
	Values
		(IdEmpresaP, IdCampeonatoP, 1);
		
	Select Last_Insert_ID() IdEmpresaCampeonato;
	
End