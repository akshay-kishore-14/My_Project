USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[ShowUserDetails]    Script Date: 5/23/2024 12:11:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ShowUserDetails] (
	@id int
)
as 
begin
	select * from UserDetails where Id=@id
end