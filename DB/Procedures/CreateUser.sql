Drop Procedure CreateUser
GO

CREATE PROCEDURE CreateUser 
	@UserID UNIQUEIDENTIFIER,
	@UserName varchar(50),
	@Password varchar(50),
	@UserRole int,
	@Domain varchar(50),
	@EmailID varchar(75) = null
AS
BEGIN
	IF @UserID = '00000000-0000-0000-0000-000000000000'
	BEGIN
	   SET @UserID = NEWID();
    END
	
	DECLARE @Count int
	SET @Count = (Select COUNT(*) from dbo.[User] WHERE UserID=@UserID)

	IF @Count = 0
	BEGIN
	INSERT INTO dbo.[User] (UserID, UserName, [Password], UserRole, EmailID)
	VALUES(@UserID, @UserName, @Password, @UserRole, @EmailID)
	END

	DECLARE @DomainCount int
	SET @DomainCount = (SELECT COUNT(*) from Domain WHERE [Name] = @Domain)

	IF @DomainCount = 1
	BEGIN
	DECLARE @DomainID UNIQUEIDENTIFIER
	SET @DomainID = (SELECT DomainID from Domain WHERE [Name] = @Domain)

	INSERT INTO DomainUserMapping (DomainUserMappingID, DomainID, UserID) VALUES(NEWID(), @DomainID, @UserID)
	END

	Select U.UserID, U.UserName, U.UserRole, D.[Name] AS DomainName, D.ApiKey 
	FROM dbo.[User] U
	JOIN dbo.[DomainUserMapping] DUM ON U.UserID = DUM.UserID
	JOIN dbo.[Domain] D ON D.DomainID = DUM.DomainID
	WHERE DUM.UserID = @UserID

END
GO
