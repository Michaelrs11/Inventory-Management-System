﻿CREATE TABLE MasterBarang
(
	SKUID VARCHAR(255) NOT NULL
		CONSTRAINT PK_MasterBarang PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
     CreatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     CreatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
     UpdatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     UpdatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
)

CREATE TABLE Outlet
(
	OutletCode VARCHAR(255) NOT NULL
		CONSTRAINT PK_Outlet PRIMARY KEY,
     Name VARCHAR(255) NOT NULL,
     CreatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     CreatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
     UpdatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     UpdatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
)

CREATE TABLE MasterGudang
(
	GudangCode VARCHAR(255) NOT NULL
		CONSTRAINT PK_GudangCode PRIMARY KEY,
     OutletCode VARCHAR(255) NOT NULL
		CONSTRAINT FK_MasterGudang_Outlet FOREIGN KEY REFERENCES Outlet,
    [Name] VARCHAR(255) NOT NULL,
	CreatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     CreatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
     UpdatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     UpdatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',

)

CREATE TABLE UserRoleEnum
(
	UserRoleEnumId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(255) NOT NULL
)

CREATE TABLE MasterUser
(
	UserCode VARCHAR(255) NOT NULL
	  CONSTRAINT PK_User PRIMARY KEY,
	UserRoleEnumId INT NOT NULL  
       CONSTRAINT FK_User_UserRoleEnum FOREIGN KEY REFERENCES UserRoleEnum, 
     Name VARCHAR(255) NOT NULL,
     Password VARCHAR(255) NOT NULL,
     Email VARCHAR(255) NOT NULL,
     CreatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     CreatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
     UpdatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     UpdatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM', 
)

CREATE TABLE StockTransaction(
	 StockTransactionId INT PRIMARY KEY IDENTITY,
	 SKUID VARCHAR(255) NOT NULL
		CONSTRAINT FK_AdjustmentStock_MasterBarang FOREIGN KEY REFERENCES MasterBarang,
     GudangCode VARCHAR(255) NOT NULL
	    CONSTRAINT FK_StockTransaction_MasterGudang FOREIGN KEY REFERENCES MasterGudang,
     StockBefore INT NOT NULL,
     StockAfter INT NOT NULL,
	 StockIn INT,
	 StockOut INT,
	 CreatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     CreatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM',
     UpdatedAt DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
     UpdatedBy VARCHAR(255) NOT NULL DEFAULT 'SYSTEM', 
)
