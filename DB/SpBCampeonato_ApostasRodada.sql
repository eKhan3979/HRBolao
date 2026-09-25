CREATE PROCEDURE u258112148_Khan.SpBCampeonato_ApostasRodada (
	IdCampeonatoG	Int,
	IdJogadorG		Int,
	RodadaG			Int
)
Begin

	Select 			J.IdCampeonatoJogo,
					J.Yyyy_Mm_Dd,
					J.Hh_Mm,
					J.IdTimeCasa,
					C.Nome							TimeCasa,
					J.GolsTimeCasa,
					J.IdTimeVisitante,
					V.Nome							TimeVisitante,	
					J.GolsTimeVisitante,
					J.PenaltisTimeCasa,
					J.PenaltisTimeVisitante,
					J.MataMata,
					J.Prorrogacao,
					J.DisputaPenaltis,
					J.Finalizado,
					J.Adiado,
					J.Cancelado,
					A.IdAposta,
					A.GolsTimeCasa					GolsApostaTimeCasa,
					A.GolsTimeVisitante				GolsApostaTimeVisitante
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
	Order	By		2, 3, 1;

End