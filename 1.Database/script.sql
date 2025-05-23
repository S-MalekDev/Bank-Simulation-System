USE [master]
GO
/****** Object:  Database [BANK]    Script Date: 5/14/2025 7:22:37 PM ******/
CREATE DATABASE [BANK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BANK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BANK.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BANK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BANK_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BANK] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BANK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BANK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BANK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BANK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BANK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BANK] SET ARITHABORT OFF 
GO
ALTER DATABASE [BANK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BANK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BANK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BANK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BANK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BANK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BANK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BANK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BANK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BANK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BANK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BANK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BANK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BANK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BANK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BANK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BANK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BANK] SET RECOVERY FULL 
GO
ALTER DATABASE [BANK] SET  MULTI_USER 
GO
ALTER DATABASE [BANK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BANK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BANK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BANK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BANK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BANK] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BANK', N'ON'
GO
ALTER DATABASE [BANK] SET QUERY_STORE = ON
GO
ALTER DATABASE [BANK] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BANK]
GO
/****** Object:  Table [dbo].[AccountCurrencies]    Script Date: 5/14/2025 7:22:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountCurrencies](
	[AccountCurrencyID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CurrencyID] [tinyint] NOT NULL,
 CONSTRAINT [PK_PossibleAccountCurrencies] PRIMARY KEY CLUSTERED 
(
	[AccountCurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypes](
	[TransactionTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Fees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountNumber] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Balance] [money] NOT NULL,
	[AccountCurrency] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeID] [tinyint] NOT NULL,
	[ServiceAppID] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WithdrawAndDepositOperations]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WithdrawAndDepositOperations](
	[OperationID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[OperationFees] [smallmoney] NOT NULL,
	[PreviousBalance] [money] NOT NULL,
	[BalanceAfterTransaction] [money] NOT NULL,
 CONSTRAINT [PK_WithdrawAndDepositOperations] PRIMARY KEY CLUSTERED 
(
	[OperationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesApplications]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesApplications](
	[ServiceAppID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ServiceID] [tinyint] NOT NULL,
	[RequestDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ServicesApplications] PRIMARY KEY CLUSTERED 
(
	[ServiceAppID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](50) NOT NULL,
	[Currency] [nvarchar](10) NOT NULL,
	[CurrencySymbol] [nvarchar](10) NOT NULL,
	[ExchangeRatePerUSD] [float] NOT NULL,
 CONSTRAINT [PK_Currencies1] PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[WithdrawDepositView]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WithdrawDepositView]
AS
SELECT CAST(dbo.WithdrawAndDepositOperations.OperationID AS nvarchar) AS ID, dbo.WithdrawAndDepositOperations.ClientID, dbo.TransactionTypes.Name AS [Transaction Type], 
                  CAST(dbo.WithdrawAndDepositOperations.Amount AS nvarchar) + ' ' + dbo.Currencies.CurrencySymbol AS Amount, FORMAT(dbo.ServicesApplications.RequestDate, 'dd-MM-yyyy') AS Date, 
                  FORMAT(dbo.ServicesApplications.RequestDate, 'HH:mm') AS Time
FROM     dbo.WithdrawAndDepositOperations INNER JOIN
                  dbo.Transactions ON dbo.WithdrawAndDepositOperations.TransactionID = dbo.Transactions.TransactionID INNER JOIN
                  dbo.TransactionTypes ON dbo.Transactions.TransactionTypeID = dbo.TransactionTypes.TransactionTypeID INNER JOIN
                  dbo.ServicesApplications ON dbo.Transactions.ServiceAppID = dbo.ServicesApplications.ServiceAppID INNER JOIN
                  dbo.Accounts ON dbo.WithdrawAndDepositOperations.ClientID = dbo.Accounts.ClientID INNER JOIN
                  dbo.AccountCurrencies ON dbo.Accounts.AccountCurrency = dbo.AccountCurrencies.AccountCurrencyID INNER JOIN
                  dbo.Currencies ON dbo.AccountCurrencies.CurrencyID = dbo.Currencies.CurrencyID
GO
/****** Object:  Table [dbo].[TransferApplications]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferApplications](
	[TransferID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	[TransferTypeID] [tinyint] NOT NULL,
 CONSTRAINT [PK_TransferOperations] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InternalTransferOperations]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternalTransferOperations](
	[OperationID] [int] IDENTITY(1,1) NOT NULL,
	[TransferID] [int] NOT NULL,
	[CurrencyOfTransfer] [tinyint] NOT NULL,
	[TransferFromClientID] [int] NOT NULL,
	[DoneByUser] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[Fees] [smallmoney] NOT NULL,
	[CurrencyOfAmountReceived] [tinyint] NOT NULL,
	[TransferToClientID] [int] NOT NULL,
	[AmountReceived] [money] NOT NULL,
	[IsSucceedit] [bit] NOT NULL,
 CONSTRAINT [PK_InternalTransfers] PRIMARY KEY CLUSTERED 
(
	[OperationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[InternalTransferOperationsView]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InternalTransferOperationsView]
AS
SELECT CAST(dbo.InternalTransferOperations.OperationID AS nvarchar) AS ID, dbo.InternalTransferOperations.TransferFromClientID AS ClientID, CAST(dbo.InternalTransferOperations.Amount AS nvarchar) 
                  + ' ' + dbo.Currencies.CurrencySymbol AS Amount, FORMAT(dbo.ServicesApplications.RequestDate, 'dd-MM-yyyy') AS Date, FORMAT(dbo.ServicesApplications.RequestDate, 'HH:mm') AS Time, 
                  CASE InternalTransferOperations.IsSucceedit WHEN 1 THEN 'Succeeded' WHEN 0 THEN 'Failed' END AS [Is Succeeded]
FROM     dbo.InternalTransferOperations INNER JOIN
                  dbo.AccountCurrencies ON dbo.InternalTransferOperations.CurrencyOfTransfer = dbo.AccountCurrencies.AccountCurrencyID INNER JOIN
                  dbo.Currencies ON dbo.AccountCurrencies.CurrencyID = dbo.Currencies.CurrencyID INNER JOIN
                  dbo.TransferApplications ON dbo.InternalTransferOperations.TransferID = dbo.TransferApplications.TransferID INNER JOIN
                  dbo.Transactions ON dbo.TransferApplications.TransactionID = dbo.Transactions.TransactionID INNER JOIN
                  dbo.ServicesApplications ON dbo.Transactions.ServiceAppID = dbo.ServicesApplications.ServiceAppID
GO
/****** Object:  Table [dbo].[ExternalTransferOperations]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalTransferOperations](
	[OperationID] [int] IDENTITY(1,1) NOT NULL,
	[TransfeID] [int] NOT NULL,
	[DoneByUser] [int] NOT NULL,
	[TronsferFrom] [int] NOT NULL,
	[CurrencyOfTransferID] [tinyint] NOT NULL,
	[Amount] [smallmoney] NOT NULL,
	[Fees] [smallmoney] NOT NULL,
	[BankName] [nvarchar](30) NOT NULL,
	[IBAN_Number] [nvarchar](30) NOT NULL,
	[RecipientFullName] [nvarchar](100) NOT NULL,
	[SendingDate] [datetime] NOT NULL,
	[ArrivalDate] [datetime] NULL,
	[status] [tinyint] NOT NULL,
 CONSTRAINT [PK_ExternalTransfers] PRIMARY KEY CLUSTERED 
(
	[OperationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ExternalTransferOperationsView]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ExternalTransferOperationsView]
AS
SELECT CAST(dbo.ExternalTransferOperations.OperationID AS nvarchar) AS ID, dbo.ExternalTransferOperations.TronsferFrom AS ClientID, CAST(dbo.ExternalTransferOperations.Amount + dbo.ExternalTransferOperations.Fees AS nvarchar) 
                  + ' ' + dbo.Currencies.CurrencySymbol AS Amount, FORMAT(dbo.ExternalTransferOperations.SendingDate, 'dd-MM-yyyy') AS Date, FORMAT(dbo.ExternalTransferOperations.SendingDate, 'HH:mm') AS Time, 
                  CASE ExternalTransferOperations.status WHEN 1 THEN 'New' WHEN 2 THEN 'Canceled' WHEN 3 THEN 'Completed' ELSE 'Unknown' END AS Status
FROM     dbo.ExternalTransferOperations INNER JOIN
                  dbo.AccountCurrencies ON dbo.ExternalTransferOperations.CurrencyOfTransferID = dbo.AccountCurrencies.AccountCurrencyID INNER JOIN
                  dbo.Currencies ON dbo.AccountCurrencies.CurrencyID = dbo.Currencies.CurrencyID
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[MedName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Gendor] [bit] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[NationalNumber] [nvarchar](20) NOT NULL,
	[Nationality] [tinyint] NOT NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[CountryOfResidence] [tinyint] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpenNewAccountApplications]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenNewAccountApplications](
	[AppID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[OpeningDate] [datetime] NOT NULL,
	[AccountID] [int] NULL,
 CONSTRAINT [PK_OpenNewAccountApplications] PRIMARY KEY CLUSTERED 
(
	[AppID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AccountsList]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AccountsList]
AS
SELECT dbo.Accounts.AccountNumber AS [Account No], dbo.Clients.ClientID AS [Client ID], CASE WHEN NOT People.MedName IS NULL 
                  THEN People.FirstName + ' ' + People.MedName + ' ' + People.LastName ELSE People.FirstName + ' ' + People.LastName END AS [Client Full Name], FORMAT(dbo.OpenNewAccountApplications.OpeningDate, 'dd-MMM-yyyy') 
                  AS [Openning Date], dbo.Accounts.Balance, dbo.Currencies.CurrencySymbol AS Currency, dbo.Accounts.IsActive AS [Is Active]
FROM     dbo.Accounts INNER JOIN
                  dbo.Clients ON dbo.Accounts.ClientID = dbo.Clients.ClientID INNER JOIN
                  dbo.People ON dbo.Clients.PersonID = dbo.People.PersonID INNER JOIN
                  dbo.OpenNewAccountApplications ON dbo.Accounts.AccountNumber = dbo.OpenNewAccountApplications.AccountID INNER JOIN
                  dbo.AccountCurrencies ON dbo.Accounts.AccountCurrency = dbo.AccountCurrencies.AccountCurrencyID INNER JOIN
                  dbo.Currencies ON dbo.AccountCurrencies.CurrencyID = dbo.Currencies.CurrencyID
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[Nationality] [nvarchar](50) NOT NULL,
	[PhoneCode] [nvarchar](20) NOT NULL,
	[CurrencyID] [tinyint] NOT NULL,
 CONSTRAINT [PK_Countries1] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ClientsList]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClientsList]
AS
SELECT dbo.Clients.ClientID AS [Client ID], dbo.People.PersonID AS [Person ID], CASE WHEN NOT People.MedName IS NULL 
                  THEN People.FirstName + ' ' + People.MedName + ' ' + People.LastName ELSE People.FirstName + ' ' + People.LastName END AS [Client Full Name], dbo.Countries.Nationality, FORMAT(dbo.OpenNewAccountApplications.OpeningDate, 
                  'dd-MMM-yyyy') AS [Joining Date], dbo.Accounts.AccountNumber AS [Account No], dbo.Currencies.CurrencyName AS [Account Currency], dbo.People.Email, dbo.People.Phone
FROM     dbo.People INNER JOIN
                  dbo.Clients ON dbo.People.PersonID = dbo.Clients.PersonID INNER JOIN
                  dbo.Accounts ON dbo.Clients.ClientID = dbo.Accounts.ClientID INNER JOIN
                  dbo.OpenNewAccountApplications ON dbo.Accounts.AccountNumber = dbo.OpenNewAccountApplications.AccountID INNER JOIN
                  dbo.AccountCurrencies ON dbo.Accounts.AccountCurrency = dbo.AccountCurrencies.AccountCurrencyID INNER JOIN
                  dbo.Currencies ON dbo.AccountCurrencies.CurrencyID = dbo.Currencies.CurrencyID INNER JOIN
                  dbo.Countries ON dbo.People.Nationality = dbo.Countries.CountryID
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](80) NOT NULL,
	[Permissions] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[WithdrawAndDepositOperationsFullData]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WithdrawAndDepositOperationsFullData]
AS
SELECT dbo.WithdrawAndDepositOperations.OperationID, dbo.Users.UserID AS DoneByUserID, dbo.Accounts.AccountNumber, dbo.Clients.ClientID, FORMAT(dbo.ServicesApplications.RequestDate, 'dd-MMM-yyyy') AS TransactionDate, 
                  FORMAT(dbo.ServicesApplications.RequestDate, 'hh:mm:ss tt') AS TransactionTime, dbo.AccountCurrencies.AccountCurrencyID, dbo.Currencies.Currency AS TransactionCurrencyName, 
                  dbo.TransactionTypes.Name AS TransactionType, dbo.WithdrawAndDepositOperations.PreviousBalance AS [Privious Balance], dbo.WithdrawAndDepositOperations.Amount, 
                  dbo.WithdrawAndDepositOperations.OperationFees AS TransactionFee, dbo.WithdrawAndDepositOperations.BalanceAfterTransaction
FROM     dbo.WithdrawAndDepositOperations INNER JOIN
                  dbo.Clients ON dbo.WithdrawAndDepositOperations.ClientID = dbo.Clients.ClientID INNER JOIN
                  dbo.People ON dbo.Clients.PersonID = dbo.People.PersonID INNER JOIN
                  dbo.ServicesApplications ON dbo.Clients.ClientID = dbo.ServicesApplications.ClientID INNER JOIN
                  dbo.Transactions ON dbo.WithdrawAndDepositOperations.TransactionID = dbo.Transactions.TransactionID AND dbo.ServicesApplications.ServiceAppID = dbo.Transactions.ServiceAppID INNER JOIN
                  dbo.TransactionTypes ON dbo.Transactions.TransactionTypeID = dbo.TransactionTypes.TransactionTypeID INNER JOIN
                  dbo.Accounts ON dbo.Clients.ClientID = dbo.Accounts.ClientID INNER JOIN
                  dbo.AccountCurrencies ON dbo.Accounts.AccountCurrency = dbo.AccountCurrencies.AccountCurrencyID INNER JOIN
                  dbo.Currencies ON dbo.AccountCurrencies.CurrencyID = dbo.Currencies.CurrencyID INNER JOIN
                  dbo.Users ON dbo.ServicesApplications.UserID = dbo.Users.UserID
GO
/****** Object:  View [dbo].[PeopleList]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PeopleList]
AS
SELECT dbo.People.PersonID AS ID, dbo.People.NationalNumber AS [National No], dbo.People.FirstName AS [First Name], dbo.People.MedName AS [Med Name], dbo.People.LastName AS [Last Name], 
                  CASE WHEN People.Gendor = 1 THEN 'Male' WHEN People.Gendor = 0 THEN 'Female' ELSE 'Unknown' END AS Gendor, FORMAT(dbo.People.DateOfBirth, 'dd-MMM-yyyy') AS [Date Of Birth], dbo.Countries.Nationality
FROM     dbo.People INNER JOIN
                  dbo.Countries ON dbo.People.Nationality = dbo.Countries.CountryID
GO
/****** Object:  View [dbo].[InternalTransferOperationsFullData]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InternalTransferOperationsFullData]
AS
SELECT dbo.InternalTransferOperations.OperationID, dbo.Users.UserID AS DoneByUserID, dbo.Users.Username AS DoneByUsername, SenderAccount.AccountNumber AS SenderAccountID, 
                  dbo.InternalTransferOperations.TransferFromClientID AS SenderClientID, CASE WHEN NOT SenderPerson.MedName IS NULL 
                  THEN SenderPerson.FirstName + ' ' + SenderPerson.MedName + ' ' + SenderPerson.LastName ELSE SenderPerson.FirstName + ' ' + SenderPerson.LastName END AS SenderClientFullName, dbo.InternalTransferOperations.Amount, 
                  dbo.InternalTransferOperations.Fees, AccountSenderCurrency.AccountCurrencyID AS SenderAccountCurrencyID, SenderCurrency.Currency AS SenderAccountCurrencyName, FORMAT(dbo.ServicesApplications.RequestDate, 
                  'dd-MMM-yyyy') AS TransactionDate, FORMAT(dbo.ServicesApplications.RequestDate, 'hh:mm:ss tt') AS TransactionTime, ReceiverAccount.AccountNumber AS ReceiverAccountID, 
                  dbo.InternalTransferOperations.TransferToClientID AS ReceiverClientID, CASE WHEN NOT ReceiverPerson.MedName IS NULL 
                  THEN ReceiverPerson.FirstName + ' ' + ReceiverPerson.MedName + ' ' + ReceiverPerson.LastName ELSE ReceiverPerson.FirstName + ' ' + ReceiverPerson.LastName END AS ReceiverClientFullName, 
                  dbo.InternalTransferOperations.AmountReceived, AccountReceiverCurrency.AccountCurrencyID AS ReceiverAcountCurrencyID, ReceiverCurrency.Currency AS ReceiverAccountCurrencyName, 
                  dbo.InternalTransferOperations.IsSucceedit
FROM     dbo.InternalTransferOperations INNER JOIN
                  dbo.Clients AS SenderClient ON dbo.InternalTransferOperations.TransferFromClientID = SenderClient.ClientID INNER JOIN
                  dbo.People AS SenderPerson ON SenderClient.PersonID = SenderPerson.PersonID INNER JOIN
                  dbo.Accounts AS SenderAccount ON SenderClient.ClientID = SenderAccount.ClientID INNER JOIN
                  dbo.TransferApplications ON dbo.InternalTransferOperations.TransferID = dbo.TransferApplications.TransferID INNER JOIN
                  dbo.Transactions ON dbo.TransferApplications.TransactionID = dbo.Transactions.TransactionID INNER JOIN
                  dbo.ServicesApplications ON dbo.Transactions.ServiceAppID = dbo.ServicesApplications.ServiceAppID INNER JOIN
                  dbo.AccountCurrencies AS AccountSenderCurrency ON SenderAccount.AccountCurrency = AccountSenderCurrency.AccountCurrencyID INNER JOIN
                  dbo.Currencies AS SenderCurrency ON AccountSenderCurrency.CurrencyID = SenderCurrency.CurrencyID INNER JOIN
                  dbo.Clients AS ReceiverClient ON dbo.InternalTransferOperations.TransferToClientID = ReceiverClient.ClientID INNER JOIN
                  dbo.People AS ReceiverPerson ON ReceiverClient.PersonID = ReceiverPerson.PersonID INNER JOIN
                  dbo.Accounts AS ReceiverAccount ON ReceiverClient.ClientID = ReceiverAccount.ClientID INNER JOIN
                  dbo.AccountCurrencies AS AccountReceiverCurrency ON ReceiverAccount.AccountCurrency = AccountReceiverCurrency.AccountCurrencyID INNER JOIN
                  dbo.Currencies AS ReceiverCurrency ON AccountReceiverCurrency.CurrencyID = ReceiverCurrency.CurrencyID INNER JOIN
                  dbo.Users ON dbo.InternalTransferOperations.DoneByUser = dbo.Users.UserID
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[EmploymentDate] [datetime] NOT NULL,
	[JobPosition] [int] NOT NULL,
	[Salary] [smallmoney] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsersList]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UsersList]
AS
SELECT dbo.Users.UserID AS [User ID], dbo.Employees.EmployeeID AS [Employee ID], CASE WHEN NOT People.MedName IS NULL 
                  THEN People.FirstName + ' ' + People.MedName + ' ' + People.LastName ELSE People.FirstName + ' ' + People.LastName END AS [Full Name], CASE WHEN People.Gendor = 1 THEN 'Male' ELSE 'Female' END AS Gendor, 
                  FORMAT(dbo.Employees.EmploymentDate, 'dd-MMM-yyyy') AS [Employment Date], dbo.Users.Username, dbo.People.Email, dbo.People.Phone, CAST(dbo.Employees.Salary AS nvarchar) + ' $' AS Salary, 
                  CASE WHEN Users.IsActive = 1 THEN 'Active' ELSE 'Deactive' END AS Status
FROM     dbo.Users INNER JOIN
                  dbo.Employees ON dbo.Users.EmployeeID = dbo.Employees.EmployeeID INNER JOIN
                  dbo.People ON dbo.Employees.PersonID = dbo.People.PersonID
GO
/****** Object:  Table [dbo].[BankingJobs]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankingJobs](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
	[SalaryRange] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BankingJobs] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeCurrencies]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeCurrencies](
	[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
	[Currency] [nvarchar](50) NOT NULL,
	[CurrencyValue] [decimal](10, 4) NOT NULL,
 CONSTRAINT [PK_ExchangeCurrencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [tinyint] IDENTITY(1,1) NOT NULL,
	[ServiceTitle] [nvarchar](50) NOT NULL,
	[ServiceDescription] [nvarchar](500) NULL,
	[Fees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_Services_1] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferTypes]    Script Date: 5/14/2025 7:22:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferTypes](
	[TransferTypeID] [tinyint] NOT NULL,
	[TransferName] [nvarchar](20) NOT NULL,
	[TransferDescription] [nvarchar](500) NOT NULL,
	[TransferFees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_TransferTypes] PRIMARY KEY CLUSTERED 
(
	[TransferTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountCurrencies] ON 

INSERT [dbo].[AccountCurrencies] ([AccountCurrencyID], [CurrencyID]) VALUES (1, 138)
INSERT [dbo].[AccountCurrencies] ([AccountCurrencyID], [CurrencyID]) VALUES (2, 49)
INSERT [dbo].[AccountCurrencies] ([AccountCurrencyID], [CurrencyID]) VALUES (5, 23)
SET IDENTITY_INSERT [dbo].[AccountCurrencies] OFF
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountNumber], [ClientID], [Password], [Balance], [AccountCurrency], [IsActive]) VALUES (1, 1, N'f;W;Xt!t1''', 1413.2040, 1, 1)
INSERT [dbo].[Accounts] ([AccountNumber], [ClientID], [Password], [Balance], [AccountCurrency], [IsActive]) VALUES (2, 2, N'LqR.-eu0=<', 1459.9898, 2, 1)
INSERT [dbo].[Accounts] ([AccountNumber], [ClientID], [Password], [Balance], [AccountCurrency], [IsActive]) VALUES (3, 3, N'Ye*qKSLSgt', 2712.3916, 2, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[BankingJobs] ON 

INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (1, N'Accessibility Developer', N'$65K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (2, N'Account Executive', N'$63K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (3, N'Account Manager', N'$58K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (4, N'Account Strategist', N'$59K-$121K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (5, N'Accounting Controller', N'$60K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (6, N'Accounting Manager', N'$59K-$120K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (7, N'Acute Care Nurse Practitioner', N'$58K-$81K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (8, N'Addiction Counselor', N'$65K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (9, N'Administrative Assistant', N'$55K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (10, N'Administrative Coordinator', N'$55K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (11, N'Administrative Manager', N'$57K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (12, N'Adult Speech Therapist', N'$60K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (13, N'Advertising Account Executive', N'$56K-$95K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (14, N'Agile Product Owner', N'$59K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (15, N'Agile Project Manager', N'$64K-$117K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (16, N'Aircraft Design Engineer', N'$56K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (17, N'Analytical Chemist', N'$63K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (18, N'API Developer', N'$63K-$105K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (19, N'Architectural Designer', N'$59K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (20, N'Architectural Drafter', N'$64K-$100K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (21, N'Art Curator', N'$62K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (22, N'Art Education Coordinator', N'$55K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (23, N'Automation Test Engineer', N'$63K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (24, N'Automation Tester', N'$61K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (25, N'Avionics Engineer', N'$56K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (26, N'B2B Sales Consultant', N'$57K-$105K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (27, N'Backend Developer', N'$58K-$86K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (28, N'Backend Web Developer', N'$64K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (29, N'Benefits Coordinator', N'$56K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (30, N'Big Data Engineer', N'$58K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (31, N'Brand Director', N'$56K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (32, N'Brand Manager', N'$56K-$104K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (33, N'Brand Marketing Analyst', N'$58K-$103K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (34, N'Brand PR Specialist', N'$59K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (35, N'Brand Promoter', N'$62K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (36, N'Brand Strategist', N'$65K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (37, N'Bridge Engineer', N'$57K-$83K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (38, N'Budget Analyst', N'$57K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (39, N'Business Development Director', N'$57K-$105K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (40, N'Business Intelligence Analyst', N'$58K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (41, N'Business Systems Analyst', N'$56K-$93K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (42, N'Business Tax Consultant', N'$59K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (43, N'CAD Technician', N'$62K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (44, N'Call Center Agent', N'$62K-$93K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (45, N'Charge Nurse', N'$64K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (46, N'Chemical Engineer', N'$58K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (47, N'Child Custody Lawyer', N'$61K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (48, N'Child Welfare Worker', N'$60K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (49, N'City Planner', N'$57K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (50, N'Classroom Teacher', N'$63K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (51, N'Client Relationship Manager', N'$59K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (52, N'Clinical Nurse Manager', N'$58K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (53, N'Clinical Nurse Specialist', N'$56K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (54, N'Clinical Psychologist', N'$62K-$92K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (55, N'Cloud Architect', N'$65K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (56, N'Cloud Systems Engineer', N'$58K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (57, N'Commercial Interior Designer', N'$58K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (58, N'Commercial Landscape Architect', N'$61K-$104K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (59, N'Community Manager', N'$60K-$92K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (60, N'Competitive Intelligence Analyst', N'$63K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (61, N'Conference Manager', N'$60K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (62, N'Construction Engineer', N'$56K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (63, N'Construction Project Coordinator', N'$57K-$83K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (64, N'Construction Project Manager', N'$58K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (65, N'Content Creator', N'$59K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (66, N'Content Marketing Manager', N'$61K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (67, N'Content SEO Strategist', N'$57K-$93K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (68, N'Content Strategist', N'$56K-$99K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (69, N'Content Writer', N'$62K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (70, N'Controls Engineer', N'$59K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (71, N'Copywriter', N'$61K-$126K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (72, N'Corporate Attorney', N'$58K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (73, N'Corporate Counsel', N'$65K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (74, N'Corporate Event Coordinator', N'$60K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (75, N'Corporate Event Planner', N'$62K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (76, N'Corporate Litigator', N'$63K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (77, N'Corporate Paralegal', N'$63K-$81K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (78, N'Court Clerk', N'$56K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (79, N'Creative Copywriter', N'$61K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (80, N'Creative Director', N'$60K-$81K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (81, N'Crisis Communication Manager', N'$58K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (82, N'Customer Experience Strategist', N'$59K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (83, N'Customer Success Manager', N'$57K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (84, N'Customer Support Manager', N'$59K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (85, N'Customer Support Specialist', N'$55K-$95K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (86, N'Cybersecurity Analyst', N'$61K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (87, N'Data Analyst', N'$60K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (88, N'Data Analyst Researcher', N'$61K-$98K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (89, N'Data Architect', N'$59K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (90, N'Data Business Analyst', N'$64K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (91, N'Data Engineer', N'$61K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (92, N'Data Entry Specialist', N'$62K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (93, N'Data Quality Analyst', N'$56K-$92K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (94, N'Data Scientist', N'$58K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (95, N'Database Administrator', N'$55K-$121K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (96, N'Database Analyst', N'$57K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (97, N'Database Developer', N'$63K-$83K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (98, N'Database Security Specialist', N'$60K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (99, N'Deliverability Analyst', N'$63K-$127K')
GO
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (100, N'Demand Planner', N'$58K-$103K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (101, N'Dental Hygiene Educator', N'$65K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (102, N'Dental Public Health Hygienist', N'$56K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (103, N'Design Engineer', N'$59K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (104, N'Desktop Support Technician', N'$58K-$111K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (105, N'DevOps Engineer', N'$64K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (106, N'Digital Marketing Analyst', N'$65K-$120K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (107, N'Digital Marketing Coordinator', N'$57K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (108, N'Digital Marketing Director', N'$64K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (109, N'Digital Marketing Manager', N'$64K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (110, N'Digital Marketing Specialist', N'$56K-$126K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (111, N'Documentation Specialist', N'$62K-$117K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (112, N'E-commerce Web Designer', N'$61K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (113, N'Electrical Engineer', N'$58K-$99K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (114, N'Electronics Hardware Engineer', N'$58K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (115, N'Email Campaign Manager', N'$59K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (116, N'Email Marketing Specialist', N'$55K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (117, N'Emergency Medicine Physician Assistant', N'$55K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (118, N'Employee Development Manager', N'$63K-$114K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (119, N'Employee Relations Specialist', N'$65K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (120, N'Employment Lawyer', N'$60K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (121, N'Enterprise Architect', N'$58K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (122, N'Environmental Compliance Officer', N'$56K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (123, N'Environmental Consultant', N'$63K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (124, N'Environmental Designer', N'$56K-$88K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (125, N'Environmental Impact Analyst', N'$64K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (126, N'Environmental Planner', N'$59K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (127, N'Equine Veterinarian', N'$59K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (128, N'ETL Developer', N'$59K-$120K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (129, N'Event Coordinator', N'$65K-$85K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (130, N'Event Marketing Coordinator', N'$57K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (131, N'Event Planner', N'$63K-$93K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (132, N'Executive Assistant', N'$58K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (133, N'Exotic Animal Veterinarian', N'$60K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (134, N'Facilities Manager', N'$61K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (135, N'Family Counselor', N'$62K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (136, N'Family Law Attorney', N'$58K-$98K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (137, N'Family Nurse Practitioner', N'$64K-$126K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (138, N'Finance Manager', N'$55K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (139, N'Financial Accountant', N'$59K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (140, N'Financial Analyst', N'$57K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (141, N'Financial Planner', N'$57K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (142, N'Financial Planning Manager', N'$62K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (143, N'Fine Arts Instructor', N'$65K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (144, N'Forensic Accountant', N'$55K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (145, N'Frontend Developer', N'$58K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (146, N'Front-End Developer', N'$65K-$92K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (147, N'Frontend Web Designer', N'$55K-$100K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (148, N'Frontend Web Developer', N'$57K-$85K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (149, N'Full-Stack Developer', N'$56K-$95K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (150, N'General Pediatrician', N'$57K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (151, N'Geriatric Nurse Practitioner', N'$62K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (152, N'Geriatric Occupational Therapist', N'$56K-$88K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (153, N'Geriatric Physical Therapist', N'$64K-$90K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (154, N'Healthcare Business Analyst', N'$59K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (155, N'Help Desk Analyst', N'$56K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (156, N'Help Desk Support Specialist', N'$62K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (157, N'Hospitality Interior Designer', N'$63K-$98K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (158, N'HR Compliance Specialist', N'$55K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (159, N'HR Coordinator', N'$64K-$121K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (160, N'HR Generalist', N'$62K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (161, N'Human Resources Director', N'$59K-$88K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (162, N'HVAC Engineer', N'$56K-$102K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (163, N'HVAC Systems Designer', N'$57K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (164, N'Industrial Designer', N'$65K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (165, N'Industrial Engineer', N'$56K-$111K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (166, N'Infrastructure Manager', N'$65K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (167, N'In-House Counsel', N'$65K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (168, N'Inside Sales Representative', N'$60K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (169, N'Instructional Designer', N'$62K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (170, N'Intellectual Property Lawyer', N'$65K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (171, N'Interaction Designer', N'$57K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (172, N'Interior Designer', N'$59K-$95K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (173, N'International Tax Consultant', N'$58K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (174, N'Inventory Control Specialist', N'$65K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (175, N'Inventory Manager', N'$63K-$85K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (176, N'Investment Advisor', N'$64K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (177, N'Investment Analyst', N'$64K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (178, N'Investment Portfolio Manager', N'$57K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (179, N'IT Analyst', N'$57K-$98K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (180, N'IT Business Analyst', N'$57K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (181, N'IT Director', N'$63K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (182, N'IT Project Manager', N'$59K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (183, N'IT Support Specialist', N'$60K-$121K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (184, N'IT Systems Administrator', N'$63K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (185, N'Java Backend Developer', N'$64K-$111K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (186, N'Java Software Engineer', N'$61K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (187, N'Java Web Application Developer', N'$60K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (188, N'JavaScript Developer', N'$62K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (189, N'Key Account Executive', N'$55K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (190, N'Key Account Manager', N'$63K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (191, N'Legal Assistant', N'$60K-$88K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (192, N'Legal Counsel', N'$64K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (193, N'Legal Secretary', N'$60K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (194, N'Lighting Designer', N'$65K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (195, N'Litigation Paralegal', N'$65K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (196, N'Litigation Support Specialist', N'$61K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (197, N'Live Chat Support Agent', N'$62K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (198, N'Logistics Analyst', N'$58K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (199, N'Logistics Manager', N'$63K-$107K')
GO
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (200, N'Machine Learning Engineer', N'$65K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (201, N'Manufacturing Engineer', N'$57K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (202, N'Market Expansion Manager', N'$61K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (203, N'Market Research Analyst', N'$58K-$126K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (204, N'Market Research Coordinator', N'$56K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (205, N'Market Researcher', N'$57K-$108K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (206, N'Marketing Analytics Specialist', N'$62K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (207, N'Marketing Automation Specialist', N'$58K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (208, N'Marketing Communications Director', N'$59K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (209, N'Marketing Specialist', N'$64K-$111K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (210, N'Mechanical Design Engineer', N'$60K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (211, N'Media Relations Specialist', N'$60K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (212, N'Mediator', N'$55K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (213, N'Medical Sales Specialist', N'$63K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (214, N'Mental Health Counselor', N'$55K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (215, N'Mental Health Occupational Therapist', N'$55K-$108K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (216, N'Mergers and Acquisitions Advisor', N'$61K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (217, N'Mobile App Developer', N'$62K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (218, N'Network Administrator', N'$62K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (219, N'Network Engineer', N'$55K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (220, N'Network Performance Analyst', N'$61K-$103K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (221, N'Network Security Analyst', N'$60K-$105K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (222, N'Network Security Engineer', N'$59K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (223, N'Network Security Specialist', N'$63K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (224, N'Network Support Specialist', N'$62K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (225, N'NoSQL Database Engineer', N'$61K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (226, N'Nurse Educator', N'$59K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (227, N'Nursing Director', N'$55K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (228, N'Office Coordinator', N'$63K-$88K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (229, N'Office Manager', N'$60K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (230, N'Onboarding Specialist', N'$59K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (231, N'Operations Director', N'$64K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (232, N'Orthopedic Physical Therapist', N'$59K-$90K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (233, N'Outside Sales Representative', N'$61K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (234, N'Paid Advertising Specialist', N'$55K-$100K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (235, N'Paralegal', N'$63K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (236, N'PCB Designer', N'$57K-$95K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (237, N'Pediatric Nurse Practitioner', N'$64K-$121K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (238, N'Pediatric Occupational Therapist', N'$59K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (239, N'Pediatric Physical Therapist', N'$55K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (240, N'Pediatric Specialist', N'$64K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (241, N'Pediatric Speech Therapist', N'$61K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (242, N'Pediatric Surgeon', N'$61K-$86K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (243, N'Performance Tester', N'$61K-$92K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (244, N'Performance Testing Specialist', N'$58K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (245, N'Periodontal Therapist', N'$61K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (246, N'Personal Assistant', N'$58K-$126K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (247, N'Personal Secretary', N'$63K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (248, N'Personal Tax Consultant', N'$55K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (249, N'Portfolio Manager', N'$64K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (250, N'Power Systems Engineer', N'$60K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (251, N'Primary Care Nurse Practitioner', N'$61K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (252, N'Primary Care Physician Assistant', N'$60K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (253, N'Primary Care Provider', N'$59K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (254, N'Print Graphic Designer', N'$57K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (255, N'Process Engineer', N'$60K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (256, N'Procurement Analyst', N'$55K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (257, N'Procurement Coordinator', N'$62K-$92K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (258, N'Procurement Manager', N'$57K-$100K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (259, N'Procurement Specialist', N'$58K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (260, N'Product Brand Manager', N'$65K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (261, N'Product Demonstrator', N'$55K-$117K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (262, N'Product Designer', N'$57K-$93K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (263, N'Product Marketing Manager', N'$63K-$111K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (264, N'Project Architect', N'$55K-$122K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (265, N'Project Coordinator', N'$64K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (266, N'Project Manager', N'$62K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (267, N'Purchasing Coordinator', N'$62K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (268, N'QA Manager', N'$62K-$83K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (269, N'QA Tester', N'$58K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (270, N'Quality Assurance Analyst', N'$64K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (271, N'Quality Assurance Manager', N'$64K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (272, N'Quality Control Analyst', N'$61K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (273, N'Quality Control Engineer', N'$63K-$103K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (274, N'Quality Control Manager', N'$59K-$121K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (275, N'Real Estate Paralegal', N'$55K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (276, N'Record Keeper', N'$57K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (277, N'Recovery Coach', N'$64K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (278, N'Recruitment Coordinator', N'$60K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (279, N'Regional Sales Director', N'$59K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (280, N'Research Analyst', N'$59K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (281, N'Research and Development (R&D) Engineer', N'$64K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (282, N'Research Chemist', N'$57K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (283, N'Research Psychologist', N'$59K-$81K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (284, N'Residential Interior Designer', N'$55K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (285, N'Residential Landscape Designer', N'$65K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (286, N'Retail Sales Associate', N'$55K-$120K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (287, N'Retirement Planner', N'$59K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (288, N'Risk Analyst', N'$63K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (289, N'Sales Account Executive', N'$58K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (290, N'Sales Account Manager', N'$62K-$99K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (291, N'Sales Advisor', N'$56K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (292, N'Sales Manager', N'$57K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (293, N'Sales Representative', N'$59K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (294, N'Sales Team Leader', N'$58K-$119K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (295, N'Sales Trainer', N'$57K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (296, N'School Psychologist', N'$57K-$108K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (297, N'School Social Worker', N'$56K-$120K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (298, N'Search Engine Marketer', N'$56K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (299, N'Security Consultant', N'$62K-$129K')
GO
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (300, N'Security Operations Center (SOC) Analyst', N'$55K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (301, N'SEM Analyst', N'$56K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (302, N'Senior Researcher', N'$59K-$86K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (303, N'SEO Analyst', N'$61K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (304, N'SEO Content Strategist', N'$57K-$99K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (305, N'SEO Copywriter', N'$63K-$112K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (306, N'SEO Specialist', N'$55K-$102K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (307, N'Server Developer', N'$61K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (308, N'Service Quality Assurance Manager', N'$56K-$111K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (309, N'Small Animal Veterinarian', N'$58K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (310, N'Social Media Analyst', N'$59K-$117K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (311, N'Social Media Influencer', N'$60K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (312, N'Social Media Manager', N'$55K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (313, N'Social Media Strategist', N'$63K-$104K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (314, N'Social Science Researcher', N'$61K-$86K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (315, N'Software QA Tester', N'$64K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (316, N'Solution Architect', N'$55K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (317, N'Sourcing Analyst', N'$64K-$117K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (318, N'Special Education Teacher', N'$55K-$116K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (319, N'Speech Pathologist', N'$58K-$115K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (320, N'SQL Database Developer', N'$61K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (321, N'Staff Nurse', N'$62K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (322, N'Strategic Account Manager', N'$61K-$95K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (323, N'Strategic Partnerships Manager', N'$55K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (324, N'Strategic Sourcing Manager', N'$58K-$130K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (325, N'Structural Engineer', N'$65K-$127K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (326, N'Studio Art Teacher', N'$59K-$128K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (327, N'Subject Matter Expert', N'$63K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (328, N'Supplier Diversity Manager', N'$58K-$83K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (329, N'Supply Chain Coordinator', N'$62K-$123K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (330, N'Supply Chain Manager', N'$59K-$80K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (331, N'Surgical Physician Assistant', N'$57K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (332, N'Sustainability Consultant', N'$64K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (333, N'Sustainability Specialist', N'$58K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (334, N'Sustainable Design Specialist', N'$62K-$129K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (335, N'Sustainable Landscape Specialist', N'$64K-$110K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (336, N'System Administrator', N'$55K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (337, N'System User', N'$58K-$81K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (338, N'Systems Administrator', N'$61K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (339, N'Systems Engineer', N'$60K-$104K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (340, N'Systems Integration Specialist', N'$63K-$107K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (341, N'Talent Acquisition Manager', N'$58K-$81K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (342, N'Tax Accountant', N'$62K-$86K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (343, N'Tax Planner', N'$60K-$120K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (344, N'Technical Copywriter', N'$65K-$104K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (345, N'Technical Product Manager', N'$63K-$82K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (346, N'Technical SEO Analyst', N'$59K-$96K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (347, N'Technical SEO Specialist', N'$59K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (348, N'Technical Support Specialist', N'$57K-$91K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (349, N'Technical Writer', N'$55K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (350, N'Territory Sales Manager', N'$61K-$86K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (351, N'Test Automation Engineer', N'$56K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (352, N'Training Coordinator', N'$61K-$118K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (353, N'Transportation Engineer', N'$58K-$99K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (354, N'Transportation Planner', N'$59K-$88K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (355, N'Treasury Manager', N'$57K-$87K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (356, N'Trial Attorney', N'$65K-$89K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (357, N'UI/UX Designer', N'$65K-$94K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (358, N'UI/UX Developer', N'$65K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (359, N'UI/UX Front-End Developer', N'$57K-$98K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (360, N'Urban Planner', N'$57K-$106K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (361, N'Usability Analyst', N'$60K-$104K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (362, N'UX Strategist', N'$59K-$93K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (363, N'UX/UI Designer', N'$59K-$126K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (364, N'Visual Designer', N'$64K-$109K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (365, N'Water Resources Engineer', N'$65K-$97K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (366, N'Wealth Advisor', N'$64K-$108K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (367, N'Wealth Management Advisor', N'$64K-$101K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (368, N'Web Designer', N'$62K-$125K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (369, N'Web Graphic Designer', N'$61K-$124K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (370, N'Wedding Consultant', N'$56K-$83K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (371, N'Wedding Coordinator', N'$63K-$84K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (372, N'Wedding Designer', N'$63K-$113K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (373, N'Wedding Planner', N'$57K-$105K')
INSERT [dbo].[BankingJobs] ([JobID], [JobTitle], [SalaryRange]) VALUES (374, N'Wireless Network Engineer', N'$63K-$82K')
SET IDENTITY_INSERT [dbo].[BankingJobs] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientID], [PersonID]) VALUES (1, 2)
INSERT [dbo].[Clients] ([ClientID], [PersonID]) VALUES (2, 3)
INSERT [dbo].[Clients] ([ClientID], [PersonID]) VALUES (3, 4)
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (1, N'Afghanistan', N'Afghan', N'93', 1)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (2, N'Aland Islands', N'Aland Island', N'358', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (3, N'Albania', N'Albanian ', N'355', 2)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (4, N'Algeria', N'Algerian', N'213', 3)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (5, N'American Samoa', N'American Samoan', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (6, N'Andorra', N'Andorran', N'376', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (7, N'Angola', N'Angolan', N'244', 4)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (8, N'Antigua and Barbuda', N'Antiguan or Barbudan', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (9, N'Argentina', N'Argentine', N'54', 5)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (10, N'Armenia', N'Armenian', N'374', 6)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (11, N'Aruba', N'Aruban', N'297', 7)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (12, N'Australia', N'Australian', N'61', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (13, N'Austria', N'Austrian', N'43', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (14, N'Azerbaijan', N'Azerbaijani, Azeri', N'994', 9)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (15, N'Bahrain', N'Bahraini', N'973', 11)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (16, N'Bangladesh', N'Bangladeshi', N'880', 12)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (17, N'Barbados', N'Barbadian', N'1', 13)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (18, N'Belarus', N'Belarusian', N'375', 14)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (19, N'Belgium', N'Belgian', N'32', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (20, N'Belize', N'Belizean', N'501', 15)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (21, N'Benin', N'Beninese, Beninois', N'229', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (22, N'Bermuda', N'Bermudian, Bermudan', N'1', 16)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (23, N'Bhutan', N'Bhutanese', N'975', 17)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (24, N'Bolivia', N'Bolivian', N'591', 19)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (25, N'Bonaire, Sint Eustatius and Saba', N'Bonaire', N'599', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (26, N'Bosnia and Herzegovina', N'Bosnian or Herzegovinian', N'387', 20)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (27, N'Botswana', N'Motswana, Botswanan', N'267', 21)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (28, N'Brazil', N'Brazilian', N'55', 22)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (29, N'British Indian Ocean Territory', N'BIOT', N'246', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (30, N'Bulgaria', N'Bulgarian', N'359', 24)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (31, N'Burkina Faso', N'Burkinabe', N'226', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (32, N'Burundi', N'Burundian', N'257', 26)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (33, N'Cambodia', N'Cambodian', N'855', 27)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (34, N'Cameroon', N'Cameroonian', N'237', 32)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (35, N'Canada', N'Canadian', N'1', 28)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (36, N'Cape Verde', N'Verdean', N'238', 29)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (37, N'Cayman Islands', N'Caymanian', N'1', 30)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (38, N'Central African Republic', N'Central African', N'236', 32)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (39, N'Chad', N'Chadian', N'235', 32)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (40, N'Chile', N'Chilean', N'56', 34)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (41, N'China', N'Chinese', N'86', 35)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (42, N'Christmas Island', N'Christmas Island', N'61', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (43, N'Cocos (Keeling) Islands', N'Cocos Island', N'61', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (44, N'Colombia', N'Colombian', N'57', 36)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (45, N'Comoros', N'Comoran, Comorian', N'269', 37)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (46, N'Congo', N'Congolese', N'242', 31)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (47, N'Costa Rica', N'Costa Rican', N'506', 38)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (48, N'Cote D''Ivoire (Ivory Coast)', N'Ivorian', N'225', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (49, N'Croatia', N'Croatian', N'385', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (50, N'Curaçao', N'Curacaoan', N'599', 94)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (51, N'Cyprus', N'Cypriot', N'357', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (52, N'Czech Republic', N'Czech', N'420', 39)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (53, N'Denmark', N'Danish', N'45', 40)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (54, N'Djibouti', N'Djiboutian', N'253', 42)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (55, N'Dominica', N'Dominican', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (56, N'Dominican Republic', N'Dominican', N'1', 44)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (57, N'Ecuador', N'Ecuadorian', N'593', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (58, N'Egypt', N'Egyptian', N'20', 46)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (59, N'El Salvador', N'Salvadoran', N'503', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (60, N'Equatorial Guinea', N'Equatorial Guinean, Equatoguinean', N'240', 32)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (61, N'Eritrea', N'Eritrean', N'291', 47)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (62, N'Estonia', N'Estonian', N'372', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (63, N'Eswatini', N'Swazi', N'268', 79)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (64, N'Ethiopia', N'Ethiopian', N'251', 48)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (65, N'Faroe Islands', N'Faroese', N'298', 40)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (66, N'Fiji Islands', N'Fijian', N'679', 50)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (67, N'Finland', N'Finnish', N'358', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (68, N'France', N'French', N'33', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (69, N'French Guiana', N'French Guianese', N'594', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (70, N'French Polynesia', N'French Polynesia', N'689', 33)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (71, N'French Southern Territories', N'French Southern Territories', N'262', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (72, N'Gabon', N'Gabonese', N'241', 32)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (73, N'Georgia', N'Georgian', N'995', 52)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (74, N'Germany', N'German', N'49', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (75, N'Ghana', N'Ghanaian', N'233', 53)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (76, N'Gibraltar', N'Gibraltar', N'350', 54)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (77, N'Greece', N'Greek, Hellenic', N'30', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (78, N'Greenland', N'Greenlandic', N'299', 40)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (79, N'Grenada', N'Grenadian', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (80, N'Guadeloupe', N'Guadeloupe', N'590', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (81, N'Guam', N'Guamanian, Guambat', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (82, N'Guatemala', N'Guatemalan', N'502', 55)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (83, N'Guernsey and Alderney', N'Channel Island', N'44', 23)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (84, N'Guinea', N'Guinean', N'224', 56)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (85, N'Guinea-Bissau', N'Bissau-Guinean', N'245', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (86, N'Guyana', N'Guyanese', N'592', 57)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (87, N'Haiti', N'Haitian', N'509', 58)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (88, N'Heard Island and McDonald Islands', N'Heard Island or McDonald Islands', N'672', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (89, N'Honduras', N'Honduran', N'504', 59)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (90, N'Hong Kong S.A.R.', N'Hong Kong, Hong Kongese', N'852', 60)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (91, N'Hungary', N'Hungarian, Magyar', N'36', 61)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (92, N'Iceland', N'Icelandic', N'354', 62)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (93, N'India', N'Indian', N'91', 63)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (94, N'Indonesia', N'Indonesian', N'62', 64)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (95, N'Iran', N'Iranian, Persian', N'98', 65)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (96, N'Iraq', N'Iraqi', N'964', 66)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (97, N'Ireland', N'Irish', N'353', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (98, N'Italy', N'Italian', N'39', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (99, N'Jamaica', N'Jamaican', N'1', 67)
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (100, N'Japan', N'Japanese', N'81', 68)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (101, N'Jersey', N'Channel Island', N'44', 23)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (102, N'Jordan', N'Jordanian', N'962', 69)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (103, N'Kazakhstan', N'Kazakhstani, Kazakh', N'7', 70)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (104, N'Kenya', N'Kenyan', N'254', 71)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (105, N'Kiribati', N'I-Kiribati', N'686', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (106, N'Kosovo', N'Kosovar, Kosovan', N'383', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (107, N'Kuwait', N'Kuwaiti', N'965', 72)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (108, N'Kyrgyzstan', N'Kyrgyzstani, Kyrgyz, Kirgiz, Kirghiz', N'996', 73)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (109, N'Laos', N'Lao, Laotian', N'856', 74)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (110, N'Latvia', N'Latvian', N'371', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (111, N'Lebanon', N'Lebanese', N'961', 75)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (112, N'Lesotho', N'Basotho', N'266', 76)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (113, N'Liberia', N'Liberian', N'231', 77)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (114, N'Libya', N'Libyan', N'218', 78)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (115, N'Liechtenstein', N'Liechtenstein', N'423', 124)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (116, N'Lithuania', N'Lithuanian', N'370', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (117, N'Luxembourg', N'Luxembourg, Luxembourgish', N'352', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (118, N'Macau S.A.R.', N'Macanese, Chinese', N'853', 80)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (119, N'Madagascar', N'Malagasy', N'261', 81)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (120, N'Malawi', N'Malawian', N'265', 82)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (121, N'Malaysia', N'Malaysian', N'60', 83)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (122, N'Maldives', N'Maldivian', N'960', 84)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (123, N'Mali', N'Malian, Malinese', N'223', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (124, N'Malta', N'Maltese', N'356', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (125, N'Man (Isle of)', N'Manx', N'44', 23)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (126, N'Marshall Islands', N'Marshallese', N'692', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (127, N'Martinique', N'Martiniquais, Martinican', N'596', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (128, N'Mauritania', N'Mauritanian', N'222', 85)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (129, N'Mauritius', N'Mauritian', N'230', 86)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (130, N'Mayotte', N'Mahoran', N'262', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (131, N'Mexico', N'Mexican', N'52', 87)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (132, N'Micronesia', N'Micronesian', N'691', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (133, N'Moldova', N'Moldovan', N'373', 88)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (134, N'Monaco', N'Monegasque, Monacan', N'377', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (135, N'Mongolia', N'Mongolian', N'976', 89)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (136, N'Montenegro', N'Montenegrin', N'382', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (137, N'Montserrat', N'Montserratian', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (138, N'Morocco', N'Moroccan', N'212', 90)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (139, N'Mozambique', N'Mozambican', N'258', 91)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (140, N'Myanmar', N'Burmese', N'95', 25)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (141, N'Namibia', N'Namibian', N'264', 92)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (142, N'Nauru', N'Nauruan', N'674', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (143, N'Nepal', N'Nepali, Nepalese', N'977', 93)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (144, N'Netherlands', N'Dutch, Netherlandic', N'31', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (145, N'New Caledonia', N'New Caledonian', N'687', 33)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (146, N'New Zealand', N'New Zealand, NZ', N'64', 96)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (147, N'Nicaragua', N'Nicaraguan', N'505', 97)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (148, N'Niger', N'Nigerien', N'227', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (149, N'Nigeria', N'Nigerian', N'234', 98)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (150, N'Niue', N'Niuean', N'683', 96)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (151, N'Norfolk Island', N'Norfolk Island', N'672', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (152, N'North Macedonia', N'Macedonian', N'389', 41)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (153, N'Northern Mariana Islands', N'Northern Marianan', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (154, N'Oman', N'Omani', N'968', 99)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (155, N'Pakistan', N'Pakistani', N'92', 100)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (156, N'Palau', N'Palauan', N'680', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (157, N'Palestinian Territory Occupied', N'Palestinian', N'970', 3)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (158, N'Panama', N'Panamanian', N'507', 101)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (159, N'Papua New Guinea', N'Papua New Guinean, Papuan', N'675', 102)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (160, N'Paraguay', N'Paraguayan', N'595', 103)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (161, N'Peru', N'Peruvian', N'51', 104)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (162, N'Philippines', N'Philippine, Filipino', N'63', 105)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (163, N'Pitcairn Island', N'Pitcairn Island', N'870', 96)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (164, N'Poland', N'Polish', N'48', 106)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (165, N'Portugal', N'Portuguese', N'351', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (166, N'Puerto Rico', N'Puerto Rican', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (167, N'Qatar', N'Qatari', N'974', 107)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (168, N'Reunion', N'Reunionese, Reunionnais', N'262', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (169, N'Romania', N'Romanian', N'40', 108)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (170, N'Russia', N'Russian', N'7', 109)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (171, N'Rwanda', N'Rwandan', N'250', 110)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (172, N'Saint Kitts and Nevis', N'Kittitian or Nevisian', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (173, N'Saint Lucia', N'Saint Lucian', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (174, N'Saint Pierre and Miquelon', N'Saint-Pierrais or Miquelonnais', N'508', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (175, N'Saint Vincent and the Grenadines', N'Saint Vincentian, Vincentian', N'1', 45)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (176, N'Saint-Barthelemy', N'Barthelemois', N'590', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (177, N'Saint-Martin (French part)', N'Saint-Martinoise', N'590', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (178, N'Samoa', N'Samoan', N'685', 111)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (179, N'San Marino', N'Sammarinese', N'378', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (180, N'Sao Tome and Principe', N'Sao Tomean', N'239', 43)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (181, N'Saudi Arabia', N'Saudi, Saudi Arabian', N'966', 112)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (182, N'Senegal', N'Senegalese', N'221', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (183, N'Serbia', N'Serbian', N'381', 113)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (184, N'Seychelles', N'Seychellois', N'248', 114)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (185, N'Sierra Leone', N'Sierra Leonean', N'232', 115)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (186, N'Singapore', N'Singaporean', N'65', 116)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (187, N'Sint Maarten (Dutch part)', N'Sint Maarten', N'1721', 94)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (188, N'Slovakia', N'Slovak', N'421', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (189, N'Slovenia', N'Slovenian, Slovene', N'386', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (190, N'Solomon Islands', N'Solomon Island', N'677', 117)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (191, N'South Africa', N'South African', N'27', 118)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (192, N'South Georgia', N'South Georgia or South Sandwich Islands', N'500', 23)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (193, N'South Korea', N'South Korean', N'82', 143)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (194, N'South Sudan', N'South Sudanese', N'211', 119)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (195, N'Spain', N'Spanish', N'34', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (196, N'Sri Lanka', N'Sri Lankan', N'94', 120)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (197, N'Sudan', N'Sudanese', N'249', 121)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (198, N'Suriname', N'Surinamese', N'597', 122)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (199, N'Sweden', N'Swedish', N'46', 123)
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (200, N'Switzerland', N'Swiss', N'41', 124)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (201, N'Syria', N'Syrian', N'963', 125)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (202, N'Taiwan', N'Chinese, Taiwanese', N'886', 95)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (203, N'Tajikistan', N'Tajikistani', N'992', 126)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (204, N'Tanzania', N'Tanzanian', N'255', 127)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (205, N'Thailand', N'Thai', N'66', 128)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (206, N'The Bahamas', N'Bahamian', N'1', 10)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (207, N'The Gambia ', N'Gambian', N'220', 51)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (208, N'Timor-Leste', N'Timorese', N'670', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (209, N'Togo', N'Togolese', N'228', 142)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (210, N'Tokelau', N'Tokelauan', N'690', 96)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (211, N'Tonga', N'Tongan', N'676', 129)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (212, N'Trinidad and Tobago', N'Trinidadian or Tobagonian', N'1', 130)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (213, N'Tunisia', N'Tunisian', N'216', 131)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (214, N'Turkey', N'Turkish', N'90', 132)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (215, N'Turkmenistan', N'Turkmen', N'993', 133)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (216, N'Turks and Caicos Islands', N'Turks and Caicos Island', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (217, N'Tuvalu', N'Tuvaluan', N'688', 8)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (218, N'Uganda', N'Ugandan', N'256', 134)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (219, N'Ukraine', N'Ukrainian', N'380', 135)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (220, N'United Arab Emirates', N'Emirati, Emirian, Emiri', N'971', 136)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (221, N'United Kingdom', N'British, UK', N'44', 23)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (222, N'United States', N'American', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (223, N'United States Minor Outlying Islands', N'American', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (224, N'Uruguay', N'Uruguayan', N'598', 137)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (225, N'Uzbekistan', N'Uzbekistani, Uzbek', N'998', 139)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (226, N'Vanuatu', N'Ni-Vanuatu, Vanuatuan', N'678', 140)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (227, N'Vatican City State (Holy See)', N'Vatican', N'379', 49)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (228, N'Venezuela', N'Venezuelan', N'58', 18)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (229, N'Vietnam', N'Vietnamese', N'84', 141)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (230, N'Virgin Islands (British)', N'British Virgin Island', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (231, N'Virgin Islands (US)', N'U.S. Virgin Island', N'1', 138)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (232, N'Wallis and Futuna Islands', N'Wallis and Futuna, Wallisian or Futunan', N'681', 33)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (233, N'Western Sahara', N'Sahrawi, Sahrawian, Sahraouian', N'212', 90)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (234, N'Yemen', N'Yemeni', N'967', 144)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (235, N'Zambia', N'Zambian', N'260', 145)
INSERT [dbo].[Countries] ([CountryID], [CountryName], [Nationality], [PhoneCode], [CurrencyID]) VALUES (236, N'Zimbabwe', N'Zimbabwean', N'263', 146)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (1, N'Afghan afghani', N'AFN', N'؋', 0.014002680112973622)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (2, N'Albanian lek', N'ALL', N'Lek', 0.011)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (3, N'Algerian dinar', N'DZD', N'دج', 0.0075)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (4, N'Angolan kwanza', N'AOA', N'Kz', 0.0011)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (5, N'Argentine peso', N'ARS', N'$', 0.0009)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (6, N'Armenian dram', N'AMD', N'֏', 0.0026)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (7, N'Aruban florin', N'AWG', N'ƒ', 0.5587)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (8, N'Australian dollar', N'AUD', N'$', 0.6338)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (9, N'Azerbaijani manat', N'AZN', N'm', 0.5883)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (10, N'Bahamian dollar', N'BSD', N'B$', 1)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (11, N'Bahraini dinar', N'BHD', N'.د.ب', 2.6596)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (12, N'Bangladeshi taka', N'BDT', N'৳', 0.0082)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (13, N'Barbadian dollar', N'BBD', N'Bds$', 0.5)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (14, N'Belarusian ruble', N'BYN', N'Br', 0.3186)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (15, N'Belize dollar', N'BZD', N'$', 0.5)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (16, N'Bermudian dollar', N'BMD', N'$', 1)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (17, N'Bhutanese ngultrum', N'BTN', N'Nu.', 0.0117)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (18, N'Bolívar', N'VES', N'Bs', 0.0142)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (19, N'Bolivian boliviano', N'BOB', N'Bs.', 0.1452)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (20, N'Bosnia and Herzegovina convertible mark', N'BAM', N'KM', 0.5652)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (21, N'Botswana pula', N'BWP', N'P', 0.0724)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (22, N'Brazilian real', N'BRL', N'R$', 0.1777)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (23, N'British pound', N'GBP', N'£', 1.311)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (24, N'Bulgarian lev', N'BGN', N'Лв.', 0.5655)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (25, N'Burmese kyat', N'MMK', N'K', 0.0005)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (26, N'Burundian franc', N'BIF', N'FBu', 0.0003)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (27, N'Cambodian riel', N'KHR', N'KHR', 0.0003)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (28, N'Canadian dollar', N'CAD', N'C$', 0.7099)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (29, N'Cape Verdean escudo', N'CVE', N'$', 0.01)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (30, N'Cayman Islands dollar', N'KYD', N'$', 1.2)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (31, N'Central African CFA franc', N'XAF', N'FC', 0.0017)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (32, N'Central African CFA franc', N'XAF', N'FCFA', 0.0017)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (33, N'CFP franc', N'XPF', N'₣', 0.0093)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (34, N'Chilean peso', N'CLP', N'$', 0.001)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (35, N'Chinese yuan', N'CNY', N'¥', 0.1372)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (36, N'Colombian peso', N'COP', N'$', 0.0002)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (37, N'Comorian franc', N'KMF', N'CF', 0.0022)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (38, N'Costa Rican colón', N'CRC', N'₡', 0.002)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (39, N'Czech koruna', N'CZK', N'Kč', 0.0442)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (40, N'Danish krone', N'DKK', N'Kr.', 0.1481)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (41, N'Denar', N'MKD', N'ден', 0.0175)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (42, N'Djiboutian franc', N'DJF', N'Fdj', 0.0056)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (43, N'Dobra', N'STD', N'Db', 0.0441)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (44, N'Dominican peso', N'DOP', N'$', 0.0159)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (45, N'Eastern Caribbean dollar', N'XCD', N'$', 0.3704)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (46, N'Egyptian pound', N'EGP', N'ج.م', 0.0198)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (47, N'Eritrean nakfa', N'ERN', N'Nfk', 0.0667)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (48, N'Ethiopian birr', N'ETB', N'Nkf', 0.0076)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (49, N'Euro', N'EUR', N'€', 1.1051)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (50, N'Fijian dollar', N'FJD', N'FJ$', 0.4294)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (51, N'Gambian dalasi', N'GMD', N'D', 0.0138)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (52, N'Georgian lari', N'GEL', N'ლ', 0.3623)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (53, N'Ghanaian cedi', N'GHS', N'GH₵', 0.0644)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (54, N'Gibraltar pound', N'GIP', N'£', 1.311)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (55, N'Guatemalan quetzal', N'GTQ', N'Q', 0.13)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (56, N'Guinean franc', N'GNF', N'FG', 0.0001)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (57, N'Guyanese dollar', N'GYD', N'$', 0.0048)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (58, N'Haitian gourde', N'HTG', N'G', 0.0076)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (59, N'Honduran lempira', N'HNL', N'L', 0.0391)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (60, N'Hong Kong dollar', N'HKD', N'$', 0.1286)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (61, N'Hungarian forint', N'HUF', N'Ft', 0.0027)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (62, N'Icelandic króna', N'ISK', N'ko', 0.0077)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (63, N'Indian rupee', N'INR', N'₹', 0.0117)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (64, N'Indonesian rupiah', N'IDR', N'Rp', 0.0001)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (65, N'Iranian rial', N'IRR', N'﷼', 0)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (66, N'Iraqi dinar', N'IQD', N'د.ع', 0.0008)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (67, N'Jamaican dollar', N'JMD', N'J$', 0.0063)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (68, N'Japanese yen', N'JPY', N'¥', 0.0068)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (69, N'Jordanian dinar', N'JOD', N'ا.د', 1.4104)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (70, N'Kazakhstani tenge', N'KZT', N'лв', 0.002)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (71, N'Kenyan shilling', N'KES', N'KSh', 0.0077)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (72, N'Kuwaiti dinar', N'KWD', N'ك.د', 3.252)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (73, N'Kyrgyzstani som', N'KGS', N'лв', 0.0115)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (74, N'Lao kip', N'LAK', N'₭', 0)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (75, N'Lebanese pound', N'LBP', N'£', 0)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (76, N'Lesotho loti', N'LSL', N'L', 0.0533)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (77, N'Liberian dollar', N'LRD', N'$', 0.005)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (78, N'Libyan dinar', N'LYD', N'د.ل', 0.2069)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (79, N'Lilangeni', N'SZL', N'E', 0.0533)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (80, N'Macanese pataca', N'MOP', N'$', 0.1248)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (81, N'Malagasy ariary', N'MGA', N'Ar', 0.0002)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (82, N'Malawian kwacha', N'MWK', N'MK', 0.0006)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (83, N'Malaysian ringgit', N'MYR', N'RM', 0.225)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (84, N'Maldivian rufiyaa', N'MVR', N'Rf', 0.0647)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (85, N'Mauritanian ouguiya', N'MRO', N'MRU', 0.0253)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (86, N'Mauritian rupee', N'MUR', N'₨', 0.022)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (87, N'Mexican peso', N'MXN', N'$', 0.0501)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (88, N'Moldovan leu', N'MDL', N'L', 0.056)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (89, N'Mongolian tögrög', N'MNT', N'₮', 0.0003)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (90, N'Moroccan dirham', N'MAD', N'DH', 0.1051)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (91, N'Mozambican metical', N'MZN', N'MT', 0.0157)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (92, N'Namibian dollar', N'NAD', N'$', 0.0533)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (93, N'Nepalese rupee', N'NPR', N'₨', 0.0073)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (94, N'Netherlands Antillean guilder', N'ANG', N'ƒ', 0.5587)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (95, N'New Taiwan dollar', N'TWD', N'$', 0.0303)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (96, N'New Zealand dollar', N'NZD', N'$', 0.5798)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (97, N'Nicaraguan córdoba', N'NIO', N'C$', 0.0273)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (98, N'Nigerian naira', N'NGN', N'₦', 0.0007)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (99, N'Omani rial', N'OMR', N'.ع.ر', 2.6008)
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (100, N'Pakistani rupee', N'PKR', N'₨', 0.0036)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (101, N'Panamanian balboa', N'PAB', N'B/.', 1)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (102, N'Papua New Guinean kina', N'PGK', N'K', 0.2435)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (103, N'Paraguayan guarani', N'PYG', N'₲', 0.0001)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (104, N'Peruvian sol', N'PEN', N'S/.', 0.2727)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (105, N'Philippine peso', N'PHP', N'₱', 0.0175)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (106, N'Polish złoty', N'PLN', N'zł', 0.2622)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (107, N'Qatari riyal', N'QAR', N'ق.ر', 0.2747)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (108, N'Romanian leu', N'RON', N'lei', 0.2222)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (109, N'Russian ruble', N'RUB', N'₽', 0.0119)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (110, N'Rwandan franc', N'RWF', N'FRw', 0.0007)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (111, N'Samoan tālā', N'WST', N'SAT', 0.3563)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (112, N'Saudi riyal', N'SAR', N'﷼', 0.2667)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (113, N'Serbian dinar', N'RSD', N'din', 0.0094)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (114, N'Seychellois rupee', N'SCR', N'SRe', 0.068)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (115, N'Sierra Leonean leone', N'SLL', N'Le', 0)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (116, N'Singapore dollar', N'SGD', N'$', 0.7486)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (117, N'Solomon Islands dollar', N'SBD', N'Si$', 0.1223)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (118, N'South African rand', N'ZAR', N'R', 0.0533)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (119, N'South Sudanese pound', N'SSP', N'£', 0.0002)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (120, N'Sri Lankan rupee', N'LKR', N'Rs', 0.0034)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (121, N'Sudanese pound', N'SDG', N'.س.ج', 0.002)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (122, N'Surinamese dollar', N'SRD', N'$', 0.0272)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (123, N'Swedish krona', N'SEK', N'ko', 0.1025)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (124, N'Swiss franc', N'CHF', N'CHf', 1.1628)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (125, N'Syrian pound', N'SYP', N'LS', 0.0001)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (126, N'Tajikistani somoni', N'TJS', N'SM', 0.0917)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (127, N'Tanzanian shilling', N'TZS', N'TSh', 0.0004)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (128, N'Thai baht', N'THB', N'฿', 0.0292)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (129, N'Tongan paʻanga', N'TOP', N'$', 0.4187)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (130, N'Trinidad and Tobago dollar', N'TTD', N'$', 0.1485)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (131, N'Tunisian dinar', N'TND', N'ت.د', 0.3263)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (132, N'Turkish lira', N'TRY', N'₺', 0.0263)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (133, N'Turkmenistan manat', N'TMT', N'T', 0.2859)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (134, N'Ugandan shilling', N'UGX', N'USh', 0.0003)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (135, N'Ukrainian hryvnia', N'UAH', N'₴', 0.0242)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (136, N'United Arab Emirates dirham', N'AED', N'إ.د', 0.2723)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (137, N'Uruguayan peso', N'UYU', N'$', 0.0238)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (138, N'US Dollar', N'USD', N'$', 1)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (139, N'Uzbekistani soʻm', N'UZS', N'лв', 0.0001)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (140, N'Vanuatu vatu', N'VUV', N'VT', 0.0081)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (141, N'Vietnamese đồng', N'VND', N'₫', 0)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (142, N'West African CFA franc', N'XOF', N'CFA', 0.0017)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (143, N'Won', N'KRW', N'₩', 0.0007)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (144, N'Yemeni rial', N'YER', N'﷼', 0.0041)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (145, N'Zambian kwacha', N'ZMW', N'ZK', 0.0357)
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [Currency], [CurrencySymbol], [ExchangeRatePerUSD]) VALUES (146, N'Zimbabwe Dollar', N'ZWL', N'$', 0.1475)
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [EmploymentDate], [JobPosition], [Salary]) VALUES (1, 1, CAST(N'2025-01-30T00:00:00.000' AS DateTime), 337, 5000.0000)
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [EmploymentDate], [JobPosition], [Salary]) VALUES (2, 3, CAST(N'2025-04-04T11:53:08.560' AS DateTime), 337, 1000.0000)
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [EmploymentDate], [JobPosition], [Salary]) VALUES (3, 4, CAST(N'2025-05-07T13:08:11.960' AS DateTime), 337, 1800.0000)
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [EmploymentDate], [JobPosition], [Salary]) VALUES (5, 5, CAST(N'2025-05-07T13:09:04.737' AS DateTime), 337, 2000.0000)
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [EmploymentDate], [JobPosition], [Salary]) VALUES (8, 6, CAST(N'2025-05-07T13:54:50.273' AS DateTime), 337, 2700.0000)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[ExchangeCurrencies] ON 

INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (1, N'USD', CAST(1.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (2, N'AED', CAST(3.6725 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (3, N'AFN', CAST(71.3562 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (4, N'ALL', CAST(90.1377 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (5, N'AMD', CAST(391.1786 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (6, N'ANG', CAST(1.7900 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (7, N'AOA', CAST(918.5748 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (8, N'ARS', CAST(1075.8800 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (9, N'AUD', CAST(1.6620 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (10, N'AWG', CAST(1.7900 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (11, N'AZN', CAST(1.6999 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (12, N'BAM', CAST(1.7805 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (13, N'BBD', CAST(2.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (14, N'BDT', CAST(121.3674 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (15, N'BGN', CAST(1.7804 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (16, N'BHD', CAST(0.3760 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (17, N'BIF', CAST(2960.3407 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (18, N'BMD', CAST(1.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (19, N'BND', CAST(1.3404 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (20, N'BOB', CAST(6.8885 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (21, N'BRL', CAST(5.7194 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (22, N'BSD', CAST(1.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (23, N'BTN', CAST(85.5708 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (24, N'BWP', CAST(13.8733 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (25, N'BYN', CAST(3.1354 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (26, N'BZD', CAST(2.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (27, N'CAD', CAST(1.4230 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (28, N'CDF', CAST(2899.0345 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (29, N'CHF', CAST(0.8524 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (30, N'CLP', CAST(960.6602 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (31, N'CNY', CAST(7.2857 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (32, N'COP', CAST(4203.7470 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (33, N'CRC', CAST(502.4294 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (34, N'CUP', CAST(24.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (35, N'CVE', CAST(100.3829 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (36, N'CZK', CAST(22.9524 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (37, N'DJF', CAST(177.7210 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (38, N'DKK', CAST(6.7905 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (39, N'DOP', CAST(62.8304 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (40, N'DZD', CAST(132.9950 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (41, N'EGP', CAST(50.8068 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (42, N'ERN', CAST(15.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (43, N'ETB', CAST(131.8684 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (44, N'EUR', CAST(0.9102 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (45, N'FJD', CAST(2.3154 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (46, N'FKP', CAST(0.7757 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (47, N'FOK', CAST(6.7935 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (48, N'GBP', CAST(0.7751 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (49, N'GEL', CAST(2.7559 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (50, N'GGP', CAST(0.7757 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (51, N'GHS', CAST(15.5067 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (52, N'GIP', CAST(0.7757 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (53, N'GMD', CAST(72.6441 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (54, N'GNF', CAST(8570.9680 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (55, N'GTQ', CAST(7.6902 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (56, N'GYD', CAST(209.8017 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (57, N'HKD', CAST(7.7734 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (58, N'HNL', CAST(25.5147 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (59, N'HRK', CAST(6.8592 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (60, N'HTG', CAST(130.7844 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (61, N'HUF', CAST(369.6088 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (62, N'IDR', CAST(16757.5574 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (63, N'ILS', CAST(3.7448 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (64, N'IMP', CAST(0.7757 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (65, N'INR', CAST(85.5703 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (66, N'IQD', CAST(1309.7144 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (67, N'IRR', CAST(42008.9149 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (68, N'ISK', CAST(131.1250 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (69, N'JEP', CAST(0.7757 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (70, N'JMD', CAST(157.7190 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (71, N'JOD', CAST(0.7090 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (72, N'JPY', CAST(145.2473 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (73, N'KES', CAST(129.2338 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (74, N'KGS', CAST(86.8492 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (75, N'KHR', CAST(3997.3556 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (76, N'KID', CAST(1.6621 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (77, N'KMF', CAST(447.8769 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (78, N'KRW', CAST(1457.9608 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (79, N'KWD', CAST(0.3070 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (80, N'KYD', CAST(0.8333 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (81, N'KZT', CAST(510.3326 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (82, N'LAK', CAST(21751.6772 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (83, N'LBP', CAST(89500.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (84, N'LKR', CAST(295.3817 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (85, N'LRD', CAST(199.3433 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (86, N'LSL', CAST(19.1915 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (87, N'LYD', CAST(4.8358 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (88, N'MAD', CAST(9.5166 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (89, N'MDL', CAST(17.6443 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (90, N'MGA', CAST(4654.3433 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (91, N'MKD', CAST(55.9208 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (92, N'MMK', CAST(2090.2388 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (93, N'MNT', CAST(3479.6583 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (94, N'MOP', CAST(8.0068 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (95, N'MRU', CAST(39.8843 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (96, N'MUR', CAST(44.5309 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (97, N'MVR', CAST(15.4592 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (98, N'MWK', CAST(1740.2553 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (99, N'MXN', CAST(20.5515 AS Decimal(10, 4)))
GO
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (100, N'MYR', CAST(4.4370 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (101, N'MZN', CAST(63.6781 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (102, N'NAD', CAST(19.1915 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (103, N'NGN', CAST(1529.0612 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (104, N'NIO', CAST(36.6793 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (105, N'NOK', CAST(10.7699 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (106, N'NPR', CAST(136.9132 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (107, N'NZD', CAST(1.7956 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (108, N'OMR', CAST(0.3845 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (109, N'PAB', CAST(1.0000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (110, N'PEN', CAST(3.6809 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (111, N'PGK', CAST(4.0959 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (112, N'PHP', CAST(57.3644 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (113, N'PKR', CAST(280.7358 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (114, N'PLN', CAST(3.8787 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (115, N'PYG', CAST(8001.2022 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (116, N'QAR', CAST(3.6400 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (117, N'RON', CAST(4.5185 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (118, N'RSD', CAST(106.3911 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (119, N'RUB', CAST(84.4536 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (120, N'RWF', CAST(1422.8596 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (121, N'SAR', CAST(3.7500 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (122, N'SBD', CAST(8.3385 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (123, N'SCR', CAST(14.8196 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (124, N'SDG', CAST(458.3047 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (125, N'SEK', CAST(10.0072 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (126, N'SGD', CAST(1.3405 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (127, N'SHP', CAST(0.7757 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (128, N'SLE', CAST(22.7181 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (129, N'SLL', CAST(22718.0510 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (130, N'SOS', CAST(571.0444 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (131, N'SRD', CAST(36.8241 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (132, N'SSP', CAST(4519.7480 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (133, N'STN', CAST(22.3043 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (134, N'SYP', CAST(12873.9497 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (135, N'SZL', CAST(19.1915 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (136, N'THB', CAST(34.3823 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (137, N'TJS', CAST(10.9221 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (138, N'TMT', CAST(3.4983 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (139, N'TND', CAST(3.0571 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (140, N'TOP', CAST(2.3833 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (141, N'TRY', CAST(38.0295 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (142, N'TTD', CAST(6.7342 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (143, N'TVD', CAST(1.6621 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (144, N'TWD', CAST(33.1309 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (145, N'TZS', CAST(2647.2453 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (146, N'UAH', CAST(41.1747 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (147, N'UGX', CAST(3662.2001 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (148, N'UYU', CAST(42.0420 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (149, N'UZS', CAST(12937.4930 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (150, N'VES', CAST(72.1856 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (151, N'VND', CAST(25642.7185 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (152, N'VUV', CAST(121.8650 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (153, N'WST', CAST(2.8015 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (154, N'XAF', CAST(597.1692 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (155, N'XCD', CAST(2.7000 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (156, N'XCG', CAST(1.7900 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (157, N'XDR', CAST(0.7510 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (158, N'XOF', CAST(597.1692 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (159, N'XPF', CAST(108.6373 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (160, N'YER', CAST(244.8828 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (161, N'ZAR', CAST(19.2142 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (162, N'ZMW', CAST(27.9801 AS Decimal(10, 4)))
INSERT [dbo].[ExchangeCurrencies] ([CurrencyID], [Currency], [CurrencyValue]) VALUES (163, N'ZWL', CAST(6.7864 AS Decimal(10, 4)))
SET IDENTITY_INSERT [dbo].[ExchangeCurrencies] OFF
GO
SET IDENTITY_INSERT [dbo].[ExternalTransferOperations] ON 

INSERT [dbo].[ExternalTransferOperations] ([OperationID], [TransfeID], [DoneByUser], [TronsferFrom], [CurrencyOfTransferID], [Amount], [Fees], [BankName], [IBAN_Number], [RecipientFullName], [SendingDate], [ArrivalDate], [status]) VALUES (2, 3, 1, 2, 2, 48.1902, 1.8098, N'Bank of Amirica', N'XXXX-923X-X29X-XXX1', N'SAHABI Mohamed Karim', CAST(N'2025-04-04T11:35:27.033' AS DateTime), CAST(N'2025-04-05T11:35:27.033' AS DateTime), 3)
INSERT [dbo].[ExternalTransferOperations] ([OperationID], [TransfeID], [DoneByUser], [TronsferFrom], [CurrencyOfTransferID], [Amount], [Fees], [BankName], [IBAN_Number], [RecipientFullName], [SendingDate], [ArrivalDate], [status]) VALUES (3, 5, 2, 1, 1, 88.0000, 2.0000, N'Bank of Amirica', N'XXX1-XX12-160X-X15X', N'Sophia Olivia', CAST(N'2025-04-04T11:59:28.210' AS DateTime), CAST(N'2025-04-05T11:59:28.210' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[ExternalTransferOperations] OFF
GO
SET IDENTITY_INSERT [dbo].[InternalTransferOperations] ON 

INSERT [dbo].[InternalTransferOperations] ([OperationID], [TransferID], [CurrencyOfTransfer], [TransferFromClientID], [DoneByUser], [Amount], [Fees], [CurrencyOfAmountReceived], [TransferToClientID], [AmountReceived], [IsSucceedit]) VALUES (2, 2, 2, 2, 1, 90.0000, 0.0000, 2, 3, 90.0000, 1)
INSERT [dbo].[InternalTransferOperations] ([OperationID], [TransferID], [CurrencyOfTransfer], [TransferFromClientID], [DoneByUser], [Amount], [Fees], [CurrencyOfAmountReceived], [TransferToClientID], [AmountReceived], [IsSucceedit]) VALUES (3, 4, 1, 1, 2, 80.0000, 0.0000, 2, 3, 72.3916, 1)
SET IDENTITY_INSERT [dbo].[InternalTransferOperations] OFF
GO
SET IDENTITY_INSERT [dbo].[OpenNewAccountApplications] ON 

INSERT [dbo].[OpenNewAccountApplications] ([AppID], [PersonID], [CreatedByUserID], [OpeningDate], [AccountID]) VALUES (12, 2, 1, CAST(N'2025-04-04T11:07:07.663' AS DateTime), 1)
INSERT [dbo].[OpenNewAccountApplications] ([AppID], [PersonID], [CreatedByUserID], [OpeningDate], [AccountID]) VALUES (13, 3, 1, CAST(N'2025-04-04T11:11:01.993' AS DateTime), 2)
INSERT [dbo].[OpenNewAccountApplications] ([AppID], [PersonID], [CreatedByUserID], [OpeningDate], [AccountID]) VALUES (14, 4, 1, CAST(N'2025-04-04T11:13:31.557' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[OpenNewAccountApplications] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (1, N'PETER', N'Noah', N'James', 1, CAST(N'2000-02-02T20:57:02.000' AS DateTime), N'N01', 222, N'noah12@gmail.com', N'+1 0125 14 51 61', 35, N'Montrial 40001', N'C:\Users\DELL\Desktop\BANK Project\BANK People Pictures\c56dd362-ca3f-432c-b475-565416329e24.jpg')
INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (2, N'SILMI', NULL, N'Ahmed', 1, CAST(N'1996-07-05T00:00:00.000' AS DateTime), N'N02', 4, N'ahmed.silmi@yahoo.fr', N'+213 665 65 20 70', 4, N'Algerie-bab elzouar 16', NULL)
INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (3, N'BELKASM', N'Amira', N'Sara', 0, CAST(N'1999-04-04T11:08:17.000' AS DateTime), N'N3', 4, N'amira14@hotmail.com', N'+213 0665 21 54 20', 4, N'Blida bolvoir 20m', N'C:\Users\DELL\Desktop\BANK Project\BANK People Pictures\786569bd-1179-400b-93de-e572afacc6dc.jpg')
INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (4, N'BENYAEKOUB', N'Abd ', N'Elrahman', 1, CAST(N'1995-12-08T11:11:26.000' AS DateTime), N'N4', 4, N'ben.abdou@yahoo.com', N'+33 0785 22 95 13', 68, N'Parie', N'C:\Users\DELL\Desktop\BANK Project\BANK People Pictures\bbb1d9e2-7345-483d-900e-6fa0fd37d984.jpg')
INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (5, N'SADOUKI', N'Sara', N'Mona', 0, CAST(N'2007-05-07T05:12:58.930' AS DateTime), N'N08', 235, N's@gmail.com', N'+55 1561 45 31 61', 28, N'Brazil-1450', NULL)
INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (6, N'KLARA', NULL, N'Michelle', 0, CAST(N'1999-05-07T05:19:58.000' AS DateTime), N'N09', 222, N'm@yahoo.fr', N'+86 1284 10 84 50', 41, N'Chine-1254', N'C:\BANK\People Imagesb16719df-b9af-4e73-8e57-5db0a7ffee5a.jpg')
INSERT [dbo].[People] ([PersonID], [FirstName], [MedName], [LastName], [Gendor], [DateOfBirth], [NationalNumber], [Nationality], [Email], [Phone], [CountryOfResidence], [Address], [ImagePath]) VALUES (12, N'SAMI', N'Mohamed', N'Akram', 1, CAST(N'1997-02-07T13:09:37.000' AS DateTime), N'N90', 4, N'akram23@yahoo.fr', N'+213 1550 16 91 30', 4, N'blida-09', NULL)
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceID], [ServiceTitle], [ServiceDescription], [Fees]) VALUES (1, N'Transactions', N'Transaction banking can be defined as the set of instruments and services that a bank offers to trading partners to financially support their reciprocal exchanges of goods (e.g., trade), monetary flows (e.g., cash), or commercial papers (e.g., exchanges). Transaction banking allows banks to maintain close relationships with their corporate clients, so banks don’t want to be disintermediated by other players.
', 0.0000)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[ServicesApplications] ON 

INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (5, 2, 1, 1, CAST(N'2025-04-04T11:33:52.000' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (6, 2, 1, 1, CAST(N'2025-04-04T11:34:03.597' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (7, 2, 1, 1, CAST(N'2025-04-04T11:34:25.530' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (8, 2, 1, 1, CAST(N'2025-04-04T11:35:27.033' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (9, 1, 2, 1, CAST(N'2025-04-04T11:56:25.653' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (10, 1, 2, 1, CAST(N'2025-04-04T11:56:50.780' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (11, 1, 2, 1, CAST(N'2025-04-04T11:57:32.660' AS DateTime))
INSERT [dbo].[ServicesApplications] ([ServiceAppID], [ClientID], [UserID], [ServiceID], [RequestDate]) VALUES (12, 1, 2, 1, CAST(N'2025-04-04T11:59:28.210' AS DateTime))
SET IDENTITY_INSERT [dbo].[ServicesApplications] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (2, 2, 5)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (3, 1, 6)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (4, 3, 7)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (5, 3, 8)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (6, 1, 9)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (7, 2, 10)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (8, 3, 11)
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeID], [ServiceAppID]) VALUES (9, 3, 12)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON 

INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [Name], [Description], [Fees]) VALUES (1, N'Withdraw', N'Is the process of taking money out of a bank account. It is a fundamental transaction in banking and an essential function for account holders.', 1.0000)
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [Name], [Description], [Fees]) VALUES (2, N'Deposit', N'A bank account deposit is the act of placing money into a bank account, either in a checking or savings format, for safekeeping and potential interest earnings. Deposits, which can be made via cash, checks, or electronic transfers, differ in their processing time and fund availability.', 0.0000)
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [Name], [Description], [Fees]) VALUES (3, N'Transfer', N'A bank transfer lets you move money from one bank account to another. It’s usually instant, free and done using mobile or online banking, over the phone or in branch', 0.0000)
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[TransferApplications] ON 

INSERT [dbo].[TransferApplications] ([TransferID], [TransactionID], [TransferTypeID]) VALUES (2, 4, 1)
INSERT [dbo].[TransferApplications] ([TransferID], [TransactionID], [TransferTypeID]) VALUES (3, 5, 2)
INSERT [dbo].[TransferApplications] ([TransferID], [TransactionID], [TransferTypeID]) VALUES (4, 8, 1)
INSERT [dbo].[TransferApplications] ([TransferID], [TransactionID], [TransferTypeID]) VALUES (5, 9, 2)
SET IDENTITY_INSERT [dbo].[TransferApplications] OFF
GO
INSERT [dbo].[TransferTypes] ([TransferTypeID], [TransferName], [TransferDescription], [TransferFees]) VALUES (1, N'Internal Transfer', N'internal transfer or transfer within the same bank, is a transaction made between accounts within the same financial institution.', 0.0000)
INSERT [dbo].[TransferTypes] ([TransferTypeID], [TransferName], [TransferDescription], [TransferFees]) VALUES (2, N'External Transfer', N'An external transfer is a process that allows individuals to move funds between two separate accounts held at different banks or financial institutions. external transfers simplify the process by eliminating the need for physical checks or cash transactions.', 2.0000)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [EmployeeID], [Username], [Password], [Permissions], [IsActive]) VALUES (1, 1, N'admin', N'8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', -1, 1)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Username], [Password], [Permissions], [IsActive]) VALUES (2, 2, N'sara1', N'0FFE1ABD1A08215353C233D6E009613E95EEC4253832A761AF28FF37AC5A150C', 4194424, 1)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Username], [Password], [Permissions], [IsActive]) VALUES (7, 3, N'User1', N'0FFE1ABD1A08215353C233D6E009613E95EEC4253832A761AF28FF37AC5A150C', -1, 0)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Username], [Password], [Permissions], [IsActive]) VALUES (8, 5, N'User2', N'0FFE1ABD1A08215353C233D6E009613E95EEC4253832A761AF28FF37AC5A150C', -1, 1)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Username], [Password], [Permissions], [IsActive]) VALUES (11, 8, N'User', N'0FFE1ABD1A08215353C233D6E009613E95EEC4253832A761AF28FF37AC5A150C', 557056, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WithdrawAndDepositOperations] ON 

INSERT [dbo].[WithdrawAndDepositOperations] ([OperationID], [TransactionID], [ClientID], [Amount], [OperationFees], [PreviousBalance], [BalanceAfterTransaction]) VALUES (2, 2, 2, 750.0000, 0.0000, 900.8947, 1650.8947)
INSERT [dbo].[WithdrawAndDepositOperations] ([OperationID], [TransactionID], [ClientID], [Amount], [OperationFees], [PreviousBalance], [BalanceAfterTransaction]) VALUES (3, 3, 2, 50.0000, 0.9049, 1650.8947, 1599.9898)
INSERT [dbo].[WithdrawAndDepositOperations] ([OperationID], [TransactionID], [ClientID], [Amount], [OperationFees], [PreviousBalance], [BalanceAfterTransaction]) VALUES (4, 6, 1, 40.0000, 1.0000, 1544.2040, 1503.2040)
INSERT [dbo].[WithdrawAndDepositOperations] ([OperationID], [TransactionID], [ClientID], [Amount], [OperationFees], [PreviousBalance], [BalanceAfterTransaction]) VALUES (5, 7, 1, 80.0000, 0.0000, 1503.2040, 1583.2040)
SET IDENTITY_INSERT [dbo].[WithdrawAndDepositOperations] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UniqueNationalNo]    Script Date: 5/14/2025 7:22:38 PM ******/
ALTER TABLE [dbo].[People] ADD  CONSTRAINT [UniqueNationalNo] UNIQUE NONCLUSTERED 
(
	[NationalNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountCurrencies]  WITH CHECK ADD  CONSTRAINT [FK_PossibleAccountCurrencies_CurrencyID] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[AccountCurrencies] CHECK CONSTRAINT [FK_PossibleAccountCurrencies_CurrencyID]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Accounts_ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Accounts_ClientID]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_PossibleAccountCurrencyID] FOREIGN KEY([AccountCurrency])
REFERENCES [dbo].[AccountCurrencies] ([AccountCurrencyID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_PossibleAccountCurrencyID]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_PersonID]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Currencies] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Currencies]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_JobID] FOREIGN KEY([JobPosition])
REFERENCES [dbo].[BankingJobs] ([JobID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_JobID]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_PersonID]
GO
ALTER TABLE [dbo].[ExternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_ExternalTransfer_ClientID] FOREIGN KEY([TronsferFrom])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[ExternalTransferOperations] CHECK CONSTRAINT [FK_ExternalTransfer_ClientID]
GO
ALTER TABLE [dbo].[ExternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_ExternalTransfer_TransferOperationID] FOREIGN KEY([TransfeID])
REFERENCES [dbo].[TransferApplications] ([TransferID])
GO
ALTER TABLE [dbo].[ExternalTransferOperations] CHECK CONSTRAINT [FK_ExternalTransfer_TransferOperationID]
GO
ALTER TABLE [dbo].[ExternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_ExternalTransfer_UserID] FOREIGN KEY([DoneByUser])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ExternalTransferOperations] CHECK CONSTRAINT [FK_ExternalTransfer_UserID]
GO
ALTER TABLE [dbo].[ExternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_ExternalTransferOperations_AccountCurrencyID] FOREIGN KEY([CurrencyOfTransferID])
REFERENCES [dbo].[AccountCurrencies] ([AccountCurrencyID])
GO
ALTER TABLE [dbo].[ExternalTransferOperations] CHECK CONSTRAINT [FK_ExternalTransferOperations_AccountCurrencyID]
GO
ALTER TABLE [dbo].[InternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_InternalTransferOperations_AccountCurrencyID] FOREIGN KEY([CurrencyOfTransfer])
REFERENCES [dbo].[AccountCurrencies] ([AccountCurrencyID])
GO
ALTER TABLE [dbo].[InternalTransferOperations] CHECK CONSTRAINT [FK_InternalTransferOperations_AccountCurrencyID]
GO
ALTER TABLE [dbo].[InternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_InternalTransferOperations_AccountCurrencyID2] FOREIGN KEY([CurrencyOfAmountReceived])
REFERENCES [dbo].[AccountCurrencies] ([AccountCurrencyID])
GO
ALTER TABLE [dbo].[InternalTransferOperations] CHECK CONSTRAINT [FK_InternalTransferOperations_AccountCurrencyID2]
GO
ALTER TABLE [dbo].[InternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_InternalTransfers_Client2] FOREIGN KEY([TransferToClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[InternalTransferOperations] CHECK CONSTRAINT [FK_InternalTransfers_Client2]
GO
ALTER TABLE [dbo].[InternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_InternalTransfers_ClientID1] FOREIGN KEY([TransferFromClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[InternalTransferOperations] CHECK CONSTRAINT [FK_InternalTransfers_ClientID1]
GO
ALTER TABLE [dbo].[InternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_InternalTransfers_TransferID] FOREIGN KEY([TransferID])
REFERENCES [dbo].[TransferApplications] ([TransferID])
GO
ALTER TABLE [dbo].[InternalTransferOperations] CHECK CONSTRAINT [FK_InternalTransfers_TransferID]
GO
ALTER TABLE [dbo].[InternalTransferOperations]  WITH CHECK ADD  CONSTRAINT [FK_InternalTransfers_UserID] FOREIGN KEY([DoneByUser])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[InternalTransferOperations] CHECK CONSTRAINT [FK_InternalTransfers_UserID]
GO
ALTER TABLE [dbo].[OpenNewAccountApplications]  WITH CHECK ADD  CONSTRAINT [FK_OpenNewAccountApp_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[OpenNewAccountApplications] CHECK CONSTRAINT [FK_OpenNewAccountApp_PersonID]
GO
ALTER TABLE [dbo].[OpenNewAccountApplications]  WITH CHECK ADD  CONSTRAINT [FK_OpenNewAccountApp_UserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OpenNewAccountApplications] CHECK CONSTRAINT [FK_OpenNewAccountApp_UserID]
GO
ALTER TABLE [dbo].[OpenNewAccountApplications]  WITH CHECK ADD  CONSTRAINT [FK_OpenNewAccountApplications_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountNumber])
GO
ALTER TABLE [dbo].[OpenNewAccountApplications] CHECK CONSTRAINT [FK_OpenNewAccountApplications_Accounts]
GO
ALTER TABLE [dbo].[ServicesApplications]  WITH CHECK ADD  CONSTRAINT [FK_ServicesApplications_ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[ServicesApplications] CHECK CONSTRAINT [FK_ServicesApplications_ClientID]
GO
ALTER TABLE [dbo].[ServicesApplications]  WITH CHECK ADD  CONSTRAINT [FK_ServicesApplications_ServiceID] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[ServicesApplications] CHECK CONSTRAINT [FK_ServicesApplications_ServiceID]
GO
ALTER TABLE [dbo].[ServicesApplications]  WITH CHECK ADD  CONSTRAINT [FK_ServicesApplications_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ServicesApplications] CHECK CONSTRAINT [FK_ServicesApplications_UserID]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_ServiceAppID] FOREIGN KEY([ServiceAppID])
REFERENCES [dbo].[ServicesApplications] ([ServiceAppID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_ServiceAppID]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionTypes] ([TransactionTypeID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_TransactionType]
GO
ALTER TABLE [dbo].[TransferApplications]  WITH CHECK ADD  CONSTRAINT [FK_TransferApplications_TransactionID] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[Transactions] ([TransactionID])
GO
ALTER TABLE [dbo].[TransferApplications] CHECK CONSTRAINT [FK_TransferApplications_TransactionID]
GO
ALTER TABLE [dbo].[TransferApplications]  WITH CHECK ADD  CONSTRAINT [FK_TransferApplications_TransferTypeID] FOREIGN KEY([TransferTypeID])
REFERENCES [dbo].[TransferTypes] ([TransferTypeID])
GO
ALTER TABLE [dbo].[TransferApplications] CHECK CONSTRAINT [FK_TransferApplications_TransferTypeID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_EmployeeID]
GO
ALTER TABLE [dbo].[WithdrawAndDepositOperations]  WITH CHECK ADD  CONSTRAINT [FK_WithdrawAndDipositOperation_ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[WithdrawAndDepositOperations] CHECK CONSTRAINT [FK_WithdrawAndDipositOperation_ClientID]
GO
ALTER TABLE [dbo].[WithdrawAndDepositOperations]  WITH CHECK ADD  CONSTRAINT [FK_WithdrawAndDipositOperation_TransactionID] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[Transactions] ([TransactionID])
GO
ALTER TABLE [dbo].[WithdrawAndDepositOperations] CHECK CONSTRAINT [FK_WithdrawAndDipositOperation_TransactionID]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-Female  1-Male' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'People', @level2type=N'COLUMN',@level2name=N'Gendor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServicesApplications', @level2type=N'COLUMN',@level2name=N'ServiceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1- EnternalTransfer  2- ExternalTransfer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferApplications', @level2type=N'COLUMN',@level2name=N'TransferTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Accounts"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Clients"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 457
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OpenNewAccountApplications"
            Begin Extent = 
               Top = 462
               Left = 48
               Bottom = 625
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountCurrencies"
            Begin Extent = 
               Top = 630
               Left = 48
               Bottom = 749
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currencies"
            Begin Extent = 
               Top = 749
               Left = 48
               Bottom = 912
               Right = 286
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AccountsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AccountsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AccountsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "People"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Clients"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Accounts"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 457
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OpenNewAccountApplications"
            Begin Extent = 
               Top = 462
               Left = 48
               Bottom = 625
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountCurrencies"
            Begin Extent = 
               Top = 630
               Left = 48
               Bottom = 749
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currencies"
            Begin Extent = 
               Top = 749
               Left = 48
               Bottom = 912
               Right = 286
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Countries"
            Begin Extent = 
               Top = 917
               Left = 48
               Bottom = 1080
               Right = 242
            End' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClientsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ExternalTransferOperations"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 284
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountCurrencies"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currencies"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 457
               Right = 286
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ExternalTransferOperationsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ExternalTransferOperationsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "InternalTransferOperations"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 329
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SenderClient"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SenderPerson"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 457
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SenderAccount"
            Begin Extent = 
               Top = 462
               Left = 48
               Bottom = 625
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TransferApplications"
            Begin Extent = 
               Top = 630
               Left = 48
               Bottom = 771
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Transactions"
            Begin Extent = 
               Top = 777
               Left = 48
               Bottom = 918
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServicesApplications"
            Begin Extent = 
               Top = 924
               Left = 48
               Bottom = 1087
           ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InternalTransferOperationsFullData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountSenderCurrency"
            Begin Extent = 
               Top = 1092
               Left = 48
               Bottom = 1211
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SenderCurrency"
            Begin Extent = 
               Top = 1211
               Left = 48
               Bottom = 1374
               Right = 286
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReceiverClient"
            Begin Extent = 
               Top = 1379
               Left = 48
               Bottom = 1498
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReceiverPerson"
            Begin Extent = 
               Top = 1498
               Left = 48
               Bottom = 1661
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReceiverAccount"
            Begin Extent = 
               Top = 1666
               Left = 48
               Bottom = 1829
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountReceiverCurrency"
            Begin Extent = 
               Top = 1834
               Left = 48
               Bottom = 1953
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReceiverCurrency"
            Begin Extent = 
               Top = 1953
               Left = 48
               Bottom = 2116
               Right = 286
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 2121
               Left = 48
               Bottom = 2284
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InternalTransferOperationsFullData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InternalTransferOperationsFullData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "InternalTransferOperations"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 329
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountCurrencies"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currencies"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 457
               Right = 286
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TransferApplications"
            Begin Extent = 
               Top = 462
               Left = 48
               Bottom = 603
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Transactions"
            Begin Extent = 
               Top = 609
               Left = 48
               Bottom = 750
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServicesApplications"
            Begin Extent = 
               Top = 756
               Left = 48
               Bottom = 919
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Be' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InternalTransferOperationsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'gin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InternalTransferOperationsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InternalTransferOperationsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "People"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Countries"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PeopleList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PeopleList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -120
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employees"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 343
               Left = 48
               Bottom = 506
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WithdrawAndDepositOperations"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 304
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Clients"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 457
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "ServicesApplications"
            Begin Extent = 
               Top = 462
               Left = 48
               Bottom = 625
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Transactions"
            Begin Extent = 
               Top = 630
               Left = 48
               Bottom = 771
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TransactionTypes"
            Begin Extent = 
               Top = 924
               Left = 48
               Bottom = 1087
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Accounts"
            Begin Extent = 
               Top = 127
               Left = 352
               Bottom = 290
               Right = 558
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WithdrawAndDepositOperationsFullData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "AccountCurrencies"
            Begin Extent = 
               Top = 30
               Left = 673
               Bottom = 149
               Right = 894
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currencies"
            Begin Extent = 
               Top = 15
               Left = 1084
               Bottom = 178
               Right = 1322
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 154
               Left = 606
               Bottom = 317
               Right = 800
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WithdrawAndDepositOperationsFullData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WithdrawAndDepositOperationsFullData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WithdrawAndDepositOperations"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 304
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Transactions"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 316
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TransactionTypes"
            Begin Extent = 
               Top = 322
               Left = 48
               Bottom = 485
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServicesApplications"
            Begin Extent = 
               Top = 490
               Left = 48
               Bottom = 653
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Accounts"
            Begin Extent = 
               Top = 7
               Left = 352
               Bottom = 170
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountCurrencies"
            Begin Extent = 
               Top = 7
               Left = 606
               Bottom = 126
               Right = 827
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currencies"
            Begin Extent = 
               Top = 7
               Left = 875
               Bottom = 170
               Righ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WithdrawDepositView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N't = 1113
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WithdrawDepositView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WithdrawDepositView'
GO
USE [master]
GO
ALTER DATABASE [BANK] SET  READ_WRITE 
GO
