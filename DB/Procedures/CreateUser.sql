--Drop Procedure CreateUser

CREATE PROCEDURE CreateUser 
	@UserID UNIQUEIDENTIFIER,
	@UserName varchar(50),
	@Password varchar(50),
	@UserRole int,
	@Domain varchar(50),
	@EmailID varchar(75)
AS
BEGIN
	IF @UserID = '00000000-0000-0000-0000-000000000000'
	BEGIN
	   SET @UserID = NEWID();
    END
	
	DECLARE @Count int
	SET @Count = (Select COUNT(*) from UserProfile WHERE UserID=@UserID)

	IF @Count = 0
	BEGIN
	INSERT INTO UserProfile (UserID, UserName, [Password], Domain, UserRole, EmailID)
	VALUES(@UserID, @UserName, @Password, @Domain, @UserRole, @EmailID)
	END

    Select UserName, UserID, EmailID, Domain, UserRole From UserProfile Where UserID = @UserID

END
GO
