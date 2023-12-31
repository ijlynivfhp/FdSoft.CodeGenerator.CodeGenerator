USE [master]
GO
/****** Object:  Database [FdSoft.CodeGenerator]    Script Date: 2022/11/10 9:24:11 ******/
CREATE DATABASE [FdSoft.CodeGenerator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FdSoft.CodeGenerator', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FdSoft.CodeGenerator.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FdSoft.CodeGenerator_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FdSoft.CodeGenerator_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FdSoft.CodeGenerator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ARITHABORT OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET RECOVERY FULL 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET  MULTI_USER 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET QUERY_STORE = OFF
GO
USE [FdSoft.CodeGenerator]
GO
/****** Object:  Table [dbo].[article]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](254) NULL,
	[content] [text] NULL,
	[userId] [bigint] NULL,
	[status] [varchar](20) NULL,
	[fmt_type] [varchar](20) NULL,
	[tags] [varchar](100) NULL,
	[hits] [int] NULL,
	[category_id] [int] NULL,
	[createTime] [datetime] NULL,
	[updateTime] [datetime] NULL,
	[authorName] [varchar](20) NULL,
	[coverUrl] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[articleCategory]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleCategory](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[create_time] [datetime] NULL,
	[parentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_demo]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_demo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
	[icon] [varchar](255) NULL,
	[showStatus] [int] NOT NULL,
	[addTime] [datetime] NULL,
	[sex] [int] NULL,
	[sort] [int] NULL,
	[beginTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[remark] [varchar](200) NULL,
	[feature] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_table]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_table](
	[tableId] [bigint] IDENTITY(1,1) NOT NULL,
	[tableName] [varchar](200) NULL,
	[tableComment] [varchar](500) NULL,
	[subTableName] [varchar](64) NULL,
	[subTableFkName] [varchar](64) NULL,
	[className] [varchar](100) NULL,
	[tplCategory] [varchar](200) NULL,
	[baseNameSpace] [varchar](100) NULL,
	[moduleName] [varchar](30) NULL,
	[businessName] [varchar](30) NULL,
	[functionName] [varchar](50) NULL,
	[functionAuthor] [varchar](50) NULL,
	[genType] [varchar](1) NULL,
	[genPath] [varchar](200) NULL,
	[options] [varchar](1000) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_Time] [datetime] NULL,
	[remark] [varchar](500) NULL,
	[dbName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[tableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_table_column]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_table_column](
	[columnId] [bigint] IDENTITY(1,1) NOT NULL,
	[tableId] [bigint] NULL,
	[tableName] [varchar](200) NULL,
	[columnName] [varchar](200) NULL,
	[columnComment] [varchar](500) NULL,
	[columnType] [varchar](100) NULL,
	[csharpType] [varchar](500) NULL,
	[csharpField] [varchar](200) NULL,
	[isPk] [tinyint] NULL,
	[isIncrement] [tinyint] NULL,
	[isRequired] [tinyint] NULL,
	[isInsert] [tinyint] NULL,
	[isEdit] [tinyint] NULL,
	[isList] [tinyint] NULL,
	[isSort] [tinyint] NULL,
	[isQuery] [tinyint] NULL,
	[queryType] [varchar](200) NULL,
	[htmlType] [varchar](200) NULL,
	[dictType] [varchar](200) NULL,
	[sort] [int] NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[columnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_common_lang]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_common_lang](
	[id] [bigint] NOT NULL,
	[lang_code] [varchar](10) NOT NULL,
	[lang_key] [nvarchar](100) NULL,
	[lang_name] [nvarchar](2000) NOT NULL,
	[addtime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_config]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_config](
	[configId] [int] IDENTITY(1,1) NOT NULL,
	[configName] [varchar](100) NULL,
	[configKey] [varchar](100) NULL,
	[configValue] [varchar](500) NULL,
	[configType] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[configId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_dept]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_dept](
	[deptId] [bigint] IDENTITY(100,1) NOT NULL,
	[parentId] [bigint] NULL,
	[ancestors] [varchar](50) NULL,
	[deptName] [varchar](30) NULL,
	[orderNum] [int] NULL,
	[leader] [varchar](20) NULL,
	[phone] [varchar](11) NULL,
	[email] [varchar](50) NULL,
	[status] [varchar](1) NULL,
	[delFlag] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[deptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_dict_data]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_dict_data](
	[dictCode] [bigint] IDENTITY(1,1) NOT NULL,
	[dictSort] [int] NULL,
	[dictLabel] [varchar](100) NULL,
	[dictValue] [varchar](100) NULL,
	[dictType] [varchar](100) NULL,
	[cssClass] [varchar](100) NULL,
	[listClass] [varchar](100) NULL,
	[isDefault] [varchar](1) NULL,
	[status] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[dictCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_dict_type]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_dict_type](
	[dictId] [bigint] IDENTITY(1,1) NOT NULL,
	[dictName] [varchar](100) NULL,
	[dictType] [varchar](100) NULL,
	[status] [varchar](1) NULL,
	[type] [varchar](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
	[customSql] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[dictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_file]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_file](
	[id] [bigint] NOT NULL,
	[realName] [varchar](50) NULL,
	[fileName] [varchar](50) NULL,
	[fileUrl] [varchar](500) NULL,
	[storePath] [varchar](50) NULL,
	[accessUrl] [varchar](300) NULL,
	[fileSize] [varchar](20) NULL,
	[fileType] [varchar](200) NULL,
	[fileExt] [varchar](10) NULL,
	[create_by] [varchar](50) NULL,
	[create_time] [datetime] NULL,
	[storeType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_logininfor]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_logininfor](
	[infoId] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](50) NULL,
	[ipaddr] [varchar](50) NULL,
	[loginLocation] [varchar](255) NULL,
	[browser] [varchar](50) NULL,
	[os] [varchar](50) NULL,
	[status] [char](1) NULL,
	[msg] [varchar](255) NULL,
	[loginTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[infoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_menu]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_menu](
	[menuId] [bigint] IDENTITY(1,1) NOT NULL,
	[menuName] [varchar](50) NOT NULL,
	[parentId] [bigint] NULL,
	[orderNum] [int] NULL,
	[path] [varchar](200) NULL,
	[component] [varchar](255) NULL,
	[isFrame] [int] NULL,
	[isCache] [int] NULL,
	[menuType] [char](1) NULL,
	[visible] [char](1) NULL,
	[status] [char](1) NULL,
	[perms] [varchar](100) NULL,
	[icon] [varchar](100) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
	[menuName_key] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[menuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_notice]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_notice](
	[notice_id] [int] IDENTITY(1,1) NOT NULL,
	[notice_title] [varchar](100) NULL,
	[notice_type] [char](1) NULL,
	[notice_content] [text] NULL,
	[status] [char](1) NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[notice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_oper_log]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_oper_log](
	[operId] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[businessType] [int] NULL,
	[method] [varchar](100) NULL,
	[requestMethod] [varchar](10) NULL,
	[operatorType] [int] NULL,
	[operName] [varchar](50) NULL,
	[deptName] [varchar](50) NULL,
	[operUrl] [varchar](255) NULL,
	[operIP] [varchar](50) NULL,
	[operLocation] [varchar](255) NULL,
	[operParam] [varchar](2000) NULL,
	[jsonResult] [varchar](max) NULL,
	[status] [int] NULL,
	[errorMsg] [varchar](2000) NULL,
	[operTime] [datetime] NULL,
	[elapsed] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[operId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_post]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_post](
	[postId] [bigint] IDENTITY(1,1) NOT NULL,
	[postCode] [varchar](64) NOT NULL,
	[postName] [varchar](50) NOT NULL,
	[postSort] [int] NOT NULL,
	[status] [varchar](1) NOT NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_role]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_role](
	[roleId] [bigint] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](30) NOT NULL,
	[roleKey] [varchar](100) NOT NULL,
	[roleSort] [int] NOT NULL,
	[dataScope] [varchar](1) NULL,
	[menu_check_strictly] [int] NULL,
	[dept_check_strictly] [int] NOT NULL,
	[status] [char](1) NOT NULL,
	[delFlag] [char](1) NOT NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_role_dept]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_role_dept](
	[roleId] [bigint] NOT NULL,
	[deptId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_role_menu]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_role_menu](
	[role_id] [bigint] NOT NULL,
	[menu_id] [bigint] NOT NULL,
	[create_by] [varchar](20) NULL,
	[create_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_tasks]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_tasks](
	[id] [varchar](100) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[jobGroup] [varchar](255) NOT NULL,
	[cron] [varchar](255) NOT NULL,
	[assemblyName] [varchar](255) NOT NULL,
	[className] [varchar](255) NOT NULL,
	[remark] [varchar](200) NULL,
	[runTimes] [int] NOT NULL,
	[beginTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[triggerType] [int] NOT NULL,
	[intervalSecond] [int] NOT NULL,
	[isStart] [int] NOT NULL,
	[jobParams] [text] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[create_by] [varchar](50) NULL,
	[update_by] [varchar](50) NULL,
	[lastRunTime] [datetime] NULL,
	[taskType] [int] NULL,
	[apiUrl] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_tasks_log]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_tasks_log](
	[jobLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[jobId] [varchar](20) NOT NULL,
	[jobName] [varchar](64) NOT NULL,
	[jobGroup] [varchar](64) NOT NULL,
	[jobMessage] [varchar](500) NULL,
	[status] [varchar](1) NULL,
	[exception] [varchar](2000) NULL,
	[createTime] [datetime] NULL,
	[invokeTarget] [varchar](200) NULL,
	[elapsed] [decimal](10, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[jobLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_user]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_user](
	[userId] [bigint] IDENTITY(1,1) NOT NULL,
	[deptId] [bigint] NULL,
	[userName] [varchar](30) NOT NULL,
	[nickName] [varchar](30) NOT NULL,
	[userType] [varchar](2) NULL,
	[email] [varchar](50) NULL,
	[phonenumber] [varchar](11) NULL,
	[sex] [varchar](1) NULL,
	[avatar] [varchar](400) NULL,
	[password] [varchar](100) NOT NULL,
	[status] [varchar](1) NULL,
	[delFlag] [varchar](1) NULL,
	[loginIP] [varchar](50) NULL,
	[loginDate] [datetime] NULL,
	[create_by] [varchar](64) NULL,
	[create_time] [datetime] NULL,
	[update_by] [varchar](64) NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_user_post]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_user_post](
	[userId] [bigint] NOT NULL,
	[postId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_user_role]    Script Date: 2022/11/10 9:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_user_role](
	[user_id] [bigint] NOT NULL,
	[role_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[articleCategory] ON 
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (1, N'C#', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 0)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (2, N'java', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 0)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (3, N'前端', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 0)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (4, N'数据库', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 0)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (5, N'其他', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 0)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (6, N'c++', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 5)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (7, N'vue', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 3)
GO
INSERT [dbo].[articleCategory] ([category_id], [name], [create_time], [parentId]) VALUES (8, N'sqlserver', CAST(N'2022-11-05T14:23:12.460' AS DateTime), 4)
GO
SET IDENTITY_INSERT [dbo].[articleCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[gen_table] ON 
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (1, N'JC_Corporation', N'企业、项目信息表，包含关联层级', NULL, NULL, N'JCCorporation', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCCorporation', N'企业、项目信息表，包含关联层级', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jccorporation","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:18:46.153' AS DateTime), N'admin', CAST(N'2022-11-07T11:16:45.030' AS DateTime), NULL, N'LaborSys')
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (2, N'JC_Project', N'项目信息', NULL, NULL, N'JCProject', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCProject', N'项目信息', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jcproject","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:18:46.327' AS DateTime), N'admin', CAST(N'2022-11-07T11:16:26.337' AS DateTime), NULL, N'LaborSys')
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (3, N'JC_PowerItem', N'角色菜单', NULL, NULL, N'JCPowerItem', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCPowerItem', N'角色菜单', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jcpoweritem","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:18:46.470' AS DateTime), N'admin', CAST(N'2022-11-07T11:16:09.540' AS DateTime), NULL, N'LaborSys')
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (4, N'JC_Role', N'用户角色信息', NULL, NULL, N'JCRole', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCRole', N'角色信息', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jcrole","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:18:46.593' AS DateTime), N'admin', CAST(N'2022-11-07T11:15:51.857' AS DateTime), NULL, N'LaborSys')
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (5, N'JC_User', N'用户表', NULL, NULL, N'JCUser', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCUser', N'用户表', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jcuser","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:19:02.600' AS DateTime), N'admin', CAST(N'2022-11-07T11:15:31.133' AS DateTime), NULL, N'LaborSys')
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (6, N'JC_UserCorporation', N'企业项目用户关联信息', NULL, NULL, N'JCUserCorporation', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCUserCorporation', N'企业项目用户关联信息', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jcusercorporation","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:19:02.727' AS DateTime), N'admin', CAST(N'2022-11-07T11:14:48.187' AS DateTime), NULL, N'LaborSys')
GO
INSERT [dbo].[gen_table] ([tableId], [tableName], [tableComment], [subTableName], [subTableFkName], [className], [tplCategory], [baseNameSpace], [moduleName], [businessName], [functionName], [functionAuthor], [genType], [genPath], [options], [create_by], [create_time], [update_by], [update_Time], [remark], [dbName]) VALUES (7, N'JC_UserRole', N'用户角色关联表', NULL, NULL, N'JCUserRole', N'crud', N'FdSoft.CodeGenerator.', N'Base', N'JCUserRole', N'用户角色关联表', N'admin', N'1', N'E:\Work\Generater', N'{"ParentMenuId":0,"SortType":"asc","SortField":"","TreeCode":"","TreeName":"","TreeParentCode":"","PermissionPrefix":"business:jcuserrole","CheckedBtn":[1,2,3],"ColNum":12,"GenerateRepo":1}', N'admin', CAST(N'2022-11-07T09:19:02.837' AS DateTime), N'admin', CAST(N'2022-11-07T11:14:34.193' AS DateTime), NULL, N'LaborSys')
GO
SET IDENTITY_INSERT [dbo].[gen_table] OFF
GO
SET IDENTITY_INSERT [dbo].[gen_table_column] ON 
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (1, 1, N'JC_Corporation', N'coId', N'', N'int', N'int', N'CoId', 1, 1, 1, 0, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (2, 1, N'JC_Corporation', N'parentCoId', N'', N'int', N'int', N'ParentCoId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (3, 1, N'JC_Corporation', N'rootCoId', N'所属根组织ID（单位ID）', N'int', N'int', N'RootCoId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (4, 1, N'JC_Corporation', N'itemPath', N'', N'nvarchar', N'string', N'ItemPath', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (5, 1, N'JC_Corporation', N'status', N'0正常，1锁定', N'int', N'int', N'Status', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (6, 1, N'JC_Corporation', N'coType', N'0组织（公司），1项目部，2子组织（子公司）', N'int', N'int', N'CoType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (7, 1, N'JC_Corporation', N'coName', N'', N'nvarchar', N'string', N'CoName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (8, 1, N'JC_Corporation', N'corpCode', N'参建企业统一社会信用代码
', N'nvarchar', N'string', N'CorpCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (9, 1, N'JC_Corporation', N'areaCode', N'注册地区', N'nvarchar', N'string', N'AreaCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (10, 1, N'JC_Corporation', N'proId', N'如果是项目部，proid对应项目表', N'uniqueidentifier', N'string', N'ProId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (11, 1, N'JC_Corporation', N'contactMan', N'', N'nvarchar', N'string', N'ContactMan', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (12, 1, N'JC_Corporation', N'contactManTel', N'', N'nvarchar', N'string', N'ContactManTel', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (13, 1, N'JC_Corporation', N'legalMan', N'法人代表', N'nvarchar', N'string', N'LegalMan', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (14, 1, N'JC_Corporation', N'legalManTel', N'法人电话', N'nvarchar', N'string', N'LegalManTel', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (15, 1, N'JC_Corporation', N'unitLevel', N'资质等级', N'nvarchar', N'string', N'UnitLevel', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (16, 1, N'JC_Corporation', N'unitPhone', N'单位电话', N'nvarchar', N'string', N'UnitPhone', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (17, 1, N'JC_Corporation', N'fax', N'传真号', N'nvarchar', N'string', N'Fax', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (18, 1, N'JC_Corporation', N'webUrl', N'组织机构网址', N'nvarchar', N'string', N'WebUrl', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'imageUpload', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (19, 1, N'JC_Corporation', N'address', N'', N'nvarchar', N'string', N'Address', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (20, 1, N'JC_Corporation', N'remark', N'备注信息', N'nvarchar', N'string', N'Remark', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (21, 1, N'JC_Corporation', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (22, 1, N'JC_Corporation', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (23, 1, N'JC_Corporation', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (24, 1, N'JC_Corporation', N'creator', N'记录创建人姓名', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (25, 1, N'JC_Corporation', N'deleteStatus', N'0正常，1删除', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (26, 1, N'JC_Corporation', N'addTime', N'', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (27, 1, N'JC_Corporation', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.273' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (28, 2, N'JC_Project', N'proId', N'', N'uniqueidentifier', N'string', N'ProId', 1, 0, 1, 1, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (29, 2, N'JC_Project', N'proNo', N'', N'nvarchar', N'string', N'ProNo', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (30, 2, N'JC_Project', N'proName', N'', N'nvarchar', N'string', N'ProName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (31, 2, N'JC_Project', N'proSmallName', N'', N'nvarchar', N'string', N'ProSmallName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (32, 2, N'JC_Project', N'status', N'1在建 2竣工', N'int', N'int', N'Status', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (33, 2, N'JC_Project', N'activeStatus', N'1正常，2停工整改', N'int', N'int', N'ActiveStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (34, 2, N'JC_Project', N'progress', N'形象进度', N'nvarchar', N'string', N'Progress', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (35, 2, N'JC_Project', N'proSubType', N'项目子类别', N'nvarchar', N'string', N'ProSubType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (36, 2, N'JC_Project', N'proType', N'项目类别1：房建项目，2：市政项目', N'int', N'int', N'ProType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (37, 2, N'JC_Project', N'areaCode', N'', N'nvarchar', N'string', N'AreaCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (38, 2, N'JC_Project', N'tenderNum', N'中标编号', N'nvarchar', N'string', N'TenderNum', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (39, 2, N'JC_Project', N'regNumber', N'', N'nvarchar', N'string', N'RegNumber', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (40, 2, N'JC_Project', N'regDate', N'', N'datetime', N'DateTime', N'RegDate', 0, 0, 0, 1, 1, 1, 0, 0, N'BETWEEN', N'datetime', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (41, 2, N'JC_Project', N'proAddress', N'工程地址', N'nvarchar', N'string', N'ProAddress', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (42, 2, N'JC_Project', N'shigongCerNo', N'施工许可证号', N'nvarchar', N'string', N'ShigongCerNo', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (43, 2, N'JC_Project', N'proPrice', N'工程造价（万元）', N'decimal', N'decimal', N'ProPrice', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (44, 2, N'JC_Project', N'proSalaryCost', N'工资性工程款', N'decimal', N'decimal', N'ProSalaryCost', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (45, 2, N'JC_Project', N'beginDate', N'开始时间', N'datetime', N'DateTime', N'BeginDate', 0, 0, 0, 1, 1, 1, 0, 0, N'BETWEEN', N'datetime', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (46, 2, N'JC_Project', N'endDate', N'结束时间', N'datetime', N'DateTime', N'EndDate', 0, 0, 0, 1, 1, 1, 0, 0, N'BETWEEN', N'datetime', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (47, 2, N'JC_Project', N'projectHeight', N'建筑高度', N'decimal', N'decimal', N'ProjectHeight', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (48, 2, N'JC_Project', N'projectFloor', N'层数', N'int', N'int', N'ProjectFloor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (49, 2, N'JC_Project', N'projectFloorInfo', N'格式1,2 表示地上1层，地下2层', N'nvarchar', N'string', N'ProjectFloorInfo', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (50, 2, N'JC_Project', N'projectArea', N'建筑面积', N'decimal', N'decimal', N'ProjectArea', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (51, 2, N'JC_Project', N'projectAreaInfo', N'地上面积,地下面积', N'nvarchar', N'string', N'ProjectAreaInfo', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (52, 2, N'JC_Project', N'projectStruct', N'结构类型', N'nvarchar', N'string', N'ProjectStruct', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (53, 2, N'JC_Project', N'bank', N'开户行', N'nvarchar', N'string', N'Bank', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (54, 2, N'JC_Project', N'mapPos', N'', N'nvarchar', N'string', N'MapPos', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (55, 2, N'JC_Project', N'syncType', N'同步类型（复选值，3=1+2），1全国，2品茗', N'int', N'int', N'SyncType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (56, 2, N'JC_Project', N'shigongUnitCorpCode', N'', N'nvarchar', N'string', N'ShigongUnitCorpCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (57, 2, N'JC_Project', N'shigongUnitName', N'施工单位', N'nvarchar', N'string', N'ShigongUnitName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (58, 2, N'JC_Project', N'jianLiUnitCorpCode', N'', N'nvarchar', N'string', N'JianLiUnitCorpCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (59, 2, N'JC_Project', N'jianLiUnitName', N'监理单位', N'nvarchar', N'string', N'JianLiUnitName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (60, 2, N'JC_Project', N'consUnitCorpCode', N'', N'nvarchar', N'string', N'ConsUnitCorpCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (61, 2, N'JC_Project', N'consUnitName', N'建设单位', N'nvarchar', N'string', N'ConsUnitName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (62, 2, N'JC_Project', N'designUnitCorpCode', N'', N'nvarchar', N'string', N'DesignUnitCorpCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (63, 2, N'JC_Project', N'designUnitName', N'', N'nvarchar', N'string', N'DesignUnitName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (64, 2, N'JC_Project', N'kanchaUnitCorpCode', N'', N'nvarchar', N'string', N'KanchaUnitCorpCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (65, 2, N'JC_Project', N'kanchaUnitName', N'', N'nvarchar', N'string', N'KanchaUnitName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (66, 2, N'JC_Project', N'proManager', N'', N'nvarchar', N'string', N'ProManager', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (67, 2, N'JC_Project', N'jsonData', N'', N'nvarchar', N'string', N'JsonData', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (68, 2, N'JC_Project', N'authStatus', N'授权状态', N'int', N'int', N'AuthStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (69, 2, N'JC_Project', N'authEndDate', N'授权到期时间', N'datetime', N'DateTime', N'AuthEndDate', 0, 0, 0, 1, 1, 1, 0, 0, N'BETWEEN', N'datetime', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (70, 2, N'JC_Project', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (71, 2, N'JC_Project', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (72, 2, N'JC_Project', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (73, 2, N'JC_Project', N'creator', N'', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (74, 2, N'JC_Project', N'deleteStatus', N'', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (75, 2, N'JC_Project', N'addTime', N'', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (76, 2, N'JC_Project', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (77, 2, N'JC_Project', N'projectCode', N'', N'nvarchar', N'string', N'ProjectCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (78, 2, N'JC_Project', N'extPK1', N'', N'nvarchar', N'string', N'ExtPK1', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (79, 2, N'JC_Project', N'hideStatus', N'子系统显示与否，复合值，目前仅用于企业云平台1.   0或者null为正常', N'int', N'int', N'HideStatus', 0, 0, 0, 1, 0, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.417' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (80, 3, N'JC_PowerItem', N'itemId', N'', N'int', N'int', N'ItemId', 1, 1, 1, 0, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (81, 3, N'JC_PowerItem', N'parentId', N'', N'int', N'int', N'ParentId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (82, 3, N'JC_PowerItem', N'itemName', N'菜单名', N'nvarchar', N'string', N'ItemName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (83, 3, N'JC_PowerItem', N'itemCode', N'全表唯一的值，编写代码时，用来进行逻辑判断的。值应形象，如addBeiAnItem,用户不可以更改', N'nvarchar', N'string', N'ItemCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (84, 3, N'JC_PowerItem', N'itemPath', N'父子关系CODE', N'nvarchar', N'string', N'ItemPath', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'textarea', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (85, 3, N'JC_PowerItem', N'itemType', N' 菜单=1,独元=4,操作=5,数据范围=6', N'int', N'int', N'ItemType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (86, 3, N'JC_PowerItem', N'inheritType', N'权限继承方式，主要用于控制数据范围继承限定；0或者null表示弱继承，1表示强继承', N'int', N'int', N'InheritType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (87, 3, N'JC_PowerItem', N'itemValue', N'菜单路径', N'nvarchar', N'string', N'ItemValue', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'textarea', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (88, 3, N'JC_PowerItem', N'productId', N'', N'int', N'int', N'ProductId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (89, 3, N'JC_PowerItem', N'itemUrlLike', N'路径特征值', N'nvarchar', N'string', N'ItemUrlLike', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'imageUpload', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (90, 3, N'JC_PowerItem', N'powerCode', N'权限项标识值', N'nvarchar', N'string', N'PowerCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'textarea', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (91, 3, N'JC_PowerItem', N'orderId', N'排序', N'int', N'int', N'OrderId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (92, 3, N'JC_PowerItem', N'itemIcon1', N'', N'nvarchar', N'string', N'ItemIcon1', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'imageUpload', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (93, 3, N'JC_PowerItem', N'itemIcon2', N'', N'nvarchar', N'string', N'ItemIcon2', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'imageUpload', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (94, 3, N'JC_PowerItem', N'extField1', N'扩展字段1', N'nvarchar', N'string', N'ExtField1', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (95, 3, N'JC_PowerItem', N'extField2', N'扩展字段2', N'nvarchar', N'string', N'ExtField2', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (96, 3, N'JC_PowerItem', N'extField3', N'', N'nvarchar', N'string', N'ExtField3', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (97, 3, N'JC_PowerItem', N'extField4', N'', N'nvarchar', N'string', N'ExtField4', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (98, 3, N'JC_PowerItem', N'extField5', N'', N'nvarchar', N'string', N'ExtField5', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (99, 3, N'JC_PowerItem', N'isSuper', N'', N'int', N'int', N'IsSuper', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (100, 3, N'JC_PowerItem', N'openType', N'', N'int', N'int', N'OpenType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (101, 3, N'JC_PowerItem', N'remark', N'', N'nvarchar', N'string', N'Remark', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'textarea', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (102, 3, N'JC_PowerItem', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (103, 3, N'JC_PowerItem', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (104, 3, N'JC_PowerItem', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (105, 3, N'JC_PowerItem', N'creator', N'记录创建人姓名', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (106, 3, N'JC_PowerItem', N'deleteStatus', N'', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (107, 3, N'JC_PowerItem', N'addTime', N'添加时间', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (108, 3, N'JC_PowerItem', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.547' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (109, 4, N'JC_Role', N'roleId', N'角色主键', N'int', N'int', N'RoleId', 1, 1, 1, 0, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (110, 4, N'JC_Role', N'parentId', N'', N'int', N'int', N'ParentId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (111, 4, N'JC_Role', N'status', N'角色状态,0为正常.', N'int', N'int', N'Status', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (112, 4, N'JC_Role', N'itemPath', N'', N'nvarchar', N'string', N'ItemPath', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (113, 4, N'JC_Role', N'roleName', N'角色名', N'nvarchar', N'string', N'RoleName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (114, 4, N'JC_Role', N'powerCode', N'', N'nvarchar', N'string', N'PowerCode', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'textarea', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (115, 4, N'JC_Role', N'roleType', N'0：全局角色 1：非全局角色(后期企业有自建角色时，全局的就可见可选)', N'int', N'int', N'RoleType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (116, 4, N'JC_Role', N'nodeType', N'节点类型，用于分组,默认0，1为分组（文件夹）', N'int', N'int', N'NodeType', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (117, 4, N'JC_Role', N'productId', N'所属产品ID', N'int', N'int', N'ProductId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (118, 4, N'JC_Role', N'remark', N'', N'nvarchar', N'string', N'Remark', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (119, 4, N'JC_Role', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (120, 4, N'JC_Role', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (121, 4, N'JC_Role', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (122, 4, N'JC_Role', N'creator', N'记录创建人姓名', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (123, 4, N'JC_Role', N'deleteStatus', N'', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (124, 4, N'JC_Role', N'addTime', N'添加时间', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (125, 4, N'JC_Role', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:18:46.663' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (126, 5, N'JC_User', N'userId', N'用户主键', N'int', N'int', N'UserId', 1, 1, 1, 0, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (127, 5, N'JC_User', N'userName', N'用户名,必须是手机号', N'nvarchar', N'string', N'UserName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (128, 5, N'JC_User', N'userPwd', N'用户密码', N'nvarchar', N'string', N'UserPwd', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (129, 5, N'JC_User', N'trueName', N'真实姓名', N'nvarchar', N'string', N'TrueName', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (130, 5, N'JC_User', N'status', N'0正常，1锁定', N'int', N'int', N'Status', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (131, 5, N'JC_User', N'sex', N'性别', N'nvarchar', N'string', N'Sex', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'select', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (132, 5, N'JC_User', N'iDCard', N'身份证', N'nvarchar', N'string', N'IDCard', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (133, 5, N'JC_User', N'email', N'Email', N'nvarchar', N'string', N'Email', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (134, 5, N'JC_User', N'telePhone', N'手机', N'nvarchar', N'string', N'TelePhone', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (135, 5, N'JC_User', N'certNo', N'', N'nvarchar', N'string', N'CertNo', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (136, 5, N'JC_User', N'telePhoneVerifyStatus', N'', N'int', N'int', N'TelePhoneVerifyStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (137, 5, N'JC_User', N'lastLoginTimeNow', N'本次登陆时间', N'datetime', N'DateTime', N'LastLoginTimeNow', 0, 0, 0, 1, 1, 1, 0, 0, N'BETWEEN', N'datetime', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (138, 5, N'JC_User', N'lastLoginTimePre', N'上次登陆时间', N'datetime', N'DateTime', N'LastLoginTimePre', 0, 0, 0, 1, 1, 1, 0, 0, N'BETWEEN', N'datetime', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (139, 5, N'JC_User', N'lastLoginIPNow', N'本次登陆IP', N'nvarchar', N'string', N'LastLoginIPNow', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (140, 5, N'JC_User', N'lastLoginIPPre', N'上次登陆IP', N'nvarchar', N'string', N'LastLoginIPPre', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (141, 5, N'JC_User', N'loginCount', N'登录次数', N'int', N'int', N'LoginCount', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (142, 5, N'JC_User', N'rootCoId', N'', N'int', N'int', N'RootCoId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (143, 5, N'JC_User', N'proId', N'上次登录项目', N'uniqueidentifier', N'string', N'ProId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (144, 5, N'JC_User', N'productId', N'上次选择产品', N'int', N'int', N'ProductId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (145, 5, N'JC_User', N'roleId', N'上次选择角色', N'int', N'int', N'RoleId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (146, 5, N'JC_User', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (147, 5, N'JC_User', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (148, 5, N'JC_User', N'creator', N'', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (149, 5, N'JC_User', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (150, 5, N'JC_User', N'deleteStatus', N'', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (151, 5, N'JC_User', N'addTime', N'添加时间', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (152, 5, N'JC_User', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.683' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (153, 6, N'JC_UserCorporation', N'ucId', N'', N'int', N'int', N'UcId', 1, 1, 1, 0, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (154, 6, N'JC_UserCorporation', N'userId', N'', N'int', N'int', N'UserId', 0, 0, 1, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (155, 6, N'JC_UserCorporation', N'coId', N'', N'int', N'int', N'CoId', 0, 0, 1, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (156, 6, N'JC_UserCorporation', N'rootCoId', N'所属根组织ID（单位ID）', N'int', N'int', N'RootCoId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (157, 6, N'JC_UserCorporation', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (158, 6, N'JC_UserCorporation', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (159, 6, N'JC_UserCorporation', N'creator', N'', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (160, 6, N'JC_UserCorporation', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (161, 6, N'JC_UserCorporation', N'deleteStatus', N'', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (162, 6, N'JC_UserCorporation', N'addTime', N'添加时间', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (163, 6, N'JC_UserCorporation', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.797' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (164, 7, N'JC_UserRole', N'urId', N'', N'int', N'int', N'UrId', 1, 1, 1, 0, 0, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (165, 7, N'JC_UserRole', N'roleId', N'', N'int', N'int', N'RoleId', 0, 0, 1, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (166, 7, N'JC_UserRole', N'userId', N'', N'int', N'int', N'UserId', 0, 0, 1, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (167, 7, N'JC_UserRole', N'coId', N'', N'int', N'int', N'CoId', 0, 0, 1, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (168, 7, N'JC_UserRole', N'createUserId', N'', N'int', N'int', N'CreateUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (169, 7, N'JC_UserRole', N'lastEditUserId', N'', N'int', N'int', N'LastEditUserId', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (170, 7, N'JC_UserRole', N'lastEditor', N'', N'nvarchar', N'string', N'LastEditor', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (171, 7, N'JC_UserRole', N'creator', N'', N'nvarchar', N'string', N'Creator', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (172, 7, N'JC_UserRole', N'deleteStatus', N'', N'int', N'int', N'DeleteStatus', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'radio', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (173, 7, N'JC_UserRole', N'addTime', N'添加时间', N'int', N'int', N'AddTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[gen_table_column] ([columnId], [tableId], [tableName], [columnName], [columnComment], [columnType], [csharpType], [csharpField], [isPk], [isIncrement], [isRequired], [isInsert], [isEdit], [isList], [isSort], [isQuery], [queryType], [htmlType], [dictType], [sort], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (174, 7, N'JC_UserRole', N'updateTime', N'', N'int', N'int', N'UpdateTime', 0, 0, 0, 1, 1, 1, 0, 0, N'EQ', N'input', N'', 0, N'admin', CAST(N'2022-11-07T09:19:02.907' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[gen_table_column] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_config] ON 
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (1, N'主框架页-默认皮肤样式名称', N'sys.index.skinName', N'skin-blue', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.477' AS DateTime), N'', NULL, N'蓝色 skin-blue、绿色 skin-green、紫色 skin-purple、红色 skin-red、黄色 skin-yellow')
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (2, N'用户管理-账号初始密码', N'sys.user.initPassword', N'123456', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.477' AS DateTime), N'', NULL, N'初始化密码 123456')
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (3, N'主框架页-侧边栏主题', N'sys.index.sideTheme', N'theme-dark', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.477' AS DateTime), N'', NULL, N'深色主题theme-dark，浅色主题theme-light')
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (4, N'账号自助-验证码开关', N'sys.account.captchaOnOff', N'1', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.480' AS DateTime), N'', NULL, N'开启验证码功能（off、关闭，1、动态验证码 2、动态gif泡泡 3、泡泡 4、静态验证码）')
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (5, N'本地文件上传访问域名', N'sys.file.uploadurl', N'http://localhost:8888', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.480' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (6, N'开启注册功能', N'sys.account.register', N'true', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.480' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_config] ([configId], [configName], [configKey], [configValue], [configType], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (7, N'文章预览地址', N'sys.article.preview.url', N'https://gitee.com/', N'Y', N'admin', CAST(N'2022-11-05T14:23:12.480' AS DateTime), N'', NULL, N'格式：http://www.izhaorui.cn/article/details/{aid}，其中{aid}为文章的id')
GO
SET IDENTITY_INSERT [dbo].[sys_config] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_dept] ON 
GO
INSERT [dbo].[sys_dept] ([deptId], [parentId], [ancestors], [deptName], [orderNum], [leader], [phone], [email], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (100, 0, N'', N'XXX公司', 0, NULL, NULL, NULL, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.060' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dept] ([deptId], [parentId], [ancestors], [deptName], [orderNum], [leader], [phone], [email], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (101, 100, N'', N'研发部门', 1, NULL, NULL, NULL, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.060' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dept] ([deptId], [parentId], [ancestors], [deptName], [orderNum], [leader], [phone], [email], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (102, 100, N'', N'市场部门', 2, NULL, NULL, NULL, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.060' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dept] ([deptId], [parentId], [ancestors], [deptName], [orderNum], [leader], [phone], [email], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (103, 100, N'', N'测试部门', 3, NULL, NULL, NULL, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.060' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dept] ([deptId], [parentId], [ancestors], [deptName], [orderNum], [leader], [phone], [email], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (104, 100, N'', N'财务部门', 4, NULL, NULL, NULL, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.060' AS DateTime), N'', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[sys_dept] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_dict_data] ON 
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (1, 1, N'男', N'0', N'sys_user_sex', N'', N'', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'性别男')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (2, 2, N'女', N'1', N'sys_user_sex', N'', N'', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'性别女')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (3, 3, N'未知', N'2', N'sys_user_sex', N'', N'', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'性别未知')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (4, 1, N'显示', N'0', N'sys_show_hide', N'', N'primary', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'显示菜单')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (5, 2, N'隐藏', N'1', N'sys_show_hide', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'隐藏菜单')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (6, 1, N'正常', N'0', N'sys_normal_disable', N'', N'primary', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'正常状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (7, 2, N'停用', N'1', N'sys_normal_disable', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'停用状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (8, 1, N'正常', N'0', N'sys_job_status', N'', N'primary', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'正常状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (9, 2, N'异常', N'1', N'sys_job_status', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', CAST(N'2021-07-02T14:09:09.000' AS DateTime), N'停用状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (10, 1, N'默认', N'DEFAULT', N'sys_job_group', N'', N'', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'默认分组')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (11, 2, N'系统', N'SYSTEM', N'sys_job_group', N'', N'', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'系统分组')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (12, 1, N'是', N'Y', N'sys_yes_no', N'', N'primary', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'系统默认是')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (13, 2, N'否', N'N', N'sys_yes_no', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:21.000' AS DateTime), N'', NULL, N'系统默认否')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (14, 1, N'通知', N'1', N'sys_notice_type', N'', N'warning', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'通知')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (15, 2, N'公告', N'2', N'sys_notice_type', N'', N'success', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'公告')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (16, 1, N'正常', N'0', N'sys_notice_status', N'', N'primary', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'正常状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (17, 2, N'关闭', N'1', N'sys_notice_status', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'关闭状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (18, 0, N'其他', N'0', N'sys_oper_type', N'', N'info', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'其他操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (19, 1, N'新增', N'1', N'sys_oper_type', N'', N'info', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'新增操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (20, 2, N'修改', N'2', N'sys_oper_type', N'', N'info', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'修改操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (21, 3, N'删除', N'3', N'sys_oper_type', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'删除操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (22, 4, N'授权', N'4', N'sys_oper_type', N'', N'primary', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'授权操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (23, 5, N'导出', N'5', N'sys_oper_type', N'', N'warning', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'导出操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (24, 6, N'导入', N'6', N'sys_oper_type', N'', N'warning', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'导入操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (25, 7, N'强退', N'7', N'sys_oper_type', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'强退操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (26, 8, N'生成代码', N'8', N'sys_oper_type', N'', N'warning', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'生成操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (27, 9, N'清空数据', N'9', N'sys_oper_type', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:22.000' AS DateTime), N'', NULL, N'清空操作')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (28, 1, N'成功', N'0', N'sys_common_status', N'', N'primary', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:23.000' AS DateTime), N'', NULL, N'正常状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (29, 2, N'失败', N'1', N'sys_common_status', N'', N'danger', N'N', N'0', N'admin', CAST(N'2021-02-24T10:56:23.000' AS DateTime), N'', NULL, N'停用状态')
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (30, 1, N'发布', N'1', N'sys_article_status', NULL, NULL, NULL, N'0', N'admin', CAST(N'2021-08-19T10:34:56.000' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (31, 2, N'草稿', N'2', N'sys_article_status', NULL, NULL, NULL, N'0', N'admin', CAST(N'2021-08-19T10:35:06.000' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (32, 1, N'中文', N'zh-cn', N'sys_lang_type', NULL, NULL, NULL, N'0', N'admin', CAST(N'2021-08-19T10:35:06.000' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (33, 2, N'英文', N'en', N'sys_lang_type', NULL, NULL, NULL, N'0', N'admin', CAST(N'2021-08-19T10:35:06.000' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_dict_data] ([dictCode], [dictSort], [dictLabel], [dictValue], [dictType], [cssClass], [listClass], [isDefault], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (34, 3, N'繁体', N'zh-tw', N'sys_lang_type', NULL, NULL, NULL, N'0', N'admin', CAST(N'2021-08-19T10:35:06.000' AS DateTime), N'', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[sys_dict_data] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_dict_type] ON 
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (1, N'用户性别', N'sys_user_sex', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'用户性别列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (2, N'菜单状态', N'sys_show_hide', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'菜单状态列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (3, N'系统开关', N'sys_normal_disable', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'系统开关列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (4, N'任务状态', N'sys_job_status', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'任务状态列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (5, N'任务分组', N'sys_job_group', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'任务分组列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (6, N'系统是否', N'sys_yes_no', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'系统是否列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (7, N'通知类型', N'sys_notice_type', N'Y', N'0', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'通知类型列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (8, N'通知状态', N'sys_notice_status', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'通知状态列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (9, N'操作类型', N'sys_oper_type', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:26.000' AS DateTime), N'', NULL, N'操作类型列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (10, N'系统状态', N'sys_common_status', N'0', N'Y', N'admin', CAST(N'2021-02-24T10:55:27.000' AS DateTime), N'', NULL, N'登录状态列表', NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (11, N'文章状态', N'sys_article_status', N'0', N'Y', N'admin', CAST(N'2021-08-19T10:34:33.000' AS DateTime), N'', NULL, NULL, NULL)
GO
INSERT [dbo].[sys_dict_type] ([dictId], [dictName], [dictType], [status], [type], [create_by], [create_time], [update_by], [update_time], [remark], [customSql]) VALUES (12, N'多语言类型', N'sys_lang_type', N'0', N'Y', N'admin', CAST(N'2021-08-19T10:34:33.000' AS DateTime), N'', NULL, N'多语言字典类型', NULL)
GO
SET IDENTITY_INSERT [dbo].[sys_dict_type] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_logininfor] ON 
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (1, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-05T14:26:08.723' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (2, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-07T09:15:26.277' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (3, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-07T15:06:47.807' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (4, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-07T15:54:29.520' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (5, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-09T10:09:46.937' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (6, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-09T11:01:56.353' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (7, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-09T18:27:55.713' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (8, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-09T18:30:12.867' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (9, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-10T09:10:42.623' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (10, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'1', N'用户名或密码错误', CAST(N'2022-11-10T09:13:53.220' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (11, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'1', N'用户名或密码错误', CAST(N'2022-11-10T09:14:33.267' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (12, N'15167101022', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'1', N'用户名或密码错误', CAST(N'2022-11-10T09:15:32.440' AS DateTime))
GO
INSERT [dbo].[sys_logininfor] ([infoId], [userName], [ipaddr], [loginLocation], [browser], [os], [status], [msg], [loginTime]) VALUES (13, N'admin', N'127.0.0.1', N'0-内网IP', N'Other', N'Windows 10', N'0', N'登录成功', CAST(N'2022-11-10T09:16:15.937' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[sys_logininfor] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_menu] ON 
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1, N'系统管理', 0, 1, N'system', NULL, 0, 0, N'M', N'0', N'0', N'', N'system', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.system')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (2, N'系统监控', 0, 2, N'monitor', NULL, 0, 0, N'M', N'0', N'0', N'', N'monitor', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.monitoring')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (3, N'系统工具', 0, 3, N'tool', NULL, 0, 0, N'M', N'0', N'0', N'', N'tool', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemTools')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (5, N'外部打开', 0, 5, N'https://gitee.com/', NULL, 1, 0, N'M', N'0', N'0', N'', N'link', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.officialWebsite')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (6, N'控制台', 0, 0, N'dashboard', N'index_v1', 0, 0, N'C', N'0', N'0', N'', N'dashboard', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.dashboard')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (100, N'用户管理', 1, 1, N'user', N'system/user/index', 0, 0, N'C', N'0', N'0', N'system:user:list', N'user', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemUser')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (101, N'角色管理', 1, 2, N'role', N'system/role/index', 0, 0, N'C', N'0', N'0', N'system:role:list', N'peoples', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemRole')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (102, N'菜单管理', 1, 3, N'menu', N'system/menu/index', 0, 0, N'C', N'0', N'0', N'system:menu:list', N'tree-table', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemMenu')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (103, N'部门管理', 1, 4, N'dept', N'system/dept/index', 0, 0, N'C', N'0', N'0', N'system:dept:list', N'tree', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemDept')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (104, N'岗位管理', 1, 5, N'post', N'system/post/index', 0, 0, N'C', N'0', N'0', N'system:post:list', N'post', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemPost')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (105, N'字典管理', 1, 6, N'dict', N'system/dict/index', 0, 0, N'C', N'0', N'0', N'system:dict:list', N'dict', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemDic')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (106, N'角色分配', 1, 2, N'roleusers', N'system/roleusers/index', 0, 0, N'C', N'1', N'0', N'system:roleusers:list', N'people', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (107, N'参数设置', 1, 8, N'config', N'system/config/index', 0, 0, N'C', N'0', N'0', N'system:config:list', N'edit', N'', CAST(N'2022-11-05T14:23:12.260' AS DateTime), N'', NULL, N'', N'menu.systemParam')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (108, N'日志管理', 1, 10, N'log', N'', 0, 0, N'M', N'0', N'0', N'', N'log', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.systemLog')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (109, N'通知公告', 1, 9, N'notice', N'system/notice/index', 0, 0, N'C', N'0', N'0', N'system:notice:list', N'message', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.systemNotice')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (110, N'定时任务', 2, 1, N'job', N'monitor/job/index', 0, 0, N'C', N'0', N'0', N'', N'job', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.timedTask')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (112, N'服务监控', 2, 4, N'server', N'monitor/server/index', 0, 0, N'C', N'0', N'0', N'monitor:server:list', N'server', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.serviceMonitor')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (113, N'缓存监控', 2, 5, N'cache', N'monitor/cache/index', 0, 0, N'C', N'1', N'1', N'monitor:cache:list', N'redis', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.cacheMonitor')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (114, N'表单构建', 3, 1, N'build', N'tool/build/index', 0, 0, N'C', N'0', N'0', N'tool:build:list', N'build', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.formBuild')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (115, N'代码生成', 3, 2, N'gen', N'tool/gen/index', 0, 0, N'C', N'0', N'0', N'tool:gen:list', N'code', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.codeGeneration')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (116, N'系统接口', 3, 3, N'swagger', N'tool/swagger/index', 0, 0, N'C', N'0', N'0', N'tool:swagger:list', N'swagger', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.systemInterface')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (117, N'发送邮件', 3, 4, N'sendEmail', N'tool/email/sendEmail', 0, 0, N'C', N'0', N'0', N'tool:email:send', N'email', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.sendEmail')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (118, N'文章管理', 3, 18, N'article', NULL, 0, 0, N'M', N'0', N'0', NULL, N'documentation', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.systemArticle')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (119, N'文章列表', 118, 1, N'index', N'system/article/manager', 0, 0, N'C', N'0', N'0', N'system:article:list', N'list', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.articleList')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (500, N'操作日志', 108, 1, N'operlog', N'monitor/operlog/index', 0, 0, N'C', N'0', N'0', N'monitor:operlog:list', N'form', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.operLog')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (501, N'登录日志', 108, 2, N'logininfor', N'monitor/logininfor/index', 0, 0, N'C', N'0', N'0', N'monitor:logininfor:list', N'logininfor', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'menu.loginLog')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1001, N'用户查询', 100, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:query', N'', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1002, N'用户添加', 100, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:add', N'', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1003, N'用户修改', 100, 3, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:edit', N'', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1004, N'用户删除', 100, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:delete', N'', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1005, N'用户导出', 100, 5, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:export', N'#', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1006, N'用户导入', 100, 6, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:import', N'#', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1007, N'重置密码', 100, 7, N'', N'', 0, 0, N'F', N'0', N'0', N'system:user:resetPwd', N'#', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1008, N'角色查询', 101, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:role:query', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1009, N'角色新增', 101, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:role:add', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1010, N'角色修改', 101, 3, N'', N'', 0, 0, N'F', N'0', N'0', N'system:role:edit', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1011, N'角色删除', 101, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:role:remove', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1012, N'菜单授权', 101, 5, N'', N'', 0, 0, N'F', N'0', N'0', N'system:role:authorize', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1013, N'菜单查询', 102, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:menu:query', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1014, N'菜单新增', 102, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:menu:add', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1015, N'菜单修改', 102, 3, N'', N'', 0, 0, N'F', N'0', N'0', N'system:menu:edit', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1016, N'菜单删除', 102, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:menu:remove', N'#', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1017, N'修改排序', 102, 5, N'', N'', 0, 0, N'F', N'0', N'0', N'system:menu:changeSort', N'', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1018, N'部门查询', 103, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dept:query', N'', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1019, N'部门新增', 103, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dept:add', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1020, N'部门修改', 103, 3, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dept:update', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1021, N'部门删除', 103, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dept:remove', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1022, N'岗位查询', 104, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:post:list', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1023, N'岗位添加', 104, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:post:add', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1024, N'岗位删除', 104, 3, N'', N'', 0, 0, N'F', N'0', N'0', N'system:post:remove', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1025, N'岗位编辑', 104, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:post:edit', N'', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1026, N'字典新增', 105, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dict:add', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1027, N'字典修改', 105, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dict:edit', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1028, N'字典删除', 105, 3, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dict:remove', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1029, N'新增用户', 106, 1, N'', N'', 0, 0, N'F', N'0', N'0', N'system:roleusers:add', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1030, N'删除用户', 106, 2, N'', N'', 0, 0, N'F', N'0', N'0', N'system:roleusers:del', NULL, N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1032, N'任务查询', 110, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:list', N'#', N'admin', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1033, N'任务新增', 110, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:add', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1034, N'任务删除', 110, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:delete', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1035, N'任务修改', 110, 4, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:edit', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1036, N'任务启动', 110, 5, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:start', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1037, N'任务运行', 110, 7, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:run', NULL, N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1038, N'任务停止', 110, 8, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:stop', NULL, N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1039, N'任务日志', 2, 0, N'job/log', N'monitor/job/log', 0, 0, N'C', N'1', N'0', N'monitor:job:query', N'log', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1040, N'任务导出', 110, 10, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:job:export', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1041, N'操作查询', 500, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:operlog:query', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1042, N'操作删除', 500, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:operlog:remove', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1043, N'操作日志导出', 500, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:operlog:export', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1044, N'登录查询', 501, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:logininfor:query', N'', N'admin', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1045, N'登录删除', 501, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:logininfor:remove', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1046, N'登录日志导出', 501, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'monitor:logininfor:export', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1047, N'发布文章', 3, 2, N'/article/publish', N'system/article/publish', 0, 0, N'C', N'1', N'0', N'system:article:publish', N'log', N'', CAST(N'2022-11-05T14:23:12.263' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1048, N'文章新增', 118, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:article:add', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1049, N'文章修改', 118, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:article:update', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1050, N'文章删除', 118, 4, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:article:delete', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1051, N'查询公告', 109, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:notice:query', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1052, N'新增公告', 109, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:notice:add', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1053, N'删除公告', 109, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:notice:delete', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1054, N'修改公告', 109, 4, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:notice:update', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1055, N'导出公告', 109, 5, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:notice:export', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1060, N'生成修改', 3, 1, N'/gen/editTable', N'tool/gen/editTable', 0, 0, N'C', N'1', N'0', N'tool:gen:edit', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1061, N'生成查询', 115, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:gen:query', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1062, N'生成删除', 115, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:gen:remove', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1063, N'导入代码', 115, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:gen:import', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1064, N'生成代码', 115, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:gen:code', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1065, N'预览代码', 115, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:gen:preview', N'', N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1070, N'岗位导出', 104, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:post:export', N'', N'', CAST(N'2022-11-05T14:23:12.267' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1071, N'字典导出', 105, 4, N'', N'', 0, 0, N'F', N'0', N'0', N'system:dict:export', NULL, N'', CAST(N'2022-11-05T14:23:12.270' AS DateTime), N'', NULL, NULL, N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1072, N'文件存储', 3, 17, N'file', N'tool/file/index', 0, 0, N'C', N'0', N'0', N'tool:file:list', N'upload', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', NULL, N'文件存储菜单', N'menu.fileStorage')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1073, N'查询', 1072, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:file:query', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1074, N'新增', 1072, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:file:add', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1075, N'删除', 1072, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:file:delete', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1076, N'修改', 1072, 4, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:file:update', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1077, N'导出', 1072, 5, N'#', NULL, 0, 0, N'F', N'0', N'0', N'tool:file:export', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1078, N'多语言配置', 1, 999, N'CommonLang', N'system/commonLang/index', 0, 0, N'C', N'0', N'0', N'system:lang:list', N'language', N'system', CAST(N'2022-11-05T14:23:12.327' AS DateTime), N'', NULL, N'', N'menu.systemLang')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1079, N'查询', 1078, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:lang:query', N'', N'system', CAST(N'2022-11-05T14:23:12.327' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1080, N'新增', 1078, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:lang:add', N'', N'system', CAST(N'2022-11-05T14:23:12.327' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1081, N'删除', 1078, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:lang:delete', N'', N'system', CAST(N'2022-11-05T14:23:12.327' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1082, N'修改', 1078, 4, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:lang:edit', N'', N'system', CAST(N'2022-11-05T14:23:12.327' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1083, N'导出', 1078, 5, N'#', NULL, 0, 0, N'F', N'0', N'0', N'system:lang:export', N'', N'system', CAST(N'2022-11-05T14:23:12.327' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1084, N'文章目录', 118, 999, N'ArticleCategory', N'system/article/articleCategory', 0, 0, N'C', N'0', N'0', N'articlecategory:list', N'tree-table', N'system', CAST(N'2022-11-05T14:23:12.340' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1085, N'查询', 1084, 1, N'#', NULL, 0, 0, N'F', N'0', N'0', N'articlecategory:query', N'', N'system', CAST(N'2022-11-05T14:23:12.343' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1086, N'新增', 1084, 2, N'#', NULL, 0, 0, N'F', N'0', N'0', N'articlecategory:add', N'', N'system', CAST(N'2022-11-05T14:23:12.343' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1087, N'删除', 1084, 3, N'#', NULL, 0, 0, N'F', N'0', N'0', N'articlecategory:delete', N'', N'system', CAST(N'2022-11-05T14:23:12.343' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1088, N'修改', 1084, 4, N'#', NULL, 0, 0, N'F', N'0', N'0', N'articlecategory:edit', N'', N'system', CAST(N'2022-11-05T14:23:12.343' AS DateTime), N'', NULL, N'', N'')
GO
INSERT [dbo].[sys_menu] ([menuId], [menuName], [parentId], [orderNum], [path], [component], [isFrame], [isCache], [menuType], [visible], [status], [perms], [icon], [create_by], [create_time], [update_by], [update_time], [remark], [menuName_key]) VALUES (1089, N'导出', 1084, 5, N'#', NULL, 0, 0, N'F', N'0', N'0', N'articlecategory:export', N'', N'system', CAST(N'2022-11-05T14:23:12.343' AS DateTime), N'', NULL, N'', N'')
GO
SET IDENTITY_INSERT [dbo].[sys_menu] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_oper_log] ON 
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (1, N'代码生成', 6, N'CodeGenerator.ImportTableSave()', N'POST', 0, N'admin', N'', N'/tool/gen/importTable', N'127.0.0.1', N'0 内网IP', N'?tables=BulkTest&dbName=Test', N'{  "code": 200,  "msg": "SUCCESS"}', 0, N'', CAST(N'2022-11-05T14:27:25.997' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (2, N'代码生成', 3, N'CodeGenerator.Remove()', N'DELETE', 0, N'admin', N'', N'/tool/gen/1', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": 24}', 0, N'', CAST(N'2022-11-05T14:28:03.903' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (3, N'代码生成', 6, N'CodeGenerator.ImportTableSave()', N'POST', 0, N'admin', N'', N'/tool/gen/importTable', N'127.0.0.1', N'0 内网IP', N'?tables=JC_Corporation,JC_Project,JC_PowerItem,JC_Role&dbName=LaborSys', N'{  "code": 200,  "msg": "SUCCESS"}', 0, N'', CAST(N'2022-11-07T09:18:46.673' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (4, N'代码生成', 6, N'CodeGenerator.ImportTableSave()', N'POST', 0, N'admin', N'', N'/tool/gen/importTable', N'127.0.0.1', N'0 内网IP', N'?tables=JC_User,JC_UserCorporation,JC_UserRole&dbName=LaborSys', N'{  "code": 200,  "msg": "SUCCESS"}', 0, N'', CAST(N'2022-11-07T09:19:02.913' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (5, N'', 0, N'', N'POST', 0, N'admin', N'', N'/tool/gen/preview/7', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-07T09:20:46.990' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (6, N'', 0, N'', N'POST', 0, N'admin', N'', N'/tool/gen/preview/7', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-07T09:21:26.747' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (7, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T10:37:52.297' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (8, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T10:40:32.427' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (9, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T10:41:16.233' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (10, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107110008.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:00:08.690' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (11, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:01:04.153' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (12, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107110110.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:01:10.313' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (13, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107110303.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:03:03.077' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (14, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107110324.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:03:24.690' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (15, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:07:11.587' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (16, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:08:50.270' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (17, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:09:08.730' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (18, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:10:07.603' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (19, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:10:41.580' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (20, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:11:13.443' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (21, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:12:18.133' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (22, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:12:45.527' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (23, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:13:38.003' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (24, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:14:06.247' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (25, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:14:34.207' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (26, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:14:48.193' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (27, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":7}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户角色关联表-1107111453.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:14:53.353' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (28, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":7}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户角色关联表-1107111502.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:15:02.570' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (29, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":6}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-企业项目用户关联信息-1107111510.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:15:10.943' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (30, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107111519.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:15:19.533' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (31, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:15:31.143' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (32, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":4}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户角色信息-1107111541.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:15:41.207' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (33, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:15:51.870' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (34, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":4}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户角色信息-1107111554.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:15:54.927' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (35, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:16:09.553' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (36, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":3}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-角色菜单-1107111611.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:16:11.433' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (37, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:16:26.353' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (38, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":2}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-项目信息-1107111635.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:16:35.120' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (39, N'代码生成', 8, N'CodeGenerator.EditSave()', N'PUT', 0, N'admin', N'', N'/tool/gen/', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": true}', 0, N'', CAST(N'2022-11-07T11:16:45.043' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (40, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":1}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-企业、项目信息表，包含关联层级-1107111650.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:16:50.597' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (41, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107111724.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T11:17:24.140' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (42, N'代码生成', 8, N'CodeGenerator.CodeGenerate()', N'POST', 0, N'admin', N'', N'/tool/gen/genCode', N'127.0.0.1', N'0 内网IP', N'{"tableId":5}', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "path": "/Generatecode/FdSoft.CodeGenerator.NET-用户表-1107150005.zip",    "fileName": null  }}', 0, N'', CAST(N'2022-11-07T15:00:05.467' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (43, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'admin', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "admin",    "id": 1  }}', 0, N'', CAST(N'2022-11-07T15:05:06.773' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (44, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'admin', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "admin",    "id": 1  }}', 0, N'', CAST(N'2022-11-07T15:26:00.500' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (45, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T10:09:02.677' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (46, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T10:09:04.460' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (47, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'admin', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "admin",    "id": 1  }}', 0, N'', CAST(N'2022-11-09T10:11:18.540' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (48, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T14:51:29.047' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (49, N'', 0, N'', N'POST', 0, N'', N'', N'/login', N'127.0.0.1', N'0 内网IP', N'{"username":"admin","password":"123456","code":"A2fa","uuid":"06dfeb8c8ca7439bb321a3351f4e8ec8"}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'One or more errors occurred. (由于目标计算机积极拒绝，无法连接。 (localhost:8889))', CAST(N'2022-11-09T14:52:44.523' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (50, N'登录', 0, N'', N'POST', 0, N'', N'', N'/GetToken', N'127.0.0.1', N'0 内网IP', N'{
	"userName": "15167101022",
	"passWord": "Fd123654",
	"productId": 1,
	"isPlaintext": true,
	"loginIp": "string"
}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'对象名 ''JC_User'' 无效。', CAST(N'2022-11-09T14:56:11.797' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (51, N'登录', 0, N'', N'POST', 0, N'', N'', N'/GetToken', N'127.0.0.1', N'0 内网IP', N'{
	"userName": "15167101022",
	"passWord": "Fd123654",
	"productId": 1,
	"isPlaintext": true,
	"loginIp": "string"
}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'对象名 ''JC_User'' 无效。', CAST(N'2022-11-09T14:56:13.517' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (52, N'登录', 0, N'', N'POST', 0, N'', N'', N'/GetToken', N'127.0.0.1', N'0 内网IP', N'{
	"userName": "15167101022",
	"passWord": "Fd123654",
	"productId": 1,
	"isPlaintext": true,
	"loginIp": "string"
}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'对象名 ''JC_User'' 无效。', CAST(N'2022-11-09T14:56:15.287' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (53, N'', 0, N'', N'POST', 0, N'', N'', N'/login', N'127.0.0.1', N'0 内网IP', N'{"username":"admin","password":"123456","code":"p43d","uuid":"fec5179ce59b43c3a468430e2ebe5877"}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'One or more errors occurred. (Error while copying content to a stream.)', CAST(N'2022-11-09T15:27:29.600' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (54, N'', 0, N'', N'POST', 0, N'', N'', N'/login', N'127.0.0.1', N'0 内网IP', N'{"username":"admin","password":"123456","code":"p43d","uuid":"fec5179ce59b43c3a468430e2ebe5877"}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'One or more errors occurred. (A task was canceled.)', CAST(N'2022-11-09T16:08:51.883' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (55, N'', 0, N'', N'POST', 0, N'', N'', N'/login', N'127.0.0.1', N'0 内网IP', N'{"username":"admin","password":"123456","code":"p43d","uuid":"fec5179ce59b43c3a468430e2ebe5877"}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Unable to find a constructor to use for type Infrastructure.CustomException. A class should either have a default constructor, one constructor with arguments or a constructor marked with the JsonConstructor attribute. Path ''code'', line 2, position 9.', CAST(N'2022-11-09T16:36:29.430' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (56, N'', 0, N'', N'POST', 0, N'', N'', N'/login', N'127.0.0.1', N'0 内网IP', N'{"username":"admin","password":"123456","code":"p43d","uuid":"fec5179ce59b43c3a468430e2ebe5877"}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Unable to find a constructor to use for type Infrastructure.CustomException. A class should either have a default constructor, one constructor with arguments or a constructor marked with the JsonConstructor attribute. Path ''code'', line 2, position 9.', CAST(N'2022-11-09T16:38:16.917' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (57, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T17:09:10.273' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (58, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T17:12:27.620' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (59, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T17:44:28.457' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (60, N'', 0, N'', N'GET', 0, N'15167101022', N'', N'/getInfo', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 101,
  "msg": "value cannot be null. (parameter ''source'')",
  "data": null
}', 1, N'Value cannot be null. (Parameter ''source'')', CAST(N'2022-11-09T17:45:41.987' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (61, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T17:49:54.210' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (62, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T17:50:04.717' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (63, N'', 0, N'', N'GET', 0, N'15167101022', N'', N'/getInfo', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-09T17:52:02.797' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (64, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'15167101022', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "15167101022",    "id": 35  }}', 0, N'', CAST(N'2022-11-09T17:52:02.863' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (65, N'', 0, N'', N'GET', 0, N'15167101022', N'', N'/getInfo', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-09T17:54:33.933' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (66, N'', 0, N'', N'GET', 0, N'15167101022', N'', N'/getInfo', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-09T17:54:38.480' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (67, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'admin', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "admin",    "id": 1  }}', 0, N'', CAST(N'2022-11-09T18:30:00.947' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (68, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T18:31:54.230' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (69, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-09T22:55:05.017' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (70, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'15167101022', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "15167101022",    "id": 35  }}', 0, N'', CAST(N'2022-11-09T22:58:16.170' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (71, N'', 0, N'', N'GET', 0, N'15167101022', N'', N'/getInfo', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-09T22:58:23.807' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (72, N'', 0, N'', N'GET', 0, N'15167101022', N'', N'/getInfo', N'127.0.0.1', N'0 内网IP', N'', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'Object reference not set to an instance of an object.', CAST(N'2022-11-09T23:11:16.750' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (73, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'15167101022', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "15167101022",    "id": 35  }}', 0, N'', CAST(N'2022-11-09T23:11:16.793' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (74, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'admin', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": "admin",    "id": 1  }}', 0, N'', CAST(N'2022-11-10T09:11:25.563' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (75, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-10T09:20:41.647' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (76, N'注销', 0, N'SysLogin.LogOut()', N'POST', 0, N'', N'', N'/LogOut', N'127.0.0.1', N'0 内网IP', N'', N'{  "code": 200,  "msg": "SUCCESS",  "data": {    "name": null,    "id": 0  }}', 0, N'', CAST(N'2022-11-10T09:20:45.287' AS DateTime), 0)
GO
INSERT [dbo].[sys_oper_log] ([operId], [title], [businessType], [method], [requestMethod], [operatorType], [operName], [deptName], [operUrl], [operIP], [operLocation], [operParam], [jsonResult], [status], [errorMsg], [operTime], [elapsed]) VALUES (77, N'', 0, N'', N'POST', 0, N'', N'', N'/login', N'127.0.0.1', N'0 内网IP', N'{"username":"15167101022","password":"Fd123654","code":"a","uuid":"52907fee5c754dfbb1766b90a14470a7"}', N'{
  "code": 500,
  "msg": "服务器好像出了点问题......",
  "data": null
}', 1, N'One or more errors occurred. (由于目标计算机积极拒绝，无法连接。 (localhost:8889))', CAST(N'2022-11-10T09:20:58.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[sys_oper_log] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_post] ON 
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (1, N'CEO', N'董事长', 1, N'0', N'', CAST(N'2022-11-05T14:23:12.360' AS DateTime), N'', NULL, N'')
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (2, N'SE', N'项目经理', 2, N'0', N'', CAST(N'2022-11-05T14:23:12.360' AS DateTime), N'', NULL, N'')
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (3, N'HR', N'人力资源', 3, N'0', N'', CAST(N'2022-11-05T14:23:12.360' AS DateTime), N'', NULL, N'')
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (4, N'USER', N'普通员工', 4, N'0', N'', CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, N'')
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (5, N'PM', N'人事经理', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (6, N'GM', N'总经理', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (7, N'COO', N'首席运营官', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (8, N'CFO', N'首席财务官', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (9, N'CTO', N'首席技术官', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (10, N'HRD', N'人力资源总监', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (11, N'VP', N'副总裁', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (12, N'OD', N'运营总监', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[sys_post] ([postId], [postCode], [postName], [postSort], [status], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (13, N'MD', N'市场总监', 0, N'0', NULL, CAST(N'2022-11-05T14:23:12.363' AS DateTime), N'', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[sys_post] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_role] ON 
GO
INSERT [dbo].[sys_role] ([roleId], [roleName], [roleKey], [roleSort], [dataScope], [menu_check_strictly], [dept_check_strictly], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (1, N'超级管理员', N'admin', 1, N'1', 1, 0, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.403' AS DateTime), N'', NULL, N'超级管理员')
GO
INSERT [dbo].[sys_role] ([roleId], [roleName], [roleKey], [roleSort], [dataScope], [menu_check_strictly], [dept_check_strictly], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (2, N'普通角色', N'common', 2, N'2', 1, 0, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.403' AS DateTime), N'', NULL, N'普通角色')
GO
INSERT [dbo].[sys_role] ([roleId], [roleName], [roleKey], [roleSort], [dataScope], [menu_check_strictly], [dept_check_strictly], [status], [delFlag], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (3, N'编辑人员', N'editor', 2, N'2', 1, 0, N'0', N'0', N'admin', CAST(N'2022-11-05T14:23:12.403' AS DateTime), N'', NULL, N'普通角色')
GO
SET IDENTITY_INSERT [dbo].[sys_role] OFF
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 3, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (3, 4, NULL, CAST(N'2022-11-05T14:23:12.443' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 5, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 6, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 100, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 101, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 102, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 103, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 104, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 106, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 108, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 109, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 114, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (3, 118, NULL, CAST(N'2022-11-05T14:23:12.443' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 500, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 501, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1001, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1008, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1013, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1018, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1022, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1031, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1041, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1044, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (3, 1047, NULL, CAST(N'2022-11-05T14:23:12.447' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (3, 1048, NULL, CAST(N'2022-11-05T14:23:12.447' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (3, 1049, NULL, CAST(N'2022-11-05T14:23:12.447' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (3, 1050, NULL, CAST(N'2022-11-05T14:23:12.447' AS DateTime))
GO
INSERT [dbo].[sys_role_menu] ([role_id], [menu_id], [create_by], [create_time]) VALUES (2, 1051, N'admin', CAST(N'2021-12-20T22:03:36.130' AS DateTime))
GO
INSERT [dbo].[sys_tasks] ([id], [name], [jobGroup], [cron], [assemblyName], [className], [remark], [runTimes], [beginTime], [endTime], [triggerType], [intervalSecond], [isStart], [jobParams], [create_time], [update_time], [create_by], [update_by], [lastRunTime], [taskType], [apiUrl]) VALUES (N'1410905433996136448', N'测试任务', N'SYSTEM', N'0 0/10 * * * ? ', N'FdSoft.CodeGenerator.Tasks', N'TaskScheduler.Job_SyncTest', NULL, 187, CAST(N'2021-07-02T18:17:31.000' AS DateTime), CAST(N'9999-12-31T00:00:00.000' AS DateTime), 1, 1, 1, NULL, CAST(N'2021-07-02T18:17:23.000' AS DateTime), CAST(N'2021-07-02T18:17:31.000' AS DateTime), N'admin', NULL, CAST(N'2022-11-09T10:10:00.133' AS DateTime), 1, N'')
GO
SET IDENTITY_INSERT [dbo].[sys_tasks_log] ON 
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (1, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-05T14:30:00.110' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(17.6675 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (2, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-05T14:40:00.037' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(14.8097 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (3, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-05T14:50:00.027' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(14.5114 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (4, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T09:20:00.053' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(9.4714 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (5, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T09:30:00.083' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(17.8233 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (6, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T09:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9714 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (7, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T09:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.3372 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (8, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T10:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0046 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (9, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T10:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.8778 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (10, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T10:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7940 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (11, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T10:30:01.967' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(1359.7922 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (12, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T10:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9575 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (13, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T11:00:00.083' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(17.0140 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (14, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T11:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.4736 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (15, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T11:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.5222 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (16, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T11:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9922 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (17, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T11:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0600 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (18, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T11:50:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0455 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (19, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T12:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9468 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (20, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T12:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9773 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (21, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T12:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9864 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (22, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T12:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9386 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (23, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T12:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8682 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (24, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T12:50:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.4783 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (25, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T13:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0419 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (26, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T13:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9407 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (27, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T13:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0541 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (28, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T13:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7059 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (29, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T13:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0520 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (30, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T13:50:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9472 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (31, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T14:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9849 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (32, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T14:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9829 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (33, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T14:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9740 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (34, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T14:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1122 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (35, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T14:40:00.040' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.2021 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (36, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T14:50:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9855 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (37, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T15:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.4237 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (38, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T15:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9265 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (39, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T15:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.2259 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (40, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T15:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9771 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (41, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T15:40:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.9574 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (42, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T15:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8239 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (43, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T16:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(7.0767 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (44, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T16:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.4063 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (45, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T16:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1500 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (46, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T16:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0997 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (47, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T16:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9635 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (48, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T16:50:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.1736 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (49, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T17:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9435 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (50, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T17:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9634 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (51, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T17:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8168 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (52, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T17:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.8853 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (53, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T17:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1970 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (54, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T17:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9106 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (55, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T18:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7236 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (56, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T18:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9176 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (57, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T18:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0228 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (58, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T18:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9548 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (59, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T18:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7986 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (60, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T18:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1562 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (61, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T19:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9289 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (62, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T19:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8549 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (63, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T19:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7017 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (64, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T19:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9036 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (65, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T19:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9252 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (66, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T19:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9514 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (67, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T20:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9437 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (68, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T20:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9206 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (69, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T20:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.7278 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (70, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T20:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9151 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (71, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T20:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.4936 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (72, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T20:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9644 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (73, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T21:00:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.7911 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (74, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T21:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9687 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (75, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T21:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.9544 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (76, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T21:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9173 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (77, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T21:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9169 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (78, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T21:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.4983 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (79, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T22:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.4165 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (80, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T22:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9518 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (81, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T22:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8919 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (82, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T22:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7514 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (83, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T22:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0074 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (84, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T22:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0263 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (85, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T23:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0084 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (86, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T23:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9817 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (87, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T23:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.6338 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (88, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T23:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9001 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (89, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T23:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9970 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (90, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-07T23:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9135 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (91, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T00:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9727 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (92, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T00:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0206 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (93, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T00:20:00.060' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1439 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (94, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T00:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9987 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (95, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T00:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9836 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (96, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T00:50:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0193 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (97, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T01:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0070 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (98, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T01:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0492 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (99, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T01:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9488 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (100, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T01:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9218 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (101, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T01:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9543 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (102, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T01:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8843 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (103, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T02:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0365 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (104, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T02:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9826 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (105, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T02:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1708 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (106, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T02:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9282 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (107, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T02:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0235 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (108, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T02:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0074 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (109, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T03:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9929 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (110, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T03:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0212 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (111, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T03:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0371 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (112, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T03:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9788 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (113, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T03:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0225 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (114, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T03:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0868 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (115, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T04:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9952 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (116, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T04:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9262 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (117, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T04:20:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7985 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (118, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T04:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7048 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (119, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T04:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9221 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (120, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T04:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9531 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (121, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T05:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.7002 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (122, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T05:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9230 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (123, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T05:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9975 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (124, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T05:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0897 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (125, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T05:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.5535 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (126, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T05:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0125 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (127, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T06:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8036 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (128, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T06:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9580 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (129, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T06:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9895 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (130, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T06:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0510 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (131, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T06:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.4779 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (132, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T06:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9462 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (133, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T07:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9351 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (134, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T07:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.6857 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (135, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T07:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8944 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (136, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T07:30:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9445 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (137, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T07:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0301 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (138, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T07:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9311 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (139, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T08:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9263 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (140, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T08:10:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0209 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (141, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T08:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.6585 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (142, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T08:30:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9313 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (143, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T08:40:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0099 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (144, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T08:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.6894 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (145, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T09:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9590 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (146, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T09:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9209 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (147, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T09:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0125 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (148, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T09:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1539 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (149, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T09:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9630 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (150, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T09:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9144 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (151, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T10:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0548 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (152, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T10:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9005 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (153, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T10:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9572 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (154, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T10:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.3042 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (155, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T10:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.5991 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (156, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T10:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9022 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (157, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T11:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9876 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (158, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T11:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.2522 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (159, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T11:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8970 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (160, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T11:30:00.040' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.2657 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (161, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T11:40:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(4.0871 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (162, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T11:50:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9286 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (163, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T12:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0208 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (164, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T12:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9085 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (165, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T12:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9663 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (166, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T12:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9013 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (167, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T12:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.3984 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (168, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T12:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9829 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (169, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T13:00:00.013' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(3.9870 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (170, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T13:10:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9762 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (171, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T13:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0306 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (172, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T13:30:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9849 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (173, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T13:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.7440 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (174, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T13:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0496 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (175, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T14:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.9490 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (176, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T14:10:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0442 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (177, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T14:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.4022 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (178, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T14:30:00.040' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.7933 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (179, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T14:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.2105 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (180, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T14:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1095 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (181, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T15:00:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8146 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (182, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T15:10:00.087' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(14.4864 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (183, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T15:20:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0687 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (184, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T15:30:00.020' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.1936 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (185, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T15:40:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(5.8526 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (186, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-08T15:50:00.017' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(6.0452 AS Decimal(10, 4)))
GO
INSERT [dbo].[sys_tasks_log] ([jobLogId], [jobId], [jobName], [jobGroup], [jobMessage], [status], [exception], [createTime], [invokeTarget], [elapsed]) VALUES (187, N'1410905433996136448', N'测试任务', N'SYSTEM', N'success', N'0', NULL, CAST(N'2022-11-09T10:10:00.087' AS DateTime), N'FdSoft.CodeGenerator.Tasks.TaskScheduler.Job_SyncTest', CAST(12.6893 AS Decimal(10, 4)))
GO
SET IDENTITY_INSERT [dbo].[sys_tasks_log] OFF
GO
SET IDENTITY_INSERT [dbo].[sys_user] ON 
GO
INSERT [dbo].[sys_user] ([userId], [deptId], [userName], [nickName], [userType], [email], [phonenumber], [sex], [avatar], [password], [status], [delFlag], [loginIP], [loginDate], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (1, 0, N'admin', N'管理员', N'0', N'', N'', N'0', N'', N'e10adc3949ba59abbe56e057f20f883e', N'0', N'0', N'127.0.0.1', CAST(N'2022-11-10T09:16:15.963' AS DateTime), N'', NULL, N'', NULL, N'管理员')
GO
INSERT [dbo].[sys_user] ([userId], [deptId], [userName], [nickName], [userType], [email], [phonenumber], [sex], [avatar], [password], [status], [delFlag], [loginIP], [loginDate], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (2, 0, N'fdsoft.codegenerator', N'fdsoft.codegenerator', N'0', N'', N'', N'0', N'', N'e10adc3949ba59abbe56e057f20f883e', N'0', N'0', N'', NULL, N'', NULL, N'', NULL, N'普通用户')
GO
INSERT [dbo].[sys_user] ([userId], [deptId], [userName], [nickName], [userType], [email], [phonenumber], [sex], [avatar], [password], [status], [delFlag], [loginIP], [loginDate], [create_by], [create_time], [update_by], [update_time], [remark]) VALUES (3, 100, N'editor', N'编辑人员', N'0', N'', N'', N'2', N'', N'E10ADC3949BA59ABBE56E057F20F883E', N'0', N'0', N'', NULL, N'', NULL, N'', NULL, N'编辑人员')
GO
SET IDENTITY_INSERT [dbo].[sys_user] OFF
GO
INSERT [dbo].[sys_user_post] ([userId], [postId]) VALUES (1, 1)
GO
INSERT [dbo].[sys_user_role] ([user_id], [role_id]) VALUES (1, 1)
GO
INSERT [dbo].[sys_user_role] ([user_id], [role_id]) VALUES (2, 2)
GO
INSERT [dbo].[sys_user_role] ([user_id], [role_id]) VALUES (3, 3)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [dictType]    Script Date: 2022/11/10 9:24:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [dictType] ON [dbo].[sys_dict_type]
(
	[dictType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [postCode]    Script Date: 2022/11/10 9:24:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [postCode] ON [dbo].[sys_post]
(
	[postCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [index_userName]    Script Date: 2022/11/10 9:24:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [index_userName] ON [dbo].[sys_user]
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [title]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [userId]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [fmt_type]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [tags]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [hits]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [category_id]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [createTime]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [updateTime]
GO
ALTER TABLE [dbo].[article] ADD  DEFAULT (NULL) FOR [authorName]
GO
ALTER TABLE [dbo].[articleCategory] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[articleCategory] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[gen_demo] ADD  DEFAULT (NULL) FOR [sex]
GO
ALTER TABLE [dbo].[gen_demo] ADD  DEFAULT ((0)) FOR [sort]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [tableName]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [tableComment]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT (NULL) FOR [subTableName]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT (NULL) FOR [subTableFkName]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [className]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('crud') FOR [tplCategory]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('0') FOR [genType]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('/') FOR [genPath]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[gen_table] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('EQ') FOR [queryType]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('') FOR [dictType]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[gen_table_column] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [configName]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [configKey]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [configValue]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('N') FOR [configType]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_config] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [ancestors]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [deptName]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ((0)) FOR [orderNum]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [leader]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [phone]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('0') FOR [delFlag]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_dept] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ((0)) FOR [dictSort]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [dictLabel]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [dictValue]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [dictType]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [cssClass]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [listClass]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('N') FOR [isDefault]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_dict_data] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [dictName]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [dictType]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('N') FOR [type]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_dict_type] ADD  DEFAULT (NULL) FOR [customSql]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [userName]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [ipaddr]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [loginLocation]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [browser]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [os]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT ('') FOR [msg]
GO
ALTER TABLE [dbo].[sys_logininfor] ADD  DEFAULT (NULL) FOR [loginTime]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [orderNum]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [path]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [component]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [isFrame]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ((0)) FOR [isCache]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [menuType]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('0') FOR [visible]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [perms]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('#') FOR [icon]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [remark]
GO
ALTER TABLE [dbo].[sys_menu] ADD  DEFAULT ('') FOR [menuName_key]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [title]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ((0)) FOR [businessType]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [method]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [requestMethod]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ((0)) FOR [operatorType]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operName]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [deptName]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operUrl]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operIP]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operLocation]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [operParam]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [jsonResult]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT ('') FOR [errorMsg]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT (NULL) FOR [operTime]
GO
ALTER TABLE [dbo].[sys_oper_log] ADD  DEFAULT (NULL) FOR [elapsed]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_post] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('1') FOR [dataScope]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ((1)) FOR [menu_check_strictly]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ((1)) FOR [dept_check_strictly]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('0') FOR [delFlag]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('') FOR [create_by]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT ('') FOR [update_by]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_role] ADD  DEFAULT (NULL) FOR [remark]
GO
ALTER TABLE [dbo].[sys_role_menu] ADD  DEFAULT (NULL) FOR [create_by]
GO
ALTER TABLE [dbo].[sys_role_menu] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [beginTime]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [endTime]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [create_time]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [update_time]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [create_by]
GO
ALTER TABLE [dbo].[sys_tasks] ADD  DEFAULT (NULL) FOR [update_by]
GO
ALTER TABLE [dbo].[sys_tasks_log] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_tasks_log] ADD  DEFAULT ('') FOR [exception]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ((0)) FOR [deptId]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [userType]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [sex]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[sys_user] ADD  DEFAULT ('0') FOR [delFlag]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'userId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章状态1、已发布 2、草稿' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑器类型markdown,html' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'fmt_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'tags'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'createTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'updateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article', @level2type=N'COLUMN',@level2name=N'authorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'article'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articleCategory', @level2type=N'COLUMN',@level2name=N'category_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articleCategory', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articleCategory', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articleCategory', @level2type=N'COLUMN',@level2name=N'parentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articleCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'showStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'addTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'beginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'endTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_demo', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'tableId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'tableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'tableComment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联子表的表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'subTableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子表关联的外键名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'subTableFkName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实体类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'className'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用的模板（crud单表操作 tree树表操作）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'tplCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成命名空间前缀' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'baseNameSpace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成模块名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'moduleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成业务名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'businessName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成功能名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'functionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成功能作者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'functionAuthor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成代码方式（0zip压缩包 1自定义路径）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'genType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成路径（不填默认项目路径）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'genPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其它生成选项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'options'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'update_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码生成业务表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'columnId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'归属表编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'tableId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'tableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'columnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'columnComment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'columnType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C#类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'csharpType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C#字段名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'csharpField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否主键（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isPk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否自增（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isIncrement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否必填（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isRequired'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否为插入字段（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isInsert'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否编辑字段（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isEdit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否列表字段（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否查询字段（1是）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'isQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查询方式（等于、不等于、大于、小于、范围）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'queryType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'htmlType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'dictType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码生成业务表字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'gen_table_column'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'configId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'configName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数键名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'configKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数键值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'configValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统内置（Y是 N否）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'configType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参数配置表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_config'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'deptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父部门id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'parentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'祖级列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'ancestors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'deptName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'orderNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'leader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志（0代表存在 2代表删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'delFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dictCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dictSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dictLabel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典键值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dictValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'dictType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样式属性（其他样式扩展）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'cssClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表格回显样式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'listClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否默认（Y是 N否）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'isDefault'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典数据表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_data'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'dictId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'dictName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'dictType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_dict_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'infoId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'userName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'ipaddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'loginLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览器类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'browser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'os'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录状态（0成功 1失败）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提示消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'msg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor', @level2type=N'COLUMN',@level2name=N'loginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_logininfor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'menuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'menuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'parentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'orderNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'component'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否外链(0 否 1 是)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'isFrame'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否缓存(0缓存 1不缓存)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'isCache'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单类型（M目录 C菜单 F按钮 L链接）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'menuType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单状态（0显示 1隐藏）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'visible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'perms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'notice_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'notice_title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告类型 (1通知 2公告)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'notice_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'notice_content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知公告表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_notice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务类型（0其它 1新增 2修改 3删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'businessType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方法名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'method'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'requestMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类别（0其它 1后台用户 2手机端用户）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operatorType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'deptName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主机地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operParam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'jsonResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作状态（0正常 1异常）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'errorMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'operTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求用时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log', @level2type=N'COLUMN',@level2name=N'elapsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作日志记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_oper_log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'postId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'postCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'postName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'postSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_post'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'roleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'roleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'roleKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'roleSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据范围（1：全部数据权限 2：自定数据权限 3：本部门数据权限 ）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'dataScope'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单树选择项是否关联显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'menu_check_strictly'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门树选择项是否关联显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'dept_check_strictly'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志（0代表存在 2代表删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'delFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu', @level2type=N'COLUMN',@level2name=N'menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色和菜单关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_role_menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'jobGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行时间表达式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'cron'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'程序集名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'assemblyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务所在类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'className'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'runTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'beginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'endTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'触发器类型（0、simple 1、cron）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'triggerType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行间隔时间(单位:秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'intervalSecond'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启动' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'isStart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传入参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'jobParams'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定时任务表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务日志ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'jobLogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'jobId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'jobName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务组名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'jobGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'jobMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行状态（0正常 1失败）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'exception'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'createTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调用目标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'invokeTarget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作业用时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log', @level2type=N'COLUMN',@level2name=N'elapsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定时任务调度日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_tasks_log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'userId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'deptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'userName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'nickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型（00系统用户）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'userType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'phonenumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户性别（0男 1女 2未知）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号状态（0正常 1停用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志（0代表存在 2代表删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'delFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'loginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'loginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'create_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'update_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_post', @level2type=N'COLUMN',@level2name=N'userId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_post', @level2type=N'COLUMN',@level2name=N'postId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户岗位绑定表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_post'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_role', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_role', @level2type=N'COLUMN',@level2name=N'role_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户和角色关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_user_role'
GO
USE [master]
GO
ALTER DATABASE [FdSoft.CodeGenerator] SET  READ_WRITE 
GO
