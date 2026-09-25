CREATE PROCEDURE u258112148_Khan.SpBCampeonato_ListaJogos (
	IdCampeonatoG	Int
)
Begin

	Select 			J.IdCampeonatoJogo,
					J.Rodada,
					J.Yyyy_Mm_Dd,
					J.Hh_Mm,
					J.IdTimeCasa,
					C.Nome					TimeCasa,
					J.GolsTimeCasa,
					J.IdTimeVisitante,
					V.Nome					TimeVisitante,	
					J.GolsTimeVisitante,
					J.Finalizado,
					J.Adiado,
					J.Cancelado
	From			u258112148_1.TbBCampeonatoJogo	J
	Inner	Join	u258112148_1.TbBTime			C
			On		J.IdTimeCasa				=	C.IdTime
	Inner	Join	u258112148_1.TbBTime			V
			On		J.IdTimeVisitante			=	V.IdTime
	Where			J.IdCampeonato				=	IdCampeonatoG
	Order	By		2, 3, 1;

End