USE [SoochnaSevaDB]
GO
/****** Object:  StoredProcedure [dbo].[AddBeneficiaryNew]    Script Date: 5/22/2021 8:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[AddBeneficiary_LC]
(
 @BeneficiaryId INT,
 @FirstName VARCHAR(50),
 @LastName VARCHAR(50),
 @FathersName VARCHAR(50),
 @DOB  VARCHAR(50),
 @State INT,
 @LCGenderCode CHAR(1),
 @Age INT,
 @LCMaritalStatus VARCHAR(100),
 @LCEmpStatus VARCHAR(100),
 @LCDisability VARCHAR(100),
 @LCQualification VARCHAR(100),
 @SoochnaPreneur VARCHAR(500),
 @Address NVARCHAR(MAX),
 @EMail NVARCHAR(250),
 @Phone NVARCHAR(20),
 @DateOfRegistration VARCHAR(50)

)
AS
	DECLARE  @EngDistID INT, @DistName NVARCHAR(200), @LCDistID INT, @MaritalStatus INT, @EmpStatus INT,@VulGroup INT,  @AnnualIncome DECIMAL(18,2)
	DECLARE @StateId INT, @LCStateName NVARCHAR(200), @LCStateID INT, @StateName NVARCHAR (200), @Sex INT, @LCGender VARCHAR(50), @Disability INT, @Qualification INT
	DECLARE @Religion INT, @Occupation INT, @Category INT, @Department INT, @District INT, @Beneficiary INT = 0
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
	--SELECT @StateId = S.ID, @StateName = S.StateName FROM [dbo].[State] S WHERE S.StateName = @LCStateName
	SELECT @StateId = S.ID FROM [dbo].[State] S JOIN Users U ON U.StateID = S.Id WHERE U.UserName = @SoochnaPreneur

	--Get SoochnaSevaDB SexId based on LC Gender
	SELECT @LCGender = G.Gender FROM LC_GENDER G WHERE G.GenderCode = @LCGenderCode
	SELECT @Sex = S.ID FROM SEX S WHERE S.Name=@LCGender

	-- LC does not give Religion. Setting Religion to ANY
	SET @Religion = 1020;

	-- LC does not give Occupation. Setting Occupation to ANY
	SET @Occupation = 55;

	--Get SoochnaSevaDB MaritalStatusID based on LC MaritalStatus
	SELECT @MaritalStatus = M.ID FROM MaritalStatus M WHERE M.Name=@LCMaritalStatus

	-- LC does not give Category. Setting Category to ANY
	SET @Category = 16;

	-- LC does not give Department. Setting Department to ANY
	SET @Department = 3485;

	--Get SoochnaSevaDB EmpStatus based on LC Emp Status
	SELECT @EmpStatus=E.ID FROM EmpStatus E WHERE E.Name = @LCEmpStatus 

	-- LC does not have VulGroup. Setting VulGroup to ANY
	SET @VulGroup = 1016;
	SET @AnnualIncome = 0;
	--Get SoochnaSevaDB Disablity based on LC Disablity
	SELECT @Disability = D.ID FROM Disablity D  WHERE D.Name = @LCDisability

	--Get SoochnaSevaDB Qualification based on LC Qualification
	SET @LCQualification = '%' + @LCQualification + '%'; 
	SELECT @Qualification = Q.ID FROM Qualification Q WHERE Q.Name LIKE @LCQualification

	SELECT @Beneficiary=ID FROM Beneficiary (NoLock) WHERE ID = @BeneficiaryId

	--IF (NOT @Beneficiary > 0) 
	--	BEGIN
	--		SELECT @Beneficiary = NewBeneficiaryId FROM [dbo].[NewBeneficiary] WHERE BeneficiaryId = @Beneficiary AND UserId = @SoochnaPreneur
	--	END
	IF (@Beneficiary = 0)
	BEGIN

	

		INSERT INTO [dbo].[Beneficiary]
		(
			[Beneficiary], [FirstName],[LastName],[FathersName],
			[DOB],[State],[District],[Sex],[Age],[Religion],
			[Occupation],[MaritulStatus],[Category],
			[Department],[EmpStatus],[VulGroup],[AnnualIncome],
			[Disablity],[SoochnaPreneur],
			[Address], [EMail], [Phone],
			[DateOfRegistration] 
		)
	VALUES
		(
			@Beneficiary, @FirstName, @LastName , @FathersName,
			@DOB, @StateId,@LCDistID ,@Sex , @Age ,@Religion ,
			@Occupation , @MaritalStatus,@Category ,
			@Department , @EmpStatus , @VulGroup,
			@AnnualIncome , @Disability , @SoochnaPreneur , 
			@Address, @EMail, @Phone,
			@DateOfRegistration 
		)
	END
	
	SELECT @@IDENTITY

	
