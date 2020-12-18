
# Database Layout

    CREATE TABLE [dbo].[Table] (
    [Id]               INT        IDENTITY (1, 1) NOT NULL,
    [username]         NCHAR (50) NULL,
    [password]         NCHAR (50) NULL,
    [registrationDate] DATETIME   DEFAULT (getdate()) NULL,
    [lastLogin]        DATETIME   NULL,
    [failedLogins]     INT        NULL DEFAULT 0,
    [successfulLogins] INT        NULL DEFAULT 0,
    [clientIP]         NCHAR (50) NULL,
    [perm]             NCHAR (10) NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC) 
    );


|Id|username|password|registrationDate|lastLogin|failedLogins|successfulLogins|clientIP|perm|
|--|--|--|--|--|--|--|--|--|
|AI|@Username|@Password|@RegDate|@LastaLogin|@FLogins|@SLogins|@CIp|@Perm|
|1|test123|hash(StronkPsw!)|"18.12.2020 10:23:04"|"18.12.2020 10:23:04"|0|123|XXX.XXX.XXX.XXX|0|


# Permissions

|Value  | Permissions |
|--|--|
|0| default / new registered user |
|NULL| default / new registered user |
|1-8| user states
|99|Admin / root

 # Credits
 - [Henk Mollema for his CryptoHelper function.](https://github.com/henkmollema/CryptoHelper)
