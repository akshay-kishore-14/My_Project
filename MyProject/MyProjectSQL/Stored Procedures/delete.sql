USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/23/2024 12:08:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[DeleteUser] (
	@id int
)
as
begin
	delete from UserDetails
	where Id = @id
end