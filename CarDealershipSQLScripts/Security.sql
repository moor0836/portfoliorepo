
use CarDealership
GO

CREATE LOGIN CarDealershipApp WITH PASSWORD='testing123'
GO

CREATE USER CarDealershipApp FOR LOGIN CarDealershipApp
GO

use CarDealership
go

use CarDealership
grant create table to CarDealershipApp

GRANT Create to CarDealership
Grant Update to cardealership
grant Delete to cardealership
