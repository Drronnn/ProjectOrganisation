USE [master]
GO
/****** Object:  Database [ProjectManagementDB]    Script Date: 28.11.2023 0:27:27 ******/
CREATE DATABASE [ProjectManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Проектная организация', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Проектная организация.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Проектная организация_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Проектная организация_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectManagementDB] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProjectManagementDB]
GO
/****** Object:  StoredProcedure [dbo].[AA]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AA]
AS
BEGIN
	SELECT p.Название, z.[ФИО] FROM Проект p JOIN Договор d on p.[Код договора]=d.[Код договора] JOIN Заказчик z on z.[Код заказчика]=d.[Код заказчика]

END;

GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[Id] [int] NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
	[ProjectCount] [int] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] NOT NULL,
	[ContractId] [int] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] NOT NULL,
	[TaskStatusId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 28.11.2023 0:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Administrator] ([Id], [FIO], [Login], [Password]) VALUES (1, N'Баженов Андрей Алексеевич', N'admin', N'12345')
INSERT [dbo].[Administrator] ([Id], [FIO], [Login], [Password]) VALUES (2, N'Рогов Тесей Викторович', N'adminrog', N'122333')
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (1, 1, CAST(0x60430B00 AS Date), CAST(0xA9430B00 AS Date), 32000.0000, 3)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (2, 2, CAST(0x7B430B00 AS Date), CAST(0x9A430B00 AS Date), 16500.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (3, 3, CAST(0x7D430B00 AS Date), CAST(0x7C430B00 AS Date), 17000.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (4, 4, CAST(0x81430B00 AS Date), CAST(0x85430B00 AS Date), 9000.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (5, 5, CAST(0x84430B00 AS Date), CAST(0x85430B00 AS Date), 2500.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (6, 6, CAST(0x57440C00 AS Date), CAST(0x8A430B00 AS Date), 6700.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (7, 7, CAST(0x8B430B00 AS Date), CAST(0xA5430B00 AS Date), 41100.0000, 2)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (8, 2, CAST(0x8C430B00 AS Date), CAST(0xA2430B00 AS Date), 67900.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (9, 6, CAST(0x93430B00 AS Date), CAST(0xFF430B00 AS Date), 112000.0000, 2)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (10, 1, CAST(0x67440C00 AS Date), CAST(0xB4430B00 AS Date), 56000.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (11, 1, CAST(0xAB440B00 AS Date), CAST(0xAB440B00 AS Date), 44.0000, 2)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (12, 1, CAST(0xAB440B00 AS Date), CAST(0xAB440B00 AS Date), 33.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (13, 1, CAST(0xAB440B00 AS Date), CAST(0xAB440B00 AS Date), 324.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (14, 1, CAST(0x9B440B00 AS Date), CAST(0xAB440B00 AS Date), 96000.0000, 2)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (15, 1, CAST(0xB0440B00 AS Date), CAST(0xB0440B00 AS Date), 86400.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (16, 1, CAST(0xB9440B00 AS Date), CAST(0xC5440B00 AS Date), 49000.0000, 1)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (17, 16, CAST(0x22460B00 AS Date), CAST(0x3F460B00 AS Date), 59000.0000, 5)
INSERT [dbo].[Contract] ([Id], [CustomerId], [StartDate], [EndDate], [Price], [ProjectCount]) VALUES (18, 14, CAST(0x22460B00 AS Date), CAST(0x6C460B00 AS Date), 72000.0000, 7)
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (1, N'Баженов Андрей Алексеевич', N'Иваново')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (2, N'Левиков Михаил Васильевич', N'Иваново')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (3, N'Васнецов Юрий Михайлович', N'Владимир')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (4, N'Григорьев Григорий Юрьевич', N'Шуя')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (5, N'Лыськов Валерий Григорьевич ', N'Москва ')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (6, N'Печирикин Максим Валерьевич', N'Иваново')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (7, N'Люблин Кантемир Антонович', N'Вологда')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (8, N'Хармоникин Василий Кантемирович', N'Архангельск')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (9, N'Ребров Савелий Васильевич', N'Кохма')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (10, N'Минин Роман Савельевич', N'Иваново')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (11, N'Лобов Матвей Романович', N'Москва')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (12, N'Митряшов Елисей Матвеевич', N'Иваново')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (13, N'Грубов Рамзан Елисеевич', N'Кохма')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (14, N'Окошкин Егор Рамзанович', N'Тейково')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (15, N'Лукошкин Юлий Егорьевич', N'Санкт-Петербург')
INSERT [dbo].[Customer] ([Id], [FIO], [City]) VALUES (16, N'Кувырков Геннадий Васильевич', N'Пенза')
INSERT [dbo].[Department] ([Id], [Name], [Phone]) VALUES (11, N'Программисты', N'8-(4932)-22-91-18')
INSERT [dbo].[Department] ([Id], [Name], [Phone]) VALUES (12, N'Бухгалтерия', N'8-(4932)-11-91-11')
INSERT [dbo].[Department] ([Id], [Name], [Phone]) VALUES (13, N'Отдел продаж', N'8-(4932)-11-11-32')
INSERT [dbo].[Department] ([Id], [Name], [Phone]) VALUES (14, N'Отдел кадров', N'8-(4932)-15-15-15')
INSERT [dbo].[Department] ([Id], [Name], [Phone]) VALUES (15, N'Отдел кадров', N'8-(4932)-90-50-15')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (1, N'Васильев Григорий Васильевич', 11, N'vgv', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (2, N'Юрьев Максим Львович', 15, N'yml', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (3, N'Курилов Кирилл Решетович', 13, N'kkr', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (4, N'Круглов Виктор Сергеевич', 14, N'kvs', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (5, N'Раков Галилей Георгиевич', 12, N'rgg', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (6, N'Крабов Матвей Иванович', 11, N'kmi', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (7, N'Левов Ростислав Елисеевич', 11, N'lre', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (8, N'Правов Сергей Елисеевич', 11, N'pse', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (9, N'Кульков Михаил Сергеевич', 12, N'kms', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (10, N'Римкин Роман Каримович', 11, N'rrk', N'54321')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (11, N'grbrth', 13, N'grbrth11', N'U!OS79')
INSERT [dbo].[Employee] ([Id], [FIO], [DepartmentId], [Login], [Password]) VALUES (12, N'Гарбов Виктор Викторович', 11, N'Гарбов12', N'eOsEtT')
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (1, 13, N'Мисс и Леди Интеграция                            ', CAST(0x60430B00 AS Date), CAST(0xB3430B00 AS Date), 32000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (2, 15, N'Сельский Клуб Палеодеревня                        ', CAST(0x7B430B00 AS Date), CAST(0x9A430B00 AS Date), 16500.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (3, 1, N'Обрети крылья вместе с нами                       ', CAST(0x7D430B00 AS Date), CAST(0x86430B00 AS Date), 17000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (4, 1, N'Школа зооволонтера                                ', CAST(0x81430B00 AS Date), CAST(0x85430B00 AS Date), 9000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (5, 5, N'Вода - безопасная среда                           ', CAST(0x84430B00 AS Date), CAST(0x85430B00 AS Date), 2500.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (6, 6, N'Фасадник                                          ', CAST(0x88430B00 AS Date), CAST(0x8A430B00 AS Date), 6700.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (7, 7, N'По следам древнего человека                       ', CAST(0x8B430B00 AS Date), CAST(0x98430B00 AS Date), 16100.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (8, 7, N'Круг доверия                                      ', CAST(0x8B430B00 AS Date), CAST(0xA5430B00 AS Date), 25000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (9, 8, N'Тунцуют все!                                      ', CAST(0x8C430B00 AS Date), CAST(0x94430B00 AS Date), 17900.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (10, 8, N'Открытая палуба                                   ', CAST(0x8C430B00 AS Date), CAST(0x9A430B00 AS Date), 24000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (11, 8, N'МультиЛето                                        ', CAST(0x8C430B00 AS Date), CAST(0xA2430B00 AS Date), 26000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (12, 9, N'Лето на заводе                                    ', CAST(0x93430B00 AS Date), CAST(0xFF430B00 AS Date), 72000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (13, 9, N'Кукарача                                          ', CAST(0xEC430B00 AS Date), CAST(0xFF430B00 AS Date), 40000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (14, 10, N'Школа дальневосточной рыбалки                     ', CAST(0x98430B00 AS Date), CAST(0xB4430B00 AS Date), 56000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (15, 9, N'Помидорка                                         ', CAST(0xB0440B00 AS Date), CAST(0xB0440B00 AS Date), 89000.0000)
INSERT [dbo].[Project] ([Id], [ContractId], [Name], [StartDate], [EndDate], [Price]) VALUES (16, 3, N'Новый проект                                      ', CAST(0x22460B00 AS Date), CAST(0x43460B00 AS Date), 15000.0000)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (1, 1, 1, N'sghdtg', N'Главная стр.', 1)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (2, 1, 7, N'sgs', N'Обратн. связь', 2)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (3, 2, 6, N'sdgdrg', N'Ан. данных', 9)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (4, 3, 7, N'dsgd', N'Сценарий', 5)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (5, 4, 5, N'sgdgg', N'Съемка/монтаж', 10)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (6, 4, 7, N'thhfnhg', N'Анал. этапов', 3)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (7, 4, 3, N'dfvd', N'Оптимизация', 2)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (8, 2, 9, N'nbgnb', N'Внедрение сист.', 4)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (9, 3, 10, N'Сценарий для ролика', N'Сценарий ', 3)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (10, 4, 7, N'vbvb', N'Интерфейс', 4)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (11, 2, 10, N'erretnht6uyntyn', N'Тестирование', 7)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (12, 2, 6, N'hfth', N'Лит. обзор', 10)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (13, 3, 6, N'gnghngh', N'Сбор данных', 8)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (14, 3, 7, N'fsfddfds', N'Доп. задача', 3)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (15, 4, 3, N'erwetet', N'Новая задача', 6)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (16, 2, 4, N'Новая задача Новая задача1', N'План прил.', 2)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (17, 2, 1, N'dfgdr', N'Нов. зад.', 1)
INSERT [dbo].[Task] ([Id], [TaskStatusId], [ProjectId], [Description], [Title], [EmployeeId]) VALUES (18, 2, 1, N'Тестирование', N'Новая задача', 4)
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (1, N'ToDo')
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (2, N'Progress')
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (3, N'Test')
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (4, N'Complete')
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (5, N'Removed')
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Customer]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Contract]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskStatus] FOREIGN KEY([TaskStatusId])
REFERENCES [dbo].[TaskStatus] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskStatus]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagementDB] SET  READ_WRITE 
GO
