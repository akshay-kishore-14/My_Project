USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[GetLoginUser]    Script Date: 5/23/2024 12:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[GetLoginUser] 

as             
begin            
	select Id, FirstName, LastName, Email, FilePath from UserDetails
	where Email = 'abc@gmail.com'
end