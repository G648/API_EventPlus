--DQL

USE [Event+_Manha];

SELECT Usuario.NomeUsuario AS [Nome do Usuário], 
TipoUsuario.TituloTipoUsuario AS [Tipo De Usuario], 
Evento.DataEvento AS [Data do Evento], 
Instituicao.NomeInstituicao AS [Local do Evento], 
TipoDeEvento.TituloTipoEvento AS [Titulo do Evento], 
Evento.NomeEvento AS [Nome do Evento],
Evento.DescricaoEvento AS [Descrição do Evento], 
CASE WHEN PresencaEvento.SituacaoEvento = 1 THEN 'Confirmada' ELSE 'Não Confirmada' END AS [Situação],
--PresencaEvento.SituacaoEvento AS [Situação do Evento], 
Comentario.DescricaoComentario AS [Comentário]
FROM 
Usuario
LEFT JOIN TipoUsuario ON Usuario.IdUsuario = TipoUsuario.IdTipoUsuario
LEFT JOIN Evento ON TipoUsuario.IdTipoUsuario = Evento.IdEvento
LEFT JOIN Instituicao ON Evento.IdEvento = Instituicao.IdInstituicao
LEFT JOIN TipoDeEvento ON Instituicao.IdInstituicao = TipoDeEvento.IdTipoDeEvento
LEFT JOIN PresencaEvento ON TipoDeEvento.IdTipoDeEvento = PresencaEvento.IdPresencaEvento
LEFT JOIN Comentario ON PresencaEvento.IdPresencaEvento = Comentario.IdComentarioEvento


SELECT * FROM Usuario
SELECT * FROM TipoUsuario
SELECT * FROM Evento
SELECT * FROM Instituicao
SELECT * FROM PresencaEvento
SELECT * FROM TipoDeEvento
SELECT * FROM Comentario