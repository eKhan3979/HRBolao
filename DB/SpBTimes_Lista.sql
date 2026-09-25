CREATE PROCEDURE u258112148_Khan.SpBTimes_Lista (
	SoAtivos	Bit
)
Begin

	Select		IdTime,
				Nome,
				UF,
				Cidade,
				Ativo,
				Abreviatura,
				IfNull(Tipo, 1)	Tipo
	From		u258112148_1.TbBTime
	Where		SoAtivos	=	0
			Or	Ativo		=	1
	Order	By	2, 1;

End