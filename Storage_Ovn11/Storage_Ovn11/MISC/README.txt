
(	Note: Starta om Visual Studio och öppna *.sln igen om inte
	PMC> Add-Mi<Tab> -> resolvar till Add-Migration		)

Efter att ProductController har lagts till:
Generera Databasen i EntityFramework:
1) Package Manager Console: Add-Migration Initial.

	PM> Add-Migration Initial
	Microsoft.EntityFrameworkCore.Infrastructure[10403]
	      Entity Framework Core 2.2.1-servicing-10028 initialized 'Storage_Ovn11Context' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
	To undo this action, use Remove-Migration.

2) Update-Database

	PM> Update-Database
	Microsoft.EntityFrameworkCore.Infrastructure[10403]
	      Entity Framework Core 2.2.1-servicing-10028 initialized 'Storage_Ovn11Context' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
	Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (278ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
	      CREATE DATABASE [Storage_Ovn11Context-7c309808-00db-4a03-a2b6-3c2f07c97c31];
	Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (80ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
	      IF SERVERPROPERTY('EngineEdition') <> 5
	      BEGIN
	          ALTER DATABASE [Storage_Ovn11Context-7c309808-00db-4a03-a2b6-3c2f07c97c31] SET READ_COMMITTED_SNAPSHOT ON;
	      END;
	Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
	      CREATE TABLE [__EFMigrationsHistory] (
	          [MigrationId] nvarchar(150) NOT NULL,
	          [ProductVersion] nvarchar(32) NOT NULL,
	          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
	      );
	Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (15ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
	      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
	Applying migration '20190121112449_Initial'.
	Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
	      SELECT [MigrationId], [ProductVersion]
	      FROM [__EFMigrationsHistory]
	      ORDER BY [MigrationId];
	Microsoft.EntityFrameworkCore.Migrations[20402]
	      Applying migration '20190121112449_Initial'.
	Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
	      CREATE TABLE [Product] (
	          [Id] int NOT NULL IDENTITY,
	          [Name] nvarchar(max) NULL,
	          [Price] int NOT NULL,
	          [OrderDate] datetime2 NOT NULL,
	          [Category] nvarchar(max) NULL,
	          [Shelf] nvarchar(max) NULL,
	          [Count] int NOT NULL,
	          [Description] nvarchar(max) NULL,
	          CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
	      );
	infoinfo:    Done.
	: Microsoft.EntityFrameworkCore.Database.Command[20101]
	      Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
	      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
	      VALUES (N'20190121112449_Initial', N'2.2.1-servicing-10028');
	PM> 