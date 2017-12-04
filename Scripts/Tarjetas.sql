/*Base de Datos Visa*/

IF DB_ID ('BD_VISA') IS NOT NULL
BEGIN
	DROP DATABASE BD_VISA
END
GO 

CREATE DATABASE BD_VISA
GO

USE BD_VISA
GO

CREATE TABLE DOCUMENTO(
CODIGO CHAR(5) NOT NULL,
DESCRIPCION VARCHAR(50) NOT NULL 
)
GO

CREATE TABLE TARJETA(
CODIGO CHAR(10) NOT NULL,
NUMERO VARCHAR(20) NOT NULL,
TITULAR VARCHAR (50) NOT NULL,
FECHA DATETIME NOT NULL,
CVC CHAR(3) NOT NULL,
TIPDOC CHAR(5) NOT NULL,
NUMDOC VARCHAR(50) NOT NULL
)
GO

ALTER TABLE DOCUMENTO ADD CONSTRAINT DOCUMENTO_PK PRIMARY KEY
	(CODIGO)
GO

ALTER TABLE TARJETA ADD CONSTRAINT TARJETA_PK PRIMARY KEY
	(CODIGO)
GO

ALTER TABLE TARJETA ADD CONSTRAINT TARJETA_FK FOREIGN KEY
	(TIPDOC)
	REFERENCES DOCUMENTO
	(CODIGO)
GO

INSERT INTO DOCUMENTO VALUES ('TD001', 'Dni')
INSERT INTO DOCUMENTO VALUES ('TD002', 'Pasaporte')
INSERT INTO DOCUMENTO VALUES ('TD004', 'Carnet de Extranjería')
GO

INSERT INTO TARJETA VALUES ('T000000001', '4474-1100-1824-3291', 'Alvaro Alonso Laveriano Toscano', '2017/01/01 08:01:45.000', '452', 'TD001', '75456269')
INSERT INTO TARJETA VALUES ('T000000002', '4517-9524-4879-2358', 'Maria Alicia Toscano Norabuena', '2017/01/01 08:01:45.000', '132', 'TD001', '07397636')
INSERT INTO TARJETA VALUES ('T000000003', '4517-5784-4821-4856', 'Nahomy Aguirre Flores', '2017/01/01 08:01:45.000', '784', 'TD001', '78951478')
GO

CREATE PROCEDURE usp_Listar
AS
BEGIN
SELECT * FROM TARJETA
END
GO

/*Base de Datos MasterCard*/

IF DB_ID ('BD_MASTER') IS NOT NULL
BEGIN
	DROP DATABASE BD_MASTER
END
GO 

CREATE DATABASE BD_MASTER
GO

USE BD_MASTER
GO

CREATE TABLE DOCUMENTO(
CODIGO CHAR(5) NOT NULL,
DESCRIPCION VARCHAR(50) NOT NULL 
)
GO

CREATE TABLE TARJETA(
CODIGO CHAR(10) NOT NULL,
NUMERO VARCHAR(20) NOT NULL,
TITULAR VARCHAR (50) NOT NULL,
FECHA DATETIME NOT NULL,
CVC CHAR(3) NOT NULL,
TIPDOC CHAR(5) NOT NULL,
NUMDOC VARCHAR(50) NOT NULL
)
GO

ALTER TABLE DOCUMENTO ADD CONSTRAINT DOCUMENTO_PK PRIMARY KEY
	(CODIGO)
GO

ALTER TABLE TARJETA ADD CONSTRAINT TARJETA_PK PRIMARY KEY
	(CODIGO)
GO

ALTER TABLE TARJETA ADD CONSTRAINT TARJETA_FK FOREIGN KEY
	(TIPDOC)
	REFERENCES DOCUMENTO
	(CODIGO)
GO

INSERT INTO DOCUMENTO VALUES ('TD001', 'Dni')
INSERT INTO DOCUMENTO VALUES ('TD002', 'Pasaporte')
INSERT INTO DOCUMENTO VALUES ('TD004', 'Carnet de Extranjería')
GO

INSERT INTO TARJETA VALUES ('T000000001', '5444-7824-7896-4526', 'Alvaro Alonso Laveriano Toscano', '2017/01/01 08:01:45.000', '487', 'TD001', '75456269')
INSERT INTO TARJETA VALUES ('T000000002', '5444-9524-4879-2358', 'Maria Alicia Toscano Norabuena', '2017/01/01 08:01:45.000', '321', 'TD001', '07397636')
INSERT INTO TARJETA VALUES ('T000000003', '5444-5784-4821-4856', 'Nahomy Aguirre Flores', '2017/01/01 08:01:45.000', '965', 'TD001', '78951478')
GO

CREATE PROCEDURE usp_Listar
AS
BEGIN
SELECT * FROM TARJETA
END
GO