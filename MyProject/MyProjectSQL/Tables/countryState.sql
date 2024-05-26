Create Table countryState  
(  
   StateId Int Primary Key,  
   CountryId Int Foreign Key References Country(CountryId),  
   State Varchar(30)  
) 