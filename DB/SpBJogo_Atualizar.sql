CREATE PROCEDURE u258112148_Khan.SpBJogo_Atualizar (
	IdCampeonatoJogoG		Int,
	GolsTimeCasaG			Int,
	GolsTimeVisitanteG		Int,
	PenaltisTimeCasaG		Int,
	PenaltisTimeVisitanteG	Int,
	ProrrogacaoG			Bit,
	DisputaPenaltisG		Bit,
	FinalizadoG				Bit,
	AdiadoG					Bit,
	CanceladoG				Bit
)
Begin


	UpDate	u258112148_1.TbBCampeonatoJogo
	Set		GolsTimeCasa			= GolsTimeCasaG,
			GolsTimeVisitante		= GolsTimeVisitanteG,
			PenaltisTimeCasa		= PenaltisTimeCasaG,
			PenaltisTimeVisitante	= PenaltisTimeVisitanteG,
			Prorrogacao				= ProrrogacaoG,
			DisputaPenaltis			= DisputaPenaltisG,
			Finalizado				= FinalizadoG,
			Adiado					= AdiadoG,
			Cancelado				= CanceladoG
	Where	IdCampeonatoJogo		= IdCampeonatoJogoG;

End