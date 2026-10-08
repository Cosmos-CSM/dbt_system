# *DBT System*

This repository provides database template projects that add key features within the CSM ecosystem.
This are pre-configured databases for ORM support on [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) and SQL based databases, 
is intended to be connected and work immediate OOB, but they provide a customization layer to extend base behavior.

The repository is composed of two projects:

- **DBT System** (`DBT.System`): the database definition, entities, design-time factory, and migrations.
- **DBT System Testing** (`DBT.System.Testing`): testing utilities for the database.

For deeper version details, please consult the [CHANGELOG](dbt_system/DBT%20System/CHANGELOG.md) and the [Testing CHANGELOG](dbt_system/DBT%20System%20Testing/CHANGELOG.md).

## **Database Structure**

Here you will be guided through the current database structure. For more structure details per version, please check the `CHANGELOG.md` files.

### Entities

- `EntityState` (`DBT System/Entities/EntityState.cs`): represents the system states of an entity within the database.
- `Asset` (`DBT System/Entities/Asset.cs`): represents a specific resource asset within the system database.
- `Configuration` (`DBT System/Entities/Configuration.cs`): represents a specific topic configuration within the system database, supporting scalar or referenced values.
- `Resource` (`DBT System/Entities/Resource.cs`): represents a local or external resource within the system database.

### Relations

- 1:M `Asset` (Dependency) -> `Resource` (Dependant): an `Asset` can have multiple `Resources` associated with it.
- M:1 `Resource` (Dependant) -> `Asset` (Dependency): each `Resource` references a single `Asset` as its `Type`.

> Dependant: Is the entity that has as a property the reference to the [Dependency].
> Dependency: Is the entity referenced from a [Dependant].

### Extras

- **SystemDatabase** (`SystemDatabase.cs`): main database context.
- **SystemDatabaseDesignFactory** (`SystemDatabaseDesignFactory.cs`): design-time factory used by EF Core tooling.
- **Depots**: data access abstractions and interfaces (`Depots/Abstractions/Interfaces`).
- **Migrations**: EF Core migrations for the database schema.

## **Installation & Usage**

Here you will be able to see how to use this database template in your business project.

// -->! Guide for NuGet related packages

> dotnet nuget add source --name "github" --username {*GITHUB.USR*} --password {*GITHUB.PAT*} "https://nuget.pkg.github.com/Cosmos-CSM/index.json"

- GITHUB.USR: Your GitHub user account.

- GITHUB.PAT: A generated personal access token. Go to *Settings* > *Developer Settings* > *Personal access tokens*, create a **Classic** token, and grant at minimum the **read:packages** permission.

> dotnet add package **DBT.System.Core** --source github

## *Testing*

The database template projects provide a package with testing utilities related to the database. To get these utilities, install it with:

> dotnet add package **DBT.System.Testing** --source github

For more specific version details about the testing package, please consult the [Testing CHANGELOG](dbt_system/DBT%20System%20Testing/CHANGELOG.md).
