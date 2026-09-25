CREATE PROCEDURE u258112148_Khan.SpBJogo_Resultado (
	IdCampeonatoJogoG		Int,
	GolsTimeCasaG			Int,
	GolsTimeVisitanteG		Int,
	FinalizadoG				Bit
)
Begin

	Declare	retorno Int;
	
	Set retorno = 0;
	
	UpDate	u258112148_1.TbBCampeonatoJogo
	Set		GolsTimeCasa			= GolsTimeCasaG,
			GolsTimeVisitante		= GolsTimeVisitanteG,
			Finalizado				= FinalizadoG
	Where	IdCampeonatoJogo		= IdCampeonatoJogoG;
	
	Set retorno = 1;
	
	Select retorno	Retorno;

End