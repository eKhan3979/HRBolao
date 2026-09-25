CREATE PROCEDURE u258112148_Khan.SpBPontuacao_Lista ()
Begin

	Select 		IdPontuacao,
				Descricao,
				Pontos
	From		u258112148_1.TbBPontuacao
	Order	By	1;

End