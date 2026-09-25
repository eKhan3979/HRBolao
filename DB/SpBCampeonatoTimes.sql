CREATE PROCEDURE u258112148_Khan.SpBCampeonatoTimes (
	IdCampeonatoG	Int
)
Begin

	Select			T.IdTime, 
					T.Nome,
					T.UF,
					T.Cidade,
					T.Ativo,
					T.Abreviatura,
					IfNull(T.Tipo, 1)					Tipo
	From			u258112148_1.TbBCampeonatoTime		C
	Inner	Join	u258112148_1.TbBTime				T
			On		C.IdTime						=	T.IdTime
	Where			C.IdCampeonato					=	IdCampeonatoG
			And		T.Ativo							=	1
	Order	By		2;

End