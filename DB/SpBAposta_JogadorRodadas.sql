Drop Procedure If Exists u258112148_1.SpBAposta_JogadorRodadas;

Delimiter @@

CREATE PROCEDURE u258112148_1.SpBAposta_JogadorRodadas (
	IdJogadorG		Int,
	IdCampeonatoG	Int
)
Begin

	Declare a_rodada				Int;
	Declare a_idCampeonatoJogo		Int;
	Declare	a_golsCasaAposta		Int;
	Declare	a_golsVisitanteAposta	Int;
	Declare	a_golsCasa				Int;
	Declare	a_golsVisitante			Int;

	Declare	a_pontos				Int;

	Declare fim						Int Default False;
	
	Declare	curApostas Cursor For
			Select 			J.Rodada,
							J.IdCampeonatoJogo,
							IfNull(A.GolsTimeCasa, 0)		GolsCasaAposta,
							IfNull(A.GolsTimeVisitante, 0)	GolsVisitanteAposta,
							IfNull(J.GolsTimeCasa, 0)		GolsCasa,
							IfNull(J.GolsTimeVisitante, 0)	GolsVisitante
			From			u258112148_1.TbBAposta			A
			Inner	Join	u258112148_1.TbBCampeonatoJogo	J
					On		A.IdCampeonatoJogo			=	J.IdCampeonatoJogo
			Where			A.IdJogador					=	IdJogadorG
					And		J.IdCampeonato				=	IdCampeonatoG
					And		IfNull(J.Finalizado, 0)		=	1
			Order	By		1, 2;	
							
	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpPontuacao;

	Create Temporary Table tmpPontuacao
	(
		Rodada		Int,
		RodadaNome	VarChar(20),
		Pontos		Int
	);
	
	Insert	Into	tmpPontuacao
				   (Rodada, RodadaNome, Pontos)
	Select 			Distinct	J.Rodada, J.RodadaNome, 0
	From			u258112148_1.TbBAposta			A
	Inner	Join	u258112148_1.TbBCampeonatoJogo	J
			On		A.IdCampeonatoJogo			=	J.IdCampeonatoJogo
	Where			A.IdJogador					=	IdJogadorG
			And		J.IdCampeonato				=	IdCampeonatoG
			And		IfNull(J.Finalizado, 0)		=	1
	Order	By		1;	

	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_rodada,
								a_idCampeonatoJogo,
								a_golsCasaAposta,
								a_golsVisitanteAposta,
								a_golsCasa,
								a_golsVisitante;

		If fim Then
			Leave Loop_Apostas;
		End If;
		
		Set a_pontos = 0;
		
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
        
		UpDate	tmpPontuacao
		Set		Pontos	=	Pontos + a_pontos
		Where	Rodada	=	a_rodada;
	End Loop;
	
	Close curApostas;
	
	Select		Rodada,
				RodadaNome,
				Pontos
	From		tmpPontuacao
	Order	By	1;
	
	Drop Temporary table tmpPontuacao;
	
End @@

Delimiter ;