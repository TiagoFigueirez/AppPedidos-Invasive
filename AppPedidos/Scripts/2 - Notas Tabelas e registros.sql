INSERT INTO Role (NameRole) VALUES ('INVASIVE-SP')
INSERT INTO Medico (NomeMedico, Habilitado, RoleId) VALUES('GUILHERME CENTOFANTI', 1, 1);
INSERT INTO Convenio (NomeConvenio, Habilitado, RoleId) VALUES('SUL AM�RICA',1, 1);
INSERT INTO Paciente (NomePaciente, Habilitado, RoleId) VALUES('TIAGO DE PAULA FIGUEIREDO OLIVEIRA', 1, 1);
INSERT INTO Hospital (NomeHospital, Habilitado, RoleId) VALUES('S�RIO LIBAN�S', 1, 1)

SELECT*FROM Medico;
SELECT*FROM Convenio
SELECT*FROM Paciente;
SELECT*FROM Hospital;

INSERT INTO Convenio (NomeConvenio, Habilitado, RoleId) VALUES ('N�O INFORMADO', 1, 1),('BRADESCO',1,1),('NOTRE DAME MEDICAL', 1,1)
