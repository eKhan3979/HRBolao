CREATE PROCEDURE u258112148_Khan.SpBCampeonato_Insert (
	NomeP	Char(50),
	AnoP	Int
)
Begin

	Insert	Into	u258112148_1.TbBCampeonato
		(Nome, Ano, Ativo)
	Values
		(NomeP, AnoP, 1);
	
	Select Last_Insert_ID()	IdCampeonato;
	
End