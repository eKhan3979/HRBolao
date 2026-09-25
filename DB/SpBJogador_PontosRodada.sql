Drop Procedure If Exists u258112148_1.SpBJogador_PontosRodada;

Delimiter @@

CREATE Procedure u258112148_1.SpBJogador_PontosRodada
(
	IdJogadorG		Int,
	IdCampeonatoG	Int,
	RodadaG			Int
)
Begin

	Declare	a_idCampeonatoJogo		Int;
	Declare	a_golsCasaAposta		Int;
	Declare	a_golsVisitanteAposta	Int;
	Declare	a_finalizado			Int;
	Declare	a_idAposta				Int;
	Declare	a_golsCasa				Int;
	Declare	a_golsVisitante			Int;
	Declare	a_pontos				Int;
	Declare fim						Int Default False;

	Declare	curApostas Cursor For
		Select 			J.IdCampeonatoJogo,
						A.GolsTimeCasa						GolsApostaCasa,
						A.GolsTimeVisitante					GolsApostaVisitante,
						J.Finalizado,
						A.IdAposta,
						J.GolsTimeCasa,
						J.GolsTimeVisitante,
						0									Pontos
		From			u258112148_1.TbBCampeonatoJogo		J
		Left	Join	u258112148_1.TbBAposta				A
				On		J.IdCampeonatoJogo				=	A.IdCampeonatoJogo
				And		A.IdJogador						=	IdJogadorG
		Where			J.IdCampeonato					=	IdCampeonatoG
				And		J.Rodada						=	RodadaG
		Order	By		J.Yyyy_Mm_Dd, 3, 1;

	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpAposta;

	Create Temporary Table tmpAposta
	(
		IdCampeonatoJogo	Int,
		GolsCasaAposta		Int,
		GolsVisitanteAposta	Int,
		Finalizado			Bit,
		IdAposta			Int,
		GolsCasa			Int,
		GolsVisitante		Int,
		Pontos				Int
	);	

	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_idCampeonatoJogo,
								a_golsCasaAposta,
								a_golsVisitanteAposta,
								a_finalizado,
								a_idAposta,
								a_golsCasa,
								a_golsVisitante,
								a_pontos;

		If fim Then
			Leave Loop_Apostas;
		End If;
		
		Set a_pontos = 0;
		
        If a_finalizado = 1 Then
			If ((a_golsCasa = a_golsCasaAposta) And (a_golsVisitante = a_golsVisitanteAposta)) 		Then
				Set	a_pontos = 10;
			ElseIf ((a_golsCasa = a_golsVisitante) And (a_golsCasaAposta = a_golsVisitanteAposta))	Then
				Set a_pontos = 5;
			ElseIf ((a_golsCasa > a_golsVisitante) And (a_golsCasaAposta > a_golsVisitanteAposta))	Then
				If ((a_golsCasa = a_golsCasaAposta) Or (a_golsVisitante = a_golsVisitanteAposta))	Then
					Set a_pontos = 7;
				Else
					Set a_pontos = 5;
				End If;
			ElseIf ((a_golsCasa < a_golsVisitante) And (a_golsCasaAposta < a_golsVisitanteAposta))	Then
				If ((a_golsCasa = a_golsCasaAposta) Or (a_golsVisitante = a_golsVisitanteAposta))	Then
					Set a_pontos = 7;
				Else
					Set a_pontos = 5;
				End If;
			Else
				If ((a_golsCasa = a_golsCasaAposta) Or (a_golsVisitante = a_golsVisitanteAposta))	Then
					Set a_pontos = 2;
				End If;
			End If;
        End If;
        
		Insert	Into	tmpAposta
			(IdCampeonatoJogo,
			 GolsCasaAposta,
			 GolsVisitanteAposta,
			 Finalizado,
			 IdAposta,
			 GolsCasa,
			 GolsVisitante,
			 Pontos)
		Values
			(a_idCampeonatoJogo,
			 a_golsCasaAposta,
			 a_golsVisitanteAposta,
			 a_finalizado,
			 a_idAposta,
			 a_golsCasa,
			 a_golsVisitante,
			 a_pontos);
	
	End Loop;
	
	Close curApostas;

	Select 			J.IdCampeonatoJogo,
					Concat(Substring(J.Yyyy_Mm_Dd, 9, 2), '/', 
						   Substring(J.Yyyy_Mm_Dd, 6, 2), '/',
						   Substring(J.Yyyy_Mm_Dd, 1, 4)) Dd_Mm_Yyyy,
					J.Hh_Mm,
					J.IdTimeCasa,
					C.Nome								TimeCasa,
					J.GolsTimeCasa,
					J.IdTimeVisitante,
					V.Nome								TimeVisitante,	
					J.GolsTimeVisitante,
					J.Finalizado,
					A.IdAposta,
					A.GolsCasaAposta,
					A.GolsVisitanteAposta,
					A.Pontos
	From			tmpAposta							A
    Inner	Join	u258112148_1.TbBCampeonatoJogo		J
			On		A.IdCampeonatoJogo				=	J.IdCampeonatoJogo
	Inner	Join	u258112148_1.TbBTime				C
			On		J.IdTimeCasa					=	C.IdTime
	Inner	Join	u258112148_1.TbBTime				V
			On		J.IdTimeVisitante				=	V.IdTime			
	Where			J.IdCampeonato					=	IdCampeonatoG
			And		J.Rodada						=	RodadaG
	Order	By		J.Yyyy_Mm_Dd, 3, 1;

End @@

Delimiter ;