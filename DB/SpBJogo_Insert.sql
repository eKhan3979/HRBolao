CREATE PROCEDURE u258112148_Khan.SpBJogo_Insert (
	IdCampeonatoG			Int,
	RodadaG					Int,
	RodadaNomeG				Char(20),
	Yyyy_Mm_DdG				Char(10),
	Hh_MmG					Char(5),
	IdTimeCasaG				Int,
	IdTimeVisitanteG		Int
)
Begin

	Insert	Into	u258112148_1.TbBCampeonatoJogo
		(IdCampeonato,
		 Rodada,
		 RodadaNome,
		 Yyyy_Mm_Dd,
		 Hh_Mm,
		 IdTimeCasa,
		 GolsTimeCasa,
		 IdTimeVisitante,
		 GolsTimeVisitante,
		 PenaltisTimeCasa,
		 PenaltisTimeVisitante,
		 MataMata,
		 Prorrogacao,
		 DisputaPenaltis,
		 Finalizado,
		 Adiado,
		 Cancelado)
	Values
		(IdCampeonatoG,
		 RodadaG,
		 RodadaNomeG,
		 Yyyy_Mm_DdG,
		 Hh_MmG,
		 IdTimeCasaG,
		 0,
		 IdTimeVisitanteG,
		 0,
		 0,
		 0,
		 0,
		 0,
		 0,
		 0,
		 0,
		 0)
	On Duplicate Key
	UpDate	Rodada			= RodadaG,
			RodadaNome		= RodadaNomeG,
			Yyyy_Mm_Dd		= Yyyy_Mm_DdG,
			Hh_Mm			= Hh_MmG,
			IdTimeCasa		= IdTimeCasaG,
			IdTimeVisitante	= IdTimeVisitanteG;

	Select Last_Insert_ID()	IdCampeonatoJogo;	

End