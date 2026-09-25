CREATE PROCEDURE u258112148_Khan.SpBAposta_PorEmpresa (
	 IdEmpresaG		Int,
	 IdCampeonatoG	Int
)
Begin

	Select			C.Rodada,
					C.IdCampeonatoJogo,
					C.GolsTimeCasa,
					C.GolsTimeVisitante,
					C.Finalizado,
					J.IdJogador,
					J.NomeApelido						Jogador,
					A.GolsTimeCasa						ApostaGolsTimeCasa,
					A.GolsTimeVisitante					ApostaGolsTimeVisitante,
					TC.Nome								TimeCasa,
					TV.Nome								TimeVisitante
	From			u258112148_1.TbBJogador				J
	Inner	Join	u258112148_1.TbBAposta				A
			On		J.IdJogador						=	A.IdJogador
	Inner	Join	u258112148_1.TbBCampeonatoJogo		C
			On		A.IdCampeonatoJogo				=	C.IdCampeonatoJogo
			And		C.IdCampeonato					=	IdCampeonatoG
	Inner 	Join	u258112148_1.TbBTime				TC
			On		C.IdTimeCasa					=	TC.IdTime
	Inner 	Join	u258112148_1.TbBTime				TV
			On		C.IdTimeVisitante				=	TV.IdTime
	Where			J.IdEmpresa						=	IdEmpresaG
			And		J.Ativo							=	1
	Order	By		7, 1, 2;

End