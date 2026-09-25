CREATE PROCEDURE u258112148_Khan.SpBJogo_Excluir (
	IdCampeonatoJogoG	Int
)
Begin

	Delete
	From	u258112148_1.TbBCampeonatoJogo
	Where	IdCampeonatoJogo	=	IdCampeonatoJogoG;

End