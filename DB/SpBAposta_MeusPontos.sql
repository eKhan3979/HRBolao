CREATE PROCEDURE u258112148_Khan.SpBAposta_MeusPontos (
	IdJogadorG		Int,
	IdCampeonatoG	Int
)
Begin

	Declare	a_rodada				Int;
	Declare	a_idCampeonatoJogo		Int;
	Declare	a_golsCasa				Int;
	Declare	a_golsVisitante			Int;
	Declare	a_golsCasaAposta		Int;
	Declare	a_golsVisitanteAposta	Int;
	
	Declare	a_pontos					Int;

	Declare fim							Int Default False;
	
	Declare	curApostas Cursor For
			Select			J.Rodada,
							J.IdCampeonatoJogo,
							J.GolsTimeCasa,
							J.GolsTimeVisitante,
							A.GolsTimeCasa					GolsCasaAposta,
							A.GolsTimeVisitante				GolsVisitanteAposta
			From			u258112148_1.TbBCampeonatoJogo	J
			Inner	Join	u258112148_1.TbBAposta			A
					On		J.IdCampeonatoJogo			=	A.IdCampeonatoJogo
			Where			J.IdCampeonato				=	IdCampeonatoG
					And		J.Finalizado				=	1
					And		A.IdJogador					=	IdJogadorG
			Order	By		1, 2;	

	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpPorRodada;

	Create Temporary Table tmpPorRodada
	(
		Rodada	Int,
		Pontos	Int		
	);
	
	Insert	Into		tmpPorRodada
	Select	Distinct	Rodada, 0
	From				u258112148_1.TbBCampeonatoJogo
	Where				IdCampeonato	=	IdCampeonatoG
	Order	By			1;
	
	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_rodada,
								a_idCampeonatoJogo,
								a_golsCasa,
								a_golsVisitante,
								a_golsCasaAposta,
								a_golsVisitanteAposta;

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
        
		UpDate	tmpPorRodada
		Set		Pontos		=	Pontos + a_pontos
		Where	Rodada		=	a_rodada;
	
	End Loop;
	
	Close curApostas;
	
	Select		Rodada,
				Pontos
	From		tmpPorRodada
	Order	By	1;
	
	Drop Temporary Table tmpPorRodada;
	
End