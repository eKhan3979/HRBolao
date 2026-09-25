CREATE PROCEDURE u258112148_Khan.SpBCampeonato_JogadorApostasRodada (
	IdCampeonatoG	Int,
	IdJogadorG		Int,
	RodadaG			Int
)
Begin

	Select 			J.IdCampeonatoJogo,
					Concat(Substring(J.Yyyy_Mm_Dd, 9, 2), '/', 
						   Substring(J.Yyyy_Mm_Dd, 6, 2), '/',
						   Substring(J.Yyyy_Mm_Dd, 1, 4)) Dd_Mm_Yyyy,
					J.Hh_Mm,
					J.IdTimeCasa,
					C.Nome							TimeCasa,
					J.GolsTimeCasa,
					J.IdTimeVisitante,
					V.Nome							TimeVisitante,	
					J.GolsTimeVisitante,
					J.Finalizado,
					A.IdAposta,
					A.GolsTimeCasa					GolsApostaTimeCasa,
					A.GolsTimeVisitante				GolsApostaTimeVisitante,
					0								Editavel
	From			u258112148_1.TbBCampeonatoJogo	J
	Inner	Join	u258112148_1.TbBTime			C
			On		J.IdTimeCasa				=	C.IdTime
	Inner	Join	u258112148_1.TbBTime			V
			On		J.IdTimeVisitante			=	V.IdTime
	Left	Join	u258112148_1.TbBAposta			A
			On		J.IdCampeonatoJogo			=	A.IdCampeonatoJogo
			And		A.IdJogador					=	IdJogadorG
	Where			J.IdCampeonato				=	IdCampeonatoG
			And		J.Rodada					=	RodadaG
	Order	By		J.Yyyy_Mm_Dd, 3, 1;

End