CREATE DATABASE DB_CobrancaAvalicacao

USE DB_CobrancaAvalicacao

Select * from Tb_Installment

CREATE TABLE Tb_Debtor (
    ID INT IDENTITY PRIMARY KEY,
    "Name" VARCHAR(255),
    CPF VARCHAR(14)
);

CREATE TABLE Tb_Contract (
    ContractId INT IDENTITY PRIMARY KEY,
    Debtor_ID INT,
    ContractNumber VARCHAR(20),
    FOREIGN KEY (Debtor_ID) REFERENCES Tb_Debtor(ID)
);

CREATE TABLE Tb_Installment (
    InstallmentId INT IDENTITY PRIMARY KEY,
    Contract_ID INT,
    Amount DECIMAL(10, 2),
    DueDate DATE,
    PaymentDate DATE,
    FOREIGN KEY (Contract_ID) REFERENCES Tb_Contract(ContractId)
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

-- Procs do Devedor
CREATE PROCEDURE P_InsertDebtor
    @Name VARCHAR(255),
    @CPF VARCHAR(14)
AS
BEGIN
    INSERT INTO Tb_Debtor ("Name", CPF)
    VALUES (@Name, @CPF)
	
	SELECT 'Devedor criado com sucesso!'
END;

CREATE PROCEDURE P_UpdateDebtor
    @ID INT,
    @Name VARCHAR(255),
    @CPF VARCHAR(14)
AS
BEGIN	
    UPDATE Tb_Debtor
    SET Name = @Name, CPF = @CPF
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

-- Procs do Telefone
CREATE PROCEDURE P_BulkInsertPhones
    @Debtor_ID INT,
    @PhoneNumbers VARCHAR(MAX)
AS
BEGIN
    CREATE TABLE TempPhoneNumbers (Debtor_ID INT, PhoneNumber VARCHAR(20));
    
    INSERT INTO TempPhoneNumbers (PhoneNumber)
    SELECT value FROM STRING_SPLIT(@PhoneNumbers, ',');

    INSERT INTO Tb_Phone (Debtor_ID, PhoneNumber)
    SELECT @Debtor_ID, PhoneNumber
    FROM TempPhoneNumbers;

    DROP TABLE TempPhoneNumbers;

    SELECT 'Telefones inseridos com sucesso!';
END;

CREATE PROCEDURE P_DeletePhone
    @ID INT
AS
BEGIN
    DELETE FROM Tb_Phone
    WHERE ID = @ID

	SELECT 'Telefone deletado com sucesso!'
END;

CREATE PROCEDURE P_GetPhones
  @Debtor_ID INT
AS
BEGIN
    SELECT * FROM Tb_Phone Where Debtor_ID = @Debtor_ID
END;


-- Procs Contrato
CREATE PROCEDURE P_CreateContractWithInstallments
	@DebtorID INT
AS
BEGIN    
    DECLARE @ContractNumber INT
    DECLARE @ContractID INT           
        
    SET @ContractNumber = RAND() * 12346789
        
    INSERT INTO Tb_Contract (Debtor_ID, ContractNumber)
    VALUES (@DebtorID, @ContractNumber)
        
    SET @ContractID = SCOPE_IDENTITY()
        
    DECLARE @InstallmentAmount DECIMAL(10, 2)
    DECLARE @DueDate DATE
    DECLARE @i INT
    DECLARE @StartMonth INT

	SET @InstallmentAmount = RAND() * 321
	SET @DueDate = GETDATE()
    SET @i = 1
	SET @StartMonth = -2
    
    WHILE @i <= 3
    BEGIN                 
		IF @StartMonth = 0
			SET @StartMonth = 1
			
        SET @DueDate = DATEADD(MONTH, @StartMonth, @DueDate)
                
        INSERT INTO Tb_Installment (Contract_ID, Amount, DueDate)
        VALUES (@ContractID, @InstallmentAmount, @DueDate)
        
        SET @i = @i + 1
		SET @StartMonth = @StartMonth + 1
    END

	SELECT 'Contrato criado com sucesso!'
END

CREATE PROCEDURE P_ListContractsByDebtorID
    @DebtorID INT
AS
BEGIN
    SELECT ContractId, ContractNumber
    FROM Tb_Contract
    WHERE Debtor_ID = @DebtorID
END

CREATE PROCEDURE P_ListContractsAndInstallmentsByDebtorID
    @DebtorID INT
AS
BEGIN
    SELECT C.ContractId, C.ContractNumber, C.Debtor_ID, I.InstallmentId, I.Amount, I.DueDate, I.PaymentDate, I.Contract_ID
    FROM Tb_Contract C
    INNER JOIN Tb_Installment I ON C.ContractId = I.Contract_ID
    WHERE C.Debtor_ID = @DebtorID
END

-- Procs Parcelas

CREATE PROCEDURE P_ListInstallmentsByContractID
    @ContractID INT
AS
BEGIN
    SELECT InstallmentId, Amount, DueDate, PaymentDate
    FROM Tb_Installment
    WHERE Contract_ID = @ContractID
END

CREATE PROCEDURE P_PaymentInstallments
    @InstallmentIDs VARCHAR(MAX)
AS
BEGIN    
    UPDATE Tb_Installment
    SET PaymentDate = GETDATE()
    WHERE InstallmentId IN (SELECT value FROM STRING_SPLIT(@InstallmentIDs, ','))
END
