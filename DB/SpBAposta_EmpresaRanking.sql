CREATE PROCEDURE u258112148_1.SpBAposta_EmpresaRanking
(
	IdEmpresaG		Int,
	IdCampeonatoG	Int
)
Begin

	Declare	a_idJogador				Int;
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
							R.IdJogador,
							J.GolsTimeCasa,
							J.GolsTimeVisitante,
							A.GolsTimeCasa						GolsCasaAposta,
							A.GolsTimeVisitante					GolsVisitanteAposta
			From			u258112148_1.TbBEmpresa				E
			Inner	Join	u258112148_1.TbBJogador				R
					On		E.IdEmpresa						=	R.IdEmpresa
			Inner	Join	u258112148_1.TbBCampeonatoJogo		J
					On		J.IdCampeonato					=	IdCampeonatoG
			Inner	Join	u258112148_1.TbBAposta				A
					On		R.IdJogador						=	A.IdJogador
                    And		J.IdCampeonatoJogo				=	A.IdCampeonatoJogo
			Where			E.IdEmpresa						=	IdEmpresaG
					And		J.Finalizado					=	1
			Order	By		1, 2, 3;	

	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpJogador;
	
	Create Temporary Table tmpRanking
	(
		IdJogador	Int,
		Rodada		Int,
		Pontos		Int
	);
	
	Insert	Into		tmpRanking
	Select	Distinct	J.IdJogador,
						Rodada,
						0
	From				u258112148_1.TbBJogador				J
	Inner	Join		u258112148_1.TbBCampeonato			C
			On			J.IdEmpresa						=	IdEmpresaG
			And			C.IdCampeonato					=	IdCampeonatoG
	Inner	Join		u258112148_1.TbBCampeonatoJogo		G
			On			C.IdCampeonato					=	G.IdCampeonato
	Order	By			1;
	
	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_rodada,
								a_idCampeonatoJogo,
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
		Where	IdJogador	=	a_idJogador
			And	Rodada		=	a_rodada;
	
	End Loop;
	
	Close curApostas;
	
    /*
	Select			J.NomeApelido,
					J.IdJogador,
                    R.Rodada,
					R.Pontos
	From			tmpRanking					R
	Inner	Join	u258112148_1.TbBJogador		J
			On		R.IdJogador				=	J.IdJogador
	Order	By		1, 3;
    */
    
	Select			J.NomeApelido,
					J.IdJogador,
					Sum(R.Pontos)				Pontos
	From			tmpRanking					R
	Inner	Join	u258112148_1.TbBJogador		J
			On		R.IdJogador				=	J.IdJogador
	Group	By		J.NomeApelido,
					J.IdJogador
	Order	By		3 Desc, 1;
	
	Drop Temporary Table tmpRanking;
	
End