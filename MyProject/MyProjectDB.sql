USE [master]
GO
/****** Object:  Database [MyProjectDB]    Script Date: 27-05-2024 09:37:51 PM ******/
CREATE DATABASE [MyProjectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyProjectDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyProjectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyProjectDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyProjectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyProjectDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyProjectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyProjectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyProjectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyProjectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyProjectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyProjectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyProjectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyProjectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyProjectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyProjectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyProjectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyProjectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyProjectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyProjectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyProjectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyProjectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyProjectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyProjectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyProjectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyProjectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyProjectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyProjectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyProjectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyProjectDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyProjectDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyProjectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyProjectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyProjectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyProjectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyProjectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyProjectDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyProjectDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyProjectDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyProjectDB]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] NOT NULL,
	[Country] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countryState]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countryState](
	[StateId] [int] NOT NULL,
	[CountryId] [int] NULL,
	[State] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stateCity]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stateCity](
	[CityId] [int] NULL,
	[StateId] [int] NULL,
	[City] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](500) NULL,
	[LastName] [varchar](500) NULL,
	[Email] [varchar](500) NULL,
	[Country] [varchar](500) NULL,
	[State] [varchar](500) NULL,
	[City] [varchar](500) NULL,
	[Phone] [bigint] NULL,
	[Password] [varchar](500) NULL,
	[FilePath] [varchar](500) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[countryState]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[stateCity]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[countryState] ([StateId])
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddUser]         
(    
    @FirstName VARCHAR(500),           
    @LastName VARCHAR(500),          
    @Email VARCHAR(500),
	@Country VARCHAR(500),
	@State VARCHAR(500),
	@City VARCHAR(500),
	@Phone BIGINT,
	@Password VARCHAR(500),
	@FilePath VARCHAR(500)
)

as           
Begin           
    Insert into UserDetails (FirstName, LastName, Email, Country, State, City, Phone, Password, FilePath)         
    Values ( @FirstName, @LastName, @Email, @Country, @State, @City, @Phone, @Password, @FilePath)         
End
GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLogin](
	@user_email NVARCHAR(500),
	@user_pass NVARCHAR(500)
)
as
begin
	SET NOCOUNT ON;
	select Email, Password from UserDetails where Email = @user_email and Password = @user_pass
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteUser] (
	@id int
)
as
begin
	delete from UserDetails
	where Id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[EmailValidation]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EmailValidation] (
	@Email_valid VARCHAR(500)
)
as begin
	select Email from UserDetails where Email = @Email_valid
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllUser]

as             
begin            
	select Id, FirstName, LastName, Email, FilePath from UserDetails
end
GO
/****** Object:  StoredProcedure [dbo].[GetCity]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCity] (
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
GO
/****** Object:  StoredProcedure [dbo].[GetCountry]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCountry]
AS
SELECT Country FROM Country
GO;
GO
/****** Object:  StoredProcedure [dbo].[GetLoginUser]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetLoginUser] 

as             
begin            
	select Id, FirstName, LastName, Email, Image from UserDetails
	where Email = 'abc@gmail.com'
end
GO
/****** Object:  StoredProcedure [dbo].[GetState]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetState] (

@countryname varchar(500)
 
)

as             

begin            
DECLARE @country_Id INT;
   select @country_Id = CountryId from Country where Country=@countryname

select State

from countryState

where CountryId = @country_Id

end
GO
/****** Object:  StoredProcedure [dbo].[ShowUserDetails]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowUserDetails] (
	@id int
)
as 
begin
	select * from UserDetails where Id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 27-05-2024 09:37:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser] (

	@Id int,
	@FirstName VARCHAR(500),           
    @LastName VARCHAR(500),          
    @Email VARCHAR(500),
	@Country VARCHAR(500),
	@State VARCHAR(500),
	@City VARCHAR(500),
	@Phone BIGINT,
	@Password VARCHAR(500),
	@FilePath VARCHAR(500)
)
as 
begin
	UPDATE UserDetails
	SET 
	FirstName = @FirstName, 
	LastName = @LastName,
	Email = @Email,
	Country = @Country,
	State = @State,
	City = @City,
	Phone = @Phone,
	Password = @Password,
	FilePath = @FilePath

WHERE Id = @Id;
end
GO
USE [master]
GO
ALTER DATABASE [MyProjectDB] SET  READ_WRITE 
GO
