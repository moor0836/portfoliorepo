use CarDealership
GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'FinanceTypesGetAll'
)
BEGIN
	DROP PROCEDURE FinanceTypesGetAll
END
GO

CREATE PROCEDURE FinanceTypesGetAll
AS

SELECT *
FROM FinanceType

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeAdd'
)
BEGIN
	DROP PROCEDURE MakeAdd
END
GO

CREATE PROCEDURE MakeAdd(
	@makeName varchar(200),
	@creator nvarchar(128)
	)
AS

INSERT INTO Make (MakeName, Creator)
VALUES
	(@makeName, @creator)
GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsGetAll'
)
BEGIN
	DROP PROCEDURE SpecialsGetAll
END
GO

CREATE PROCEDURE SpecialsGetAll
AS

SELECT SpecialTitle, SpecialDescription
FROM Special

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StylesGetAll'
)
BEGIN
	DROP PROCEDURE StylesGetAll
END
GO

CREATE PROCEDURE StylesGetAll
AS

SELECT *
FROM Style

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesGetFeatured'
)
BEGIN
	DROP PROCEDURE VehiclesGetFeatured
END
GO

CREATE PROCEDURE VehiclesGetFeatured
AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId
WHERE Vehicle.Featured = 1		
	AND
	Vehicle.VIN NOT IN
	(Select VIN
	FROM PurchasedVehicle)


GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesGetAll'
)
BEGIN
	DROP PROCEDURE VehiclesGetAll
END
GO

CREATE PROCEDURE VehiclesGetAll
AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorsGetAll'
)
BEGIN
	DROP PROCEDURE ColorsGetAll
END
GO

CREATE PROCEDURE ColorsGetAll
AS

SELECT *
FROM color

go



if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesGetAll'
)
BEGIN
	DROP PROCEDURE MakesGetAll
END
GO

CREATE PROCEDURE MakesGetAll
AS

select MakeId, MakeName, DateAdded, Creator
from Make

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsGetAll'
)
BEGIN
	DROP PROCEDURE ModelsGetAll
END
GO

CREATE PROCEDURE ModelsGetAll
AS

SELECT MakeName, ModelName, Model.Creator, Model.DateAdded
FROM Model
JOIN Make On Model.MakeId = Make.MakeId

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasedVehiclesGetAll'
)
BEGIN
	DROP PROCEDURE PurchasedVehiclesGetAll
END
GO

CREATE PROCEDURE PurchasedVehiclesGetAll
AS

SELECT VIN, [Name] AS CustomerName, Street1, Street2, City, [Address].[StateAbbreviation], Zip, Customer.Email, Phone, PurchasePrice, FinanceTypeId, PurchaseDate AS SaleDate, Salesperson
FROM PurchasedVehicle
JOIN Customer on PurchasedVehicle.CustomerId = Customer.CustomerId
JOIN [Address] on Customer.AddressId = [Address].AddressId

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesGetAllUnsold'
)
BEGIN
	DROP PROCEDURE VehiclesGetAllUnsold
END
GO

CREATE PROCEDURE VehiclesGetAllUnsold
AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId
WHERE Vehicle.VIN NOT IN
(Select VIN
FROM PurchasedVehicle)

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactUsAdd'
)
BEGIN
	DROP PROCEDURE ContactUsAdd
END
GO

CREATE PROCEDURE ContactUsAdd(
	@contactName varchar(200),
	@contactPhone char(10),
	@contactEmail varchar(150),
	@contactMessage varchar(max)
)
AS

INSERT INTO ContactUs (ContactName, ContactPhone, ContactEmail, ContactMessage)
VALUES
	(@contactName, @contactPhone, @contactEmail, @contactMessage)

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddressAdd'
)
BEGIN
	DROP PROCEDURE AddressAdd
END
GO

CREATE PROCEDURE AddressAdd(
	@street1 varchar(200),
	@street2 varchar(100),
	@city varchar(75),
	@state char(2),
	@zip char(5)
	)
AS

INSERT INTO Address (Street1, Street2, City, StateAbbreviation, Zip)
VALUES
	(@street1, @street2, @city, @state, @zip)

GO

if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CustomerAdd'
)
BEGIN
	DROP PROCEDURE CustomerAdd
END
GO

CREATE PROCEDURE CustomerAdd(
	@customerName varchar(300),
	@customerPhone varchar(10),
	@customerEmail varchar(100),
	@addressId int
	)
AS

INSERT INTO Customer ([Name], Phone, Email, AddressId)
VALUES
	(@customerName, @customerPhone, @customerEmail, @addressId)

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasedVehicleAdd'
)
BEGIN
	DROP PROCEDURE PurchasedVehicleAdd
END
GO

CREATE PROCEDURE PurchasedVehicleAdd(
	@VIN char(17),
	@customerName varchar(300),
	@street1 varchar(200),
	@street2 varchar(100),
	@city varchar(75),
	@state char(2),
	@zip char(5),
	@email varchar(100),
	@phone char(10),
	@purchasePrice decimal(8,2),
	@financeTypeId int,
	@salesperson nvarchar(128)
)

AS

EXEC AddressAdd @street1, @street2, @city, @state, @zip;
EXEC CustomerAdd @customerName, @customerPhone = @phone, @customerEmail = @email, @addressId = @@IDENTITY;
INSERT INTO PurchasedVehicle(VIN, CustomerId, Salesperson, PurchasePrice, FinanceTypeId)
VALUES
	(@VIN, @@IDENTITY, @salesperson, @purchasePrice, @financeTypeId)
GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialDelete'
)
BEGIN
	DROP PROCEDURE SpecialDelete
END
GO

CREATE PROCEDURE SpecialDelete(
	@specialTitle varchar(300)
)

AS

DELETE FROM Special
WHERE SpecialTitle = @specialTitle

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleDelete'
)
BEGIN
	DROP PROCEDURE VehicleDelete
END
GO

CREATE PROCEDURE VehicleDelete(
	@vin char(17)
)

AS

DELETE FROM Vehicle
WHERE VIN = @vin

GO



if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleAdd'
)
BEGIN
	DROP PROCEDURE VehicleAdd
END
GO

CREATE PROCEDURE VehicleAdd(
	@vin char(17),
	@year char(4),
	@modelId int,
	@exColor int,
	@inColor int,
	@transmission varchar(25),
	@mileage int,
	@mSRP decimal(8,2),
	@salePrice decimal(8,2),
	@description varchar(max)
)

AS

INSERT INTO Vehicle (VIN, [Year], ModelId, ExColor, InColor, Transmission, Mileage, MSRP, SalePrice, [Description], Featured)
VALUES
	(@vin, @year, @modelId, @exColor, @inColor, @transmission, @mileage, @mSRP, @salePrice, @description, 0)
GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleEdit'
)
BEGIN
	DROP PROCEDURE VehicleEdit
END
GO

CREATE PROCEDURE VehicleEdit(
	@vin char(17),
	@year char(4),
	@modelId int,
	@exColor int,
	@inColor int,
	@transmission varchar(25),
	@mileage int,
	@mSRP decimal(8,2),
	@salePrice decimal(8,2),
	@description varchar(max),
	@featured bit
)

AS

EXEC VehicleDelete @vin;--check correct @vin
INSERT INTO Vehicle (VIN, [Year], ModelId, ExColor, InColor, Transmission, Mileage, MSRP, SalePrice, [Description], Featured)
VALUES
	(@vin, @year, @modelId, @exColor, @inColor, @transmission, @mileage, @mSRP, @salePrice, @description, @featured)
GO

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelAdd'
)
BEGIN
	DROP PROCEDURE ModelAdd
END
GO

CREATE PROCEDURE ModelAdd(
	@makeId int,
	@styleId int,
	@modelName varchar(200),
	@creator nvarchar(128)
)

AS

INSERT INTO Model (MakeId, StyleId, ModelName, Creator)
VALUES
	(@makeId, @styleId, @modelName, @creator)

GO



if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialAdd'
)
BEGIN
	DROP PROCEDURE SpecialAdd
END
GO

CREATE PROCEDURE SpecialAdd(
	@specialTitle varchar(300),
	@specialDescription varchar(max)
)

AS

INSERT INTO Special (SpecialTitle, SpecialDescription)
VALUES
	(@specialTitle, @specialDescription)

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetBodyStyle'
)
BEGIN
	DROP PROCEDURE GetBodyStyle
END
GO

CREATE PROCEDURE GetBodyStyle(
	@modelId int
)

AS

SELECT StyleName
FROM Model
JOIN Style on Model.StyleId = Style.StyleId
WHERE ModelId = @modelId

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetEasyEditByVIN'
)
BEGIN
	DROP PROCEDURE GetEasyEditByVIN
END
GO

CREATE PROCEDURE GetEasyEditByVIN(
	@vin char(17)
)

AS

SELECT VIN, Year, MakeId, Vehicle.ModelId, ExColor, InColor, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
WHERE VIN = @vin

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsGetByMakeId'
)
BEGIN
	DROP PROCEDURE ModelsGetByMakeId
END
GO

CREATE PROCEDURE ModelsGetByMakeId(
	@makeId int
)

AS

Select *
FROM Model
Where MakeId = @makeId

GO




if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasedVehicleGetBySalesperson'
)
BEGIN
	DROP PROCEDURE PurchasedVehicleGetBySalesperson
END
GO

CREATE PROCEDURE PurchasedVehicleGetBySalesperson(
	@salesperson nvarchar(128)
)

AS

SELECT VIN, [Name] AS CustomerName, Street1, Street2, City, [Address].[StateAbbreviation], Zip, Customer.Email, Phone, PurchasePrice, FinanceTypeId, PurchaseDate AS SaleDate, Salesperson
FROM PurchasedVehicle
JOIN Customer on PurchasedVehicle.CustomerId = Customer.CustomerId
JOIN [Address] on Customer.AddressId = [Address].AddressId
WHERE Salesperson = @salesperson

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetByVIN'
)
BEGIN
	DROP PROCEDURE VehicleGetByVIN
END
GO

CREATE PROCEDURE VehicleGetByVIN(
	@vin char(17)
)

AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId
WHERE Vehicle.VIN = @vin;

GO



if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSearchAll'
)
BEGIN
	DROP PROCEDURE VehiclesSearchAll
END
GO

CREATE PROCEDURE VehiclesSearchAll(
	@searchText varchar(300),
	@minPrice decimal(15,2),
	@maxPrice decimal(15,2),
	@minYear int,
	@maxYear int
)

AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId
WHERE 
	(
	MakeName LIKE '%' + @searchText + '%'
	OR
	ModelName LIKE '%' + @searchText + '%'
	OR 
	[Year] LIKE '%' + @searchText + '%'
	)
	AND
	(
	SalePrice > @minPrice
	AND
	SalePrice < @maxPrice
	)
	AND
	(
	[Year] > @minYear
	AND 
	[Year] < @maxPrice
	)
	AND
	Vehicle.VIN NOT IN
	(Select VIN
	FROM PurchasedVehicle)

GO




if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSearchNew'
)
BEGIN
	DROP PROCEDURE VehiclesSearchNew
END
GO

CREATE PROCEDURE VehiclesSearchNew(
	@searchText varchar(300),
	@minPrice decimal(15,2),
	@maxPrice decimal(15,2),
	@minYear int,
	@maxYear int
)

AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId
WHERE 
	(
	MakeName LIKE '%' + @searchText + '%'
	OR
	ModelName LIKE '%' + @searchText + '%'
	OR 
	[Year] LIKE '%' + @searchText + '%'
	)
	AND
	(
	SalePrice > @minPrice
	AND
	SalePrice < @maxPrice
	)
	AND
	(
	[Year] > @minYear
	AND 
	[Year] < @maxPrice
	)
	AND
	Mileage < 1000
		AND
	Vehicle.VIN NOT IN
	(Select VIN
	FROM PurchasedVehicle)

GO



if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSearchUsed'
)
BEGIN
	DROP PROCEDURE VehiclesSearchUsed
END
GO

CREATE PROCEDURE VehiclesSearchUsed(
	@searchText varchar(300),
	@minPrice decimal(15,2),
	@maxPrice decimal(15,2),
	@minYear int,
	@maxYear int
)

AS

SELECT VIN, [Year], MakeName AS Make, ModelName AS Model, Interior.ColorName AS InColor, Exterior.ColorName AS ExColor, StyleName AS Style, Transmission, Mileage, MSRP, SalePrice, [Description], Featured
FROM Vehicle
JOIN Model on Vehicle.ModelId = Model.ModelId
JOIN Make on Model.MakeId = Make.MakeId
JOIN Color Interior on Vehicle.ExColor = Interior.ColorId
JOIN Color Exterior on Vehicle.InColor = Exterior.ColorId
JOIN Style on Model.StyleId = Style.StyleId
WHERE 
	(
	MakeName LIKE '%' + @searchText + '%'
	OR
	ModelName LIKE '%' + @searchText + '%'
	OR 
	[Year] LIKE '%' + @searchText + '%'
	)
	AND
	(
	SalePrice > @minPrice
	AND
	SalePrice < @maxPrice
	)
	AND
	(
	[Year] > @minYear
	AND 
	[Year] < @maxPrice
	)
	AND
	Mileage > 999
		AND
	Vehicle.VIN NOT IN
	(Select VIN
	FROM PurchasedVehicle)

GO


if exists(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VINSGetActive'
)
BEGIN
	DROP PROCEDURE VINSGetActive
END
GO

CREATE PROCEDURE VINSGetActive

AS

SELECT VIN
FROM Vehicle

GO