use [master]
go

if exists (select * from sys.databases where name = N'CarDealership')
begin 
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CarDealership';
	ALTER DATABASE CarDealership SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE CarDealership;
end

create database CarDealership
GO
--stop here, run update-database from Visual Studios, then run remainder
