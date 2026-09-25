Drop Procedure If Exists u258112148_1.SpBJogador_Change;

Delimiter @@

Create Procedure u258112148_1.SpBJogador_Change (
	IdJogadorG	Int,
	SenhaG		VarChar(20)
)

Begin

	UpDate	u258112148_1.TbBJogador
	Set		Senha		=	SenhaG
	Where	IdJogador	=	IdJogadorG;

End @@

Delimiter ;