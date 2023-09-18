--DML

USE [Event+_Manha];

INSERT INTO TipoUsuario (TituloTipoUsuario) VALUES 
('Administrador'),
('Padr�o');

INSERT INTO Instituicao (NomeInstituicao, CNPJ, EnderecoInstituicao) VALUES
('SENAI', '03776284000109', 'Rua Niter�i 180');

INSERT INTO TipoDeEvento (TituloTipoEvento) VALUES 
('SQL Server');

INSERT INTO Usuario (IdTipoUsuario, NomeUsuario, EmailUsuario, SenhaUsuario) VALUES
(1, 'Amandinha03', 'amandinha@amandinha.com', '123456');

INSERT INTO Evento (IdTipoDeEvento, IdInstituicao, NomeEvento, DescricaoEvento, DataEvento, HoraEvento) VALUES
(1, 1, 'Introdu��o ao SQL Server', 'Evento relacionado a programa��o em SQL', '2023-08-15', '15:00:00');

INSERT INTO PresencaEvento (IdEvento, IdUsuario) VALUES
(1, 1);

INSERT INTO Comentario (IdUsuario, IdEvento, DescricaoComentario, Exibe) VALUES 
(1, 1, 'MUITO BOMM!!!', 1);

SELECT * FROM Usuario;