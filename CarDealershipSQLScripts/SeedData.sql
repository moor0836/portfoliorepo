use CarDealership
GO

Delete FROM PurchasedVehicle
DELETE FROM FinanceType
Delete FROM Customer
Delete FROM [Address]
Delete from Vehicle
DELETE FROM MODEL
DELETE FROM Style
DELETE FROM MAKE
Delete from Color
Delete FROM Special

SET IDENTITY_INSERT Make ON
INSERT INTO MAKE (MakeId, MakeName, Creator)
VALUES 
	(1, 'Ford', 'SeedAdmin@cardealership.com'),
	(2, 'Kia', 'SeedAdmin@cardealership.com'),
	(3, 'Honda', 'SeedAdmin@cardealership.com'),
	(4, 'Subaru', 'SeedAdmin@cardealership.com')
GO
SET IDENTITY_INSERT Make OFF


SET IDENTITY_INSERT Style ON
INSERT INTO Style(StyleId, StyleName)
VALUES
	(1, 'Car'),
	(2, 'Truck'),
	(3, 'SUV'),
	(4, 'Van')
GO
SET IDENTITY_INSERT Style OFF


SET IDENTITY_INSERT Model ON
INSERT INTO Model (MakeId, ModelId, StyleId, ModelName, Creator)
VALUES
	(1, 1, 1, 'Mustang', 'SeedAdmin@cardealership.com'),
	(1, 2, 1, 'Fiesta', 'SeedAdmin@cardealership.com'),
	(1, 3, 1, 'Focus', 'SeedAdmin@cardealership.com'),
	(1, 4, 2, 'F-150', 'SeedAdmin@cardealership.com'),
	(1, 5, 2, 'F-250', 'SeedAdmin@cardealership.com'),
	(1, 6, 2, 'Ranger', 'SeedAdmin@cardealership.com'),
	(1, 7, 3, 'Explorer', 'SeedAdmin@cardealership.com'),
	(1, 8, 3, 'Edge', 'SeedAdmin@cardealership.com'),
	(1, 9, 3, 'Escape', 'SeedAdmin@cardealership.com'),
	(1, 10, 4, 'Transit', 'SeedAdmin@cardealership.com'),
	(2, 11, 1, 'Optima', 'SeedAdmin@cardealership.com'),
	(2, 12, 1, 'Stinger', 'SeedAdmin@cardealership.com'),
	(2, 14, 1, 'Rio', 'SeedAdmin@cardealership.com'),
	(2, 15, 3, 'Sportage', 'SeedAdmin@cardealership.com'),
	(2, 16, 3, 'Sorrento', 'SeedAdmin@cardealership.com'),
	(2, 17, 3, 'Telluride', 'SeedAdmin@cardealership.com'),
	(2, 18, 4, 'Sedona', 'SeedAdmin@cardealership.com'),
	(3, 19, 1, 'Civic', 'SeedAdmin@cardealership.com'),
	(3, 20, 1, 'Fit', 'SeedAdmin@cardealership.com'),
	(3, 21, 1, 'Accord', 'SeedAdmin@cardealership.com'),
	(3, 22, 2, 'Ridgeline', 'SeedAdmin@cardealership.com'),
	(3, 23, 3, 'Pilot', 'SeedAdmin@cardealership.com'),
	(3, 24, 3, 'CR-V', 'SeedAdmin@cardealership.com'),
	(3, 25, 3, 'HR-V', 'SeedAdmin@cardealership.com'),
	(3, 26, 3, 'Passport', 'SeedAdmin@cardealership.com'),
	(4, 27, 1, 'BRZ', 'SeedAdmin@cardealership.com'),
	(4, 28, 1, 'WRX', 'SeedAdmin@cardealership.com'),
	(4, 29, 1, 'Legacy', 'SeedAdmin@cardealership.com'),
	(4, 30, 1, 'Impreza', 'SeedAdmin@cardealership.com'),
	(4, 31, 2, 'Baja Sport', 'SeedAdmin@cardealership.com'),
	(4, 32, 3, 'Forester', 'SeedAdmin@cardealership.com'),
	(4, 33, 3, 'Outback', 'SeedAdmin@cardealership.com'),
	(4, 34, 3, 'Ascent', 'SeedAdmin@cardealership.com'),
	(4, 35, 3, 'Crosstrek', 'SeedAdmin@cardealership.com')

GO
SET IDENTITY_INSERT Model OFF


SET IDENTITY_Insert Color ON
INSERT INTO Color (ColorId, ColorName)
VALUES
	(1, 'Black'),
	(2, 'Red'),
	(3, 'Blue'),
	(4, 'Orange'),
	(5, 'White'),
	(6, 'Gray'),
	(7, 'Beige'),
	(8, 'Green'),
	(9, 'Gold'),
	(10, 'Silver')
GO
SET IDENTITY_INSERT Color OFF


INSERT INTO Vehicle (VIN, Year, ModelId, ExColor, InColor, Transmission, Mileage, MSRP, SalePrice, [Description], Featured)
VALUES
	('1FAFP42X32F104642', '2002', 1, 5, 7, 'Manual', 98567, 1400, 1279.40, 'Drive home in this beautiful classic - with certificate of title salvage rebuildable, already running, fully functional with minor dents/scratches - sold by State Farm Insurance', 0),
	('1HGCP263X9A181686', '2020', 1, 2, 6, 'Automatic', 1, 28280, 2799.99, 'For 2020, Ford gifts the four-cylinder Mustang with a more desirable engine and legitimate track-ready equipment. The former is included with the new High-Performance package, which adds a 330-hp EcoBoost four-banger and other hardware from V-8–powered models.', 1),
	('YV1RH527352431364', '2009', 2, 3, 6, 'Automatic', 67994, 3900, 3840, 'With an electrically operated power-steering system, a new, high-strength-steel chassis, 16-inch tires, and an available sport-tuned suspension, the 2009 Ford Fiesta handles well in the corners and provides an exceptional highway drive.', 1),
	('KL1TG66646B699984', '2012', 3, 10, 1, 'Automatic', 49338, 2740, 2699, 'With better styling than the Chevrolet Cruze and better handling than the Hyundai Elantra, the 2012 Ford Focus is the most complete package in the compact-car market.', 1),
	('JM3KE2DEXD0179110', '2019', 4, 8, 6, 'Automatic', 1, 30115, 29999, 'Research the Quality, Craftsmanship & Toughness of the 2019 Ford F-150. Built Ford Tough® Frame. Pro Trailer Backup Assist. IIHS Top Safety Pick. Military-Grade Aluminum. LCD Productivity Screen. NHTSA 5-Star Safety Award. Roll Stability Control™.', 1),
	('2T1BURHE0EC229115', '2007', 5, 4, 7, 'Automatic', 108749, 5440, 4999, 'The base F-150 engine is a 202-horsepower, 4.2-liter V-6. Two V-8s are available: a 231-hp 4.6-liter and a 300-hp 5.4-liter. A four-speed-automatic transmission is standard with V-8 power, but V-6 models can team with a four-speed-automatic transmission or a five-speed manual.', 0),
	('JTDKN3DU9F0475339', '2018', 32, 8, 6, 'Manual', 42895, 19450, 18999, 'What it is: The Forester is a compact SUV with standard all-wheel drive. It offers a suite of active safety features called EyeSight, which uses cameras to provide adaptive cruise control, precollision braking and lane departure warning.', 0)
GO


INSERT INTO Special (SpecialTitle, SpecialDescription)
VALUES
	('Veteran''s Special', 'Now through the end of the year, we will cover $500 in taxes and fees for you!!'),
	('Teacher''s Special', 'Time to get out and enjoy your summer with a new vehicle! Now through the beginning of the year, we will waive 80% of our admin fees. Thank you!!'),
	('COVID-19 Special', 'Want to get out but still practice social distancing? Get a new vehicle to see the country while you still can!')
GO


SET IDENTITY_INSERT [Address] ON
INSERT INTO [Address] (AddressId, Street1, Street2, City, StateAbbreviation, Zip)
VALUES
	(1, '2047 Montreal Ave', '', 'St Paul', 'MN', '55116'),
	(2, '1108 Dover Dr', '', 'Lodi', 'CA', '95242'),
	(3, '2432 W Tokay St', '', 'Lodi', 'CA', '95242')
GO
SET IDENTITY_INSERT [Address] OFF



SET IDENTITY_INSERT Customer ON
INSERT INTO Customer (CustomerID, [Name], Phone, Email, AddressId)
VALUES
	(1, 'Lori Moore', '2093274278', 'mooredreams@gmail.com', 2),
	(2, 'Kyle Miest-Moore', '5555555555', 'kyle@domain.net', 1),
	(3, 'Glen Robinson', '2094017433', 'glenr@sbcglobal.net', 3)
GO
SET IDENTITY_INSERT Customer OFF


SET IDENTITY_INSERT FinanceType ON
INSERT INTO FinanceType (FinanceTypeId, FinanceTypeName)
VALUES
	(1, 'Bank Finance'),
	(2, 'Cash'),
	(3, 'Dealer Finance')
GO
SET IDENTITY_INSERT FinanceType OFF


INSERT INTO PurchasedVehicle (VIN, CustomerId, Salesperson, PurchasePrice, FinanceTypeId)
VALUES
	('KL1TG66646B699984', 1, 'admin@cardealership.com', 2699, 2),
	('2T1BURHE0EC229115', 2, 'admin@cardealership.com', 4990, 1)
GO 