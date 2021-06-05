USE [SoochnaSevaDB]
GO
/****** Object:  StoredProcedure [dbo].[AddBeneficiaryNew]    Script Date: 5/22/2021 8:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE  [dbo].[AddBeneficiary_LC]
(
 @BeneficiaryId INT,
 @Beneficiary INT,
 @FirstName VARCHAR(50),
 @LastName VARCHAR(50),
 @FathersName VARCHAR(50),
 @HusbandsName VARCHAR(50),
 @DOB  VARCHAR(50),
 @IDProof INT,
 @IDDetails VARCHAR(50),
 @State INT,
 @District INT,
 @Sex INT,
 @Age INT,
 @Religion INT,
 @Socio INT,
 @Occupation INT,
 @MaritalStatus INT,
 @Category INT,
 @Department INT,
 @EmpStatus INT,
 @VulGroup INT,
 @AnnualIncome DECIMAL(18,2),
 @Disability INT,
 @SoochnaPreneur VARCHAR(500),
 @Photo NVARCHAR(MAX),
 @Relationship INT,
 @Sickness INT,
 @Address NVARCHAR(MAX),
 @EMail NVARCHAR(250),
 @Phone NVARCHAR(20),
 @DateOfRegistration VARCHAR(50),
 @PercentageDisability INT = 0,
 @Qualification INT = 0,
 @Block VARCHAR(100),
 @Village VARCHAR(100),
 @Panchayat VARCHAR(100)
)
AS
	DECLARE  @EngDistID INT, @DistName NVARCHAR(200), @LCDistID INT
	DECLARE @StateId INT, @LCStateName NVARCHAR(200), @LCStateID INT, @StateName NVARCHAR (200)

	--Get SoochnaSeva District
	--Get EngDistID of the Soochnapreneur
	SELECT  @EngDistID= D.EngDistrictId FROM Users U JOIN District D 
	ON U.DistrictID=D.ID
	WHERE U.UserName = @SoochnaPreneur

	--Get English District Name from SoochnaSeva
	SELECT @DistName=D.DistrictName FROM District D WHERE D.ID = @EngDistID

	--Get LC DistictID based on the District Name
	SELECT @LCDistID = L.Id  FROM [dbo].[LC_District] L WHERE L.Name = @DistName

	--Get SoochnaSevaDB State based on LC StateId
	--Get LC State Name from LCState Id
	SELECT @LCStateName=LS.Name FROM LC_State LS WHERE LS.ID = @State

	-- Get SoochnaSevaDB StateId based on StateName
	SELECT @StateId = S.ID, @StateName = S.StateName FROM [dbo].[State] S WHERE S.StateName = @LCStateName

	INSERT INTO [dbo].[Beneficiary]
	(
		[Beneficiary],[FirstName],[LastName],[FathersName],
		[HusbandsName],
		[DOB],[IDProof],
		[IDDetails],[State],[District],
		[Sex],[Age],[Religion],
		[Socio],[Occupation],[MaritulStatus],[Category],
		[Department],[EmpStatus],[VulGroup],[AnnualIncome],
		[Disablity],[SoochnaPreneur],[Photo], [Relationship],
		[Sickness],
		[Address], [EMail], [Phone],
		[DateOfRegistration],[PercentageDisability], [Qualification],[Block],[Village],[Panchayat]
	)
VALUES
	(
		@Beneficiary, @FirstName, @LastName , @FathersName ,

		@HusbandsName , 
		@DOB ,@IDProof,
		@IDDetails, @StateId,
		@LCDistID ,@Sex , @Age ,@Religion ,
		@Socio , @Occupation , @MaritalStatus,
		@Category ,@Department , @EmpStatus , @VulGroup,
		@AnnualIncome , @Disability , @SoochnaPreneur , @Photo ,
		@Relationship, @Sickness,
		@Address, @EMail, @Phone,
		@DateOfRegistration, @PercentageDisability, @Qualification, @Block, @Village, @Panchayat


	)
	IF(@Beneficiary <> 0)
	BEGIN
		UPDATE [dbo].[Beneficiary]
		SET Beneficiary = (SELECT NewBeneficiaryId FROM [dbo].[NewBeneficiary] WHERE BeneficiaryId = @Beneficiary AND UserId = @SoochnaPreneur)
		WHERE Id = @@IDENTITY
	END
	--ELSE
	BEGIN
		INSERT INTO [dbo].[NewBeneficiary] (UserId, BeneficiaryId, NewBeneficiaryId, NewIdentityKey)
		VALUES (@SoochnaPreneur, @BeneficiaryId, @@IDENTITY, @@IDENTITY)
	END

	
