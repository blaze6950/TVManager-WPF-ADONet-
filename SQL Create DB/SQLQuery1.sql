CREATE DATABASE TVSeries  
ON   
(   NAME = TVSeries_dat,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TVSeries.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
(   NAME = TVSeries_log,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TVSerieslog.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB ) ;

USE TVSeries

CREATE TABLE Channels
(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE TVSeriesTable
(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(100) NOT NULL,
	Image nvarchar(1000),
	YearOfIssue int,
	Seasons int,
	Desription nvarchar(3000),
	Channel_Id int NOT NULL FOREIGN KEY REFERENCES Channels(Id)
);

CREATE TABLE Genres
(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE TVSeriesGenres
(
	TVSeries_Id int NOT NULL 
			FOREIGN KEY REFERENCES TVSeriesTable(Id)
			ON DELETE CASCADE
			ON UPDATE CASCADE,
	Genre_Id int NOT NULL 
			FOREIGN KEY REFERENCES Genres(Id)
			ON DELETE CASCADE
			ON UPDATE CASCADE
	CONSTRAINT PK_TVSeries_Genres PRIMARY KEY(TVSeries_Id, Genre_Id)
);