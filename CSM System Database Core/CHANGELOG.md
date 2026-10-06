# CSM System Database CHANGELOG

## [x.x.x] - xx.xx.xxxx

### Changes

- Added new entities to the database schema along with their depots. These entities are the followings: 
	- [Asset] representing a local or network asset within the system.
	- [Configuration] representing configuration settings for the system.
	- [Resource] representing various resources types used by the system.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | 7.0.0            | 7.0.0           |
| Microsoft.EntityFrameworkCore.Design	  | 10.0.10          | 10.0.10         |
	
## [1.0.0] - 10.09.2026

### Init

- Initialized package adding resources for a DB Creation using EF Core about CSM Ecosystem essentials.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | -.-.-            | 7.0.0           |
| Microsoft.EntityFrameworkCore.Design	  | -.-.-            | 10.0.10         |