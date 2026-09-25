CREATE PROCEDURE u258112148_Khan.SpBCampeonato_RodadaEmAndamento (
	IdCampeonatoG	Int
)
Begin

	Declare	rodadas Int;
    
	Select	Count(*)		Into rodadas
	From	u258112148_1.TbBCampeonatoJogo
	Where	IdCampeonato	=	IdCampeonatoG
		And	Finalizado		=	0
	Limit	1;

	If rodadas > 0 Then
		Select	Min(Rodada)			RodadaAtual
		From	u258112148_1.TbBCampeonatoJogo
		Where	IdCampeonato	=	IdCampeonatoG
			And	Finalizado		=	0
		Limit	1;
    Else
		Select	Max(Rodada)			RodadaAtual
		From	u258112148_1.TbBCampeonatoJogo
		Where	IdCampeonato	=	IdCampeonatoG
		Limit	1;
	End If;

End