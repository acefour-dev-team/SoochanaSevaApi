USE [SoochnaSevaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDEFSoochnaPreneur]
	  @State varchar(500)
	  AS
		BEGIN
			SET NOCOUNT ON;
			SELECT U.UserName, U.FirstName + ' ' + U.LastName AS Name, S.StateName, U.MobileNumber, U.Email FROM Users U
				JOIN State S ON U.StateID = S.ID
				WHERE IsDeleted = 0 
				AND RoleID = 7
				AND CompanyId = 1
				AND S.StateName = @State
				ORDER BY U.FirstName, U.LastName
		END




