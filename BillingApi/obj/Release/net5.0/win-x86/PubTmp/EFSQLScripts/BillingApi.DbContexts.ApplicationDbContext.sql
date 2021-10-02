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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210927172325_createDbAddLedgerItemTable')
BEGIN
    CREATE TABLE [LedgerItems] (
        [LedgerItemId] int NOT NULL IDENTITY,
        [Posted] datetime2 NOT NULL,
        [Description] nvarchar(max) NULL,
        [Debit] float NOT NULL,
        [Credit] float NOT NULL,
        [Remarks] nvarchar(max) NULL,
        [User] nvarchar(max) NULL,
        CONSTRAINT [PK_LedgerItems] PRIMARY KEY ([LedgerItemId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210927172325_createDbAddLedgerItemTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210927172325_createDbAddLedgerItemTable', N'5.0.10');
END;
GO

COMMIT;
GO

