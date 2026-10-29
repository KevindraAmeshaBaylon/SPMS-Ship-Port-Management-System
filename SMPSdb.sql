/* ============================================================
   Ship Port Management System (SPMS)
   Database: SMPSdb
   Run this script in SQL Server Management Studio (SSMS)
   ============================================================ */

-- 1. Create the database
IF DB_ID('SMPSdb') IS NULL
    CREATE DATABASE SMPSdb;
GO

USE SMPSdb;
GO

-- 2. Admin table
CREATE TABLE dbo.tbladmin (
    AdminID   VARCHAR(50) NULL,
    Username  VARCHAR(50) NULL,
    [Password] VARCHAR(50) NULL
);
GO

-- 3. User table
CREATE TABLE dbo.tbluser (
    UserID    VARCHAR(50) NULL,
    Username  VARCHAR(50) NULL,
    [Password] VARCHAR(50) NULL
);
GO

-- 4. Ship table (created before tblrequest because tblrequest references it)
CREATE TABLE dbo.tblship (
    ShipNo    NUMERIC(18,0) NOT NULL,
    ShipName  VARCHAR(20)   NULL,
    [Status]  VARCHAR(50)   NULL,
    CONSTRAINT PK_tblship PRIMARY KEY (ShipNo)
);
GO

-- 5. Request table
CREATE TABLE dbo.tblrequest (
    RequestID     NUMERIC(18,0) NOT NULL,
    FromCountry   VARCHAR(50)   NULL,
    ToCountry     VARCHAR(50)   NULL,
    ShipNo        NUMERIC(18,0) NULL,
    Arrival       DATETIME      NULL,
    Departure     DATETIME      NULL,
    RequestStatus VARCHAR(50)   NULL,
    CONSTRAINT PK_tblrequest PRIMARY KEY (RequestID),
    CONSTRAINT FK_tblrequest_tblship FOREIGN KEY (ShipNo)
        REFERENCES dbo.tblship (ShipNo)
);
GO

-- 6. OPTIONAL: sample data (dummy values only, never real passwords)
INSERT INTO dbo.tbladmin (AdminID, Username, [Password])
VALUES ('A001', 'admin', 'admin123');

INSERT INTO dbo.tbluser (UserID, Username, [Password])
VALUES ('U001', 'testuser', 'user123');

INSERT INTO dbo.tblship (ShipNo, ShipName, [Status])
VALUES (1, 'Ocean Star', 'Docked'),
       (2, 'Sea Voyager', 'At Sea');

INSERT INTO dbo.tblrequest (RequestID, FromCountry, ToCountry, ShipNo, Arrival, Departure, RequestStatus)
VALUES (1, 'Sri Lanka', 'India', 1, '2026-11-05 08:00', '2026-11-07 18:00', 'Pending');
GO
