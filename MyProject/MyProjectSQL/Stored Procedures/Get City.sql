USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[GetCity]    Script Date: 5/23/2024 12:09:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetCity] (
@statename varchar(500)
)
as             
begin            
   DECLARE @state_Id INT;
   select @state_Id = StateId from countryState where State=@statename

select City
from stateCity
where StateId = @state_Id
end