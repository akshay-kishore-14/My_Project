Create procedure AddUser         
(    
	@Id int,
    @FirstName VARCHAR(500),           
    @LastName VARCHAR(500),          
    @Email VARCHAR(500),
	@Country VARCHAR(500),
	@State VARCHAR(500),
	@City VARCHAR(500),
	@Phone BIGINT,
	@Password VARCHAR(500)
)

as           
Begin           
    Insert into UserDetails (Id, FirstName, LastName, Email, Country, State, City, Phone, Password)         
    Values (@Id, @FirstName, @LastName, @Email, @Country, @State, @City, @Phone, @Password)         
End