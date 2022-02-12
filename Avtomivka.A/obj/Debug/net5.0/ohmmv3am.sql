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

IF SCHEMA_ID(N'17118057') IS NULL EXEC(N'CREATE SCHEMA [17118057];');
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [17118057].[log_17118057] (
    [Id] nvarchar(450) NOT NULL,
    [Table] nvarchar(max) NOT NULL,
    [Operation] nvarchar(max) NOT NULL,
    [Delete] bit NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified_17118057] datetime2 NOT NULL,
    CONSTRAINT [PK_log_17118057] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [17118057].[Worker] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [Image] nvarchar(max) NULL,
    [Description] nvarchar(max) NOT NULL,
    [Taken] bit NOT NULL,
    [Delete] bit NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified_17118057] datetime2 NOT NULL,
    CONSTRAINT [PK_Worker] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [17118057].[Colon] (
    [Id] nvarchar(450) NOT NULL,
    [Number] int NOT NULL,
    [Taken] bit NOT NULL,
    [UserId] nvarchar(450) NULL,
    [Delete] bit NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified_17118057] datetime2 NOT NULL,
    CONSTRAINT [PK_Colon] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Colon_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [17118057].[Program] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Price] float NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [WorkerId] nvarchar(450) NULL,
    [Delete] bit NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified_17118057] datetime2 NOT NULL,
    CONSTRAINT [PK_Program] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Program_Worker_WorkerId] FOREIGN KEY ([WorkerId]) REFERENCES [17118057].[Worker] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [17118057].[WashReservation] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(max) NOT NULL,
    [ReservationDate] datetime2 NOT NULL,
    [ProgramId] nvarchar(450) NULL,
    [WorkerId] nvarchar(450) NULL,
    [ColonId] nvarchar(450) NULL,
    [Delete] bit NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified_17118057] datetime2 NOT NULL,
    CONSTRAINT [PK_WashReservation] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WashReservation_Colon_ColonId] FOREIGN KEY ([ColonId]) REFERENCES [17118057].[Colon] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WashReservation_Program_ProgramId] FOREIGN KEY ([ProgramId]) REFERENCES [17118057].[Program] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WashReservation_Worker_WorkerId] FOREIGN KEY ([WorkerId]) REFERENCES [17118057].[Worker] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Colon_UserId] ON [17118057].[Colon] ([UserId]);
GO

CREATE INDEX [IX_Program_WorkerId] ON [17118057].[Program] ([WorkerId]);
GO

CREATE INDEX [IX_WashReservation_ColonId] ON [17118057].[WashReservation] ([ColonId]);
GO

CREATE INDEX [IX_WashReservation_ProgramId] ON [17118057].[WashReservation] ([ProgramId]);
GO

CREATE INDEX [IX_WashReservation_WorkerId] ON [17118057].[WashReservation] ([WorkerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220128122652_Initial', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [17118057].[Program] DROP CONSTRAINT [FK_Program_Worker_WorkerId];
GO

DROP INDEX [IX_Program_WorkerId] ON [17118057].[Program];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[17118057].[Program]') AND [c].[name] = N'WorkerId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [17118057].[Program] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [17118057].[Program] DROP COLUMN [WorkerId];
GO

ALTER TABLE [17118057].[WashReservation] ADD [UserId] nvarchar(450) NULL;
GO

CREATE INDEX [IX_WashReservation_UserId] ON [17118057].[WashReservation] ([UserId]);
GO

ALTER TABLE [17118057].[WashReservation] ADD CONSTRAINT [FK_WashReservation_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220131135153_test', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[17118057].[Colon].[Number]', N'COLON TEST', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220212152043_ChangeColonName', N'5.0.13');
GO

COMMIT;
GO

