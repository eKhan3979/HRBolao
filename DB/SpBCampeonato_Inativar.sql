CREATE PROCEDURE u258112148_Khan.SpBCampeonato_Inativar (
	IdCampeonatoP	Int
)
Begin

	Update	u258112148_1.TbBCampeonato
	Set		Ativo			=	0
	Where	IdCampeonato	=	IdCampeonatoP;
	
End