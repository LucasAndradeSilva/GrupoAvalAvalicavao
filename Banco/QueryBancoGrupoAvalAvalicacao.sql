CREATE DATABASE DBCobrancaAvalicacao

USE DBCobrancaAvalicacao

-- Tabela "Devedor"
CREATE TABLE Devedor (
    ID INT PRIMARY KEY,
    Nome VARCHAR(255),
    CPF VARCHAR(11) UNIQUE
);

-- Tabela "Contrato"
CREATE TABLE Contrato (
    ID INT PRIMARY KEY,
    Devedor_ID INT,
    NumeroContrato VARCHAR(20),
    FOREIGN KEY (Devedor_ID) REFERENCES Devedor(ID)
);

-- Tabela "Parcela"
CREATE TABLE Parcela (
    ID INT PRIMARY KEY,
    Contrato_ID INT,
    Valor DECIMAL(10, 2),
    DataVencimento DATE,
    DataPagamento DATE,
    FOREIGN KEY (Contrato_ID) REFERENCES Contrato(ID)
);

-- Tabela "Telefone"
CREATE TABLE Telefone (
    ID INT PRIMARY KEY,
    Devedor_ID INT,
    NumeroTelefone VARCHAR(20),
    FOREIGN KEY (Devedor_ID) REFERENCES Devedor(ID)
);
