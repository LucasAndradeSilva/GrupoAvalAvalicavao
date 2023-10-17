CREATE DATABASE DB_CobrancaAvalicacao

USE DB_CobrancaAvalicacao

CREATE TABLE Tb_Debtor (
    ID INT IDENTITY PRIMARY KEY,
    "Name" VARCHAR(255),
    CPF VARCHAR(11)
);

CREATE TABLE Tb_Contract (
    ID INT IDENTITY PRIMARY KEY,
    Debtor_ID INT,
    ContractNumber VARCHAR(20),
    FOREIGN KEY (Debtor_ID) REFERENCES Tb_Debtor(ID)
);

CREATE TABLE Tb_Installment (
    ID INT IDENTITY PRIMARY KEY,
    Contract_ID INT,
    Amount DECIMAL(10, 2),
    DueDate DATE,
    PaymentDate DATE,
    FOREIGN KEY (Contract_ID) REFERENCES Tb_Contract(ID)
);

CREATE TABLE Tb_Phone (
    ID INT IDENTITY PRIMARY KEY,
    Debtor_ID INT,
    PhoneNumber VARCHAR(20),
    FOREIGN KEY (Debtor_ID) REFERENCES Tb_Debtor(ID)
);

-- ==============
-- = Procedures =
-- ==============

CREATE PROCEDURE P_InsertDebtor
    @Name VARCHAR(255),
    @CPF VARCHAR(11)
AS
BEGIN
    INSERT INTO Tb_Debtor ("Name", CPF)
    VALUES (@Name, @CPF)
	
	SELECT 'Devedor criado com sucesso!'
END;

CREATE PROCEDURE P_UpdateDebtor
    @ID INT,
    @Name VARCHAR(255),
    @CPF VARCHAR(11)
AS
BEGIN
    UPDATE Tb_Debtor
    SET "Name" = @Name, CPF = @CPF
    WHERE ID = @ID

	SELECT 'Devedor atualizado com sucesso!'
END;

CREATE PROCEDURE P_DeleteDebtor
    @ID INT
AS
BEGIN
    DELETE FROM Tb_Debtor
    WHERE ID = @ID

	SELECT 'Devedor deletado com sucesso!'
END;

CREATE PROCEDURE P_GetAllDebtors
AS
BEGIN
    SELECT * FROM Tb_Debtor
END;

CREATE PROCEDURE P_GetDebtor
    @ID INT
AS
BEGIN
    SELECT * FROM Tb_Debtor
    WHERE ID = @ID
END;
