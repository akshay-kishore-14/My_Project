USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 5/23/2024 12:09:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetAllUser] 

as             
begin            
	select Id, FirstName, LastName, Email, FilePath from UserDetails
end