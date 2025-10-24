DROP DATABASE [MuslimSalat]

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MuslimSalat')
BEGIN
    CREATE DATABASE [MuslimSalat];
    PRINT 'Base de données créée avec succès.';
END
GO

USE [MuslimSalat]
GO

CREATE TABLE [dbo].[Address] (
[Id] int NOT NULL IDENTITY(1,1),
[PostCode] int NOT NULL,
[Locality] nvarchar(250),
[Longitude] nvarchar(50),
[Latitude] nvarchar(50),
CONSTRAINT [PK_Address] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Parameter] (
[Id] int NOT NULL IDENTITY(1,1),
[PrayerReminderMinutes] tinyint CONSTRAINT [DF_PrayerReminderMinutes] DEFAULT ((15)) NOT NULL,
[CalculationStrategy] bit CONSTRAINT [DF_CalculationStrategy] DEFAULT ((0)) NOT NULL,
[IdUser] int NOT NULL CONSTRAINT [UQ_IdUser] UNIQUE,
CONSTRAINT [PK_Parameter] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Prayer] (
[Id] int NOT NULL IDENTITY(1,1),
[Name] nvarchar(30) NOT NULL,
[Datetime] datetime2(0) NOT NULL,
[Done] bit CONSTRAINT [DF_Done] DEFAULT ((0)) NOT NULL,
CONSTRAINT [PK_Prayer] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Mission] (
[Id] int NOT NULL IDENTITY(1,1),
[Name] nvarchar(250) NOT NULL,
[Description] nvarchar(500),
[Level] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Mission] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[User] (
[Id] int NOT NULL IDENTITY(1,1),
[Username] nvarchar(100) CONSTRAINT [UQ_Username] UNIQUE,
[Email] nvarchar(200) NOT NULL,
[PasswordHash] nvarchar(255),
[Role] nvarchar(50) CONSTRAINT [DF_Role] DEFAULT ('User') NOT NULL,
[IdAddress] int,
CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[PrayerReminder] (
[Id] int NOT NULL IDENTITY(1,1),
[Name] nvarchar(50) NOT NULL,
[Datetime] datetime2(0) NOT NULL,
CONSTRAINT [PK_PrayerReminder] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[User_Mission] (
[Id] int NOT NULL IDENTITY(1,1),
[IdUser] int NOT NULL,
[IdMission] int NOT NULL,
[CompletedDatetime] datetime2(0),
CONSTRAINT [PK_User_Mission] PRIMARY KEY ([Id])
);

ALTER TABLE [dbo].[Parameter]
ADD CONSTRAINT [FK_Parameter_User]
FOREIGN KEY ([IdUser]) 
REFERENCES [dbo].[User]([Id])
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Address]
FOREIGN KEY ([IdAddress]) 
REFERENCES [dbo].[Address]([Id])
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE [dbo].[User_Mission]
ADD CONSTRAINT [FK_UserMission_User]
FOREIGN KEY ([IdUser]) 
REFERENCES [dbo].[User]([Id])
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE [dbo].[User_Mission]
ADD CONSTRAINT [FK_UserMission_Mission]
FOREIGN KEY ([IdMission]) 
REFERENCES [dbo].[Mission]([Id])
ON DELETE CASCADE
ON UPDATE CASCADE;