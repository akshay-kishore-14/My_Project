USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[EmailValidation]    Script Date: 5/23/2024 12:09:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[EmailValidation] (
	@Email_valid VARCHAR(500)
)
as begin
	select Email from UserDetails where Email = @Email_valid
end