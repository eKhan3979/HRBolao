CREATE PROCEDURE u258112148_Khan.SpBAposta_Gravar (
	IdApostaG				Int,
	IdCampeonatoJogoG		Int,
	IdJogadorG				Int,
	GolsTimeCasaG			Int,
	GolsTimeVisitanteG		Int,
	ProrrogacaoG			Bit,
	DisputaPenaltisG		Bit,
	PenaltisTimeCasaG		Int,
	PenaltisTimeVisitanteG	Int
)
Begin

	Declare	Id Int;
	
	Set Id = IdApostaG;

	If Id = 0 Then
		Insert	Into	u258112148_1.TbBAposta
		(
			IdCampeonatoJogo,
			IdJogador,
			GolsTimeCasa,
			GolsTimeVisitante,
			Prorrogacao,
			DisputaPenaltis,
			PenaltisTimeCasa,
			PenaltisTimeVisitante,
			Pontos
		)
		Values
		(
			IdCampeonatoJogoG,
			IdJogadorG,
			GolsTimeCasaG,
			GolsTimeVisitanteG,
			ProrrogacaoG,
			DisputaPenaltisG,
			PenaltisTimeCasaG,
			PenaltisTimeVisitanteG,
			0
		);

		Select Last_Insert_ID() Into Id;
	Else
		UpDate	u258112148_1.TbBAposta
		Set		GolsTimeCasa			= GolsTimeCasaG,
				GolsTimeVisitante		= GolsTimeVisitanteG,
				Prorrogacao				= ProrrogacaoG,
				DisputaPenaltis			= DisputaPenaltisG,
				PenaltisTimeCasa		= PenaltisTimeCasaG,
				PenaltisTimeVisitante	= PenaltisTimeVisitanteG
		Where	IdAposta				= IdApostaG;		
	End If;
		
	Select	Id	IdAposta;

End