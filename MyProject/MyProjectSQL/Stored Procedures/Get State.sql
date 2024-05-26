USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[GetState]    Script Date: 5/23/2024 12:10:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetState] (

@countryname varchar(500)
 
)

as             

begin            
DECLARE @country_Id INT;
   select @country_Id = CountryId from Country where Country=@countryname

select State

from countryState

where CountryId = @country_Id

end