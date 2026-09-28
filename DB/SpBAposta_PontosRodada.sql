Drop Procedure If Exists u258112148_1.SpBAposta_PontosRodada;

Delimiter @@

Create Procedure u258112148_1.SpBAposta_PontosRodada (
	IdEmpresaG		Int,
	IdCampeonatoG	Int,
	Rodada			Int
)
Begin

	Declare	a_idCampeonatoJogo		Int;
	Declare	a_idJogador				Int;
	Declare	a_golsCasa				Int;
	Declare	a_golsVisitante			Int;
	Declare	a_golsCasaAposta		Int;
	Declare	a_golsVisitanteAposta	Int;
	
	Declare	a_pontos					Int;

	Declare fim							Int Default False;
	
	Declare	curApostas Cursor For
			Select			C.IdCampeonatoJogo,
							J.IdJogador,
							C.GolsTimeCasa,
							C.GolsTimeVisitante,
							A.GolsTimeCasa						GolsTimeCasaAposta,
							A.GolsTimeVisitante					GolsTimeVisitanteAposta
			From			u258112148_1.TbBJogador				J
			Inner	Join	u258112148_1.TbBAposta				A
					On		J.IdJogador						=	A.IdJogador
			Inner	Join	u258112148_1.TbBCampeonatoJogo		C
					On		A.IdCampeonatoJogo				=	C.IdCampeonatoJogo
			Where			J.IdEmpresa						=	IdEmpresaG
					And		C.IdCampeonato					=	IdCampeonatoG
					And		C.Rodada						=	Rodada
					And		C.Finalizado					=	1
					And		J.Ativo							=	1
			Order	By		1, 2;
	
	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpRanking;

	Create Temporary Table tmpRanking
	(
		NomeApelido	VarChar(100),
		IdJogador	Int,
		Pontos		Int		
	);
	
	Insert	Into	tmpRanking
	Select		NomeApelido,
				IdJogador,
				0
	From		u258112148_1.TbBJogador
	Where		IdEmpresa	=	IdEmpresaG
		And		Ativo		=	1
	Order	By	1;
	
	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_idCampeonatoJogo,
								a_idJogador,
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
        
		UpDate	tmpRanking
		Set		Pontos		=	Pontos + a_pontos
		Where	IdJogador	=	a_idJogador;
	
	End Loop;
	
	Close curApostas;
	
	Select		NomeApelido,
				IdJogador,
				Pontos
	From		tmpRanking
	Order	By	3 Desc, 1;
	
	Drop Temporary Table tmpRanking;
	
	
End @@

Delimiter ;