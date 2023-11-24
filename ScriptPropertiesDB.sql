USE [PropertiesDB]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[IdOwner] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Photo] [nvarchar](500) NULL,
	[Birthday] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOwner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[IdProperty] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NULL,
	[CodeInternal] [nvarchar](50) NULL,
	[YearProperty] [int] NULL,
	[IdOwner] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyImage]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImage](
	[IdPropertyImage] [int] IDENTITY(1,1) NOT NULL,
	[IdProperty] [int] NULL,
	[FilePropertyImage] [nvarchar](500) NULL,
	[Enabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPropertyImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyTrace]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTrace](
	[IdPropertyTrace] [int] IDENTITY(1,1) NOT NULL,
	[DataSale] [date] NULL,
	[Name] [nvarchar](255) NULL,
	[Value] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[IdProperty] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPropertyTrace] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD FOREIGN KEY([IdOwner])
REFERENCES [dbo].[Owner] ([IdOwner])
GO
ALTER TABLE [dbo].[PropertyImage]  WITH CHECK ADD FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Property] ([IdProperty])
GO
ALTER TABLE [dbo].[PropertyTrace]  WITH CHECK ADD FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Property] ([IdProperty])
GO
/****** Object:  StoredProcedure [dbo].[spImagesProperty]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023/11/18
-- Description:	Obtener imagenes de propiedad
-- =============================================
CREATE PROCEDURE [dbo].[spImagesProperty]
(
@IdProperty int
)
AS
BEGIN

  SELECT IdPropertyImage,FilePropertyImage,Enabled from PropertyImage where IdProperty=@IdProperty
END
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spLogin]
(
@name nvarchar(50),
@password  nvarchar(50)
)
AS
BEGIN
	
	SELECT Role from Users o where name=@name and Password=@password;
END
GO
/****** Object:  StoredProcedure [dbo].[spOwnerById]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023/11/14
-- Description:	Obtener Owner por Id
-- =============================================
CREATE PROCEDURE [dbo].[spOwnerById]
(
@IdOwner int
)
AS
BEGIN

  SELECT IdOwner,Name,Address,Photo,Birthday from Owner where IdOwner=@IdOwner
END
GO
/****** Object:  StoredProcedure [dbo].[spOwnerEdit]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023-11-15
-- Description:	Actualizar registro para la tabla owner
-- =============================================
CREATE PROCEDURE [dbo].[spOwnerEdit]
	@IdOwner int,
	@Name nvarchar(255),
	@Address nvarchar(255),
	@Photo nvarchar(500),
	@Birthday date

AS
BEGIN

UPDATE [dbo].[Owner]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Photo] = @Photo
      ,[Birthday] = @Birthday
 WHERE IdOwner = @IdOwner
END
GO
/****** Object:  StoredProcedure [dbo].[spOwnerList]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spOwnerList]
AS
BEGIN
	
	SELECT IdOwner,Name,Address,Photo,Birthday from Owner
END
GO
/****** Object:  StoredProcedure [dbo].[spOwnerRegister]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023-11-15
-- Description:	Insert para la tabla owner
-- =============================================
CREATE PROCEDURE [dbo].[spOwnerRegister]
	@Name nvarchar(255),
	@Address nvarchar(255),
	@Photo nvarchar(500),
	@Birthday date

AS
BEGIN

INSERT INTO [dbo].[Owner]
           ([Name]
           ,[Address]
           ,[Photo]
           ,[Birthday])
     VALUES
           (@Name 
           ,@Address
           ,@Photo
           ,@Birthday)
END
GO
/****** Object:  StoredProcedure [dbo].[spPropertyAddImage]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023-11-15
-- Description:	Insert para la tabla PropertyImage
-- =============================================
CREATE PROCEDURE [dbo].[spPropertyAddImage]
	@IdProperty int,
	@FilePropertyImage nvarchar(500),
	@Enabled bit

AS
BEGIN

INSERT INTO [dbo].[PropertyImage]
           ([IdProperty]
           ,[FilePropertyImage]
           ,[Enabled])
     VALUES
           (@IdProperty
           ,@FilePropertyImage
           ,@Enabled)
END
GO
/****** Object:  StoredProcedure [dbo].[spPropertyChangePrice]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023-11-15
-- Description:	Actualizar registro para la tabla Property
-- =============================================
Create PROCEDURE [dbo].[spPropertyChangePrice]
	@IdProperty int,
	@Price decimal(18,2)

AS
BEGIN

UPDATE [dbo].[Property]
   SET [Price] = @Price
 WHERE IdProperty =@IdProperty 
END
GO
/****** Object:  StoredProcedure [dbo].[spPropertyEdit]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023-11-15
-- Description:	Actualizar registro para la tabla Property
-- =============================================
Create PROCEDURE [dbo].[spPropertyEdit]
	@IdProperty int,
	@Name nvarchar(255),
	@Address nvarchar(255),
	@Price decimal(18,2),
	@CodeInternal nvarchar(50),
	@YearProperty int ,
	@IdOwner int

AS
BEGIN

UPDATE [dbo].[Property]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Price] = @Price
      ,[CodeInternal] = @CodeInternal
      ,[YearProperty] = @YearProperty
      ,[IdOwner] = @IdOwner
 WHERE IdProperty =@IdProperty 
END
GO
/****** Object:  StoredProcedure [dbo].[spPropertyListFilter]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023/11/18
-- Description:	Obterner registos con filtros
-- =============================================
CREATE PROCEDURE [dbo].[spPropertyListFilter]
(
@Filter nvarchar(250)
)
AS
BEGIN
	
	SELECT p.IdProperty,p.Name ,p.Address,p.Price,p.CodeInternal,p.YearProperty,o.Name Owner
	FROM Property p
	inner join Owner o on p.IdOwner=o.IdOwner
	WHERE p.Name LIKE @Filter OR p.Address LIKE @Filter OR p.YearProperty LIKE @Filter OR p.Price LIKE @Filter OR  p.CodeInternal LIKE @Filter
END
GO
/****** Object:  StoredProcedure [dbo].[spPropertyRegister]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023/11/18
-- Description:	Creación de una nueva propiedad
-- =============================================
CREATE PROCEDURE [dbo].[spPropertyRegister]
	@Name nvarchar(255),
	@Address nvarchar(255),
	@Price decimal(18,2),
	@CodeInternal nvarchar(50),
	@YearProperty int ,
	@IdOwner int
AS
BEGIN

INSERT INTO [dbo].[Property]
           ([Name]
           ,[Address]
           ,[Price]
           ,[CodeInternal]
           ,[YearProperty]
           ,[IdOwner])
     VALUES
           (@Name
           ,@Address
           ,@Price
           ,@CodeInternal
           ,@YearProperty
           ,@IdOwner)


END
GO
/****** Object:  StoredProcedure [dbo].[spTracesProperty]    Script Date: 11/23/2023 8:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Yeinson Acuña
-- Create date: 2023/11/18
-- Description:	Obtener los seguimientos de propiedad
-- =============================================
CREATE PROCEDURE [dbo].[spTracesProperty]
(
@IdProperty int
)
AS
BEGIN

  SELECT IdPropertyTrace,DataSale,Name,Value,Tax from PropertyTrace where IdProperty=@IdProperty
END
GO
