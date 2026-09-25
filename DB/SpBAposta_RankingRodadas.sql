CREATE PROCEDURE u258112148_Khan.SpBAposta_RankingRodadas (
	IdEmpresaG		Int,
	IdCampeonatoG	Int
)
Begin

	Declare a_rodada				Int;
	Declare a_idJogador				Int;
	Declare a_idCampeonatoJogo		Int;
	Declare	a_golsCasaAposta		Int;
	Declare	a_golsVisitanteAposta	Int;
	Declare	a_golsCasa				Int;
	Declare	a_golsVisitante			Int;

	Declare	a_pontos				Int;

	Declare fim						Int Default False;
	
	Declare	curApostas Cursor For
			Select 			J.Rodada,
							A.IdJogador,
							J.IdCampeonatoJogo,
							IfNull(A.GolsTimeCasa, 0)		GolsCasaAposta,
							IfNull(A.GolsTimeVisitante, 0)	GolsVisitanteAposta,
							IfNull(J.GolsTimeCasa, 0)		GolsCasa,
							IfNull(J.GolsTimeVisitante, 0)	GolsVisitante
			From			u258112148_1.TbBJogador			R
			Inner	Join	u258112148_1.TbBAposta			A
					On		R.IdJogador					=	A.IdJogador
			Inner	Join	u258112148_1.TbBCampeonatoJogo	J
					On		A.IdCampeonatoJogo			=	J.IdCampeonatoJogo
			Where			R.IdEmpresa					=	IdEmpresaG
					And		J.IdCampeonato				=	IdCampeonatoG
					And		IfNull(J.Finalizado, 0)		=	1
			Order	By		1, 2;	
							
	Declare Continue Handler For Not Found Set fim = True;

	Drop Temporary Table If Exists tmpPontuacao;

	Create Temporary Table tmpPontuacao
	(
		Rodada		Int,
		IdJogador	Int,
		Pontos		Int
	);
	
	Insert	Into	tmpPontuacao
				   (Rodada, IdJogador, Pontos)
	Select 			Distinct	J.Rodada, R.IdJogador, 0
	From			u258112148_1.TbBJogador			R
	Inner	Join	u258112148_1.TbBAposta			A
			On		R.IdJogador					=	A.IdJogador
	Inner	Join	u258112148_1.TbBCampeonatoJogo	J
			On		A.IdCampeonatoJogo			=	J.IdCampeonatoJogo
	Where			R.IdEmpresa					=	IdEmpresaG
			And		J.IdCampeonato				=	IdCampeonatoG
			And		IfNull(J.Finalizado, 0)		=	1
	Order	By		1, 2;	

	Open curApostas;
	
	Loop_Apostas: Loop
		Fetch curApostas Into	a_rodada,
								a_idJogador,
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
		Set		Pontos		=	Pontos + a_pontos
		Where	Rodada		=	a_rodada
			And	IdJogador	=	a_idJogador;
	End Loop;
	
	Close curApostas;
	
	Select			P.Rodada,
					P.Pontos,
					R.NomeApelido,
					P.IdJogador
	From			tmpPontuacao			P
	Inner	Join	u258112148_1.TbBJogador	R
			On		P.IdJogador			=	R.IdJogador
	Order	By		1, 2 Desc, 3;
	
	Drop Temporary table tmpPontuacao;
	
End