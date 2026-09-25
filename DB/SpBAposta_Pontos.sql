CREATE PROCEDURE u258112148_Khan.SpBAposta_Pontos (
	IdApostaG	Int
)
Begin

	Declare	golsCasaP				Int;
	Declare	golsVisitanteP			Int;
	Declare	golsCasaApostaP			Int;
	Declare	golsVisitanteApostaP	Int;
	Declare	idCampeonatoJogoP		Int;
	Declare	pontos					Int;

	Set		pontos					=	0;

	Select	IdCampeonatoJogo		Into	idCampeonatoJogoP
	From	u258112148_1.TbBAposta
	Where	IdAposta				=		IdApostaG;
    
    Select	IdCampeonatoJogo		Into	idCampeonatoJogoP
    From	u258112148_1.TbBAposta
    Where	IdAposta				=		IdApostaG;

	Select	GolsTimeCasa			Into	golsCasaApostaP
	From	u258112148_1.TbBAposta
	Where	IdAposta				=		IdApostaG;

	Select	GolsTimeVisitante		Into	golsVisitanteApostaP
	From	u258112148_1.TbBAposta
	Where	IdAposta				=		IdApostaG;
			
	Select	GolsTimeCasa			Into	golsCasaP
	From	u258112148_1.TbBCampeonatoJogo
	Where	IdCampeonatoJogo		=		idCampeonatoJogoP;

	Select	GolsTimeVisitante		Into	golsVisitanteP
	From	u258112148_1.TbBCampeonatoJogo
	Where	IdCampeonatoJogo		=		idCampeonatoJogoP;

	If ((golsCasaP = golsCasaApostaP) And (golsVisitanteP = golsVisitanteApostaP)) 		Then
		Set	pontos = 10;
	ElseIf ((golsCasaP = golsVisitanteP) And (golsCasaApostaP = golsVisitanteApostaP))	Then
		Set pontos = 5;
	ElseIf ((golsCasaP > golsVisitanteP) And (golsCasaApostaP > golsVisitanteApostaP))	Then
		If ((golsCasaP = golsCasaApostaP) Or (golsVisitanteP = golsVisitanteApostaP))	Then
			Set pontos = 7;
		Else
			Set pontos = 5;
		End If;
	ElseIf ((golsCasaP < golsVisitanteP) And (golsCasaApostaP < golsVisitanteApostaP))	Then
		If ((golsCasaP = golsCasaApostaP) Or (golsVisitanteP = golsVisitanteApostaP))	Then
			Set pontos = 7;
		Else
			Set pontos = 5;
		End If;
	Else
		If ((golsCasaP = golsCasaApostaP) Or (golsVisitanteP = golsVisitanteApostaP))	Then
			Set pontos = 2;
		End If;
	End If;
	
	Select	pontos	Pontos;
	
End