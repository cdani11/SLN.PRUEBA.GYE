CREATE DATABASE [CTP_Prueba]
GO

USE [CTP_Prueba]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Categoria] [smallint] NOT NULL,
	[Imagen] [binary](1) NULL,
	[Precio] [decimal](19, 4) NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [Productos_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransacCab]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransacCab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTransacDet] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](19, 4) NOT NULL,
 CONSTRAINT [TransacCab_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransacDet]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransacDet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](19, 4) NOT NULL,
	[Total] [decimal](19, 4) NOT NULL,
 CONSTRAINT [TransacDet_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Contrasena] [varchar](255) NOT NULL,
	[UsuarioCreacion] [varchar](50) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [bit] NOT NULL,
	[NombreUsuario] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [Categoria], [Imagen], [Precio], [Stock]) VALUES (1, N'Producto 1', N'Nuevo producto', 1, NULL, CAST(12.3000 AS Decimal(19, 4)), 5)
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [Email], [Contrasena], [UsuarioCreacion], [FechaCreacion], [UsuarioModificacion], [FechaModificacion], [Estado], [NombreUsuario]) VALUES (1, N'Carlos', N'Tigrero', N'cdanitg@gmail.com', N'/3WX5oRtrBm+9a2trHd7Hw==', N'admin', CAST(N'2025-10-26T22:12:11.227' AS DateTime), NULL, NULL, 1, N'ctigrero')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__A9D10534C1C5BE5A]    Script Date: 27/10/2025 17:40:32 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[TransacCab]  WITH CHECK ADD  CONSTRAINT [TransacCab_TransacDet_Id_fk] FOREIGN KEY([IdTransacDet])
REFERENCES [dbo].[TransacDet] ([Id])
GO
ALTER TABLE [dbo].[TransacCab] CHECK CONSTRAINT [TransacCab_TransacDet_Id_fk]
GO
ALTER TABLE [dbo].[TransacDet]  WITH CHECK ADD  CONSTRAINT [TransacDet_Productos_Id_fk] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[TransacDet] CHECK CONSTRAINT [TransacDet_Productos_Id_fk]
GO
/****** Object:  StoredProcedure [dbo].[DEL_Producto]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DEL_Producto]
    @Id INT
AS
BEGIN
    DELETE Productos WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[INS_Producto]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INS_Producto]
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100),
    @Categoria SMALLINT,
    @Imagen BINARY = NULL,
    @Precio DECIMAL(19, 4),
    @Stock INT
AS
BEGIN
    INSERT INTO Productos(Nombre, Descripcion, Categoria, Imagen, Precio, Stock)
    VALUES (@Nombre, @Descripcion, @Categoria, @Imagen, @Precio, @Stock)
END
GO
/****** Object:  StoredProcedure [dbo].[QRY_Producto]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[QRY_Producto]
AS
BEGIN
    SELECT Id,
        Nombre,
        Descripcion,
        Categoria,
        Imagen,
        Precio,
        Stock
    FROM Productos
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LoginUsuario]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LoginUsuario]
    @NombreUsuario VARCHAR(30),
    @Contrasena VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
		U.NombreUsuario as Usuario,
        U.Id,
        U.Nombre,
        U.Apellido,
        U.Email,
        U.Estado
    FROM dbo.Usuario U
    WHERE U.NombreUsuario = @NombreUsuario
      AND U.Contrasena = @Contrasena
      AND U.Estado = 1; 
END;
GO
/****** Object:  StoredProcedure [dbo].[UPD_Producto]    Script Date: 27/10/2025 17:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UPD_Producto]
    @Id INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100),
    @Categoria SMALLINT,
    @Imagen BINARY,
    @Precio DECIMAL(19, 4),
    @Stock INT
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Categoria = @Categoria,
        Imagen = @Imagen,
        Precio = @Precio,
        Stock = @Stock
    WHERE Id = @Id
END
GO
