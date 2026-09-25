CREATE PROCEDURE u258112148_Khan.SpBCampeonatoTimes_Insert (
	IdCampeonatoG	Int,
	IdTimeG			Int
)
Begin

	Insert	Into	u258112148_1.TbBCampeonatoTime
		(IdCampeonato, IdTime)
	Values
		(IdCampeonatoG, IdTimeG);
		
	Select Last_Insert_ID()	IdCampeonatoTime;
	
End