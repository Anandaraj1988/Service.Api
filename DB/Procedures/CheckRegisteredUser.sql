USE [Admin]
GO

/****** Object:  StoredProcedure [dbo].[CheckRegisteredUser]    Script Date: 29-11-2020 20:06:57 ******/
DROP PROCEDURE [dbo].[CheckRegisteredUser]
GO

/****** Object:  StoredProcedure [dbo].[CheckRegisteredUser]    Script Date: 29-11-2020 20:06:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Drop Procedure CheckRegisteredUser

CREATE PROCEDURE [dbo].[CheckRegisteredUser] 
	@UserName varchar(50),
	@Password varchar(50),
	@Domain varchar(50)
AS
BEGIN
	Declare @DomainID UNIQUEIDENTIFIER;
	Declare @ApiKey uniqueIdentifier;

	IF @Domain <> '' AND @Domain IS NOT NULL
	BEGIN
	SET @DomainID = (SELECT DomainID FROM Domain WHERE [Name] = @Domain)
	SET @ApiKey = (SELECT ApiKey FROM dbo.[Domain] WHERE DomainID = @DomainID)
	END


	IF @DomainID <> '00000000-0000-0000-0000-000000000000'
	BEGIN
	 Declare @Count int;
	 Declare @UserID uniqueidentifier;
	 SET @UserID = (Select  U.UserID
	 From dbo.[User] U JOIN dbo.[DomainUserMapping] DUM 
	 ON U.UserID = DUM.UserID WHERE U.UserName = @UserName and U.[Password] = @Password)

	 IF @UserID <> '00000000-0000-0000-0000-000000000000' AND @UserID IS NOT NULL
	 BEGIN
		SELECT U.UserID, U.UserName, U.UserRole, U.AccessToken
		From dbo.[User] U JOIN dbo.[DomainUserMapping] DUM 
		ON U.UserID = DUM.UserID WHERE U.UserID = @UserID;
	 END
	END

END
GO


