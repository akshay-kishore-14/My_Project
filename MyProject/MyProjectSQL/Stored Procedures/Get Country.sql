USE [MyProjectDB]
GO
/****** Object:  StoredProcedure [dbo].[GetCountry]    Script Date: 5/23/2024 12:10:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetCountry]
AS
SELECT Country FROM Country
GO;