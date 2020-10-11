--Drop Procedure CreateDomain

CREATE PROCEDURE CreateDomain 
	@DomainID UNIQUEIDENTIFIER,
	@Name varchar(50),
	@ApiKey UNIQUEIDENTIFIER
AS
BEGIN
	IF @DomainID = '00000000-0000-0000-0000-000000000000'
	BEGIN
	   SET @DomainID = NEWID();
    END
	
	DECLARE @Count int
	SET @Count = (Select COUNT(*) from Domain WHERE DomainID=@DomainID)

	IF @Count = 0
	BEGIN
	INSERT INTO Domain (DomainID, [Name], ApiKey)
	VALUES(@DomainID, @Name, @ApiKey)
	END

    Select DomainID, [Name], ApiKey From Domain Where DomainID = @DomainID

END
GO
