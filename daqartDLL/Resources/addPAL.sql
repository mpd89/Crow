
use [!!dbName!!]

exec sp_grant_publication_access @publication = N'!!dbName!!', @login = N'!!MachineName!!\Daqart_Agent'

