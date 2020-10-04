Create Table UserProfile(
	UserID UNIQUEIDENTIFIER NOT NULL,
    UserName varchar(50) Not Null,
    [Password] varchar(50) Not Null,
    Domain varchar(50) Not Null,
    EmailID varchar(75),
	PRIMARY KEY (UserID)
)