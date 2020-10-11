--Drop Procedure CheckRegisteredUser

CREATE PROCEDURE CheckRegisteredUser 
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
	 Select U.UserID, U.UserName, U.UserRole, @ApiKey as ApiKey 
	 From dbo.[User] U JOIN dbo.[DomainUserMapping] DUM 
	 ON U.UserID = DUM.UserID WHERE U.UserName = @UserName and U.[Password] = @Password
	END

END
GO
