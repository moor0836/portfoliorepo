use CarDealership
go

drop table if exists dbo.ContactUs
drop table if exists dbo.Special
drop table if exists dbo.PurchasedVehicle
drop table if exists dbo.Customer
drop table if exists dbo.[Address]
drop table if exists Vehicle
drop table if exists dbo.FinanceType
drop table if exists TransmissionType
drop table if exists dbo.Color
drop table if exists dbo.Model
drop table if exists dbo.Style
drop table if exists dbo.Make

create table Make (
	MakeId INT PRIMARY KEY IDENTITY(1,1),
	MakeName VARCHAR(200) NOT NULL,
	Creator nvarchar(128) NOT NULL,
	DateAdded DATETIME NOT NULL Default(GetDate()),
);

create table Style (
	StyleId INT PRIMARY KEY IDENTITY(1,1),
	StyleName VARCHAR(200) NOT NULL
);

create table Model(
	ModelId INT PRIMARY KEY IDENTITY(1,1),
	MakeId INT NOT NULL,
	StyleId INT NOT NULL,
	ModelName VARCHAR(200) NOT NULL,
	Creator nvarchar(128) NOT NULL,
	DateAdded DATETIME NOT NULL Default(GetDate()), 
	CONSTRAINT FK_MakeModel FOREIGN KEY (MakeId)
	REFERENCES Make(MakeId),
	CONSTRAINT FK_StyleModel FOREIGN KEY (StyleId)
	REFERENCES Style(StyleId)
);

create table Color(
	ColorId INT PRIMARY KEY IDENTITY(1,1),
	ColorName VARCHAR(200) NOT NULL
);

create table Vehicle(
	VIN CHAR(17) PRIMARY KEY,
	Year CHAR(4) NOT NULL,
	ModelId INT NOT NULL,
	ExColor INT NOT NULL,
	InColor INT NOT NULL,
	Transmission varchar(25) NOT NULL,
	Mileage int NOT NULL,
	MSRP decimal(8,2) NOT NULL,
	SalePrice decimal(8,2) NOT NULL,
	[Description] varchar(Max),
	Featured bit NOT NULL
	CONSTRAINT FK_ColorVehicleEx FOREIGN KEY (ExColor)
	REFERENCES Color(ColorId),
	CONSTRAINT FK_ColorVehicleIn Foreign KEY (InColor)
	REFERENCES Color(ColorId),
	CONSTRAINT FK_ModelVehicle FOREIGN KEY (ModelId)
	REFERENCES Model(ModelId)
);

create table FinanceType(
	FinanceTypeId INT PRIMARY KEY IDENTITY(1,1) not null,
	FinanceTypeName varchar(15) not null
);

create table [Address](
	AddressId INT PRIMARY KEY IDENTITY(1,1),
	Street1 varchar(200) NOT NULL,
	Street2 varchar(100),
	City varchar(75),
	StateAbbreviation char(2),
	Zip char(5)
);

create table Customer(
	CustomerId INT PRIMARY KEY IDENTITY(1,1),
	Name varchar(300) not null,
	Phone char(10) not null,
	Email varchar(100) not null,
	AddressId INT not null,
		CONSTRAINT FK_AddressCustomer FOREIGN KEY (AddressId)
		REFERENCES [Address](AddressId)
);

create table PurchasedVehicle(
	VIN CHAR(17) PRIMARY KEY,
	CustomerId INT not null,
	Salesperson nvarchar(128) not null,
	PurchaseDate date default GetDate() not null,
	PurchasePrice decimal(8,2) not null,
	FinanceTypeId Int not null
		CONSTRAINT FK_VehiclePurchasedVehicle FOREIGN KEY (VIN)
		REFERENCES Vehicle(VIN),
		CONSTRAINT FK_CustomerPurchasedVehicle FOREIGN KEY(CustomerId)
		REFERENCES Customer(CustomerId),
		CONSTRAINT FK_FinanceTypePurchasedVehicle FOREIGN KEY (FinanceTypeId)
		REFERENCES FinanceType(FinanceTypeId)
);

create table Special(
	SpecialId INT PRIMARY KEY IDENTITY(1,1),
	SpecialTitle varchar(300) not null,
	SpecialDescription varchar(MAX) not null
);

create table ContactUs(
	ContactUsId INT PRIMARY KEY IDENTITY(1,1),
	ContactName varchar(200) not null,
	ContactPhone char(10),
	ContactEmail varchar(150),
	ContactMessage varchar(MAX) not null
);

