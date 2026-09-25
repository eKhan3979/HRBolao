Drop Procedure If Exists u258112148_1.SpBAposta_PontosRodadaJogador;

Delimiter @@

Create Procedure u258112148_1.SpBAposta_PontosRodadaJogador (
	IdJogadorG		Int,
	IdCampeonatoG	Int,
	RodadaG			Int
)
Begin

	Declare a_yyyy_Mm_Dd			Char(10);
	Declare	a_hh_Mm					Char(5);
	Declare a_idCampeonatoJogo		Int;
	Declare	a_golsCasaAposta		Int;
	Declare	a_golsVisitanteAposta	Int;
	Declare	a_golsCasa				Int;
	Declare	a_golsVisitante			Int;
    Declare	a_finalizado			Int;
	Declare	a_timeCasa				VarChar(50);
	Declare a_timeVisitante			VarChar(50);
	
	Declare	a_pontos				Int;

	Declare fim						Int Default False;
	
	Declare	curApostas Cursor For
			Select 			J.Yyyy_Mm_Dd,
							J.Hh_Mm,
							J.IdCampeonatoJogo,
							IfNull(A.GolsTimeCasa, 0)		GolsCasaAposta,
							IfNull(A.GolsTimeVisitante, 0)	GolsVisitanteAposta,
							IfNull(J.GolsTimeCasa, 0)		GolsCasa,
							IfNull(J.GolsTimeVisitante, 0)	GolsVisitante,
                            IfNull(J.Finalizado, 0)			Finalizado,
							C.Nome							TimeCasa,
							V.Nome							TimeVisitante
			From			u258112148_1.TbBAposta			A
			Inner	Join	u258112148_1.TbBCampeonatoJogo	J
					On		A.IdCampeonatoJogo			=	J.IdCampeonatoJogo
			Inner	Join	u258112148_1.TbBTime			C
					On		J.IdTimeCasa				=	C.IdTime
			Inner	Join	u258112148_1.TbBTime			V
					On		J.IdTimeVisitante			=	V.IdTime
			Where			A.IdJogador					=	IdJogadorG
					And		J.IdCampeonato				=	IdCampeonatoG
					And		J.Rodada					=	RodadaG
			Order	By		J.Yyyy_Mm_Dd,
							J.Hh_Mm,
							J.IdCampeonatoJogo;	
							
	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpAposta;

	Create Temporary Table tmpAposta
	(
		Yyyy_Mm_Dd			Char(10),
		Hh_Mm				Char(5),
		IdCampeonatoJogo	Int,
		GolsCasaAposta		Int,
		GolsVisitanteAposta	Int,
		GolsCasa			Int,
		GolsVisitante		Int,
		TimeCasa			VarChar(50),
		TimeVisitante		VarChar(50),
		Pontos				Int
	);

	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_yyyy_Mm_Dd,
								a_hh_Mm,
								a_idCampeonatoJogo,
								a_golsCasaAposta,
								a_golsVisitanteAposta,
								a_golsCasa,
								a_golsVisitante,
                                a_finalizado,
								a_timeCasa,
								a_timeVisitante;

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
			(Yyyy_Mm_Dd, Hh_Mm, IdCampeonatoJogo, GolsCasaAposta, GolsVisitanteAposta, GolsCasa, GolsVisitante, TimeCasa, TimeVisitante, Pontos)
		Values
			(a_yyyy_Mm_Dd,
			 a_hh_Mm,
			 a_idCampeonatoJogo, 
             a_golsCasaAposta, 
             a_golsVisitanteAposta, 
             a_golsCasa, 
             a_golsVisitante, 
             a_timeCasa, 
             a_timeVisitante, 
             a_pontos);
	
	End Loop;
	
	Close curApostas;
	
	Select		Yyyy_Mm_Dd,
				Hh_Mm,
				IdCampeonatoJogo,
				GolsCasaAposta,
				GolsVisitanteAposta,
				GolsCasa,
				GolsVisitante,
				TimeCasa,
				TimeVisitante,
				Pontos
	From		tmpAposta
	Order	By	1, 2, 3;
	
	Drop Temporary table tmpAposta;
	
End @@

Delimiter ;