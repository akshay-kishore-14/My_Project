USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 5/23/2024 12:11:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateUser] (
	@Id int,
	@FirstName VARCHAR(500),           
    @LastName VARCHAR(500),          
    @Email VARCHAR(500),
	@Country VARCHAR(500),
	@State VARCHAR(500),
	@City VARCHAR(500),
	@Phone BIGINT,
	@Password VARCHAR(500),
	@FilePath VARCHAR(500)
)
as 
begin
	UPDATE UserDetails
	SET 
	FirstName = @FirstName, 
	LastName = @LastName,
	Email = @Email,
	Country = @Country,
	State = @State,
	City = @City,
	Phone = @Phone,
	Password = @Password,
	FilePath = @FilePath
WHERE Id = @Id;
end