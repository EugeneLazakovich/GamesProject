CREATE TABLE Sales (
	[GameId] Uniqueidentifier NOT NULL DEFAULT NEWID(),
	[UserId] Uniqueidentifier NOT NULL DEFAULT NEWID(),
	[DateBuy] date NOT NULL DEFAULT GETDATE(),
	[Price] DECIMAL(7, 2) NOT NULL DEFAULT 0, 
    PRIMARY KEY (
		[GameId],
		[UserId]
		)
	)
