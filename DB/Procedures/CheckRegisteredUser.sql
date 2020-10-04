--Drop Procedure CheckRegisteredUser

CREATE PROCEDURE CheckRegisteredUser 
	@UserName varchar(50),
	@Password varchar(50)
AS
BEGIN
	DECLARE @Count int
	SET @Count = (Select COUNT(*) from UserProfile WHERE UserName = @UserName and Password = @Password)

	IF @Count = 0
	BEGIN
		Select '';
	END
	ELSE
	BEGIN
		Select UserID From UserProfile WHERE UserName=@UserName and Password =@Password
	END
END
GO
