-- Script SQL pour créer la base de données LeHeronCendre
CREATE DATABASE LeHeronCendre;
GO

USE LeHeronCendre;
GO

-- Table Clients
CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20)
);
GO

-- Table Reservations
CREATE TABLE Reservations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClientId INT NOT NULL,
    ReservationDate DATETIME NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Details NVARCHAR(MAX),
    IsConfirmed BIT NOT NULL,
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);
GO

-- Table Rooms
CREATE TABLE Rooms (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL, -- Correction : NVIDIA remplacé par NVARCHAR
    Description NVARCHAR(MAX),
    Price DECIMAL(10,2) NOT NULL,
    IsAvailable BIT NOT NULL
);
GO

-- Table Menus
CREATE TABLE Menus (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10,2) NOT NULL,
    Category NVARCHAR(50) NOT NULL
);
GO

-- Table WellnessServices
CREATE TABLE WellnessServices (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10,2) NOT NULL,
    Duration NVARCHAR(50) NOT NULL
);
GO

-- Table Events
CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    EventDate DATETIME NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

INSERT INTO WellnessServices (Name, Description, Price, Duration)
VALUES 
('Massage', 'Massage relaxant complet du corps', 60.00, '60'),
('Soin du visage', 'Soin du visage hydratant et revitalisant', 45.00, '45'),
('Manucure', 'Manucure professionnelle avec vernis', 30.00, '30');