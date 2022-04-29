CREATE DATABASE BRQ;
GO
USE BRQ;
GO
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
CREATE TABLE [Truck] (
    [Id] uniqueidentifier NOT NULL,
    [Model] int NOT NULL,
    [ManufactoryYear] int NOT NULL,
    [ModelYear] int NOT NULL,
    CONSTRAINT [PK_Truck] PRIMARY KEY ([Id])
);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220429034149_Initial', N'5.0.15');
GO
COMMIT;
GO


