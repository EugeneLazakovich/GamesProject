CREATE TABLE [dbo].[Games]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT(NEWID()),
	[Name] NVARCHAR(100) NOT NULL,
	[Company] NVARCHAR(100),
	[SupportEmail] NVARCHAR(100),
	[DateReleased] datetime2,
	[CountBuys] INT NOT NULL
)
