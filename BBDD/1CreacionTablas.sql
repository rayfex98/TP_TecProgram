/****** Script de creaccion DB ******/
/*
	v1.2: Creacion de tablas  modulos 2, 3, 4
	NOTA: Se deben modificar las rutas donde se guradaran los archivos, en el caso de que sea necesario.
*/
/****** START ******/
USE [master]
GO
/****** Object:  Database [dbTecProg]    Script Date: 20/6/2021 20:51:00 ******/
CREATE DATABASE [dbTecProg]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbTecProg', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbTecProg.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbTecProg_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbTecProg_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbTecProg] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTecProg].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTecProg] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTecProg] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTecProg] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTecProg] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTecProg] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTecProg] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbTecProg] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTecProg] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTecProg] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTecProg] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTecProg] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTecProg] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTecProg] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTecProg] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTecProg] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbTecProg] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTecProg] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTecProg] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTecProg] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTecProg] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTecProg] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTecProg] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTecProg] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbTecProg] SET  MULTI_USER 
GO
ALTER DATABASE [dbTecProg] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTecProg] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTecProg] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTecProg] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbTecProg] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbTecProg] SET QUERY_STORE = OFF
GO
USE [dbTecProg]
GO
/****** Object:  Table [dbo].[alerta]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alerta](
	[id_alerta] [int] IDENTITY(1,1) NOT NULL,
	[id_stock] [int] NOT NULL,
	[id_persona] [int] NOT NULL,
	[cantidad_minima] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alerta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[id_categoria] [smallint] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[habilitado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_orden]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_orden](
	[id_detalle_orden] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[id_orden] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
 CONSTRAINT [PK_id_detalle_orden] PRIMARY KEY CLUSTERED 
(
	[id_detalle_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[direccion]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[direccion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[calle] [nvarchar](50) NULL,
	[altura] [nvarchar](20) NULL,
	[localidad] [nvarchar](50) NOT NULL,
	[codigo_postal] [nvarchar](50) NULL,
	[provincia] [nvarchar](50) NULL,
 CONSTRAINT [PK_direccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[metodo_pago]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[metodo_pago](
	[id_metodo_pago] [int] IDENTITY(1,1) NOT NULL,
	[TIPO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_metodo_pago] PRIMARY KEY CLUSTERED 
(
	[id_metodo_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_persona] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden_compra]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_compra](
	[id_orden] [int] NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[id_persona] [int] NULL,
	[fecha_aprobacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden_venta]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_venta](
	[id_orden] [int] NOT NULL,
	[id_metodo_pago] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso_por_rol]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_por_rol](
	[id_rol] [int] NOT NULL,
	[id_permiso] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[dni] [int] NOT NULL,
	[id_direccion] [int] NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_persona] UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_persona_dni] UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio_compra] [float] NOT NULL,
	[precio_venta] [float] NOT NULL,
	[id_categoria] [int] NOT NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[id_direccion] [int] NOT NULL,
	[cuil] [varchar](13) NOT NULL,
	[razonsocial] [varchar](30) NOT NULL,
	[habilitado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cuil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sesion]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sesion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha_inicio] [datetime] NOT NULL,
	[fecha_fin] [datetime] NULL,
 CONSTRAINT [PK_sesion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock](
	[id_stock] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[habilitado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarjeta]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarjeta](
	[id_tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[cvc] [varchar](50) NOT NULL,
	[fecha_vencimiento] [varchar](50) NOT NULL,
	[nombre_tarjeta] [varchar](50) NOT NULL,
	[numero_tarjeta] [varchar](50) NOT NULL,
	[id_orden] int NOT NULL
 CONSTRAINT [PK_tarjeta] PRIMARY KEY CLUSTERED 
(
	[id_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 9/6/2021 22:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id_persona] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[legajo] [int] NOT NULL,
	[deshabilitado] [datetime] NULL,
 PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_cliente_persona]    Script Date: 9/6/2021 22:40:47 ******/
CREATE NONCLUSTERED INDEX [IXFK_cliente_persona] ON [dbo].[cliente]
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_id_orden]    Script Date: 9/6/2021 22:40:47 ******/
CREATE NONCLUSTERED INDEX [IXFK_id_orden] ON [dbo].[detalle_orden]
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_id_producto]    Script Date: 9/6/2021 22:40:47 ******/
CREATE NONCLUSTERED INDEX [IXFK_id_producto] ON [dbo].[detalle_orden]
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_orden_venta_metodo_pago]    Script Date: 9/6/2021 22:40:47 ******/
CREATE NONCLUSTERED INDEX [IXFK_orden_venta_metodo_pago] ON [dbo].[orden_venta]
(
	[id_metodo_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_orden_venta_orden]    Script Date: 9/6/2021 22:40:47 ******/
CREATE NONCLUSTERED INDEX [IXFK_orden_venta_orden] ON [dbo].[orden_venta]
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_producto_categoria]    Script Date: 9/6/2021 22:40:47 ******/
CREATE NONCLUSTERED INDEX [IXFK_producto_categoria] ON [dbo].[producto]
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usuario] ADD  CONSTRAINT [DF_usuario_deshabilitado]  DEFAULT ((0)) FOR [deshabilitado]
GO
ALTER TABLE [dbo].[alerta]  WITH CHECK ADD FOREIGN KEY([id_persona])
REFERENCES [dbo].[usuario] ([id_persona])
GO
ALTER TABLE [dbo].[alerta]  WITH CHECK ADD FOREIGN KEY([id_stock])
REFERENCES [dbo].[stock] ([id_stock])
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_persona]
GO
ALTER TABLE [dbo].[detalle_orden]  WITH CHECK ADD  CONSTRAINT [FK_id_orden] FOREIGN KEY([id_orden])
REFERENCES [dbo].[orden] ([id])
GO
ALTER TABLE [dbo].[detalle_orden] CHECK CONSTRAINT [FK_id_orden]
GO
ALTER TABLE [dbo].[detalle_orden]  WITH CHECK ADD  CONSTRAINT [FK_id_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[detalle_orden] CHECK CONSTRAINT [FK_id_producto]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD FOREIGN KEY([id_persona])
REFERENCES [dbo].[usuario] ([id_persona])
GO
ALTER TABLE [dbo].[orden_compra]  WITH CHECK ADD FOREIGN KEY([id_orden])
REFERENCES [dbo].[orden] ([id])
GO
ALTER TABLE [dbo].[orden_compra]  WITH CHECK ADD FOREIGN KEY([id_persona])
REFERENCES [dbo].[usuario] ([id_persona])
GO
ALTER TABLE [dbo].[orden_compra]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[orden_venta]  WITH CHECK ADD  CONSTRAINT [FK_orden_venta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[orden_venta] CHECK CONSTRAINT [FK_orden_venta_cliente]
GO
ALTER TABLE [dbo].[orden_venta]  WITH CHECK ADD  CONSTRAINT [FK_orden_venta_metodo_pago] FOREIGN KEY([id_metodo_pago])
REFERENCES [dbo].[metodo_pago] ([id_metodo_pago])
GO
ALTER TABLE [dbo].[orden_venta] CHECK CONSTRAINT [FK_orden_venta_metodo_pago]
GO
ALTER TABLE [dbo].[orden_venta]  WITH CHECK ADD FOREIGN KEY([id_orden])
REFERENCES [dbo].[orden] ([id])
GO
ALTER TABLE [dbo].[permiso_por_rol]  WITH CHECK ADD  CONSTRAINT [FK_permiso_por_rol_permiso] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[permiso] ([id])
GO
ALTER TABLE [dbo].[permiso_por_rol] CHECK CONSTRAINT [FK_permiso_por_rol_permiso]
GO
ALTER TABLE [dbo].[permiso_por_rol]  WITH CHECK ADD  CONSTRAINT [FK_permiso_por_rol_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[permiso_por_rol] CHECK CONSTRAINT [FK_permiso_por_rol_rol]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [FK_persona_direccion] FOREIGN KEY([id_direccion])
REFERENCES [dbo].[direccion] ([id])
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [FK_persona_direccion]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([id_direccion])
REFERENCES [dbo].[direccion] ([id])
GO
ALTER TABLE [dbo].[sesion]  WITH CHECK ADD  CONSTRAINT [FK_sesion_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_persona])
GO
ALTER TABLE [dbo].[sesion] CHECK CONSTRAINT [FK_sesion_usuario]
GO
ALTER TABLE [tarjeta] ADD CONSTRAINT [FK_tarjeta_orden_venta]
	FOREIGN KEY ([id_orden]) REFERENCES [orden_venta] ([id_orden]) ON DELETE No Action ON UPDATE No Action
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([id_persona])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
ALTER TABLE [dbo].[alerta]  WITH CHECK ADD CHECK  (([cantidad_minima]>=(0)))
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD CHECK  (([cantidad]>=(0)))
GO
USE [master]
GO
ALTER DATABASE [dbTecProg] SET  READ_WRITE 
GO