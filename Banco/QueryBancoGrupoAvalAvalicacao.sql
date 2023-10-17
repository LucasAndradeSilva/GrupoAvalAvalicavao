CREATE DATABASE DB_CobrancaAvalicacao

USE DB_CobrancaAvalicacao


CREATE TABLE Tb_Debtor (
    ID INT PRIMARY KEY,
    "Name" VARCHAR(255),
    CPF VARCHAR(11) UNIQUE
);

CREATE TABLE Tb_Contract (
    ID INT PRIMARY KEY,
    Debtor_ID INT,
    ContractNumber VARCHAR(20),
    FOREIGN KEY (Debtor_ID) REFERENCES Tb_Debtor(ID)
);

CREATE TABLE Tb_Installment (
    ID INT PRIMARY KEY,
    Contract_ID INT,
    Amount DECIMAL(10, 2),
    DueDate DATE,
    PaymentDate DATE,
    FOREIGN KEY (Contract_ID) REFERENCES Tb_Contract(ID)
);

CREATE TABLE Tb_Phone (
    ID INT PRIMARY KEY,
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
    INSERT INTO Debtor ("Name", CPF)
    VALUES (@Name, @CPF)
END;

CREATE PROCEDURE P_UpdateDebtor
    @ID INT,
    @Name VARCHAR(255),
    @CPF VARCHAR(11)
AS
BEGIN
    UPDATE Debtor
    SET "Name" = @Name, CPF = @CPF
    WHERE ID = @ID
END;

CREATE PROCEDURE P_DeleteDebtor
    @ID INT
AS
BEGIN
    DELETE FROM Debtor
    WHERE ID = @ID
END;

CREATE PROCEDURE P_GetAllDebtors
AS
BEGIN
    SELECT * FROM Debtor
END;

CREATE PROCEDURE P_GetDebtor
    @ID INT
AS
BEGIN
    SELECT * FROM Debtor
    WHERE ID = @ID
END;
