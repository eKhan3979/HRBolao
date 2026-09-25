CREATE PROCEDURE u258112148_Khan.SpBCampeonatoTimes_Disponiveis (
	IdCampeonatoG	Int
)
Begin

	Select		IdTime, 
				Nome,
				Abreviatura
	From		u258112148_1.TbBTime
	Where		Ativo	=	1
		And		IdTime	Not In (Select	IdTime
								From	u258112148_1.TbBCampeonatoTime
								Where	IdCampeonato	=	IdCampeonatoG)
	Order	By		2;

End