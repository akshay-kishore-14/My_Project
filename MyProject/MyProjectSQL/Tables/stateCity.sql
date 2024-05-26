Create Table stateCity  
(  
   CityId Int,  
   StateId Int Foreign Key References countryState(StateId),  
   City Varchar(30)  
) 