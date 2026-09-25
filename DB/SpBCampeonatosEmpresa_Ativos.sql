CREATE PROCEDURE u258112148_Khan.SpBCampeonatosEmpresa_Ativos (
	IdEmpresaG	Int
)
Begin

	Select			C.Nome, 
					C.IdCampeonato,
					C.Ano,
					E.IdEmpresaCampeonato
	From			u258112148_1.TbBCampeonato				C
	Inner	Join	u258112148_1.TbBEmpresaCampeonato		E
			On		C.IdCampeonato						=	E.IdCampeonato
	Where			E.IdEmpresa							=	IdEmpresaG
			And		C.Ativo								=	1
			And		E.Ativo								=	1
	Order	By		1;

End