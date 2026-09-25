CREATE PROCEDURE u258112148_Khan.SpBTimes_Gravar (
	IdTimeG			Int, 
	NomeG			Char(50),
	UFG				Char(2),
	CidadeG			Char(100),
	AtivoG			Bit,
	AbreviaturaG	Char(5),
	TipoG			Int
)
Begin

	Declare	Id	Int;
    
    Set Id = IdTimeG;

	If IfNull(Id, 0) = 0 Then
		Insert	Into	u258112148_1.TbBTime
				(Nome, UF, Cidade, Ativo, Abreviatura, Tipo)
		Values
				(NomeG, UFG, CidadeG, AtivoG, AbreviaturaG, TipoG);
                
		Select Last_Insert_ID() Into Id;
    Else
		UpDate	u258112148_1.TbBTime
        Set		Nome		=	NomeG,
				UF			=	UFG,
				Cidade		=	CidadeG,
				Ativo		=	AtivoG,
				Abreviatura	=	AbreviaturaG,
				Tipo		=	TipoG
		Where	IdTime		=	IdTimeG;
    End If;
    
    Select	Id IdTime;

End