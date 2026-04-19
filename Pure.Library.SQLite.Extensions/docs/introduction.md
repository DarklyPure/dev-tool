# Pure.Library.SQLite.Extensions Library
This set of extensions provides extra functionality to using a Sqlite database in your application and in particular
when using it with Entity Framework.

## Extensions
There are currently two main Extensions in use here.

### DbConnectionExtensions
These extend the DbConnection feature, currently providing only one feature set.

#### QueryTableNames
This basically bundles up the query tables functionality and using that returns a collection of Tables in the database.