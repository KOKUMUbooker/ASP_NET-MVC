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

CREATE TABLE [Departments] (
    [DepartmentId] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId])
);
GO

CREATE TABLE [Employees] (
    [EmployeeId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(30) NOT NULL,
    [LastName] nvarchar(30) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [JoiningDate] datetime2 NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [Password] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
);
GO

CREATE TABLE [JobTitles] (
    [JobTitleId] int NOT NULL IDENTITY,
    [TitleName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_JobTitles] PRIMARY KEY ([JobTitleId])
);
GO

CREATE TABLE [SkillSets] (
    [SkillSetId] int NOT NULL IDENTITY,
    [SkillName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_SkillSets] PRIMARY KEY ([SkillSetId])
);
GO

CREATE TABLE [Addresses] (
    [AddressId] int NOT NULL IDENTITY,
    [Street] nvarchar(100) NOT NULL,
    [City] nvarchar(50) NOT NULL,
    [State] nvarchar(50) NOT NULL,
    [PostalCode] nvarchar(max) NOT NULL,
    [EmployeeId] int NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([AddressId]),
    CONSTRAINT [FK_Addresses_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [JobDetails] (
    [JobDetailId] int NOT NULL IDENTITY,
    [JobTitleId] int NOT NULL,
    [DepartmentId] int NOT NULL,
    [EmployeeId] int NOT NULL,
    [Salary] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_JobDetails] PRIMARY KEY ([JobDetailId]),
    CONSTRAINT [FK_JobDetails_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([DepartmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_JobDetails_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_JobDetails_JobTitles_JobTitleId] FOREIGN KEY ([JobTitleId]) REFERENCES [JobTitles] ([JobTitleId]) ON DELETE CASCADE
);
GO

CREATE TABLE [EmployeeSkillSet] (
    [EmployeesEmployeeId] int NOT NULL,
    [SkillSetsSkillSetId] int NOT NULL,
    CONSTRAINT [PK_EmployeeSkillSet] PRIMARY KEY ([EmployeesEmployeeId], [SkillSetsSkillSetId]),
    CONSTRAINT [FK_EmployeeSkillSet_Employees_EmployeesEmployeeId] FOREIGN KEY ([EmployeesEmployeeId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeSkillSet_SkillSets_SkillSetsSkillSetId] FOREIGN KEY ([SkillSetsSkillSetId]) REFERENCES [SkillSets] ([SkillSetId]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'Name') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] ON;
INSERT INTO [Departments] ([DepartmentId], [Name])
VALUES (1, N'IT'),
(2, N'HR'),
(3, N'Payroll'),
(4, N'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'Name') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'JobTitleId', N'TitleName') AND [object_id] = OBJECT_ID(N'[JobTitles]'))
    SET IDENTITY_INSERT [JobTitles] ON;
INSERT INTO [JobTitles] ([JobTitleId], [TitleName])
VALUES (1, N'Software Engineer'),
(2, N'Project Manager'),
(3, N'Quality Assurance Engineer'),
(4, N'Business Analyst'),
(5, N'System Administrator');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'JobTitleId', N'TitleName') AND [object_id] = OBJECT_ID(N'[JobTitles]'))
    SET IDENTITY_INSERT [JobTitles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SkillSetId', N'SkillName') AND [object_id] = OBJECT_ID(N'[SkillSets]'))
    SET IDENTITY_INSERT [SkillSets] ON;
INSERT INTO [SkillSets] ([SkillSetId], [SkillName])
VALUES (1, N'Dot Net'),
(2, N'Java'),
(3, N'Python'),
(4, N'PHP'),
(5, N'Database');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SkillSetId', N'SkillName') AND [object_id] = OBJECT_ID(N'[SkillSets]'))
    SET IDENTITY_INSERT [SkillSets] OFF;
GO

CREATE UNIQUE INDEX [IX_Addresses_EmployeeId] ON [Addresses] ([EmployeeId]);
GO

CREATE UNIQUE INDEX [IX_Employees_Unique_Email] ON [Employees] ([Email]);
GO

CREATE INDEX [IX_EmployeeSkillSet_SkillSetsSkillSetId] ON [EmployeeSkillSet] ([SkillSetsSkillSetId]);
GO

CREATE INDEX [IX_JobDetails_DepartmentId] ON [JobDetails] ([DepartmentId]);
GO

CREATE UNIQUE INDEX [IX_JobDetails_EmployeeId] ON [JobDetails] ([EmployeeId]);
GO

CREATE INDEX [IX_JobDetails_JobTitleId] ON [JobDetails] ([JobTitleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251221160603_InitialCreate', N'8.0.22');
GO

COMMIT;
GO

