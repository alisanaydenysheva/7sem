USE [master]
GO
/****** Object:  Database [WitcherToursDB]    Script Date: 12/5/2022 3:40:29 PM ******/
CREATE DATABASE [WitcherToursDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Hotel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Hotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Hotel_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WitcherToursDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WitcherToursDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WitcherToursDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WitcherToursDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WitcherToursDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WitcherToursDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WitcherToursDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WitcherToursDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WitcherToursDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WitcherToursDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WitcherToursDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WitcherToursDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WitcherToursDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WitcherToursDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WitcherToursDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WitcherToursDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WitcherToursDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WitcherToursDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WitcherToursDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WitcherToursDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WitcherToursDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WitcherToursDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WitcherToursDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WitcherToursDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WitcherToursDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WitcherToursDB] SET  MULTI_USER 
GO
ALTER DATABASE [WitcherToursDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WitcherToursDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WitcherToursDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WitcherToursDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WitcherToursDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WitcherToursDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WitcherToursDB] SET QUERY_STORE = OFF
GO
USE [WitcherToursDB]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryCode] [varchar](3) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Stars] [int] NOT NULL,
	[CountryCode] [varchar](3) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelImage]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelImage](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NOT NULL,
	[ImageSource] [varchar](200) NOT NULL,
 CONSTRAINT [PK_HotelImage] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourHotel]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourHotel](
	[HotelID] [int] NOT NULL,
	[TourID] [int] NOT NULL,
 CONSTRAINT [PK_TourHotel] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC,
	[TourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tours]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[TourID] [int] IDENTITY(1,1) NOT NULL,
	[ValueOfTickets] [int] NULL,
	[Name] [varchar](50) NULL,
	[ImagePreview] [nvarchar](500) NULL,
	[Price] [decimal](10, 2) NULL,
	[IsActual] [nchar](16) NULL,
 CONSTRAINT [PK_Tours] PRIMARY KEY CLUSTERED 
(
	[TourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourTypes]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourTypes](
	[TourID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_TourTypes] PRIMARY KEY CLUSTERED 
(
	[TourID] ASC,
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/5/2022 3:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Login] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[photo] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AD', N'Andorra')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AE', N'United Arab Emirates')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AF', N'Afghanistan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AG', N'Antigua and Barbuda')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AI', N'Anguilla')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AL', N'Albania')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AM', N'Armenia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AN', N'Netherlands Antilles')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AO', N'Angola')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AP', N'Asia/Pacific Region')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AQ', N'Antarctica')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AR', N'Argentina')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AS', N'American Samoa')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AT', N'Austria')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AU', N'Australia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AW', N'Aruba')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'AZ', N'Azerbaijan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BA', N'Bosnia and Herzegovina')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BB', N'Barbados')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BD', N'Bangladesh')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BE', N'Belgium')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BF', N'Burkina Faso')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BG', N'Bulgaria')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BH', N'Bahrain')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BI', N'Burundi')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BJ', N'Benin')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BM', N'Bermuda')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BN', N'Brunei Darussalam')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BO', N'Bolivia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BR', N'Brazil')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BS', N'Bahamas')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BT', N'Bhutan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BV', N'Bouvet Island')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BW', N'Botswana')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BY', N'Belarus')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'BZ', N'Belize')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CA', N'Canada')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CC', N'Cocos (Keeling) Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CD', N'Congo, The Democratic Republic of the')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CF', N'Central African Republic')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CG', N'Congo')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CH', N'Switzerland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CI', N'Cote D''Ivoire')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CK', N'Cook Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CL', N'Chile')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CM', N'Cameroon')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CN', N'China')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CO', N'Colombia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CR', N'Costa Rica')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CS', N'Serbia and Montenegro')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CU', N'Cuba')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CV', N'Cape Verde')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CX', N'Christmas Island')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CY', N'Cyprus')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'CZ', N'Czech Republic')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'DE', N'Germany')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'DJ', N'Djibouti')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'DK', N'Denmark')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'DM', N'Dominica')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'DO', N'Dominican Republic')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'DZ', N'Algeria')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'EC', N'Ecuador')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'EE', N'Estonia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'EG', N'Egypt')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'EH', N'Western Sahara')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ER', N'Eritrea')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ES', N'Spain')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ET', N'Ethiopia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'EU', N'Europe')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FI', N'Finland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FJ', N'Fiji')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FK', N'Falkland Islands (Malvinas)')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FM', N'Micronesia, Federated States of')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FO', N'Faroe Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FR', N'France')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'FX', N'France, Metropolitan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GA', N'Gabon')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GB', N'United Kingdom')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GD', N'Grenada')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GE', N'Georgia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GF', N'French Guiana')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GH', N'Ghana')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GI', N'Gibraltar')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GL', N'Greenland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GM', N'Gambia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GN', N'Guinea')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GP', N'Guadeloupe')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GQ', N'Equatorial Guinea')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GR', N'Greece')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GS', N'South Georgia and the South Sandwich Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GT', N'Guatemala')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GU', N'Guam')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GW', N'Guinea-Bissau')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'GY', N'Guyana')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'HK', N'Hong Kong')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'HM', N'Heard Island and McDonald Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'HN', N'Honduras')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'HR', N'Croatia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'HT', N'Haiti')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'HU', N'Hungary')
GO
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ID', N'Indonesia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IE', N'Ireland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IL', N'Israel')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IN', N'India')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IO', N'British Indian Ocean Territory')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IQ', N'Iraq')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IR', N'Iran, Islamic Republic of')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IS', N'Iceland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'IT', N'Italy')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'JM', N'Jamaica')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'JO', N'Jordan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'JP', N'Japan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KE', N'Kenya')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KG', N'Kyrgyzstan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KH', N'Cambodia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KI', N'Kiribati')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KM', N'Comoros')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KN', N'Saint Kitts and Nevis')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KP', N'Korea, Democratic People''s Republic of')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KR', N'Korea, Republic of')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KW', N'Kuwait')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KY', N'Cayman Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'KZ', N'Kazakhstan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LA', N'Lao People''s Democratic Republic')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LB', N'Lebanon')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LC', N'Saint Lucia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LI', N'Liechtenstein')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LK', N'Sri Lanka')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LR', N'Liberia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LS', N'Lesotho')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LT', N'Lithuania')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LU', N'Luxembourg')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LV', N'Latvia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'LY', N'Libyan Arab Jamahiriya')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MA', N'Morocco')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MC', N'Monaco')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MD', N'Moldova, Republic of')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MG', N'Madagascar')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MH', N'Marshall Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MK', N'Macedonia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ML', N'Mali')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MM', N'Myanmar')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MN', N'Mongolia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MO', N'Macau')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MP', N'Northern Mariana Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MQ', N'Martinique')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MR', N'Mauritania')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MS', N'Montserrat')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MT', N'Malta')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MU', N'Mauritius')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MV', N'Maldives')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MW', N'Malawi')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MX', N'Mexico')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MY', N'Malaysia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'MZ', N'Mozambique')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NA', N'Namibia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NC', N'New Caledonia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NE', N'Niger')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NF', N'Norfolk Island')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NG', N'Nigeria')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NI', N'Nicaragua')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NL', N'Netherlands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NO', N'Norway')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NP', N'Nepal')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NR', N'Nauru')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NU', N'Niue')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'NZ', N'New Zealand')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'OM', N'Oman')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PA', N'Panama')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PE', N'Peru')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PF', N'French Polynesia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PG', N'Papua New Guinea')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PH', N'Philippines')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PK', N'Pakistan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PL', N'Poland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PM', N'Saint Pierre and Miquelon')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PN', N'Pitcairn Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PR', N'Puerto Rico')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PS', N'Palestinian Territory')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PT', N'Portugal')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PW', N'Palau')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'PY', N'Paraguay')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'QA', N'Qatar')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'RE', N'Reunion')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'RO', N'Romania')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'RU', N'Russia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'RW', N'Rwanda')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SA', N'Saudi Arabia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SB', N'Solomon Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SC', N'Seychelles')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SD', N'Sudan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SE', N'Sweden')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SG', N'Singapore')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SH', N'Saint Helena')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SI', N'Slovenia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SJ', N'Svalbard and Jan Mayen')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SK', N'Slovakia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SL', N'Sierra Leone')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SM', N'San Marino')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SN', N'Senegal')
GO
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SO', N'Somalia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SR', N'Suriname')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ST', N'Sao Tome and Principe')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SV', N'El Salvador')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SY', N'Syrian Arab Republic')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'SZ', N'Swaziland')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TC', N'Turks and Caicos Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TD', N'Chad')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TF', N'French Southern Territories')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TG', N'Togo')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TH', N'Thailand')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TJ', N'Tajikistan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TK', N'Tokelau')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TM', N'Turkmenistan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TN', N'Tunisia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TO', N'Tonga')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TP', N'East Timor')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TR', N'Turkey')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TT', N'Trinidad and Tobago')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TV', N'Tuvalu')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TW', N'Taiwan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'TZ', N'Tanzania, United Republic of')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'UA', N'Ukraine')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'UG', N'Uganda')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'UM', N'United States Minor Outlying Islands')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'US', N'United States')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'UY', N'Uruguay')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'UZ', N'Uzbekistan')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VA', N'Holy See (Vatican City State)')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VC', N'Saint Vincent and the Grenadines')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VE', N'Venezuela')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VG', N'Virgin Islands, British')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VI', N'Virgin Islands, U.S.')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VN', N'Vietnam')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'VU', N'Vanuatu')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'WF', N'Wallis and Futuna')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'WS', N'Samoa')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'YE', N'Yemen')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'YT', N'Mayotte')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ZA', N'South Africa')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ZM', N'Zambia')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ZR', N'Zaire')
INSERT [dbo].[Countries] ([CountryCode], [Name]) VALUES (N'ZW', N'Zimbabwe')
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (2, N'Hotel Artemide2', 1, N'ES')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (3, N'H10 Madison', 4, N'FI')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (4, N'A Room With A View', 3, N'ES')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (5, N'Hotel Rec Barcelona', 5, N'ES')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (6, N'Aydinli Cave Hotel', 2, N'ES')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (7, N'Titanic Business Kartal', 3, N'ES')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (8, N'Amber Design Residence', 3, N'FI')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (9, N'Hotel Al Ponte Mocenigo', 5, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (10, N'La Cachette', 4, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (11, N'Celsus 8outique Hotel', 3, N'GB')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (12, N'Ashford Castle', 2, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (13, N'Agarta Cave Hotel', 5, N'GB')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (14, N'Sofitel Grand Sopot', 5, N'FI')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (15, N'Grand Resort Bad Ragaz', 4, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (16, N'Kelebek Special Cave Hotel', 5, N'GB')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (17, N'A Room With A View', 3, N'GB')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (18, N'Aren Cave Hotel & Art Gallery', 5, N'GE')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (19, N'Castle Hotel Auf Schoenburg', 3, N'GE')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (20, N'Lawton & Lauriston Court Hotel', 5, N'GB')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (21, N'El if Hanim Hotel & Spa', 3, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (22, N'Boutique Hotel Sierra de Alicante', 3, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (23, N'Van der Valk Hotel Hoorn', 4, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (24, N'Up Hotel', 5, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (25, N'Dere Suites', 5, N'FI')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (26, N'Park Dedeman Trabzon', 3, N'RU')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (27, N'Duven Hotel', 5, N'FI')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (28, N'Bandholm Hotel', 2, N'GE')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (29, N'Boutique Hotel El Cresol', 4, N'HR')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (30, N'Perimasali Cave Hotel - Cappadocia', 3, N'HR')
INSERT [dbo].[Hotel] ([HotelID], [Name], [Stars], [CountryCode]) VALUES (31, N'Gul Konaklari -Sinasos Rose Mansio', 5, N'HR')
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
INSERT [dbo].[Role] ([ID], [Title]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (2, N'Manager')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (3, N'Karabchikov')
GO
SET IDENTITY_INSERT [dbo].[Tours] ON 

INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (1, 127, N'?????????? ????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Болгарское наследие.png', CAST(35700.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (2, 92, N'????????? ??????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Волшебный Восток.png', CAST(77100.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (3, 72, N'????? ? ???????? ?????????
', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Город с большими амбициями.png', CAST(93300.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (4, 143, N'????? ??????? ?????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Город четырех ворот.png', CAST(72500.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (5, 34, N'??????? ????? ????? ? ?????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Горячий отдых зимой и летом.png', CAST(31900.00 AS Decimal(10, 2)), N'0               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (6, 43, N'??????? ?????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Древний Минск.png', CAST(74900.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (7, 224, N'????????? ??????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Жемчужина Татарстана.png', CAST(65100.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (8, 283, N'???????????. ?????????''', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Знакомьтесь. Амстердам''.png', CAST(68300.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (9, 204, N'?? ?????? ? ?????????? ??????? ??????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Из Алании к загадочным пещерам Алтынбешик.png', CAST(55900.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (10, 215, N'?????????? ?????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Многоликий Сувон.png', CAST(62200.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (11, 30, N'?????? ???????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Москва поэтическая.png', CAST(53200.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (12, 250, N'???????????? ????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Незабываемый Дели.png', CAST(22500.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (13, 51, N'????? ?? ??????? ???????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Отдых на райском острове.png', CAST(30900.00 AS Decimal(10, 2)), N'0               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (14, 60, N'?? ??????? ???????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\По старому Таллину.png', CAST(28800.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (15, 120, N'?????????? ??????? ??????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Прекрасные острова Греции.png', CAST(53700.00 AS Decimal(10, 2)), N'0               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (16, 101, N'????????? ????? ????? ? ????????? ??????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Романтика белых ночей и разводных мостов.png', CAST(54900.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (17, 161, N'', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Свидание с Хельсинки.png', CAST(49100.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (18, 99, N'?????? ?????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Сердце Ирана.png', CAST(71400.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (19, 25, N'?????? ???????? ???????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Сердце Северной Карелии.png', CAST(62000.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (20, 38, N'?????? ?????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Старый город.png', CAST(25600.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (21, 292, N'??????? ?????? ???????? ????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Столица страны Утренней Свежести.png', CAST(27600.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (22, 223, N'?????? ????????? ????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Страна идеальной гармонии.png', CAST(28700.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (23, 286, N'?????? ???????????? ??????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Страна удивительных контрастов.png', CAST(50900.00 AS Decimal(10, 2)), N'0               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (24, 22, N'??????????????? ????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Урбанистическая Бразилия.png', CAST(80900.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (25, 115, N'??????? ????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Финская крепость.png', CAST(70700.00 AS Decimal(10, 2)), N'1               ')
INSERT [dbo].[Tours] ([TourID], [ValueOfTickets], [Name], [ImagePreview], [Price], [IsActual]) VALUES (26, 289, N'??????? ?????????', N'C:\Users\Администратор\Downloads\Demoekzamen-main\0 WorldSkills\6_Working with unstructured data\Tours Photo\Финский романтизм.png', CAST(93600.00 AS Decimal(10, 2)), N'1               ')
SET IDENTITY_INSERT [dbo].[Tours] OFF
GO
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (1, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (1, 26)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (1, 27)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (2, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (2, 27)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (3, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (3, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (3, 29)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (4, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (4, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (4, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (5, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (5, 26)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (6, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (6, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (6, 29)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (6, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (6, 33)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (7, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (7, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (7, 32)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (8, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (8, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (9, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (9, 27)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (9, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (9, 29)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (9, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (10, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (10, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (11, 32)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (11, 33)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (12, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (12, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (13, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (13, 27)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (14, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (14, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (14, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (15, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (16, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (16, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (16, 32)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (17, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (17, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (18, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (18, 29)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (18, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (19, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (19, 34)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (20, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (20, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (20, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (21, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (22, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (22, 26)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (23, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (23, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (23, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (23, 33)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (24, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (24, 27)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (24, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (25, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (25, 28)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (25, 30)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (25, 31)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (26, 25)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (26, 29)
INSERT [dbo].[TourTypes] ([TourID], [TypeID]) VALUES (26, 34)
GO
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (25, N'????????????? ?????? ', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (26, N'???????-??????????????? ???? ', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (27, N'??????? ????', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (28, N'????????????? ???? ', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (29, N'???????????? ????????????? ???????? ?? ??????', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (30, N'?????????-???????????? ????', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (31, N'?????????????????? ??????? ???? ', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (32, N'?????????? ?????? ', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (33, N'?????????????????? ??????? ????', NULL)
INSERT [dbo].[Types] ([TypeID], [Name], [Description]) VALUES (34, N'??????????? ???????', NULL)
SET IDENTITY_INSERT [dbo].[Types] OFF
GO
INSERT [dbo].[User] ([ID], [Login], [RoleID], [Password], [photo]) VALUES (1, N'Vesemir', 1, N'umer123', N'\Resources\userphoto.png')
INSERT [dbo].[User] ([ID], [Login], [RoleID], [Password], [photo]) VALUES (2, N'TrissMerigold', 2, N'triss123', N'\Resources\trissavatar.png')
INSERT [dbo].[User] ([ID], [Login], [RoleID], [Password], [photo]) VALUES (3, N'test', 3, N'test', N'\Resources\userphoto.png')
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Countries] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([CountryCode])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Countries]
GO
ALTER TABLE [dbo].[HotelImage]  WITH CHECK ADD  CONSTRAINT [FK_HotelImage_Hotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[HotelImage] CHECK CONSTRAINT [FK_HotelImage_Hotel]
GO
ALTER TABLE [dbo].[TourHotel]  WITH CHECK ADD  CONSTRAINT [FK_TourHotel_Hotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[TourHotel] CHECK CONSTRAINT [FK_TourHotel_Hotel]
GO
ALTER TABLE [dbo].[TourHotel]  WITH CHECK ADD  CONSTRAINT [FK_TourHotel_Tours] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([TourID])
GO
ALTER TABLE [dbo].[TourHotel] CHECK CONSTRAINT [FK_TourHotel_Tours]
GO
ALTER TABLE [dbo].[TourTypes]  WITH CHECK ADD  CONSTRAINT [FK_TourTypes_Tours] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([TourID])
GO
ALTER TABLE [dbo].[TourTypes] CHECK CONSTRAINT [FK_TourTypes_Tours]
GO
ALTER TABLE [dbo].[TourTypes]  WITH CHECK ADD  CONSTRAINT [FK_TourTypes_Types] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Types] ([TypeID])
GO
ALTER TABLE [dbo].[TourTypes] CHECK CONSTRAINT [FK_TourTypes_Types]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [WitcherToursDB] SET  READ_WRITE 
GO
