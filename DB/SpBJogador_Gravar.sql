CREATE PROCEDURE u258112148_Khan.SpBJogador_Gravar (
	 IdJogadorG		Int,
	 IdEmpresaG		Int,
	 NomeApelidoG	VarChar(100),
	 SenhaG			Char(10),
	 emailG			VarChar(100)
)
Begin

	Declare Id Int;
	
	If IdJogadorG = 0 Then
		Insert Into u258112148_1.TbBJogador
			(IdEmpresa,
			 NomeApelido,
			 Senha,
			 email,
			 DataCadastro,
			 Ativo)
		Values
			(IdEmpresaG,
			 NomeApelidoG,
			 SenhaG,
			 emailG,
			 Now(),
			 1);
				
		Select Last_Insert_ID() Into Id;
	Else
		UpDate	u258112148_1.TbBJogador
		Set		NomeApelido	= NomeApelidoG,
				Senha		= SenhaG,
				email		= emailG
		Where	IdJogador	= IdJogadorG;
			 
		Set Id = IdJogadorG;
	End If;
	
	Select Id IdJogador;

End