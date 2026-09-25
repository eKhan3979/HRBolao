CREATE PROCEDURE u258112148_Khan.SpBCampeonato_Gravar (
	IdCampeonatoP	Int,
	NomeP			Char(50),
	AnoP			Int,
	AtivoP			Bit
)
Begin

	Declare	Id Int;
	
	Set Id = 0;
	
	If Id = 0 Then
		Insert	Into	u258112148_1.TbBCampeonato
			(Nome, Ano, Ativo)
		Values
			(NomeP, AnoP, 1);

		Select Last_Insert_ID() Into Id;
	Else
		UpDate	u258112148_1.TbBCampeonato
		Set		Nome			=	NomeP,
				Ano				=	AnoP,
				Ativo			=	AtivoP
		Where	IdCampeonato	=	IdCampeonatoP;
		
		Select	IdCampeonatoP Into Id;
	End If;
		
	Select Id	IdCampeonato;
	
End