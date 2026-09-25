CREATE PROCEDURE u258112148_Khan.SpBCampeonatos_Lista (
	SoAtivos	Bit
)
Begin

	Select		IdCampeonato,
				Nome,
				Ano,
				Ativo
	From		u258112148_1.TbBCampeonato
	Where		SoAtivos	=	0
			Or	Ativo		=	1
	Order	By	2, 1;

End