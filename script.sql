IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BallHistories] (
    [Id] int NOT NULL IDENTITY,
    [BallNumber] int NOT NULL,
    [GeneratedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_BallHistories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230224145912_InitialCreate', N'7.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [CardboardHistories] (
    [Id] int NOT NULL IDENTITY,
    [CardboardOne] int NULL,
    [CardboardTwo] int NULL,
    [CardboardThree] int NULL,
    [CardboardFour] int NULL,
    [GeneratedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_CardboardHistories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230226161923_SecondCreate', N'7.0.3');
GO

COMMIT;
GO