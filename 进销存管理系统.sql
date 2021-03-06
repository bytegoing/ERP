USE [master]
GO
/****** Object:  Database [InventoryManage]    Script Date: 2020/7/14 18:42:56 ******/
CREATE DATABASE [InventoryManage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManage', FILENAME = N'E:\ENV\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\InventoryManage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryManage_log', FILENAME = N'E:\ENV\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\InventoryManage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InventoryManage] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryManage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryManage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryManage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryManage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryManage] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryManage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryManage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryManage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryManage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryManage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryManage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryManage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryManage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryManage] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryManage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryManage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryManage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryManage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryManage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryManage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryManage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryManage] SET RECOVERY FULL 
GO
ALTER DATABASE [InventoryManage] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryManage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryManage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryManage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryManage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryManage] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryManage] SET QUERY_STORE = OFF
GO
USE [InventoryManage]
GO
/****** Object:  Table [dbo].[tbl_BusinessUnit]    Script Date: 2020/7/14 18:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_BusinessUnit](
	[BU_No] [int] IDENTITY(1,1) NOT NULL,
	[BU_Name] [varchar](20) NOT NULL,
	[BU_Type] [varchar](10) NOT NULL,
	[BU_Address] [varchar](100) NULL,
	[BU_ContactName] [varchar](10) NULL,
	[BU_Phone] [varchar](11) NULL,
	[BU_Email] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[BU_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Good]    Script Date: 2020/7/14 18:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Good](
	[G_No] [int] IDENTITY(1,1) NOT NULL,
	[G_Name] [nvarchar](30) NOT NULL,
	[G_Package] [nvarchar](10) NULL,
	[G_Unit] [nvarchar](5) NULL,
	[G_Type] [int] NOT NULL,
	[G_MaxInventory] [int] NULL,
	[G_MinInventory] [int] NULL,
	[G_Remark] [nvarchar](100) NULL,
 CONSTRAINT [PK_Good] PRIMARY KEY CLUSTERED 
(
	[G_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GoodType]    Script Date: 2020/7/14 18:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GoodType](
	[GT_No] [int] IDENTITY(1,1) NOT NULL,
	[GT_Name] [nvarchar](15) NOT NULL,
	[GT_ParentNo] [int] NULL,
 CONSTRAINT [PK_GoodType] PRIMARY KEY CLUSTERED 
(
	[GT_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Stock]    Script Date: 2020/7/14 18:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Stock](
	[S_No] [int] IDENTITY(1,1) NOT NULL,
	[S_GoodNo] [int] NOT NULL,
	[S_WarehouseNo] [int] NOT NULL,
	[S_Type] [nvarchar](10) NOT NULL,
	[S_Reason] [nvarchar](50) NULL,
	[S_In_Count] [int] NULL,
	[S_In_SinglePrice] [int] NULL,
	[S_Out_Count] [int] NULL,
	[S_Out_SinglePrice] [int] NULL,
	[S_Remaining_Count] [int] NOT NULL,
	[S_Remaining_Price] [int] NOT NULL,
	[S_BusinessUnitNo] [int] NULL,
	[S_OperatorLoginName] [nvarchar](20) NOT NULL,
	[S_Date] [date] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[S_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 2020/7/14 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[U_LoginName] [nvarchar](20) NOT NULL,
	[U_Password] [nvarchar](32) NOT NULL,
	[U_Permission] [nvarchar](37) NOT NULL,
	[U_Name] [nvarchar](10) NULL,
	[U_Sex] [nvarchar](2) NULL,
	[U_Department] [nvarchar](20) NULL,
	[U_Phone] [nvarchar](11) NULL,
	[U_Birthday] [date] NULL,
	[U_EntryDate] [date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[U_LoginName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Warehouse]    Script Date: 2020/7/14 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Warehouse](
	[W_No] [int] IDENTITY(1,1) NOT NULL,
	[W_Name] [nvarchar](10) NOT NULL,
	[W_Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[W_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_User] ([U_LoginName], [U_Password], [U_Permission], [U_Name], [U_Sex], [U_Department], [U_Phone], [U_Birthday], [U_EntryDate]) VALUES (N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789', N'系统管理员', N'男', N'系统', N'00000000000', CAST(N'2000-01-01' AS Date), CAST(N'2020-01-01' AS Date))
ALTER TABLE [dbo].[tbl_Good] ADD  CONSTRAINT [DF_tbl_Good_G_Type]  DEFAULT ((0)) FOR [G_Type]
GO
ALTER TABLE [dbo].[tbl_Good] ADD  CONSTRAINT [DF_Good_G_Maxhold]  DEFAULT ((0)) FOR [G_MaxInventory]
GO
ALTER TABLE [dbo].[tbl_Good] ADD  CONSTRAINT [DF_Good_G_Minhold]  DEFAULT ((0)) FOR [G_MinInventory]
GO
ALTER TABLE [dbo].[tbl_GoodType] ADD  CONSTRAINT [DF_GoodType_GT_ParentNo]  DEFAULT ((0)) FOR [GT_ParentNo]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_In_Count]  DEFAULT ((0)) FOR [S_In_Count]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_In_SinglePrice]  DEFAULT ((0)) FOR [S_In_SinglePrice]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_Out_Count]  DEFAULT ((0)) FOR [S_Out_Count]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_Out_SinglePrice]  DEFAULT ((0)) FOR [S_Out_SinglePrice]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_Remaining_Count]  DEFAULT ((0)) FOR [S_Remaining_Count]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_Remaining_TotalPrice]  DEFAULT ((0)) FOR [S_Remaining_Price]
GO
ALTER TABLE [dbo].[tbl_Stock] ADD  CONSTRAINT [DF_Stock_S_BusinessUnitNo]  DEFAULT ((0)) FOR [S_BusinessUnitNo]
GO
ALTER TABLE [dbo].[tbl_User] ADD  CONSTRAINT [DF_tbl_User_U_Permission]  DEFAULT ((0)) FOR [U_Permission]
GO
ALTER TABLE [dbo].[tbl_Good]  WITH CHECK ADD  CONSTRAINT [FK_Good_GoodType] FOREIGN KEY([G_Type])
REFERENCES [dbo].[tbl_GoodType] ([GT_No])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Good] CHECK CONSTRAINT [FK_Good_GoodType]
GO
ALTER TABLE [dbo].[tbl_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Good] FOREIGN KEY([S_GoodNo])
REFERENCES [dbo].[tbl_Good] ([G_No])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Stock] CHECK CONSTRAINT [FK_Stock_Good]
GO
ALTER TABLE [dbo].[tbl_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Warehouse] FOREIGN KEY([S_WarehouseNo])
REFERENCES [dbo].[tbl_Warehouse] ([W_No])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Stock] CHECK CONSTRAINT [FK_Stock_Warehouse]
GO
ALTER TABLE [dbo].[tbl_Stock]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Stock_tbl_BusinessUnit] FOREIGN KEY([S_BusinessUnitNo])
REFERENCES [dbo].[tbl_BusinessUnit] ([BU_No])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[tbl_Stock] CHECK CONSTRAINT [FK_tbl_Stock_tbl_BusinessUnit]
GO
ALTER TABLE [dbo].[tbl_Stock]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Stock_tbl_User] FOREIGN KEY([S_OperatorLoginName])
REFERENCES [dbo].[tbl_User] ([U_LoginName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_Stock] CHECK CONSTRAINT [FK_tbl_Stock_tbl_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'往来单位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'往来单位类别:客户、经销商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_ContactName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_BusinessUnit', @level2type=N'COLUMN',@level2name=N'BU_Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号(自增)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格/400ml,500g等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_Package'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位/瓶,袋等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_Unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大库存(0代表无限制)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_MaxInventory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_MinInventory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'COLUMN',@level2name=N'G_Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品与商品类别的外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Good', @level2type=N'CONSTRAINT',@level2name=N'FK_Good_GoodType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_GoodType', @level2type=N'COLUMN',@level2name=N'GT_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_GoodType', @level2type=N'COLUMN',@level2name=N'GT_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父类编号(如果有,默认值0)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_GoodType', @level2type=N'COLUMN',@level2name=N'GT_ParentNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存变动流水号自增' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_GoodNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_WarehouseNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作说明:进货入库,进货退货,销售出库,其他出库等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当出入库操作为其他时在此存放理由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本次入仓数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_In_Count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本次入仓单价(单位分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_In_SinglePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本次出仓数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Out_Count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本次出仓单价(单位分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Out_SinglePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'剩余数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Remaining_Count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'剩余总价(单位分)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Remaining_Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'往来单位Id(为0则已经删除)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_BusinessUnitNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_OperatorLoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Stock', @level2type=N'COLUMN',@level2name=N'S_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码(md5加密)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Permission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动电话号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入职日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'U_EntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Warehouse', @level2type=N'COLUMN',@level2name=N'W_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Warehouse', @level2type=N'COLUMN',@level2name=N'W_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Warehouse', @level2type=N'COLUMN',@level2name=N'W_Address'
GO
USE [master]
GO
ALTER DATABASE [InventoryManage] SET  READ_WRITE 
GO
