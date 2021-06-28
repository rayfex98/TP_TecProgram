--CARGA DE MODULO 2
USE [dbTecProg]
GO
INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[provincia])
     VALUES
           ('Las Rosas', '3245','Monte Grande','1842','Buenos Aires'),
		   ('Malvinas', '464','Luis Guillon','1200','Buenos Aires'),
		   ('Las Heras', '4556','Lomas de Zamora','1800','Buenos Aires'),
		   ('Fair', '123','Ezeiza','1111','Buenos Aires'),
		   ('Oliver', '3454','Monte Grande','1842','Buenos Aires'),
		   ('9 de Julio', '355','Monte Grande','1842','Buenos Aires'),
		   ('Las Rosas', '34','Monte Grande','1842','Buenos Aires'),
		   ('25 de Mayo', '34','Ezeiza','1333','Buenos Aires')

GO
/*Datos Tabla Personas*/
USE [dbTecProg]
GO
INSERT INTO [dbo].[persona]
           ([apellido]
           ,[nombre]
           ,[dni]
		   ,[id_direccion])
     VALUES
		   ('Morrone','Florencia','22333444', 1),
		   ('Solohaga','Braian','22333111', 2),
		   ('Ovejero','Jorge','33444666', 3),
           ('Ramirez','Martin','33444555', 4),
           ('Santos','Mario','33666999', 5),
           ('Medina','Gabriel','11333999', 6),
           ('Lampone','Pablo','11222999', 7),
           ('Ravenna','Emilio','11555999', 8)

GO
/*Datos Tabla Permiso*/
USE [dbTecProg]
GO

INSERT INTO [dbo].[permiso]
           ([descripcion])
     VALUES
		   ('ADMINISTRAR_USUARIOS'),
		   ('CONTROLAR_STOCK'),
		   ('CONFIGURAR_ALERTAS'),
		   ('GENERAR_ORDEN_DE_COMPRA'),
		   ('VENDER_PRODUCTOS'),
		   ('GESTIONAR_CLIENTES'),
		   ('APROBAR_ORDEN_DE_COMPRA'),
		   ('VER_REPORTES_DE_VENTA')
GO
/*Datos Tabla Rol*/
USE [dbTecProg]
GO
INSERT INTO [dbo].[rol]
           ([descripcion])
     VALUES
		   ('Administrador'),
		   ('Encargado de inventario y logistica'),
		   ('Vendedor'),
		   ('Gerente')
GO
/*Datos Tabla Permiso_Por_Rol*/
USE [dbTecProg]
GO
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(1,1)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(2,2)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(2,3)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(2,4)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(3,5)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(3,6)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(4,7)
INSERT INTO [dbo].[permiso_por_rol]([id_rol],[id_permiso]) VALUES(4,8)
GO
/*Datos Tabla Usuario*/
USE [dbTecProg]
GO
INSERT INTO [dbo].[usuario]
           ([id_persona]
           ,[id_rol]
           ,[password]
           ,[legajo])
     VALUES
			((select persona.id from persona where persona.apellido like 'morrone'),1, '123456', '0001'),
			((select persona.id from persona where persona.apellido like 'solohaga'),1, '123456', '0002'),
			((select persona.id from persona where persona.apellido like 'ovejero'),1, '123456', '0003'),
			((select persona.id from persona where persona.apellido like 'ramirez'),1, '123456', '0004'),
			((select persona.id from persona where persona.apellido like 'santos'),2, '123456', '0005'),
			((select persona.id from persona where persona.apellido like 'medina'),3, '123456', '0006'),
			((select persona.id from persona where persona.apellido like 'lampone'),4, '123456', '0007'),
			((select persona.id from persona where persona.apellido like 'ravenna'),4, '123456', '0008')

GO
--------------------------------------------------------------------------------------
--MODULO 4

--cargo categoria
	go
	insert into [dbo].[CATEGORIA] (descripcion,habilitado)	
	values	('hogar',20-10-20),
			('jardin',20-10-20),
			('herramientas',20-10-20),
			('electrodomesticos',20-10-20),
			('muebles',20-10-20),
			('tecnologia',20-10-20),
			('decoracion',20-10-20),
			('indumentaria',20-10-20),
			('camping',20-10-20),
			('deportes',20-10-20),
			('instrumentos',20-10-20),
			('iluminaria',20-10-20)
	go
--cargo producto
	go
	insert into [dbo].[PRODUCTO] (id_categoria,nombre,precio_compra,precio_venta)
	values	(1,'cocina ',2000,4000),
			(2,'corta cesped',1400,8000),
			(3,'martillo ',200,600),
			(4,'batidora',1000,3500),
			(5,'ropero',1400,5800),
			(6,'computadora',10000,3000),
			(7,'lampara',400,800),
			(8,'camisa',400,800),
			(6,'dvd',2000,5000),
			(8,'short',150,600),
			(9,'carpa',2000,5000),
			(10,'pelota',800,1000),
			(11,'guitarra',1000,2000),
			(12,'Lampara',1000,2000)
	go
--cargo stock
	go
	insert into [dbo].[STOCK] (id_producto,cantidad,habilitado) 
	values	(1,20,GETDATE()),
			(2,50,GETDATE()),
			(3,100,GETDATE()),
			(4,100,GETDATE()),
			(5,10,GETDATE()),
			(6,100,GETDATE()),
			(7,100,GETDATE()),
			(8,100,GETDATE()),
			(9,50,GETDATE()),
			(10,10,GETDATE()),
			(11,100,GETDATE()),
			(12,10,GETDATE())
	go
--cargo direccion

	insert into dbo.direccion (altura,calle,codigo_postal,localidad,provincia)
	values	(123,'estrada','1122','ezeiza','buenos aires'),
			(67,'paraguay','1231','temperley','buenos aires'),
			(64,'belgrano','1823','capital','buenos aires'),
			(13,'cabildo','1823','capital','buenos aires'),
			(1323,'uruguay','1823','flores','buenos aires'),
			(27,'ramos','1823','lanus','buenos Aires'),
			(1313,'alcorta','1823','caballito','buenos aires'),
			(121,'cabildo','1823','banfield','buenos aires'),
			(232,'brasil','1823','temperley','buenos aires'),
			(156,'yrigoyen','5641','rio cuarto','cordoba'),
			(4245,'san martin','1823','temperley','buenos aires'),
			(21,'belgrano','1254','rio cuarto','cordoba'),
			(456,'jacaranda','1234','monte grande','buenos aires'),
			(416,'santa fe','1124','monte grande','la pampa'),
			(1456,'aaaaaaaa','15634','rio cuarto','santa fe'),
			(4356,'25 mayo','1244','monte grande','san luis'),
			(46,'guarani','1412','rio hondo','mendoza'),
			(463,'general peron','1123','los horneros','rio negro')
	go
 -- cargo alerta 
	 go
	 insert into dbo.ALERTA(id_stock,id_persona,cantidad_minima) 
	 values		(1,1,100),
				(2,3,100),
				(3,2,100),
				(4,3,100),
				(5,1,100)
	 go
--carga proveedor 
	 go
	 insert into dbo.PROVEEDOR(id_direccion,cuil,razonsocial,habilitado) 
	 values		(15,20302010222,'loma negra',GETDATE()),
				(16,32220102224,'molinos cañuelas',GETDATE()),
				(17,20364587586,'coto',GETDATE()),
				(18,21321411212,'dia',GETDATE()),
				(19,30010242122,'sinteplast',GETDATE()),
				(20,80102123122,'la redonda',GETDATE()),
				(21,11210242122,'carrefour',GETDATE()),
				(22,68010242122,'zara',GETDATE())
	 go

--carga orden 
	 go
	 insert into dbo.orden(id_persona,fecha) 
	 values		(1,GETDATE()),
				(1,GETDATE()),
				(2,GETDATE()),
				(2,GETDATE()),
				(3,GETDATE()),
				(4,GETDATE()),
				(4,GETDATE()),
				(4,GETDATE())
	 go
--carga detalleorden
	go
	INSERT INTO [dbo].[detalle_orden]
			   ([cantidad]
			   ,[id_orden]
			   ,[id_producto])
		 VALUES
			   (10,1,2),
			   (5,1,1),
			   (20,1,3),
			   (10,2,6),
			   (5,2,4),
			   (20,3,5),
			   (10,3,5),
			   (30,4,7),
			   (50,5,10),
			   (40,5,11),
			   (54,6,12),
			   (30,7,8)
	GO
	insert into dbo.detalle_orden (id_orden,id_producto,cantidad)
	 values	 (1,2,30),
			 (4,2,30),
			 (2,2,30),
			 (2,1,30),
			 (2,3,30),
			 (3,2,30),
			 (1,4,30)
	 GO
--carga ordencompra 
	 go
	 insert into dbo.orden_compra (id_orden,id_persona,id_proveedor) 
	 values		(1,1,5),
				(2,2,1),
				(3,2,2),
				(4,3,1)
	 go
	 
------------------------------------------------------------------------------------------
--MODULO 3

INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (1)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (2)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (3)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (4)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (5)
GO

INSERT INTO [dbo].[metodo_pago]
           ([TIPO])
     VALUES
           ('Efectivo')
GO
INSERT INTO [dbo].[metodo_pago]
           ([TIPO])
     VALUES
           ('Tarjeta')
GO

insert into dbo.orden_venta(id_orden,id_metodo_pago,id_cliente) 
	 values		(5,1,1),
				(6,2,2),
				(7,2,3),
				(8,2,3)
	 go