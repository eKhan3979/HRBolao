CREATE PROCEDURE u258112148_Khan.SpBCampeonato_Rodadas (
	IdCampeonatoG	Int
)
Begin

	Select 	Distinct	Rodada,
						RodadaNome
	From				u258112148_1.TbBCampeonatoJogo 
	Where				IdCampeonato	= IdCampeonatoG
	Order	By			1;

End